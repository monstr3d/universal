using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataWarehouse.Interfaces;

using NamedTree;
using WindowsExtensions;

namespace DataWarehouse.Forms.Tree
{
    public class TreeNode : System.Windows.Forms.TreeNode
    {
        IDirectory directory;
        TreeView treeView;
        

        ILeaf leaf;

       void Set()
        {
            if (directory == null)
            {
                leaf.OnDeleteItself += Leaf_OnDeleteItself;
                leaf.OnChangeItself += Leaf_OnChangeItself;
                Tag = leaf;
                return;
            }
            directory.OnDeleteItself += Directory_OnDeleteItself;
            directory.OnAddDirectory += Directory_OnAddDirectory;
            directory.OnAddLeaf += Directory_OnAddLeaf;
            directory.OnChangeItself += Directory_OnChangeItself;
            Tag = directory;
        }

        public async Task Expand(bool leaves)
        {
            if (directory != null)
            {
              directory.FillNode(this, false, leaves);
            }
        }

        bool Leaves { get; set; } = true;

        void Init()
        {
            treeView = this.TreeView;
        }

        #region Ctor

        

        public TreeNode(IDirectory directory) : base(directory.Name, 0, 1)
        {
            Init();
            this.directory = directory;
            Set();
        }

        public TreeNode(IDirectory directory, bool leaves) : base(directory.Name)
        {
            Init();
            this.directory = directory;
            Leaves = leaves;
            Set();
        }
        public TreeNode(ILeaf leaf) : base(leaf.Name, 2, 2)
        {
            Init();
            this.leaf = leaf;
            leaf.OnDeleteItself += Leaf_OnDeleteItself;
            leaf.OnChangeItself += Leaf_OnChangeItself;
            Tag = leaf;
        }

        #endregion

        public void SetDisposed()
        {
            var t = this.TreeView;
            t.Disposed += T_Disposed;
        }

        private void Leaf_OnDeleteItself()
        {

            Remove();
            leaf.OnDeleteItself -= Leaf_OnDeleteItself;
        }

        private void T_Disposed(object sender, EventArgs e)
        {
            if (directory != null)
            {
                directory.OnDeleteItself -= Directory_OnDeleteItself;
                directory.OnAddDirectory -= Directory_OnAddDirectory;
                directory.OnAddLeaf -= Directory_OnAddLeaf;
                directory.OnChangeItself -= Directory_OnChangeItself;
                return;
            }
            leaf.OnDeleteItself -= Leaf_OnDeleteItself;
            leaf.OnChangeItself -= Leaf_OnChangeItself;
        }

        private void Directory_OnAddLeaf(ILeaf obj)
        {
            var node = new TreeNode(obj);
            Nodes.Add(node);
        }

        void Execute<T>(Action<T> action, T t) where T : class
        {
            treeView.InvokeIfNeeded(action, t);
        }

        void Execute(Action action)
        {
            treeView.InvokeIfNeeded(action);
        }


        private void Directory_OnAddDirectory(IDirectory obj)
        {
            Execute(Directory_OnAddDirectoryT, obj);
        }

        private void Directory_OnAddDirectoryT(IDirectory obj)
        {
            var node = Leaves ? new TreeNode(obj) : new TreeNode(obj, false);
            Nodes.Add(node);
        }

        private void Directory_OnDeleteItself()
        {
            directory.OnDeleteItself -= Directory_OnDeleteItself;
            directory.OnAddDirectory -= Directory_OnAddDirectory;
            directory.OnAddLeaf -= Directory_OnAddLeaf;
            Remove();
        }

   

        void Change(INamed named)
        {
            var name = named.Name;
            if (name == Text)
            {
                return;
            }
            Text = name;

        }
        private void Directory_OnChangeItself(IDirectory obj)
        {
            Change(obj);
        }

        private void Leaf_OnChangeItself(ILeaf obj)
        {
            Change(obj);
        }

    }
}
