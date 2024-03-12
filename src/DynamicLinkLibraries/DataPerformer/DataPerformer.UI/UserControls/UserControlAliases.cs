using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataPerformer.Interfaces;
using DataPerformer.Portable;

namespace DataPerformer.UI.UserControls
{
    public partial class UserControlAliases : UserControl
    {

        IDataConsumer dataConsumer;

        /// <summary>
        ///  Constructor
        /// </summary>
        public UserControlAliases()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Data consumer
        /// </summary>
        public IDataConsumer DataConsumer
        {
            get => dataConsumer;
            set
            {
                dataConsumer = value;
                Set();
            }
        }

        /// <summary>
        /// Dictionary
        /// </summary>
        public Dictionary<string, string> Dictionary
        {
            get
            {
                var d = new Dictionary<string, string>();
                foreach (DataGridViewRow r in dataGridView.Rows)
                {
                    var s = r.Cells[1].Value;
                    if (s == null)
                    {
                        continue;
                    }
                    var c = s + "";
                    if (c.Length == 0)
                    {
                        continue;
                    }
                    d[r.Cells[0].Value + ""] = c;
                }
                return d;
            }
            set
            {
                foreach (DataGridViewRow r in dataGridView.Rows)
                {
                    var s = r.Cells[0].Value + "";
                    if (value.ContainsKey(s))
                    {
                        r.Cells[1].Value = value[s];
                    }

                }
            }
        }

        void Set()
        {
            var l = dataConsumer.GetAllAliases();
            foreach (var alias in l) 
            { 
                dataGridView.Rows.Add(alias, "");
            }
        }
    }
}
