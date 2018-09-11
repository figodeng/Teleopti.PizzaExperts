using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleopti.PizzaExperts.UI.Commands
{
    /// <summary>
    /// AbstractCommand
    /// </summary>
    internal abstract class AbstractCommand
    {
        /// <summary>
        /// Construction method
        /// </summary>
        /// <param name="commandLine">commandline</param>
        /// <param name="name">command name</param>
        public AbstractCommand(string commandLine, string name)
        {
            CommandLine = commandLine;
            Name = name;
        }

        /// <summary>
        /// Command
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// CommandLine
        /// </summary>
        public string CommandLine { get; private set; }

    }
}
