using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Chart.Classes;
using Chart.Interfaces;
using ErrorHandler;

namespace Chart.UserControls
{
    /// <summary>
    /// External chart contriol
    /// </summary>
    public partial class UserControlExternalChart : UserControl
    {
        #region Fields

        private ChartPerformer performer;


        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlExternalChart()
        {
            InitializeComponent();
        }

        #endregion


        #region Members

        /// <summary>
        /// Preparation
        /// </summary>
        /// <param name="insets">Insets</param>
        /// <param name="hasStandardHandlers">The has standard handlers sign</param>
        public void Prepare(int[,] insets, bool hasStandardHandlers)
        {
            if (performer != null)
            {
                throw new   OwnException("Double initialization");
            }
            performer = new ChartPerformer(userControlControlInternalChart, insets, hasStandardHandlers);
            userControlControlInternalChart.Performer = performer;
            userControlControlInternalChart.Parent = this;
            if (DataTextChooser.Localize != null)
            {
                DataTextChooser.Localize(this);
            }
        }

        /// <summary>
        /// Performer
        /// </summary>
        public ChartPerformer Performer
        {
            get
            {
                return performer;
            }
        }

        /// <summary>
        /// Creator of properties editor
        /// </summary>
        public IChartProperiesFormCreator FormCreator
        {
            get
            {
                return userControlControlInternalChart.FormCreator;
            }
            set
            {
                userControlControlInternalChart.FormCreator = value;
            }
        }

        #endregion

    }
}
