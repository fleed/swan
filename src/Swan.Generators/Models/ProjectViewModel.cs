// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectViewModel.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the ProjectViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Generators.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The project view model.
    /// </summary>
    public class ProjectViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectViewModel"/> class.
        /// </summary>
        public ProjectViewModel()
        {
            this.Entities = new List<EntityViewModel>();
        }

        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        public ICollection<EntityViewModel> Entities { get; set; }

        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the output name.
        /// </summary>
        public string OutputName { get; set; }
    }
}