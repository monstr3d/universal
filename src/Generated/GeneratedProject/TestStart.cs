using Diagram.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Regression.Portable;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratedProject
{
    public class TestStart : IAdditionalStart
    {

        public static TestStart Singleton = new TestStart();

        private TestStart()
        {

        }

        void IAdditionalStart.Start()
        {
            try
            {
                IDesktop d = StaticExtensionGeneratedProject.Desktop;
                AliasRegression r = null;
                d.ForEach((AliasRegression ar) => { r = ar; });
                double a = r.Iterate();
            }
            catch (Exception exception)
            {

            }

        }
    }
}
