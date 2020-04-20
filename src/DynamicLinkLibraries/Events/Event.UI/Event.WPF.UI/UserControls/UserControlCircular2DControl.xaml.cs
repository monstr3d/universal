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

namespace Event.WPF.UI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlCircular2DControl.xaml
    /// </summary>
    public partial class UserControlCircular2DControl : UserControl
    {

        #region Fields

        Action<double, double> mouseEvent = (double x, double y) => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlCircular2DControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public void Set(double x, double y)
        {
            double xx = x * ActualWidth;
            double yy = y * ActualHeight;
            control.Margin = new Thickness(xx - 5, yy - 5, xx + 5, yy + 5);
        }

        /// <summary>
        /// Mouse event
        /// </summary>
        public event Action<double, double> MouseEvent
        {
            add { mouseEvent += value; }
            remove { mouseEvent -= value; }
        }

        #endregion

        #region Event Handlers

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Go(e.GetPosition(Base));
            }
        }

        private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Go(e.GetPosition(Base));
            }
        }

        private void Go(Point p)
        {
            double x = p.X;
            double y = p.Y;
            control.Margin = new Thickness(x - 5, y - 5, ActualWidth - x - 5, ActualHeight - y - 5);
            mouseEvent(x / ActualWidth, y / ActualHeight);
        }

        #endregion
    }
}
