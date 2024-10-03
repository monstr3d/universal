using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;



using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer;

using DataWarehouse;
using DataWarehouse.Interfaces;

using CommonService;

using BasicEngineering.UI.Factory.Interfaces;
using BasicEngineering.UI.Factory.Advanced.Forms;



namespace BasicEngineering.UI.Factory.Advanced
{
    /// <summary>
    /// Default application crerator
    /// </summary>
    public class DefaultApplicationCreator : IApplicationCreator
    {

        #region Fields


        private LightDictionary<string, ButtonWrapper[]> buttons;

        Icon icon;
        EngineeringUIFactory factory;
        string filename;
        Action<double, double, int, int, int, IDesktop> start;
        string text;
        string ext;
        string fileFilter;

        IApplicationInitializer initializer;

        ByteHolder holder;

        Dictionary<string, object>[] resources;

        IDatabaseCoordinator coordinator;

        TextWriter log = null;

        TestCategory.Interfaces.ITestInterface testInterface;

        #endregion

        #region Ctor

        public DefaultApplicationCreator(IDatabaseCoordinator coordinator, LightDictionary<string, ButtonWrapper[]> buttons,
            Icon icon, EngineeringUIFactory factory, ByteHolder holder, string filename, Action<double, double, int, int, int, IDesktop> start, 
            Dictionary<string, object>[] resources, string text,
            string ext,  string fileFilter,
            IApplicationInitializer initializer, TextWriter log,
            TestCategory.Interfaces.ITestInterface testInterface)
        {
            this.coordinator = coordinator;
            this.buttons = buttons;
            this.icon = icon;
            this.factory = factory;
            this.holder = holder;
            this.filename = filename;
            this.start = start;
            this.resources = resources;
            this.text = text;
            this.ext = ext;
            this.fileFilter = fileFilter;
            this.initializer = initializer;
            this.log = log;
            this.testInterface = testInterface;

      ///!!! ZIP LOG     Event.Interfaces.StaticExtensionEventInterfaces.LogFactory =                new Zip.Service.ZipLog();

        }

        #endregion

        #region IApplicationCreator Members

        LightDictionary<string, ButtonWrapper[]> IApplicationCreator.Buttons
        {
            get { return buttons; }
        }

        Icon IApplicationCreator.Icon
        {
            get { return icon; }
        }

        IUIFactory IApplicationCreator.Factory
        {
            get { return factory; }
        }

        string IApplicationCreator.Filename
        {
            get { return filename; }
        }

        Action<double, double, int, int, int, IDesktop> IApplicationCreator.Start
        {
            get { return start; }
        }

        string IApplicationCreator.Text
        {
            get { return text; }
        }

        string IApplicationCreator.Ext
        {
            get { return ext; }
        }

        IApplicationInitializer IApplicationCreator.ApplicationInitializer
        {
            get { return initializer; }
        }

        string IApplicationCreator.FileFilter
        {
            get { return fileFilter; }
        }

        ByteHolder IApplicationCreator.Holder
        {
            get
            {
                return holder;
            }
            set
            {
                holder = value;
            }
        }

        Dictionary<string, object>[] IApplicationCreator.Resources
        {
            get
            {
                return resources;
            }
        }


        void IApplicationCreator.LoadResources()
        {
            loadResources();
        }

        IDatabaseCoordinator IApplicationCreator.DatabaseCoordinator
        {
            get
            {
                return coordinator;
            }
        }

        TextWriter IApplicationCreator.Log
        {
            get { return log; }
        }


        TestCategory.Interfaces.ITestInterface IApplicationCreator.TestInterface
        {
            get { return testInterface; }
        }


        #endregion

        #region Members

        public static FormMain CreateForm(IDatabaseCoordinator coordinator, ByteHolder holder,
            OrdinaryDifferentialEquations.IDifferentialEquationSolver ordSolver,
     DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor diffProcessor,
 IApplicationInitializer[] initializers,
            IUIFactory[] factories,
     bool throwsRepeatException, LightDictionary<string, ButtonWrapper[]> buttons, Dictionary<string, object>[]
            resources,
            Icon icon, string filename, Action<double, double, int, int, int, IDesktop> start, string text,
            string ext, string fileFilter, TextWriter log, TestCategory.Interfaces.ITestInterface testInterface)
        {
            EngineeringUIFactory factory = new EngineeringUIFactory(factories, true, ext);
            EngineeringInitializer initializer = new EngineeringInitializer(coordinator, ordSolver, diffProcessor, 
              initializers, throwsRepeatException, resources, log);
            DefaultApplicationCreator creator = new DefaultApplicationCreator(coordinator, buttons, icon, factory, holder, filename, start, 
              resources,  text,
            ext, fileFilter, initializer, log, testInterface);
            return CreateForm(creator);
        }

        public static FormMain CreateForm(IDatabaseCoordinator coordinator, ByteHolder holder,
             OrdinaryDifferentialEquations.IDifferentialEquationSolver ordSolver,
      DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor diffProcessor,
      IApplicationInitializer[] initializers,
         IUIFactory[] factories,
      bool throwsRepeatException, LightDictionary<string, ButtonWrapper[]> buttons,
             Icon icon, string filename, Dictionary<string, object>[] resources, string text,
             string ext, string fileFilter, TextWriter logWriter, TestCategory.Interfaces.ITestInterface testInterface)
        {
            EngineeringUIFactory factory = new EngineeringUIFactory(factories, true, ext);
            StaticExtensionDiagramUIFactory.UIFactory = factory;
            IDatabaseCoordinator c = coordinator;
            if (c == null)
            {
                c = AssemblyService.StaticExtensionAssemblyService.GetFirstInterfaceObjectFromBaseDirectory<IDatabaseCoordinator>();
            }
            EngineeringInitializer initializer = new EngineeringInitializer(c, ordSolver, diffProcessor,
              initializers, throwsRepeatException, resources, logWriter);
            DefaultApplicationCreator creator = new DefaultApplicationCreator(c, buttons, icon, factory, holder, 
                filename, factory.Start, resources, text,
            ext, fileFilter, initializer, logWriter, testInterface);
            return CreateForm(creator);
        }

        /// <summary>
        /// Crates form
        /// </summary>
        /// <param name="creator">Creator of applications</param>
        /// <returns>The form</returns>
        public static FormMain CreateForm(IApplicationCreator creator)
        {
            FormMain f = new FormMain(creator);
            return f;
        }


        static private void loadResources()
        {

            string sApp = ResourceService.Resources.CurrentDirectory;
            System.Globalization.CultureInfo c = System.Globalization.CultureInfo.CurrentCulture;
        }
 
        #endregion

    }
}
