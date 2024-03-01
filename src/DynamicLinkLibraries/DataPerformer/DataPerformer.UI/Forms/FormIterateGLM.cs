using System;
using System.Windows.Forms;

using DataPerformer.UI.UserControls;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Regression;

namespace DataPerformer.UI.Forms
{
    public partial class FormIterateGLM : Form, IUpdatableForm
    {
        IObjectLabel comp;

        IteratorGLM iterator;

        public FormIterateGLM()
        {
            InitializeComponent();
        }

        /// </summary>
        /// <param name="comp">Component label</param>
        public FormIterateGLM(IObjectLabel comp) :
            this()
        {
            this.comp = comp;
            iterator = comp.Object as IteratorGLM;
        }

        void IUpdatableForm.UpdateFormUI()
        {
            if (comp != null)
            {
                Text = comp.Name;
            }
        }

        private void FormIterateGLM_Load(object sender, EventArgs e)
        {
            UserControlIteratorGLM uc = new UserControlIteratorGLM();
            uc.Iterator = iterator;
            uc.Dock = DockStyle.Fill;
            panelCenter.Controls.Add(uc);
        }

        private void buttonFullIteration_Click(object sender, EventArgs e)
        {
            double s = iterator.FullIterate();
            labelSigma.Text = s + "";
        }
    }
}
