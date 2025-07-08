using System.ComponentModel;
using System.Windows.Forms;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// Item of list
    /// </summary>
    public partial class UserControlListItem : UserControl
    {

        #region Fields


        /// <summary>
        /// Control
        /// </summary>
        Control control;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlListItem()
        {
            InitializeComponent();
            control = comboBox;
        }

        #endregion

        #region Public members


        /// <summary>
        /// Label
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Label
        {
            get
            {
                return labelText.Text;
            }
            set
            {
                labelText.Text = value;
            }
        }

        /// <summary>
        /// Control
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control Control
        {
            get => control;
            set
            {
                var p = control.Parent;
                value.Top = control.Top;
                value.Left= control.Left;
                value.Width = control.Width;
                value.Height = control.Height;
                p.Controls.Remove(control);
                control = value;
                p.Controls.Add(control);
                control.Dock = DockStyle.Fill;
            }
        }

        #endregion
    }
}
