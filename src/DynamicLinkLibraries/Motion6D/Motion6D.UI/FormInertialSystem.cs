using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Diagram.UI;
using Motion6D;
using PhysicalField;
using CategoryTheory;
using BaseTypes;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

namespace Motion6D.UI
{
    /// <summary>
    /// Editor of properties of inertial navigational system
    /// </summary>
    public partial class FormInertialSystem : Form, IUpdatableForm
    {
        private IObjectLabel label;

        private InertialSensorData data;

        private FormInertialSystem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Object label</param>
        /// <param name="data">Inertial sensor</param>
        public FormInertialSystem(IObjectLabel label, InertialSensorData data)
            : this()
        {
            this.label = label;
            this.data = data;
            UpdateFormUI();
            post();
        }

        private void post()
        {
            userControlRelativeField.Set(data, data.Field);
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            userControlRelativeField.Accept();
            IPostSetArrow p = data;
            p.PostSetArrow();
        }


        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion
    }
}