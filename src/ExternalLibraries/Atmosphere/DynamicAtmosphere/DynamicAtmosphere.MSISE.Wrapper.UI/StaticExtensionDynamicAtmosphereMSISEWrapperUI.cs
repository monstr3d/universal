using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicAtmosphere.MSISE.Wrapper.UI
{
    /// <summary>
    /// Static extension
    /// </summary>
    static internal class StaticExtensionDynamicAtmosphereMSISEWrapperUI
    {
        static internal readonly string[] Switches = new string[]
        {
            "output in centimeters instead of meters",
            "F10.7 effect on mean",
            "time independent",
            "symmetrical annual",
            "symmetrical semiannual",
            "asymmetrical annual",
            "asymmetrical semiannual",
            "diurnal",
            "semidiurnal",
            "daily ap [when this is set to -1 (!) the pointer ap_a in struct nrlmsise_input must point to a struct ap_array",
            "all UT/long effects",
            "longitudinal",
            "UT and mixed UT/long",
            "mixed AP/UT/LONG",
            "terdiurnal",
            "departures from diffusive equilibrium",
            "all TINF var",
            "all TLB var",
            "all TN1 var",
            "all S var",
            "all TN2 var",
            "all NLB var",
            "all TN3 var",
            "turbo scale height var"
        };
    }
}