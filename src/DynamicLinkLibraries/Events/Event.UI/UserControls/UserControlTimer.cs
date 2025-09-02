using Diagram.UI.Interfaces;
using ErrorHandler;
using Event.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;

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
                textBox.KeyUp += TextBox_KeyUp;
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            double a;
            if (double.TryParse(textBox.Text, out a))
            {
                timer.TimeSpan =  new TimeSpan(long.Parse(textBox.Text) * 10000);

                return;
            }
            textBox.Text = timer.TimeSpan.Ticks.ToString();
        }

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

        #endregion

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
