using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Diagram.UI;
using Diagram.UI.Interfaces;

namespace DinAtm
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [CategoryTheory.InitAssembly()]
    public static class StaticExtensionAtmosphere
    {
        /// <summary>
        /// First
        /// </summary>
        static bool first = true;

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {
            if (!first)
            {
                return;
            }
            first = false;
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
         
                //        if (System.IO.File.Exists(f))*/
                //      {

                if (s.Contains("DinAtm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null") |
                        s.Contains("DinAtm, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null") |
                        s.Contains("DinAtm, Version=1.0.0.2, Culture=neutral, PublicKeyToken=null") |
                        s.Contains("DinAtm, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null"))
                    {
                        return typeof(Atmosphere).Assembly;
                    }

                return null;
            }

            #endregion

        }

    }
}
