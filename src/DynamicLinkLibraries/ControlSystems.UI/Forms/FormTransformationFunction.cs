using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Diagram.UI.Labels;
using Diagram.UI;
using ControlSystemsWrapper;
using Diagram.UI.Interfaces;
using ControlSystems.UI.Interfaces;

namespace ControlSystems.UI.Forms
{
    public partial class FormTransformationFunction : Form, IUpdatableForm
    {

        #region Fields

        IObjectLabel label;

        RationalTransformControlSystemFunctionWrapper transform;

        #endregion


        private FormTransformationFunction()
        {
            InitializeComponent();
            ResourceService.Resources.LoadControlResources(this, ControlSystems.UI.Utils.ControlUtilites.Resources);
        }

        public FormTransformationFunction(IObjectLabel label)
            : this()
        {
            this.label = label;
            UpdateFormUI();
            transform = label.Object as RationalTransformControlSystemFunctionWrapper;
        }

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            string s =
                ResourceService.Resources.GetControlResource(RationalTransformControlSystemFunctionWrapper.NAME,
                ControlSystems.UI.Utils.ControlUtilites.Resources);
            string sn = label.Name;
            if (sn.Length == 0)
            {
                Text = s;
                return;
            }
            Text = sn + " [" + s + "]";
        }

        #endregion


        #region Members

        /// <summary>
        /// Select event
        /// </summary>
        public event ControlSystems.UI.UserControls.SelectMeasure SelectMeasure
        {
            add
            {
                userControlTransformFunctionFilter.SelectMeasure += value;
            }
            remove
            {
                userControlTransformFunctionFilter.SelectMeasure -= value;
            }
        }

        /// <summary>
        /// Measurements
        /// </summary>
        public ICollection<string> Measurements
        {
            set
            {
                userControlTransformFunctionFilter.Measurements = value;
            }
        }

        /// <summary>
        /// Sets selected item
        /// </summary>
        public string SelectedItem
        {
            set
            {
                userControlTransformFunctionFilter.SelectedItem = value;
            }
        }


        /// <summary>
        /// Shows compobox
        /// </summary>
        /// <returns>Elargement of window</returns>
        public int ShowComboBox()
        {
            int w = userControlTransformFunctionFilter.ShowComboBox();
            Height = Height + w;
            return w;
        }
        /// <summary>
        /// Feedback
        /// </summary>
        public IFeedback Feedback
        {
            set
            {
                userControlTransformFunctionFilter.Feedback = value;
            }
        }



        #endregion


        #region Event Handlers

        private void FormTransformationFunctionFilter_Load(object sender, EventArgs e)
        {
            userControlTransformFunctionFilter.Prepare();
            userControlTransformFunctionFilter.Transform = transform;
        }

        #endregion
    }
}