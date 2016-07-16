// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Generator.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the Generator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Generators
{
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Hosting.Internal;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.ObjectPool;
    using Microsoft.Extensions.PlatformAbstractions;

    /// <summary>
    /// Defines the component that can generates content out of a template and a model.
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// Generates the content.
        /// </summary>
        /// <param name="templateName">
        /// The name of the template.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <returns>
        /// The generated content.
        /// </returns>
        public async Task<string> GenerateAsync<TModel>(string templateName, TModel model)
        {
            // Initialize the necessary services
            var services = new ServiceCollection();
            this.ConfigureDefaultServices(services);
            var provider = services.BuildServiceProvider();

            var renderer = provider.GetRequiredService<RazorViewToStringRenderer>();
            return await renderer.RenderViewToStringAsync(templateName, model);
        }

        private void ConfigureDefaultServices(IServiceCollection services)
        {
            var applicationEnvironment = PlatformServices.Default.Application;
            services.AddSingleton(applicationEnvironment);

            var appDirectory = Path.Combine(Directory.GetCurrentDirectory());

            var environment = new HostingEnvironment
            {
                WebRootFileProvider = new PhysicalFileProvider(appDirectory),
                ApplicationName = "Swan.Generators"
            };
            services.AddSingleton<IHostingEnvironment>(environment);

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Clear();
                options.FileProviders.Add(new PhysicalFileProvider(appDirectory));
                options.ViewLocationExpanders.Add(new TemplatesLocationExpander());
            });

            services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();

            var diagnosticSource = new DiagnosticListener("Microsoft.AspNetCore");
            services.AddSingleton<DiagnosticSource>(diagnosticSource);

            services.AddLogging();
            services.AddMvc();
            services.AddSingleton<RazorViewToStringRenderer>();
        }
    }
}