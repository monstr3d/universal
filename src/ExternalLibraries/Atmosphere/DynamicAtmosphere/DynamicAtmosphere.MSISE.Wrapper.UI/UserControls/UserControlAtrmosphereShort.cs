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
    /// Short editor of atmosphere
    /// </summary>
    public partial class UserControlAtrmosphereShort : UserControl
    {
        #region Ctor

        /// <summary>
        /// Default construrctor
        /// </summary>
        public UserControlAtrmosphereShort()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Members

        internal Atmosphere Atmosphere
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                userControlPhysicalUnit.PhysicalUnitObject = value;
                userControlSwithes.Atmosphere = value;
            }
        }

        #endregion
    }
}
