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

using Web.Interfaces;

// !!!REMOVEDusing Event.Remote;

namespace Event.UI.UserControls
{
    /// <summary>
    /// User control for remote object
    /// </summary>
    public partial class UserControlRemoteObject : UserControl
    {
        #region Fields

        //    !!!REMOVED   Tuple<Action<Remote.RemoteType>, Remote.RemoteType, IUrlConsumer, IUrlProvider> tuple;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlRemoteObject()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Members
   /*     !!!REMOVED
        internal Tuple<Action<Remote.RemoteType>, RemoteType, IUrlConsumer, IUrlProvider> Tuple
        {
            get
            {
                return tuple;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                tuple = value;
                RemoteType type = tuple.Item2;
                comboBoxType.SelectedIndex =
                    StaticExtensionEventRemote.Types.IndexOf(type);
                comboBoxType.SelectedIndexChanged += comboBoxType_SelectedIndexChanged;
                textBoxUrl.Text = tuple.Item4.Url;
                textBoxUrl.KeyUp += textBoxUrl_KeyUp;
            }
        }
   */

        internal void ShowError(Exception exception)
        {
            if (exception == null)
            {
                labelResult.Text = "Success";
            }
            else
            {
                labelResult.Text = exception.Message;
                exception.ShowError();
            }
        }

        #endregion

        #region Event handlers

        void textBoxUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            try
            {
          //      !!!REMOVED           tuple.Item3.Url = textBoxUrl.Text;
              ShowError(null);
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* !!!REMOVED
            try
            {
                RemoteType type = StaticExtensionEventRemote.Types[comboBoxType.SelectedIndex];
                tuple.Item1(type);
                ShowError(null);
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
            */
        }

        #endregion
    }
}
