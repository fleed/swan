// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IParameter.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the IParameter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines a parameter.
    /// </summary>
    public interface IParameter
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        string In { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the parameter is required.
        /// </summary>
        bool Required { get; set; }

        /// <summary>
        /// Gets the extensions dictionary.
        /// </summary>
        Dictionary<string, object> Extensions { get; }
    }
}