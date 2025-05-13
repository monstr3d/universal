using System.ComponentModel;
using System.Windows.Controls;

using Scada.Interfaces;
using Scada.Wpf.Common.Convertes;

namespace Scada.WPF.UI.ScadaControls
{
    class ScadaCheckBox : CheckBox, IScadaConsumer
    {

        #region Fields

        bool isEnabled;

        IScadaInterface scada;

        bool ignore = false;

        Action<bool> input;

        #endregion

        #region Ctor

        public ScadaCheckBox()
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


        #endregion

        #region IScadaConsumer members
        bool IScadaConsumer.IsEnabled
        {
            get
            {
                return isEnabled;
            }

            set
            {
              throw  new  ErrorHandler.WriteProhibitedException();
            }
        }

        IScadaInterface IScadaConsumer.Scada
        {
            get
            {
              throw new  ErrorHandler.WriteProhibitedException();
            }

            set
            {
              throw new  ErrorHandler.WriteProhibitedException();
            }
        }

        #endregion

        #region Scada properties

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
    }
}
