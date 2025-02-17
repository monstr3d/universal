using System.Windows.Forms;

using WpfInterface.UI.Labels;

namespace WpfInterface.UI.UserControls
{
    public partial class UserControlConvert : UserControl
    {
        internal ShapeLabel Label
        {
            set;
            private get;
        }
        
        public UserControlConvert()
        {
            InitializeComponent();
        }
    }
}
