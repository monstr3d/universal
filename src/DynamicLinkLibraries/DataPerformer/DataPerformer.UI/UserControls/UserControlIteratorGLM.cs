using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Utils;
using ErrorHandler;
using Regression;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control for GLM iterator
    /// </summary>
    public partial class UserControlIteratorGLM : UserControl
    {
        #region Fields

        Stack<Tuple<string, Dictionary<IAliasName, double>>> stack =
            new Stack<Tuple<string, Dictionary<IAliasName, double>>>();

        private Regression.Portable.IteratorGLM iterator;

      //  private List<ComboBox> alias = new List<ComboBox>();

     //   List<TextBox> disp = new List<TextBox>();

        private List<Label> labs = new List<Label>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlIteratorGLM()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Members

        internal Regression.Portable.IteratorGLM Iterator
        {
            set
            {
                iterator = value;
            }
        }

        #endregion

        #region Private Members

        private  List<ComboBox> alias
        {
            get
            {
                List<ComboBox> l = new List<ComboBox>();
                foreach (UserControlComboboxTexts uc in userControlComoboxesTexts.Children)
                {
                    l.Add(uc.ComboBox);
                }
                return l;
            }
        }

        private List<TextBox> disp
        {
            get
            {
                List<TextBox> l = new List<TextBox>();
                foreach (UserControlComboboxTexts uc in userControlComoboxesTexts.Children)
                {
                    l.Add(uc.TextBox);
                }
                return l;
            }
        }

        void LoadIterator()
        {
            toolStripButtonNumberAli.FillCombo(1, 100);
            toolStripComboBoxOut.FillCombo(1, 100);
            toolStripButtonNumberAli.SelectedIndex = iterator.AliasesCount - 1;
            toolStripComboBoxOut.SelectedIndex = iterator.DataCount - 1;
            fillOut();
            FillAli();
            selectCombo();
        }

        private void removeData()
        {
          /*  foreach (ComboBox cb in left)
            {
                Control p = cb.Parent;
                p.Controls.Remove(cb);
            }
            left.Clear();
            foreach (ComboBox cb in right)
            {
                Control p = cb.Parent;
                p.Controls.Remove(cb);
            }*/
      //      right.Clear();
            foreach (Label l in labs)
            {
                Control p = l.Parent;
                p.Controls.Remove(l);
            }
            labs.Clear();
        }

      /*  private void removeAli()
        {
            foreach (ComboBox box in alias)
            {
                Control p = box.Parent;
                p.Controls.Remove(box);
            }
            alias.Clear();
            foreach (TextBox tb in disp)
            {
                Control p = tb.Parent;
                p.Controls.Remove(tb);
            }
        }*/

        
        void fillOut()
        {
            removeData();
            int n = toolStripComboBoxOut.SelectedIndex + 1;
            if (n == 0)
            {
                int.TryParse(toolStripComboBoxOut.Text, out n);
            }
            userControlEqualComboboxesContainer.Number = n;
            List<UserControlEqualComboboxes> l = userControlEqualComboboxesContainer.Children;
//            left.Clear();
//            right.Clear();
            foreach (UserControlEqualComboboxes c in l)
            {
                ComboBox[] cb = c.Boxes;
                foreach (ComboBox cc in cb)
                {
                    fillData(cc);
                }
  //              left.Add(cb[0]);
  //              right.Add(cb[1]);
            }
            /* !!! for (int i = 0; i < n; i++)
            {
                ComboBox comboLeft = new ComboBox();
                left.Add(comboLeft);
                fillData(comboLeft);
                comboLeft.Top = y;
                comboLeft.Left = 5;
                comboLeft.Width = cLeftPart.Width - 10;
                cLeftPart.Controls.Add(comboLeft);
                /* Label l = new Label();
                 l.Text = "=";
                 l.Left = comboLeft.Left + comboLeft.Width + 5;
                 l.Top = comboLeft.Top;
                 l.Width = 20;
                 labs.Add(l);*/
                //cRightPart.Controls.Add(l);
             /*!!!   ComboBox comboRight = new ComboBox();
                right.Add(comboRight);
                fillData(comboRight);
                comboRight.Top = y;
                comboRight.Left = 5;// l.Right + 5;
                comboRight.Width = cRightPart.Width - 10;
                cRightPart.Controls.Add(comboRight);
                y = comboLeft.Top + comboLeft.Height + 10;
            } // */
        }

        void FillAli()
        {
            int n = toolStripButtonNumberAli.SelectedIndex + 1;
            if (n == 0)
            {
                int.TryParse(toolStripButtonNumberAli.Text, out n);
            }

            /* !!! for (int i = 0; i < n; i++)
            {
                ComboBox box = new ComboBox();
                box.Top = y;
                alias.Add(box);
                fillAlias(box);
                box.Left = 10;
                box.Width = cPar.Width - 10;
                cPar.Controls.Add(box);
                y = box.Top + box.Height + 10;
                TextBox tb = new TextBox();
                tb.Top = box.Top;
                tb.Left = 5;
                tb.Text = 0 + "";
                disp.Add(tb);
                cSigma.Controls.Add(tb);
            }*/
            FillAliases(n);
        }

        void FillAliases(int number)
        {
            if (number == userControlComoboxesTexts.Children.Count)
            {
                return;
            }
            userControlComoboxesTexts.Count = number;
            List<ComboBox> l = alias;
            foreach (ComboBox cb in l)
            {
                fillAlias(cb);
            }
        }

        void selectCombo()
        {
            List<UserControlEqualComboboxes> cb = userControlEqualComboboxesContainer.Children;
            for (int i = 0; i < cb.Count; i++)
            {
                cb[i].Select(iterator.GetLeftName(i), iterator.GetRightName(i));
            }
            List<ComboBox> al = alias;
            for (int i = 0; i < al.Count; i++)
            {
                selectCombo(al[i], iterator.GetAliasName(i));
            }
            double[,] d = iterator.CorrectionMatrix;

            List<UserControlComboboxTexts> lc = userControlComoboxesTexts.Children;
            if (d != null)
            {
                for (int i = 0; i < lc.Count; i++)
                {
                    if (i >= d.GetLength(0))
                    {
                        continue;
                    }
                    if (i >= d.GetLength(1))
                    {
                        continue;
                    }
                    TextBox tb = lc[i].TextBox;
                    tb.Text = d[i, i] + "";
                }
            }
        }

        void selectCombo(ComboBox box, string item)
        {
            for (int i = 0; i < box.Items.Count; i++)
            {
                string s = box.Items[i] + "";
                if (s.Equals(item))
                {
                    box.SelectedIndex = i;
                    return;
                }
            }
        }

        void fillData(ComboBox box)
        {
            List<string> l = iterator.AllMeasurements;
            foreach (string s in l)
            {
                box.Items.Add(s);
            }
        }

        void fillAlias(ComboBox box)
        {
            List<string> l = iterator.AllAliases;
            foreach (string s in l)
            {
                box.Items.Add(s);
            }
        }

        void accept()
        {
            try
            {
                List<string>[] texts = userControlEqualComboboxesContainer.Texts;
               // List<string> l = getComboList(left);
               // List<string> ri = getComboList(right);
                List<string> ali = getComboList(alias);
                List<List<string>> r = new List<List<string>>();
                int n = ali.Count;
                double[,] d = new double[n, n];
                double[] dx = new double[n];
                for (int i = 0; i < dx.Length; i++)
                {
                    dx[i] = 0.00000001;
                }
                for (int i = 0; i < texts[0].Count; i++)
                {
                    List<string> list = new List<string>();
                    r.Add(list);
                    for (int j = 0; j <= i; j++)
                    {
                        list.Add("");
                        d[i, j] = d[j, i] = 0;
                    }
                }
                for (int i = 0; i < disp.Count; i++)
                {
                    d[i, i] = double.Parse(disp[i].Text);
                }
                iterator.Set(ali, texts[0], texts[1], r, dx, d);
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }

        private List<string> getComboList(List<ComboBox> l)
        {
            List<string> list = new List<string>();
            foreach (ComboBox box in l)
            {
                list.Add(box.SelectedItem + "");
            }
            return list;
        }

        private void fill()
        {
            FillAli();
            fillOut();
        }

        void Iterate()
        {
            try
            {
                stack.Push(new Tuple<string, Dictionary<IAliasName, double>>(
                   labelSigma.Text, iterator.Backup));
                double s = iterator.FullIterate();
                buttonBack.Enabled = true;
                labelSigma.Text = "Sigma = " + s + "";
            }
            catch (Exception exception)
            {
                exception.HandleException();
                stack.Pop();
            }
        }


        void Back()
        {
            Tuple<string, Dictionary<IAliasName, double>> t = stack.Pop();
            labelSigma.Text = t.Item1;
            Dictionary<IAliasName, double> d = t.Item2;
            foreach (IAliasName alias in d.Keys)
            {
                alias.Value = d[alias];
            }
            if (stack.Count == 0)
            {
                buttonBack.Enabled = false;
            }
        }

        #endregion

        #region Event Handlers

        private void buttonAcceptAll_Click(object sender, EventArgs e)
        {
            accept();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            fill();
        }

        private void buttonAcceptNumber_Click(object sender, EventArgs e)
        {
            fill();
        }

        private void buttonIterate_Click(object sender, EventArgs e)
        {
            Iterate();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void UserControlIteratorGLM_Load(object sender, EventArgs e)
        {
            LoadIterator();
        }

        private void panelTopContainer_Resize(object sender, EventArgs e)
        {
            int w = panelTopContainer.Width / 2 - 2;
            panelLeftContainer.Width = w;
            panelRightName.Width = w;
        }

        #endregion


    }
}
