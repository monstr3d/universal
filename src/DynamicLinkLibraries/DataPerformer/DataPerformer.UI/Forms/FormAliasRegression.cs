using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Diagram.UI.Utils;


using DataPerformer.Interfaces;
using DataPerformer.Portable;

using DataPerformer.UI.UserControls;
using ErrorHandler;

namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Editor for alias regression component
    /// </summary>
    public partial class FormAliasRegression : Form, IUpdatableForm
    {
        private IObjectLabel label;
        private Regression.AliasRegression  regression;

        private Stack<Dictionary<IAliasName, double>> stack = new Stack<Dictionary<IAliasName, double>>();

        private Stack<string> texts = new Stack<string>();
        
        private FormAliasRegression()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Label of object</param>
        public FormAliasRegression(IObjectLabel label)
            : this()
        {
            this.label = label;
            regression = label.Object as Regression.AliasRegression;
            textBoxCoefficient.Text = regression.Coefficient + "";
            UpdateFormUI();
            createAliasPanels(regression.Aliases.Count);
            fillAliasPanels();
            fillSelections();
            createMeasurementsPanel();
            measurements = regression.MeasuresNames;
            Dictionary<int, object[]> t = regression.Aliases;
            if (t != null)
            {
                numericUpDownAliases.Value = t.Count;
            }
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


        private void createAliasPanels(int count)
        {
            List<string> al = new List<string>();
            Double a = 0;
            regression.GetAllAliases(al, a);
            panelAliases.Controls.Clear();
            int y = 0;
            for (int i = 0; i < count; i++)
            {
                RegressionAliasUserControl panel = new RegressionAliasUserControl(al);
                panel.Top = y;
                panel.Left = 0;
                panel.Width = panelAliases.Width;
                y += panel.Height;
                panelAliases.Controls.Add(panel);
                Panel pan = new Panel();
                pan.Height = 3;
                pan.BackColor = Color.Black;
                pan.Top = y;
                pan.Width = panelAliases.Width;
                pan.Left = 0;
                panelAliases.Controls.Add(pan);
                y += pan.Height;
            }
        }

        private void fillAliasPanels()
        {
            int i = 0;
            panelAliases.Resize += panelAliases_Resize;
            Dictionary<int, object[]> t = regression.Aliases;
            foreach (Control c in panelAliases.Controls)
            {
                if (!(c is RegressionAliasUserControl))
                {
                    continue;
                }
                RegressionAliasUserControl p = c as RegressionAliasUserControl;
                p.Object = t[i];
                ++i;
            }
        }

        private void panelAliases_Resize(object sender, EventArgs e)
        {
            foreach (Control c in panelAliases.Controls)
            {
                if (!(c is RegressionAliasUserControl))
                {
                    continue;
                }
                RegressionAliasUserControl p = c as RegressionAliasUserControl;
                p.Width = panelAliases.Width - panelAliases.Left - 10;
            }
        }


        private Dictionary<int, object[]> aliases
        {
            get
            {
                int i = 0;
                Dictionary<int, object[]> t = new Dictionary<int, object[]>();
                foreach (Control c in panelAliases.Controls)
                {
                    if (!(c is RegressionAliasUserControl))
                    {
                        continue;
                    }
                    RegressionAliasUserControl p = c as RegressionAliasUserControl;
                    t[i] = p.Object;
                    ++i;
                }
                return t;
            }
        }

        private void createMeasurementsPanel()
        {
            int y = 0;
            Hashtable t = regression.MeasuresNames;
            IDataConsumer cons = regression as IDataConsumer;
            for (int i = 0; i < cons.Count; i++)
            {
                IMeasurements m = regression[i];
                RegessionAliasMeasureUserControl panel = new RegessionAliasMeasureUserControl(regression, m);
                panel.Table = t;
                panel.Top = y;
                panel.Left = 0;
                panel.Width = panelMeasurements.Width;
                panel.Table = t;
                panelMeasurements.Controls.Add(panel);
                y += panel.Height;
                Panel pan = new Panel();
                pan.Height = 3;
                pan.BackColor = Color.Black;
                pan.Top = y;
                pan.Width = panelMeasurements.Width;
                pan.Left = 0;
                panelMeasurements.Controls.Add(pan);
                y += pan.Height;
            }
        }

        private Hashtable measurements
        {
            get
            {
                Hashtable table = new Hashtable();
                foreach (Control c in panelMeasurements.Controls)
                {
                    if (!(c is RegessionAliasMeasureUserControl))
                    {
                        continue;
                    }
                    RegessionAliasMeasureUserControl p = c as RegessionAliasMeasureUserControl;
                    Hashtable t = p.Table;
                    foreach (int i in t.Keys)
                    {
                        table[i] = t[i];
                    }
                }
                return table;
            }
            set
            {
                foreach (Control c in panelMeasurements.Controls)
                {
                    if (!(c is RegessionAliasMeasureUserControl))
                    {
                        continue;
                    }
                    RegessionAliasMeasureUserControl p = c as RegessionAliasMeasureUserControl;
                    p.Table = value;
                }
            }
        }

        private void fillSelections()
        {
            List<IStructuredSelectionCollection> sel = regression.Selections;
            Hashtable t = regression.SelectionsNames;
            int y = 0;
            foreach (IStructuredSelectionCollection s in sel)
            {
                RegressionSelectionUserControl panel = new RegressionSelectionUserControl(regression, s);
                panel.Width = panelSelections.Width;
                panel.Left = 0;
                panel.Top = y;
                panelSelections.Controls.Add(panel);
                panel.Table = t;
                y += panel.Height;
                Panel pan = new Panel();
                pan.Height = 3;
                pan.BackColor = Color.Black;
                pan.Top = y;
                pan.Width = panelSelections.Width;
                pan.Left = 0;
                panelSelections.Controls.Add(pan);
                y += pan.Height;
            }
        }

        private void Back()
        {
            Dictionary<IAliasName, double> d = stack.Pop();
            foreach (IAliasName an in d.Keys)
            {
                an.Value = d[an];
            }
            if (texts.Count > 0)
            {
                string s = texts.Pop();
                labelSigma0.Text = s;
            }
        }

        private Hashtable selections
        {
            get
            {
                Hashtable t = new Hashtable();
                foreach (Control c in panelSelections.Controls)
                {
                    if (!(c is RegressionSelectionUserControl))
                    {
                        continue;
                    }
                    RegressionSelectionUserControl p = c as RegressionSelectionUserControl;
                    p.Fill(t);
                }
                return t;
            }
        }

        private void buttonAcceptAliasesNumber_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDownAliases.Value;
            createAliasPanels(n);
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                regression.Aliases = aliases;
                regression.MeasuresNames = measurements;
                regression.SelectionsNames = selections;
                regression.Coefficient = double.Parse(textBoxCoefficient.Text);
                regression.Init();
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }

        }

        private void buttonIterate_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<IAliasName, double> dict = regression.Backup;
                texts.Push(labelSigma0.Text);
                stack.Push(dict);
                buttonBack.Enabled = true;
                regression.FullIterate();
            }
            catch (Exception exc)
            {
                exc.HandleException();
                return;
            }
            try
            {
                labelSigma0.Text = Math.Sqrt(regression.SquareResidual / regression.DataDimension) + "";
                IDesktop r = label.Root.Desktop;
                if (r is PanelDesktop)
                {
                    PanelDesktop d = r as PanelDesktop;
                    foreach (Control c in d.Controls)
                    {
                        update(c);
                    }
                    d.Refresh();
                }
            }
            catch (Exception ex)
            {
                ex.HandleException(1);
            }
        }

        void update(Control control)
        {
            IUpdatableSelection upd = control.GetSimpleObject<IUpdatableSelection>();
            if (upd != null)
            {
                upd.UpdateSelection();
            }
            foreach (Control c in control.Controls)
            {
                update(c);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Back();
            if (stack.Count == 0)
            {
                buttonBack.Enabled = false;
            }
        }

    }
}