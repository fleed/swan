// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BodyParameter.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the BodyParameter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Describes a body parameter.
    /// </summary>
    public class BodyParameter : IParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyParameter"/> class.
        /// </summary>
        public BodyParameter()
        {
            this.Extensions = new Dictionary<string, object>();
        }

        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public string In { get; set; }

        /// <inheritdoc />
        public string Description { get; set; }

        /// <inheritdoc />
        public bool Required { get; set; }

        /// <inheritdoc />
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; private set; }

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        public Schema Schema { get; set; }
    }
}