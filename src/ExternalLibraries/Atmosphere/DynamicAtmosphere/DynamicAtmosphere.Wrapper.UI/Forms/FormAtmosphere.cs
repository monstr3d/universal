using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

namespace DynamicAtmosphere.Wrapper.UI.Forms
{
    /// <summary>
    /// Editor of atmosphere
    /// </summary>
    public partial class FormAtmosphere : Form, IUpdatableForm
    {
        #region Fields

        /// <summary>
        /// Atmosphere
        /// </summary>
        private Atmosphere atmosphere;

        #endregion

        #region Ctor

        public FormAtmosphere()
        {
            InitializeComponent();
        }

        internal FormAtmosphere(Atmosphere atmosphere)
            : this()
        {
            this.atmosphere = atmosphere;
            UpdateFormUI();
            userControlAtmosphere.Atmosphere = atmosphere;
        }

        #endregion

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            CategoryTheory.IAssociatedObject ao = atmosphere as CategoryTheory.IAssociatedObject;
            object o = ao.Object;
            if (o == null)
            {
                return;
            }
            IObjectLabel l = o as IObjectLabel;
            Text = l.Name;
        }

        #endregion
    }
}

