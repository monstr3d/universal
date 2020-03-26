using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CategoryTheory;
using Diagram.UI;
using DataPerformer;
using Chart;
using Chart.Interfaces;
using ToolBox;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;
using Chart.Drawing.Interfaces;
using Chart.Objects;
using Chart.Panels;

namespace DataPerformer.UI
{
    /// <summary>
    /// Editor of propreties of collection of points
    /// </summary>
    public partial class FormPointCollection : Form, IUpdatableForm
    {
        private IObjectLabel label;
        private DrawSeries draw;
        private IPointCollecionChooser chooser;
        private ChartPerformer performer;


        private FormPointCollection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Label of component</param>
        public FormPointCollection(IObjectLabel label)
        {
            InitializeComponent();
            this.label = label;
            draw = label.Object as DrawSeries;
            Text = label.Name;
            string[] names = PointCollectionChooserFactory.Factory.Names;
            comboBoxType.FillCombo(names);
            PanelChart panel = new PanelChart(new int[,] { { 80, 20 }, { 30, 40 } });
            panel.Width = panelChart.Width - 100;
            panel.Height = panelChart.Height - 100;
            panel.Top = 50;
            panel.Left = 50;
            panel.Dock = DockStyle.Fill;
            performer = panel.Performer;
            performer.Resize();
            panelChart.Controls.Add(panel);
            SimpleCoordinator coordinator = new SimpleCoordinator(5, 5, performer);
            performer.Coordinator = coordinator;
            setChooser();
            string fn = draw.FactoryName;
            if (fn != null)
            {
                comboBoxType.SelectCombo(fn);
            }
        }


        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion


        void setChooser()
        {
            if (chooser != null)
            {
                Control c = chooser as Control;
                Control p = c.Parent;
                p.Controls.Remove(c);
            }
            IPointFactory f = draw.Factory;
            if (f == null)
            {
                return;
            }
            chooser = PointCollectionChooserFactory.Factory[f];
            chooser.Consumer = draw;
            chooser.Measurements = draw.Measurements;
            Control control = chooser as Control;
            splitContainerMain.Panel2.Controls.Add(control);
            control.LoadResources();
            if (performer.Count > 0)
            {
                performer.Remove(draw);
            }
            ISeriesPainter painter = f.GetPainter(performer);
            performer.AddSeries(draw, painter);
            performer.Resize();
            performer.RefreshAll();
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedItem == null)
            {
                return;
            }
            string s = comboBoxType.SelectedItem + "";
            if (s.Length == 0)
            {
                return;
            }
            draw.FactoryName = s;
            setChooser();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (chooser == null)
                {
                    return;
                }
                draw.Measurements = chooser.Measurements;
                performer.RefreshAll();
                Refresh();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }
    }
}