using Scada.Desktop;
using Scada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.Standard
{
    public class SliderIndicatorFactory : IIndicatorFactory
    {
        public SliderIndicatorFactory()
        {

        }

        IIndicator IIndicatorFactory.Get(GameObject gameObject)
        {
            var txt = gameObject.GetGameObjectComponents<Text>();
            var tt = new string[] { "ValueText", "Format", "Desktop", "Parameter", "Limit", "Scale" };
            var d = new Dictionary<string, string>();
            foreach (var key in tt)
            {
                if (!txt.ContainsKey(key))
                {
                    return null;
                }
                if (txt[key].Count > 1)
                {
                    return null;
                }
                d[key] = txt[key][0].text;
            }
            string desktop = d["Desktop"];
            IScadaInterface scada = desktop.ToExistedScada();
            Func<double> f = null;
            string par = desktop + ".";
            if (scada != null)
            {
                double a = 0;
                string so = d["Parameter"];
                var ou = scada.Outputs;
                if (ou.ContainsKey(so))
                {
                    if (ou[so].Equals(a))
                    {
                        f = scada.GetDoubleOutput(so);
                        par += so;
                    }
                }
            }
            string format = "0.00";
            if (d["Format"].Length > 0)
            {
                format = d["Format"];
            }
            float scale;
            float limit;
            if (!float.TryParse(d["Scale"], out scale))
            {
                scale = 1f;
            }
            if (!float.TryParse(d["Limit"], out limit))
            {
                limit = 1f;
            }
            bool enableDebug = false;
            if (txt.ContainsKey("EnableDebug"))
            {
                string ed = txt["EnableDebug"][0].text;
                enableDebug = ed == "1";
            }
            return new SliderWrapper(par,
                 gameObject.GetComponent<Component>(), scale, limit, f, 
                 Color.green, Color.red, format, enableDebug);

        }
    }
}
