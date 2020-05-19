using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

namespace Simulink.Proxy.UI.Forms
{
    /// <summary>
    /// Editor of properties of Simulink proxy
    /// </summary>
    public partial class FormSimulinkContainer : Form, IUpdatableForm
    {
        #region Fields
        private IObjectLabel label;

        //private SimulinkContainer container;

 
        #endregion

        private FormSimulinkContainer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Object label</param>
        public FormSimulinkContainer(IObjectLabel label)
            : this()
        {
            this.label = label;
            UpdateFormUI();
            userControlSimulinkContainer.TheObject = label.Object;
        }

        

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

    }
}
