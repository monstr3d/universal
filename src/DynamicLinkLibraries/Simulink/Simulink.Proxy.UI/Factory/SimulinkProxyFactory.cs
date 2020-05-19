using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;



using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI;
using Diagram.UI.Factory;

using Simulink.Proxy.CategoryObjects;
using Simulink.Proxy.UI.Forms;


namespace Simulink.Proxy.UI.Factory
{
    /// <summary>
    /// UI factory for Simulink components
    /// </summary>
    public class SimulinkProxyFactory : EmptyUIFactory
    {
        /// <summary>
        /// Singleton
        /// </summary>
        public static SimulinkProxyFactory Object = new SimulinkProxyFactory();

        /// <summary>
        /// Buttons of objects
        /// </summary>
        public static readonly ButtonWrapper[] ObjectButtons = new ButtonWrapper[]
        {
                                        new ButtonWrapper(typeof(Simulink.Proxy.CategoryObjects.SimulinkContainer),
                    "", "Simulink container", ResourceImage.Simulink, SimulinkProxyFactory.Object, true, false),

                                        new ButtonWrapper(typeof(Simulink.CSharp.Proxy.CSharpSimulinkProxy),
                    "", "Simulink C# container", ResourceImage.SimulinkCSharp, SimulinkProxyFactory.Object, true, false),


        };

        #region Overriden Members

        /// <summary>
        /// Creates a form for component properties editor
        /// </summary>
        /// <param name="comp">The component</param>
        /// <returns>The result form</returns>
        public override object CreateForm(INamedComponent comp)
        {
            if (comp is IObjectLabel)
            {
                IObjectLabel l = comp as IObjectLabel;
                ICategoryObject obj = l.Object;
                if (obj is SimulinkContainer)
                {
                    return new FormSimulinkContainer(l);
                }
                else if (obj is Simulink.CSharp.Proxy.CSharpSimulinkProxy)
                {
                    Form f = new FormSimulinkContainer(l);
                    f.Icon = ResourceImage.SimulinkCSharp;
                    return f;
                }
            }
            return null;
        }

        #endregion


    }
}
