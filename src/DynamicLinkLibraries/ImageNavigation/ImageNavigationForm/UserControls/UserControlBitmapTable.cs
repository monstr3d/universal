using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI.Utils;

using DataPerformer.Portable;

namespace ImageNavigation.UserControls
{
    public partial class UserControlBitmapTable : UserControl
    {
        BitmapColorTable table;

        

        public UserControlBitmapTable()
        {
            InitializeComponent();
        }

        

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal BitmapColorTable Table
        {
            set
            {
                table = value;
             }
        }



        void Fill()
        {
            Double a = 0;
            List<string> l = table.GetAllMeasurements(a);
            userControlComboboxList.Fill(l);
        }

        new void Select()
        {
            List<ComboBox> l = userControlComboboxList.Boxes;
            l[0].SelectCombo(table.X);
            l[1].SelectCombo(table.Y);
        }

        internal void Post()
        {
            Fill();
            Select();
        }

        new void Refresh()
        {
            string[] t = userControlComboboxList.Selected;
            if (t[0] == null | t[1] == null)
            {
                Fill();
                return;
            }
            table.Set(t[0], t[1]);
        }
    }
}
