using System.Collections.Generic;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Creates code for desktop
    /// </summary>
    public interface IDesktopCodeCreator
    {
        /// <summary>
        /// Creates code for desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="namespacE">The namespace</param>
        /// <param name="className">Name of desktop class</param>
        /// <param name="staticClass">The "static class" sign</param>
        /// <returns>The code</returns>
        List<string> CreateCode(IDesktop desktop, string namespacE,
            string className, bool staticClass = true);

      }
}
