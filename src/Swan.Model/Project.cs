// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Project.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the Project type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a Swan project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the output name of the project.
        /// </summary>
        [JsonProperty("outputName")]
        public string OutputName { get; set; }

        /// <summary>
        /// Gets or sets the base namespace for the project.
        /// </summary>
        /// <value>The base namespace for the project.</value>
        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the namespaces.
        /// </summary>
        /// <value>The namespaces. It might be <c>null</c>.</value>
        [JsonProperty("namespaces")]
        public Namespace[] Namespaces { get; set; }
    }
}