using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;

using Event.Basic;
using Event.Log.Database.Interfaces;
using Event.Log.Database.UI.Forms;
using ErrorHandler;

namespace Event.Log.Database.UI.UserControls
{
    /// <summary>
    /// Database editor
    /// </summary>
    public partial class UserControlEditDatadase : UserControl
    {

        #region Fields

        ILogDirectory current;

        #endregion

        #region Ctor
        public UserControlEditDatadase()
        {
            InitializeComponent();
            newToolStripButton.Image = StaticExtensionEventLogDatabaseUI.ImageList.Images[3];
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

        void Finish()
        {
            try
            {
                IDatabaseInterface d = StaticExtensionEventLogDatabase.Data;
                d.SubmitChanges();
            }
            catch (Exception exception)
            {
                exception.HandleException();
            }
        }

        void AddDirectory()
        {
            TreeNode s = selected;
            if (s == null)
            {
                return;
            }
            ILogDirectory d = s.Tag as ILogDirectory;
            try
            {
                List<string> l = d.GetDirectoryNames();
                for (int i = 1; ; i++)
                {
                    string n = "New folder" + i;
                    if (!l.Contains(n))
                    {
                        ILogDirectory ld = d.Create(n, "");
                        TreeNode nd = ld.CreateNode(true);
                        s.Nodes.Add(nd);
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                exception.HandleException();
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
            if (o is ILogItem)
            {
                try
                {
                    (o as ILogItem).Delete();
                    TreeNode p = s.Parent;
                    p.Nodes.Remove(s);
                }
                catch (Exception exception)
                {
                    exception.HandleException();
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

        private string[] DetectUrl(DragEventArgs args)
        {
            IDataObject d = args.Data;
            List<string> l = new List<string>();
            if (d.GetDataPresent("FileDrop"))
            {
                string[] s = d.GetData("FileDrop") as string[];
                foreach (string p in s)
                {
                    string ext = Path.GetExtension(p).ToLower();
                    if (ext.Equals(".filelog"))
                    {
                        l.Add(p);
                    }
                }
            }
            return (l.Count == 0) ? null : l.ToArray();
        }

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
                exception.HandleException();
            }
        }

        void ShowContent(ILogDirectory dir)
        {
            if (dir == current)
            {
                return;
            }
            current = dir;
            bool isFile = IsFile;
            Dictionary<string, ILogData> d = new Dictionary<string, ILogData>();
            foreach (object o in current.Children)
            {
                if (o is ILogData)
                {
                    ILogData ld = o as ILogData;
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
                    ILogData data = d[key];
                    row.Tag = d[key];
                    row.CreateCells(dataGridViewFiles,
                        new object[] { data.Name, data.Comment, data.Length, data.FileName });
                    dataGridViewFiles.Rows.Add(row);
                }
                toolStripLabelDrag.Visible = !isRoot;
                newToolStripButton.Visible = false;
                dataGridViewFiles.Visible = true;
                dataGridViewIntervals.Visible = false;
            }
            else
            {
                ShowIntervalTable(dir, isFile);
            }
        }

        void ShowIntervalTable(ILogDirectory dir, bool isFile)
        {
            Dictionary<string, ILogData> d = new Dictionary<string, ILogData>();
            foreach (object o in current.Children)
            {
                if (o is ILogData)
                {
                    ILogData ld = o as ILogData;
                    d[ld.Name] = ld;
                }
            }
            List<string> lt = new List<string>(d.Keys);
            lt.Sort();
            bool isRoot = IsRoot;
            dataGridViewIntervals.Rows.Clear();
            foreach (string key in lt)
            {
                DataGridViewRow row = new DataGridViewRow();
                ILogData data = d[key];
                ILogInterval i = data as ILogInterval;
                row.Tag = d[key];
                row.CreateCells(dataGridViewIntervals,
                    new object[] { data.Name, data.Comment, i.Begin, i.End, data.FileName });
                dataGridViewIntervals.Rows.Add(row);
            }
            toolStripLabelDrag.Visible = false;
            newToolStripButton.Visible = !isRoot;
            dataGridViewFiles.Visible = false;
            dataGridViewIntervals.Visible = true;
        }

        void DeleteDataGrid()
        {
            if (dataGridViewFiles.Visible)
            {
                Delete(dataGridViewFiles);
            }
            if (dataGridViewIntervals.Visible)
            {
                Delete(dataGridViewIntervals);
            }
        }

        void Delete(DataGridView data)
        {

            DataGridViewSelectedRowCollection c = data.SelectedRows;
            List<DataGridViewRow> l = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in c)
            {
                l.Add(row);
                (row.Tag as ILogItem).Delete();
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
            if (o is ILogDirectory)
            {
                ShowContent(o as ILogDirectory);
            }
        }

        private void UserControlEditDatadase_Load(object sender, EventArgs e)
        {
            ILogDirectory[] dirs = StaticExtensionEventLogDatabase.Roots;
            treeViewDir.ImageList = StaticExtensionEventLogDatabaseUI.ImageList;
            foreach (ILogDirectory d in dirs)
            {
                TreeNode n = d.CreateNode(true);
                treeViewDir.Nodes.Add(n);
            }
        }

        private void toolStripButtonCreateDir_Click(object sender, EventArgs e)
        {
            AddDirectory();
        }

        private void UserControlEditDatadase_DragDrop(object sender, DragEventArgs e)
        {
            if (!toolStripLabelDrag.Visible)
            {
                return;
            }
            string[] s = DetectUrl(e);
            foreach (string file in s)
            {
                SaveFile(file);
            }
        }

        private void UserControlEditDatadase_DragEnter(object sender, DragEventArgs e)
        {
            if (toolStripLabelDrag.Visible)
            {
                if (DetectUrl(e) != null)
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void treeViewDir_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
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
            if (o is ILogItem)
            {
                ILogItem item = o as ILogItem;
                ILogItem p = item.Parent;
                if (p == null | !(p is ILogDirectory))
                {
                    MessageBox.Show("Prohibited");
                    return;
                }
                ILogDirectory d = p as ILogDirectory;
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
                    exception.HandleException();
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
            ILogData d = row.Tag as ILogData;
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
                ILogDirectory dir = d.Parent as ILogDirectory;
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

        private void dataGridViewIntervals_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewIntervals.Rows[e.RowIndex];
            ILogData d = row.Tag as ILogData;
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
                ILogDirectory dir = d.Parent as ILogDirectory;
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
                return;
            }
            ILogInterval interval = d as ILogInterval;
            try
            {
                uint number = uint.Parse(text);
                if (number == 1)
                {
                    number = 0;
                }
                if (ri == 2)
                {
                    interval.Begin = number;
                }
                if (ri == 3)
                {
                    interval.End = number;
                }
            }
            catch (Exception exception)
            {
                exception.HandleException();
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


        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewInterval();
        }

        #endregion


    }
}