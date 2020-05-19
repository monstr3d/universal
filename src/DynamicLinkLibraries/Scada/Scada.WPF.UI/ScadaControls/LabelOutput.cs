using Scada.Interfaces;
using Scada.WPF.UI.Convertes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;



namespace Scada.WPF.UI.ScadaControls
{
    /// <summary>
    /// Output Label
    /// </summary>
    public class LabelOutput : Label,  IScadaConsumer
    {

        #region Fields

        IEvent eventObject;

        Func<object> output;

        IScadaInterface scada;

        bool isEnabled = false;

        string doubleFormat = "";

        Func<double, string> transform = (double a) => { return a + ""; };
       
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
                output = scada.GetOutput(Output);
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
        [TypeConverter(typeof(OutputRealConverter))]
        [Category("SCADA"), Description("Output name"), DisplayName("Output")]
        public string Output
        {
            get;
            set;
        }

        /// <summary>
        /// Format of double
        /// </summary>
        [Browsable(true)]
        [Category("Specific"), Description("Format of double"), DisplayName("DoubleFormat")]
        public string DoubleFormat
        {
            get
            {
                return doubleFormat;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                if (doubleFormat.Equals(value))
                {
                    return;
                }
                doubleFormat = value;
                if (doubleFormat.Length == 0)
                {
                    transform = (double a) => { return a + ""; };
                }
                else
                {
                    transform = (double a) =>
                    { return string.Format(doubleFormat, a); };
                }
            }
        }

        #endregion

        #region Private Methods

        void Set()
        {
            Dispatcher.Invoke(SetValue);
        }

        void SetValue()
        {
            Content = transform((double)output());
        }

        #endregion

    }
}
