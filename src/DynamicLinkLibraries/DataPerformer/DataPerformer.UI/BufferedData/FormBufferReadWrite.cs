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

using DataPerformer.Event.Portable.Objects.BufferedData;
using DataPerformer.UI.BufferedData.UserControls;

namespace DataPerformer.UI.BufferedData
{
    public partial class FormBufferReadWrite : Form, IUpdatableForm
    {

        BufferReadWrite buffer;

        IObjectLabel label;

        public FormBufferReadWrite()
        {
            InitializeComponent();
        }

        internal FormBufferReadWrite(IObjectLabel label) : 
            this()
        {
            this.label = label;
        }

        void IUpdatableForm.UpdateFormUI()
        {
            if (label != null)
            {
                Text = label.Name;
            }
        }

        private void FormBufferReadWrite_Load(object sender, EventArgs e)
        {
            UserControlBufferReadWriteFull uc = new UserControlBufferReadWriteFull();
            uc.Dock = DockStyle.Fill;
            panelCenter.Controls.Add(uc);
            uc.Buffer = label.Object as BufferReadWrite;
        }
    }
}
