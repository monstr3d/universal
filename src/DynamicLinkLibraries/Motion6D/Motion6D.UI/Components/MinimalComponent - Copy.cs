using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Resources;


using Diagram.UI;
using Diagram.UI.Components;
using Diagram.UI.Interfaces;

using ResourceService;

using CommonService;

using Motion6D.UI.Initialization;



using BasicEngineering.UI.Factory;
using BasicEngineering.UI.Factory.Forms;

namespace Motion6D.UI.Components
{
    /// <summary>
    /// Minimal editor comonent
    /// </summary>
    public class MinimalComponent : DesktopHolder
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MinimalComponent()
            : base(new Editor())
        {
        }

        class Editor : UITypeEditor
        {
            public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                string[] tabs = new string[] { "General", "6D Motion", "Arrows" };
                ButtonWrapper[][] but = new ButtonWrapper[tabs.Length][];
                int i = 0;
                List<ButtonWrapper> gen = new List<ButtonWrapper>();
                gen.AddRange(DataPerformer.UI.Factory.StaticFactory.GeneralObjectsButtons);
               // gen.AddRange(ControlSystems.Data.UI.Factory.ControlSystemsFactory.ObjectButtons);
                but[i] = gen.ToArray();
                ++i;
                List<ButtonWrapper> geom = new List<ButtonWrapper>();
                //geom.AddRange(Motion6D.UI.Factory.MotionFactory.ObjectButtons);
                // geom.AddRange(Motion6D.UI.Factory.VisibleFactory.GetVisualObjectButtons(factory));
                but[i] = geom.ToArray();
                ++i;
                List<ButtonWrapper> arr = new List<ButtonWrapper>();
                arr.AddRange(EngineeringUIFactory.ArrowButtons);
                arr.AddRange(Motion6D.UI.Factory.MotionFactory.ArrowButtons);
                arr.AddRange(Motion6D.UI.Factory.VisibleFactory.VisualArrowButtons);
                but[i] = arr.ToArray();
                LightDictionary<string, ButtonWrapper[]> buttons = new LightDictionary<string, ButtonWrapper[]>();
                buttons.Add(tabs, but);
                IUIFactory[] factories = new IUIFactory[]
                {
                   // ControlSystems.Data.UI.Factory.ControlSystemsFactory.Object,
               };
                IApplicationInitializer[] init = new IApplicationInitializer[]
            {
            };

                Dictionary<string, object>[] d = Motion6D.UI.Utils.ControlUtilites.Resources;

                ByteHolder holder = value as ByteHolder;
                FormMain m = MotionApplicationCreator.CreateForm(null, holder,
               OrdinaryDifferentialEquations.Runge4Solver.Singleton,
            DataPerformer.Portable.DifferentialEquationProcessors.RungeProcessor.Processor, init, factories, true, buttons,
            Properties.Resources.Aviation,
            null, null, Motion6D.UI.Utils.ControlUtilites.Resources,
            "Astronomy + OpenGL",
            ".cfa", "Astronomy configuration files |*.cfa", null, null);
                m.ShowDialog();
                return m.Creator.Holder;
            }

            public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
            {
                return UITypeEditorEditStyle.Modal;
            }
        }
    }
}
