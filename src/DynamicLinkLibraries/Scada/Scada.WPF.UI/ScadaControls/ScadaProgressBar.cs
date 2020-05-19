using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Scada.Interfaces;
using Scada.WPF.UI.Convertes;

namespace Scada.WPF.UI.ScadaControls
{
    /// <summary>
    /// Progress bar for SCADA
    /// </summary>
    public class ScadaProgressBar : ProgressBar, IScadaConsumer
    {

        #region Fields

        IEvent eventObject;

        Func<double> output;

        IScadaInterface scada;

        bool isEnabled = false;

        ToolTip toolTip = new ToolTip();

        bool showToolTip = false;

        double a;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ScadaProgressBar()
        {
            VerticalContentAlignment = VerticalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            HorizontalContentAlignment = HorizontalAlignment.Stretch;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            ToolTip = toolTip;
            toolTip.Placement = PlacementMode.MousePoint;
        }

        #endregion

        #region Public Members

        #region Scada Related

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
        [TypeConverter(typeof(OutputRealConverter))]
        [Category("SCADA"), Description("Output name"), DisplayName("Output")]
        public string Output
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
                scada = value;
                if (eventObject != null)
                {
                    if (isEnabled)
                    {
                        eventObject.Event -= Set;
                    }
                }
                eventObject = scada[Event];
                output = scada.GetDoubleOutput(Output);
                scada.AddEventOutput(Event, Output);
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
                if (value)
                {
                    toolTip.IsOpen = showToolTip;
                    eventObject.Event += Set;
                }
                else
                {
                    toolTip.IsOpen = false;
                    eventObject.Event -= Set;
                }
            }
        }

        #endregion

        #region Private Methods

        void Set()
        {
            a = output();
            Dispatcher.Invoke(SetValue);
        }

        void SetValue()
        {
            Value = a;
            if (showToolTip)
            {
                toolTip.Content = a + "";
            }
        }

        #endregion

    }
}
