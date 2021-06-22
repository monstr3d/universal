using Motion6D.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using UnityEngine;
using UnityEngine.UI;

using Unity.Standard;

using Vector3D;
using Scada.Interfaces;
using Unity.Standard.Abstract;

namespace Scripts
{
    public class UpdateCompass : AbstractFrameUpdate
    {
        float headingAmplitude = 1, headingOffSet = 0, headingFilterFactor = 0.1f;
        float heading, factor = 1, maxValue = 360;
        float startX = 0, startY,  
            startWidth, startHeight;

        RawImage rawImg;

        public UpdateCompass()
        {
            var a = new float[] { headingAmplitude, headingOffSet, headingFilterFactor,
            heading, factor, maxValue,
            startX,  startWidth, startHeight };
        }

        public override void Set(object[] obj, Component gameObject, IScadaInterface scada)
        {
            base.Set(obj, gameObject, scada);
            rawImg = gameObject.GetComponent<RawImage>();
            startX = rawImg.uvRect.x; startY = rawImg.uvRect.y;
            startWidth = rawImg.uvRect.width; startHeight = rawImg.uvRect.height;
        }

        public override int SetConstants(int offset, float[] constants)
        {
            int i = base.SetConstants(offset, constants);
            return i;
        }
        //       Dictionary<string, List<Component>> comp;
        /*    gameObject.GetComponents(out comp);
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
            return;*/


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
