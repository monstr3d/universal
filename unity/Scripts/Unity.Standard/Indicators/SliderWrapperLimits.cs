using System;
using System.Collections.Generic;

using Unity.Standard.Interfaces;

using UnityEngine;

namespace Unity.Standard.Indicators
{
    /// <summary>
    /// Slider wrapper with limits
    /// </summary>
    public class SliderWrapperLimits : SliderWrapper, ILimits
    {

        #region Fields 

        

        Dictionary<string, Tuple<float[], string[]>> limits = new Dictionary<string, Tuple<float[], string[]>>();

      //  Func<float[], bool> exceeds;

        float[] l;

        #endregion

        public SliderWrapperLimits(string parameter, Component component,
       float scale, float limit, Func<double?> output, Color normal, Color exceed, string format, 
       bool enableDebug, string alias, string dimension) :
            base(parameter,  component, scale,  limit, output, normal, exceed, format, enableDebug)

        {
            l = new float[] { -limit, limit };
   /* !!! CHECK        if (left == null)
            {
                l[0] = 0;
            }
   */
            Tuple<float[], string[]> tuple = new Tuple<float[], string[]>(l,
                new string[] {alias, dimension });
            limits[parameter] = tuple;
          //  exceeds = Exceeds;
        }

        Dictionary<string, Tuple<float[], string[]>> ILimits.Limits => limits;

        bool ILimits.Active 
        {
            get => isVisible;
            set => SetVisible(value); 
        }
        bool ILimits.Exceeds => exceeds();
    }
}
