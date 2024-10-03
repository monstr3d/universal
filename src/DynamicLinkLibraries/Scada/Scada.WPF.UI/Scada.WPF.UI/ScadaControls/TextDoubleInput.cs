using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

using Scada.Interfaces;

using Scada.Wpf.Common.Convertes;

namespace Scada.WPF.UI.ScadaControls
{
    /// <summary>
    /// Input of textbox
    /// </summary>
    public class TextDoubleInput : TextBox, IScadaConsumer
    {

        #region Fields

        Action<float> input;

        Action<float> currentInput = (float x) => { };

        bool isEnabled;

        IScadaInterface scada;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TextDoubleInput()
        {
            KeyUp += (object sender, KeyEventArgs e) =>
            {
                if (e.Key == Key.Enter)
                {
                    float a;
                    if (float.TryParse(Text, out a))
                    {
                        currentInput(a);
                    }
                }
            };
        }


        #endregion

        #region Properties

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
                    Func<float> f = scada.GetFloatOutput(Input);
                    if (f != null)
                    {
                        Text = f() + "";
                    }
                    return;
                }
                currentInput = (float x) => { };
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
                Text = "0";
                scada = value;
                input = scada.GetFloatInput(Input);
            }
        }

        #endregion
        
    }
}
