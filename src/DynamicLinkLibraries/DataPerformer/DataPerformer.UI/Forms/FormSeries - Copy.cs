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

namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Editor of properties of series
    /// </summary>
    public partial class FormSeries : Form, IUpdatableForm
    {

        #region Fields


        IObjectLabel l;

        object[] array;


        #endregion

        #region Ctor
        private FormSeries()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Consrutor
        /// </summary>
        /// <param name="l">Object label</param>
        /// <param name="array">Drawing array</param>
        public FormSeries(IObjectLabel l, object[] array)
            : this()
        {
            this.l = l;
            this.array = array;
            UpdateFormUI();
            DataPerformer.Series s = l.Object as DataPerformer.Series;
            userControlSeriesTab.Series = s;
            userControlSeriesTab.Array = array;
        }


        #endregion

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = l.Name;
        }

        #endregion

        private void FormSeries_Load(object sender, EventArgs e)
        {
            userControlSeriesTab.Array = array;
            userControlSeriesTab.ShowAll();

            userControlSeriesTab.SetFormula += (string formula) =>
                {
                    if (l is DataPerformer.UI.Labels.SeriesLabel)
                    {
                        (l as DataPerformer.UI.Labels.SeriesLabel).Formula = formula;
                    }
                };
            if (l is DataPerformer.UI.Labels.SeriesLabel)
            {
                userControlSeriesTab.Formula = (l as DataPerformer.UI.Labels.SeriesLabel).Formula;
            }

        }
    }
}
