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
        }
 
        #endregion

        #region Own Members

 
        protected virtual void UpdateInternal()
        {
            indicators.UpdateInicators();
        }

        #endregion
    }
}
