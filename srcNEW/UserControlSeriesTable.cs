using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Table of series
    /// </summary>
    public partial class UserControlSeriesTable : UserControl
    {

        #region Fields

        Action<bool> showTable = delegate(bool b)
        {
            
        };

        Action update = delegate()
    {
    };
        Series series;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlSeriesTable()
        {
            InitializeComponent();
            foreach (DataGridViewColumn column in seriesGrid.Columns)
            {
                var cm = new ContextMenuStrip();
                ToolStripMenuItem paste = new ToolStripMenuItem("Paste");
                cm.Items.Add(paste);


                column.ContextMenuStrip = cm;
                column.ContextMenuStrip.Items.Add(paste);

                paste.Click += (object sender, EventArgs e) =>
                {
                    Paste(column);
                };
            }
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Update event
        /// </summary>
        new public event Action Update
        {
            add { update += value; }
            remove { update -= value; }
        }

        /// <summary>
        /// Show table event
        /// </summary>
        public event Action<bool> ShowTable
        {
            add { showTable += value; }
            remove { showTable -= value; }
        }


        /// <summary>
        /// The "Show" sign
        /// </summary>
        new public bool Show
        {
            set
            {
                if (!value)
                {
                    table.Rows.Clear();
                }
                else
                {
                    if (table.Rows.Count == 0)
                    {
                        FillTable();
                    }
                }
                showTable(value);
            }
        }

        internal void FillTable(bool check)
        {
            if (!check)
            {
                return;
            }
            table.Rows.Clear();
            FillTable();
        }

   
        void FillTable()
        {
            int n = series.Count;
            for (int i = 0; i < n; i++)
            {
                object[] o = new object[2];
                for (int j = 0; j < 2; j++)
                {
                    o[j] = series[i, j];
                }
                table.Rows.Add(o);
            }
        }

        /// <summary>
        /// Updates table
        /// </summary>
        public void UpdateTable()
        {
            seriesGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            series.Clear();
            foreach (DataRow row in table.Rows)
            {
                series.AddXY((double)row[0], (double)row[1]);
            }
            update();
        }

        /// <summary>
        /// Series of control
        /// </summary>
        public Series Series
        {
            get
            {
                return series;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                series = value;
            }
        }

        #endregion

        internal void DisableEdit()
        {
            seriesGrid.AllowUserToAddRows = false;
            dataColumn1.ReadOnly = true;
            dataColumn2.ReadOnly = true;
        }

        private void Paste(DataGridViewColumn column)
        {
            IDataObject dob = Clipboard.GetDataObject();
            var p = dob.GetData("System.String");
            if (p == null)
            {
                return;
            }
            var s = p + "";
            double[] x;
            s.LoadFromString(out x);
            var table = seriesData.Tables[0];
            int i = 0;
            var j = (column == seriesGrid.Columns[0]) ? 0 : 1;
            var k = 1 - j;
            for (; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                row[j] = x[i];
            }
            for (; i < x.Length; i++)
            {
                var row = table.NewRow();
                row[j] = x[i];
                row[k] = 0;
                table.Rows.Add(row);
            }
            UpdateTable();
        }
    }
}
