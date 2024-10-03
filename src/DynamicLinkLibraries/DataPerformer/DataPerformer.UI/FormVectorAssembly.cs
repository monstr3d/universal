using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;


namespace DataPerformer.UI
{
    /// <summary>
    /// Editor of properties of vector assembly
    /// </summary>
    public partial class FormVectorAssembly : Form, IUpdatableForm
    {
        private IObjectLabel label;
        private VectorAssembly vector;
        const Double a = 0;
        private Panel workPanel;
        private ComboBox[] boxes;
        private int knum;


        private FormVectorAssembly()
        {
            InitializeComponent();
            workPanel = panelCenter;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Object label</param>
        public FormVectorAssembly(IObjectLabel label)
            : this()
        {
            InitializeComponent();
            this.label = label;
            UpdateFormUI();
            vector = label.Object as VectorAssembly;
            string[] names = vector.Names;
            if (names == null)
            {
                return;
            }
            numericUpDownRows.Value = names.Length;
            set();
            select();
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


        void select()
        {
            string[] n = vector.Names;
            if (n == null)
            {
                return;
            }
            for (int i = 0; i < boxes.Length; i++)
            {
                string s = n[i];
                ComboBox box = boxes[i];
                for (int k = 0; k < box.Items.Count; k++)
                {
                    string sb = box.Items[k] + "";
                    if (s.Equals(sb))
                    {
                        box.SelectedIndex = k;
                        break;
                    }
                }
            }
        }

        void set()
        {
            if (boxes != null)
            {
                for (int i = 0; i < boxes.Length; i++)
                {
                    workPanel.Controls.Remove(boxes[i]);
                }
            }
            IList<string> n = vector.GetAllMeasurementsType(a);
            int rows = knum;
            boxes = new ComboBox[rows];
            int x = 10;
            int y = 20;
            for (int i = 0; i < rows; i++)
            {
                ComboBox box = new ComboBox();
                box.FillCombo(n);
                box.Left = x;
                box.Top = y;
                workPanel.Controls.Add(box);
                boxes[i] = box;
                y = boxes[i].Bottom + 5;
            }
        }


        void accept()
        {
            if (boxes == null)
            {
                return;
            }
            string[] n = new string[boxes.Length];
            for (int i = 0; i < n.Length; i++)
            {
                ComboBox box = boxes[i];
                if (box.SelectedIndex < 0)
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal(i + " ");
                    return;
                }
                n[i] = box.SelectedItem + "";
            }
            vector.Names = n;
        }



        private void buttonAccDim_Click(object sender, EventArgs e)
        {
            set();
        }


        private void buttonAccept_Click(object sender, EventArgs e)
        {
            accept();
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = sender as NumericUpDown;
            knum = (int)n.Value;
        }

     }
}