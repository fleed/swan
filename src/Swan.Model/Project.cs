namespace Swan.Model
{
    /// <summary>
    /// Defines a Swan project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Gets or sets the base namespace for the project.
        /// </summary>
        /// <value>The base namespace for the project.</value>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the namespaces.
        /// </summary>
        /// <value>The namespaces. It might be <c>null</c>.</value>
        public Namespace[] Namespaces { get; set; }
    }
}