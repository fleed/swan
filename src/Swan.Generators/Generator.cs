namespace Swan.Generators
{
    using System.Diagnostics;
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Hosting.Internal;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.ObjectPool;
    using Microsoft.Extensions.PlatformAbstractions;

    public class Generator
    {
        public string Generate<TModel>(string templateName, TModel model)
        {
            // Initialize the necessary services
            var services = new ServiceCollection();
            this.ConfigureDefaultServices(services);
            var provider = services.BuildServiceProvider();

            var renderer = provider.GetRequiredService<RazorViewToStringRenderer>();

            // Build a model and render a view
            
            return renderer.RenderViewToString(templateName, model);
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