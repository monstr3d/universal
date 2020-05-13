using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicAtmosphere.MSISE.Wrapper.UI.UserControls
{
    /// <summary>
    /// Switches of atmosphere
    /// </summary>
    public partial class UserControlSwithes : UserControl
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlSwithes()
        {
            InitializeComponent();
        }

        #endregion

        #region Members

        internal Atmosphere Atmosphere
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                int[] array = value.Switches;
                userControlNumberArrayEditor.Set(array,
                    StaticExtensionDynamicAtmosphereMSISEWrapperUI.Switches);
                userControlNumberArrayEditor.Change += () =>
                {
                    value.Switches = array;
                };
            }
        }

        #endregion
    }
}
