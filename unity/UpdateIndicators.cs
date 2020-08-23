using System;
using System.Collections.Generic;

using UnityEngine;

using Scada.Interfaces;

using Scada.Desktop;


namespace Unity.Standard
{
    public class UpdateIndicators : AbstractUpdateGameObject
    {
        #region Fields

      

        Dictionary<string, Tuple<Func<object>, List<IIndicator>>>
            indicators = new Dictionary<string, Tuple<Func<object>, List<IIndicator>>>();

        Dictionary<string, List<ILimits>> limits = new Dictionary<string, List<ILimits>>();

        protected Action update;

        #endregion

        #region Ctor

        public UpdateIndicators()
        {
            update = UpdateInternal;
            constants = new float[0];
        }

        #endregion

        #region Overriden

        public override Action Update => update;

        public override void Set(object[] obj, Component indicator, IScadaInterface scada)
        {
            base.Set(obj, indicator, scada);
            indicators = indicator.gameObject.GetIndicatorsFull();
            bool b = false;
            foreach (var i in indicators.Keys)
            {
                var l = indicators[i];
                var ll = l.Item2;
                List<ILimits> li= new List<ILimits>();
                limits[i] = li;
                foreach (var ind in ll)
                if (ind is ILimits)
                {
                        b = true;
                        li.Add(ind as ILimits);
                }
            }
            if (b)
            {
                update += UpdateLimits;
            }
        }
 
        #endregion

        #region Own Members

 
        protected virtual void UpdateInternal()
        {
            indicators.UpdateInicators();
        }

        void UpdateLimits()
        {

        }

        #endregion
    }
}
