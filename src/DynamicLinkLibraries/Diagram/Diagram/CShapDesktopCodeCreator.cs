using System.Collections.Generic;

using Diagram.Attributes;
using Diagram.UI.Interfaces;

namespace Diagram.UI
{
    [Language("C#", ".cs")]
    internal class CShapDesktopCodeCreator : IDesktopCodeCreator
    {
        public CShapDesktopCodeCreator()
        {
            this.AddCodeCreator();
        }


        List<string> IDesktopCodeCreator.CreateCode(IDesktop desktop, string namespacE, string className, bool staticClass)
        {
            return desktop.CreateInitDesktopCSharpCode(namespacE, className, staticClass);
        }
    }
}
