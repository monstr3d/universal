using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control for regression alias
    /// </summary>
    public partial class UserControlRegressionAlias : UserControl
    {
        internal UserControlRegressionAlias()
        {
            InitializeComponent();
            this.LoadResources();
        }

        private void UserControlRegressionAlias_Resize(object sender, EventArgs e)
        {
            comboBoxParameter.Width = Width - 2 * comboBoxParameter.Left;
        }

        internal ComboBox Parameter
        {
            get
            {
                return comboBoxParameter;
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal double Delta
        {
            get
            {
                return Double.Parse(textBoxDelta.Text);
            }
            set
            {
                textBoxDelta.Text = value + "";
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal double Sigma
        {
            get
            {
                return Double.Parse(textBoxSigma.Text);
            }
            set
            {
                textBoxSigma.Text = value + "";
            }
        }
    }
}
