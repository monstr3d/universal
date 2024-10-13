using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Utils;

using Motion6D.Portable.Aggregates;

using Vector3D;

namespace Motion6D.UI.UserControls
{
    public partial class UserControlRigidBody : UserControl
    {

        #region Fields

        Vector3DProcessor vp = new();

        private RigidBody rigid;

        private ComboBox[] comboAli;

        private ComboBox[] comboForces;

        private ComboBox[] comboInertial;

        private TextBox[][] moments;

        private TextBox[] linear;
        private TextBox[] angular;


        private bool entered = false;



        #endregion

        public UserControlRigidBody()
        {
            InitializeComponent();
        }

        #region Public Members

        public RigidBody RigidBody
        {
            set
            {
                rigid = value;
                createCombo();
                fillText();
                fillInitial();
                fillTable();
            }
        }

        #endregion

        #region Private Members

        void createCombo()
        {
            comboAli = new ComboBox[] {comboBoxXA, comboBoxYA, comboBoxZA,
                comboBoxVxA, comboBoxVyA, comboBoxVzA,
                comboBoxQ0, comboBoxQ1, comboBoxQ2, comboBoxQ3,
                comboBoxOMx, comboBoxOMy, comboBoxOMz};
            comboForces = new ComboBox[]  { comboBoxFxA, comboBoxFyA, comboBoxFzA,
                comboBoxMxA, comboBoxMyA, comboBoxMzA};

            comboInertial = new ComboBox[] { comboBoxFxR, comboBoxFyR, comboBoxFzR };
            fillCombo();
        }

        void fillCombo()
        {
            ICollection<string> ali = rigid.AllAliases;
            comboAli.FillCombo( ali);
            ICollection<string> mea = rigid.AllMeasurements;
            comboForces.FillCombo( mea);
            comboInertial.FillCombo(mea);
            selectCombo();
        }

        void selectCombo()
        {
            comboAli.SelectCombo(rigid.AliasNames);
            comboForces.SelectCombo( rigid.Forces);
            comboInertial.SelectCombo(rigid.Inretial);
        }

        void fillText()
        {
            moments = new TextBox[3][];
            moments[0] = new TextBox[] { textBoxJxx, textBoxJxy, textBoxJxz };
            moments[1] = new TextBox[] { textBoxJyy, textBoxJyz };
            moments[2] = new TextBox[] { textBoxJzz };

            double[,] m = rigid.MomentOfInertia;
            for (int i = 0; i < 3; i++)
            {
                TextBox[] tb = moments[i];
                for (int j = 0; j < tb.Length; j++)
                {
                    tb[j].Text = m[i, j + i] + "";
                }
            }
            textBoxMass.Text = rigid.Mass + "";
            linear = new TextBox[] { textBoxX, textBoxY, textBoxZ, textBoxVx, textBoxVy, textBoxVz };
            angular = new TextBox[] { textBoxOMx, textBoxOMy, textBoxOMz };

        }

        void fillInitial()
        {
            double[] init = rigid.InitialState;
            double[] q = new double[4];
            Array.Copy(init, 6, q, 0, 4);
            double[,] m = new double[3, 3];
            double[,] qq = new double[4, 4];
           vp.QuaternionToMatrix(q, m, qq);
            fillMatrix(m);
            for (int i = 0; i < 6; i++)
            {
                linear[i].Text = init[i] + "";
            }
            for (int i = 0; i < 3; i++)
            {
                angular[i].Text = init[i + 10] + "";
            }
            EulerAngles angles = new EulerAngles();
            vp.Set(angles, q);
            textBoxRoll.Text = angles.roll + "";
            textBoxPitch.Text = angles.pitch + "";
            textBoxYaw.Text = angles.yaw + "";
        }

        void fillFromEuler()
        {
            double roll = double.Parse(textBoxRoll.Text);
            double pitch = double.Parse(textBoxPitch.Text);
            double yaw = double.Parse(textBoxYaw.Text);
            EulerAngles angles = new EulerAngles(roll, pitch, yaw);
            double[] q = new double[4];
            vp.ToQuaternion(angles, q);
            double[,] m = new double[3, 3];
            double[,] qq = new double[4, 4];
            vp.QuaternionToMatrix(q, m, qq);
            fillMatrix(m);
        }


        void fillMatrix(double[,] m)
        {
            DataTable table = dataSetMatrix.Tables[0];
            table.Clear();
            string[] c = new string[] { "X", "Y", "Z" };
            for (int i = 0; i < 3; i++)
            {
                object[] o = new object[] { c[i], m[i, 0], m[i, 1], m[i, 2] };
                table.Rows.Add(o);
            }
        }

        void norm()
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
            vp.NormMatrix(m);
            fillMatrix(m);
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



        void fillTable()
        {
            int n = rigid.NumberOfConnections;
            entered = true;
            for (int i = 0; i < n; i++)
            {
                DataRow row = dataTableConnections.NewRow();
                row[0] = i + 1;
                double[] conn = rigid.GenConnection(i);
                for (int j = 0; j < conn.Length; j++)
                {
                    row[j + 1] = conn[j];
                }
                dataTableConnections.Rows.Add(row);
            }
            entered = false;
        }

        void accept()
        {
            double[,] m = new double[3, 3];

            for (int i = 0; i < 3; i++)
            {
                TextBox[] tb = moments[i];
                for (int j = i; j < 3; j++)
                {
                    double a = Double.Parse(tb[j - i].Text);
                    m[i, j] = a;
                    m[j, i] = a;
                }
            }
            double mass = Double.Parse(textBoxMass.Text);
            string[] inert = comboInertial.GetSelectedStringArray();
            string[] forces = comboForces.GetSelectedStringArray();
            Dictionary<int, string> dic = comboAli.GetSelectedDictionary();
            double[] inc = new double[13];
            double[] lin = linear.GetDoubleTextArray();
            double[] ang = angular.GetDoubleTextArray();
            Array.Copy(lin, inc, 6);
            Array.Copy(ang, 0, inc, 10, 3);
            norm();
            double[,] mo = new double[3, 3];
            DataTable t = dataSetMatrix.Tables[0];
            for (int i = 0; i < t.Rows.Count; i++)
            {
                DataRow row = t.Rows[i];
                for (int j = 0; j < 3; j++)
                {
                    mo[i, j] = (double)row[j + 1];
                }
            }
            double[] q = new double[4];
            double[,] qq = new double[4, 4];
            vp.MatrixToQuaternion(mo, q);
            Array.Copy(q, 0, inc, 6, 4);
            double[][] conn = null;
            normConnections();
            int n = dataTableConnections.Rows.Count;
            if (n > 0)
            {
                conn = new double[n][];
            }
            for (int i = 0; i < n; i++)
            {
                double[] a = new double[7];
                conn[i] = a;
                DataRow row = dataTableConnections.Rows[i];
                for (int j = 0; j < a.Length; j++)
                {
                    a[j] = (double)row[j + 1];
                }
                double b = 0;
                for (int j = 3; j < 7; j++)
                {
                    double x = a[j];
                    b += x * x;
                }
                b = 1 / Math.Sqrt(b);
                for (int j = 3; j < 7; j++)
                {
                    a[j] *= b;
                }
            }
            rigid.Set(dic, forces, inert, conn, m, mass, inc);
        }

        private void normConnections()
        {
            entered = true;
            List<DataRow> l = new List<DataRow>();
            foreach (DataRow row in dataTableConnections.Rows)
            {
                l.Add(row);
            }
            foreach (DataRow row in l)
            {
                double a = 0;
                for (int i = 4; i < 8; i++)
                {
                    double b = (double)row[i];
                    a += b * b;
                }
                a = 1 / Math.Sqrt(a);
                for (int i = 4; i < 8; i++)
                {
                    double b = (double)row[i];
                    row[i] = b * a;
                }
            }
            entered = false;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            accept();
        }

        private void dataGridViewConnections_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (entered)
            {
                return;
            }
            normConnections();
        }

        private void buttonNorm_Click(object sender, EventArgs e)
        {
            try
            {
                norm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAlong_Click(object sender, EventArgs e)
        {
            try
            {
                double[] p = coordinates;
                double a = Double.Parse(textBoxRot.Text);
                double[,] m = Motion6D.Interfaces.ReferenceFrame.CalucateViewMatrix(p, a);
                fillMatrix(m);
            }
            catch (Exception)
            {
            }

        }

        private void buttonSetEuler_Click(object sender, EventArgs e)
        {
            try
            {
                fillFromEuler();
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }

        #endregion

    }
}
