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
using Diagram.UI.Interfaces;

using Event.UI.Labels;


namespace Event.UI.Forms
{
    public partial class FormCircular2DControl : Form, IUpdatableForm

    {
        #region Fields

        Circular2DControlLabel label;

        #endregion

        #region Ctor

        internal FormCircular2DControl(Circular2DControlLabel label)
        {
            InitializeComponent();
            this.label = label;
            userControlCircular2DControlFull.Label = label;
            (this as IUpdatableForm).UpdateFormUI();
        }

        #endregion

        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = (label as IObjectLabel).Name;
        }

        #endregion
    }
}
