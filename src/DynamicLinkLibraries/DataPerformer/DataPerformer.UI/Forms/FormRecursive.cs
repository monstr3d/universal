using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Diagram.UI.Utils;

using BaseTypes;
using BaseTypes.Utils;


using FormulaEditor;

using ToolBox;

using DataPerformer.Portable;
using DataPerformer.Interfaces;
using ErrorHandler;


namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Editor of properties of recursive element
    /// </summary>
    public partial class FormRecursive : Form, IUpdatableForm, ISaveComments
    {
        // private Hashtable variableCombo = new Hashtable();
        private IObjectLabel label;
        private Recursive recursive;
        private Hashtable formulaHash = new Hashtable();
        private Hashtable aliasCombo = new Hashtable();
        private Hashtable formulaPanels = new Hashtable();
        const Double a = 0;



        private FormRecursive()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Component label</param>
        public FormRecursive(IObjectLabel label)
            : this()
        {
            PanelFormula.SetResize(panelFormula);
            this.label = label;
            recursive = label.Object as Recursive;
            propertyGridAl.SetAlias(recursive);
            ArrayList comments = recursive.Comments;
            this.SetComments(comments);
            UpdateFormUI();
            fillVariables();
            fillFormulas();
            fillConstants();
            fillMeasurements();
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


        private void fillVariables()
        {
            string var = FormDiffEquation.Variables;
            Dictionary<object,object> variables = recursive.Variables;
            string vars = "";
            foreach (char c in recursive.OrderedVariables)
            {
                vars += c;
            }
            for (int i = 0; i < var.Length; i++)
            {
                char v = var[i];
                if (vars.IndexOf(v) > -1)
                {
                    checkedListBoxV.Items.Add("" + v, CheckState.Checked);
                }
                else
                {
                    checkedListBoxV.Items.Add("" + v, CheckState.Unchecked);
                }
            }

        }

        private void fillFormulas()
        {
            Dictionary<object, object> variables = recursive.Variables;
            formulaHash.Clear();
            formulaPanels.Clear();
            panelFormula.Controls.Clear();
            int top = 0;
            foreach (char c in recursive.OrderedVariables)
            {
                PanelFormula p = new PanelFormula("" + c, this, panelFormula.Width, 200, Forms.FormDiffEquation.Variables, false, null, null);
                p.Left = 0;
                p.Top = top;
                top += p.Height;
                object[] o = variables[c] as object[];
                if (o[1] != null)
                {
                    string f = o[1] as string;
                    p.Formula = f;
                }
                panelFormula.Controls.Add(p);
                formulaHash[c] = p;
            }
        }

        private void fillConstants()
        {
            string st = recursive.AllExternalVariables;
            string str = recursive.AliasesString;
            Dictionary<object, object> vars = recursive.Variables;
            checkedListBoxP.Items.Clear();
            foreach (char c in st)
            {
                if (vars.ContainsKey(c))
                {
                    continue;
                }
                if (str.IndexOf(c) < 0)
                {
                    checkedListBoxP.Items.Add(c + "", CheckState.Unchecked);
                }
                else
                {
                    checkedListBoxP.Items.Add(c + "", CheckState.Checked);
                }

            }
            dataTableInitial.Clear();
            Dictionary<object, object> var = recursive.Variables;
            foreach (char c in var.Keys)
            {
                object[] o = var[c] as object[];
                double a = o[2].ToDouble();
                dataTableInitial.Rows.Add(new object[] { c + "", a });
            }
            IAlias al = recursive;
            IList<string> list = al.AliasNames;
            dataTableP.Clear();
            foreach (string s in list)
            {
                if (var.ContainsKey(s[0]))
                {
                    continue;
                }
                dataTableP.Rows.Add(new object[] { s, Converter.ToDouble(al[s]) });
            }
        }


        private void fillMeasurements()
        {
            string s = "";
            Dictionary<object, object> table = recursive.Arguments;
            foreach (char ch in table.Keys)
            {
                s += ch;
            }
            IDataConsumer c = recursive;
            int y = 0;
            for (int i = 0; i < c.Count; i++)
            {
                IMeasurements arrow = c[i];
                PanelMeasureFormula panel = new PanelMeasureFormula(arrow, s, recursive);
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
            comboBoxTime.FillCombo(s);
            foreach (char ch in table.Keys)
            {
                if (table[ch].Equals("Time"))
                {
                    int n = s.IndexOf(ch);
                    comboBoxTime.SelectedIndex = n;
                    break;
                }
            }

        }

        private void fillMeaCombo()
        {
            string s = "";
            Dictionary<object, object> table = recursive.Arguments;
            foreach (char ch in table.Keys)
            {
                s += ch;
            }
            foreach (Control c in panelMea.Controls)
            {
                if (!(c is PanelMeasureFormula))
                {
                    continue;
                }
                PanelMeasureFormula p = c as PanelMeasureFormula;
                p.FillComboboxes(s);
            }
            comboBoxTime.FillCombo(s);
        }

        private void createAndFillAliasComboBox()
        {
            IMeasurements m = recursive;
            Panel panelComboAliasInner = new Panel();
            panelComboAliasInner.Width = panelComboAlias.Width;
            panelComboAliasInner.Height = 5;
            panelComboAlias.Controls.Add(panelComboAliasInner);
            int y = 0;
            List<string> al = new List<string>();
            recursive.GetAliases(al, null);
            Dictionary<object, object> ea = recursive.ExternalAliases;
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

        private List<string> arguments
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
                object o = comboBoxTime.SelectedItem;
                if (o != null)
                {
                    list.Add(o + " = Time");
                }
                return list;
            }
        }





        private void buttonVar_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<object, object> table = new Dictionary<object, object>();

                foreach (string s in checkedListBoxV.CheckedItems)
                {
                    object[] o = new object[3];
                    double a = 0;
                    o[0] = a;
                    o[2] = a;
                    table[s[0]] = o;
                }
                recursive.Variables = table;
                fillFormulas();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
             }
        }

        private void buttonAcceptForm_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<object, object> table = new Dictionary<object, object>();
                foreach (char c in formulaHash.Keys)
                {
                    PanelFormula p = formulaHash[c] as PanelFormula;
                    table[c] = p.Formula;
                }
                recursive.Formulas = table;
                fillConstants();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        private void buttonAcceptConst_Click(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                foreach (string str in checkedListBoxP.CheckedItems)
                {
                    s += str[0];
                }
                recursive.AliasesString = s;
                propertyGridAl.SetAlias(recursive);
                fillMeaCombo();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
             }
        }

        private void buttonAcceptPar_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> arg = arguments;
                Dictionary<object, object> table = new Dictionary<object, object>();
                foreach (string s in arg)
                {
                    table[s[0]] = s.Substring(4);
                }
                recursive.Arguments = table;
                fillConstants();
                createAndFillAliasComboBox();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        private void buttonAcceptInitial_Click(object sender, EventArgs e)
        {
            IAlias al = recursive;
            try
            {
                foreach (DataRow row in dataTableP.Rows)
                {
                    string s = row[0] as string;
                    double a = (double)row[1];

                    al[s] = a;
                }
                Dictionary<object, object> var = recursive.Variables;
                foreach (DataRow row in dataTableInitial.Rows)
                {
                    string st = row[0] as string;
                    double at = (double)row[1];
                    object[] o = var[st[0]] as object[];
                    o[0] = o[2].Convert(at);
                }
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        private void buttonAcceptAliases_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<object, object> table = new Dictionary<object, object>();
                foreach (char c in aliasCombo.Keys)
                {
                    ComboBox cb = aliasCombo[c] as ComboBox;
                    if (cb.SelectedIndex < 0)
                    {
                        continue;
                    }
                    table[c] = cb.SelectedItem.ToString();
                }
                recursive.ExternalAliases = table;
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }
 
  
        void ISaveComments.Save()
        {
            recursive.Comments = this.GetComments() as ArrayList;
        }
    }
}