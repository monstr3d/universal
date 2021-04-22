using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynamic.Atmosphere
{
    /// <summary>
    /// Static extensions
    /// </summary>
    public static class StaticExtensionDynamicAtmosphere
    {
        static internal DateTime ToDateTime(this double time)
        {
            return DateTime.FromBinary((long)(time / 10000000));
        }
    }
}
