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
    /// Editor of matrix assembly properties
    /// </summary>
    public partial class FormMatrixAssembly : Form, IUpdatableForm
    {
        private IObjectLabel label;
        private MatrixAssembly matrix;
        const Double a = 0;
        private Panel workPanel;
        private ComboBox[,] boxes;
        private int[] knum = new int[2];


        private FormMatrixAssembly()
        {
            InitializeComponent();
            workPanel = panelCenter;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Object label</param>
        public FormMatrixAssembly(IObjectLabel label)
            : this()
        {
            this.label = label;
            UpdateFormUI();
            matrix = label.Object as MatrixAssembly;
            string[,] names = matrix.Names;
            if (names == null)
            {
                return;
            }
            numericUpDownRows.Value = names.GetLength(0);
            numericUpDownColumns.Value = names.GetLength(1);
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
            string[,] n = matrix.Names;
            if (n == null)
            {
                return;
            }
            for (int i = 0; i < boxes.GetLength(0); i++)
            {
                for (int j = 0; j < boxes.GetLength(1); j++)
                {
                    string s = n[i, j];
                    ComboBox box = boxes[i, j];
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
        }

        void set()
        {
            if (boxes != null)
            {
                for (int i = 0; i < boxes.GetLength(0); i++)
                {
                    for (int j = 0; j < boxes.GetLength(1); j++)
                    {
                        workPanel.Controls.Remove(boxes[i, j]);
                    }
                }
            }
            IList<string> n = matrix.GetAllMeasurementsType(a);
            int rows = knum[0];
            int columns = knum[1];
            boxes = new ComboBox[rows, columns];
            int x = 10;
            int y = 20;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    ComboBox box = new ComboBox();
                    box.FillCombo(n);
                    box.Left = x;
                    box.Top = y;
                    x = box.Right + 10;
                    workPanel.Controls.Add(box);
                    boxes[i, j] = box;
                }
                if (columns > 0)
                {
                    y = boxes[i, 0].Bottom + 5;
                }
                x = 10;
            }
        }


        void accept()
        {
            if (boxes == null)
            {
                return;
            }
            string[,] n = new string[boxes.GetLength(0), boxes.GetLength(1)];
            for (int i = 0; i < n.GetLength(0); i++)
            {
                for (int j = 0; j < n.GetLength(1); j++)
                {
                    ComboBox box = boxes[i, j];
                    if (box.SelectedIndex < 0)
                    {
                        WindowsExtensions.ControlExtensions.ShowMessageBoxModal(i + " " + j);
                        return;
                    }
                    n[i, j] = box.SelectedItem + "";
                }
            }
            matrix.Names = n;
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
            knum[0] = (int)n.Value;
        }

        private void numericUpDownColumns_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = sender as NumericUpDown;
            knum[1] = (int)n.Value;
        }
    }
}