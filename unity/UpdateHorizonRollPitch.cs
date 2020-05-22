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

namespace Assets
{
    public class UpdateHorizonRollPitch : AbstractRectTransformUpdate
    {
 
        Text headingTxt;
        Text Text;
        Text Altitude_Txt;
        Text Speed_Txt;

        public UpdateHorizonRollPitch()
        {

        }

        public override void Set(ReferenceFrame frame, EulerAngles angles,
            RectTransform transform)
        {
            base.Set(frame, angles, transform);
            GameObject go = transform.gameObject;
            Dictionary<string, List<Component>> comp;
            var d = go.GetComponents(out comp);
            var texts = comp.GetComponents<Text>();
            headingTxt = texts["heading_Indicator"][0];
        }

        public override Action Update => UpdateInternal;


        
        void UpdateInternal()
        {
            float heading = (float)angles.pitch;
            heading *= RadianToDegree;
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
