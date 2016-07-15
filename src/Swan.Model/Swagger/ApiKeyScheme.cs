// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiKeyScheme.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the ApiKeyScheme type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    /// <summary>
    /// The API key scheme.
    /// </summary>
    public class ApiKeyScheme : SecurityScheme
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        public string In { get; set; }
    }
}