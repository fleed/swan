namespace Swan.Core
{
    using System.Threading.Tasks;
    using System.IO;

    using Serilog;

    using Generators;
    using Model;

    public class ProjectWriter
    {
        internal ProjectWriter(Project project)
        {
            this.Project = project;
        }

        public Project Project { get; private set; }
        public string BasePath { get; internal set; }

        public async Task WriteAsync()
        {
            await this.WriteProgramAsync();
            await this.WriteStartupAsync();
            await this.WriteProjectJsonAsync();
            foreach (var ns in this.Project.Namespaces)
            {
                foreach (var entity in ns.Entities)
                {
                    Log.Information("Writing entity {name}", entity.Name);
                    await this.WriteEntityAsync(entity);
                    await this.WriteRepositoryInterfaceAsync(entity);
                    await this.WriteRepositoryAsync(entity);
                    await this.WriteConversionExtensionsAsync();
                    await this.WriteAppsettingsAsync();
                    await this.WriteHostingAsync();
                    await this.WriteDataContextAsync();
                    await this.WriteDtoAsync(entity);
                    await this.WriteControllerAsync(entity);
                }
            }
        }

        private async Task WriteProgramAsync()
        {
            var generator = new Generator();

            var model = new DataControllerViewModel
            {
                KeyType = "Guid",
                Name = "Program",
                Namespace = this.Project.Namespace
            };
            var content = generator.Generate("Program.cs", model);
            var outputPath = Path.Combine(this.BasePath, "Program.generated.cs");
            await this.WriteFileAsync(outputPath, content);
        }

        private async Task WriteStartupAsync()
        {
            var generator = new Generator();

            var model = new DataControllerViewModel
            {
                KeyType = "Guid",
                Name = "Startup",
                Namespace = this.Project.Namespace
            };
            var content = generator.Generate("Startup.cs", model);
            var outputPath = Path.Combine(this.BasePath, "Startup.generated.cs");
            await this.WriteFileAsync(outputPath, content);
        }

        private async Task WriteProjectJsonAsync()
        {
            var generator = new Generator();

            var model = new DataControllerViewModel
            {
                KeyType = "Guid",
                Name = "Project",
                Namespace = this.Project.Namespace
            };
            var content = generator.Generate("project.json", model);
            var outputPath = Path.Combine(this.BasePath, "project.json");
            await this.WriteFileAsync(outputPath, content);
        }

        private async Task WriteControllerAsync(Entity entity)
        {
            var generator = new Generator();

            var model = new DataControllerViewModel
            {
                KeyType = "Guid",
                Name = entity.Name,
                Namespace = this.Project.Namespace,
                Route = "/api/v1/data/[controller]"
            };
            var directory = Path.Combine(this.BasePath, "Controllers");

            var content = generator.Generate("DataController.cs", model);
            var outputPath = Path.Combine(directory, $"{model.Name}Controller.generated.cs");
            await this.WriteFileAsync(outputPath, content);
        }

        private async Task WriteRepositoryInterfaceAsync(Entity entity)
        {
            var generator = new Generator();

            var model = new DataControllerViewModel
            {
                Name = entity.Name,
                Namespace = this.Project.Namespace + ".Data",
                Route = "/api/v1/data/[controller]"
            };
            var directory = Path.Combine(this.BasePath, "Data");

            var content = generator.Generate("IRepository.cs", model);
            var outputPath = Path.Combine(directory, $"I{model.Name}Repository.generated.cs");
            await this.WriteFileAsync(outputPath, content);
        }

        private async Task WriteRepositoryAsync(Entity entity)
        {
            var generator = new Generator();

            var model = new DataControllerViewModel
            {
                Name = entity.Name,
                Namespace = this.Project.Namespace + ".Data",
                Route = "/api/v1/data/[controller]"
            };
            var directory = Path.Combine(this.BasePath, "Data");

            var content = generator.Generate("Repository.cs", model);
            var outputPath = Path.Combine(directory, $"{model.Name}Repository.generated.cs");
            await this.WriteFileAsync(outputPath, content);
        }

        private async Task WriteConversionExtensionsAsync()
        {
            var generator = new Generator();

            var model = new DataControllerViewModel
            {
                Namespace = this.Project.Namespace + ".Data",
                Route = "/api/v1/data/[controller]"
            };
            var directory = Path.Combine(this.BasePath, "Data");

            var content = generator.Generate("ConversionExtensions.cs", model);
            var outputPath = Path.Combine(directory, "ConversionExtensions.generated.cs");
            await this.WriteFileAsync(outputPath, content);
        }

        private async Task WriteDataContextAsync()
        {
            var generator = new Generator();

            var model = new DataContextViewModel
            {
                Namespace = this.Project.Namespace + ".Entities",
                Entities = {
                    "MyEntity"
                }
            };
            var directory = Path.Combine(this.BasePath, "Entities");

            var content = generator.Generate("DataContext.cs", model);
            var outputPath = Path.Combine(directory, "DataContext.generated.cs");
            await this.WriteFileAsync(outputPath, content);
        }

        private async Task WriteAppsettingsAsync()
        {
            var generator = new Generator();

            var model = new DataControllerViewModel
            {
                Namespace = this.Project.Namespace
            };

            var content = generator.Generate("appsettings.json", model);
            var outputPath = Path.Combine(this.BasePath, "appsettings.json");
            await this.WriteFileAsync(outputPath, content);
        }

        private async Task WriteHostingAsync()
        {
            var generator = new Generator();

            var model = new DataControllerViewModel
            {
                Namespace = this.Project.Namespace
            };

            var content = generator.Generate("hosting.json", model);
            var outputPath = Path.Combine(this.BasePath, "hosting.json");
            await this.WriteFileAsync(outputPath, content);
        }

        private async Task WriteEntityAsync(Entity entity)
        {
            var generator = new Generator();

            var model = new DataControllerViewModel
            {
                KeyType = "Guid",
                Name = entity.Name,
                Namespace = this.Project.Namespace
            };
            var directory = Path.Combine(this.BasePath, "Entities");

            var content = generator.Generate("Entity.cs", model);
            var outputPath = Path.Combine(directory, $"{model.Name}.generated.cs");
            await this.WriteFileAsync(outputPath, content);
        }

        private async Task WriteDtoAsync(Entity entity)
        {
            var generator = new Generator();

            var model = new DataControllerViewModel
            {
                KeyType = "Guid",
                Name = entity.Name,
                Namespace = this.Project.Namespace
            };
            var directory = Path.Combine(this.BasePath, "Dto");

            var content = generator.Generate("Dto.cs", model);
            var outputPath = Path.Combine(directory, $"{model.Name}.generated.cs");
            await this.WriteFileAsync(outputPath, content);
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