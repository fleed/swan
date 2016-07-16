// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Swan.Core
{
    using System.Linq;

    using Generators.Models;
    using Model;

    /// <summary>
    /// The extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Converts an entity to an equivalent entity view model.
        /// </summary>
        /// <param name="value">
        /// The value to convert.
        /// </param>
        /// <param name="ns">
        /// The namespace.
        /// </param>
        /// <returns>
        /// The <see cref="EntityViewModel"/> equivalent to the input entity.
        /// </returns>
        public static EntityViewModel Convert(this Entity value, string ns)
        {
            return new EntityViewModel
                       {
                           Name = value.Name,
                           Namespace = ns,
                           Properties = value.Properties.Select(Convert).ToList()
                       };
        }

        /// <summary>
        /// Converts a property to an equivalent property view model.
        /// </summary>
        /// <param name="property">
        /// The property to convert.
        /// </param>
        /// <returns>
        /// The <see cref="PropertyViewModel"/> equivalent to the input property.
        /// </returns>
        public static PropertyViewModel Convert(this Property property)
        {
            return new PropertyViewModel { Name = property.Name, Type = property.Type };
        }
    }
}