using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Diagram.UI;

using DataPerformer.Interfaces.BufferedData.Interfaces;
using DataPerformer.Interfaces;
using DataPerformer.UI;


namespace DataPerformer.UI.BufferedData.UserControls
{
    public partial class UserControlEditDatadase : UserControl
    {
        #region Fields

        IBufferDirectory current;

        #endregion

        #region Ctor
        public UserControlEditDatadase()
        {
            InitializeComponent();
           // newToolStripButton.Image = StaticExtensionDataPerformerUI.BufferDataImageList[3];
        }

        #endregion

        #region Private Members

        private TreeNode selected
        {
            get
            {
                return treeViewDir.SelectedNode;
            }
        }

        /*
        ILogItem SaveFile(string filename)
        {
            IDatabaseInterface d = StaticExtensionEventLogDatabase.Data;
            string fn = Path.GetFileNameWithoutExtension(filename).ToLower();
            if (d.Filenames.Contains(fn))
            {
                MessageBox.Show("File already exists");
                return null;
            }
            using (Stream stream = File.OpenRead(filename))
            {
                ILogDirectory dir = selected.Tag as ILogDirectory;
                IEnumerable<byte[]> data = stream.ToObjectEnumerable().ToByteEnumerable();
                ILogItem it = dir.CreateData(data, fn, fn, "");
                DataGridViewRow row = new DataGridViewRow();
                ILogData ld = it as ILogData;
                row.Tag = it;
                row.CreateCells(dataGridViewFiles,
                    new object[] { ld.Name, ld.Comment, ld.Length, ld.FileName });
                dataGridViewFiles.Rows.Add(row);
                return it;
            }
        }
        */

        void Finish()
        {
            try
            {
                IDatabaseInterface d = StaticExtensionDataPerformerInterfaces.Data;
                d.SubmitChanges();
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }

        void AddDirectory()
        {
            TreeNode s = selected;
            if (s == null)
            {
                return;
            }
            IBufferDirectory d = s.Tag as IBufferDirectory;
            try
            {
                List<string> l = d.GetDirectoryNames();
                for (int i = 1; ; i++)
                {
                    string n = "New folder" + i;
                    if (!l.Contains(n))
                    {
                        IBufferDirectory ld = d.Create(n, "");
                        TreeNode nd = ld.CreateNode(true);
                        s.Nodes.Add(nd);
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }

        void DeleteNode()
        {
            TreeNode s = selected;
            if (s == null)
            {
                return;
            }
            object o = s.Tag;
            if (o is IBufferItem)
            {
                try
                {
                    (o as IBufferItem).Delete();
                    TreeNode p = s.Parent;
                    p.Nodes.Remove(s);
                }
                catch (Exception exception)
                {
                    exception.ShowError();
                }
            }
        }

        private TreeNode Root
        {
            get
            {
                return GetRoot(selected);
            }
        }

        private TreeNode GetRoot(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }
            if (!(node.Parent is TreeNode))
            {
                return node;
            }
            return GetRoot(node.Parent);
        }

        bool IsRoot
        {
            get
            {
                return (selected == Root);
            }
        }

        private bool IsFile
        {
            get
            {
                TreeNode r = Root;
                if (r == null)
                {
                    return false;
                }
                if (r == selected)
                {
                    return false;
                }
                return r.Text.Equals("Files");
            }
        }


        /*
        void NewInterval()
        {
            FormSelectItem form = new FormSelectItem(true);
            if (form.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            AddInterval(form.Selected);
        }

        void AddInterval(ILogData data)
        {
            TreeNode s = selected;
            if (s == null)
            {
                return;
            }
            ILogDirectory d = s.Tag as ILogDirectory;
            if ((d == null) | (data == null))
            {
                return;
            }
            try
            {
                List<string> l = d.GetDirectoryNames();
                for (int i = 1; ; i++)
                {
                    string n = "New interval" + i;
                    if (!l.Contains(n))
                    {
                        ILogInterval ld = d.CreateIntrerval(data, n, "", 0, (uint)data.Length);
                        ShowIntervalTable(d, false);
                        return;
                    }
                }

            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }
        */

        void ShowContent(IBufferDirectory dir)
        {
            return;
            if (dir == current)
            {
                return;
            }
            current = dir;
            bool isFile = IsFile;
            Dictionary<string, IBufferData> d = new Dictionary<string, IBufferData>();
            foreach (object o in current.Children)
            {
                if (o is IBufferData)
                {
                    IBufferData ld = o as IBufferData;
                    d[ld.Name] = ld;
                }
            }
            List<string> lt = new List<string>(d.Keys);
            lt.Sort();
            bool isRoot = IsRoot;
            if (isFile)
            {
                dataGridViewFiles.Rows.Clear();
                foreach (string key in lt)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    IBufferData data = d[key];
                    row.Tag = d[key];
                    row.CreateCells(dataGridViewFiles,
                        new object[] { data.Name, data.Comment, data.Length, data.FileName });
                    dataGridViewFiles.Rows.Add(row);
                }
                toolStripLabelDrag.Visible = !isRoot;
                newToolStripButton.Visible = false;
                dataGridViewFiles.Visible = true;
            }
        }


        void DeleteDataGrid()
        {
            if (dataGridViewFiles.Visible)
            {
                Delete(dataGridViewFiles);
            }
         }

        void Delete(DataGridView data)
        {

            DataGridViewSelectedRowCollection c = data.SelectedRows;
            List<DataGridViewRow> l = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in c)
            {
                l.Add(row);
                (row.Tag as IBufferItem).Delete();
            }
            foreach (DataGridViewRow row in l)
            {
                data.Rows.Remove(row);
            }
        }

        #endregion

        #region EventHanlers

        private void treeViewDir_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (selected != null)
            {
                toolStripButtonCreateDir.Enabled = true;
                toolStripButtonDeleteFolder.Enabled = true;
            }
            else
            {
                toolStripButtonCreateDir.Enabled = true;
                toolStripButtonDeleteFolder.Enabled = true;
                // toolStripButtonDelete.Enabled = true;
            }
            foreach (TreeNode n in treeViewDir.Nodes)
            {
                if (selected == n)
                {

                    toolStripButtonDelete.Enabled = false;
                }
            }

            bool isRoot = IsRoot;
            ///toolStripButtonDelete.Enabled = !isRoot;
            toolStripButtonDeleteFolder.Enabled = !isRoot;

            treeViewDir.LabelEdit = !isRoot;
            object o = selected.Tag;
            if (o is IBufferDirectory)
            {
                ShowContent(o as IBufferDirectory);
            }
        }

        private void UserControlEditDatadase_Load(object sender, EventArgs e)
        {
            IBufferDirectory dir = StaticExtensionDataPerformerInterfaces.Root;
            treeViewDir.ImageList = StaticExtensionDataPerformerUI.BufferDataImageList;
            TreeNode n = dir.CreateNode();
            treeViewDir.Nodes.Add(n);
        }

        private void toolStripButtonCreateDir_Click(object sender, EventArgs e)
        {
            AddDirectory();
        }

        private void treeViewDir_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null)
            {
                return;
            }
            TreeNode s = e.Node;
            if (s == null)
            {
                return;
            }
            object o = s.Tag;
            if (o == null)
            {
                return;
            }
            if (o is IBufferItem)
            {
                IBufferItem item = o as IBufferItem;
                IBufferItem p = item.Parent;
                if (p == null | !(p is IBufferDirectory))
                {
                    MessageBox.Show("Prohibited");
                    return;
                }
                IBufferDirectory d = p as IBufferDirectory;
                List<string> names = d.GetDirectoryNames();
                string name = e.Label;
                if (names.Contains(name))
                {
                    MessageBox.Show("Name alredy exists");
                    return;
                }
                try
                {
                    item.Name = name;
                }
                catch (Exception exception)
                {
                    exception.ShowError();
                }
            }
        }

        private void toolStripButtonDeleteFolder_Click(object sender, EventArgs e)
        {
            DeleteNode();
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewFiles.Rows[e.RowIndex];
            IBufferData d = row.Tag as IBufferData;
            int ri = e.ColumnIndex;
            string text = row.Cells[ri].Value + "";
            if (ri == 1)
            {
                if (d.Comment.Equals(text))
                {
                    return;
                }
                d.Comment = text;
                return;
            }
            if (ri == 0)
            {
                if (d.Name.Equals(text))
                {
                    return;
                }
                IBufferDirectory dir = d.Parent as IBufferDirectory;
                List<string> l = dir.GetDirectoryNames();
                string name = d.Name;
                l.Remove(name);
                if (l.Contains(text))
                {
                    MessageBox.Show(this, "Name already exist");
                    row.Cells[ri].Value = name;
                    return;
                }
                d.Name = text;
            }
        }

  
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView d = sender as DataGridView;
            if (d == null)
            {
                return;
            }
            DataGridViewSelectedRowCollection c = d.SelectedRows;
            bool b = c.Count != 0;
            toolStripButtonDelete.Enabled = b;
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteDataGrid();
        }


        #endregion

    }
}
