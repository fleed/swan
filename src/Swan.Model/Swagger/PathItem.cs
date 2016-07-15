// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PathItem.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the PathItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Defines a path item.
    /// </summary>
    public class PathItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PathItem"/> class.
        /// </summary>
        public PathItem()
        {
            this.Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        [JsonProperty("$ref")]
        public string Ref { get; set; }

        /// <summary>
        /// Gets or sets the GET operation.
        /// </summary>
        public Operation Get { get; set; }

        /// <summary>
        /// Gets or sets the PUT operation.
        /// </summary>
        public Operation Put { get; set; }

        /// <summary>
        /// Gets or sets the POST operation.
        /// </summary>
        public Operation Post { get; set; }

        /// <summary>
        /// Gets or sets the DELETE operation.
        /// </summary>
        public Operation Delete { get; set; }

        /// <summary>
        /// Gets or sets the OPTIONS operation.
        /// </summary>
        public Operation Options { get; set; }

        /// <summary>
        /// Gets or sets the HEAD operation.
        /// </summary>
        public Operation Head { get; set; }

        /// <summary>
        /// Gets or sets the PATCH operation.
        /// </summary>
        public Operation Patch { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public IList<IParameter> Parameters { get; set; }

        /// <summary>
        /// Gets the extensions dictionary.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; }
    }
}