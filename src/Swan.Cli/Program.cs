// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Cli
{
    using System;
    using System.Linq;

    using Commands;

    using Microsoft.Extensions.CommandLineUtils;

    using Serilog;

    /// <summary>
    /// Defines the entry point for the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry point for the application.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            Log.Logger =
                new LoggerConfiguration().Enrich.FromLogContext()
                    .MinimumLevel.Verbose()
                    .WriteTo.LiterateConsole()
                    .CreateLogger();
            try
            {
                var application = new CommandLineApplication();
                application.Command("generate", RenderTemplates);
                var result = application.Execute(args);
                Environment.Exit(result);
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "Fatality");
                Environment.Exit(-1);
            }
        }

        private static void RenderTemplates(CommandLineApplication application)
        {
            application.Description = "Renders templates";
            application.Option("-n", "Name", CommandOptionType.SingleValue);
            application.Option("-o", "Output", CommandOptionType.SingleValue);
            application.Option("-p", "Path to the Project file", CommandOptionType.SingleValue);
            application.OnExecute(
                async () =>
                    {
                        CommandBase command;
                        try
                        {
                            var basePath = application.Options.Single(o => o.ShortName == "o").Value();
                            var projectFilePath = application.Options.Single(o => o.ShortName == "p").Value();
                            command =
                                new RenderTemplatesCommand(basePath, projectFilePath);
                        }
                        catch (Exception exception)
                        {
                            Log.Error(exception, "Couldn't create the command.");
                            return -1;
                        }

                        var executor = new CommandExecutor(command);
                        return await executor.ExecuteAsync();
                    });
        }
    }
}