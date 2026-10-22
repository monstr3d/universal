using Diagram.UI;

using Event.Basic.Data.Events;
using System.ComponentModel;
using System.Windows.Forms;

namespace Event.UI.UserControls
{
    public partial class UserControlEventDataFull : UserControl
    {
        #region Fields

        ForcedEventData forced;

        #endregion

            public UserControlEventDataFull()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ForcedEventData Forced
        {
            set
            {
                forced = value;
                var d = this.FindChild<UserControlEventData>();
                d.Forced = value;
            }
        }
    }
}
