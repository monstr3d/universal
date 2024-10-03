using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;


using Diagram.UI.Utils;

namespace Diagram.UI
{
    /// <summary>
    /// Form associated to library
    /// </summary>
    public partial class FormMultilibrary : Form, IUpdatableForm
    {

        private IObjectLabel label;
        private MultiLibraryObject obj;
        private FormMultilibrary()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Associated label</param>
        public FormMultilibrary(IObjectLabel label)
        {
            InitializeComponent();
            this.LoadControlResources(ControlUtilites.Resources);
            this.label = label;
            obj = label.Object as MultiLibraryObject;
            fill();
            Text = label.Name;
        }

        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogDLL.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            obj.Add(openFileDialogDLL.FileName);
            fill();
            
        }

        private void fill()
        {
            listViewLibraries.Items.Clear();
            if (obj.Libraries != null)
            {
                string[] s = obj.Libraries;
                foreach (string str in s)
                {
                    listViewLibraries.Items.Add(str);
                }
            }
            if (obj.Factory != null)
            {
                string[] s = obj.Factory.Names;
                if (s != null)
                {
                    comboBoxName.FillCombo(s);
                }
            }
            if (obj.Name != null)
            {
                comboBoxName.SelectCombo(obj.Name);
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            obj.Name = comboBoxName.SelectedItem + "";
            ISeparatedAssemblyEditedObject s = obj.GetObject<ISeparatedAssemblyEditedObject>();
            if (s != null)
            {
               s.FirstLoad();
            }
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }
       
    }
}