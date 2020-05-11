using CategoryTheory;
using Diagram.UI;
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
                if (o is IChildrenObject)
                {
                    IChildrenObject co = o as IChildrenObject;
                    rigidBody = co.GetChild<RigidBody>();
                    if (rigidBody == null)
                    {
                        throw new Exception();
                    }
                }
            }
            userControlRigidBody.RigidBody = rigidBody;
            UpdateFormUI();
        }

        public void UpdateFormUI()
        {
            Text = label.Name;
        }
    }
}
