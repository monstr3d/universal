using System;

using DataWarehouse.Interfaces;

namespace DataWarehouse.Forms.Tree
{
    public class TreeNode : System.Windows.Forms.TreeNode
    {
        IDirectory directory;

        ILeaf leaf;

        private TreeNode()
        {
            var t = this.TreeView;
            t.Disposed += T_Disposed;
            
        }


        public TreeNode(IDirectory directory)
        {
            this.directory = directory;
            directory.OnDeleteItself += Directory_OnDeleteItself;
            directory.OnAddDirectory += Directory_OnAddDirectory;
            directory.OnAddLeaf += Directory_OnAddLeaf;
            Text = directory.Name;
        }

        public TreeNode(ILeaf leaf)
        {
            this.leaf = leaf;
            leaf.OnDeleteItself += Leaf_OnDeleteItself;
            Text = leaf.Name;
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
