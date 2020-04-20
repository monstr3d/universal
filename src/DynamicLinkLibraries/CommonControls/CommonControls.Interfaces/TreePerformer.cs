using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using CommonControls.Interfaces;

namespace CommonControls
{
    /// <summary>
    /// Preformer of tree operations
    /// </summary>
    public static class TreePerformer
    {

        /// <summary>
        /// Adds object
        /// </summary>
        /// <param name="o">Object</param>
        /// <param name="creator">Tree creator</param>
        /// <param name="tree">Tree</param>
        /// <returns>Active node</returns>
        public static TreeNode Add(object o, IChildrenCreator creator, TreeView tree)
        {
            string name = creator.GetObjectName(o);   
            TreeNode tn = new TreeNode(name);
            int im = creator.GetImageIndex(o);
            if (im >= 0)
            {
                tn.ImageIndex = im;
                tn.SelectedImageIndex = im;
            }
            tree.Nodes.Add(tn);
            tn.Tag = o;
            Add(tn, creator);
            return tn;
        }

        /// <summary>
        /// Adds object
        /// </summary>
        /// <param name="o">The object</param>
        /// <param name="creator">Children creator</param>
        /// <param name="parent">Parent node</param>
        /// <returns>Current node</returns>
        public static TreeNode Add(object o, IChildrenCreator creator, TreeNode parent)
        {
            string name = creator.GetObjectName(o);
            TreeNode tn = new TreeNode(name);
            int im = creator.GetImageIndex(o);
            if (im >= 0)
            {
                tn.ImageIndex = im;
                tn.SelectedImageIndex = im;
            }
            parent.Nodes.Add(tn);
            tn.Tag = o;
            Add(tn, creator);
            return tn;
        }


        /// <summary>
        /// Adds crerator
        /// </summary>
        /// <param name="parent">Parent node</param>
        /// <param name="creator">Creator</param>
        public static void Add(TreeNode parent, IChildrenCreator creator)
        {
            if (parent.Tag == null)
            {
                return;
            }
            object o = parent.Tag;
            if (creator == null)
            {
                return;
            }
            object[] ch = creator.GetChildern(o);
            if (ch == null)
            {
                return;
            }
            foreach (object child in ch)
            {
                string name = creator.GetObjectName(child);
                TreeNode tn = new TreeNode(name);
                int im = creator.GetImageIndex(child);
                if (im >= 0)
                {
                    tn.ImageIndex = im;
                    tn.SelectedImageIndex = im;
                }
                parent.Nodes.Add(tn);
                tn.Tag = child;
                Add(tn, creator);
            }
        }
    }
}
