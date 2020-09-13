using System;
using System.Collections.Generic;

using UnityEngine;

using Scada.Interfaces;

using Assets;

namespace Unity.Standard
{
    public class UpdateIndicators : AbstractUpdateGameObject
    {
        #region Fields

        Dictionary<string, Tuple<Func<object>, List<IIndicator>>>
            indicators = new Dictionary<string, Tuple<Func<object>, List<IIndicator>>>();

        List<ILimits> limits = new List<ILimits>();

        protected Action upd;
        
        protected Action update;


        const string key = "RigidBodyStation.Relative to station.z";


        private IIndicator indicator;


        #endregion

        #region Ctor

        public UpdateIndicators()
        {
            update = UpdateFirst;
            upd = UpdateInternal;
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
                this.indicator = indicators[key].Item2[0];
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
                upd += UpdateLimits;
            }
        }

        #endregion

        #region Own Members

        const double bound = 30;

        bool Start()
        {
            object o = indicator.Value;
            double a = (double)o * 100;
            return a < bound;
        }

   
        protected virtual void UpdateInternal()
        {
            indicators.UpdateInicators();
        }

        float delay = 0.1f;

        bool[] st = new bool[] { false };


        void UpdateFirst()
        {
            var indi = new Dictionary<string, Tuple<Func<object>, List<IIndicator>>>();
            a
            upd();
            update = upd;
        }
     

        void UpdateLimits()
        {
            limits.StartBlink(delay, Start, st,
                ForcesMomentumsUpdate.forcesMomentumsUpdate.AlarmAudio);
        }

        #endregion
    }
}
