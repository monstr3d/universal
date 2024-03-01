using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Utils;

using DataPerformer.Portable;
using DataPerformer.Event.Portable.Objects.BufferedData;
using DataPerformer.Interfaces;
using Diagram.UI.Interfaces;

namespace DataPerformer.UI.BufferedData.UserControls
{
    /// <summary>
    /// Control of buffer
    /// </summary>
    public partial class UserControlBufferReadWrite : UserControl, Diagram.UI.Interfaces.IPostSet
    {

        #region Fields

        UserControlDataBaseTreeSelect select;

        UserControlBufferReadWriteCadr cadr;

        internal BufferReadWrite buffer;

        bool suspend = false;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlBufferReadWrite()
        {
            InitializeComponent();
        }

        #endregion

        #region IPostSet Members

        void IPostSet.Post()
        {
            Fill();
        }

        #endregion

        #region Internal Members

        internal BufferReadWrite Buffer
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                buffer = value;
                if (select != null)
                {
                    select.Buffer = buffer;
                }
                checkBoxDirectory.Checked = value.DirectoryIteration;
                checkBoxDirectory.CheckedChanged += (object o, EventArgs a) =>
                { buffer.DirectoryIteration = checkBoxDirectory.Checked; };
                Fill();
                (buffer as IDataConsumer).OnChangeInput += Fill;
                dataGridView.CellValueChanged += dataGridView_CellValueChanged;
                dataGridView.RowsRemoved += dataGridView_RowsRemoved;
            }
        }


        #endregion

        #region Private Members

    
        /// <summary>
        /// Fills the input rows in the buffer.
        /// 
        /// !!! Fails to refresh the rows when the objects are deleted as well as redefine the visible inputs unless Enter key is explicitly pressed
        /// </summary>
        void Fill()
        {
            suspend = true;
            try
            {
                dataGridView.Rows.Clear();
                Dictionary<string, IMeasurement> d = buffer.GetAllMeasurementsByName();
                List<string> l = new List<string>(d.Keys);
                ColumnMeasurement.Items.Clear();
                foreach (string key in d.Keys)
                {
                    ColumnMeasurement.Items.Add(key);
                }
                List<string> input = buffer.Input; //for an elegant solution, buffer.Input has to be changed here
                List<string> li = new List<string>(input);
                li.Sort();
                for (int i = 0; i < li.Count; i++)
                {
                    //Perhaps not the most elegant solution (as the use of 'suspend' itself)  but forces the inputs in the buffer to be filled at the last step
                    if (i == li.Count - 1)
                    {
                        suspend = false;
                    } 

                    string v = li[i]; // !!! was: "string v = l[i];". Seems to have caused bugs
                    if (!d.ContainsKey(v))
                    {
                        continue;
                    }
                    dataGridView.Rows.Add();
                    dataGridView.Rows[i].Cells[0].Value = v;
                }
            }
            catch
            {

            }
            suspend = false;
        }

        void SetInput()
        {
            try
            {
               
                List<string> l = new List<string>();
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Cells == null)
                    {
                        break;
                    }
                    object o = row.Cells[0].Value;
                    if (o == null)
                    {
                        break;
                    }
                    l.Add(o + "");
                }
                l.Sort();

                //This line is superfluous when an IMeasurements is disconnected from the buffer.
                //Yet (for now) cannot be removed altogether, since it becomes useful when new inputs are added.
                //A clever remodelling of Fill() may be considered.
                buffer.Input = l; 
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }

        #endregion

        #region Event handlers

        private void UserControlBufferReadWrite_Load(object sender, EventArgs e)
        {
            select = new UserControlDataBaseTreeSelect();
            select.Dock = DockStyle.Fill;
            panelData.Controls.Add(select);
            if (buffer != null)
            {
                select.Buffer = buffer;
            }
            cadr = new UserControlBufferReadWriteCadr();
            cadr.Dock = DockStyle.Fill;
            panelCadr.Controls.Add(cadr);
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            buffer.Write();
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (suspend)
            {
                return;
            }
            SetInput();
        }

        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (suspend)
            {
                return;
            }
            SetInput();
        }


        private void showIndicatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlBufferReadWriteCadr uc = this.FindChild<UserControlBufferReadWriteCadr>();
            uc.ShowIndicators();
        }

        #endregion

    }
}
