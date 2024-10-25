using System;
using System.Collections.Generic;

using Scada.Desktop;
using Scada.Interfaces;

using Unity.Standard.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.Standard.Indicators
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
            Func<double?> f = null;
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
            float scale = d["Scale"].ToSingle();
            float limit = d["Limit"].ToSingle();
          /*  if (!float.TryParse(d["Limit"], CultureInfo.InvariantCulture.NumberFormat, null, out limit))
            {
                
                limit = 1f;
                if (double.TryParse(d["Limit"], out x))
                {
                    limit = (float)x;
                }
            }*/
            bool enableDebug = false;
            if (txt.ContainsKey("EnableDebug"))
            {
                string ed = txt["EnableDebug"][0].text;
                enableDebug = ed == "1";
            }
            if (txt.ContainsKey("Alias"))
            {
                string ali = txt["Alias"][0].text;
                new DubleFloatLimitFailure(f, new float[] { -limit, limit }, scale, ali);
                return new SliderWrapperLimits(par,
                gameObject.GetComponent<Component>(), scale, limit, f,
                Color.green, Color.red, format, enableDebug, ali, txt["Dimension"][0].text);
            }
              
            return new SliderWrapper(par,
                 gameObject.GetComponent<Component>(), scale, limit, f, 
                 Color.green, Color.red, format, enableDebug);

        }
    }
}
