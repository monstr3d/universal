using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


using Chart.Interfaces;

namespace Chart.UserControls
{
    /// <summary>
    /// Internal user control
    /// </summary>
    internal partial class UserControlControlInternalChart : UserControl
    {

        #region Fields

        private ChartPerformer performer;

        private UserControlExternalChart parent;

        private IChartProperiesFormCreator formCreator;

        private Form propertiesForm;

        #endregion

        #region Ctor

        internal UserControlControlInternalChart()
        {
            InitializeComponent();
        }

        #endregion


        #region Members

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ChartPerformer Performer
        {
            get
            {
                return performer;
            }
            set
            {
                performer = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        new internal UserControlExternalChart Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal IChartProperiesFormCreator FormCreator
        {
            get
            {
                return formCreator;
            }
            set
            {
                formCreator = value;
            }
        }

        #endregion

        private void contextMenuStripChart_Opening(object sender, CancelEventArgs e)
        {
            if (formCreator == null)
            {
                propertiesToolStripMenuItem.Visible = false;
                return;
            }
            if (propertiesForm != null)
            {
                if (propertiesForm.IsDisposed)
                {
                    propertiesForm = null;
                }
            }
            propertiesToolStripMenuItem.Visible = propertiesForm == null;

        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formCreator == null)
            {
                return;
            }
            propertiesForm = formCreator.Create();
            propertiesForm.Show();
        }
    }
}
