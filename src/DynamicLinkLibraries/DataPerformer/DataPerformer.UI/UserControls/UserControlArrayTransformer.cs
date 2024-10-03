using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataPerformer;
using Diagram.UI.Utils;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control for array transformer
    /// </summary>
    public partial class UserControlArrayTransformer : UserControl
    {
        #region Fields

        private ArrayTransformer transformer;

        private ComboBox box;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlArrayTransformer()
        {
            InitializeComponent();
            box = userControlComboboxList.Boxes[0];
        }

        #endregion

        #region Specific Members

        internal ArrayTransformer Transformer
        {
            set
            {
                transformer = value;
                box.FillCombo(transformer.Measurements);
                box.SelectCombo(transformer.Measure);
                checkBoxObjectType.Checked = transformer.IsObjectArray;
            }
        }

        #endregion

        #region Event Handlers

        private void Accept_Click(object sender, EventArgs e)
        {
            if (box.SelectedItem == null)
            {
                return;
            }
            transformer.Measure = box.SelectedItem + "";
            transformer.IsObjectArray = checkBoxObjectType.Checked;
        }

        #endregion

    }
}
