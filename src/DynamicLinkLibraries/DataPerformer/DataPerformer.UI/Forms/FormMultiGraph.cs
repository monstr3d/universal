using DataPerformer.UI.UserControls;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPerformer.UI.Forms
{
    public partial class FormMultiGraph : Form, IUpdatableForm, IStartStop
    {

        #region Fields

        Labels.GraphLabel label;

        IObjectLabel l;


        #endregion

        private FormMultiGraph()
        {
            InitializeComponent();
            generateCodeToolStripMenuItem.Visible = StaticExtensionDataPerformerUI.HasDataConsumerCodeGenerator;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lab">Parent graph label</param>
        public FormMultiGraph(Labels.GraphLabel lab)
            : this()
        {
            this.label = lab;
            l = lab;
            UpdateFormUI();
        }


        #region

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = l.RootName;
        }

        private void FormMultiGraph_Load(object sender, EventArgs e)
        {
            userControlMultiGraph.Label = label;
        }

        #endregion

        #region IStartStop Members

        void IStartStop.Action(object type, ActionType actionType)
        {
            IStartStop ss = label;
            ss.Action(type, actionType);
        }

        #endregion

    }
}
