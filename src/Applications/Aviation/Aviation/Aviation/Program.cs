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

namespace Aviation
{

    static class Program
    {



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AssemblyService.StaticExtensionAssemblyService.Init();
            try
            {
         //       Type t = typeof(DataPerformer.Python.Wrapper.Objects.PythonTransformer);
          //      string ss = t.FullName + "," + t.Assembly.FullName;

                object o = null;
                DateTime dt = DateTime.FromOADate(1770457504 / (24 * 3600));
                System.Configuration.Configuration config =
                    System.Configuration.ConfigurationManager.OpenExeConfiguration(
                        System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal);
                string path = config.FilePath;

                //*/
                //  double sec = (double)dt.Ticks / (10000000 * 24 * 3600);
                string filename = "";
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
             /* !!! SOUND TEST TEMPORARY COMMENTED           testInterface = SoundService.Test.UI.TestInterface.Singleton;
                        SoundService.UI.Factory.SoundUIFactrory.HasTests = true;
             */
                    }
                }

                Form f = GetForm(filename, null, logWriter, testInterface);
                /*f.Load += (object sender, EventArgs e) =>
                {
                    IDesktop d = GeneratedProject.StaticExtensionGeneratedProject.Desktop;
                    Environment.Exit(0);
                };*/
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
           //     Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(f);
            }
            catch (Exception e)
            {

            }
        }

        static void Prepare()
        {
            Type t = typeof(Gravity_36_36.Wrapper.Gravity);
            string st = t.FullName + "," + t.Assembly.FullName;

        }

        private static void F_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        static readonly IUIFactory[] Factories = new IUIFactory[]
                {
                    ControlSystemLib.Data.UI.Factory.ControlSystemsFactory.Object,
      // !!!REMOVED             Simulink.Proxy.UI.Factory.SimulinkProxyFactory.Object,
                    Database.UI.Factory.DatabaseFactory.Object,
          // !!!REMOVED          ImageTransformations.Factory.ImageTransformationFactory.Object,
           // !!!REMOVED            ImageNavigation.Factory.ImageNavigationFactory.Object,
                // !!!REMOVED    SoundService.UI.Factory.SoundUIFactrory.Singleton,
                    Event.UI.Factory.UIFactory.Factory
         //!!!REMOVED           Web.Interfaces.UI.Factory.Factory.Singleton
                };

        static LightDictionary<string, ButtonWrapper[]> GetButtons(Motion6D.Portable.Interfaces.IPositionObjectFactory factory)
        {
            Motion6D.Portable.Interfaces.IPositionObjectFactory f = factory;
            if (f == null)
            {
                f = Motion6D.Portable.PositionObjectFactory.BaseFactory;
            }
            string[] tabs = new string[] { "General", "Statistics", "Database", "6D Motion", "Image", "Events", "Arrows" };
            ButtonWrapper[][] but = new ButtonWrapper[tabs.Length][];
            int i = 0;
            List<ButtonWrapper> gen = new List<ButtonWrapper>();
            gen.AddRange(DataPerformer.UI.Factory.StaticFactory.GeneralObjectsButtons);
            gen.AddRange(ControlSystemLib.Data.UI.Factory.ControlSystemsFactory.ObjectButtons);
            // !!!REMOVED      gen.AddRange(Simulink.Proxy.UI.Factory.SimulinkProxyFactory.ObjectButtons);
            // !!!REMOVED      gen.AddRange(SoundService.UI.Factory.SoundUIFactrory.ObjectButtons);
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
            // !!!REMOVED        image.AddRange(ImageTransformations.Factory.ImageTransformationFactory.ObjectButtons);
            // !!!REMOVED     image.AddRange(ImageNavigation.Factory.ImageNavigationFactory.ObjectButtons);
            but[i] = image.ToArray();
            ++i;
            List<ButtonWrapper> events = new List<ButtonWrapper>();
            events.AddRange(Event.UI.Factory.UIFactory.ObjectButtons);
            but[i] = events.ToArray();
            ++i;
            List<ButtonWrapper> arr = new List<ButtonWrapper>();
            arr.AddRange(EngineeringUIFactory.ArrowButtons);
            arr.Add(EngineeringUIFactory.DataExchangeArrowButtons[0]);
            arr.AddRange(Database.UI.Factory.DatabaseFactory.ArrowButtons);
            arr.AddRange(Motion6D.UI.Factory.MotionFactory.ArrowButtons);
            arr.AddRange(Motion6D.UI.Factory.VisibleFactory.VisualArrowButtons);
            // !!!REMOVED          arr.AddRange(ImageTransformations.Factory.ImageTransformationFactory.ArrowButtons);
            // !!!REMOVED         arr.AddRange(ImageNavigation.Factory.ImageNavigationFactory.ArrowButtons);
            arr.AddRange(Event.UI.Factory.UIFactory.ArrowButtons);
            but[i] = arr.ToArray();
            LightDictionary<string, ButtonWrapper[]> buttons = new LightDictionary<string, ButtonWrapper[]>();
            buttons.Add(tabs, but);
            return buttons;
        }


        static Diagram.UI.Interfaces.IApplicationInitializer[] Initializers
        {
            get
            {
                IApplicationInitializer[] init = new IApplicationInitializer[]
            {
                DataSetService.Initialization.DatabaseInitializer.GetInitializer(DataSetService.DllDataSetFactoryChooser.BaseDirectoryFactory)
             };
                return init;
            }
        }


        static Form GetForm(string filename, Motion6D.Portable.PositionObjectFactory factory, System.IO.TextWriter logWriter, TestCategory.Interfaces.ITestInterface testInterface)
        {
            List<ButtonWrapper> l = new List<ButtonWrapper>();
            l.AddRange(ControlSystemLib.Data.UI.Factory.ControlSystemsFactory.ObjectButtons);
            // !!!REMOVED    l.AddRange(Simulink.Proxy.UI.Factory.SimulinkProxyFactory.ObjectButtons);
            Form form = StaticExtension.CreateAviationFormFull(GetButtons(factory), Initializers,
                Aviation.Utils.ControlUtilites.Resources, null, filename, null, Factories,
               null, true,
                "Aviation simulation processor",
                Properties.Resources.Aviation, logWriter, testInterface);
            return form;
        }

        static void List()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(@"c:\AUsers\1MySoft\CSharp\0\METEO\RussianTowns.xml");
            using (System.IO.TextWriter w =
         new System.IO.StreamWriter(@"c:\AUsers\1MySoft\CSharp\0\METEO\RussianTownsList.txt"))
            {
                System.Xml.XmlNodeList nl = doc.GetElementsByTagName("a");
                foreach (System.Xml.XmlElement e in nl)
                {
                    System.Xml.XmlNode n = e.GetElementsByTagName("b")[0];
                    w.WriteLine("{ \"" + n.InnerText + "\", \"" + e.GetAttribute("href").Replace("AND", "&") + "\"},");
                }
            }
    
        }

        

        static void List1()
        {
            List<string> l = new List<string>();
            char[] tok = " ".ToCharArray();
            using (System.IO.TextReader r =
                new System.IO.StreamReader(@"c:\AUsers\1MySoft\CSharp\0\METEO\RussianTowns.txt", System.Text.Encoding.GetEncoding(1251), true))
            {
                while (true)
                {
                    string s = r.ReadLine();
                    if (s == null)
                    {
                        break;
                    }
                    string[] ss = s.Split(tok);
                    foreach (string name in ss)
                    {
                        if (name.Length > 1)
                        {
                            l.Add(name);
                        }
                    }
                }
            }
            using (System.IO.TextWriter w =
                new System.IO.StreamWriter(@"c:\AUsers\1MySoft\CSharp\0\METEO\RussianTownsList.txt"))
            {
                foreach (string s in l)
                {
                    w.WriteLine("\"" + s + "\",");
                }
            }
        }
    }
}