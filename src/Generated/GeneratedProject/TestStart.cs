using System;
using System.Collections.Generic;
using System.IO;

using AssemblyService.Attributes;

using Diagram.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

using Regression.Portable;

namespace GeneratedProject
{
    [InitAssembly]
    public class TestStart : IAdditionalStart, IErrorHandler
    {

        public static TestStart Singleton = new TestStart();

        static TestStart()
        {
            string[] fn = new string[] { "RigidBodyStation", "EarthMotion" };
            string fileName = @"F:\0Unity\Motion\Assets\Scripts\GeneratedProject\";
               StaticExtensionDiagramUI.OnCreateCode += (List<string> l) =>
                {
                    var ff = fileName;
                    foreach (var s in l)
                    {
                        foreach (var p in fn)
                        {
                            if (s.Contains(p))
                            {
                                ff += p + ".cs";
                                goto m;
                            }
                        }
                    }
                    m:
                    if (File.Exists(ff))
                    {
                        File.Delete(ff);
                    }
                    using (TextWriter w = new StreamWriter(ff))
                    {
                        foreach (string s in l)
                        {
                            w.WriteLine(s);
                        }
                    }

                };
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }



        private TestStart()
        {

        }

        void DataConsumerTest()
        {
            IDesktop d =  RigidBodyStation.Desktop;
            IDataConsumer dc = d["Consumer"].GetLabelObject<IDataConsumer>();
            IDataRuntime runtime = dc.CreateRuntime(StaticExtensionDataPerformerInterfaces.Calculation);
            runtime.StartAll(0);
            dc.FullReset();
           dc.PerformFixed(0, 0.01, 3100, StaticExtensionDataPerformerInterfaces.Calculation,
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
