using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;
using Scada.Interfaces;
using System.ComponentModel;
using Scada.WPF.UI.Convertes;
using System.Windows.Input;

namespace Scada.WPF.UI.ScadaControls
{
    /// <summary>
    /// Slider for scada
    /// </summary>
    public class ScadaSlider : Slider, IScadaConsumer
    {

        #region Fields

        IScadaInterface scada;

        ToolTip toolTip = new ToolTip();

        double currentValue = 0;

        Action<double> currentInput;

        Action<double> input;

        bool isEnabled;

        bool showToolTip = false;


        bool change = true;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ScadaSlider()
        {
            VerticalContentAlignment = VerticalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            HorizontalContentAlignment = HorizontalAlignment.Stretch;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            ValueChanged += ScadaSlider_ValueChanged;
            ToolTip = toolTip;
            toolTip.Placement = PlacementMode.MousePoint;
        }

        #endregion

        #region Properties

        #region Scada Related

        /// <summary>
        /// Output
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
        /// Shows Tooltip
        /// </summary>
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

        #endregion

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
                    Func<double> f = scada.GetDoubleOutput(Input);
                    if (f != null)
                    {
                        change = false;
                        Value = f();
                        change = true;
                    }
                    return;
                }
                currentInput = (double x) => { };
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

        #region Event Handlers

        private void ScadaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!change)
            {
                return;
            }
            if (e.NewValue == e.OldValue)
            {
                return;
            }
            toolTip.IsOpen = showToolTip;
            toolTip.Content = Value + "";
            double v = Value;
            if (v == currentValue)
            {
                return;
            }
            currentValue = v;
            input(v);
        }

        #endregion

    }
}
