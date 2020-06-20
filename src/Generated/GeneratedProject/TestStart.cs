using System;
using System.Collections.Generic;

using Diagram.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

using Regression.Portable;
using DataPerformer.Event.Portable;

namespace GeneratedProject
{
    public class TestStart : IAdditionalStart, IErrorHandler
    {

        public static TestStart Singleton = new TestStart();

        private TestStart()
        {

        }

        void DataConsumerTest()
        {
            IDesktop d =  RigidBodyStation.Desktop;
            IDataConsumer dc = d["Consumer"].GetLabelObject<IDataConsumer>();
            dc.PerformFixed(0, 0.01, 100, StaticExtensionDataPerformerInterfaces.Calculation,
          0, () =>
          {

          }, null, this
          );
        }


        void RegressionTest()
        {
            IDesktop d = SimpleRegression.Desktop;
            AliasRegression r = null;
            d.ForEach((AliasRegression ar) => { r = ar; });
            double a = r.Iterate(); 
        }

        void IErrorHandler.ShowError(Exception exception, object obj)
        {
           
        }

        void IErrorHandler.ShowMessage(string message, object obj)
        {
           
        }

        void IAdditionalStart.Start()
        {
            try
            {
                DataConsumerTest();
            }
            catch (Exception exception)
            {

            }

        }
    }
}
