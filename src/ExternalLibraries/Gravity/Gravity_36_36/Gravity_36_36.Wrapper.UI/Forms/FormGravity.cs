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
using Gravity_36_36.Wrapper.UI.Labels;
using NamedTree;

namespace Gravity_36_36.Wrapper.UI.Forms
{
    /// <summary>
    /// Form for gravity
    /// </summary>
    public partial class FormGravity : Form, IUpdatableForm
    {

        Serializable.Gravity gravity;

        /// <summary>
        /// Default constructor
        /// </summary>
        public FormGravity()
        {
            InitializeComponent();
        }

        internal FormGravity(Serializable.Gravity gravity) : 
            this()
        {
            this.gravity = gravity;
            userControlGravity.Gravity = gravity;
            UpdateFormUI();
        }

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            IAssociatedObject ao = gravity as IAssociatedObject;
            object o = ao.Object;
            if (o == null)
            {
                return;
            }
            IObjectLabel l = o as IObjectLabel;
            Text = l.Name;
        }

    }
}
