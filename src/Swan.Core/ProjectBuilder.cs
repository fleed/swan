namespace Swan.Core
{
    using Model;

    public class ProjectBuilder
    {
        public ProjectBuilder(Project project)
        {
            this.Project = project;
        }

        public Project Project { get; private set; }

        public string BasePath { get; private set; }

        public ProjectBuilder SetBasePath(string basePath)
        {
            return new ProjectBuilder(this.Project) { BasePath = basePath };
        }

        public ProjectWriter Build()
        {
            return new ProjectWriter(this.Project) { BasePath = this.BasePath };
        }
    }
}