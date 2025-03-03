using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SerializationInterface;

using Diagram.UI;
using Diagram.UI.PropretyGridHelpers;
using Diagram.UI.Utils;

using ControlSystemsWrapper;

using OrdinaryDifferentialEquations;
using Chart;
using Chart.UserControls;
using ControlSystems.UI.Interfaces;
using ErrorHandler;

namespace ControlSystems.UI.UserControls
{
    public partial class UserControlTransformFunction : UserControl
    {
        #region Fields


        private RationalTransformControlSystemFunctionWrapper transform;

        private RationalTransformControlSystemFunctionWrapper clone;

        private UserControlChart[] charts;

        private double min;

        private double max;


        private double maxfreq;

        private double minfreq;

        private double freqstep;

        private IFeedback feedback;

        private SelectMeasure sel = delegate(object measure)
        {
        };

        #endregion

        #region Ctor

        public UserControlTransformFunction()
        {
            InitializeComponent();
            charts = new UserControlChart[] {
                userControlChartTransient, 
                userControlChartApmplitude,
                userControlChartPhase};

        }

        #endregion

        #region Members

        public IFeedback Feedback
        {
            set
            {
                feedback = value;
                ICollection<string> al = feedback.Aliases;
                comboBoxFeedBack.FillCombo(al);
                try
                {
                    comboBoxFeedBack.SelectCombo(feedback.Alias);
                }
                catch (Exception ex)
                {
                    ex.HandleException(10);
                }
            }
        }
                

        /// <summary>
        /// Select event
        /// </summary>
        public event SelectMeasure SelectMeasure
        {
            add
            {
                sel += value;
            }
            remove
            {
                sel -= value;
            }
        }

        /// <summary>
        /// Measurements
        /// </summary>
        public ICollection<string> Measurements
        {
            set
            {
                comboBoxInput.Items.Clear();
                foreach (string s in value)
                {
                    comboBoxInput.Items.Add(s);
                }
            }
        }

        /// <summary>
        /// Sets selected item
        /// </summary>
        public string SelectedItem
        {
            set
            {
                for (int i = 0; i < comboBoxInput.Items.Count; i++)
                {
                    string s = comboBoxInput.Items[i] + "";
                    if (s.Equals(value))
                    {
                        comboBoxInput.SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Shows compobox
        /// </summary>
        /// <returns>Elargement of window</returns>
        public int ShowComboBox()
        {
            comboBoxInput.Visible = true;
            labelInput.Visible = true;
            int old = buttonFormula.Top;
            int ne = comboBoxInput.Bottom + 5;
            int delta = ne - old;
            buttonFormula.Top = buttonFormula.Top + delta;
            buttonApply.Top = buttonApply.Top + delta;
            panelControl.Height = panelControl.Height + delta;
            return delta;
        }

        internal void Prepare()
        {
            ResourceService.Resources.LoadControlResources(this, ControlSystems.UI.Utils.ControlUtilites.Resources);
            char c = ControlSystems.RationalTransformControlSystemFunction.LaplaceTransformChar;
            string[] ss = new string[] { "abcdfghijklmnopqrstuvwxyz" };
            string[] sss = new string[ss.Length];
            for (int i = 0; i < sss.Length; i++)
            {
                string str = "";
                string prot = ss[i];
                foreach (char ch in prot)
                {
                    if (ch != c)
                    {
                        str += ch;
                    }
                }
                sss[i] = str;
            }
            userFormulaEditor.PreparePoly(new int[] { 15, 11 }, c, sss);
            foreach (UserControlChart chart in charts)
            {
                chart.Prepare(new int[,] { { 50, 5 }, { 5, 50 } }, true);
                chart.Coordinator = new SimpleCoordinator(5, 5);
            }
        }

        internal RationalTransformControlSystemFunctionWrapper Transform
        {
            get
            {
                return transform;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                transform = value;
                DictionaryTable<double>.Set(transform.Variables, propertyGrid);
                userFormulaEditor.Formula = transform.Formula;
                checkBoxStable.Checked = transform.ShouldStable;
                checkBoxStable.CheckedChanged += checkBoxStable_CheckedChanged;
                ShowAll();
            }
        }


        private void CreateClone()
        {
            try
            {
                clone = transform.Clone<RationalTransformControlSystemFunctionWrapper>();
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }

        }

        private void ShowAll()
        {
            CreateClone();
            if (clone == null)
            {
                return;
            }
            double[] n = clone.MinMaxFrequency;
           // return;
            min = n[0];
            max = n[1];
            if (min == 0)
            {
                min = 0.1;
            }
            if (max < min)
            {
                max = 10 * min;
            }
            minfreq = min / 10;
            maxfreq = max * 10;
            freqstep = 1 / (100 * max);
            double coeff = clone.HighFrequecyCoefficient;
            foreach (UserControlChart c in charts)
            {
                c.RemoveAll();
            }
            ShowTransient();
            if (checkBoxLog.Checked)
            {
                ShowLog();
            }
            else
            {
                ShowFreq();
            }
        }

        private void ShowFreq()
        {
            for (int i = 1; i < 3; i++)
            {
                UserControlChart chart = charts[i];
                chart.RemoveAll();
                chart.Coordinator = new SimpleCoordinator(5, 5);
            }
            Chart.Drawing.Series.SimpleSeries sa = new Chart.Drawing.Series.SimpleSeries();
            Chart.Drawing.Series.SimpleSeries sp = new Chart.Drawing.Series.SimpleSeries();
            freqstep = maxfreq / 400;
            double maxamp = 0;
            double coeff = clone.HighFrequecyCoefficient;
            int max = 0;
            for (int i = 0; ; i++)
            {
                ++max;
                if (max > 10000)
                {
                    break;
                }
                double a = (double)i * freqstep;
                double amp;
                double ph;
                clone.GetFrequencyCharacteristics(a, out amp, out ph);
                if (a > maxfreq & ((Math.Abs(amp - coeff) < 0.01 * Math.Abs(maxamp - coeff))
                    | amp > maxamp))
                {
                    break;
                }
                if (amp > maxamp)
                {
                    maxamp = amp;
                }
                sa.AddXY(a / (2 * Math.PI), amp);
                sp.AddXY(a / (2 * Math.PI), 180 * ph / Math.PI);
            }
            Chart.Drawing.Series.SimpleSeries[] ss = new Chart.Drawing.Series.SimpleSeries[] { sa, sp };
            for (int i = 0; i < 2; i++)
            {
                charts[i + 1].AddSeries(ss[i], Color.Red);
            }
        }

        private void ShowLog()
        {
            if (clone == null)
            {
                return;
            }
            for (int i = 1; i < 3; i++)
            {
                UserControlChart chart = charts[i];
                chart.RemoveAll();
                LogarithmCoordinator coord = new LogarithmCoordinator(chart.Performer);
                coord.LogX = true;
                if (i == 1)
                {
                    coord.LogY = true;
                }
                chart.Coordinator = coord;
            }
            double ml = Math.Log10(maxfreq);
            //double step = ml / 400;
            Chart.Drawing.Series.SimpleSeries sa = new Chart.Drawing.Series.SimpleSeries();
            Chart.Drawing.Series.SimpleSeries sp = new Chart.Drawing.Series.SimpleSeries();
            double dec = 100;
            double minlog = -3;
            if (minfreq > 0)
            {
                minlog = Math.Log10(minfreq);
            }
            double step = Math.Log10(dec) / 400;
            double logpi = Math.Log10(2 * Math.PI);
            double maxamp = 0;
            double coeff = clone.HighFrequecyCoefficient;
            int max = 0;
            for (int i = 1; ; i++)
            {
                ++max;
                if (max > 10000)
                {
                    break;
                }
                double x = (double)i * step + minlog;
                double f = Math.Pow(10, x);
                double amp;
                double ph;
                clone.GetFrequencyCharacteristics(f, out amp, out ph);
                if (amp > maxamp)
                {
                    maxamp = amp;
                }
                if (f > maxfreq & ((Math.Abs(amp - coeff) < 0.01 * Math.Abs(maxamp - coeff))
                    | amp > maxamp))
                {
                    break;
                }
                amp = Math.Log10(amp);
                double fr = x - logpi;
                sa.AddXY(fr, amp);
                sp.AddXY(fr, 180 * ph / Math.PI);
            }
            Chart.Drawing.Series.SimpleSeries[] ss = new Chart.Drawing.Series.SimpleSeries[] { sa, sp };
            for (int i = 0; i < 2; i++)
            {
                charts[i + 1].AddSeries(ss[i], Color.Red);
            }
        }

        private void ShowTransient()
        {
            double step = 1 / (30 * max);
            double eps = 0.001;
            double coeff = clone.Coefficient;
            if (coeff < 1 & coeff > 1e-15)
            {
                eps *= coeff;
            }
            double a = 0;
            if (min > 0)
            {
                a = 1 / min;
            }
            Chart.Drawing.Series.SimpleSeries ss = new Chart.Drawing.Series.SimpleSeries();
            double t = 0;
            double ed = 1;
            double y1 = 0;
            IDifferentialEquationsSystem sys = clone;
            int maxm = 0;
            while (true)
            {
                ++maxm;
                if (maxm > 10000)
                {
                    break;
                }
                double te = t + step;
                clone.Step(t, te, 1);
                double y = clone.Output;
                t = te;
                ss.AddXY(t, y);
                double ep = y - coeff;
                if (!transform.IsStable)
                {
                    if (t > 10 * a)
                    {
                        break;
                    }
                }
                if (Math.Abs(ep) < eps & Math.Abs(ed) < eps & t > (3 * a))
                {
                    break;
                }
                ed = (y1 - y) / step;
                y1 = y;
            }
            userControlChartTransient.AddSeries(ss, Color.Red);
        }

        #endregion

        #region Event Handlers

        private void checkBoxLog_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLog.Checked)
            {
                ShowLog();
                return;
            }
            ShowFreq();
        }

        private void buttonFormula_Click(object sender, EventArgs e)
        {
            if (transform == null)
            {
                return;
            }
            transform.AcceptFormula(userFormulaEditor.Formula);
            DictionaryTable<double>.Set(transform.Variables, propertyGrid);
            
        }


        private void buttonAll_Click(object sender, EventArgs e)
        {
            if (transform == null)
            {
                return;
            }
            try
            {
                sel(comboBoxInput.SelectedItem);
                transform.CreateSystem(userFormulaEditor.Formula);
                if (feedback != null)
                {
                    object o = comboBoxFeedBack.SelectedItem;
                    if (o != null)
                    {
                        feedback.Alias = o + "";
                    }
                }
                ShowAll();
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }

        #endregion

        private void checkBoxStable_CheckedChanged(object sender, EventArgs e)
        {
            transform.ShouldStable = checkBoxStable.Checked;
        }


    }

    #region Delegate

    public delegate void SelectMeasure(object measure);

    #endregion

}