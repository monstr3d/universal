﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI;

using Http.Meteo.UI.Factory;

namespace Http.Meteo.UI
{
    [InitAssembly]
    public static class StaticExtensionHttpMeteoUI
    {

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        static StaticExtensionHttpMeteoUI()
        {
            (new UIFactory()).Add();
        }
    }
}
