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
using DataPerformer.Formula;

namespace Aviation.Light
{

    class Program
    {
        static bool check(object o)
        {
            if (o == null) 
            {
                return true;
            }
            return o == null;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
      /*      var atm = new DimAtm.Serializable.Atmosphere();
            var l = new DinAtm.Forms.Labels.LabelAtmosphere();
            var g = new Gravity_36_36.Wrapper.Serializable.Gravity();
            using (var s = new MemoryStream())
            {
                var f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                f.Serialize(s, atm);
                f.Serialize(s, l);
                f.Serialize(s, g);
                var b = s.ToArray();
                using (var st = new MemoryStream(b))
                {
                    var a = f.Deserialize(st);
                    var la = f.Deserialize(st);
                    var lg = f.Deserialize(st);
                }
            }
      //*/

            /*     WpfInterface.StaticExtensionWebInterfaceUI.Init();
               Application.SetHighDpiMode(HighDpiMode.SystemAware);
               Application.EnableVisualStyles();
               //Application.SetCompatibleTextRenderingDefault(false);
             ApplicationConfiguration.Initialize();

            */
            AssemblyService.StaticExtensionAssemblyService.Init();

            // FormulaMeasurement.CheckValue = (o)                            => o == null;
            FormulaEditor.StaticExtensionFormulaEditor.CheckValue = check;


            string filename = "";
            /*         Type t = typeof(Motion6D.Aggregates.RigidBody);
                     string st = t.FullName + "," + t.Assembly; //*/
 //           new Gravity_36_36.Gravity();
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
                logWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "log.txt");
                filename = "";
            }
            if (filename.Equals("-tc"))
            {
                filename = "";
            }
            TestCategory.Interfaces.ITestInterface testInterface = null;
            foreach (string s in args)
            {
                if (s.Equals("-tc"))
                {
                    testInterface = TestCategory.UI.TestInterface.Singleton;
                }
            }

            Application.EnableVisualStyles();
     //       Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(GetForm(filename, null, logWriter, testInterface));
        }


        static readonly IUIFactory[] Factories = new IUIFactory[]
                {
                    ControlSystemLib.Data.UI.Factory.ControlSystemsFactory.Object,
                    // !!!REMOVED        SoundService.UI.Factory.SoundUIFactrory.Singleton,
                    Event.UI.Factory.UIFactory.Factory,
                    Database.UI.Factory.DatabaseFactory.Object
                };


        static LightDictionary<string, ButtonWrapper[]> GetButtons(Motion6D.Portable.Interfaces.IPositionObjectFactory factory)
        {
            Motion6D.Portable.Interfaces.IPositionObjectFactory f = factory;
            if (f == null)
            {
                f = Motion6D.Portable.PositionObjectFactory.BaseFactory;
            }
            var tabs = new string[] { "General", "Statistics", "Database", "6D Motion", "Image", "Events", "Arrows" };
            ButtonWrapper[][] but = new ButtonWrapper[tabs.Length][];
            int i = 0;
            List<ButtonWrapper> gen = new List<ButtonWrapper>();
            gen.AddRange(DataPerformer.UI.Factory.StaticFactory.GeneralObjectsButtons);
            gen.AddRange(ControlSystems.Data.UI.Factory.ControlSystemsFactory.ObjectButtons);
     //       gen.AddRange(SoundService.UI.Factory.SoundUIFactrory.ObjectButtons);
            but[i] = gen.ToArray();
            ++i;
            but[i] = EngineeringUIFactory.StatisticalObjectsButtons;
            ++i;
            but[i] = Database.UI.Factory.DatabaseFactory.ObjectButtons;
            ++i;
            List<ButtonWrapper> geom = new List<ButtonWrapper>();
            geom.AddRange(Motion6D.UI.Factory.MotionFactory.ObjectButtons);
            geom.AddRange(Motion6D.UI.Factory.VisibleFactory.GetVisualObjectButtons(f));
            but[i] = geom.ToArray();
            ++i;
            List<ButtonWrapper> image = new List<ButtonWrapper>();
            image.AddRange(ImageTransformations.Factory.ImageTransformationFactory.ObjectButtons);
            image.AddRange(ImageNavigation.Factory.ImageNavigationFactory.ObjectButtons);
            but[i] = image.ToArray();
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
            arr.AddRange(Database.UI.Factory.DatabaseFactory.ArrowButtons);
            arr.AddRange(ImageTransformations.Factory.ImageTransformationFactory.ArrowButtons);
            arr.AddRange(ImageNavigation.Factory.ImageNavigationFactory.ArrowButtons);
            but[i] = arr.ToArray();
            LightDictionary<string, ButtonWrapper[]> buttons = new LightDictionary<string, ButtonWrapper[]>();
            buttons.Add(tabs, but);
            return buttons;
        }



        static Form GetForm(string filename, Motion6D.Portable.PositionObjectFactory factory, TextWriter logWriter, TestCategory.Interfaces.ITestInterface testInterface)
        {
            //!!! SCADA     
            Scada.Desktop.StaticExtensionScadaDesktop.ScadaFactory = Scada.Desktop.Serializable.StaticExtensionScadaDesktopSerializable.BaseFactory;
            List<ButtonWrapper> l = new List<ButtonWrapper>();
            l.AddRange(ControlSystemLib.Data.UI.Factory.ControlSystemsFactory.ObjectButtons);
            Form form =   StaticExtension.CreateAviationFormFull(GetButtons(factory), new IApplicationInitializer[]
            {
                DataSetService.Initialization.DatabaseInitializer.GetInitializer(
                 DataSetService.DllDataSetFactoryChooser.BaseDirectoryFactory)
            },
               null, null, filename, null, Factories,
               null, true,
                "Aviation simulation processor",
                Resources.ResourceImage.Aviation, logWriter, testInterface);
            return form;
        }

    }
}