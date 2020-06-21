using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    static class Level0
    {

        internal static void Set(this MonoBehaviour monoBehaviour)
        {
            ReferenceFrameBehavior rf = null;
            OutputController oc = null;
            if (monoBehaviour is ReferenceFrameBehavior)
            {
                rf = monoBehaviour as ReferenceFrameBehavior;
            }
            if (monoBehaviour is OutputController)
            {
                oc = monoBehaviour as OutputController;
            }
            string name = monoBehaviour.gameObject.name;
            if (oc != null)
            {
                //oc.inputConstants = floatConstants[0];
            /*    var txts = oc.gameObject.GetGameObjectComponents<Text>();
                var tt = txts["Text"];
                foreach (var t in tt)
                {
                    if (t.text.Contains("WASD"))
                    {
                        t.text = controlString;
                        break;
                    }
                }
                var cc = oc.gameObject.GetGameObjectComponents<RectTransform>();
                RectTransform rt = cc["Results"][0];
                Vector3 anc = rt.anchoredPosition;
                rt.sizeDelta = new Vector2(rt.rect.width, (float)controlHeight);
                rt.anchoredPosition = anc;
            }
            if (name == "Station")
            {
                rf.constants = stringConstants[0];
            }*/
        }

    }
}
}
