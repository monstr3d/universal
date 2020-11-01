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

using Event.Remote;

namespace Event.UI.UserControls
{
    /// <summary>
    /// User control for remoting event
    /// </summary>
    public partial class UserControlRemotingEvent : UserControl
    {

        #region Fields

        /// <summary>
        /// Event
        /// </summary>
        private Event.Remote.RemoteEvent ev;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlRemotingEvent()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Members


        internal Event.Remote.RemoteEvent Event
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                ev = value;
                Web.Interfaces.IUrlProvider p = ev;
                string url = p.Url;
                if (url != null)
                {
                    textBoxUrl.Text = url;
                }
                RemoteType type = ev.Type;
                comboBoxType.SelectedIndex =
                    StaticExtensionEventRemote.Types.IndexOf(type);
                comboBoxType.SelectedIndexChanged += comboBoxType_SelectedIndexChanged;

            }
        }

        #endregion

        #region Event handlers

        private void textBoxUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            try
            {
                Web.Interfaces.IUrlConsumer c = ev;
                c.Url = textBoxUrl.Text;
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RemoteType type = StaticExtensionEventRemote.Types[comboBoxType.SelectedIndex];
                ev.Type = type;
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }

        #endregion
    }
}
