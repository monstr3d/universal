using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;


namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Editor of properties of named series
    /// </summary>
    public partial class FormNamedSeries : Form, IUpdatableForm
    {

        #region Fields
        IObjectLabel l;
        #endregion

        private FormNamedSeries()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="l">Object label</param>
        /// <param name="nc">Edited objet</param>
        /// <param name="array">Chart properties</param>
        public FormNamedSeries(IObjectLabel l, INamedCoordinates nc, object[] array)
            : this()
        {
            this.l = l;
            userControlNamedSeriesTab.NamedCoordinates = nc;
            userControlNamedSeriesTab.Array = array;
            UpdateFormUI();
        }

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = l.Name;
        }

        #endregion

        #region Event Handlers

        private void FormNamedSeries_Load(object sender, EventArgs e)
        {
            userControlNamedSeriesTab.ShowAll();
        }

        #endregion
    }
}
