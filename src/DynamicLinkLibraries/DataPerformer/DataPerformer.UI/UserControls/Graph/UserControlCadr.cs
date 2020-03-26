using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diagram.UI;
using DataPerformer.UI.Labels;

namespace DataPerformer.UI.UserControls.Graph
{
    public partial class UserControlCadr : UserControl
    {
        bool changed = false;

        public UserControlCadr()
        {
            InitializeComponent();
        }

        private void numericUpDownCadr_ValueChanged(object sender, EventArgs e)
        {
            if (changed)
            {
                return;
            }
            this.FindParent<GraphLabel>().CadrNumber = (int)numericUpDownCadr.Value;
        }

        internal int Cadr
        {
            get
            {
               return this.FindParent<GraphLabel>().CadrNumber;
            }
            set
            {
                if (numericUpDownCadr.Value == value)
                {
                    return;
                }
                if (this.FindParent<GraphLabel>().CadrNumber != value)
                {
                    this.FindParent<GraphLabel>().CadrNumber = value;
                }
                changed = true;
                numericUpDownCadr.Value = value;
                changed = false;
            }
        }

        internal Dictionary<string, object> Dictionary
        {
            set
            {
                listView.Set(value);
            }
        }
    }
}
