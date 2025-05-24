using System;
using DataWarehouse.Interfaces;
using NamedTree;

namespace DataWarehouse.Forms.Tree
{
    public class TreeNode : System.Windows.Forms.TreeNode
    {
        IDirectory directory;

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

        bool Leaves { get; set; } = true;

        #region Ctor

        public TreeNode(IDirectory directory) : base(directory.Name, 0, 1)
        {
            this.directory = directory;
            Set();
        }

        public TreeNode(IDirectory directory, bool leaves) : base(directory.Name)
        {
            this.directory = directory;
            Leaves = leaves;
            Set();
        }
        public TreeNode(ILeaf leaf) : base(leaf.Name, 2, 2)
        {
            this.leaf = leaf;
            leaf.OnDeleteItself += Leaf_OnDeleteItself;
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

        private void Directory_OnAddDirectory(IDirectory obj)
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
