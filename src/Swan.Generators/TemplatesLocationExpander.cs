namespace Swan.Generators
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.Razor;

    public class TemplatesLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return viewLocations.Select(f => f.Replace("/Views/", "/Templates/"));
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        { 
        }
    }
}