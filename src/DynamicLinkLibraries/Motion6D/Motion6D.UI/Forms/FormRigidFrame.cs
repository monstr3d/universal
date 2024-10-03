using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Motion6D;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

namespace Motion6D.UI.Forms
{
   /// <summary>
   /// Editor of properties of rigid frame
   /// </summary>
    public partial class FormRigidFrame : Form, IUpdatableForm
    {
        private IObjectLabel label;
        RigidReferenceFrame frame;
        private TextBox[] coord;

        private FormRigidFrame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Object label</param>
        public FormRigidFrame(IObjectLabel label)
        {
            InitializeComponent();
            this.label = label;
            frame = label.Object as RigidReferenceFrame;
            Text = label.Name;
            coord = new TextBox[] { textBoxX, textBoxY, textBoxZ };
            Fill();
        }

        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
           Text = label.Name;
        }

        #endregion


        #region Private Members

        void Fill()
        {
            double[] p = frame.RelativePosition;
            for (int i = 0; i < coord.Length; i++)
            {
                coord[i].Text = p[i] + "";
            }
            double[,] m = frame.RelativeMatrix;
            Fill(m);
        }

        void Fill(double[,] m)
        {
            dataSetMatrix.Tables[0].Clear();
            string[] c = new string[] { "X", "Y", "Z" };
            for (int i = 0; i < 3; i++)
            {
                object[] o = new object[] { c[i], m[i, 0], m[i, 1], m[i, 2] };
                dataSetMatrix.Tables[0].Rows.Add(o);
            }
        }

        void Norm(bool save)
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
            Fill(m);
            if (save)
            {
                frame.RelativeMatrix = m;
            }
        }

        double[] Coordinates
        {
            get
            {
                double[] p = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    p[i] = Double.Parse(coord[i].Text);
                }
                return p;
            }
        }

        #endregion

        #region Event Handles

        private void buttonNorm_Click(object sender, EventArgs e)
        {
            try
            {
                Norm(false);
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                Norm(true);
                double[] p = frame.RelativePosition;
                for (int i = 0; i < 3; i++)
                {
                    p[i] = Double.Parse(coord[i].Text);
                }
                frame.Init();
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
                double[] p = Coordinates;
                double a = Double.Parse(textBoxRot.Text);
                double[,] m = Interfaces.ReferenceFrame.CalucateViewMatrix(p, a);
                Fill(m);
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        #endregion

    }
}