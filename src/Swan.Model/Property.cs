// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Property.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the Property type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a property.
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>The name of the property.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the property.
        /// </summary>
        /// <value>The type of the property.</value>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the property is required or not.
        /// </summary>
        /// <value><b>true</b> if the property is required; otherwise, <b>false</b>.</value>
        [JsonProperty("isRequired")]
        public bool IsRequired { get; set; }
    }
}