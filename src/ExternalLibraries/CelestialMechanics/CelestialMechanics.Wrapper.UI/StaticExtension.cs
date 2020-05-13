using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI;

namespace CelestialMechanics.Wrapper.UI
{
    /// <summary>
    /// Static extension
    /// </summary>
    public class StaticExtensionCelestialMechanicsWrapperUI
    {
        static StaticExtensionCelestialMechanicsWrapperUI()
        {
            new Replace();
        }
    }

    class Replace : Diagram.UI.Interfaces.IReplaceAssembly
    {
        internal Replace()
        {
            this.Add();
        }

        #region IReplaceAssembly Members

        Assembly Diagram.UI.Interfaces.IReplaceAssembly.Replace(Assembly assembly)
        {
            if (assembly.FullName.Equals("Celestrak.NORAD.Satellites.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"))
            {
                     return typeof(CelestialMechanics.Wrapper.UI.Replace).Assembly;
            }
            return null;
        }
        
        #endregion
    }


}
