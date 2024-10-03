using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

using Scada.Interfaces;

using Scada.Wpf.Common.Convertes;

namespace Scada.WPF.UI.ScadaControls
{
    /// <summary>
    /// Plus Minus Slider
    /// </summary>
    public partial class UserControlPlusMinusSlider : UserControl, IScadaConsumer, IDisposable
    {
        #region Fields

        #region Scada Related fields

        IScadaInterface scada;

        double currentValue = 0;

        Action<double> currentInput;

        Action<double> input;

        bool isEnabled;

        #endregion

        #region Specific Fields

        ToolTip toolTip = new ToolTip();

        bool showToolTip = false;

        DispatcherTimer timer = new DispatcherTimer();

        double delta;

        bool timerStarted = false;

        #endregion

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlPlusMinusSlider()
        {
            InitializeComponent();
            VerticalContentAlignment = VerticalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            HorizontalContentAlignment = HorizontalAlignment.Stretch;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            ToolTip = toolTip;
            toolTip.Placement = PlacementMode.MousePoint;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
        }

        #endregion

        #region IScadaConsumer Members

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
                if (isEnabled)
                {
                    currentInput = input;
                    Func<double?> f = scada.GetDoubleOutput(Input);
                    if (f != null)
                    {
                        var r = f();
                        if (r != null)
                        {
                            slider.Value = (double)r;
                        }
                    }
                    return;
                }
                currentInput = (double x) => { };
                if (timerStarted)
                {
                    timer.Tick -= Timer_Tick;
                    timer.Stop();
                }
            }
        }

        IScadaInterface IScadaConsumer.Scada
        {
            get
            {
                return scada;
            }

            set
            {
                scada = value;
                input = scada.GetDoubleInput(Input);
            }
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (timer.IsEnabled & timerStarted)
            {
                timer.Stop();
            }
        }

        #endregion

        #region Properties

        #region Scada Related

        /// <summary>
        /// Input
        /// </summary>
        [Browsable(true)]
        [TypeConverter(typeof(InputRealConverter))]
        [Category("SCADA"), Description("Input name"), DisplayName("Input")]
        public string Input
        {
            get;
            set;
        }

        #endregion

        #region Specific Properties

        /// <summary>
        /// Output
        /// </summary>
        [Browsable(true)]
        [Category("Specific"), Description("Button key interval"), DisplayName("Interval")]
        public TimeSpan Interval
        {
            get
            {
                return timer.Interval;
            }
            set
            {
                timer.Interval = value;
            }
        }

        /// <summary>
        /// Shows Tooltip
        /// </summary>
        [Browsable(true)]
        [Category("Specific"), Description("Tooltip"), DisplayName("Tooltip show")]
        public bool ShowToolTip
        {
            get
            {
                return showToolTip;
            }
            set
            {
                showToolTip = value;
            }
        }

        /// <summary>
        /// Mimimal value
        /// </summary>
        [Browsable(true)]
        [Category("Specific"), Description("Minimum"), DisplayName("Mimimal value")]
        public double Minimum
        {
            get
            {
                return slider.Minimum;
            }
            set
            {
                slider.Minimum = value;
            }
        }

        /// <summary>
        /// Maximal value
        /// </summary>
        [Browsable(true)]
        [Category("Specific"), Description("Maximum"), DisplayName("Maximal value")]
        public double Maximum
        {
            get
            {
                return slider.Maximum;
            }
            set
            {
                slider.Maximum = value;
            }
        }

        /// <summary>
        /// Small change
        /// </summary>
        [Browsable(true)]
        [Category("Specific"), Description("Small change"), DisplayName("Small change value")]
        public double SmallChange
        {
            get
            {
                return slider.SmallChange;
            }
            set
            {
                slider.SmallChange = value;
            }
        }

        /// <summary>
        /// Foreground of slider
        /// </summary>
        [Browsable(true)]
        [Category("Specific"), Description("Foreground of slider"), DisplayName("Foreground of slider")]
        public Brush SliderForeground
        {
            get
            {
                return slider.Foreground;
            }
            set
            {
                slider.Foreground = value;
            }
        }

        #endregion

        #endregion

        #region Event Handlers

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double v = slider.Value;
            if (v == currentValue)
            {
                return;
            }
            toolTip.IsOpen = showToolTip;
            toolTip.Content = v + "";
            currentValue = v;
            input(v);
        }

        private void ButtonMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isEnabled)
            {
                return;
            }
            object s = sender;
            if (s is TextBlock)
            {
                s = (s as TextBlock).Parent;
            }
            slider.ValueChanged -= slider_ValueChanged;
            delta = (s == Lower) ? -SmallChange : SmallChange;
            slider.Value += delta;
            toolTip.IsOpen = true;
            timer.Tick += Timer_Tick;
            timer.Start();
            timerStarted = true;
        }

        private void ButtonMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!isEnabled)
            {
                return;
            }
            timer.Stop();
            timer.Tick -= Timer_Tick;
            toolTip.IsOpen = showToolTip;
            input(slider.Value);
            slider.ValueChanged += slider_ValueChanged;
            timerStarted = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Dispatcher.Invoke(Set);
        }

        private void Set()
        {
            double v = slider.Value + delta;
            slider.Value = v;
            toolTip.Content = v + "";
        }

        #endregion

    }
}
