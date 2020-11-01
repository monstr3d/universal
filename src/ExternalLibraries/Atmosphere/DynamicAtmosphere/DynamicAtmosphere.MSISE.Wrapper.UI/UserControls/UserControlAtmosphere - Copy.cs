using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;

namespace DynamicAtmosphere.MSISE.Wrapper.UI.UserControls
{
    /// <summary>
    /// Editor of atmosphere
    /// </summary>
    public partial class UserControlAtmosphere : UserControl
    {
        #region Ctor
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlAtmosphere()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Member

        internal Atmosphere Atmosphere
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                propertyGrid.SetAlias(value);
            }
        }

        #endregion
    }
}
