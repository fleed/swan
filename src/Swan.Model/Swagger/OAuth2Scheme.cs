// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OAuth2Scheme.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the OAuth2Scheme type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Model.Swagger
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the scheme for the OAuth2 protocol.
    /// </summary>
    public class OAuth2Scheme : SecurityScheme
    {
        /// <summary>
        /// Gets or sets the flow.
        /// </summary>
        public string Flow { get; set; }

        /// <summary>
        /// Gets or sets the authorization url.
        /// </summary>
        public string AuthorizationUrl { get; set; }

        /// <summary>
        /// Gets or sets the token url.
        /// </summary>
        public string TokenUrl { get; set; }

        /// <summary>
        /// Gets or sets the dictionary of scopes.
        /// </summary>
        public IDictionary<string, string> Scopes { get; set; }
    }
}