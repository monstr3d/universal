using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scada.WPF.UI.UserControls
{
    /// <summary>
    /// Start stop user control
    /// </summary>
    public partial class UserControlStartStop : UserControl
    {
        #region Fields

        event Action start = () => { };

        event Action stop = () => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Defaul constructor
        /// </summary>
        public UserControlStartStop()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        #region Properties

        /// <summary>
        /// Foreground of buttons
        /// </summary>
        public Brush ButtonForeground
        {
            get
            {
                return buttonStart.Foreground;
            }
            set
            {
                buttonStart.Foreground = value;
                buttonStop.Foreground = value;
            }
        }

        /// <summary>
        /// Size of font
        /// </summary>
        public double ButtonFontSize
        {
            get
            {
                return buttonStart.FontSize;
            }
            set
            {
                buttonStart.FontSize = value;
                buttonStop.FontSize = value;

            }
        }

        #endregion

        /// <summary>
        /// Start
        /// </summary>
        public event Action Start
        {
            add { start += value; }
            remove { start -= value; }
        }

        /// <summary>
        /// Stop
        /// </summary>
        public event Action Stop
        {
            add { stop += value; }
            remove { stop -= value; }
        }

        #endregion

        #region Event Handlers

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            start();
            buttonStart.IsEnabled = false;
            buttonStop.IsEnabled = true;
        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            stop();
            buttonStart.IsEnabled = true;
            buttonStop.IsEnabled = false;
        }

        #endregion
    }
}
