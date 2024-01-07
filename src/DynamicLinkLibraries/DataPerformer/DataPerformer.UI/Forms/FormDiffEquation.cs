using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;


using FormulaEditor;


using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;


namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Editor of properties of ordinary differential equation system
    /// </summary>
    public partial class FormDiffEquation : Form, IUpdatableForm, ISaveComments

    {
        /// <summary>
        /// Vraiables letters
        /// </summary>
        public const string Variables = "abcdfghijklmnoqrstuvwxyz";
        private Hashtable aliasCombo = new Hashtable();

        private DifferentialEquationSolver solver;
     
        private IObjectLabel label;

        private bool first = true;

        private FormDiffEquation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label"></param>
        public FormDiffEquation(IObjectLabel label)
            : this()
        {
            PanelFormula.SetResize(panelFormula);
            this.label = label;
            solver = label.Object as DifferentialEquationSolver;
            // ArrayList comments = solver.Comments;
            this.SetComments(solver.Comments);
            numericUpDownDerivationOrder.Value = solver.DerivationOrder;
            first = false;
            string var = "";
            List<string> vv = new List<string>();
            foreach (char c in solver.Keys)
            {
                var += c;
                vv.Add(c + "");
            }
            for (int i = 0; i < Variables.Length; i++)
            {
                char v = Variables[i];
                if (var.IndexOf(v) > -1)
                {
                    checkedListBoxV.Items.Add("" + v, CheckState.Checked);
                }
                else
                {
                    checkedListBoxV.Items.Add("" + v, CheckState.Unchecked);
                }
            }
            userControlCharIntDictionary.Minimum = 1;
            userControlCharIntDictionary.Keys = vv;
            Dictionary<string, int> dder = new Dictionary<string,int>();
            Dictionary<string, int> dor = solver.DerivationOrders;
            foreach (string key in dor.Keys)
            {
                dder[key] = dor[key] + 1;
            }
            userControlCharIntDictionary.Dictionary = dder;
            string str = solver.AllParameters;
            IList<string> l = solver.AliasNames;
            foreach (char c in str)
            {
                string s = c + "";
                if (l.Contains(s))
                {
                    checkedListBoxP.Items.Add(s, CheckState.Checked);
                }
                else
                {
                    checkedListBoxP.Items.Add(s, CheckState.Unchecked);
                }
            }
            int top = 0;
            foreach (char c in solver.Keys)
            {
                PanelFormula p = new PanelFormula("" + c, this, panelFormula.Width, 200, Variables, true, null, null);
                p.Left = 0;
                p.Top = top;
                top += p.Height;
                p.Formula = solver[c];
                panelFormula.Controls.Add(p);

            }
            UpdateFormUI();
            setFormulas();
            fillTable();
            createAndFillAliasComboBox();

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

        private void setFormulas()
        {
            int y = 20;
            string variables = "";
            for (int i = 0; i < solver.Count; i++)
            {
                IMeasurements arrow = solver[i];
                PanelMeasureFormula panel = new PanelMeasureFormula(arrow, variables, solver);
                panel.Width = 300;
                Panel pan = new Panel();
                pan.Width = panel.Width;
                pan.BackColor = Color.Black;
                pan.Top = y;
                pan.Height = 2;
                panelMea.Controls.Add(pan);
                y += pan.Height;
                panelMea.Controls.Add(panel);
                panel.Left = 0;
                panel.Top = y;
                y += panel.Height + 1;
            }
            foreach (string str in solver.Arguments)
            {
                comboBoxTime.Items.Add(str[0] + "");
                variables += str[0];
            }
            foreach (string str in solver.Arguments)
            {
                string s = str;
                int n = str.Length;
                if (s.Substring(n - 4, 4).Equals("Time"))
                {
                    for (int i = 0; i < variables.Length; i++)
                    {
                        if (variables[i] == str[0])
                        {
                            this.comboBoxTime.SelectedIndex = i;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// List of arguments
        /// </summary>
        public List<string> Arguments
        {
            get
            {
                List<string> list = new List<string>();
                foreach (Control c in panelMea.Controls)
                {
                    if (!(c is PanelMeasureFormula))
                    {
                        continue;
                    }
                    PanelMeasureFormula p = c as PanelMeasureFormula;
                    p.AddArgumentLabels(list);
                }
                object ob = comboBoxTime.SelectedItem;
                if (ob != null)
                {
                    string sn = comboBoxTime.SelectedItem.ToString();
                    if (sn.Length != 0)
                    {
                        list.Add(sn + " = Time");
                    }
                }
                return list;
            }
        }

        private Formula.DynamicalParameter Parameter
        {
            get
            {
                Formula.DynamicalParameter par = new Formula.DynamicalParameter();
                foreach (Control c in panelMea.Controls)
                {
                    if (!(c is PanelMeasureFormula))
                    {
                        continue;
                    }
                    PanelMeasureFormula p = c as PanelMeasureFormula;
                    p.CreateArguments(par);
                }
                object ob = comboBoxTime.SelectedItem;
                if (ob != null)
                {
                    string sn = ob.ToString();
                    if (sn.Length != 0)
                    {
                        //ElectromagneticUIFactory f = label.Desktop.Tools.Factory as ElectromagneticUIFactory;
                        IMeasurement m = StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement;
                        par.Add(sn[0], m);
                    }
                }

                return par;
            }
        }


        private void fillComboBoxes(string str)
        {
            foreach (Control c in panelMea.Controls)
            {
                if (!(c is PanelMeasureFormula))
                {
                    continue;
                }
                PanelMeasureFormula p = c as PanelMeasureFormula;
                p.FillComboboxes(str);
            }
            comboBoxTime.Items.Clear();
            foreach (char c in str)
            {
                comboBoxTime.Items.Add(c + "");
            }

        }

        private void resetCombo()
        {
            foreach (Control c in panelMea.Controls)
            {
                if (!(c is PanelMeasureFormula))
                {
                    continue;
                }
                PanelMeasureFormula p = c as PanelMeasureFormula;
                p.ResetCombo();
            }
        }

        private void acceptEquations()
        {
            try
            {
                solver.ClearParameters();
                Hashtable t = new Hashtable();
                foreach (DataRow row in dataTableInitial.Rows)
                {
                    string s = row[0] as string;
                    double x = (double)row[1];
                    t[s[0]] = x;
                }
                dataTableInitial.Clear();
                foreach (Control c in panelFormula.Controls)
                {
                    if (!(c is PanelFormula))
                    {
                        continue;
                    }
                    PanelFormula p = c as PanelFormula;
                    char var = p.Variable;
                    solver.AddVariable(var);
                    solver.SetVariable(var, p.Formula);
                    double x = 0;
                    if (t.ContainsKey(var))
                    {
                        x = (double)t[var];
                    }
                    dataTableInitial.Rows.Add(new object[] { var + "", x });
                }
                string par = solver.AllParameters;
                checkedListBoxP.Items.Clear();
                foreach (char c in par)
                {
                    checkedListBoxP.Items.Add("" + c);
                }
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        private void fillTable()
        {
            try
            {
                dataTableInitial.Clear();
                foreach (char c in solver.Keys)
                {
                    dataTableInitial.Rows.Add(new object[] { c + "", solver.GetInitialValue(c) });
                }
                propertyGridAl.SetAlias(solver);
                propertyGridAl.Refresh();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }

        }

        private void acceptArg()
        {
            Dictionary<string, int> old = solver.DerivationOrders;
            try
            {
                solver.ClearParameters();
                Formula.DynamicalParameter p = Parameter;
                solver.Parameter = p;
                foreach (char c in p.Variables)
                {
                    IMeasurement m = p[c];
                    IMeasurement par = m.GetHigherDerivative(1);
                    IMeasurement mea = null;
                    if (par == null)
                    {
                        mea = new Measurement(m.Parameter, c + "");
                    }
                    else
                    {
                        Double a = 0;
                        mea = new MeasurementDerivation(a, m.Parameter, par, c + "");
                    }
                    solver.SetParameter(c, mea);
                }
                solver.Arguments = Arguments;
                Dictionary<string, int> nn =
                     userControlCharIntDictionary.Dictionary;
                Dictionary<string, int> ss =
                    solver.DerivationOrders;
                ss.Clear();
                foreach (string key in nn.Keys)
                {
                    ss[key] = nn[key] - 1;
                }
                solver.Prepare();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        private void showEquations()
        {
            solver.ClearVariables();
            panelFormula.Controls.Clear();
            int w = panelFormula.Width;
            int y = 0;
            List<string> vars = new List<string>();
            foreach (string s in checkedListBoxV.CheckedItems)
            {
                vars.Add(s);
                Panel p = new PanelFormula(s, this, panelFormula.Width, 200, Variables, true, null, null);
                p.Left = 0;
                p.Top = y;
                y += p.Height;
                panelFormula.Controls.Add(p);
            }
            userControlCharIntDictionary.Keys = vars;
        }

        private void setValues()
        {
            try
            {
                foreach (DataRow row in dataTableInitial.Rows)
                {
                    string s = (string)row[0];
                    double a = (double)row[1];
                    solver[s] = a;
                }
           }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        private void acceptParameters()
        {
            solver.ResetAliases();
            //solver.CreateArg();
            IAlias al = solver;
            double a = 0;
            try
            {
                foreach (string s in checkedListBoxP.CheckedItems)
                {
                    al[s] = a;
                }
                string str = solver.InputParameters;
                fillComboBoxes(str);
                fillTable();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        private void createAndFillAliasComboBox()
        {
            IMeasurements m = this.solver;
            Panel panelComboAliasInner = new Panel();
            panelComboAliasInner.Width = panelComboAlias.Width;
            panelComboAliasInner.Height = 5;
            panelComboAlias.Controls.Add(panelComboAliasInner);
            int y = 0;
            List<string> al = new List<string>();
            solver.GetAliases(al, null);
            Dictionary<object, object> ea = solver.ExternalAliases;
            for (int i = 0; i < m.Count; i++)
            {
                IMeasurement mea = m[i];
                char c = mea.Name[0];
                ComboBox cb = new ComboBox();
                panelComboAliasInner.Controls.Add(cb);
                aliasCombo[c] = cb;
                cb.Width = 121;
                cb.Height = 21;
                cb.Top = 10 + y;
                cb.Left = 10;
                Label l = new Label();
                panelComboAliasInner.Controls.Add(l);
                l.Text = c + "";
                l.Top = cb.Top;
                l.Left = cb.Left + cb.Width + 10;
                foreach (string s in al)
                {
                    cb.Items.Add(s);
                }
                y += cb.Height + 10;
                if (ea == null)
                {
                    continue;
                }
                if (ea.ContainsKey(c))
                {
                    string str = ea[c] as string;
                    for (int j = 0; j < cb.Items.Count; j++)
                    {
                        if (str.Equals(cb.Items[j].ToString()))
                        {
                            cb.SelectedIndex = j;
                            break;
                        }
                    }
                }
            }
            panelComboAliasInner.Height = y;

        }



        private void buttonVar_Click(object sender, EventArgs e)
        {
            showEquations();

        }

        private void buttonAcceptForm_Click(object sender, EventArgs e)
        {
            acceptEquations();
            resetCombo();	
        }

        private void buttonAcceptConst_Click(object sender, EventArgs e)
        {
            acceptParameters();
        }

        private void buttonAcceptPar_Click(object sender, EventArgs e)
        {
            acceptArg();
        }

        private void buttonAcceptInitial_Click(object sender, EventArgs e)
        {
            setValues();
        }

        private void buttonAcceptAliases_Click(object sender, EventArgs e)
        {
            try
            {
                if (solver.ExternalAliases != null)
                {
                    solver.ExternalAliases.Clear();
                }
                Hashtable table = new Hashtable();
                foreach (char c in aliasCombo.Keys)
                {
                    ComboBox cb = aliasCombo[c] as ComboBox;
                    object o = cb.SelectedItem;
                    if (o == null)
                    {
                        continue;
                    }
                    table[c] = cb.SelectedItem.ToString();
                }
                Dictionary<object, object> d = new Dictionary<object, object>();
                foreach (var o in table.Keys)
                {
                    d[o] = table[o];
                }
                solver.ExternalAliases = d;
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }

        }

        private void numericUpDownDerivationOrder_ValueChanged(object sender, EventArgs e)
        {
            if (first)
            {
                return;
            }
            solver.DerivationOrder = (int)numericUpDownDerivationOrder.Value;
        }

        void ISaveComments.Save()
        {
            solver.Comments = this.GetComments() as ArrayList;
        }
    }
}