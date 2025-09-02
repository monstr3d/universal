using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestCategory.UI.Forms
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        internal FormReport(List<string> l)
            : this()
        {
            for (int i = 0; i < l.Count; i++)
            {
                dataTable.Rows.Add(new object[] { (i + 1), l[i] });
            }
        }
    }
}
