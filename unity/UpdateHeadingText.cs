using System;
using UnityEngine;
using UnityEngine.UI;

using Unity.Standard;

using Scada.Interfaces;

namespace Assets
{
    public class UpdateHeadingText : AbstractFrameUpdate
    {
        Text headingTxt;

        public UpdateHeadingText()
        {

        }

        public override void Set(object[] obj, Component gameObject, IScadaInterface scada)
        {
            base.Set(obj, gameObject, scada);
            /*   Dictionary<string, List<Component>> comp;
               gameObject.GetComponents(out comp);
               var texts = comp.GetComponents<Text>();*/
            var t = gameObject.GetComponent<Text>();
            headingTxt = t;
                //texts["heading_Indicator"][0];
        }

        public override Action Update => UpdateInternal;

        Action upd;



        void UpdateInternal()
        {
            upd?.Invoke();
            float heading = angles.pitch.ToDegree();
            if (headingTxt != null)
            {
                if (heading < 0)
                {
                    headingTxt.text = (heading + 360f).ToString("000");
                }
                else
                {
                    headingTxt.text = heading.ToString("000");
                }
            }
        }
    }
}