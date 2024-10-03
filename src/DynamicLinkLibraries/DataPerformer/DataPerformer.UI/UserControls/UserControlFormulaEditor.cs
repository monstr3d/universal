using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


using Diagram.UI;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using ToolBox;

using DataPerformer.Interfaces;
using DataPerformer;
using FormulaEditor.Drawing.Symbols;
using FormulaEditor.Drawing;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control for formula editor
    /// </summary>
    public partial class UserControlFormulaEditor : UserControl
    {
        #region Fields

        /// <summary>
        /// Error messages
        /// </summary>
        public static readonly string[] Messages = new string[]{"Formulas are accepted. Select constants using checkboxes", 
            "Constants are accepeted. Select data-in", "Data-in is accepted. Enter values of constants"};


        private VectorFormulaConsumer consumer;
        const string form = "Formula ";
        bool first = true;
        private Dictionary<string, object> tempAliases = new Dictionary<string, object>();

 

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlFormulaEditor()
        {
            InitializeComponent();
        }

        #endregion

        #region Members

        internal VectorFormulaConsumer Consumer
        {
            get
            {
                return consumer;
            }
            set
            {
                consumer = value;
                userControlFeedBack.Set(consumer, consumer);
            }
        }

        new internal void Load()
        {

            /*         userControlCommentsFont.AcceptComments += delegate(ICollection comm)
                     {
                         consumer.Comments = comm;
                     };
             */
            PanelFormula.SetResize(panelFormula);
            fill();
            IList<string> a = consumer.AliasNames;
            numericUpDownOrder.Value = consumer.DerivationOrder;
            first = false;
            Diagram.UI.PropertyEditors.AliasTable.AddDicitionary(consumer, tempAliases);
            try
            {
                IAlias alias = consumer;
                IList<string> al = alias.AliasNames;
                propertyGridAlias.SetAlias(consumer);
                string str = consumer.AllVariables;
                foreach (char c in str)
                {
                    if (al.Contains(c + ""))
                    {
                        checkedListBoxP.Items.Add("" + c, CheckState.Checked);
                    }
                    else
                    {
                        checkedListBoxP.Items.Add("" + c, CheckState.Unchecked);
                    }
                }
                IMeasurements m = consumer;
                numericUpDownQuantity.Value = m.Count;
                fillFormulas();
                setComboboxes();
                userControlFeedBack.Reset();
                userControlFeedBack.Set(consumer.Feedback);
                userControlForward.Measurements = consumer;
                userControlForward.Items = consumer.ForwardAliases;
                userControlForward.OnChange += (Dictionary<int, string> d) =>
                    {
                        consumer.ForwardAliases = userControlForward.Items;
                    };
                IRuntimeUpdate start = consumer;

                checkBoxRuntimeUpdate.Checked = start.ShouldRuntimeUpdate;
                checkBoxRuntimeUpdate.CheckStateChanged += (object o, EventArgs e) =>
                    {
                        start.ShouldRuntimeUpdate = checkBoxRuntimeUpdate.Checked;
                    };
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        void fill()
        {
            string variables = consumer.InputParameters;
            int y = 20;
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements arrow = consumer[i];
                PanelMeasureFormula panel = new PanelMeasureFormula(arrow, variables, consumer);
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
            comboBoxTime.FillCombo(variables);
            if (consumer.Arguments != null)
            {
                foreach (string str in consumer.Arguments)
                {
                    string s = str + "";
                    int n = str.Length;
                    if (s.Substring(n - 4, 4).Equals("Time"))
                    {
                        for (int i = 0; i < comboBoxTime.Items.Count; i++)
                        {
                            if (comboBoxTime.Items[i].ToString()[0] == str[0])
                            {
                                comboBoxTime.SelectedIndex = i;
                                return;
                            }
                        }
                    }
                }
            }
        }


        private void acceptConstants()
        {
            try
            {
                string str = "";
                /*
                Hashtable t = new Hashtable();
                foreach (DataRow row in dataTableP.Rows)
                {
                    string s = row[0] as string;
                    double x = (double)row[1];
                    t[s] = x;
                }*/
                foreach (string s in checkedListBoxP.CheckedItems)
                {
                    /*  double a = 0;
                      if (t.ContainsKey(s))
                      {
                          a = (double)t[s];
                      }
                     //* dataTableP.Rows.Add(new object[] { s, a });*/
                    str += s;
                }
                Diagram.UI.PropertyEditors.AliasTable.AddDicitionary(consumer, tempAliases);
                consumer.CreateAliases(str);
                Diagram.UI.PropertyEditors.AliasTable.SetDictionary(tempAliases, consumer);
                string var = consumer.InputParameters;
                foreach (Control c in panelMea.Controls)
                {
                    if (!(c is PanelMeasureFormula))
                    {
                        continue;
                    }
                    PanelMeasureFormula p = c as PanelMeasureFormula;
                    p.FillComboboxes(var);
                }
                if (comboBoxTime.SelectedItem != null)
                {
                    comboBoxTime.Tag = comboBoxTime.SelectedItem;
                }
      
                comboBoxTime.FillCombo(var);
                propertyGridAlias.SetAlias(consumer);
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        private void createFormulaControls()
        {
            ArrayList formulas = new ArrayList();
            foreach (Control c in panelFormula.Controls)
            {
                if (!(c is PanelFormula))
                {
                    continue;
                }
                PanelFormula p = c as PanelFormula;
                formulas.Add(p.Formula);
            }
            panelFormula.Controls.Clear();
            int w = panelFormula.Width;
            int y = 0;
            IMeasurements m = consumer;
            int n = m.Count;
            for (int i = 0; i < n; i++)
            {
                PanelFormula p = new PanelFormula(form + (i + 1), this, panelFormula.Width, 200,
                    "abcdfghijklmnopqrstuvwxyz", false, null, null);
                p.Left = 0;
                p.Top = y;
                y += p.Height;
                if (i < formulas.Count)
                {
                    string formula = formulas[i] as string;
                    p.Formula = formula;
                }
                panelFormula.Controls.Add(p);
            }
        }

        private void fillFormulas()
        {
            Graphics g =  Graphics.FromHwnd(this.Handle);
            panelFormula.Controls.Clear();
            int w = panelFormula.Width;
            int y = 0;
            IMeasurements m = consumer;
            int n = m.Count;
            for (int i = 0; i < n; i++)
            {
                PanelFormula p = new PanelFormula(form + (i + 1), this, panelFormula.Width, 200,
                    "abcdfghijklmnopqrstuvwxyz", false, null, null);
                p.Left = 0;
                p.Top = y;
                y += p.Height;
                panelFormula.Controls.Add(p);
                string f = consumer.GetFormula(i);
                if (f != null)
                {
                    p.Formula = f;
                }
            }
        }

        /// <summary>
        /// Resets comboboxes
        /// </summary>
        public void ResetCombo()
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
            comboBoxTime.ClearItems();
        }

        /// <summary>
        /// Access to dynamical parameter
        /// </summary>
        public Formula.DynamicalParameter Parameter
        {
            get
            {
                try
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
                            IMeasurement m = DataPerformer.Portable.StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement;
                            par.Add(sn[0], m);
                        }
                    }

                    return par;
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                 }
                return null;
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

  
        private void acceptFormulas()
        {
            try
            {
                ResetCombo();
                int i = 0;
                foreach (Control c in panelFormula.Controls)
                {
                    if (!(c is PanelFormula))
                    {
                        continue;
                    }
                    PanelFormula p = c as PanelFormula;
                    consumer.SetFormula(p.Formula, i);
                    ++i;
                }
                consumer.AcceptFormulas();
                checkedListBoxP.Items.Clear();
                string par = consumer.AllVariables;
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

        private void acceptParameters()
        {
            consumer.Parameter = Parameter;
            consumer.Arguments = Arguments;
            tempAliases = Diagram.UI.PropertyEditors.AliasTable.GetDictionary(consumer);
        }


        private string message
        {
            set
            {
                this.statusStrip.Text = ResourceService.Resources.GetControlResource(value, DataPerformer.UI.Utils.ControlUtilites.Resources);
            }
        }



        private void setComboboxes()
        {
            Dictionary<int, string> table = consumer.OperationNames;
            /*     foreach (object o in panelUnary.Controls)
                 {
                     if (!(o is PanelUnary))
                     {
                         continue;
                     }
                     PanelUnary p = o as PanelUnary;
                     p.SetComboBoxes(table);
                 }*/
        }




        #endregion

        #region Event Handlers

 
        private void buttonSetQuantity_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDownQuantity.Value;
            consumer.Dimension = n;
            createFormulaControls();
            ResetCombo();

        }


        private void buttonAcceptForm_Click(object sender, EventArgs e)
        {
            acceptFormulas();
            message = Messages[0];
        }

        private void buttonAcceptConst_Click(object sender, EventArgs e)
        {
            acceptConstants();
            message = Messages[1];
        }

        private void buttonAcceptPar_Click(object sender, EventArgs e)
        {
            try
            {
                acceptParameters();
                message = Messages[2];
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }

        }

        private void numericUpDownOrder_ValueChanged(object sender, EventArgs e)
        {
            if (first)
            {
                return;
            }
            consumer.DerivationOrder = (int)numericUpDownOrder.Value;
        }

        private void buttonAcceptFeedback_Click(object sender, EventArgs e)
        {
            consumer.Feedback = userControlFeedBack.Dictionary;
        }


        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            userControlFeedBack.Reset();
        }


        private void userControlCommentsFont_AcceptComments(ICollection comments)
        {
            consumer.Comments = comments;
       }

        private void panelMea_Resize(object sender, EventArgs e)
        {
            int w = panelMea.Width;
            foreach (Control c in panelMea.Controls)
            {
                if (c is PanelMeasureFormula)
                {
                    c.Width = w - 10;
                }
            }
        }
        #endregion


    }
}
