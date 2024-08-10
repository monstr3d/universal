using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internet.Meteo.UI.UserControls
{
    public partial class UserControlTemperatureFull : UserControl
    {

        TextBox[] children = new TextBox[5];
        public UserControlTemperatureFull()
        {
            InitializeComponent();
            var tb = new List<Control>();
            for (int i = 0; i < children.Length; i++)
            {
                var t = new TextBox();
                children[i] = t;
                tb.Add(new TextBox());
            }
            userControlListItems.Children = tb.ToArray();
        }
    }
}
