using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml;
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
            string filename = "";
           // Type t = typeof(Http.Meteo.Services.MeteoService);
            //string st = t.FullName + "," + t.Assembly;
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
            foreach (string s in args)
            {
                if (s.Equals("-tc"))
                {
                    testInterface = SoundService.Test.UI.TestInterface.Singleton;
                    SoundService.UI.Factory.SoundUIFactrory.HasTests = true;
                }
            }
            InitCollada();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(GetForm(filename, null, logWriter, testInterface));
        }

    
        static readonly IUIFactory[] Factories = new IUIFactory[]
                {
                    ControlSystemLib.Data.UI.Factory.ControlSystemsFactory.Object,
                    Simulink.Proxy.UI.Factory.SimulinkProxyFactory.Object,
                    Database.UI.Factory.DatabaseFactory.Object,
                    ImageTransformations.Factory.ImageTransformationFactory.Object,
                    ImageNavigation.Factory.ImageNavigationFactory.Object,
                    SoundService.UI.Factory.SoundUIFactrory.Singleton,
                    Event.UI.Factory.UIFactory.Factory,
                    Web.Interfaces.UI.Factory.Factory.Singleton
                };

        static LightDictionary<string, ButtonWrapper[]> GetButtons(Motion6D.Interfaces.IPositionObjectFactory factory)
        {
            Motion6D.Interfaces.IPositionObjectFactory f = factory;
            if (f == null)
            {
                f = Motion6D.PositionObjectFactory.BaseFactory;
            }
            string[] tabs = new string[] { "General", "Statistics", "Database", "6D Motion", "Image", "Events", "Arrows" };
            ButtonWrapper[][] but = new ButtonWrapper[tabs.Length][];
            int i = 0;
            List<ButtonWrapper> gen = new List<ButtonWrapper>();
            gen.AddRange(DataPerformer.UI.Factory.StaticFactory.GeneralObjectsButtons);
            gen.AddRange(ControlSystems.Data.UI.Factory.ControlSystemsFactory.ObjectButtons);
            gen.AddRange(Simulink.Proxy.UI.Factory.SimulinkProxyFactory.ObjectButtons);
            gen.AddRange(SoundService.UI.Factory.SoundUIFactrory.ObjectButtons);
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
            arr.AddRange(Database.UI.Factory.DatabaseFactory.ArrowButtons);
            arr.AddRange(Motion6D.UI.Factory.MotionFactory.ArrowButtons);
            arr.AddRange(Motion6D.UI.Factory.VisibleFactory.VisualArrowButtons);
            arr.AddRange(ImageTransformations.Factory.ImageTransformationFactory.ArrowButtons);
            arr.AddRange(ImageNavigation.Factory.ImageNavigationFactory.ArrowButtons);
            arr.AddRange(Event.UI.Factory.UIFactory.ArrowButtons);
            but[i] = arr.ToArray();
            LightDictionary<string, ButtonWrapper[]> buttons = new LightDictionary<string, ButtonWrapper[]>();
            buttons.Add(tabs, but);
            return buttons;
        }


       //!!! [Conditional("WPF")]
        static void InitCollada()
        {
            Collada.FileLoader.StaticExtensionColladaFileLoader.Set();
        }

        static void GetTypes()
        {
          /*  Type t = typeof(Http.Meteo.Services.MeteoService);
            string st = t.FullName + "," + t.Assembly.FullName;
            Type ty = Type.GetType(st);

            string ss = "Event.Data.Remote.Client,Event.Data.Remote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

            string sss = "Event.Data.Remote.Server,Event.Data.Remote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
       */ }


        static void SaveOldPlane()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"g:\0\1.xml");
            PureDesktopPeer d = doc.LoadFromXml(GetObjectFromXml);
            using (Stream s = File.OpenWrite(@"g:\0\1.cfa"))
            {
                d.Save(s);
            }
        }

        static object GetObjectFromXml(XmlElement e)
        {
            string type = e.GetAttribute("Type");
            if (e.Name.Equals("Object"))
            {
                if (type.Equals("DiagramUI.ObjectContainer") |
                    type.Equals("Visualization.CameraUI"))
                {
                    return null;
                }
                if (type.Equals("DataPerformer.VectorFormulaConsumer"))
                {
                    DataPerformer.VectorFormulaConsumer vc = new DataPerformer.VectorFormulaConsumer();
                    XmlElement fr = e.GetElementsByTagName("Formulae")[0] as XmlElement;
                    int nf = 0;
                    XmlNodeList nl = fr.ChildNodes;
                    vc.Dimension = nl.Count;
                    foreach (XmlElement fp in fr.ChildNodes)
                    {
                        vc.SetFormula(fp.InnerText, nf);
                        ++nf;
                    }
                    IAlias ali = vc;
                    XmlElement aln = e.GetElementsByTagName("Aliases")[0] as XmlElement;
                    foreach (XmlElement ea in aln.ChildNodes)
                    {
                        ali[ea.GetAttribute("Name")] = double.Parse(ea.InnerText);
                    }
                    XmlElement args = e.GetElementsByTagName("Arguments")[0] as XmlElement;
                    foreach (XmlElement ea in args.ChildNodes)
                    {
                        vc.Arguments.Add(ea.InnerText);
                    }
                    return vc;
                }
                if (type.Equals("ElectromagneticUI.FileFigure"))
                {
                    return null;// new WpfInterface.Objects3D.WpfShape();
                }
                if (type.Equals("SpatialUI.FrameData"))
                {
                    Motion6D.ReferenceFrameData frame = new Motion6D.ReferenceFrameData();
                    XmlElement pp = e.GetElementsByTagName("Properties")[0] as XmlElement;
                    foreach (XmlElement ee in pp.ChildNodes)
                    {
                        frame.Parameters.Add(ee.InnerText);
                    }
                    return frame;
                }

            }
            else
            {
                if (type.Equals("Visualization.VisibleLink"))
                {
                    return null;
                }
                if (type.Equals("SpatialUI.FrameDataLink"))
                {
                    return null;
                }
                if (type.Equals("DataPerformer.DataLink"))
                {
                    return new DataPerformer.DataLink();
                }
                if (type.Equals("SpatialUI.ReferenceFrameArrow"))
                {
                    return new Motion6D.ReferenceFrameArrow();
                }
            }
            return null;
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

        static Form GetForm(string filename, Motion6D.PositionObjectFactory factory, System.IO.TextWriter logWriter, TestCategory.Interfaces.ITestInterface testInterface)
        {
            //!!! SCADA     
            Scada.Desktop.StaticExtensionScadaDesktop.ScadaFactory = Scada.Desktop.Serializable.StaticExtensionScadaDesktopSerializable.BaseFactory;
            List<ButtonWrapper> l = new List<ButtonWrapper>();
            l.AddRange(ControlSystemLib.Data.UI.Factory.ControlSystemsFactory.ObjectButtons);
            l.AddRange(Simulink.Proxy.UI.Factory.SimulinkProxyFactory.ObjectButtons);
            Form form = StaticExtension.CreateAviationFormFull(GetButtons(factory), Initializers,
                Aviation.Utils.ControlUtilites.Resources, null, filename, null, Factories,
               null, true,
                "Aviation simulation processor",
                Properties.Resources.Aviation, logWriter, testInterface);
            return form;
        }

    }
}