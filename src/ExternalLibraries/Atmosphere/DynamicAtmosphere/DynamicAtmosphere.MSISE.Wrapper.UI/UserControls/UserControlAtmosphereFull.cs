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
    /// Full editor of atmoshere
    /// </summary>
    public partial class UserControlAtmosphereFull : UserControl
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlAtmosphereFull()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Members

        internal DynamicAtmosphere.MSISE.Wrapper.Atmosphere Atmosphere
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                userControlAtmosphere.Atmosphere = value;
                userControlPhysicalUnit.PhysicalUnitObject = value;
                userControlSwithes.Atmosphere = value;
            }
        }

        #endregion
    }
}
