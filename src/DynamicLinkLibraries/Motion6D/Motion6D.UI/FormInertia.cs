using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using DataPerformer.Portable;

namespace Motion6D.UI
{
    /// <summary>
    /// Form of inertial 3D object
    /// </summary>
    public partial class FormInertia : Form, IUpdatableForm
    {
        private InertialReferenceFrame frame;
        private IObjectLabel label;
        private ComboBox[] comboState;
        private ComboBox[] comboIntertia;
        private ComboBox[] comboForces;
        private ComboBox[] required;
        private TextBox[] linear;
        private TextBox[] angular;

        private static readonly string[] req = new string[] { "Jxx", "Jyy", "Jzz" };


        private FormInertia()
        {
            InitializeComponent();
            comboState = new ComboBox[]
            {
                comboBoxXA, comboBoxYA, comboBoxZA, comboBoxVxA, comboBoxVyA, comboBoxVzA,
                comboBoxQ0, comboBoxQ1, comboBoxQ2, comboBoxQ3, comboBoxOMx, comboBoxOMy, comboBoxOMz,
                comboBoxVxR, comboBoxVyR, comboBoxVzR, comboBoxOMxR, comboBoxOMyR, comboBoxOMzR
            };

            comboIntertia = new ComboBox[]
            {
                comboBoxJxx, comboBoxJxy, comboBoxJxz,
                comboBoxJyy, comboBoxJyz,
                comboBoxJzz,
                comboBoxMass
            };

            comboForces = new ComboBox[]
            {
                comboBoxFxA, comboBoxFyA, comboBoxFzA, comboBoxMxA, comboBoxMyA, comboBoxMzA,
                comboBoxFxR, comboBoxFyR, comboBoxFzR, comboBoxMxR, comboBoxMyR, comboBoxMzR
            };

            linear = new TextBox[] { textBoxX, textBoxY, textBoxZ, textBoxVx, textBoxVy, textBoxVz };
            angular = new TextBox[] { textBoxOMx, textBoxOMy, textBoxOMz };
            required = new ComboBox[] { comboBoxJxx, comboBoxJyy, comboBoxJzz };

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Linked label</param>
        public FormInertia(IObjectLabel label)
            : this()
        {
            this.label = label;
            frame = label.Object as InertialReferenceFrame;
            this.LoadControlResources(Motion6D.UI.Utils.ControlUtilites.Resources);
            UpdateFormUI();
            fill();
            select();
        }

        #region IUpdatableForm Members
        
        /// <summary>
        /// Updates caption
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        void fill()
        {
            Double a = 0;
            IList<string> al = frame.GetAliases(a);
            comboState.FillCombo(al);
            IList<string> mea = frame.GetAllMeasurementsType(a);
            comboForces.FillCombo(mea);
            comboIntertia.FillCombo(mea);
            double[] inc = frame.Initial;
            linear.FillTextBoxes(inc, 0);
            angular.FillTextBoxes(inc, 7);
            fillMatrix();
        }

        void select()
        {
            string[] f = frame.Forces;
            comboForces.SelectCombo(f);
            string[] inert = frame.Inretia;
            comboIntertia.SelectCombo(inert);
            string[] st = frame.State;
            comboState.SelectCombo(st);
        }

        void accept()
        {
            try
            {
                for (int i = 0; i < required.Length; i++)
                {
                    if (required[i].SelectedItem == null)
                    {
                        WindowsExtensions.ControlExtensions.ShowMessageBoxModal("The " + req[i] + " is required");
                        return;
                    }
                }
                string[] f = comboForces.GetSelectedStringArray();
                string[] inert = comboIntertia.GetSelectedStringArray();
                string[] st = comboState.GetSelectedStringArray();
                double[] inc = frame.Initial;
                double[] lin = linear.GetDoubleTextArray();
                double[] angv = angular.GetDoubleTextArray();
                frame.Set(f, inert, st);
                norm(true);
                Array.Copy(lin, inc, 6);
                Array.Copy(angv, 0, inc, 10, 3);
            }
            catch (Exception e)
            {
                e.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }

        void fillMatrix()
        {
/*            double[] p = frame.RelativePosition;
            for (int i = 0; i < coord.Length; i++)
            {
                coord[i].Text = p[i] + "";
            }*/
            double[,] m = frame.RelativeMatrix;
            fill(m);
        }

        void fill(double[,] m)
        {
            dataSetMatrix.Tables[0].Clear();
            string[] c = new string[] { "X", "Y", "Z" };
            for (int i = 0; i < 3; i++)
            {
                object[] o = new object[] { c[i], m[i, 0], m[i, 1], m[i, 2] };
                dataSetMatrix.Tables[0].Rows.Add(o);
            }
        }

        void norm(bool save)
        {
            double[,] m = new double[3, 3];
            DataTable t = dataSetMatrix.Tables[0];
            for (int i = 0; i < t.Rows.Count; i++)
            {
                DataRow row = t.Rows[i];
                for (int j = 0; j < 3; j++)
                {
                    m[i, j] = (double)row[j + 1];
                }
            }
            Vector3D.StaticExtensionVector3D.NormMatrix(m);
            fill(m);
            if (save)
            {
                frame.RelativeMatrix = m;
            }
        }

        double[] coordinates
        {
            get
            {
                double[] p = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    p[i] = Double.Parse(linear[i].Text);
                }
                return p;
            }
        }


        private void buttonNorm_Click(object sender, EventArgs e)
        {
            try
            {
                norm(false);
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }

        }

        private void buttonAlong_Click(object sender, EventArgs e)
        {
            try
            {
                double[] p = coordinates;
                double a = Double.Parse(textBoxRot.Text);
                double[,] m = ReferenceFrame.CalucateViewMatrix(p, a);
                fill(m);
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }

        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            accept();
        }

     }
}