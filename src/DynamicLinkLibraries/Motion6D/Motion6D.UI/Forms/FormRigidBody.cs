using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Motion6D.Portable.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motion6D.UI.Forms
{
    public partial class FormRigidBody : Form, IUpdatableForm
    {

        IObjectLabel label;

        RigidBody rigidBody;

        private FormRigidBody()
        {
            InitializeComponent();
        }

        public FormRigidBody(IObjectLabel label) : this()
        {
            this.label = label;
            object o = label.Object;
            if (!(o is RigidBody))
            {
                throw new Exception();
            }
            rigidBody = o as RigidBody;
            userControlRigidBody.RigidBody = rigidBody;
            UpdateFormUI();
        }

        public void UpdateFormUI()
        {
            Text = label.Name;
        }
    }
}
