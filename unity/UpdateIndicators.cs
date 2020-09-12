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

        List<ILimits> limits = new List<ILimits>();

        protected Action update;

        IIndicator indi;

        const string key = "RigidBodyStation.Relative to station.z";

        double lim = 10;

        bool last = false;

        bool[] b = new bool[] { false };

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
            if (indicators.ContainsKey(key))
            {
                indi = indicators[key].Item2[0];
            }
            bool b = false;
            foreach (var i in indicators.Keys)
            {
                var l = indicators[i];
                var ll = l.Item2;
                foreach (var ind in ll)
                {
                    if (ind is ILimits)
                    {
                        b = true;
                        limits.Add(ind as ILimits);
                    }
                }
            }
            if (b)
            {
                update += UpdateLimits;
            }
        }
 
        #endregion

        #region Own Members

        void Stop(bool[] b)
        {

        }

 
        protected virtual void UpdateInternal()
        {
            indicators.UpdateInicators();
        }
     

        void UpdateLimits()
        {
            object o = indi.Value;
            double a = (double)o * 100;
            bool more = a > lim;
            if (more)
            {
                if (!last)
                {
                    return;
                }
            }
        }

        #endregion
    }
}
