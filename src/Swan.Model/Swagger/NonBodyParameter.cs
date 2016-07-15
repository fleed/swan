// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NonBodyParameter.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the NonBodyParameter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Defines a parameter outside the body.
    /// </summary>
    public class NonBodyParameter : PartialSchema, IParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NonBodyParameter"/> class.
        /// </summary>
        public NonBodyParameter()
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
        public Dictionary<string, object> Extensions { get; }
    }
}