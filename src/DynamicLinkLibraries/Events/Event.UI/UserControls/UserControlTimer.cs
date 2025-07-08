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
using Diagram.UI.Interfaces;

using Event.Interfaces;
using ErrorHandler;

namespace Event.UI.UserControls
{
    /// <summary>
    /// Timer user control
    /// </summary>
    public partial class UserControlTimer : UserControl, IPreparation
    {
        #region Fields

        /// <summary>
        /// Timer
        /// </summary>
        ITimerEvent timer;

        #endregion

        #region Ctor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserControlTimer()
        {
            InitializeComponent();
        }

        #endregion

        void IPreparation.Prepare()
        {
            Set();
        }

        #region Internal Mebmers

        /// <summary>
        /// Timer
        /// </summary>

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ITimerEvent Timer
        {
            get { return timer; }
            set 
            {
                timer = value;
                if (value != null)
                {
                    textBox.Text = timer.TimeSpan.TotalMilliseconds + "";
                }
                
            }
        }
       
        #endregion

        void Set()
        {
            if (timer == null)
            {
                return;
            }
            try
            {
                timer.TimeSpan = new TimeSpan(long.Parse(textBox.Text) * 10000);
            }
            catch (Exception exception)
            {
                exception.HandleException();
            }
        }

        #region Event handlers

        /*  private void textBox_KeyUp(object sender, KeyEventArgs e)
          {
              try
              {
                  if (e.KeyData == Keys.Enter)
                  {
                      timer.TimeSpan = new TimeSpan(long.Parse(textBox.Text) * 10000);
                  }
              }
              catch (Exception exception)
              {
                  exception.HandleException();
              }
          }*/

        #endregion

    }
}
