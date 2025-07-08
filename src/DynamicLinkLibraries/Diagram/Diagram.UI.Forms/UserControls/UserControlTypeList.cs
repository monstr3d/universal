using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BaseTypes;
using ErrorHandler;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// Editor of type list
    /// </summary>
    public partial class UserControlTypeList : UserControl
    {
        #region Fields

        List<Tuple<string, object>> types = new List<Tuple<string, object>>();

        event Action<List<Tuple<string, object>>> onChange = (List<Tuple<string, object>> types) => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlTypeList()
        {
            InitializeComponent();
            columnType.ValueType = typeof(EnumType);
            columnType.DataSource = Enum.GetValues(typeof(EnumType));
        }

        #endregion

        #region Public Members


        #endregion

        #region Public Members

        /// <summary>
        /// Types
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Tuple<string, object>> Types
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
        public event Action<List<Tuple<string, object>>> OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        #region Private Membrers

        void Set()
        {
            foreach (Tuple<string, object> t in types)
            {
                dataGridView.Rows.Add(new object[] { t.Item1, t.Item2.ToEnumType() });
            }
        }

        void Get()
        {
            try
            {
                List<Tuple<string, object>> types = new List<Tuple<string, object>>();
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    object type = row.Cells[0].Value;
                    object val = row.Cells[1].Value;
                    if ((type == null) | (val == null))
                    {
                        continue;
                    }
                    Tuple<string, object> t = new Tuple<string, object>(type + "", 
                        ((EnumType)val).ToType());
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

        #region Event handlers

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Get();
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Get();

        }

        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Get();
        }

        #endregion

    }
}
