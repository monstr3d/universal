using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;


using ResourceService;
using DataWarehouse.Utils;
using DataWarehouse.Interfaces;


namespace DataWarehouse.Forms
{
    /// <summary>
    /// Database form
    /// </summary>
    public partial class FormDatabase : Form
    {

        #region Fields
        /// <summary>
        /// Message string
        /// </summary>
        static public readonly string DoYowWantDelete = "Do you really want delete ";

        /// <summary>
        /// Message string
        /// </summary>
        static public readonly string DoYowWantReplace = "Do you really want replace ";
        
        IBlob blob;
        DatabaseInterface data;
        bool open;
        string[] ext;
        private TreeNode root = null;
        private IDirectory selectedNode;
        private ILeaf selected;
        private TreeNode selectedTreeNode;
        private ListViewItem selectedItem;

        #endregion

        #region Ctor

        private FormDatabase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="blob">Blob holder</param>
        /// <param name="data">Database interface</param>
        /// <param name="open">The "open" sign</param>
        public FormDatabase(IBlob blob, DatabaseInterface data, bool open)
        {
            InitializeComponent();
            this.LoadControlResources();
            this.blob = blob;
            this.data = data;
            this.open = open;
            ext = new string[] { blob.Extension };
            //labelFileName.Visible = false;
            if (open)
            {
                buttonCreateDir.Enabled = false;
                buttonChangeNodeDescr.Enabled = false;
                buttonSaveDoc.Visible = false;
                //textBoxDescription.Visible = false;
                //textBoxDirDescr.Visible = false;
                //textBoxDirName.Visible = false;
                //textBoxName.Visible = false;
                //buttonSaveDoc.Visible = false;
                buttonReplace.Enabled = false;

            }
            else
            {
                buttonLoad.Visible = false;
            }
            buttonDelete.Enabled = false;
            buttonDirDelete.Enabled = false;
            buttonLoad.Enabled = false;
            refreshTree();
        }

        #endregion


        private void refreshTree()
        {
   
            IDirectory[] dir = data.GetRoots(ext);
            foreach (IDirectory d in dir)
            {
                treeViewDir.Nodes.Add(GetNode(d));
            }
            if (listViewDoc.Items.Count > 0)
            {
                listViewDoc.Items.Clear();
            }
            this.buttonDelete.Enabled = false;
            buttonLoad.Enabled = false;
            this.buttonDirDelete.Enabled = false;
            this.buttonDirDelete.Enabled = false;
        }

        private TreeNode GetNode(IDirectory dir)
        {
            IEnumerable<IDirectory> d = dir;
            List<IDirectory> l = new List<IDirectory>();
            l.AddRange(d);
            l.Sort(NodeComparer.Singleton);
            List<TreeNode> lt = new List<TreeNode>();
            foreach (IDirectory dd in l)
            {
                lt.Add(GetNode(dd));
            }
            TreeNode node = new TreeNode(dir.Name, lt.ToArray());
            node.Tag = dir;
            return node;
        }

        private void treeViewDir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeViewDir.SelectedNode;
            if (node == selectedNode | node == null)
            {
                return;
            }
            selectedTreeNode = node;
            selectedNode = node.Tag as IDirectory;
            if (selectedNode == root)
            {
                buttonDirDelete.Enabled = false;
                buttonSaveDoc.Enabled = false;
                buttonChangeNodeDescr.Enabled = false;
            }
            else
            {
                buttonDirDelete.Enabled = true;
                buttonSaveDoc.Enabled = true;
                buttonChangeNodeDescr.Enabled = true;
            }
            string description = selectedNode.Description;
            labelDirectoryDescr.Text = description;
            if (listViewDoc.Items.Count > 0)
            {
                listViewDoc.Items.Clear();
            }
            refreshTable();
        }

        private void refreshTable()
        {
            if (selectedNode == null)
            {
                return;
            }
            listViewDoc.Items.Clear();
            /*
            if (dataTableDoc.Rows.Count > 0)
            {
                dataTableDoc.Clear();
            }*/
            IEnumerable<ILeaf> coll = selectedNode;
            foreach (ILeaf leaf in coll)
            {
                string[] s = new string[] { leaf.Name, leaf.Extension };
                ListViewItem it = new ListViewItem(s);
                it.Tag = leaf;
                listViewDoc.Items.Add(it);
            }
            labelDescr.Text = "";
            buttonDelete.Enabled = false;
            buttonLoad.Enabled = false;
        }

        void save(string filename)
        {
            string ext = null;
            byte[] b = getData(ref ext);
            if (b == null)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal("Select data, please");
                return;
            }
            Stream s = File.OpenWrite(filename);
            s.Write(b, 0, b.Length);
            s.Close();
        }

        void save()
        {
            if (saveFileDialogData.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            save(saveFileDialogData.FileName);
        }

        private void treeViewDir_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null)
            {
                return;
            }
            selectedNode.Name = e.Label;
        }

        private void listViewDoc_Click(object sender, EventArgs e)
        {
            if (selectedNode == null)
            {
                return;
            }
            if (listViewDoc.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem it = listViewDoc.SelectedItems[0];
            ILeaf s = it.Tag as ILeaf;
            if (selected == s)
            {
                return;
            }
            selected = s;
            if (selected != null)
            {
                selectedItem = it;
                string desc = selected.Description;
                labelDescr.Text = desc;
                textBoxDescription.Text = desc;
                buttonDelete.Enabled = true;
                buttonLoad.Enabled = true;

            }

        }

        private void buttonCreateDir_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedNode == null)
                {
                    return;
                }
            /*    if (textBoxDirName.Text.Length > textLength)
                {
                }*/
                IDirectory node = selectedNode;
                //string id = node.UID;
                string descr = "";
                foreach (string s in textBoxDirDescr.Lines)
                {
                    descr += s;
                    descr += " ";
                }
                IDirectory child =
                    node.Add(textBoxDirName.Text, textBoxDirDescr.Text, blob.Extension);
                if (child == null)
                {
                    return;
                }
                 TreeNode nn = new TreeNode(child.Name);
                nn.Tag = child;
                selectedTreeNode.Nodes.Add(nn);
            }
            catch (Exception ex)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }

        }

        private void buttonDirDelete_Click(object sender, EventArgs e)
        {
            try
            {
                IDirectory selected = selectedNode;
                if (selected == null | selected == root)
                {
                    return;
                }
                DialogResult res = WindowsExtensions.ControlExtensions.ShowMessageBoxModal(
                    ResourceService.Resources.ContainsControlResource(DoYowWantDelete, ControlUtilites.Resources) +
                    "\"" + selected.Name + "\"" + "?", "",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                if (res != DialogResult.OK)
                {
                    return;
                }
                selectedNode.Remove();
                selectedNode = null;
                TreeNode p = selectedTreeNode.Parent;
                if (p.Nodes.Count == 1)
                {
                    treeViewDir.SelectedNode = p;
                }
                selectedTreeNode.Remove();
            }
            catch (Exception ex)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }


        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refreshTree();
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            if (selected == null)
            {
                return;
            }
            string s = Resources.GetControlResource(DoYowWantReplace, ControlUtilites.Resources) +
                "\"" + selected.Name + "\"" + "?";
            string q = Resources.GetControlResource("Question", ControlUtilites.Resources);
            DialogResult res = 
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, s, q,
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res != DialogResult.OK)
            {
                return;
            }
            byte[] b = null;
            if (labelFileName.Text.Length != 0)
            {
                Stream stream = File.OpenRead(labelFileName.Text);
                b = new byte[stream.Length];
                stream.Read(b, 0, b.Length);
                stream.Close();
            }
            else
            {
                b = blob.Bytes;
            }
            try
            {
                selected.Data = b;
            }
            catch (Exception ex)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }

            /*string guid = selected.Attributes["BinaryID"].Value;
            MemoryStream mStream = new MemoryStream();
            parent.SaveAll(mStream);
            int length = (int)mStream.Length;
            byte[] buffer = mStream.GetBuffer();
            DatabaseInterface.DatabaseClient.Service.UpdateBinaryData(guid, buffer);
            mStream.Close();*/
            //DatabaseInterface.DatabaseClient.Service.UpdateBinaryDataTable();
            //DatabaseInterface.DatabaseClient.Service.updateBinaryData();

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (selected == null)
            {
                return;
            }
            byte[] b = selected.Data;
            Close();
            blob.Extension = ext[0];
            blob.Bytes = b;
        }

        byte[] getData(ref string ext)
        {
            if (selected == null)
            {
                return null;
            }
            return selected.Data;
        }


        private void buttonSaveDoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedNode == null)
                {
                    return;
                }
                byte[] b = null;
                string ext = "";
                if (labelFileName.Text.Length != 0)
                {
                    Stream stream = File.OpenRead(labelFileName.Text);
                    b = new byte[stream.Length];
                    stream.Read(b, 0, b.Length);
                    stream.Close();
                    int n = labelFileName.Text.LastIndexOf('.');
                    if (n > 0)
                    {
                        ext = labelFileName.Text.Substring(n + 1);
                    }
                }
                else
                {
                    b = blob.Bytes;
                    ext = blob.Extension;
                }
                selectedNode.Add(textBoxName.Text, textBoxDescription.Text, b, ext);
                Close();
            }
            catch (Exception ex)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selected == null)
                {
                    return;
                }
                string name = selected.Name;
                //!!!            DialogResult res = WindowsExtensions.ControlExtensions.ShowMessageBoxModal(
                // Resources.ContainsControlResource(DoYowWantDelete, ControlUtilites.Resources) +
                DialogResult res = WindowsExtensions.ControlExtensions.ShowMessageBoxModal(DoYowWantDelete + "\"" + name + "\"" + "?", "",
    MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
    MessageBoxOptions.DefaultDesktopOnly);
                if (res != DialogResult.OK)
                {
                    return;
                }
                selected.Remove();
                //selectedNode.Remove(selected);
                refreshTable();
            }
            catch (Exception ex)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ext == null)
            {
                openFileDialogData.Filter = "|*.*";
            }
            else
            {
                openFileDialogData.Filter = "|*." + ext[0];
            }
            if (openFileDialogData.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            labelFileName.Text = openFileDialogData.FileName + "";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected == null)
            {
                return;
            }
            byte[] b = selected.Data;
            saveFileDialogData.Filter = "|*." + ext;
            try
            {
                saveFileDialogData.FileName = selected.Name;
                if (saveFileDialogData.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
            }
            catch (Exception)
            {
                saveFileDialogData.FileName = "File";
                if (saveFileDialogData.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
            }
            Stream stream = File.OpenWrite(saveFileDialogData.FileName);
            stream.Write(b, 0, b.Length);
            stream.Close();
        }

        private void toolStripButtonCreateDir_Click(object sender, EventArgs e)
        {
            buttonCreateDir_Click(sender, e);
        }

        private void toolStripButtonDeleteFolder_Click(object sender, EventArgs e)
        {
            buttonDirDelete_Click(sender, e);
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            buttonDelete_Click(sender, e);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void listViewDoc_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
               /* string guid = selected.Attributes["BinaryId"].Value;
                XmlElement el = selected.GetElementsByTagName("Description")[0] as XmlElement;
                data.UpdateData(guid, e.Label, el.InnerText); */
                selected.Name = e.Label;

            }
            catch (Exception)
            {
            }
        }

        private void listViewDoc_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
        }

        private void buttonChangeDescription_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                selected.Description = textBoxDescription.Text;
            }
        }

        private void buttonChangeNodeDescr_Click(object sender, EventArgs e)
        {
            if (selectedNode != null)
            {
                selectedNode.Description = textBoxDirDescr.Text;
            }
        }

    }
}