using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataPerformer.UI.UserControls.Wpf
{
    /// <summary>
    /// Interaction logic for UserControlWpfChart.xaml
    /// </summary>
    public partial class UserControlWpfChart : UserControl
    {

        #region Fields
 
        Dictionary<string, Tuple<System.Windows.Media.Color, bool, double[], Func<object, double>>> dictionary =
        new Dictionary<string,Tuple<Color,bool,double[],Func<object,double>>>();

        Dictionary<string, Path> dPath = new Dictionary<string, Path>();


        double current = 0;


        double timeInterval = 60;

        double currentTime;

        double startTime;

        Dictionary<string, object> dict;

        double t;

        Action<Dictionary<string, object>, double> write;


        Dictionary<string, double> last = new Dictionary<string, double>();


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlWpfChart()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Wrires dictionary
        /// </summary>
        /// <param name="d">The dictrionary</param>
        /// <param name="time"></param>
        public void Write(Dictionary<string, object> d, double time)
        {
            dict = d;
            t = time;
            Dispatcher.Invoke(Set);
        }

        /// <summary>
        /// Resets itself
        /// </summary>
        public void Reset()
        {
            Clear();
            CreateUI();
            write = SetLast;
        }

        /// <summary>
        /// Clears itself
        /// </summary>
        public void Clear()
        {
           Dispatcher.Invoke(() => { main.Children.Clear(); });
        }


        /// <summary>
        /// Access to function by name
        /// </summary>
        /// <param name="name">Function name</param>
        /// <returns>The function</returns>
        public Tuple<Color, bool, double[], Func<object, double>> this[string name]
        {
            set
            {
                dictionary[name] = value;
            }
        }

        #region Public Members
        /// <summary>
        /// Output
        /// </summary>
        [Browsable(true)]
        [Category("Control"), Description("Time interval"), DisplayName("Time interval")]
        public double Interval
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
            write(dict, t);
        }

        void SetLast(Dictionary<string, object> d, double time)
        {
            current = Width;
            startTime = time;
            currentTime = time;
            foreach (string key in dictionary.Keys)
            {
                Tuple<Color, bool, double[], Func<object, double>> t = dictionary[key];
                double[] s = t.Item3;
                try
                {
                    double x = t.Item4(d[key]);
                    last[key] = GetY(x, s);
                }
                catch
                {

                }
            }
           write = SetAction;

        }

        private void SetAction(Dictionary<string, object> d, double time)
        {
            double next = Width + ((time - startTime) * Width) / timeInterval;
            double delta = next - current;
            foreach (string key in d.Keys)
            {
                Tuple<Color, bool, double[], Func<object, double>> t = dictionary[key];
                double[] s = t.Item3;
                double x = t.Item4(d[key]);
                x = GetY(x, s);
                Path p = dPath[key];
                LineGeometry l = new LineGeometry(new Point(current, last[key]), new Point(next, x));
                last[key] = x;
                GeometryGroup g = p.Data as GeometryGroup;
                g.Children.Add(l);
                (g.Transform as TranslateTransform).X -= delta;
            }
            current = next;
        }


        void CreateUI()
        {
            dPath.Clear();
            last.Clear();
            foreach (string key in dictionary.Keys)
            {
                GeometryGroup g = new GeometryGroup();
                TranslateTransform tt = new TranslateTransform();
                g.Transform = tt;
                tt.X = 0;
                tt.Y = 0;
                Path p = new Path();
                p.Data = g;
                Tuple<Color, bool, double[], Func<object, double>> t = dictionary[key];
                p.Stroke = new SolidColorBrush(t.Item1);
                p.StrokeThickness = 1;
                dPath[key] = p;
                main.Children.Add(p);
            }
        }

        double GetY(double x, double[] d)
        {
            double y = (x - d[0]) / (d[1] - d[0]);
            y = Height - y * Height;
            return y;
        }

        #endregion
    }
}