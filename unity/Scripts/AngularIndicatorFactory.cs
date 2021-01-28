using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


using Diagram.UI;
using Diagram.UI.Interfaces;

using Motion6D.Interfaces;

using Scada.Desktop;
using Scada.Interfaces;

using Unity.Standard;

namespace Scripts
{
    public class AngularIndicatorFactory : IIndicatorFactory
    {

        #region Fields

        string desktop;

        string par;

        #endregion

        public AngularIndicatorFactory()
        {

        }

        IIndicator IIndicatorFactory.Get(GameObject gameObject)
        {
            string[] ss = { "AngularDesktop", "AngularParameter" };
            var im = gameObject.GetGameObjectComponents<Image>();
            var txt = gameObject.GetGameObjectComponents<Text>();
            var sdic = new Dictionary<string, string>();
            foreach (var s in ss)
            {
                if (!txt.ContainsKey(s))
                {
                    return null;
                }
                var l = txt[s];
                if (l.Count > 1)
                {
                    return null;
                }
                sdic[s] = l[0].text;
            }
            string desktop = sdic[ss[0]];
            IScadaInterface scada = desktop.ToExistedScada();
            if (scada == null)
            {
                return null;
            }
            string par = sdic[ss[1]];
            Func<object> f = null;
            IReferenceFrame frame = null;
            if (scada.Outputs.ContainsKey(par))
            {
                if (scada.Outputs[par].Equals(typeof(ReferenceFrame)))
                {
                    f = scada.GetOutput(par);
                }
            }
            if (f == null)
            {
                IDesktop desk = scada.GetDesktop();
                desk.ForEach((IReferenceFrame fr) =>
                {
                    if (fr.GetName(desk) == par)
                    {
                        frame = fr;
                    }
                });
            }
            if ((frame == null) & (f == null))
            {
                return null;
            }
            Text[] headT = new Text[] { txt["heading_Indicator"][0], txt["Heading_Indicator_Text"][0] };
            Image mask = im["Bank_fix"][0];
            Image maskR = im["Bank_fix_Red"][0];
            return new AngularIndicator(gameObject, scada, f, frame, 
                desktop + "." + par, headT, mask, maskR);
        }
    }
}
