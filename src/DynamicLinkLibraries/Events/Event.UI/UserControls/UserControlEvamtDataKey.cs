using BaseTypes;
using ErrorHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Event.UI.UserControls
{
    public partial class UserControlEvamtDataKey : UserControl
    {
        #region Fields

        List<Tuple<string, string?, object>> types = new();

        event Action<List<Tuple<string, string?, object>>> onChange = (List<Tuple<string, string?, object>> types) => { };

        #endregion

        #region Ctor

        public UserControlEvamtDataKey()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Members

        /// <summary>
        /// Types
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Tuple<string, string?, object>> Types
        {
            get
            {
                Get();
                return types;
            }
            set
            {
                types = value;
                Set();
            }
        }

        /// <summary>
        /// On change event
        /// </summary>
        public event Action<List<Tuple<string, string?, object>>> OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        #region Private Membrers

        void Set()
        {
            foreach (Tuple<string, string?, object> t in types)
            {
                dataGridView.Rows.Add(new object[] { t.Item1, t.Item2.ToEnumType() });
            }
        }

        void Get()
        {
            try
            {
                List<Tuple<string, string?, object>> types = new List<Tuple<string, string?, object>>();
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    object type = row.Cells[2].Value;
                    object val = row.Cells[0].Value;
                    object val1 = row.Cells[1].Value;
                    if ((type == null) | (val == null))
                    {
                        continue;
                    }
                    string? s = (val1 == null) ? null : val1.ToString();

                    Tuple<string, string?, object> t = new Tuple<string, string?, object>(val + "", s,                        ((EnumType)type).ToType());
                    types.Add(t);
                }
                this.types = types;
                onChange(this.types);
            }
            catch (Exception exception)
            {
                exception.HandleException();
                return;
            }
        }

        #endregion



        #region Event Handlers

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        #endregion
    }
}
