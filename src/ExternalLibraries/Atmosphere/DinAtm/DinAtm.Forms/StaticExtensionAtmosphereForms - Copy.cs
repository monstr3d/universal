using CategoryTheory;
using DinAtm.Forms.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinAtm.Forms
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExStaticExtensionAtmosphereForms
    {

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        static StaticExStaticExtensionAtmosphereForms()
        {
            new UIFactory();
        }

    }
}
