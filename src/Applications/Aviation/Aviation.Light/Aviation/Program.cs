using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

using Diagram.UI.Interfaces;
using Diagram.UI;

using ControlSystemLib = ControlSystems;

using CommonService;
using BasicEngineering.UI.Factory;

using Aviation.UI;
using System.Xml;

namespace Aviation.Light
{

    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string filename = "";
       /*         Type t = typeof(Motion6D.Aggregates.RigidBody);
                string st = t.FullName + "," + t.Assembly; //*/
            TextWriter logWriter = null;
            if (args != null)
            {
                if (args.Length == 1)
                {
                    filename = args[0];
                }
            }
            if (filename.Equals("-t"))
            {
                logWriter = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "log.txt");
                filename = "";
            }
            if (filename.Equals("-tc"))
            {
                filename = "";
            }
            TestCategory.Interfaces.ITestInterface testInterface = null;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(GetForm(filename, null, logWriter, testInterface));
        }


        static readonly IUIFactory[] Factories = new IUIFactory[]
                {
                    ControlSystemLib.Data.UI.Factory.ControlSystemsFactory.Object,
                    SoundService.UI.Factory.SoundUIFactrory.Singleton,
                    Event.UI.Factory.UIFactory.Factory,
                };

        static LightDictionary<string, ButtonWrapper[]> GetButtons(Motion6D.Portable.Interfaces.IPositionObjectFactory factory)
        {
            Motion6D.Portable.Interfaces.IPositionObjectFactory f = factory;
            if (f == null)
            {
                f = Motion6D.Portable.PositionObjectFactory.BaseFactory;
            }
            string[] tabs = new string[] { "General", "Statistics",  "6D Motion", "Events", "Arrows" };
            ButtonWrapper[][] but = new ButtonWrapper[tabs.Length][];
            int i = 0;
            List<ButtonWrapper> gen = new List<ButtonWrapper>();
            gen.AddRange(DataPerformer.UI.Factory.StaticFactory.GeneralObjectsButtons);
            gen.AddRange(ControlSystems.Data.UI.Factory.ControlSystemsFactory.ObjectButtons);
            gen.AddRange(SoundService.UI.Factory.SoundUIFactrory.ObjectButtons);
            but[i] = gen.ToArray();
            ++i;
            but[i] = EngineeringUIFactory.StatisticalObjectsButtons;
            ++i;
            List<ButtonWrapper> geom = new List<ButtonWrapper>();
            geom.AddRange(Motion6D.UI.Factory.MotionFactory.ObjectButtons);
            geom.AddRange(Motion6D.UI.Factory.VisibleFactory.GetVisualObjectButtons(f));
            but[i] = geom.ToArray();
            ++i;
            List<ButtonWrapper> events = new List<ButtonWrapper>();
            events.AddRange(Event.UI.Factory.UIFactory.ObjectButtons);
            but[i] = events.ToArray();
            ++i;
            List<ButtonWrapper> arr = new List<ButtonWrapper>();
            arr.AddRange(EngineeringUIFactory.ArrowButtons);
            arr.Add(EngineeringUIFactory.DataExchangeArrowButtons[0]);
            arr.AddRange(Motion6D.UI.Factory.MotionFactory.ArrowButtons);
            arr.AddRange(Motion6D.UI.Factory.VisibleFactory.VisualArrowButtons);
            arr.AddRange(Event.UI.Factory.UIFactory.ArrowButtons);
            but[i] = arr.ToArray();
            LightDictionary<string, ButtonWrapper[]> buttons = new LightDictionary<string, ButtonWrapper[]>();
            buttons.Add(tabs, but);
            return buttons;
        }


        static Form GetForm(string filename, Motion6D.Portable.PositionObjectFactory factory, System.IO.TextWriter logWriter, TestCategory.Interfaces.ITestInterface testInterface)
        {
            //!!! SCADA     
            Scada.Desktop.StaticExtensionScadaDesktop.ScadaFactory = Scada.Desktop.Serializable.StaticExtensionScadaDesktopSerializable.BaseFactory;
            List<ButtonWrapper> l = new List<ButtonWrapper>();
            l.AddRange(ControlSystemLib.Data.UI.Factory.ControlSystemsFactory.ObjectButtons);
            Form form = StaticExtension.CreateAviationFormFull(GetButtons(factory), new IApplicationInitializer[0],
               null, null, filename, null, Factories,
               null, true,
                "Aviation simulation processor",
                Properties.Resources.Aviation, logWriter, testInterface);
            return form;
        }

    }
}