using Diagram.UI.Interfaces;
using Diagram.UI;

using ControlSystemLib = ControlSystems;

using CommonService;
using BasicEngineering.UI.Factory;

using Aviation.UI;
using ErrorHandler;


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

        static void Test()
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

            /*     WpfInterface.StaticExtensionWebInterfaceUI.Init();*/
        }

        static void TestType()
        {
            var obj = new Internet.Meteo.Wrapper.Serializable.Sensor("all");

            if (!(obj is Internet.Meteo.Wrapper.Sensor sensor))
            {
                
            }
            else
            {
                sensor = null;
            }

            /*  Type t = typeof(object);
              string st = t.FullName + "," + t.Assembly; //*/
            /*     new Gravity_36_36.Gravity();
                 var gv = new Gravity_36_36.Wrapper.Serializable.Gravity();
                 var b = gv is Gravity_36_36.Wrapper.Gravity;
                 var ggg = (Gravity_36_36.Wrapper.Gravity)gv;
                 var a = new Regression.AliasRegression();
                 var bb = a is Regression.Portable.AliasRegression;
                 bb = false;*/
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            AssemblyService.StaticExtensionAssemblyService.Init();

            Abstract3DConverters.StaticExtensionAbstract3DConverters.UseDirectory = true;

            TestType();

            // FormulaMeasurement.CheckValue = (o)                            => o == null;
            FormulaEditor.StaticExtensionFormulaEditor.CheckValue = check;

            FormulaEditor.StaticExtensionFormulaEditor.ShouldCheckValueInGeneratedCode = true;



            string filename = "";
                    IExceptionHandler logWriter = null;
            if (args != null)
            {
                if (args.Length == 1)
                {
                    filename = args[0];
                }
            }
            if (filename.Equals("-t"))
            {
                logWriter = new MessageFileLog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"log.txt"));
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
            Application.Run(GetForm(filename, WpfInterface.UI.Factory.WpfFactory.Singleton, 
                logWriter, testInterface));
        }


        static readonly IUIFactory[] Factories = new IUIFactory[]
                {
                    ControlSystemLib.Data.UI.Factory.ControlSystemsFactory.Object,
                    Event.UI.Factory.UIFactory.Factory,
                    Database.UI.Factory.DatabaseFactory.Object
                };


        static LightDictionary<string, ButtonWrapper[]> GetButtons(Motion6D.Portable.Interfaces.IPositionObjectFactory factory)
        {
            Motion6D.Portable.Interfaces.IPositionObjectFactory f = factory;
            if (factory != null)
            {
                new Motion6D.UI.Factory.VisibleFactory(factory);
            }
            else
            {
                f = Motion6D.Portable.PositionObjectFactory.BaseFactory;
            }
            var tabs = new string[] { "General", "Statistics", "Database", "6D Motion", "Image", "Events", "Arrows" };
            var soundFactory = SoundService.StaticExtensionSoundService.SoundFactory;
            if (soundFactory != null)
            {
                tabs = [ "General", "Statistics", "Database", "6D Motion", "Image", "Sound", "Events", "Arrows" ];
            }
            var but = new ButtonWrapper[tabs.Length][];
            int i = 0;
            var gen = new List<ButtonWrapper>();
            gen.AddRange(DataPerformer.UI.Factory.StaticFactory.GeneralObjectsButtons);
            gen.AddRange(ControlSystems.Data.UI.Factory.ControlSystemsFactory.ObjectButtons);
     //       gen.AddRange(SoundService.UI.Factory.SoundUIFactrory.ObjectButtons);
            but[i] = gen.ToArray();
            ++i;
            but[i] = EngineeringUIFactory.StatisticalObjectsButtons;
            ++i;
            but[i] = Database.UI.Factory.DatabaseFactory.ObjectButtons;
            ++i;
            var geom = new List<ButtonWrapper>();
            geom.AddRange(Motion6D.UI.Factory.MotionFactory.ObjectButtons);
            geom.AddRange(Motion6D.UI.Factory.VisibleFactory.GetVisualObjectButtons(f));
            but[i] = geom.ToArray();
            ++i;
            var image = new List<ButtonWrapper>();
            image.AddRange(ImageTransformations.Factory.ImageTransformationFactory.ObjectButtons);
            image.AddRange(ImageNavigation.Factory.ImageNavigationFactory.ObjectButtons);
            but[i] = image.ToArray();
            ++i;
            if (soundFactory != null)
            {
                var sounds = SoundService.UI.StaticExtensionSoundServiceUI.ObjectButtons;
                but[i] = sounds;
                ++i;
            }
            var events = new List<ButtonWrapper>();
            events.AddRange(Event.UI.Factory.UIFactory.ObjectButtons);
            but[i] = events.ToArray();
            ++i;
            var arr = new List<ButtonWrapper>();
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



        static Form GetForm(string filename, Motion6D.Portable.PositionObjectFactory factory, IExceptionHandler logWriter, TestCategory.Interfaces.ITestInterface testInterface)
        {
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