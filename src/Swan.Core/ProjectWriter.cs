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
            foreach (var entity in this.Project.Entities)
            {
                await this.WriteEntityAsync(entity);
                await this.WriteDtoAsync(entity);
                await this.WriteControllerAsync(entity);
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