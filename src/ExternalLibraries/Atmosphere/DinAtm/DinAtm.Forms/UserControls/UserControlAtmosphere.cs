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

namespace DinAtm.Forms.UserControls
{
    public partial class UserControlAtmosphere : UserControl
    {
        public UserControlAtmosphere()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Portable.Atmosphere Atmosphere
        {
            set
            {
                propertyGrid.SetAlias(value);
            }
        }
 
    }
}
