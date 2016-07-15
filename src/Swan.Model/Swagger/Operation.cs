// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Operation.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the Operation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Defines an operation.
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Operation"/> class.
        /// </summary>
        public Operation()
        {
            this.Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public IList<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the external docs.
        /// </summary>
        public ExternalDocs ExternalDocs { get; set; }

        /// <summary>
        /// Gets or sets the operation id.
        /// </summary>
        public string OperationId { get; set; }

        /// <summary>
        /// Gets or sets the list of types for input.
        /// </summary>
        public IList<string> Consumes { get; set; }

        /// <summary>
        /// Gets or sets the list of types for output.
        /// </summary>
        public IList<string> Produces { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public IList<IParameter> Parameters { get; set; }

        /// <summary>
        /// Gets or sets the responses.
        /// </summary>
        public IDictionary<string, Response> Responses { get; set; }

        /// <summary>
        /// Gets or sets the schemes.
        /// </summary>
        public IList<string> Schemes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether deprecated.
        /// </summary>
        public bool Deprecated { get; set; }

        /// <summary>
        /// Gets or sets the security dictionary.
        /// </summary>
        public IList<IDictionary<string, IEnumerable<string>>> Security { get; set; }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; }
    }
}