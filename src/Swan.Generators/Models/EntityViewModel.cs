// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityViewModel.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the EntityViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Generators.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the properties required to render view models based on an entity.
    /// </summary>
    public class EntityViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityViewModel"/> class.
        /// </summary>
        public EntityViewModel()
        {
            this.Properties = new List<PropertyViewModel>();
        }

        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the namespace of the entity.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        public ICollection<PropertyViewModel> Properties { get; set; }
    }
}