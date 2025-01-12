using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using Scada.Interfaces;
using System.ComponentModel;

namespace Scada.CircularGauge
{
    [TemplatePart(Name = "LayoutRoot", Type = typeof(Grid))]
    [TemplatePart(Name = "Pointer", Type = typeof(Path))]
    [TemplatePart(Name = "RangeIndicatorLight", Type = typeof(Ellipse))]
    [TemplatePart(Name = "PointerCap", Type = typeof(Ellipse))]
    public class CircularGaugeControl :
        global::CircularGauge.CircularGaugeControl, IScadaConsumer
    {
        #region Fields

        #region Scada Input Fields

        Func<double?> output;

        IScadaInterface scada;

        IEvent eventObject;

        bool isEnabled;

        #endregion

        #endregion

        #region Ctor


        public CircularGaugeControl()
        {
            Unloaded += (object sender, RoutedEventArgs e) =>
            { (this as IScadaConsumer).IsEnabled = false; };
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

        #endregion

        #region Private Methods

        void Set()
        {
            var r = output();
            if (r.HasValue)
            {
                base.CurrentValue = (double)r;
            }
        }

        #endregion



    }
}
