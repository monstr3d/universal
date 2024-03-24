using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.UI.Interfaces
{
    public interface IExecuteCommand
    {
        /// <summary>
        /// Executes a command
        /// </summary>
        /// <param name="command">The command for execution</param>
        void Execute(string command);
    }
}
