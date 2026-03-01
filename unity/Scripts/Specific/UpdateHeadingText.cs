using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

using Unity.Standard;

using Vector3D;
using Motion6D.Interfaces;
using Scada.Interfaces;
using Unity.Standard.Abstract;

namespace Scripts.Specific
{
    public class UpdateHeadingText : AbstractFrameUpdate
    {
        Text headingTxt;
        Text Text;
        Text Altitude_Txt;
        Text Speed_Txt;

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