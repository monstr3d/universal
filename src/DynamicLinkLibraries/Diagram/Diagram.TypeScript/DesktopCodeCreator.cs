using Diagram.Attributes;
using Diagram.UI;
using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.TypeScript
{
    [Language("TS")]
    internal class DesktopCodeCreator : IDesktopCodeCreator
    {

        public DesktopCodeCreator() { this.AddCodeCreator(); }

        /// <summary>
        /// Creates code for desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="namespacE">The namespace</param>
        /// <param name="className">Name of desktop class</param>
        /// <param name="staticClass">The "static class" sign</param>
        /// <returns>The code</returns>
        List<string> IDesktopCodeCreator.CreateCode(IDesktop desktop, string namespacE, string className, bool staticClass)
        {
            throw new OwnNotImplemented();
        }
    }
}
