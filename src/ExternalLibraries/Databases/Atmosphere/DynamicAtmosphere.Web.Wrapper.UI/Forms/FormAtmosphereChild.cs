using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Interfaces;

namespace DynamicAtmosphere.Web.Wrapper.UI.Forms
{
    /// <summary>
    /// Atmosphere editor with child
    /// </summary>
    public partial class FormAtmosphereChild : Form, IUpdatableForm
    {
        #region Fields

        Atmosphere atmosphere;

        #endregion

        #region Ctor

        private FormAtmosphereChild()
        {
            InitializeComponent();
        }

        internal FormAtmosphereChild(Atmosphere atmosphere)
            : this()
        {
            this.atmosphere = atmosphere;
            userControlAtmosphereChild.Atmosphere = atmosphere;
            UpdateFormUI();
        }

        #endregion

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = atmosphere.GetName();
        }

        #endregion
    }
}
