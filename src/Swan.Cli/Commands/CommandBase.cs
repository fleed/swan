// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandBase.cs" company="Swan Team">
//   Copyright © 2016 Swan Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the CommandBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Swan.Cli.Commands
{
    using System.Threading.Tasks;

    /// <summary>
    /// Base class for commands.
    /// </summary>
    public abstract class CommandBase
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> that can be awaited.
        /// </returns>
        public abstract Task ExecuteAsync();
    }
}