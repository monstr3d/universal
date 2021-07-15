using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

using Scada.Desktop;
using Unity.Standard.Interfaces;

namespace Unity.Standard.Indicators
{
    public class InputOutputFactory : IIndicatorFactory
    {

        public InputOutputFactory()
        {

        }

        IIndicator IIndicatorFactory.Get(GameObject gameObject)
        {
            var ch = gameObject.GetGameObjectComponents<Text>();
            string[] ss = new string[] { "Input", "Output" };
            var tt = new string[2];
            for (int i = 0; i < 2; i++)
            {
                var st = ss[i];
                if (!ch.ContainsKey(st))
                {
                    return null;
                }
                var l = ch[st];
                if (l.Count != 1)
                {
                    return null;
                }
                tt[i] = l[0].text;
            }
            var a = tt.DetectActions();
            if (a == null)
            {
                return null;
            }
            double coefficient = 1;
            if (ch.ContainsKey("Coefficient"))
            {
                coefficient = double.Parse(ch["Coefficient"][0].text);
            }
            return InputOutputIndicator.Create(a.Item2, tt[0], a.Item3, coefficient);
        }
    }
}
