using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Diagram.UI.Utils;
using Diagram.UI.Aliases;
using ErrorHandler;

namespace Diagram.UI
{
    /// <summary>
    /// Standard alias editor
    /// </summary>
    public partial class FormStandardAliasEditor : Form
    {
        private PropertyEditors.AliasItem item;

        private int[] dim;

        private object bt = null;


        private static readonly Double d = 0;

        private static readonly Boolean b = false;

        private static readonly Single f = 0;


        private static readonly Int32 i = 0;


        private FormStandardAliasEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">The item</param>
        public FormStandardAliasEditor(PropertyEditors.AliasItem item)
            : this()
        {
            this.LoadControlResources(ControlUtilites.Resources);
            this.item = item;
            Text = Text + " [" + item.Name + "]";
            bt = AliasTypeDetector.Detector.DetectType(item.Value);
            dim = AliasTypeDetector.Detector.GetDimension(bt);
            if (dim != null)
            {
                bt = AliasTypeDetector.Detector.GetBaseType(bt);
            }
            Set();
            fill();
        }


        object itemType
        {
            get
            {
                return item.Alias.GetType(item.Name);
            }
        }

        object itemValue
        {
            get
            {
                return item.Alias[item.Name];
            }
            set
            {
                item.Alias[item.Name] = value;
            }
        }



        private object Type
        {
            get
            {
                return bt;
            }
            set
            {
                bt = value;
                checkBoxBool.Visible = false;
                textValue.Visible = false;
                userControlDateTime.Visible = false;
                if (value.Equals(b))
                {
                    checkBoxBool.Visible = true;
                }
                else if (value.Equals(BaseTypes.FixedTypes.DateTimeType))
                {
                    userControlDateTime.Visible = true;
                }
                else
                {
                    textValue.Visible = true;
                }

            }
        }


        void Set()
        {
            Type = bt;
            if (dim == null)
            {
                tabInput.SelectTab(tabSimple);
                return;
            }
            if (dim.Length == 1)
            {
                tabInput.SelectTab(tabVector);
                numericUpDownDim.Value = dim[0];
            }
            if (dim.Length == 2)
            {
                tabInput.SelectTab(tabMatrix);
                numericUpDownRows.Value = dim[0];
                numericUpDownColumns.Value = dim[1];
                return;
            }
        }

        object val
        {
            get
            {
                if (dim == null)
                {
                    if (bt.Equals(b))
                    {
                        return checkBoxBool.Checked;
                    }
                    if (bt.Equals(d))
                    {
                        return Double.Parse(textValue.Text);
                    }
                    if (bt.Equals(i))
                    {
                        return Int32.Parse(textValue.Text);
                    }
                    if (bt.Equals(""))
                    {
                        return textValue.Text;
                    }
                    if (bt.Equals(BaseTypes.FixedTypes.DateTimeType))
                    {
                        return userControlDateTime.DateTime;
                    }
                    if (bt.Equals(f))
                    {
                        return Single.Parse(textValue.Text);
                    }
                }
                if (dim.Length == 1)
                {
                    return vectValue;
                }
                if (dim.Length == 2)
                {
                    return matrValue;
                }
                return null;
            }
        }

        object vectValue
        {
            get
            {
                if (bt.Equals(b))
                {
                    bool[] bo = new bool[dim[0]];
                    for (int i = 0; i < bo.Length; i++)
                    {
                       DataGridViewRow row = dataGridViewVector.Rows[i];
                       bo[i] = (bool)row.Cells[1].FormattedValue;
                    }
                    return bo;
                }
                if (bt.Equals(d))
                {
                    double[] dd = new double[dim[0]];
                    for (int i = 0; i < dd.Length; i++)
                    {
                        DataGridViewRow row = dataGridViewVector.Rows[i];
                        dd[i] = Double.Parse(row.Cells[1].FormattedValue + "");
                    }
                    return dd;
                }
                if (bt.Equals(FormStandardAliasEditor.i))
                {
                    int[] ii = new int[dim[0]];
                    for (int i = 0; i < ii.Length; i++)
                    {
                        DataGridViewRow row = dataGridViewVector.Rows[i];
                        ii[i] = Int32.Parse(row.Cells[1].FormattedValue + "");
                    }
                    return ii;
                }
                if (bt.Equals(f))
                {
                    float[] ff = new float[dim[0]];
                    for (int i = 0; i < ff.Length; i++)
                    {
                        DataGridViewRow row = dataGridViewVector.Rows[i];
                        ff[i] = Single.Parse(row.Cells[1].FormattedValue + "");
                    }
                    return ff;
                }
                return null;
            }
        }


        object matrValue
        {
            get
            {
                if (bt.Equals(b))
                {
                    bool[,] bo = new bool[dim[0], dim[1]];
                    for (int i = 0; i < bo.GetLength(0); i++)
                    {
                        DataGridViewRow row = dataGridViewMatrix.Rows[i];
                        for (int j = 0; j < bo.GetLength(1); j++)
                        {
                            bo[i, j] = (bool)row.Cells[j + 1].FormattedValue;
                        }
                    }
                    return bo;
                }
                if (bt.Equals(d))
                {
                    double[,] dd = new double[dim[0], dim[1]];
                    for (int i = 0; i < dd.GetLength(0); i++)
                    {
                        DataGridViewRow row = dataGridViewMatrix.Rows[i];
                        for (int j = 0; j < dd.GetLength(1); j++)
                        {
                            dd[i, j] = Double.Parse(row.Cells[j + 1].FormattedValue + "");
                        }
                    }
                    return dd;
                }
                if (bt.Equals(FormStandardAliasEditor.i))
                {
                    int[,] ii = new int[dim[0], dim[1]];
                    for (int i = 0; i < ii.GetLength(0); i++)
                    {
                        DataGridViewRow row = dataGridViewMatrix.Rows[i];
                        for (int j = 0; j < ii.GetLength(1); j++)
                        {
                            ii[i, j] = Int32.Parse(row.Cells[j + 1].FormattedValue + "");
                        }
                    }
                    return ii;
                }
                if (bt.Equals(f))
                {
                    float[,] ff = new float[dim[0], dim[1]];
                    for (int i = 0; i < ff.GetLength(0); i++)
                    {
                        DataGridViewRow row = dataGridViewMatrix.Rows[i];
                        for (int j = 0; j < ff.GetLength(1); j++)
                        {
                            ff[i, j] = Single.Parse(row.Cells[j + 1].FormattedValue + "");
                        }
                    }
                }
                return null;
            }
        }

        void defaultFill()
        {
            clearGrids();
            if (dim == null)
            {
                return;
            }
            if (dim.Length == 1)
            {
                defaultFillVector();
            }
            if (dim.Length == 2)
            {
                defaultFillMatrix();
            }
        }

        void fill()
        {
            if (bt.Equals(d))
            {
                comboBoxType.SelectedIndex = 0;
            }
            if (bt.Equals(i))
            {
                comboBoxType.SelectedIndex = 1;
            }
            if (bt.Equals(b))
            {
                comboBoxType.SelectedIndex = 2;
            }
            if (bt.Equals(""))
            {
                  comboBoxType.SelectedIndex = 3;
            }
            if (bt.Equals(BaseTypes.FixedTypes.DateTimeType))
            {
                comboBoxType.SelectedIndex = 4;
            }
            if (bt.Equals(f))
            {
                comboBoxType.SelectedIndex = 5;
            }
            clearGrids();
            if (dim == null)
            {
                object t = Type;
                if (t.Equals(b))
                {
                    checkBoxBool.Checked = (bool)item.Value;
                }
                else if (t.Equals(BaseTypes.FixedTypes.DateTimeType))
                {
                    userControlDateTime.DateTime = (DateTime)item.Value;
                }
                else
                {
                    textValue.Text = item.Value + "";
                }
                return;
            }
            if (dim.Length == 1)
            {
                fillVector();
            }
            if (dim.Length == 2)
            {
                fillMatrix();
            }
        }


        void defaultFillVector()
        {
            DataGridViewColumn c = newColumn;
            dataGridViewVector.Columns.Add(c);
            for (int k = 0; k < dim[0]; k++)
            {
                object[] o = new object[] { (k + 1) + "", bt };
                dataGridViewVector.Rows.Add(o);
            }
        }

        void fillVector()
        {
            Array arr = item.Value as Array;
            DataGridViewColumn c = newColumn;
            dataGridViewVector.Columns.Add(c);
            for (int i = 0; i < arr.Length; i++)
            {
                object[] o = new object[] { (i + 1) + "", arr.GetValue(i) };
                dataGridViewVector.Rows.Add(o);

            }
        }

        void defaultFillMatrix()
        {
            for (int k = 0; k < dim[1]; k++)
            {
                DataGridViewColumn dc = createColumn(k);
                dataGridViewMatrix.Columns.Add(dc);
            }
            for (int k = 0; k < dim[0]; k++)
            {
                object[] o = new object[dim[1] + 1];
                o[0] = (k + 1) + "";
                for (int l = 0; l < dim[1]; l++)
                {
                    o[l + 1] = bt;
                }
                dataGridViewMatrix.Rows.Add(o);
            }
        }


        void fillMatrix()
        {
            Array arr = item.Value as Array;
            for (int k = 0; k < dim[1]; k++)
            {
                DataGridViewColumn dc = createColumn(k);
                dataGridViewMatrix.Columns.Add(dc);
            }
            int[] n = new int[2];
            for (int k = 0; k < dim[0]; k++)
            {
                object[] o = new object[dim[1] + 1];
                o[0] = (k + 1) + "";
                n[0] = k;
                for (int l = 0; l < dim[1]; l++)
                {
                    n[1] = l;
                    o[l + 1] = arr.GetValue(n);
                }
                dataGridViewMatrix.Rows.Add(o);
            }

        }


        void clearGrids()
        {
            for (int k = dataGridViewMatrix.ColumnCount - 1; k > 0; k--)
            {
                dataGridViewMatrix.Columns.RemoveAt(k);
            }
            if (dataGridViewVector.Columns.Count == 2)
            {
                dataGridViewVector.Columns.RemoveAt(1);
            }
            dataGridViewMatrix.Rows.Clear();
            dataGridViewVector.Rows.Clear();
        }

        private DataGridViewColumn createColumn(int i)
        {
            DataGridViewColumn c = newColumn;
            c.HeaderText = (i + 1) + "";
            return c;
        }


        private DataGridViewColumn newColumn
        {
            get
            {
                if (bt.Equals(b))
                {
                    return new DataGridViewCheckBoxColumn();
                }
                return new DataGridViewTextBoxColumn();
            }
         }


        void defOld()
        {
            if (dim == null)
            {
                   return;
            }
            IList<DataColumn> lc = new List<DataColumn>();
            foreach (DataColumn dc in dataTable.Columns)
            {
                if (dc != dataColumnRow)
                {
                    lc.Add(dc);
                }
            }
            foreach (DataColumn dc in lc)
            {
                dataTable.Columns.Remove(dc);
            }
            Type type = bt.GetType();
            for (int k = 0; k < dim[1]; k++)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = (k + 1) + "";
                dc.DataType = type;
                dataTable.Columns.Add(dc);
            }
            for (int k = 0; k < dim[1]; k++)
            {
                object[] o = new object[dim[1] + 1];
                o[0] = (k + 1) + "";
                for (int l = 0; l < dim[1]; l++)
                {
                    o[l + 1] = bt;
                }
                dataTable.Rows.Add(o);
            }
            dataGridViewMatrix.Refresh();


        }


        object selectedType
        {
            get
            {
                if (tabInput.SelectedTab == tabSimple)
                {
                    dim = null;
                }
                if (tabInput.SelectedTab == tabVector)
                {
                    dim = new int[] { (int)numericUpDownDim.Value };
                }
                if (tabInput.SelectedTab == tabMatrix)
                {
                    dim = new int[] { (int)numericUpDownRows.Value, (int)numericUpDownColumns.Value };
                }
                int j = comboBoxType.SelectedIndex;
                if (j == 0)
                {
                    return d;
                }
                if (j == 1)
                {
                    return i;
                }
                if (j == 3)
                {
                    return "";
                }
                if (j == 4)
                {
                    return BaseTypes.FixedTypes.DateTimeType;
                }
                if (j == 5)
                {
                    return f;
                }
                return b;
            }
        }


        private void buttonApplyType_Click(object sender, EventArgs e)
        {
            bt = selectedType;
            Set();
            defaultFill();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                itemValue = val;
                Close();
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

   
    }
}