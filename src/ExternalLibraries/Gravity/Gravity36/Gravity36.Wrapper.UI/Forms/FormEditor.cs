using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

namespace Gravity36.Wrapper.UI.Forms
{
    internal partial class FormEditor : Form, IUpdatableForm
    {
        #region Fields
        private IObjectLabel label;

        private Gravity grav;

        #endregion

        #region Ctor

        private FormEditor()
        {
            InitializeComponent();
        }

        internal FormEditor(Gravity grav)
            : this()
        {
            this.grav = grav;
            userControlEdit.Gravity = grav;
            Text = "";
            IUpdatableForm f = this;
            f.UpdateFormUI();
        }

        #endregion

        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            CategoryTheory.IAssociatedObject ao = grav as CategoryTheory.IAssociatedObject;
            object o = ao.Object;
            if (o == null)
            {
                return;
            }
            IObjectLabel l = o as IObjectLabel;
            Text = l.Name;
        }

        #endregion

    }
}

