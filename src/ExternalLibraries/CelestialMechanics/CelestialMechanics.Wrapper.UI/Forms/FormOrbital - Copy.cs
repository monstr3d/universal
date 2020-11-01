using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

namespace CelestialMechanics.Wrapper.UI.Forms
{
    internal partial class FormOrbital : Form, IUpdatableForm
    {
       private Classes.Orbit orbit;

        private FormOrbital()
        {
            InitializeComponent();
        }

        internal FormOrbital(Classes.Orbit orbit)
            : this()
        {
            this.orbit = orbit;
            userControlOrbit.Orbit = orbit;
            Text = "";
            IUpdatableForm f = this;
            f.UpdateFormUI();
        }


        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            CategoryTheory.IAssociatedObject ao = orbit as CategoryTheory.IAssociatedObject;
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
