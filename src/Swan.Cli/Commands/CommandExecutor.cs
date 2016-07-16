// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandExecutor.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the CommandExecutor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Cli.Commands
{
    using System;
    using System.Threading.Tasks;

    using Serilog;

    /// <summary>
    /// Executes commands, return integer codes for the result of the execution.
    /// </summary>
    public class CommandExecutor
    {
        private readonly CommandBase command;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandExecutor"/> class.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        public CommandExecutor(CommandBase command)
        {
            this.command = command;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <returns>
        /// The integer result of the execution.
        /// </returns>
        public async Task<int> ExecuteAsync()
        {
            try
            {
                await this.command.ExecuteAsync();
                return 0;
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error while executing the command");
                return -1;
            }
        }
    }
}