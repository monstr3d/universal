using System.Windows.Forms;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using NamedTree.Interfaces;

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
            IAssociatedObject ao = atmosphere as IAssociatedObject;
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
