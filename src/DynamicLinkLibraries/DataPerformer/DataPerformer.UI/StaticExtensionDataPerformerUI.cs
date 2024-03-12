using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI.Utils;

using BaseTypes.Interfaces;

using AssemblyService.Attributes;

using DataPerformer.Portable;
using DataPerformer.Interfaces;

using DataPerformer.UI.Interfaces;

using Chart;
using Chart.Drawing.Series;
using Chart.Drawing.Interfaces;
using Chart.Drawing.Painters;
using DataPerformer.UI.UserControls;
using Chart.Objects;
using DataPerformer.UI.Labels;


namespace DataPerformer.UI
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDataPerformerUI
    {

        #region Fields

        static internal ImageList BufferDataImageList;

        static internal IComparer<TreeNode> BufferComparer = TreeNodeComparer.Singleton;

        static List<IDataConsumerCodeGenerator> dataConsumerCodeGenerators = new();

        /// <summary>
        /// Buffer connection string
        /// </summary>
     // !!!   static public readonly string BufferConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=BufferDatabase;Integrated Security=" +
     // !!!       "True";

        /// <summary>
        /// Modes for painting
        /// </summary>
        static private readonly string[] modes = new string[] { "Lines", "Crosses" };

        static private Action<Action> animationAction;

        static IAnimationParameters animationParameters;

        static IAnimation startAnimation;

        static IAsynchronousCalculation currentCalculation;

        static IDisassemblyObject disassembly =
            new BaseTypes.DisassemblyObjectList();

        static internal DataPerformer.Interfaces.Objects.MeasurementObjectFactoryCollection GraphCollection =
            new ();

        static event Action onUpdateAnalysisUI = () => { };

        static internal Action<IDataConsumer> initText = (IDataConsumer c) => { };

        static internal Action<object> performText = (object o) => { };

        static internal Action finishText = () => { };

        static internal IDisassemblyObject Disassembly
        {
            get { return disassembly; }
        }

        #endregion

        #region Ctor

        static StaticExtensionDataPerformerUI()
        {
            new Binder();
        /// !!! DISASSEMBLY MAY BE NEEDED     (new Portable.DisassemblyObjects.ArrayDisassemblyObject((double)0)).Add();
            BufferDataImageList = new ImageList();
            BufferDataImageList.Images.AddRange(new Image[]
            {
                ResourceImage.Directory.ToBitmap(),
                ResourceImage.OpenedDirectory.ToBitmap(),
                ResourceImage.File.ToBitmap(),
                ResourceImage.OpenedFile.ToBitmap()
            });
            StaticExtensionDiagramUI.PostLoadDesktop += PostLoad;
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        public static void GenerateCode(this GraphLabel label, string nameSpace, string className)
        {

        }

        /// <summary>
        /// Adds code generator
        /// </summary>
        /// <param name="codeGenerator"></param>
        static public void  Add(this IDataConsumerCodeGenerator codeGenerator)
        {
            dataConsumerCodeGenerators.Add(codeGenerator);
        }

        /// <summary>
        /// Udates Analisys UI event
        /// </summary>
        static public event Action OnUpdateAnalysisUI
        {
            add { onUpdateAnalysisUI += value; }
            remove { onUpdateAnalysisUI -= value; }
        }

        /// <summary>
        /// Initiate writing text file
        /// </summary>
        static public event Action<IDataConsumer> InitText
        {
            add
            {
                initText += value;
            }
            remove
            {
                initText -= value;
            }
        }

        /// <summary>
        /// Setting series to a chart
        /// </summary>
        /// <param name="chart">The chart</param>
        /// <param name="colors">The colors</param>
        /// <param name="data">Chart data</param>
        /// <param name="measurements">Measurements</param>
        static public void Set(this Chart.UserControls.UserControlFilledChart chart, 
            IColorDictionary colors, Dictionary<string, object> data, Dictionary<string, IMeasurement> measurements)
        {
            chart.Clear();
            var d = colors.ColorDictionary;
            foreach (var key in d.Keys)
            {
                var s = key + ".";
                var v = d[key];
                foreach (var item in v.Keys)
                {
                    var t = s + item;
                    var p = v[item];
                    var ps = data[t] as SeriesTypes.ParametrizedSeries;
                    ParametrizedSeries series = new ParametrizedSeries(null, null);
                    series.Add(ps);
                    var m = measurements[t];
                    chart.AddSeries(series, p, m);
                }
            }
            chart.RefreshAll();
        }
 

        /// <summary>
        /// Initiate writing text file
        /// </summary>
        static public event Action<object> PerformText
        {
            add
            {
                performText += value;
            }
            remove
            {
                performText -= value;
            }
        }

        static public event Action FinishText
        {
            add
            {
                finishText += value;
            }
            remove
            {
                finishText -= value;
            }
        }

        /// <summary>
        /// Udates Analisys UI
        /// </summary>
        static public void UpdateAnalysisUI()
        {
            onUpdateAnalysisUI();
        }

        /// <summary>
        /// Conversion of dictionary
        /// </summary>
        /// <param name="dictionary">Prototype</param>
        /// <returns>Conversion result</returns>
        public static Dictionary<string, Color[]> Convert(this Dictionary<string, Color> dictionary)
        {
            var d = new Dictionary<string, Color[]>();
            foreach (var key in dictionary.Keys)
            {
                d[key] = [dictionary[key]];
            }
            return d;
        }

        /// <summary>
        /// Conversion of dictionary
        /// </summary>
        /// <param name="dictionary">Prototype</param>
        /// <returns>Conversion result</returns>
        public static Dictionary<string, Color> Convert(this Dictionary<string, Color[]> dictionary)
        {
            var d = new Dictionary<string, Color>();
            foreach (var key in dictionary.Keys)
            {
                d[key] = dictionary[key][0];
            }
            return d;
        }

 
        /// <summary>
        /// Sets dictionary
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="ao">The associated object</param>
        public static void Set(this IColorDictionary dictionary, IAssociatedObject ao)
        {
            var o = ao.Object;
            if (o is Control)
            {
                var control = (Control)o;
                var d = control.FindChildObject<IColorDictionary>();
                if (d != null)
                {
                    d.ColorDictionary = dictionary.ColorDictionary;
                }
            }
        }

        public static IEnumerable<IMeasurements> GetMeasurements(this IColorDictionary dictionary,
            IDataConsumer consumer)
        {
            var d = dictionary.ColorDictionary;
            foreach (var measurements in consumer.GetMeasurements())
            {
                var name = consumer.GetRelativeMeasurementsName(measurements);
                if (d.ContainsKey(name)) yield return measurements;
            }
        }

        /// <summary>
        /// Sets color dictionary
        /// </summary>
        /// <param name="ao">The assiciated object</param>
        /// <param name="dictionary">The dictionary</param>
        public static void Set(this IAssociatedObject ao, IColorDictionary dictionary)
        {
            var o = ao.Object;
            if (o is Control)
            {
                var control = (Control)o;
                var d = control.FindChildObject<IColorDictionary>();
                if (d != null)
                {
                    dictionary.ColorDictionary = d.ColorDictionary;
                }
            }
        }

        /// <summary>
        /// Transforms color dictionary to strings
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <returns>The strings</returns>
        public static IEnumerable<string> ToStrings(this IColorDictionary dictionary)
        {
            var dd = dictionary.ColorDictionary;
            foreach (var item in dd.Keys)
            {
                var str = item.ToString() + ".";
                var d = dd[item];
                foreach (var k in d.Keys)
                {
                    yield return str + k;
                }
                
            }
        }


        /// <summary>
        /// Gets image of measurements
        /// </summary>
        /// <param name="measurements">The measurements</param>
        /// <returns>The image</returns>
        static public Image GetImage(this IMeasurements measurements)
        {
            return (measurements as ICategoryObject).GetImage();
        }

        /// <summary>
        /// Gets measurement objects 
        /// </summary>
        /// <param name="dataConsumer">Consumer of data</param>
        /// <param name="dictionary">Dictionary of objects</param>
        /// <param name="factory">Factory of objects</param>
        static public void GetMeasurementObjects(this IDataConsumer dataConsumer,
         Dictionary<IMeasurement, object> dictionary, IMeasurementObjectFactory factory)
        {
            Func<object, bool> condition = (object o) =>
            {
                if (o is Form)
                {
                    return !(o as Form).IsDisposed;
                }
                return true;
            };
            dataConsumer.GetMeasurementObjects(dictionary, factory, condition);
        }

        /// <summary>
        /// Removes measurement objects 
        /// </summary>
        /// <param name="dictionary">Dictionary of objects</param>
        static public void RemoveMeasurementObjects(this Dictionary<IMeasurement, object> dictionary)
        {
            dictionary.RemoveMeasurementObjects((object o) =>
            {
                if (o is Control)
                {
                    return (o as Control).IsDisposed;
                }
                return false;
            });
        }

        /// <summary>
        /// Sets a dictionary to a list view
        /// </summary>
        /// <param name="listView">The list view</param>
        /// <param name="dictionary">The dictionary</param>
        static public void Set(this ListView listView, Dictionary<string, object> dictionary)
        {
            listView.Items.Clear();
            List<string> l = new List<string>(dictionary.Keys);
            l.Sort();
            foreach (string name in l)
            {
                ListViewItem it = new ListViewItem(new string[] { name, dictionary[name] + "" });
                listView.Items.Add(it);
            }
        }

        /// <summary>
        /// Adds indicator
        /// </summary>
        /// <param name="indicator">The indicator for add</param>
        static public void AddGraphIndicator(this IMeasurementObjectFactory indicator)
        {
            GraphCollection.Add(indicator);
        }

        /// <summary>
        ///  Creates disassembly object dictionary
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <returns>The dictionary</returns>
        static public Dictionary<IMeasurement, IDisassemblyObject> CreateDisassemblyObjectDictionary(
            this IDataConsumer dataConsumer)
        {
            return dataConsumer.CreateDisassemblyObjectDictionary(disassembly);
        }

        /// <summary>
        ///  Creates disassembly measurements dictionary
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <returns>The dictionary</returns>
        static public Dictionary<IMeasurement, MeasurementsDisassemblyWrapper> CreateDisassemblyMeasurements(
            this IDataConsumer dataConsumer)
        {
            return dataConsumer.CreateDisassemblyMeasurements(disassembly);
        }

        /// <summary>
        /// Gets Disassembly object
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>Disassembly</returns>
        static public IDisassemblyObject GetDisassemblyObject(this object type)
        {
            return disassembly[type];
        }

        /// <summary>
        /// Adds disasembly object
        /// </summary>
        /// <param name="o">Object to add</param>
        static public void Add(this IDisassemblyObject o)
        {
            (disassembly as BaseTypes.DisassemblyObjectList).Add(o);
        }

        /// <summary>
        /// Interruption
        /// </summary>
        static public void Interrupt()
        {
            if (currentCalculation == null)
            {
                return;
            }
            currentCalculation.Interrupt();
            currentCalculation = null;
        }

        /// <summary>
        /// The "is running" sign
        /// </summary>
        static public bool IsRunning
        {
            get
            {
                if (currentCalculation == null)
                {
                    return false;
                }
                return currentCalculation.IsRunning;
            }
        }

        /// <summary>
        /// Fills series type combobox
        /// </summary>
        /// <param name="box">The combobox to fill</param>
        static public void FillSeriesTypeCombo(this ComboBox box)
        {
            foreach (string mode in modes)
            {
                string m = ResourceService.Resources.GetControlResource(mode,
                    DataPerformer.UI.Utils.ControlUtilites.Resources);
                box.Items.Add(m);
            }
        }

        /// <summary>
        /// Starts animation
        /// </summary>
        /// <param name="collection">Collection of components</param>
        /// <param name="reasons">Reasons</param>
        /// <param name="animationType">Type of animation</param>
        /// <param name="pause">Pause</param>
        /// <param name="timeScale">Time scale</param>
        /// <param name="realTime">The "real time" sign</param>
        /// <param name="absoluteTime">The "absolute time" sign</param>
        /// <returns>Animation asynchronous calculation</returns>
        public static IAsynchronousCalculation StartAnimation(this IComponentCollection collection, string[] reasons,
         Animation.Interfaces.Enums.AnimationType animationType,
          TimeSpan pause, double timeScale, bool realTime, bool absoluteTime)
        {
            currentCalculation = global::Animation.Interfaces.StaticExtensionAnimationInterfaces.StartAnimation
                (collection, reasons, animationType, pause, timeScale, realTime, absoluteTime)
                as IAsynchronousCalculation;
            return currentCalculation;
        }

        /// <summary>
        /// Stops current calculation
        /// </summary>
        static public void StopCurrentCalculation()
        {
            if (currentCalculation == null)
            {
                return;
            }
            if (currentCalculation.IsRunning)
            {
                currentCalculation.Interrupt();
            }
            currentCalculation = null;
        }

        /// <summary>
        ///  Fills series type tool strip combobox
        /// </summary>
        /// <param name="box">The combobox to fill</param>
        static public void FillSeriesTypeCombo(this ToolStripComboBox box)
        {
            foreach (string mode in modes)
            {
                string m = ResourceService.Resources.GetControlResource(mode,
                    DataPerformer.UI.Utils.ControlUtilites.Resources);
                box.Items.Add(m);
            }
        }

        /// <summary>
        /// Gets series names of desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>List of series</returns>
        static public List<string> GetSeries(this IDesktop desktop)
        {
            IEnumerable<IObjectLabel> objs = desktop.Objects;
            List<string> list = new List<string>();
            foreach (IObjectLabel l in objs)
            {
                if (l.Object is Series | l.Object is ISeries)
                {
                    list.Add(l.Name);
                }
            }
            return list;
        }

        /// <summary>
        /// Selects painter
        /// </summary>
        /// <param name="box">Combomox</param>
        /// <param name="color">Color</param>
        /// <param name="performer">Performer</param>
        /// <returns>Painter</returns>
        static public ISeriesPainter SelectPainter(this ComboBox box, Color color, ChartPerformer performer)
        {
            return SelectPainter(box.SelectedItem + "", new Color[] { color }, performer);
        }

        /// <summary>
        /// Selects painter
        /// </summary>
        /// <param name="mode">Mode</param>
        /// <param name="color">Color</param>
        /// <param name="performer">Performer</param>
        /// <returns>Painter</returns>
        static public ISeriesPainter SelectPainter(this string mode, Color[] color, ChartPerformer performer)
        {
            ISeriesPainter painter = null;
            if (mode.Equals(ResourceService.Resources.GetControlResource("Lines",
                DataPerformer.UI.Utils.ControlUtilites.Resources)))
            {
                painter = new SimpleSeriesPainter(color);
            }
            if (mode.Equals(ResourceService.Resources.GetControlResource("Crosses",
                DataPerformer.UI.Utils.ControlUtilites.Resources)))
            {
                painter = new CrossSeriesPainter(color);
            }
            if (painter != null)
            {
                painter.Performer = performer;
            }
            return painter;
        }

        /// <summary>
        /// Gets colors dictoinary
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <param name="measurements">Measurements</param>
        /// <param name="colors">Colors</param>
        /// <returns>The Dictionary</returns>
        public static Dictionary<IMeasurement, Color> GetColors(this IDataConsumer consumer,
            IMeasurements[] measurements, Dictionary<string, Dictionary<string, Color>> colors)
        {
            var list = new List<IMeasurements>(measurements);
            if (consumer is IMeasurements)
            {
                if (consumer.ShouldInsertIntoChildren())
                {
                    list.Add((IMeasurements)consumer);
                }
            }
            Dictionary<IMeasurement, Color> dict = new Dictionary<IMeasurement, Color>();
            foreach (var item in list)
            {
                var name = consumer.GetRelativeMeasurementsName(item);
                if (!colors.ContainsKey(name))
                {
                    continue;
                }
                var d = colors[name];
                foreach (var m in item.GetMeasurementObjects())
                {
                    var nn = m.Name;
                    if (d.ContainsKey(nn))
                    {
                        dict[m] = d[nn];
                    }
                }
            }
            return dict;
        }


        /// <summary>
        /// Draws two parameter table
        /// </summary>
        /// <param name="t">The table to draw</param>
        /// <param name="g">Graphics to draw</param>
        /// <param name="x">Left corner coordinate</param>
        /// <param name="y">Top corner coordinate</param>
        /// <param name="w">Width</param>
        /// <param name="h">Height</param>
        public static void Draw(this Table2D t, Graphics g, int x, int y, int w, int h)
        {
            if (t == null)
            {
                return;
            }
            double[,] b = t.Bounds;
            double[] e = t.Extremums;
            int xc = t.XCount;
            int yc = t.YCount;
            double ww = w;
            double hh = h;
            bool bx = ww > hh;
            double coeff = 1 / (1 + Math.Sqrt(0.5));
            double delta = (bx ? ww : hh) * coeff;
            double w1 = w - delta;
            double h1 = h - delta;
            double vScale = 0;
            if (e[1] != e[0])
            {
                vScale = h1 / (e[1] - e[0]);
            }
            double yScale = 0;
            if (b[1, 1] != b[1, 0])
            {
                yScale = delta / (b[1, 1] - b[1, 0]);
            }
            double xScale = 0;
            if (t.XCount > 1)
            {
                if (b[0, 1] != b[0, 0])
                {
                    xScale = w1 / ((2 * Math.Sqrt(0.5)) * (b[0, 1] - b[0, 0]));
                }
            }
            Pen pen = new Pen(Color.Magenta);
            double x0 = x + w1;
            double y0 = y + h1;
            for (int i = 0; i < t.XCount; i++)
            {
                double xx = t.GetX(i);
                double dx = xx - b[0, 0];
                double x1 = x0 - dx * xScale;
                double y1 = y0 + dx * xScale;
                float xOld = 0;
                float yOld = 0;
                for (int j = 0; j < t.YCount; j++)
                {
                    double v = t[i, j];
                    double vc = v - e[0];
                    vc = -vc * vScale;
                    vc += y1;
                    double yf = t.GetY(j);
                    yf = (yf - b[1, 0]) * yScale;
                    yf += x1;
                    float xd = (float)yf;
                    float yd = (float)vc;
                    if (j > 0)
                    {
                        g.DrawLine(pen, xOld, yOld, xd, yd);
                    }
                    xOld = xd;
                    yOld = yd;
                }
            }
        }

        /// <summary>
        /// Animation action
        /// </summary>
        static public Action<Action> AnimationAction
        {
            get
            {
                return animationAction;
            }
            set
            {
                animationAction = value;
            }
        }

        /// <summary>
        /// Start of animation
        /// </summary>
        public static IAnimation Animation
        {
            get
            {
                return startAnimation;
            }
            set
            {
                startAnimation = value;
            }
        }

        /// <summary>
        /// Animation parameters
        /// </summary>
        public static IAnimationParameters AnimationParameters
        {
            get
            {
                return animationParameters;
            }
            set
            {
                animationParameters = value;
            }
        }

        /// <summary>
        /// Starts Synchronous animation
        /// </summary>
        /// <param name="parameters">Parameters</param>
        /// <param name="animation">Animation action</param>
        public static void StartSynchronousAnimation(this IAnimationParameters parameters,
             Action<Action> animation)
        {
            animationParameters = parameters;
            startAnimation.Start(animation);
        }


        /// <summary>
        /// Stops animation
        /// </summary>
        /// <param name="parameters">Parameters</param>
        public static void StopAnimation(this IAnimationParameters parameters)
        {
            animationParameters = parameters;
            startAnimation.Stop();
        }

        /// <summary>
        /// Pauses animation
        /// </summary>
        /// <param name="parameters">Parameters</param>
        public static void PauseAnimation(this IAnimationParameters parameters)
        {
            startAnimation.Pause();
        }

        /// <summary>
        /// Saves series
        /// </summary>
        /// <param name="series">Series for saving</param>
        /// <param name="control">Parent control</param>
        public static void Save(this Series series, Control control)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Graph files |*.gra";
            if (control == null)
            {
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            if (dlg.ShowDialog(control) != DialogResult.OK)
            {
                return;
            }
            series.Save(dlg.FileName);
        }

        /// <summary>
        /// Loads series
        /// </summary>
        /// <param name="series">Series for loading</param>
        /// <param name="control">Parent control</param>
        public static void Load(this Series series, Control control)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Graph files |*.gra";
            if (control == null)
            {
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            if (dlg.ShowDialog(control) != DialogResult.OK)
            {
                return;
            }
            series.Load(dlg.FileName);
        }

        /// <summary>
        /// Copies series to clipboard
        /// </summary>
        /// <param name="series">Series to copy to clipboard</param>
        public static void CopyToClipboard(this Series series)
        {
            if (series == null)
            {
                return;
            }
            PureSeries ps = new PureSeries();
            for (int i = 0; i < series.Count; i++)
            {
                ps.AddXY(series[i, 0], series[i, 1]);
            }
            Clipboard.SetDataObject(ps, false);
        }

        #endregion

        #region Private & Internal Members

        #region Internal Members

        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="exception">Error exception</param>
        static internal void ShowError(this Control control, Exception exception)
        {
            Utils.ControlUtilites.ShowError(control, exception);
        }

        static internal void ShowMessage(this Control control, string message)
        {
            Utils.ControlUtilites.ShowMessage(control, message);
        }

        static internal void LoadResources(this Control control)
        {
            ResourceService.Resources.LoadControlResources(control, DataPerformer.UI.Utils.ControlUtilites.Resources);
        }

        static internal void ShowLocalized(this string text)
        {
            text.ShowLocalized(DataPerformer.UI.Utils.ControlUtilites.Resources);
        }

        static internal object[] DefaultSeriesPaintingArray
        {
            get
            {
                return new object[] { (int)(-1), Color.Black, new ICollection[0], false };
            }
        }

        static internal TreeNode Find(this TreeNode node, string url)
        {
            object o = node.Tag;
            if (o is DataPerformer.Interfaces.BufferedData.Interfaces.IBufferItem)
            {
                DataPerformer.Interfaces.BufferedData.Interfaces.IBufferItem li =
                    o as DataPerformer.Interfaces.BufferedData.Interfaces.IBufferItem;
                if (li.GetUrl().Equals(url))
                {
                    return node;
                }
            }
            foreach (TreeNode tn in node.Nodes)
            {
                TreeNode t = Find(tn, url);
                if (t != null)
                {
                    return t;
                }
            }
            return null;
        }

        static internal TreeNode Find(this TreeView tv, string url)
        {
            foreach (TreeNode node in tv.Nodes)
            {
                TreeNode tn = node.Find(url);
                if (tn != null)
                {
                    return tn;
                }
            }
            return null;
        }

        static internal TreeNode CreateNode(this
            DataPerformer.Interfaces.BufferedData.Interfaces.IBufferItem item,
                bool openedDir = false)
        {
            int n2 = 0;
            int n3 = 1;
            int n4 = 2;
            if (openedDir)
            {
                ++n2;
                ++n3;
                ++n4;
            }
            TreeNode n = null;
            if (item is DataPerformer.Interfaces.BufferedData.Interfaces.IBufferDirectory)
            {
                DataPerformer.Interfaces.BufferedData.Interfaces.IBufferDirectory d =
                    item as DataPerformer.Interfaces.BufferedData.Interfaces.IBufferDirectory;
                List<TreeNode> l = new List<TreeNode>();
                foreach (DataPerformer.Interfaces.BufferedData.Interfaces.IBufferItem it in
                    d.Children)
                {
                    TreeNode tn = it.CreateNode(openedDir);
                    if (tn != null)
                    {
                        l.Add(it.CreateNode(openedDir));
                    }
                }
                l.Sort(TreeNodeComparer.Singleton);
                n = new TreeNode(item.Name, 0, 1, l.ToArray());
            }
            else
            {
                if (!openedDir)
                {
                    n = new TreeNode(item.Name, 2, 3);
                }
                else
                {
                    return null;
                }
            }
            n.Tag = item;
            return n;
        }

        static internal int GetDrawMode(this object[] array)
        {
            return (int)array[0];
        }

        static internal Color GetColor(this object[] array)
        {
            return (Color)array[1];
        }

        static internal ICollection[] GetComments(this object[] array)
        {
            return (ICollection[])array[2];
        }

        static internal bool GetShowTable(this object[] array)
        {
            return (bool)array[3];
        }

        static internal void SetDrawMode(this object[] array, int mode)
        {
            array[0] = mode;
        }

        static internal void SetColor(this object[] array, Color color)
        {
            array[1] = color;
        }

        static internal void SetComments(this object[] array, ICollection[] comments)
        {
            array[2] = comments; ;
        }

        static internal void SetShowTable(this object[] array, bool showTable)
        {
            array[3] = showTable;
        }

        static internal void Fill(this INamedCoordinates coord, ToolStripComboBox cx, ToolStripComboBox cy)
        {
            string x = coord.X;
            string y = coord.Y;
            cx.Text = "<X>";
            cx.Items.Clear();
            IList<string> l = coord.GetNames("x");
            if (l != null)
            {
                cx.FillCombo(l);
                if (x != null)
                {
                    cx.SelectCombo(x);
                }
            }
            cy.Text = "<Y>";
            cy.Items.Clear();
            l = coord.GetNames("y");
            if (l != null)
            {
                cy.FillCombo(l);
                if (y != null)
                {
                    cy.SelectCombo(y);
                }
            }
        }

        #endregion

        #region Private Members

        static void PostLoad(IDesktop desktop)
        {
            try
            {
                desktop.ForEach((IAssociatedObject ao) =>
                {
                    object o = ao.Object;
                    if (o is Control)
                    {
                        Control c = o as Control;
                        IPostLoadDesktop p = c.FindChildObject<IPostLoadDesktop>();
                        if (p != null)
                        {
                            p.PostLoad();
                        }
                    }
               });
            }
            catch (Exception exception)
            {
                exception.ShowError(10);
            }

        }

        #endregion


        #endregion

        #region Classes

        #region Binder Class

        //!!!BINDER
        class Binder : System.Runtime.Serialization.SerializationBinder
        {
            static bool first = true;

            internal Binder()
            {
                if (first)
                {
                    first = false;
                    this.Add();
                }
            }
            readonly string[] types = new string[] { "DataPerformerUI", "DataPerformer.UI" };
            public override Type BindToType(string assemblyName, string typeName)
            {
                if (assemblyName.Contains(types[0]))
                {
                    Type t = Type.GetType(String.Format("{0}, {1}",
                        typeName.Replace(types[0], types[1]),
                        assemblyName.Replace(types[0], types[1])));
                    return t;
                }
                return null;

            }
        }

        #endregion

        #region TreeNodeComparer class

        class TreeNodeComparer : IComparer<TreeNode>
        {

            static internal TreeNodeComparer Singleton = new TreeNodeComparer();

            int IComparer<TreeNode>.Compare(TreeNode x, TreeNode y)
            {
                DataPerformer.Interfaces.BufferedData.Interfaces.IBufferItem lx = x.Tag as
                    DataPerformer.Interfaces.BufferedData.Interfaces.IBufferItem;
                DataPerformer.Interfaces.BufferedData.Interfaces.IBufferItem ly = y.Tag as
                         DataPerformer.Interfaces.BufferedData.Interfaces.IBufferItem;
                if ((lx is DataPerformer.Interfaces.BufferedData.Interfaces.IBufferDirectory))
                {
                    if (ly is DataPerformer.Interfaces.BufferedData.Interfaces.IBufferDirectory)
                    {
                        return x.Text.CompareTo(y.Text);
                    }
                    return -1;
                }
                if (ly is DataPerformer.Interfaces.BufferedData.Interfaces.IBufferDirectory)
                {
                    return 1;
                }
                return x.Text.CompareTo(y.Text);
            }
        }

        #endregion

        #endregion

        internal static void Load(UserControls.UserControlSeries userControlSeries, Series series)
        {
            throw new NotImplementedException();
        }
    }
}