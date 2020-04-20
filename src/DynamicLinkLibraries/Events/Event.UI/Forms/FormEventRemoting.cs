using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI.Labels;

namespace Event.UI.Forms
{
    /// <summary>
    /// Form for remoting event
    /// </summary>
    public partial class FormEventRemoting : Form, IUpdatableForm
    {

        #region Fields

        IObjectLabel label;

        #endregion

        #region Ctor

        private FormEventRemoting()
        {
            InitializeComponent();
        }

        internal FormEventRemoting(IObjectLabel label)
            : this()
        {
            this.label = label;
            (this as IUpdatableForm).UpdateFormUI();
            Event.Basic.Events.ImportedEvent ie = label.Object 
                as Event.Basic.Events.ImportedEvent;
            userControlRemotingEvent.Event = ie.Event as Event.Remote.RemoteEvent;
         }

        #endregion

        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion
    }
}
