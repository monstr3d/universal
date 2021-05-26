using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI;
using AssemblyService.Attributes;

namespace Gravity36.Wrapper
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionGravity36
    {
   
        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        static StaticExtensionGravity36()
        {
            new Replace();
        }

        class Replace : IReplaceAssembly
        {
            internal Replace()
            {
                this.Add();
            }

            #region IReplaceAssembly Members

            System.Reflection.Assembly IReplaceAssembly.Replace(System.Reflection.Assembly assembly)
            {
                string s = assembly.FullName;
                if (s.Equals("Grav36, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                    | s.Equals("Grav36, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null"))
                {
                    return typeof(Replace).Assembly;
                }
                if (s.Equals("Gravity36.Wrapper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                    | s.Equals("Grav36, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null"))
                {
                    return typeof(Replace).Assembly;
                }
                return null;
            }

            #endregion

        }

    }
}
