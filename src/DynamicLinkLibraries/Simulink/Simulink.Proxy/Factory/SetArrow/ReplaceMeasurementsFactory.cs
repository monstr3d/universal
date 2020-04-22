using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.XmlObjectFactory;
using DataPerformer;
using DataPerformer.Interfaces;

namespace Simulink.Proxy.Factory.SetArrow
{
    class ReplaceMeasurementsFactory : GenericFactory<IReplaceMeasurements>
    {
        #region Fields

        IDataConsumer dc;

        #endregion


        #region Ctor

        internal ReplaceMeasurementsFactory(IDesktop desktop)
            : base(desktop)
        {
        }

        #endregion

        #region Overriden

 
 
        protected override void Process()
        {
            if (obj is IDataConsumer)
            {
                dc = obj as IDataConsumer;
                if (dc.Count > 0)
                {
                    ProcessOneInput();
                }
            }
        }


        #endregion

        #region Private

        void ProcessOneInput()
        {
            IMeasurements m = dc[0];

            if (m.Count > 0)
            {
                IMeasurement mea = m[0];
               // obj.Replace(null, StaticDataPerformer.Strategy.TimeProvider.TimeMeasure, m, mea);
            }
        }

        #endregion
    }
}
