using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;


using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Factory;
using Diagram.UI.Utils;
using Diagram.UI;

using CategoryTheory;

using DataPerformer;


namespace BasicEngineering.UI.Factory
{
    /// <summary>
    /// Basic engineering factory
    /// Contains most important features those uses a lot of enginners
    /// </summary>
    public partial class EngineeringUIFactory : AssemblyFactory
    {

        #region Fields

        volatile AutoResetEvent pauseEvent = new AutoResetEvent(false);

        volatile bool isPaused = false;

 
        event Action cancelProcess;

 
        private event Action<double> timeIndication = (double time) => { };

        /// <summary>
        /// Buttons of Statistical Objects
        /// </summary>
        public static readonly ButtonWrapper[] StatisticalObjectsButtons = new ButtonWrapper[]
        {
                            new ButtonWrapper(typeof(Regression.AliasRegression),
                    "", "Regression", ResourceImage.AliasRegression, MinimalFactory.Object, true, false),
                            new ButtonWrapper(typeof(Regression.IteratorGLM),
                    "", "Data set iterator", ResourceImage.RecoursiveGLM, MinimalFactory.Object, true, false),
                            new ButtonWrapper(typeof(Regression.CombinedSelection),
                    "", "Combined selection", ResourceImage.Sigma, MinimalFactory.Object, true, false),
                            new ButtonWrapper(typeof(Regression.Portable.XmlSelectionCollection),
                    "", "Selection from XML file", ResourceImage.XmlData, MinimalFactory.Object, true, false),
                            new ButtonWrapper(typeof(SeriesIterator),
                    "", "Iterator series", ResourceImage.SeriesIterator, MinimalFactory.Object, true, false),
                            new ButtonWrapper(typeof(ObjectsCollection),
                   "Regression.AliasRegression,AliasRegression", "Fisher", ResourceImage.Fisher, MinimalFactory.Object, true, false),
                             new ButtonWrapper(typeof(Event.Basic.Data.LogIterator),  "", "Iterator of a log",
                                  ResourceImage.logIterator, MinimalFactory.Object, true, false)
        };

        /// <summary>
        /// Button Arrows
        /// </summary>
        public static readonly ButtonWrapper[] ArrowButtons = new ButtonWrapper[]
        {
            new ButtonWrapper(typeof(BelongsToCollection), "", 
                "Belongs link", ResourceImage.Belong, MinimalFactory.Object, true, true),
            new ButtonWrapper(typeof(DataPerformer.ObjectTransformerLink), "", 
                "Link of object transformer", ResourceImage.TransformArrow, MinimalFactory.Object, true, true),
            new ButtonWrapper(typeof(Regression.SelectionLink), "", 
                "Link between selection and selection consumer", ResourceImage.SelectionLink, MinimalFactory.Object, true, true),
            new ButtonWrapper(typeof(DataPerformer.IteratorConsumerLink), "", 
                "Iterator link", ResourceImage.IteratorLink, MinimalFactory.Object, true, true),
            new ButtonWrapper(type: typeof(UnaryLink), "", 
                "Unary link", ResourceImage.UnaryLink, MinimalFactory.Object, false, true),
        };

        public static readonly ButtonWrapper[] DataExchangeArrowButtons = new ButtonWrapper[]
        {
              new ButtonWrapper(typeof(DataPerformer.DataLink), "Mv", 
                "Measurement consumer link", ResourceImage.DataLink, MinimalFactory.Object, true, true)
            /*  new ButtonWrapper(typeof(DataPerformer.Arrows.DataLink), "", 
                "Measurement consumer link1", ResourceImage.link, MinimalFactory.Object, true, true),*/
        };


        /// <summary>
        /// Inverted arrow buttons
        /// </summary>
        public static ButtonWrapper[] ArrowButtonsInverted
        {
            get
            {

                if (arrowButtonsInv == null)
                {
                    arrowButtonsInv = new ButtonWrapper[ArrowButtons.Length];
                    for (int i = 0; i < arrowButtonsInv.Length; i++)
                    {
                        arrowButtonsInv[i] = ArrowButtons[i];
                    }
                    arrowButtonsInv[1] = new ButtonWrapper(typeof(DataPerformer.Arrows.DataLink), "",
                "Measurement consumer link", ResourceImage.Connection, MinimalFactory.Object, true, true);

                }
                return arrowButtonsInv;
            }
        }

        private static ButtonWrapper[] arrowButtonsInv;

        

        private BackgroundWorker worker;


        /// <summary>
        /// Tools
        /// </summary>
        //protected ToolsDiagram tools;

        /// <summary>
        /// Data
        /// </summary>
        protected static DataWarehouse.DatabaseInterface data;

        /// <summary>
        /// Desktop
        /// </summary>
        protected PanelDesktop desktop;


        /// <summary>
        /// The start thread
        /// </summary>
        protected ThreadStart start;

 
        /// <summary>
        /// Pause in milliseconds
        /// </summary>
        protected int pause;

        /// <summary>
        /// Step of performance
        /// </summary>
        protected double step;

        /// <summary>
        /// Time of start
        /// </summary>
        protected double startTime;

        /// <summary>
        /// Count of steps
        /// </summary>
        protected int stepCount;

        /// <summary>
        /// Number of current step
        /// </summary>
        protected int currentStep;

        /// <summary>
        /// Time indicator
        /// </summary>
        protected int timeIndicator;

      /*  /// <summary>
        /// Writer of missing resources
        /// </summary>
        private static StreamWriter missWriter;*/

        /// <summary>
        /// Extension
        /// </summary>
        private string ext;

        /// <summary>
        /// Global exception
        /// </summary>
        private Exception exglo;


        #endregion

        #region Ctor

        public EngineeringUIFactory(IUIFactory[] factories, bool defaultValue, string ext)
            : base(factories, defaultValue)
        {
            StaticExtensionDiagramUIFactory.Factory = DefalutLabelFactory.Object;
            factory = StaticExtensionDiagramUIFactory.Factory;
            this.ext = ext;
            List<IUIFactory> l = new List<IUIFactory>();
            l.Add(new DefaultFactory(ext));
            l.Add(MinimalFactory.Object);
            if (factories != null)
            {
                l.AddRange(factories);
            }
            this.factories = l.ToArray();
        }

        static EngineeringUIFactory()
        {
            Dictionary<Type, System.Drawing.Image> buttonImages =
            ButtonWrapper.CreateImageDictionary(StatisticalObjectsButtons);
            Dictionary<Type, System.Drawing.Image> d = DataPerformer.UI.Labels.NamedlSeriesLabel.ImageDictionary;
            foreach (Type t in buttonImages.Keys)
            {
                if (!d.ContainsKey(t))
                {
                    d[t] = buttonImages[t];
                }
            }
        }

        #endregion

        #region Overriden

   /*     public override void ShowError(Exception e)
        {
            if (errorHandler != null)
            {
                errorHandler.ShowError(e);
            }
        }
*/
        #endregion

       #region Specific Members

        public event Action CancelProcess
        {
            add
            {
                cancelProcess += value;
            }
            remove
            {
                cancelProcess -= value;
            }
        }

        /// <summary>
        /// Empty initializer
        /// </summary>
        private static void emptyInit()
        {
        }


        /// <summary>
        /// Project data
        /// </summary>
        public static DataWarehouse.DatabaseInterface Data
        {
            set
            {
                data = value;
            }
        }

        /// <summary>
        /// Error handler
        /// </summary>
        public IErrorHandler ErrorHandler
        {
            set
            {
                 StaticExtensionDiagramUI.ErrorHandler = value;
            }
        }

        /// <summary>
        /// Desktop
        /// </summary>
        public PanelDesktop Desktop
        {
            get
            {
                return desktop;
            }
            set
            {
                desktop = value;
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="startTime">Start time</param>
        /// <param name="pause">Pause</param>
        /// <param name="step">Step</param>
        /// <param name="stepCount">Step Count</param>
        /// <param name="desktop">Desktop</param>
        public void Start(double startTime, double step, int stepCount, int pause, int timeIndicator, IDesktop desktop)
        {
            this.startTime = startTime;
            this.pause = pause;
            this.step = step;
            this.stepCount = stepCount;
            this.timeIndicator = timeIndicator; 
            this.desktop = desktop as PanelDesktop;
            StartWorker();
        }

        private void Work(object sender, DoWorkEventArgs e)
        {
            Run();
        }

        public void StartWorker()
        {
            worker = new BackgroundWorker();
            worker.DoWork += Work;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerCompleted += Cancel;
            worker.RunWorkerAsync();
        }

        public event Action<double> TimeIndication
        {
            add { timeIndication += value; }
            remove { timeIndication -= value; }
        }

            

        public void PauseWorker()
        {
            lock (this)
            {
                if (isPaused)
                {
                    return;
                }
                isPaused = true;
            }
        }

        public void Resume()
        {
            lock (this)
            {
                pauseEvent.Set();
            }
        }

        public void StopWorker()
        {
            if (worker == null)
            {
                return;
            }
            if (isPaused)
            {
                Resume();
            }
            
            worker.CancelAsync();
        }

        private void Cancel(object sender, RunWorkerCompletedEventArgs e)
        {
            Exception ex = exglo;
            exglo = null;
            if (ex != null)
            {
                ControlUtilites.ShowError(null, ex, Common.Engineering.Localization.Utils.ControlUtilites.Resources);
            }
            if (cancelProcess != null)
            {
                cancelProcess();
            }
        }



        /// <summary>
        /// Redraws all forms
        /// </summary>
        internal void Redraw()
        {
            foreach (Control c in desktop.Controls)
            {
                if (!(c is IObjectLabelUI))
                {
                    continue;
                }
                IObjectLabelUI label = c as IObjectLabelUI;

                Form f = null;
                if (label is IShowForm)
                {
                    IShowForm sf = label as IShowForm;
                    f = sf.Form as Form;
                }
                if (f == null)
                {
                    Redraw(c);
                    continue;
                }
                if (f.IsDisposed)
                {
                    Redraw(c);
                    continue;
                }
                if (!(f is IRedraw))
                {
                    continue;
                }
                IRedraw r = f as IRedraw;
                r.Redraw();
            }
        }

        private bool Redraw(Control control)
        {
            IRedraw r = control.GetSimpleObject<IRedraw>();
            if (r != null)
            {
                r.Redraw();
                return true;
            }
            foreach (Control c in control.Controls)
            {
                if (Redraw(c))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <returns>True in case of first initialization</returns>
      /*  public static void Initialize(OrdinaryDifferentialEquations.IDifferentialEquationSolver ordSolver,
            DataPerformer.IDataPerformerStrategy strategy, IDatabaseCoordinator coordinator, IApplicationInitializer[] initializers, 
            bool throwsRepeatException)
        {
            if (BasicEngineeringInitializer.IsInitialized)
            {
                return;
            }
            EngineeringInitializer.Initialize(ordSolver,
            strategy, coordinator, initializers, throwsRepeatException);
        }*/


 




        static public string TransformEncoding(string s)
        {
            string per = "ÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÜÛÚÝÞßàáâãäå¸æçèéêëìíîïðñòóôõöøùüûúýþÿ";
            string rus = "\u0410\u0411\u0412\u0413\u0414\u0415\u0401\u0416\u0417\u0418\u0419\u041A\u041B\u041C\u041D\u041E\u041F\u0420\u0421\u0422\u0423\u0424\u0425\u0426\u0427\u0428\u0429\u042C\u042B\u042A\u042D\u042E\u042F\u0430\u0431\u0432\u0433\u0434\u0435\u0451\u0436\u0437\u0438\u0439\u043A\u043B\u043C\u043D\u043E\u043F\u0440\u0441\u0442\u0443\u0444\u0445\u0446\u0448\u0449\u044C\u044B\u044A\u044D\u044E\u044F";
            string str = "";
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                int j = per.IndexOf(c);
                if (j > -1)
                {
                    c = rus[j];
                }
                str += c;
            }
            return str;
        }

        static void copyData()
        {
            return;
        }




        #endregion
    }

    /// <summary>
    /// Initialization 
    /// </summary>
   // public delegate void Initializer();
}
