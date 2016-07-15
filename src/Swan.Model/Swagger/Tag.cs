// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tag.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the Tag type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Defines a tag.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tag"/> class.
        /// </summary>
        public Tag()
        {
            this.Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the external docs.
        /// </summary>
        public ExternalDocs ExternalDocs { get; set; }

        /// <summary>
        /// Gets the extensions dictionary.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; }
    }
}