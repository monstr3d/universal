using System;
using System.Windows.Forms;


using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using ErrorHandler;
using Motion6D.Portable.Aggregates;
using NamedTree;

namespace Motion6D.UI.Forms
{
    /// <summary>
    /// Rigid bogy form
    /// </summary>
    public partial class FormRigidBody : Form, IUpdatableForm
    {

        IObjectLabel label;

        RigidBody rigidBody;

        private FormRigidBody()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Label</param>
        public FormRigidBody(IObjectLabel label) : this()
        {
            this.label = label;
            object o = label.Object;

            if (o is RigidBody)
            {
                rigidBody = o as RigidBody;
            }
            else
            {
                if (o is IChildren<IAssociatedObject> co)
                {
                    rigidBody = co.GetChild<RigidBody>();
                    if (rigidBody == null)
                    {
                        throw new OwnException();
                    }
                }
            }
            UserControls.UserControlRigidBody userControlRigidBody = new UserControls.UserControlRigidBody();
            userControlRigidBody.Dock = DockStyle.Fill;
            panelCenter.Controls.Add(userControlRigidBody);
            userControlRigidBody.RigidBody = rigidBody;
            UpdateFormUI();
        }

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
        }
    }
}
