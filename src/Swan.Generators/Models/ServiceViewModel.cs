// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceViewModel.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the ServiceViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Generators.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the properties required to render view models based on a service.
    /// </summary>
    public class ServiceViewModel
    {
        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the namespace of the entity.
        /// </summary>
        public string Namespace { get; set; }
    }
}