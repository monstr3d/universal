using System;
using System.Collections.Generic;

using UnityEngine;

using Scada.Interfaces;

using Unity.Standard.Abstract;
using Unity.Standard.Interfaces;
using Unity.Standard;

using Scripts.Specific;

namespace Unity.Specific
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


        new private IIndicator indicator;

        static  internal  double bound = 20;


        #endregion

        #region Ctor

        public UpdateIndicators()
        {
            update = UpdateInternal;
            constants = new float[0];
        }

        #endregion

        #region Overriden

        public override Action Update => updateLocal;


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
      //          upd += UpdateLimits;
                update += UpdateLimits;
                StaticExtensionUnity.OnGlobal += AddGlobal;
            }
        }

        

        #endregion

        #region Own Members

        void updateLocal()
        {
            update();
        }

        void AddGlobal(string global)
        {
            if (global.StartsWith("on:"))
            {
                string key = global.Substring(3);
                if (indicators.ContainsKey(key))
                {
                    var i = indicators[key];
                    foreach (var ii in i.Item2)
                    {
                        if (ii is ILimits)
                        {
                            limits.Add(ii as ILimits);
                        }
                    }
                }
            }
        }

 
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

        float blinkDelay = 0.4f;

        bool[] st = new bool[] { false };


        void UpdateFirst()
        {
            var indi = new Dictionary<string, Tuple<Func<object>, List<IIndicator>>>();
            upd();
            update = upd;
        }
     

        void UpdateLimits()
        {
            limits.StartBlink(blinkDelay, Start, st,
                ForcesMomentumsUpdate.forcesMomentumsUpdate.AlarmAudio);
        }

        #endregion
    }
}
