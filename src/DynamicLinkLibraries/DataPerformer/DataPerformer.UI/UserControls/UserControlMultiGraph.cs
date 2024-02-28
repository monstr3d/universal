using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPerformer.UI.UserControls
{
    public partial class UserControlMultiGraph : UserControl
    {

        private List<Dictionary<string, Color>> dictionary = null;
        public UserControlMultiGraph()
        {
            InitializeComponent();
        }


        internal List<Dictionary<string, Color>> Dictionary
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                dictionary = value;
                SetFirst();
                
            }
        }

        void SetFirst()
        {
            toolStripComboBoxNumber.SelectedIndex = dictionary.Count;
            toolStripComboBoxNumber.SelectedIndexChanged += ToolStripComboBoxNumber_SelectedIndexChanged;
            Set();
        }

        private void ToolStripComboBoxNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n =  toolStripComboBoxNumber.SelectedIndex;
            var m = dictionary.Count;
            if (m == n)
            {
                return;
            }
            if (m > n)
            {
                dictionary.Add(new());
            }
            else
            {
                dictionary.RemoveAt(1);
            }
            
        }

        void Set()
        {
            var one = dictionary.Count == 1;
            if (one)
            {
               // userControlChartDouble.Visible = false;
               // u
            }
        }
    }
}
