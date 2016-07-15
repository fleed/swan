// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Schema.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the Schema type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Defines a schema.
    /// </summary>
    public class Schema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> class.
        /// </summary>
        public Schema()
        {
            this.Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        [JsonProperty("$ref")]
        public string Ref { get; set; }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        public object Default { get; set; }

        /// <summary>
        /// Gets or sets the <c>multiple of</c> value.
        /// </summary>
        public int? MultipleOf { get; set; }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        public int? Maximum { get; set; }

        /// <summary>
        /// Gets or sets the exclusive maximum.
        /// </summary>
        public bool? ExclusiveMaximum { get; set; }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        public int? Minimum { get; set; }

        /// <summary>
        /// Gets or sets the exclusive minimum.
        /// </summary>
        public bool? ExclusiveMinimum { get; set; }

        /// <summary>
        /// Gets or sets the max length.
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// Gets or sets the min length.
        /// </summary>
        public int? MinLength { get; set; }

        /// <summary>
        /// Gets or sets the pattern.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Gets or sets the max items.
        /// </summary>
        public int? MaxItems { get; set; }

        /// <summary>
        /// Gets or sets the min items.
        /// </summary>
        public int? MinItems { get; set; }

        /// <summary>
        /// Gets or sets the unique items.
        /// </summary>
        public bool? UniqueItems { get; set; }

        /// <summary>
        /// Gets or sets the max properties.
        /// </summary>
        public int? MaxProperties { get; set; }

        /// <summary>
        /// Gets or sets the min properties.
        /// </summary>
        public int? MinProperties { get; set; }

        /// <summary>
        /// Gets or sets the names of the required properties.
        /// </summary>
        public IList<string> Required { get; set; }

        /// <summary>
        /// Gets or sets the enum values.
        /// </summary>
        public IList<object> Enum { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public Schema Items { get; set; }

        /// <summary>
        /// Gets or sets list of schema items used to compose this one.
        /// </summary>
        public IList<Schema> AllOf { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        public IDictionary<string, Schema> Properties { get; set; }

        /// <summary>
        /// Gets or sets the additional properties.
        /// </summary>
        public Schema AdditionalProperties { get; set; }

        /// <summary>
        /// Gets or sets the discriminator.
        /// </summary>
        public string Discriminator { get; set; }

        /// <summary>
        /// Gets or sets the read only.
        /// </summary>
        public bool? ReadOnly { get; set; }

        /// <summary>
        /// Gets or sets the xml.
        /// </summary>
        public Xml Xml { get; set; }

        /// <summary>
        /// Gets or sets the external docs.
        /// </summary>
        public ExternalDocs ExternalDocs { get; set; }

        /// <summary>
        /// Gets or sets the example.
        /// </summary>
        public object Example { get; set; }

        /// <summary>
        /// Gets the extensions dictionary.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; }
    }
}