using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

namespace DinAtm.UI.Forms
{
    public partial class FormAtmosphereEdit : Form, IUpdatableForm
    {

        private Atmosphere atmosphere;
        private TextBox[] tb;
        private FormAtmosphereEdit()
        {
            InitializeComponent();
        }

        internal FormAtmosphereEdit(Atmosphere atmosphere)
            : this()
        {
            this.atmosphere = atmosphere;
            UpdateFormUI();
            tb = new TextBox[] { textBox1, textBox2, textBox3 };
            int[] iff = atmosphere.If;
            for (int i = 0; i < iff.Length; i++)
            {
                tb[i].Text = iff[i] + "";
            }
        }

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            CategoryTheory.IAssociatedObject ao = atmosphere as CategoryTheory.IAssociatedObject;
            object o = ao.Object;
            if (o == null)
            {
                return;
            }
            IObjectLabel l = o as IObjectLabel;
            Text = l.Name;
        }

        #endregion

        void accept()
        {
            try
            {
                int[] k = new int[3];
                for (int i = 0; i < k.Length; i++)
                {
                    k[i] = Int32.Parse(tb[i].Text);
                }
                atmosphere.If = k;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            accept();
        }
    }
}