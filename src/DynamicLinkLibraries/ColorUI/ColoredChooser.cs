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
    public partial class ColoredChooser : UserControl, IBoxArray
    {
        private ComboBox[] boxes;
        public ColoredChooser()
        {
            InitializeComponent();
            ResourceService.Resources.LoadControlResources(this, ColorUI.Utils.ControlUtilites.Resources);
            
            boxes = new ComboBox[] { comboBoxR, comboBoxG, comboBoxB };
        }


 
        #region IBoxArray Members

        ComboBox[] IBoxArray.Boxes
        {
            get { return boxes;  }
        }

        #endregion
    }
}
