﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI.Interfaces;
using Animation.Interfaces;
using Animation.Interfaces.Enums;
using AssemblyService.Attributes;

namespace Animation
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionAnimationInterfaces
    {

        #region Private

        static StaticExtensionAnimationInterfaces()
        {
            Interfaces.StaticExtensionAnimationInterfaces.Driver =
                AssemblyService.StaticExtensionAssemblyService.GetFirstInterfaceObjectFromBaseDirectory<IAnimationDriver>();
        }

        #endregion

    }
}
