using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using DataPerformer.Helpers;

namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Editor of Kalman Filter
    /// </summary>
    public partial class FormKalmanFilter : Form, IUpdatableForm
    {

        #region Fields

        IObjectLabel label;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public FormKalmanFilter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Label</param>
        public FormKalmanFilter(IObjectLabel label)
            : this()
        {
            this.label = label;
            UpdateFormUI();
            userControlKalmanFilter.Filter = label.Object as KalmanFilter;
        }

        #endregion

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