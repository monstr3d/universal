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
using Diagram.UI.Utils;
using ResourceService;

namespace DinAtm.Forms.FormUI
{
    public partial class FormAtmosphere : Form, IUpdatableForm
    {

        Portable.Atmosphere atmosphere;

        private FormAtmosphere()
        {
            InitializeComponent();
           // this.LoadControlResources();
        }

        internal FormAtmosphere(Portable.Atmosphere atmosphere) : this()
        {
            this.atmosphere = atmosphere;
            userControlAtmosphere.Atmosphere = atmosphere;
        }

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
    }
}
