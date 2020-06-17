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

        Dictionary<string, Tuple<Func<object>, List<IIndicator>>>
            jumped = new Dictionary<string, Tuple<Func<object>, List<IIndicator>>>();


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
            indicators = indicator.gameObject.GetIndicatorsFull(false);
            jumped = indicator.gameObject.GetIndicatorsFull(true);
            if (jumped.Count > 0  & eve != null)
            {
                var v = eve.Split(";".ToCharArray());
                Action a = UpdateJumped;
                a.AddToToScadaEvent(v);
            }
        }

        #endregion

        #region Own Members

        void UpdateJumped()
        {
            jumped.UpdateInicators();
        }

        protected virtual void UpdateInternal()
        {
            indicators.UpdateInicators();
        }

        #endregion
    }
}
