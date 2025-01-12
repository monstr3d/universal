using System;
using System.Collections.Generic;

using Scada.Desktop;
using Scada.Interfaces;

using Unity.Standard.Interfaces;

using UnityEngine;
using UnityEngine.UI;

namespace Unity.Standard.Indicators
{
    /// <summary>
    /// Factory of text indicators
    /// </summary>
    public class TextIndicatorFactory : IIndicatorFactory
    {

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public TextIndicatorFactory()
        {

        }

        #endregion

        IIndicator IIndicatorFactory.Get(GameObject gameObject)
        {
            var txt = gameObject.GetGameObjectComponents<Text>();
            var tt = new string[] {  "Desktop", "Parameter", "TextIndicator", "ValueText" };
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
            var desktop = d["Desktop"];
            var scada = desktop.ToExistedScada();
            Func<double?> f = null;
            string par = desktop + ".";
            bool debug = false;
            if (txt.ContainsKey("Debug"))
            {
                if (txt["Debug"][0].text == "1")
                {
                    debug = true;
                }
            }
            if (scada != null)
            {
                double a = 0;
                string so = d["Parameter"];
                var ou = scada.Outputs;
                string format = null;
                if (txt.ContainsKey("Format"))
                {
                    format = txt["Format"][0].text;
                }
                if (ou.ContainsKey(so))
                {
                    return new TextIndicator(par + so, txt["ValueText"][0], ou[so], format, debug);
                    if (ou[so].Equals(a))
                    {
                        f = scada.GetDoubleOutput(so);
                        par += so;
                        return new TextIndicator(par, txt["Text"][0], null, null, debug);
                    }
                }
            }
            return null;
        }
    }
}
