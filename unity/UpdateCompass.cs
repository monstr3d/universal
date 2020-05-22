using Motion6D.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using UnityEngine;
using UnityEngine.UI;
using Vector3D;

namespace Assets
{
    public class UpdateCompass : AbstractRectTransformUpdate
    {
        float headingAmplitude = 1, headingOffSet = 0, headingFilterFactor = 0.1f;
        float heading,  factor = 1, maxValue = 360;
        float startX = 0, startY = 0, startWidth, startHeight;

        public UpdateCompass()
        {

        }

        RawImage rawImg;
        public override void Set(ReferenceFrame frame, EulerAngles angles, RectTransform transform)
        {
            base.Set(frame, angles, transform);
            Dictionary<string, List<Component>> comp;
            transform.gameObject.GetComponents(out comp);
            foreach (var o in comp.Values)
            {
                foreach (var a in o)
                {
                    if (a is RawImage)
                    {
                        rawImg = a as RawImage;
                        goto m;
                    }
                }
            }
        m:
            return;
            
       }

        public override Action Update => UpdateInternal;

        void UpdateInternal()
        {
            float heading = angles.pitch.ToDegree();
            Rect r = new Rect(factor * (heading + headingOffSet)
                 / maxValue + startX, rawImg.uvRect.y,
                 rawImg.uvRect.width, rawImg.uvRect.height);
            rawImg.uvRect = r;

        }
    }
}
