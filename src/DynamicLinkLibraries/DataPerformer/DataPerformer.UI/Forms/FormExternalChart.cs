using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Labels;
using Diagram.UI;
using DataPerformer;
using Chart;
using ToolBox;
using DataPerformer.UI.Labels;
using Diagram.UI.Interfaces;
using Chart.Drawing.Interfaces;

namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// External chart form
    /// </summary>
    public partial class FormExternalChart : Form, IUpdatableForm
    {
        #region Fields

        private IObjectLabel label;

        private DataConsumer consumer;

        private ICoordPainter coordinator;

        private ChartPerformer performer;

        private GraphLabel lab;

        #endregion

        #region Ctor

        private FormExternalChart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="label">Object label</param>
        /// <param name="lab">Graph label</param>
        public FormExternalChart(IObjectLabel label, GraphLabel lab)
            : this()
        {
            this.label = label;
            this.lab = lab;
            UpdateFormUI();
            consumer = label.Object as DataConsumer;
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

        void init()
        {

            Chart.UserControls.UserControlExternalChart chart = userControlExternalChart;

            chart.Prepare(new int[,] { { 80, 30 }, { 10, 40 } }, true);
            chart.Cursor = Cursors.Cross;
            /*panel.Width = panelGraph.Width - 100;
            panel.Height = panelGraph.Height - 100;
            panel.Left = 50;
            panel.Top = 50;
            */
            performer = chart.Performer;
            /*
            performer.InternalInsets[0, 0] = 20;
            performer.InternalInsets[1, 0] = 20;
            performer.InternalInsets[0, 1] = 20;
            performer.InternalInsets[1, 1] = 20;
            */
            //panelGraph.Controls.Add(chart);
            chart.Dock = DockStyle.Fill;
            performer.Resize();
            coordinator = new LogarithmCoordinator(performer);
            performer.Coordinator = coordinator;
            //EditorReceiver.AddEditorDrag(panelGraph);
            //PictureReceiver.AddImageDrag(panelGraph);
            /*ArrayList graphControls = consumer.GraphControls;
            ControlPanel.LoadControls(panelGraph, graphControls);
            textBoxStart.Text = consumer.Start + "";
            textBoxStep.Text = consumer.Step + "";
            textBoxStepCount.Text = consumer.Steps + "";*/
            /*pic.Text = ResourceService.Resources.GetControlResource("Color");
            pic.Width = 50;*/
            /*DataPerformer.UI.Performers.SeriesPerformer.FillTypeCombo(toolStripButtonType);
            if (argument.Equals("Time"))
            {
                checkBoxTime.Checked = true;
            }*/
        }


        private void userControlExternalChart_Load(object sender, EventArgs e)
        {
            init();
        }
    }
}