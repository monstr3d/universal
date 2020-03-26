using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CategoryTheory;


using Simulink.Proxy.CategoryObjects;
using Simulink.CSharp.Proxy;

namespace Simulink.Proxy.UI.Objects
{
    class TextObject
    {
        #region Fields

        SimulinkContainer container;

        CSharpSimulinkProxy csproxy;

        #endregion

        #region Ctor

        internal TextObject(ICategoryObject co)
        {
            if (co is CSharpSimulinkProxy)
            {
                csproxy = co as CSharpSimulinkProxy;
            }
            else
            {
                container = co as SimulinkContainer;
            }
        }

        #endregion

        #region Members

        internal List<string> Text
        {
            get
            {
                if (csproxy != null)
                {
                    return csproxy.Text;
                }
                return container.Text;
            }
            set
            {
                if (csproxy != null)
                {
                    csproxy.Text = value;
                }
                else
                {
                    container.Text = value;
                }
            }
        }

        #endregion
    }
}
