// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderTemplatesCommand.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the RenderTemplatesCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Cli.Commands
{
    using System;
    using System.Threading.Tasks;

    using Core;

    /// <summary>
    /// Command used to generate a solution.
    /// </summary>
    internal class RenderTemplatesCommand : CommandBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderTemplatesCommand"/> class.
        /// </summary>
        /// <param name="basePath">
        /// The base path.
        /// </param>
        /// <param name="projectFilePath">The path to the Swan project.</param>
        public RenderTemplatesCommand(string basePath, string projectFilePath)
        {
            this.BasePath = basePath;
            this.ProjectFilePath = projectFilePath;
        }

        /// <summary>
        /// Gets the base path where the output should be generated.
        /// </summary>
        public string BasePath { get; }

        /// <summary>
        /// Gets or sets the project file path.
        /// </summary>
        public string ProjectFilePath { get; set; }

        /// <inheritdoc />
        public override async Task ExecuteAsync()
        {
            Console.WriteLine("Rendering templates");
            var builder =
                new ProjectBuilder()
                    .SetBasePath(this.BasePath)
                    .SetProjectFilePath(this.ProjectFilePath);
            var writer = builder.Build();
            await writer.WriteAsync();
        }
    }
}