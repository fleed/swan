// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataContextViewModel.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the DataContextViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Generators
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the view model used to generate the code for a data context.
    /// </summary>
    public class DataContextViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContextViewModel"/> class.
        /// </summary>
        public DataContextViewModel()
        {
            this.Entities = new List<string>();
        }

        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets the entities.
        /// </summary>
        public ICollection<string> Entities { get; }
    }
}