
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

using Scada.Interfaces;

using Scada.Wpf.Common.Convertes;

namespace Scada.WPF.UI.ScadaControls
{
    /// <summary>
    /// Toggle button for SCADA
    /// </summary>
    public class ScadaToggleButton : ToggleButton, IScadaConsumer
    {

        #region Fields

        Action<bool> input;

        Action<bool> currentInput = (bool x) => { };

        bool isEnabled;

        IScadaInterface scada;

        bool ignore = false;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public ScadaToggleButton()
        {
            Checked += (object sender, System.Windows.RoutedEventArgs e) =>
            {
                if (ignore)
                {
                    return;
                }
                input(true);
            };
            {
                Unchecked += (object sender, System.Windows.RoutedEventArgs e) =>
                {
                    if (ignore)
                    {
                        return;
                    }
                    input(false);
                };

            }
        }

   

        #region Properties

        /// <summary>
        /// Output
        /// </summary>
        [Browsable(true)]
        [TypeConverter(typeof(OutputBooleanConverter))]
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
                    Func<object> f = scada.GetOutput(Input);
                    if (f != null)
                    {
                        ignore = true;
                        IsChecked = (bool) f();
                        ignore = false;
                    }
                    return;
                }
                currentInput = (bool x) => { };
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
                Action<object> act = scada.GetInput(Input);
                input = (bool b) =>
                {
                    act(b);
                };
            }
        }

        #endregion

    }
}
