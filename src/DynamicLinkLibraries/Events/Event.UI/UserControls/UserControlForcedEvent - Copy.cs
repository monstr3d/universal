using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Event.Basic.Events;

namespace Event.UI.UserControls
{
    /// <summary>
    /// User control for forced event
    /// </summary>
    public partial class UserControlForcedEvent : UserControl
    {

        #region Fields

        ForcedEvent forced;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlForcedEvent()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Members

        internal ForcedEvent Event
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                forced = value;
            }
        }

        #endregion

        #region Event Handlers

        private void buttonForce_Click(object sender, EventArgs e)
        {
            forced.Force();
        }

        #endregion

    }
}
