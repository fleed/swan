// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemplatesLocationExpander.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the TemplatesLocationExpander type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Generators
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc.Razor;

    /// <summary>
    /// Custom <see cref="IViewLocationExpander"/> used to define the view locations for templates.
    /// </summary>
    public class TemplatesLocationExpander : IViewLocationExpander
    {
        /// <inheritdoc />
        public IEnumerable<string> ExpandViewLocations(
            ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            return viewLocations.Select(f => f.Replace("/Views/", "/Templates/"));
        }

        /// <inheritdoc />
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // nothing to do here
        }
    }
}