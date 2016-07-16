// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectBuilder.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the ProjectBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Core
{
    using System;
    using System.IO;

    using Model;

    using Newtonsoft.Json;

    /// <summary>
    /// Utility class used to build a <see cref="Project"/> using a fluent interface.
    /// </summary>
    public class ProjectBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectBuilder"/> class.
        /// </summary>
        public ProjectBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectBuilder"/> class.
        /// </summary>
        /// <param name="builder">
        /// The base builder.
        /// </param>
        private ProjectBuilder(ProjectBuilder builder)
        {
            this.BasePath = builder.BasePath;
            this.ProjectFilePath = builder.ProjectFilePath;
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        public string BasePath { get; private set; }

        /// <summary>
        /// Gets the project file path.
        /// </summary>
        public string ProjectFilePath { get; private set; }

        /// <summary>
        /// Sets the base path.
        /// </summary>
        /// <param name="basePath">
        /// The base path.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectBuilder"/>.
        /// </returns>
        public ProjectBuilder SetBasePath(string basePath)
        {
            return new ProjectBuilder(this) { BasePath = basePath };
        }

        /// <summary>
        /// Sets the file path for the project file.
        /// </summary>
        /// <param name="projectFilePath">
        /// The project file path.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectBuilder"/>.
        /// </returns>
        public ProjectBuilder SetProjectFilePath(string projectFilePath)
        {
            return new ProjectBuilder(this) { ProjectFilePath = projectFilePath };
        }

        /// <summary>
        /// Builds the <see cref="ProjectWriter"/> relative to this configured builder.
        /// </summary>
        /// <returns>
        /// The <see cref="ProjectWriter"/>.
        /// </returns>
        public ProjectWriter Build()
        {
            if (string.IsNullOrEmpty(this.ProjectFilePath))
            {
                throw new ArgumentException("The project file path must be specified");
            }

            string content;
            using (var stream = File.OpenText(this.ProjectFilePath))
            {
                content = stream.ReadToEnd();
            }

            var project = JsonConvert.DeserializeObject<Project>(content);
            return new ProjectWriter(project, this.BasePath);
        }
    }
}