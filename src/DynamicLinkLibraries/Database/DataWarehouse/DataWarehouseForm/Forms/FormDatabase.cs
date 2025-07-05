using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataWarehouse.Classes;
using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using DataWarehouse.Utils;
using ErrorHandler;
using NamedTree;

using ResourceService;
using WindowsExtensions;


namespace DataWarehouse.Forms
{
    /// <summary>
    /// Database form
    /// </summary>
    public partial class FormDatabase : Form
    {

        #region Fields

        NamedTree.Performer perf = new();

        DataWarehouse.Forms.Performer performer = new();

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

        DataWarehouse.Performer p = new();
        private IDirectory SelectedNode
        {
            get;
            set;
        }
        private ILeaf Selected
        {
            get;
            set;
        }
        private TreeNode SelectedTreeNode
        {
            get;
            set;
        }
        private ListViewItem SelectedItem
        {
            get;
            set;
        }

        #endregion

        #region Ctor

        private FormDatabase()
        {
            InitializeComponent();
            var t = this.FindControlChild<TreeView>();
            t.Tag = ActionIssue;
        }

        void ActionIssue(Issue issue)
        {
            var err = p.GetErrorType(issue);
            if (err == ErrorType.AlreadyExecuted)
            {
                return;
            }
           WindowsExtensions.ControlExtensions.ShowMessageBoxModal("Error");

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="blob">Blob holder</param>
        /// <param name="data">Database interface</param>
        /// <param name="open">The "open" sign</param>
        public FormDatabase(IBlob blob, DatabaseInterface data, bool open) : this()
        {
            this.LoadControlResources();
            this.blob = blob;
            this.data = data;
            this.open = open;
            ext = new string[] { blob.Extension };
            if (open)
            {
                buttonCreateDir.Enabled = false;
                buttonChangeNodeDescr.Enabled = false;
                buttonSaveDoc.Visible = false;
                buttonReplace.Enabled = false;

            }
            else
            {
                buttonLoad.Visible = false;
            }
            buttonDelete.Enabled = false;
            buttonDirDelete.Enabled = false;
            buttonLoad.Enabled = false;
            treeViewDir.BeforeExpand += performer.BeforeExpand;
            refreshTree();
        }

        #endregion


        private void refreshTree()
        {
            treeViewDir.Fill(data, ext[0], false, true, ActionIssue);
   
       /* !!! DELETE      IDirectory[] dir = data.GetRoots(ext);
            foreach (IDirectory d in dir)
            {
                treeViewDir.Nodes.Add(GetNode(d));
            }*/
            if (listViewDoc.Items.Count > 0)
            {
                listViewDoc.Items.Clear();
            }
            this.buttonDelete.Enabled = false;
            buttonLoad.Enabled = false;
            this.buttonDirDelete.Enabled = false;
            this.buttonDirDelete.Enabled = false;
        }

 

        private void treeViewDir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeViewDir.SelectedNode;
            if (node == SelectedNode | node == null)
            {
                return;
            }
            SelectedTreeNode = node;
            SelectedNode = node.Tag as IDirectory;
            if (SelectedNode == root)
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
            string description = SelectedNode.Description;
            labelDirectoryDescr.Text = description;
            if (listViewDoc.Items.Count > 0)
            {
                listViewDoc.Items.Clear();
            }
            
            RefreshTable();
        }

        Dictionary<IDirectory, Action<object>> leaf_add = new Dictionary<IDirectory, Action<object>>();

        Dictionary<ILeaf, Action<object>> leaf_act_remove = new Dictionary<ILeaf, Action<object>>();



        Dictionary<ILeaf, ListViewItem> items = new Dictionary<ILeaf, ListViewItem>();

        private async void RefreshTable()
        {
            try
            {
                if (SelectedNode == null)
                {
                    return;
                }
                listViewDoc.Items.Clear();
     /*           foreach (var i in leaf_act_remove)
                {
                    i.Key.OnDeleteItself -= i.Value;
                }

                foreach (var i in leaf_add)
                {
                    i.Key.OnAddLeaf -= i.Value;
                }

                leaf_add.Clear();


                leaf_act_remove.Clear();

                var act_a = (object o) =>
                {
                    var i = o as Issue;
                    if (i.ErrorType != ErrorType.None)
                    {
                        return;
                    }
                    var l = i.Object as ILeaf;
                    var a = () =>
                    {
                        string[] s = new string[] { l.Name, l.Extension };
                        ListViewItem it = new ListViewItem(s);
                        it.Tag = l;
                        listViewDoc.Items.Add(it);

                    };
                    listViewDoc.InvokeIfNeeded(a);
                };
                (SelectedNode as IDirectory).OnAddLeaf += act_a;
                leaf_add[SelectedNode] = act_a;

                /*
               if (dataTableDoc.Rows.Count > 0)
               {
                   dataTableDoc.Clear();
               }*/
                IDirectory d = SelectedNode;
                if (d is IDirectoryAsync async)
                {
                    var tl = async.LoadChildren();
                   
                    var t = async.LoadLeaves();
                    var act = () =>
                    {
                        IChildren<ILeaf> coll = d;

                        foreach (var leaf in coll.Children)
                        {
                            string[] s = new string[] { leaf.Value.Name, leaf.Value.Extension };
                            ListViewItem it = new ListViewItem(s);
                            it.Tag = leaf;
                            listViewDoc.Items.Add(it);
                            var act = (object o) =>
                         {
                               var i = o as Issue;
                               if (i.ErrorType == ErrorType.None)
                               {
                                   listViewDoc.InvokeIfNeeded(() => listViewDoc.Items.Remove(it));
                               }
                           };
                            leaf.OnDeleteItself += act;
                            leaf_act_remove[leaf] = act;
                        }
                        labelDescr.Text = "";
                        buttonDelete.Enabled = false;
                        buttonLoad.Enabled = false;
                    };
                    tl.GetAwaiter().OnCompleted(async () =>
                    {
                        t.GetAwaiter().OnCompleted(() =>
                        {
                            this.InvokeIfNeeded(act);
                        });
                        await t;
                    });
                    await tl;
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
        }

        

        private void Leaf_OnDeleteItself(object obj)
        {
            throw new OwnNotImplemented();
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
            var n = SelectedNode.Name;
            SelectedNode.Name = e.Label;
            if (n == SelectedNode.Name)
            {
                e.CancelEdit = true;
            }
        }

        private void listViewDoc_Click(object sender, EventArgs e)
        {
            if (SelectedNode == null)
            {
                return;
            }
            if (listViewDoc.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem it = listViewDoc.SelectedItems[0];
            ILeaf s = it.Tag as ILeaf;
            if (Selected == s)
            {
                return;
            }
            Selected = s;
            if (Selected != null)
            {
                SelectedItem = it;
                string desc = Selected.Description;
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
                if (SelectedNode == null)
                {
                    return;
                }
                /*    if (textBoxDirName.Text.Length > textLength)
                    {
                    }*/
                IDirectory node = SelectedNode;
                //string id = node.UID;
                string descr = "";
                foreach (string s in textBoxDirDescr.Lines)
                {
                    descr += s;
                    descr += " ";
                }
                var nm = textBoxDirName.Text;
                IDirectory dir = new Classes.Directory(null, nm, textBoxDirDescr.Text, blob.Extension, false);
                IDirectory child = node.Add(dir);
            }
            catch (Exception ex)
            {
                ex.HandleException();
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }

        }

        private void buttonDirDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedNode == null | SelectedNode == root)
                {
                    return;
                }
                DialogResult res = WindowsExtensions.ControlExtensions.ShowMessageBoxModal(
                    Resources.GetControlResource(DoYowWantDelete, ControlUtilites.Resources) +
                    "\"" + SelectedNode.Name + "\"" + "?", "",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                if (res != DialogResult.OK)
                {
                    return;
                }
                 SelectedNode.RemoveItself();
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
            if (Selected == null)
            {
                return;
            }
            string s = Resources.GetControlResource(DoYowWantReplace, ControlUtilites.Resources) +
                "\"" + Selected.Name + "\"" + "?";
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
                stream.ReadExactly(b);
                stream.Close();
            }
            else
            {
                b = blob.Bytes;
            }
            try
            {
                (Selected as IData).Data = b;
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
            if (Selected == null)
            {
                return;
            }
            byte[] b = (Selected as IData).Data;
            Close();
            blob.Extension = ext[0];
            blob.Bytes = b;
        }

        byte[] getData(ref string ext)
        {
            if (Selected == null)
            {
                return null;
            }
            return (Selected as IData).Data;
        }

        IAccceptNameUpdate Update => SelectedNode as IAccceptNameUpdate;

        private void buttonSaveDoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedNode == null)
                {
                    return;
                }
                byte[] b = null;
                string ext = "";
                var nm = textBoxName.Text;
                if (labelFileName.Text.Length != 0)
                {
                    Stream stream = File.OpenRead(labelFileName.Text);
                    b = new byte[stream.Length];
                    stream.ReadExactly(b);
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
                if (!Update.AcceptUpdate(nm))
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal("Illegal name \"" + nm + "\"");
                    return;
                }
                var leaf = new Leaf(null, nm, textBoxDescription.Text, ext, b);
                var l = SelectedNode.Add(leaf);
   /*             if (l == null)
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal("Illegal name \"" + nm + "\"");
                    return;
                }*/
          //      Close();
            }
            catch (Exception ex)
            {
                ex.HandleException();
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Selected == null)
                {
                    return;
                }
                string name = Selected.Name;
                //!!!            DialogResult res = WindowsExtensions.ControlExtensions.ShowMessageBoxModal(
                // Resources.ContainsControlResource(DoYowWantDelete, ControlUtilites.Resources) +
                DialogResult res = WindowsExtensions.ControlExtensions.ShowMessageBoxModal(DoYowWantDelete + "\"" + name + "\"" + "?", "",
    MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
    MessageBoxOptions.DefaultDesktopOnly);
                if (res != DialogResult.OK)
                {
                    return;
                }
                Selected.RemoveItself();
                //selectedNode.Remove(selected);
            //    RefreshTable();
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
            if (Selected == null)
            {
                return;
            }
            byte[] b = (Selected as IData).Data;
            saveFileDialogData.Filter = "|*.cfa"; // !!! + ext;
            /*!!!         try
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
                     }*/
            if (saveFileDialogData.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            using (var stream = File.OpenWrite(saveFileDialogData.FileName))
            {
                stream.Write(b, 0, b.Length);
            }        
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
                ILeaf leaf = Selected;
                var name = leaf.Name;
                leaf.Name = e.Label;
                if (leaf is ILeafAsync)
                {
                    return;
                }
                if (name == leaf.Name)
                {
                    e.CancelEdit = true;
                }

            }
            catch (Exception ex)
            {
                e.CancelEdit = true;
                ex.HandleException();
            }
        }

        private void listViewDoc_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
        }

        private void buttonChangeDescription_Click(object sender, EventArgs e)
        {
            if (Selected != null)
            {
               Selected.Description = textBoxDescription.Text;
            }
        }

        private void buttonChangeNodeDescr_Click(object sender, EventArgs e)
        {
            if (SelectedNode != null)
            {
                SelectedNode.Description = textBoxDirDescr.Text;
            }
        }

    }
}