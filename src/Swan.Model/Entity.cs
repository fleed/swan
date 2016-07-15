// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entity.cs" company="Swan Team">
//   Copyright � 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the Entity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model
{
    /// <summary>
    /// Defines an entity.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        /// <value>The name of the entity.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the properties of the entity.
        /// </summary>
        /// <value>The properties of the entity. It might be <c>null</c>.</value>
        public Property[] Properties { get; set; }
    }
}