// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Header.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the Header type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    /// <summary>
    /// Defines the header.
    /// </summary>
    public class Header : PartialSchema
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
    }
}