using System;
using DataWarehouse.Interfaces;

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
                return;
            }
            directory.OnDeleteItself += Directory_OnDeleteItself;
            directory.OnAddDirectory += Directory_OnAddDirectory;
            directory.OnAddLeaf += Directory_OnAddLeaf;

        }

        public TreeNode(IDirectory directory) : base(directory.Name, 0, 1)
        {
            this.directory = directory;
            Set();
        }

        public TreeNode(IDirectory directory, bool pure) : base(directory.Name)
        {
            this.directory = directory; 
            Set();
        }
        public TreeNode(ILeaf leaf) : base(leaf.Name, 2, 2)
        {
            this.leaf = leaf;
            leaf.OnDeleteItself += Leaf_OnDeleteItself;
        }



        public  void SetDisposed()
        {
            var t = this.TreeView;
            t.Disposed += T_Disposed;
        }

        private void Leaf_OnDeleteItself(ILeaf obj)
        {

            Remove();
            leaf.OnDeleteItself += Leaf_OnDeleteItself;
        }

        private void T_Disposed(object sender, EventArgs e)
        {
            if (directory != null)
            {
                directory.OnDeleteItself -= Directory_OnDeleteItself;
                directory.OnAddDirectory -= Directory_OnAddDirectory;
                directory.OnAddLeaf -= Directory_OnAddLeaf;
                return;
            }
            leaf.OnDeleteItself -= Leaf_OnDeleteItself;
            
        }

        private void Directory_OnAddLeaf(ILeaf obj)
        {
            var node = new TreeNode(obj);
            Nodes.Add(node);
        }

        private void Directory_OnAddDirectory(IDirectory obj)
        {
            var node = new TreeNode(obj);
            Nodes.Add(node);
        }

        private void Directory_OnDeleteItself(IDirectory obj)
        {
            directory.OnDeleteItself -= Directory_OnDeleteItself;
            directory.OnAddDirectory -= Directory_OnAddDirectory;
            directory.OnAddLeaf -= Directory_OnAddLeaf;
            Remove();
        }
    }
}
