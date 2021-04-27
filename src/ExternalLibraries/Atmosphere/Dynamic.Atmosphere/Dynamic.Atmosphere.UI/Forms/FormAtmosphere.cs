using Diagram.UI.Labels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dynamic.Atmosphere.UI.Forms
{
    public partial class FormAtmosphere : Form
    {
        Portable.Atmosphere atmosphere;

        public FormAtmosphere()
        {
            InitializeComponent();
        }

        internal FormAtmosphere(Portable.Atmosphere atmosphere) :
            this()
        {
            this.atmosphere = atmosphere;
            userControlAtmosphere.Atmosphere = atmosphere;
            UpdateFormUI();
        }

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            CategoryTheory.IAssociatedObject ao = atmosphere 
                as CategoryTheory.IAssociatedObject;
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
