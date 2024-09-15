using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scada.Interfaces;
using Scada.Wpf.Common.Convertes;

namespace Scada.WPF.UI.ScadaControls
{
    /// <summary>
    /// Adapted to SCADA numeric up down
    /// </summary>
    public class NumericUpDown : CustomControlLibrary.NumericUpDown, IScadaConsumer
    {

        #region Fields

        #region Scada Related fields

        IScadaInterface scada;

        double currentValue = 0;

        Action<double> currentInput;

        Action<double> input;

        bool isEnabled;

        #endregion


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public NumericUpDown()
        {
           
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
                        if (r.HasValue)
                        {
                            Value = (decimal)r.Value;
                        }
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

        #endregion


        #region Event Handlers

        private void NumericUpDown_ValueChanged(object sender, 
            System.Windows.RoutedPropertyChangedEventArgs<decimal> e)
        {
            input((double)e.NewValue);
        }

        #endregion
    }
}
