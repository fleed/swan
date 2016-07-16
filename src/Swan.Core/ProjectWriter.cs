// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectWriter.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the ProjectWriter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Core
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Generators;
    using Generators.Models;

    using Humanizer;

    using Model;

    using Serilog;

    /// <summary>
    /// The project writer.
    /// </summary>
    public class ProjectWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectWriter"/> class.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <param name="basePath">
        /// The base path where the project should be written.
        /// </param>
        internal ProjectWriter(Project project, string basePath)
        {
            if (project == null)
            {
                throw new ArgumentNullException("project");
            }

            if (string.IsNullOrEmpty(basePath))
            {
                throw new ArgumentOutOfRangeException("basePath", basePath, "The base path must be a non-empty string");
            }

            this.Project = project;
            this.BasePath = basePath;
        }

        /// <summary>
        /// Gets the Swan project.
        /// </summary>
        public Project Project { get; }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        public string BasePath { get; }

        /// <summary>
        /// Writes the project.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> that can be awaited.
        /// </returns>
        public async Task WriteAsync()
        {
            await this.WriteProgramAsync();
            await this.WriteStartupAsync();
            await this.WriteSettingsAsync();
            await this.WriteProjectJsonAsync();
            await this.WriteAppsettingsAsync();
            await this.WriteHostingAsync();
            await this.WriteRepositoriesAsync();
            await this.WriteConversionExtensionsAsync();
            await this.WriteDataContextAsync();
            foreach (var ns in this.Project.Namespaces)
            {
                foreach (var entity in ns.Entities)
                {
                    Log.Information("Writing entity {name}", entity.Name);
                    await this.WriteEntityAsync(entity);
                    await this.WriteDtoAsync(entity);
                    await this.WriteControllerAsync(entity);
                }
            }
        }

        private ProjectViewModel GetProjectViewModel(string name = null)
        {
            var ns = this.Project.Namespace;
            if (!string.IsNullOrEmpty(name))
            {
                ns += "." + name;
            }

            var projectViewModel = new ProjectViewModel { Namespace = ns, OutputName = this.Project.OutputName };
            foreach (var n in this.Project.Namespaces)
            {
                foreach (var entity in n.Entities)
                {
                    projectViewModel.Entities.Add(entity.Convert(ns));
                }
            }

            return projectViewModel;
        }

        private async Task WriteContentAsync<T>(
            string templateName,
            T model,
            string fileName,
            string folderPath = null,
            bool clearFolder = false)
        {
            var generator = new Generator();
            var directory = Path.Combine(this.BasePath, folderPath ?? string.Empty);
            var directoryInfo = new DirectoryInfo(directory);
            if (clearFolder && directoryInfo.Exists)
            {
                directoryInfo.Delete(true);
            }

            var outputPath = Path.Combine(directoryInfo.FullName, fileName);
            var content = await generator.GenerateAsync(templateName, model);
            await this.WriteFileAsync(outputPath, content);
        }

        private async Task WriteProgramAsync()
        {
            var model = this.GetProjectViewModel();
            await this.WriteContentAsync("Program.cs", model, "Program.generated.cs", clearFolder: true);
        }

        private async Task WriteStartupAsync()
        {
            var model = this.GetProjectViewModel();
            await this.WriteContentAsync("Startup.cs", model, "Startup.generated.cs");
        }

        private async Task WriteSettingsAsync()
        {
            var model = this.GetProjectViewModel();
            await this.WriteContentAsync("Settings.cs", model, "Settings.generated.cs");
        }

        private async Task WriteProjectJsonAsync()
        {
            var model = this.GetProjectViewModel();
            await this.WriteContentAsync("project.json", model, "project.json");
        }

        private async Task WriteAppsettingsAsync()
        {
            var model = new DataControllerViewModel { Namespace = this.Project.Namespace };
            await this.WriteContentAsync("appsettings.json", model, "appsettings.json");
        }

        private async Task WriteHostingAsync()
        {
            var model = new DataControllerViewModel { Namespace = this.Project.Namespace };
            await this.WriteContentAsync("hosting.json", model, "hosting.json");
        }

        private async Task WriteControllerAsync(Entity entity)
        {
            var controllerName = entity.Name.Pluralize();
            var model = new DataControllerViewModel
            {
                Name = entity.Name,
                ControllerName = controllerName,
                Namespace = this.Project.Namespace,
                Route = "/api/v1/data/" + controllerName.Underscore().Dasherize()
            };
            var fileName = string.Format("{0}Controller.generated.cs", model.Name.Pluralize());
            await this.WriteContentAsync("DataController.cs", model, fileName, "Controllers");
        }

        private async Task WriteRepositoriesAsync()
        {
            var projectViewModel = this.GetProjectViewModel("Data");
            var models =
                projectViewModel.Entities.Select(
                    entity =>
                        {
                            var controllerName = entity.Name.Pluralize();
                            return new DataControllerViewModel
                                             {
                                                 ControllerName = controllerName,
                                                 Name = entity.Name,
                                                 Namespace = entity.Namespace,
                                                 Route = "/api/v1/data/" + controllerName.Underscore().Dasherize(),
                                                 Properties = entity.Properties
                                             };
                        });
            foreach (var model in models)
            {
                await this.WriteRepositoryInterfaceAsync(model);
                await this.WriteRepositoryAsync(model);
            }

            await this.WriteContentAsync("UpdateResult.cs", projectViewModel, "UpdateResult.generated.cs", "Data");
        }

        private async Task WriteRepositoryInterfaceAsync(DataControllerViewModel entity)
        {
            var fileName = string.Format("I{0}Repository.generated.cs", entity.Name);
            await this.WriteContentAsync("IRepository.cs", entity, fileName, "Data");
        }

        private async Task WriteRepositoryAsync(DataControllerViewModel entity)
        {
            var fileName = string.Format("{0}Repository.generated.cs", entity.Name);
            await this.WriteContentAsync("Repository.cs", entity, fileName, "Data");
        }

        private async Task WriteConversionExtensionsAsync()
        {
            var projectViewModel = this.GetProjectViewModel("Data");
            await
                this.WriteContentAsync(
                    "ConversionExtensions.cs",
                    projectViewModel,
                    "ConversionExtensions.generated.cs",
                    "Data");
        }

        private async Task WriteDataContextAsync()
        {
            var projectViewModel = this.GetProjectViewModel("Entities");
            await this.WriteContentAsync("DataContext.cs", projectViewModel, "DataContext.generated.cs", "Entities");
        }

        private async Task WriteEntityAsync(Entity entity)
        {
            var model = entity.Convert(this.Project.Namespace);
            var fileName = string.Format("{0}.generated.cs", model.Name);
            await this.WriteContentAsync("Entity.cs", model, fileName, "Entities");
        }

        private async Task WriteDtoAsync(Entity entity)
        {
            var model = entity.Convert(this.Project.Namespace);
            var fileName = string.Format("{0}.generated.cs", model.Name);
            await this.WriteContentAsync("Dto.cs", model, fileName, "Dto");
        }

        private async Task WriteFileAsync(string path, string content)
        {
            var fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            else if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }

            Log.Information("Writing file {path}", path);
            using (var file = File.OpenWrite(path))
            {
                using (var streamWriter = new StreamWriter(file))
                {
                    await streamWriter.WriteAsync(content);
                }
            }
        }
    }
}