// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConvertionExtensions.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the ConvertionExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model
{
    using Swagger;

    /// <summary>
    /// Extension methods used to convert objects.
    /// </summary>
    public static class ConvertionExtensions
    {
        /// <summary>
        /// Converts a Swan <see cref="Project"/> into a <see cref="SwaggerDocument"/>.
        /// </summary>
        /// <param name="project">The input project.</param>
        /// <returns>The corresponding <see cref="SwaggerDocument"/>.</returns>
        public static SwaggerDocument Convert(this Project project)
        {
            return new SwaggerDocument();
        }
    }
}