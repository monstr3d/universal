using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Event.Basic.Events;

namespace Event.UI.UserControls
{
    public partial class UserControlTransientProcessEvent : UserControl
    {

        #region Fields

        private TransientProcessEvent transient;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlTransientProcessEvent()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Members

        internal TransientProcessEvent Transient
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                transient = value;
                TimeSpan[] ts = transient.TimeSpans;
                for (int i = 0; i < ts.Length; i++)
                {
                    dataGridView.Rows.Add(new object[] { (i + 1) + "", ts[i].TotalSeconds + "" });
                }
                dataGridView.CellValueChanged += dataGridView_CellValueChanged;
            }
        }

        #endregion

        #region Private Members

        private void Save()
        {
            List<TimeSpan> l = new List<TimeSpan>();
            try
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    l.Add(TimeSpan.FromSeconds(double.Parse(dataGridView.Rows[i].Cells[1].Value + "")));
                }
                transient.TimeSpans = l.ToArray();
            }
            catch (Exception)
            {

            }
            if (l.Count > 0)
            {
                transient.TimeSpans = l.ToArray();
 
            }
        }


        #endregion

        #region Event Handlers

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Save();
        }

        #endregion

  
    }
}
