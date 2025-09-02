using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using BaseTypes;
using Scada.Interfaces;

using Scada.Wpf.Common.Convertes;


namespace Scada.WPF.UI.ScadaControls
{
    /// <summary>
    /// Chart group
    /// </summary>
    public partial class UserControlChartGroup : UserControl, IScadaConsumer
    {

        #region Fields

        object[] ob;

        Func<object[]> output;

        double[] last; 

        Path[] paths;

        IEvent eventObject;

        IScadaInterface scada;

        double current = 0;

        bool isEnabled;

        Action act;

        double timeInterval = 60;

        double currentTime;

        double startTime;
   
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlChartGroup()
        {
            InitializeComponent();
            
        }

        #endregion

        #region IScadaConsumer Members

        IScadaInterface IScadaConsumer.Scada
        {
            get
            {
                return scada;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                if (scada == null)
                {
                    if (!CreateUI())
                    {
                        return;
                    }
                }
                scada = value;
                if (eventObject != null)
                {
                    if (isEnabled)
                    {
                        eventObject.Event -= Set;
                    }
                }
                eventObject = scada[Event];
                List<string> n = new List<string>();
                foreach (Tuple<string, Color, double[]> t in Output)
                {
                    n.Add(t.Item1);
                    scada.AddEventOutput(Event, t.Item1);
                }
                output = scada.GetOutput(n.ToArray());
            }
        }

        bool IScadaConsumer.IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled == value)
                {
                    return;
                }
                isEnabled = value;
                if (!StaticExtensionWpfUI.Strict)
                {
                    if (paths == null)
                    {
                        return;
                    }
                }
                if (value)
                {
                    foreach (Path p in paths)
                    {
                        GeometryGroup g = p.Data as GeometryGroup;
                        g.Children.Clear();
                    }
                    act = SetLast;
                    eventObject.Event += Set;
                }
                else
                {
                    eventObject.Event -= Set;
                }
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Event
        /// </summary>
        [Browsable(true)]
        [TypeConverter(typeof(EventConverter))]
        [Category("SCADA"), Description("Event name"), DisplayName("Event")]
        public string Event
        {
            get;
            set;
        }

        /// <summary>
        /// Output
        /// </summary>
        [Browsable(true)]
        [Category("SCADA"), Description("Output"), DisplayName("Output")]
        public List<Tuple<string, Color, double[]>> Output
        {
            get;
            set;
        }

        /// <summary>
        /// Output
        /// </summary>
        [Browsable(true)]
        [Category("SCADA"), Description("Time interval"), DisplayName("Time interval")]
        public double TimeInterval
        {
            get
            {
                return timeInterval;
            }
            set
            {
                timeInterval = value;
            }
        }

        #endregion

        #region Private Methods

        void Set()
        {
            ob = output();
            Dispatcher.Invoke(act);
        }

        void SetLast()
        {
            current = 0;
            for (int i = 0; i < ob.Length; i++)
            {
                var xo = ob[i];
                if (xo == null)
                {
                    continue;
                }
                double[] d = Output[i].Item3;
                double x = (double)ob[i];
                last[i] = GetY(x, d);
                TranslateTransform tt = (paths[i].Data as Geometry).Transform as TranslateTransform;
                tt.Y = 0;
                tt.X = ActualWidth;
            }
            startTime = DateTime.Now.DateTimeToDay();
            currentTime = startTime;
            act = SetAction;
         }

        private void SetAction()
        {
            double time = DateTime.Now.DateTimeToDay();
            double next = ((time - startTime) * ActualWidth * 86400) / timeInterval;
            double delta = next - current;
            for (int i = 0; i < paths.Length; i++)
            {
                Tuple<string, Color, double[]> t = Output[i];
                double[] d = Output[i].Item3;
                double x = (double)ob[i];
                x = GetY(x, d);
                Path p = paths[i];
                LineGeometry l = new LineGeometry(new Point(current, last[i]), new Point(next, x));
                last[i] = x;
                GeometryGroup g = p.Data as GeometryGroup;
                g.Children.Add(l);
                (g.Transform as TranslateTransform).X -= delta;
            }
            current = next;
        }

        bool CreateUI()
        {
            if (!StaticExtensionWpfUI.Strict)
            {
                if (Output == null)
                {
                    return false;
                }
            }
            paths = new Path[Output.Count];
            last = new double[Output.Count];
            List<GeometryGroup> l = new List<GeometryGroup>();
            for (int i = 0; i < Output.Count; i++)
            {
                GeometryGroup g = new GeometryGroup();
                g.Transform = new TranslateTransform();
                Path p = new Path();
                p.Data = g;
                //paths[i] = p;
                Tuple<string, Color, double[]> t = Output[i];
                p.Stroke = new SolidColorBrush(t.Item2);
                p.StrokeThickness = 1;
                paths[i] = p;
                main.Children.Add(p);
            }
            return true;
        }

        double GetY(double x, double[] d)
        {
            double y = (x - d[0]) / (d[1] - d[0]);
            y = ActualHeight - y * ActualHeight;
            return y;
        }

        #endregion

    }
}