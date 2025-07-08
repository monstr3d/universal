using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Diagram.UI;
using Diagram.UI.Utils;

using DataPerformer.Helpers;
using DataPerformer.Interfaces;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Editor of properties of Kalman Filter
    /// </summary>
    public partial class UserControlKalmanFilter : UserControl
    {

        #region Fields

        KalmanFilter filter;

        List<ComboBox> boxes;

        double[][] old = new double[3][];

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlKalmanFilter()
        {
            InitializeComponent();
            boxes = userControlComboboxList.Boxes;
        }

        #endregion


        #region Members

        /// <summary>
        /// Filter
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KalmanFilter Filter
        {
            get
            {
                return filter;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                filter = value;
                Fill();
            }
        }

        void Fill()
        {
            IEnumerable<string> l = FiniteMatrixDerivationTransformer.GetNames(filter);
            boxes[0].FillCombo(l);
            boxes[0].SelectCombo(filter.Transition);
            boxes[1].FillCombo(l);
            boxes[1].SelectCombo(filter.Measurements);
            l = filter.GetAllNames<IMeasurements>();
            string[] s = new string[] { filter.RealMeasurements, filter.CovariationState, filter.CovariationMeasurements };
            for (int i = 0; i < s.Length; i++)
            {
                ComboBox box = boxes[i + 2];
                box.FillCombo(l);
                box.SelectCombo(s[i]);
            }
            FillNumbers(false);
        }


        void FillNumbers()
        {
        }

        void FillNumbers(bool rewrite)
        {
            double[] x = filter.InitialState;
            if (x == null)
            {
                return;
            }
            dataGridView.Rows.Clear();
            if (rewrite)
            {
                int n = x.Length;
                if (old[0] != null)
                {
                    int k = old[0].Length;
                    if (k < n)
                    {
                        n = k;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    object[] o = new object[] { i, x[i], filter.Difference[i], filter.MeaDifference[i] };
                    dataGridView.Rows.Add(o);
                }
                for (int i = n; i < x.Length; i++)
                {
                    object[] o = new object[] { i, x[i], filter.Difference[i], filter.MeaDifference[i] };
                    dataGridView.Rows.Add(o);
                }
            }
            else
            {
               int n = x.Length;
               for (int i = 0; i < n; i++)
                {
                    object[] o = new object[] { i, x[i], filter.Difference[i], filter.MeaDifference[i] };
                    dataGridView.Rows.Add(o);
                }
           }
            dataGridViewMatrix.RealMatrix = filter.InitialCovariation;
        }

        void AcceptPar()
        {
            string[] s = new string[5];
            for (int i = 0; i < 5; i++)
            {
               object o = boxes[i].SelectedItem;
                if (o == null)
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal("Empty");
                    return;
                }
                s[i] = o + "";
            }
            if (!filter.Set(s[0], s[1], s[2], s[3], s[4]))
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal("Incorrect");
                return;
            }
            FillNumbers(old[0] != null);
        }

        void AcceptNumbers()
        {
            try
            {
                if (filter.InitialState == null)
                {
                    return;
                }
                int n = filter.InitialState.Length;
                for (int i = 0; i < 3; i++)
                {
                    old[i] = new double[n];
                }
                for (int i = 0; i < n; i++)
                {
                    DataGridViewRow row = dataGridView.Rows[i];
                    for (int j = 0; j < 3; j++)
                    {
                        double a = Double.Parse(row.Cells[j + 1].Value + "");
                        old[j][i] = a;
                    }
                }
                filter.Set(old[0], old[1], old[2]);
                dataGridViewMatrix.Accept();
            }
            catch (Exception ex)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }

        #endregion

        #region Event handlers

        private void buttonSetPar_Click(object sender, EventArgs e)
        {
            AcceptPar();
        }

        private void buttonSetState_Click(object sender, EventArgs e)
        {
            AcceptNumbers();
        }



        private void dataGridViewMatrix_Action(int arg1, int arg2, object arg3)
        {
            try
            {
                double[,] a = filter.InitialCovariation;
                if (a == null)
                {
                    return;
                }
                if (arg3 is string)
                {
                    a[arg1, arg2] = Double.Parse(arg3 + "");
                }
            }
            catch (Exception e)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }
        #endregion

    }
}
