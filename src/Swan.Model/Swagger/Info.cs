// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Info.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the Info type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// The info about the Swagger document.
    /// </summary>
    public class Info
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Info"/> class.
        /// </summary>
        public Info()
        {
            this.Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the terms of service.
        /// </summary>
        public string TermsOfService { get; set; }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Gets or sets the license.
        /// </summary>
        public License License { get; set; }

        /// <summary>
        /// Gets the extensions dictionary.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; private set; }
    }
}