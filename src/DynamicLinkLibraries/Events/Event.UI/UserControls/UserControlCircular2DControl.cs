using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Event.Basic.Data.Events;

namespace Event.UI.UserControls
{
    /// <summary>
    /// Circular control
    /// </summary>
    public partial class UserControlCircular2DControl : UserControl
    {

        #region Fields

        ForcedEventData forced;

        object[] data;

        double x1;

        double y1;

        double x2;

        double y2;

        #endregion


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlCircular2DControl()
        {
            InitializeComponent();
            labelX.Text = "";
            labelY.Text = "";
        }

        #endregion

        #region Internal Members

        internal void Set(ForcedEventData forced, double x1, double y1, double x2, double y2)
        {
            this.forced = forced;
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            object[] o = forced.Initial;
            control.MouseEvent += control_MouseEvent;
            data = forced.Data;
        }

   
        #endregion

        #region Event Handlers

        void control_MouseEvent(double arg1, double arg2)
        {
            data[0] = x1 + arg1 * (x2 - x1);
            data[1] = y1 + arg2 * (y2 - y1);
            forced.Data = data;
            labelX.Text = "X = " + data[0];
            labelY.Text = "Y = " + data[1];
        }


        #endregion

    }
}

