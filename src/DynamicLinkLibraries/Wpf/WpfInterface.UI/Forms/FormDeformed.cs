using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using Motion6D.Interfaces;
using NamedTree;


namespace WpfInterface.UI.Forms
{
    public partial class FormDeformed : Form, IUpdatableForm
    {
        #region Fields

        IObjectLabel label;


        #endregion


        private FormDeformed()
        {
            InitializeComponent();
        }


        public FormDeformed(IPosition p, IVisible v)
            : this()
        {
            userControlDeformed.Set(p, v);
            IAssociatedObject ao = p as IAssociatedObject;
            label = ao.Object as IObjectLabel;

            UpdateFormUI();
        }

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            if (label != null)
            {
                Text = label.Name;
            }
        }

        #endregion
    }

}
