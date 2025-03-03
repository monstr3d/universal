using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;
using ErrorHandler;

namespace Motion6D.UI.UserControls
{
    /// <summary>
    /// User control for Linear 6D forecast
    /// </summary>
    public partial class UserControlLinerar6DForecast : UserControl
    {
        #region Fields

        Motion6D.Interfaces.ILinear6DForecast forecast;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlLinerar6DForecast()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Forecast object
        /// </summary>
        public Motion6D.Interfaces.ILinear6DForecast Forecast
        {
            get
            {
                return forecast;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                forecast = value;
                textBoxCoordinate.Text = forecast.CoordinateError + "";
                textBoxAngle.Text = (forecast.AngleError * 180 / Math.PI) + "";
                textBoxForecastTime.Text = forecast.ForecastTime.TotalSeconds + "";
            }
        }

        #endregion

        #region Event Handlers

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                forecast.CoordinateError = Double.Parse(textBoxCoordinate.Text);
                forecast.AngleError = Double.Parse(textBoxAngle.Text) * Math.PI / 180;
                forecast.ForecastTime = TimeSpan.FromSeconds(Double.Parse(textBoxForecastTime.Text));
            }
            catch (Exception exception)
            {
                exception.HandleException();
            }
        }

        #endregion
    }
}
