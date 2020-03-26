using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;


namespace Diagram.UI
{
    /// <summary>
    /// Form associated to library object
    /// </summary>
    public partial class FormLibraryObject : Form, IUpdatableForm
    {
        IObjectLabel label;
        LibraryObjectWrapper wrapper;
        string id;
        private FormLibraryObject()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Associated label</param>
        /// <param name="wrapper">Library object</param>
        public FormLibraryObject(IObjectLabel label, LibraryObjectWrapper wrapper)
        {
            this.label = label;
            this.wrapper = wrapper;
            InitializeComponent();
            this.LoadControlResources(ControlUtilites.Resources);
            if (CategoryTheory.BinaryLoader.Object == null || Diagram.UI.BinaryChooser.Object == null)
            {
                buttonLoad.Enabled = false;
            }
            UpdateFormUI();
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
        void fill()
        {
            if (wrapper.FileName == null)
            {
                return;
            }
            textBoxFileName.Text = wrapper.FileName;
            string[] items = LibraryObjectWrapper.GetNames(wrapper.FileName);
            int n = 0;
            int sel = 0;
            foreach (string it in items)
            {
                comboBoxName.Items.Add(it);
                if (it.Equals(wrapper.Name))
                {
                    sel = n;
                }
                ++n;
            }
            comboBoxName.SelectedIndex = sel;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialogDLL.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            string fn = openFileDialogDLL.FileName + "";
            string[] names = LibraryObjectWrapper.GetNames(fn);
            if (names == null)
            {
                return;
            }
            textBoxFileName.Text = fn;
            comboBoxName.Items.Clear();
            foreach (string it in names)
            {
                comboBoxName.Items.Add(it);
            }
            buttonLoad.Enabled = false;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (comboBoxName.Items.Count == 0)
            {
                return;
            }
            string it = comboBoxName.SelectedItem + "";
            if (it.Length == 0)
            {
                return;
            }
            if (id != null)
            {
                wrapper.Set(id, it);
            }
            else
            {
                wrapper.Set(textBoxFileName.Text, it);
            }

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (CategoryTheory.BinaryLoader.Object == null || Diagram.UI.BinaryChooser.Object == null)
            {
                return;
            }

            Diagram.UI.BinaryChooser.Object.Show(this, "dll");
            if (Diagram.UI.BinaryChooser.Object.Name == null)
            {
                return;
            }
            textBoxDB.Text = Diagram.UI.BinaryChooser.Object.Name + "";
            id = Diagram.UI.BinaryChooser.Object.Id;
            string[] names = LibraryObjectWrapper.GetNames(id);
            if (names == null)
            {
                return;
            }
            comboBoxName.Items.Clear();
            foreach (string it in names)
            {
                comboBoxName.Items.Add(it);
            }
            buttonBrowse.Enabled = false;
        }
    }
}