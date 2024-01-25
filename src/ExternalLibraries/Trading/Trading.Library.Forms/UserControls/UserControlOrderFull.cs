using System;
using System.Windows.Forms;
using System.Drawing;
using Diagram.UI;
using Diagram.Interfaces;

using Chart.DataPerformer;

using DataPerformer.Portable;

using Trading.Library.Forms.Interfaces;
using Trading.Library.Objects;
using System.Threading.Tasks;
using System.Collections.Generic;
using WindowsExtensions;
using DataPerformer.UI.Interfaces;
using DataPerformer.UI;
using System.Linq;
using DataPerformer.Interfaces;
using Chart.Interfaces;
using System.Text;

namespace Trading.Library.Forms.UserControls
{
    public partial class UserControlOrderFull : UserControl, IOrderHolder, IMouseChartIndicator
    {
        Order order;

        volatile bool finish = false;

        UserControlOrderChart chart;

        Dictionary<string, object> dictionary;

        bool mouseWheelEnabled = false;

        IColorDictionary colorDictionary;

        Dictionary<string, Dictionary<string, Color>> dColor;

        public UserControlOrderFull()
        {
            InitializeComponent();
            tabControlMain.TabPages.Remove(tabPageProperties);
            colorDictionary = this.FindChildObject<IColorDictionary>();
            chart = this.FindChildObject<UserControlOrderChart>();
        }

        Order IOrderHolder.Order
        {
            get => order;
            set => order = value;
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        void SolveTask()
        {
            var mea = order.FindMeasurement(order.Date);
             MeasurementSeries[] m = null;
            var str = colorDictionary.ToStrings().ToArray();
            dictionary = order.PerformIterator(order.Iterator,
    order.Date, str, out m, () => finish);

        }

        void Start()
        {
            if (order.Iterator == null) { return; }
            toolStripButtonStart.Enabled = false;
            toolStripButtonStop.Enabled = true;
            dColor = colorDictionary.ColorDictionary;
            var task =
                new Task(
            SolveTask);
            task.GetAwaiter().OnCompleted(TaskCompleted);
            task.Start();


        }
        void TaskCompleted()
        {
            finish = false;
            var act = () =>
                {
                    toolStripButtonStart.Enabled = true;
                    toolStripButtonStop.Enabled = false;

                };
            this.InvokeIfNeeded(act);
            colorDictionary.Set(order);
            IMeasurements[] mmm = colorDictionary.GetMeasurements(order).ToArray();
            if (chart != null)
            {
                chart.Process(dictionary, mmm, colorDictionary.ColorDictionary);
            }
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            var a = () =>
            {

                finish = true;
                toolStripButtonStop.Enabled = false;
            };
            this.InvokeIfNeeded(a);

        }

        void SetMouseWheel(bool enabled)
        {
            mouseWheelEnabled = enabled;
            if (!enabled)
            {
                toolStripStatusLabel.Text = string.Empty;
            }
        }


        static object f(object o)
        {
            return o;
        }

        internal Func<object, object>[] Show = [f, f];


        bool IMouseChartIndicator.IsEnabled
        {
            get => mouseWheelEnabled;
            set => SetMouseWheel(value);

        }

        void IMouseChartIndicator.Indicate(double x, double y)
        {
     //       toolStripStatusLabel.Text = "X = " + Show[0](x) + " Y= " + Show[1](y);
            var dt  = Show[0](x).ToString();
            StringBuilder buffer = new StringBuilder(dt);
            int n = 50 - (int)buffer.Length;
            for (int i = 0; i < n; i++) 
            { 
                buffer.Append(' ');
            }

            toolStripStatusLabel.Text = "X = " + buffer + " Y= " + y;
        }
    }
}