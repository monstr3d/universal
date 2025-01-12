using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                throw new NotImplementedException();
            }
        }

        IScadaInterface IScadaConsumer.Scada
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
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
