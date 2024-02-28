using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Linq;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Utils;
using Diagram.UI.Labels;

using BaseTypes.Attributes;

using DataPerformer.UI.UserControls;
using DataPerformer.UI.Interfaces;
using DataPerformer.UI.UserControls.Graph;
using Chart.Drawing;


namespace DataPerformer.UI.Labels
{
    /// <summary>
    /// Label of graph
    /// </summary>
    [Serializable()]
    public partial class GraphLabel : UserControlBaseLabel, IBlocking,
       INonstandardLabel, IStartStop, IStartStopConsumer, IGraphLabel, IPostLoadDesktop
    {

        #region Specific Fields

        private DataConsumer consumer;

        private global::Animation.Interfaces.Enums.AnimationType animationType =
            global::Animation.Interfaces.Enums.AnimationType.Synchronous;

        private Dictionary<string, string> textsBuf = null;

        private Dictionary<string, Color[]> colorsBuf = null;

        private Dictionary<string, Color> cBuf;

        private Dictionary<string, bool> stepChartBuf = null;

        private PictureBox pb = new PictureBox();

        private Label lt = new Label();


        private Forms.FormGraph form = null;

        private double timeScaleAnimation = 1;

        private TimeType timeUnitAnimation = TimeType.Second;

        internal Tuple<Dictionary<string, Color[]>, Dictionary<string, bool>,
            Dictionary<string, string>, string[], int[],
             Tuple<double[],
            Dictionary<string, Dictionary<string,
            Tuple<Color[], bool, double[]>>>>[]> data =

            new Tuple<Dictionary<string, Color[]>, Dictionary<string, bool>,
                Dictionary<string, string>, string[], int[], Tuple<double[],
            Dictionary<string, Dictionary<string,
            Tuple<Color[], bool, double[]>>>>[]>
                (new Dictionary<string, Color[]>(),
                new Dictionary<string, bool>(),
                new Dictionary<string, string>(), new string[] { "", "", "", "", "", "" },
                new int[2],
                new Tuple<double[], Dictionary<string, Dictionary<string, Tuple<Color[], bool, double[]>>>>[]
                {
                        new Tuple<double[], Dictionary<string, Dictionary<string, Tuple<Color[], bool, double[]>>>>
                    (new double[]{60}, new Dictionary<string, Dictionary<string, Tuple<Color[], bool, double[]>>>())
                }
                );

        Tuple<Dictionary<string, Color>, Dictionary<string, bool>,
         Dictionary<string, string>, string[], int[],
          Tuple<double[],
         Dictionary<string, Dictionary<string,
         Tuple<Color, bool, double[]>>>>[]> dat;


        UserControlGraph child;

        TimeType timeType = TimeType.Second;

        bool absoluteTime = true;

        Tuple<double[],
                    Dictionary<string,
                    Dictionary<string, Tuple<Color, bool, double[]>>>> rtime;

        Tuple<double[],
            Dictionary<string,
            Dictionary<string, Tuple<Color[], bool, double[]>>>> realtime = null;

        internal Dictionary<string, Size> sizes = new Dictionary<string, Size>();

        int cadrNumber = 0;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphLabel()
            : base(typeof(DataConsumer), "", ResourceImage.Graph.ToBitmap())
        {

        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected GraphLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            CopyDat();
            info.AddValue("Colors", dat.Item1, typeof(Dictionary<string, Color>));
            string[] s = data.Item4;
            info.AddValue("Argument", s[1], typeof(string));
            info.AddValue("Condition", s[0], typeof(string));
            info.AddValue("Texts", data.Item3, typeof(Dictionary<string, string>));
            info.AddValue("Start", s[2], typeof(string));
            info.AddValue("Step", s[3], typeof(string));
            info.AddValue("StepCount", s[4], typeof(string));
            info.AddValue("Split", data.Item5[1]);
            info.AddValue("StepChart", data.Item2, typeof(Dictionary<string, bool>));
            info.AddValue("Points", s[5]);
            info.AddValue("Pause", data.Item5[0]);
            info.AddValue("TimeType", timeType, typeof(TimeType));
            info.AddValue("AbsoluteTime", absoluteTime);
            info.AddValue("Realtime", dat.Item6[0],
                typeof(Tuple<double[],
            Dictionary<string, Dictionary<string,
            Tuple<Color, bool, double[]>>>>));
            info.AddValue("AnimationType", animationType, typeof(Animation.Interfaces.Enums.ActionType));
            info.AddValue("TimeScaleAnimation", timeScaleAnimation);
            info.AddValue("TimeUnitAnimation", timeUnitAnimation, typeof(TimeType));
            info.AddValue("IndicatorSizes", sizes, typeof(Dictionary<string, Size>));
            info.AddValue("CadrNumber", cadrNumber);
            info.AddValue("MultiSeries", MultiSeries, typeof(List<Dictionary<string, Color[]>>));
        }

        #endregion

        #region Diagram.UI.Interfaces.IBlocking Members

        bool IBlocking.IsBlocked
        {
            get
            {
                IBlocking b = child;
                return b.IsBlocked;
            }
            set
            {
                IBlocking b = child;
                b.IsBlocked = value;
            }
        }

        #endregion

        #region IGraphLabel Members

        /// <summary>
        /// Data
        /// </summary>
        Tuple<Dictionary<string, Color[]>, Dictionary<string, bool>,
           Dictionary<string, string>, string[], int[],
            Tuple<double[],
           Dictionary<string, Dictionary<string,
           Tuple<Color[], bool, double[]>>>>[]> IGraphLabel.Data
        {
            get
            {
                PostLoad();
                return data;
            }
            set
            {

            }
        }

        #endregion

        #region IStartStop Members

        void IStartStop.Action(object type, ActionType actionType)
        {
            IStartStop ss = child;
            ss.Action(type, actionType);
        }

        #endregion

        #region IStartStopConsumer Members

        /// <summary>
        /// Start stop
        /// </summary>
        public IStartStop StartStop
        {
            get
            {
                IStartStopConsumer ssc = child;
                return ssc.StartStop;
            }
            set
            {
                IStartStopConsumer ssc = child;
                ssc.StartStop = value;
            }
        }

        #endregion

        #region IPostLoadDesktop Members

        void IPostLoadDesktop.PostLoad()
        {
            PostLoadDesktop();
        }

        #endregion

        #region Create form members

        /// <summary>
        /// Initialization
        /// </summary>
        new public void Initialize()
        {
            (child as IGraphLabel).Data = (this as IGraphLabel).Data;
            child.TimeUnit = timeType;
            child.IsAbsuluteTime = absoluteTime;
            child.ChangeAbsoluteTime += (bool b) => { absoluteTime = b; };
            child.ChangeTimeUnit += (TimeType tt) => { timeType = tt; };
        }

        /// <summary>
        /// Resize
        /// </summary>
        new public void Resize()
        {
        }

        /// <summary>
        /// Creates editor form
        /// </summary>
        public override void CreateForm()
        {
            form = new Forms.FormGraph(this);
        }

        /// <summary>
        /// Editor form
        /// </summary>
        public override object Form
        {
            get
            {
                return form;
            }
        }


        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {
            child.Post();
        }



        #endregion

        #region Members

        internal List<Dictionary<string, Color[]>> MultiSeries
        {
            get;
            private set;
        } = new List<Dictionary<string, Color[]>>()
        {
            new ()// Dictionary<string, Color[]>()
        };

        internal double TimeScaleAnimation
        {
            get { return timeScaleAnimation; }
            set { timeScaleAnimation = value; }
        }

        internal TimeType TimeUnitAnimation
        {
            get { return timeUnitAnimation; }
            set { timeUnitAnimation = value; }
        }

        internal Animation.Interfaces.Enums.AnimationType AnimationType
        {
            get
            {
                return animationType;
            }
            set
            {
                animationType = value;
            }
        }


        internal IDesktop OwnDesktop
        {
            set
            {
                desktop = value;
            }
        }

        private void ResizeLabel(object sender, EventArgs e)
        {
            child.SetVisible();
        }

        void PreInit()
        {
            child.PreInit();
        }
   
        private void CopyDat()
        {
            Dictionary<string, Color> d = new Dictionary<string, Color>();
            Dictionary<string, Color[]> dd = data.Item1;
            foreach (string key in dd.Keys)
            {
                d[key] = dd[key][0];
            }
            Tuple<double[],
               Dictionary<string, Dictionary<string,
               Tuple<Color[], bool, double[]>>>>[] ddd = data.Item6;

            List<Tuple<double[], Dictionary<string, Dictionary<string,
               Tuple<Color, bool, double[]>>>>> l = new List<Tuple<double[], Dictionary<string, Dictionary<string, Tuple<Color, bool, double[]>>>>>();
            foreach (Tuple<double[], Dictionary<string, Dictionary<string, Tuple<Color[], bool, double[]>>>> tddd in ddd)
            {
                Dictionary<string, Dictionary<string, Tuple<Color[], bool, double[]>>> dl = tddd.Item2;
                Dictionary<string, Dictionary<string, Tuple<Color, bool, double[]>>> dll = new Dictionary<string, Dictionary<string, Tuple<Color, bool, double[]>>>();
                foreach (string key in dl.Keys)
                {
                    Dictionary<string, Tuple<Color[], bool, double[]>> dpp = dl[key];
                    Dictionary<string, Tuple<Color, bool, double[]>> dppp = new Dictionary<string, Tuple<Color, bool, double[]>>();
                    foreach (string str in dpp.Keys)
                    {
                        Tuple<Color[], bool, double[]> tt = dpp[str];
                        dppp[str] = new Tuple<Color, bool, double[]>(tt.Item1[0], tt.Item2, tt.Item3);
                    }
                    dll[key] = dppp;
                }
                l.Add(new Tuple<double[], Dictionary<string, Dictionary<string, Tuple<Color, bool, double[]>>>>(tddd.Item1, dll));
            }
            dat = new Tuple<Dictionary<string, Color>, Dictionary<string, bool>, Dictionary<string, string>, string[],
                int[], Tuple<double[], Dictionary<string, Dictionary<string, Tuple<Color, bool, double[]>>>>[]>(
                d, data.Item2, data.Item3, data.Item4, data.Item5, l.ToArray());
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {
                child = new UserControlGraph(true);
                child.ParentLabel = this;
                return child;
            }
        }


        /// <summary>
        /// Object
        /// </summary>
        public override ICategoryObject Object
        {
            get
            {
                return consumer;
            }
            set
            {
                if (!(value is DataConsumer))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                PostLoad();
                consumer = value as DataConsumer;
                consumer.Object = this;
                child.Set(consumer, data);
            }
        }

        /// <summary>
        /// Load operation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected override void Load(SerializationInfo info, StreamingContext context)
        {
            base.Load(info, context);
            try
            {
                if (type == null)
                {
                    type = typeof(DataPerformer.DataConsumer);
                }
                cBuf = info.GetValue("Colors", typeof(Dictionary<string, Color>)) as Dictionary<string, Color>;
                string argument = info.GetValue("Argument", typeof(string)) as string;
                string condition = info.GetValue("Condition", typeof(string)) as string;
                textsBuf = info.GetValue("Texts", typeof(Dictionary<string, string>)) as Dictionary<string, string>;
                string start = info.GetValue("Start", typeof(string)) as string;
                string step = info.GetValue("Step", typeof(string)) as string;
                string stepCount = info.GetValue("StepCount", typeof(string)) as string;
                int dist = info.GetInt32("Split");
                stepChartBuf = info.GetValue("StepChart", typeof(Dictionary<string, bool>)) as Dictionary<string, bool>;
                string points = info.GetString("Points");
                int pause = info.GetInt32("Pause");
                string[] s = data.Item4;
                s[0] = condition;
                s[1] = argument;
                s[2] = start;
                s[3] = step;
                s[4] = stepCount;
                s[5] = points;
                int[] n = data.Item5;
                n[0] = pause;
                n[1] = dist;
                timeType = (TimeType)info.GetValue("TimeType", typeof(TimeType));
                absoluteTime = info.GetBoolean("AbsoluteTime");
                rtime = info.GetValue("Realtime", typeof(Tuple<double[],
                    Dictionary<string, Dictionary<string,
                    Tuple<Color, bool, double[]>>>>)) as Tuple<double[],
                    Dictionary<string, Dictionary<string,
                    Tuple<Color, bool, double[]>>>>;
                animationType = (Animation.Interfaces.Enums.AnimationType)info.GetValue("AnimationType",
                    typeof(Animation.Interfaces.Enums.AnimationType));
                timeScaleAnimation = info.GetDouble("TimeScaleAnimation");
                timeUnitAnimation = (TimeType)info.GetValue("TimeUnitAnimation", typeof(TimeType));
                sizes = info.GetValue("IndicatorSizes", typeof(Dictionary<string, Size>)) as Dictionary<string, Size>;
                cadrNumber = info.GetInt32("CadrNumber");
                try
                {
                    MultiSeries = info.GetValue("MultiSeries", typeof(List<Dictionary<string, Color[]>>)) 
                        as List<Dictionary<string, Color[]>>;
                }
                catch
                {

                }

            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        #endregion

        #region Internal Members

        internal int CadrNumber
        {
            get
            {
                return cadrNumber;
            }
            set
            {
                if (cadrNumber == value)
                {
                    return;
                }
                this.FindChild<UserControlGraph>().indicatorWrapper.UpdateIndicators();
                UpdateCadr(value);
                cadrNumber = value;
            }
        }

        #endregion

        #region Private Members

        void UpdateCadr(int cadrNumber)
        {
            UserControlCadr userControlCadr = this.FindChild<UserControlCadr>();
            UserControlGraph userControlGraph = this.FindChild<UserControlGraph>();
            userControlGraph.StartIterator(cadrNumber);
            Dictionary<string, object> values = userControlGraph.CadrMeasurements;
            Dictionary<string, object> vals = userControlGraph.CadrExternal;
            values = values.Concat(vals).ToDictionary(x => x.Key, x => x.Value); 
            userControlCadr.Dictionary = values;
        }

        void PostLoadDesktop()
        {
            UpdateCadr(cadrNumber);
        }



        void PostLoad()
        {
            // Create a new ContextMenuStrip control.
            ContextMenuStrip fruitContextMenuStrip = new ContextMenuStrip();

            // Attach an event handler for the 
            // ContextMenuStrip control's Opening event.
           // fruitContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(cms_Opening);

            // Create a new ToolStrip control.
            ToolStrip ts = new ToolStrip();

            // Create a ToolStripDropDownButton control and add it
            // to the ToolStrip control's Items collections.
            ToolStripDropDownButton fruitToolStripDropDownButton = new ToolStripDropDownButton("Fruit", null, null, "Fruit");
            ts.Items.Add(fruitToolStripDropDownButton);

            // Dock the ToolStrip control to the top of the form.
            ts.Dock = DockStyle.Top;

            // Assign the ContextMenuStrip control as the 
            // ToolStripDropDownButton control's DropDown menu.
            fruitToolStripDropDownButton.DropDown = fruitContextMenuStrip;

            // Create a new MenuStrip control and add a ToolStripMenuItem.
            MenuStrip ms = new MenuStrip();
            ToolStripMenuItem fruitToolStripMenuItem = new ToolStripMenuItem("Fruit", null, null, "Fruit");
            ms.Items.Add(fruitToolStripMenuItem);

            // Dock the MenuStrip control to the top of the form.
            ms.Dock = DockStyle.Top;

            // Assign the MenuStrip control as the 
            // ToolStripMenuItem's DropDown menu.
            fruitToolStripMenuItem.DropDown = fruitContextMenuStrip;

            // Assign the ContextMenuStrip to the form's 
            // ContextMenuStrip property.
            //this.ContextMenuStrip = fruitContextMenuStrip;

            // Add the ToolStrip control to the Controls collection.
            //this.Controls.Add(ts);

            UserControlLabel p  = this.FindParent<UserControlLabel>();
            //   ContextMenuStrip menu = new ContextMenuStrip();
          

            if (rtime != null)
            {
                Dictionary<string, Dictionary<string, Tuple<Color[], bool, double[]>>> d =
                    new Dictionary<string, Dictionary<string, Tuple<Color[], bool, double[]>>>();
                foreach (string key in rtime.Item2.Keys)
                {
                    Dictionary<string, Tuple<Color, bool, double[]>> dt = rtime.Item2[key];
                    Dictionary<string, Tuple<Color[], bool, double[]>> dtt = new Dictionary<string, Tuple<Color[], bool, double[]>>();
                    foreach (string kk in dt.Keys)
                    {
                        Tuple<Color, bool, double[]> tp = dt[kk];
                        dtt[kk] = new Tuple<Color[], bool, double[]>(new Color[] { tp.Item1 }, tp.Item2, tp.Item3);
                    }
                    d[key] = dtt;
                }
                realtime = new Tuple<double[], Dictionary<string, Dictionary<string, Tuple<Color[], bool, double[]>>>>(rtime.Item1, d);
            }
            if (cBuf != null)
            {
                colorsBuf = new Dictionary<string, Color[]>();
                foreach (string key in cBuf.Keys)
                {
                    colorsBuf[key] = new Color[] { cBuf[key] };
                }
                cBuf = null;
            }
            if (colorsBuf != null)
            {
                foreach (string key in colorsBuf.Keys)
                {
                    data.Item1[key] = colorsBuf[key];
                }
                colorsBuf = null;
            }
            if (stepChartBuf != null)
            {
                foreach (string key in stepChartBuf.Keys)
                {
                    data.Item2[key] = stepChartBuf[key];
                }
                stepChartBuf = null;
            }
            if (textsBuf != null)
            {
                foreach (string key in textsBuf.Keys)
                {
                    data.Item3[key] = textsBuf[key];
                }
                textsBuf = null;
            }
            if (realtime != null)
            {
                data.Item6[0] = realtime;
            }
           this.FindChild<UserControlCadr>().Cadr = cadrNumber;
        }

        #endregion

    }
}
