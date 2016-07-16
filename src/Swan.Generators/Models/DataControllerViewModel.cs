// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataControllerViewModel.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the DataControllerViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Generators.Models
{
    /// <summary>
    /// Defines the view model to generate a data controller.
    /// </summary>
    public class DataControllerViewModel : EntityViewModel
    {
        /// <summary>
        /// Gets or sets the name of the controller.
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        public string Route { get; set; }
    }
}