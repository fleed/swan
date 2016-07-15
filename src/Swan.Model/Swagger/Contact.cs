// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contact.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the Contact type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    /// <summary>
    /// The contact information.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }
    }
}