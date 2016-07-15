// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PartialSchema.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the PartialSchema type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines a partial schema.
    /// </summary>
    public class PartialSchema
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public PartialSchema Items { get; set; }

        /// <summary>
        /// Gets or sets the collection format.
        /// </summary>
        public string CollectionFormat { get; set; }

        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        public object Default { get; set; }

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
        /// Gets or sets the enum.
        /// </summary>
        public IList<object> Enum { get; set; }

        /// <summary>
        /// Gets or sets the multiple of.
        /// </summary>
        public int? MultipleOf { get; set; }
    }
}