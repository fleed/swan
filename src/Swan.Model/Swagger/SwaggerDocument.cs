// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwaggerDocument.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the SwaggerDocument type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Defines a Swagger document.
    /// </summary>
    public class SwaggerDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerDocument"/> class.
        /// </summary>
        public SwaggerDocument()
        {
            this.Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets the swagger version.
        /// </summary>
        public string Swagger
        {
            get { return "2.0"; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Info"/>.
        /// </summary>
        public Info Info { get; set; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the base path.
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// Gets or sets the schemes.
        /// </summary>
        public IList<string> Schemes { get; set; }

        /// <summary>
        /// Gets or sets the list of supported types for input.
        /// </summary>
        public IList<string> Consumes { get; set; }

        /// <summary>
        /// Gets or sets the list of supported types for output.
        /// </summary>
        public IList<string> Produces { get; set; }

        /// <summary>
        /// Gets or sets the paths.
        /// </summary>
        public IDictionary<string, PathItem> Paths { get; set; }

        /// <summary>
        /// Gets or sets the definitions.
        /// </summary>
        public IDictionary<string, Schema> Definitions { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public IDictionary<string, IParameter> Parameters { get; set; }

        /// <summary>
        /// Gets or sets the responses.
        /// </summary>
        public IDictionary<string, Response> Responses { get; set; }

        /// <summary>
        /// Gets or sets the security definitions.
        /// </summary>
        public IDictionary<string, SecurityScheme> SecurityDefinitions { get; set; }

        /// <summary>
        /// Gets or sets the security dictionary.
        /// </summary>
        public IList<IDictionary<string, IEnumerable<string>>> Security { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public IList<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets the external docs.
        /// </summary>
        public ExternalDocs ExternalDocs { get; set; }

        /// <summary>
        /// Gets the extensions dictionary.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; private set; }
    }
}