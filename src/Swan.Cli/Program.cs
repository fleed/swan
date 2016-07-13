namespace Swan.Cli
{
    using System;
    using System.Linq;
    using System.IO;

    using Serilog;

    using Core;
    using Generators;
    using Model;

    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Get help: SwanCli -h");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.LiterateConsole()
                .CreateLogger();
            if (args.Length > 0 && args.Contains("gen"))
            {
                RenderTemplates();
                return;
            }
        }

        private static void RenderTemplates()
        {
            Console.WriteLine("Rendering templates");
            var project = new Project{
                Namespace = "MyBuilderNamespace"
            };
            project.Entities = new [] {
                new Entity {
                    Name = "MyEntity"
                }
            };
            var builder = new ProjectBuilder(project)
                .SetBasePath("/Users/francesco/Desktop/output");
            var writer = builder.Build();
            writer.WriteAsync().Wait();
        }
    }
}