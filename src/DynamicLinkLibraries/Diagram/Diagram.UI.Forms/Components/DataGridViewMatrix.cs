using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using ErrorHandler;

namespace Diagram.UI.Components
{
    /// <summary>
    /// Data grid for matrix edition
    /// </summary>
    public class DataGridViewMatrix : DataGridView
    {
        #region

        event Action<int, int, object> action = (int i, int j, object value) => { };

        #endregion


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataGridViewMatrix()
        {
        }

        #endregion


        #region Members

        /// <summary>
        /// Matrix
        /// </summary>
        public double[,] RealMatrix
        {
            set
            {
                try
                {
                    if (value == null)
                    {
                        return;
                    }
                    Rows.Clear();
                    DataGridViewTextBoxColumn dataColumnRow = new DataGridViewTextBoxColumn();
                    dataColumnRow.HeaderText = "Row";
                    dataColumnRow.Name = "Row";
                    dataColumnRow.ReadOnly = true;

                    Columns.Add(dataColumnRow);
                    for (int i = 0; i < value.GetLength(0); i++)
                    {
                        DataGridViewTextBoxColumn c = CreateTextColumn(i);
                        Columns.Add(c);
                    }
                    for (int i = 0; i < value.GetLength(1); i++)
                    {
                        object[] o = new object[value.GetLength(0) + 1];
                        o[0] = i + "";
                        for (int j = 0; j < value.GetLength(0); j++)
                        {
                            o[j + 1] = value[i, j] + "";
                        }
                        Rows.Add(o);
                    }
                }
                catch (Exception ex)
                {
                    ex.HandleException(10);
                }

            }
        }

        /// <summary>
        /// Accepts matrix
        /// </summary>
        public void Accept()
        {
            int n = Rows.Count;
            int k = Columns.Count - 1;
            for (int i = 0; i < n; i++)
            {
                DataGridViewRow row = Rows[i];
                for (int j = 0; j < k; j++)
                {
                    object o = row.Cells[j + 1].Value;
                    action(i, j, o);
                }
            }
        }

        /// <summary>
        /// Edit action
        /// </summary>
        public event Action<int, int, object> Action
        {
            add
            {
                action += value;
            }
            remove
            {
                action -= value;
            }
        }


        private DataGridViewTextBoxColumn CreateTextColumn(int i)
        {
            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
            c.HeaderText = (i + 1) + "";
            return c;
        }


        #endregion
    }
}
