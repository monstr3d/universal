using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataWarehouse.Interfaces;
using ErrorHandler;
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

        private void Leaf_OnDeleteItself(object obj)
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

        private void Directory_OnAddLeafT(object obj)
        {
    /*        if (obj.Parent == null)
            {
                throw new OwnNotImplemented();
            }
            var node = new TreeNode(obj);
            Nodes.Add(node);*/
        }
        private void Directory_OnAddLeaf(object obj)
        {
            if (Leaves)
            {
                Execute(Directory_OnAddLeafT, obj);
            }
        }

        void Execute<T>(Action<T> action, T t) where T : class
        {
            treeView.InvokeIfNeeded(action, t);
        }

        void Execute(Action action)
        {
            treeView.InvokeIfNeeded(action);
        }


        private void Directory_OnAddDirectory(object obj)
        {
            
            Execute(Directory_OnAddDirectoryT, obj);
        }

        private void Directory_OnAddDirectoryT(object obj)
        {
         /*   if (obj == null)
            {
                throw new OwnNotImplemented("NULL DIRECTORY");
            }
            if (obj.Parent == null)
            {
                throw new OwnNotImplemented("NULL DIRECTORY");

            }

            var node = Leaves ? new TreeNode(obj) : new TreeNode(obj, false);
            Nodes.Add(node);*/
        }

        private void Directory_OnDeleteItself(object obj)
        {
            if (directory.Parent != null)
            {
                throw new OwnNotImplemented();
            }
            Execute(Directory_OnDeleteItselfT);
        }

        private void Directory_OnDeleteItselfT()
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
        private void Directory_OnChangeItself(object obj)
        {
           // Change(obj);
        }

        private void Leaf_OnChangeItself(object obj)
        {
           // Change(obj);
        }

    }
}
