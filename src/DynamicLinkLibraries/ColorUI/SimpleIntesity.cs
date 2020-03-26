using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Diagram.UI.Interfaces;

namespace ColorUI
{
    public partial class SimpleIntesity : UserControl, IBoxArray
    {

        private ComboBox[] boxes;

        public SimpleIntesity()
        {
            InitializeComponent();
            ResourceService.Resources.LoadControlResources(this, ColorUI.Utils.ControlUtilites.Resources);
            boxes = new ComboBox[] { comboBoxLight };
        }

        #region IBoxArray Members

        ComboBox[] IBoxArray.Boxes
        {
            get { return boxes; }
        }

        #endregion
    }
}
