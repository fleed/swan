// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Namespace.cs" company="Swan Team">
//   Copyright � 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the Namespace type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model
{
    /// <summary>
    /// Defines a namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        /// <value>The entities. It might be <c>null</c>.</value>
        public Entity[] Entities { get; set; }
    }
}