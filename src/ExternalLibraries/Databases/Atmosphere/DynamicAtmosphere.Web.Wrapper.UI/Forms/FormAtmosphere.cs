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
    /// Atmosphere editor form
    /// </summary>
    public partial class FormAtmosphere : Form
    {

               #region Fields

        Atmosphere atmosphere;

        #endregion

       #region Ctor

        private FormAtmosphere()
        {
            InitializeComponent();
        }

        internal FormAtmosphere(Atmosphere atmosphere)
            : this()
        {
            this.atmosphere = atmosphere;
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
