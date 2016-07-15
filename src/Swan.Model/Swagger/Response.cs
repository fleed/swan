// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Response.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the Response type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Defines a response.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        public Response()
        {
            this.Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        public Schema Schema { get; set; }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        public IDictionary<string, Header> Headers { get; set; }

        /// <summary>
        /// Gets or sets the examples.
        /// </summary>
        public object Examples { get; set; }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; }
    }
}