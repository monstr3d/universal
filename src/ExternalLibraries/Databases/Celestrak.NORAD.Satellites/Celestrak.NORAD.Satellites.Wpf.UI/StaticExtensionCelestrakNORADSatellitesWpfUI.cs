using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Diagram.UI;

using Scada.Interfaces;


namespace Celestrak.NORAD.Satellites.Wpf.UI
{
    /// <summary>
    /// Static extension
    /// </summary>
    [CategoryTheory.InitAssembly]
    public class StaticExtensionCelestrakNORADSatellitesWpfUI
    {

        internal static IScadaInterface ScadaDesign;

        internal const string CelestrakNORADSatellitesSatelliteData =
            "CelestrakNORADSatellitesSatelliteData";

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {
        }

        static StaticExtensionCelestrakNORADSatellitesWpfUI()
        {
            Scada.Desktop.StaticExtensionScadaDesktop.ScadaFactory.OnCreateXml +=
                (Diagram.UI.Interfaces.IDesktop desktop, XElement document) =>
                {
                    List<string> ls = new List<string>();
                    desktop.ForEach<SatelliteData>((SatelliteData satellite) =>
                     {
                         ls.Add(satellite.GetRootName());
                     });
                    document.AddItems(CelestrakNORADSatellitesSatelliteData, ls);
                };

            string s = Environment.GetEnvironmentVariable("SCADA_DESIGN");
            if (System.IO.File.Exists(s))
            {
                ScadaDesign = new EmptyScadaInterface(s);
            }
    
        }
    }
}