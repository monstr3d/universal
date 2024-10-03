using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// StaticExtesion
    /// </summary>
    public static class StaticExtensionCommonControlsInterfaces
    {
        /// <summary>
        /// Full expand
        /// </summary>
        /// <param name="node">Node</param>
        public static void FullExpand(this TreeNode node)
        {
            TreeNode p = node.Parent;
            if (p == null)
            {
                return;
            }
            p.Expand();
            p.FullExpand();
        }

        /// <summary>
        /// Selects node
        /// </summary>
        /// <param name="node">Node for selection</param>
        public static void Select(this TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            node.FullExpand();
            TreeView t = node.TreeView;
            t.SelectedNode = node;
        }

        /// <summary>
        /// Performs operation with tree
        /// </summary>
        /// <typeparam name="T">Tag type</typeparam>
        /// <param name="tree">Tree</param>
        /// <param name="function">Operation funstion</param>
        /// <returns>True in success</returns>
        public static bool Perform<T>(this TreeView tree, Func<T, TreeNode, bool> function) where T : class
        {
            foreach (TreeNode n in tree.Nodes)
            {
                if (Perform<T>(n, function))
                {
                    return true;
                }
            }
            return false;
        }

        

        /// <summary>
        /// Performs operation with node
        /// </summary>
        /// <typeparam name="T">Tag type</typeparam>
        /// <param name="node">Node</param>
        /// <param name="function">Operation funstion</param>
        /// <returns>True in success</returns>
        public static bool Perform<T>(this TreeNode node, Func<T, TreeNode, bool> function) where T : class
        {
            object o = node.Tag;
            if (o != null)
            {
                if (o is T)
                {
                    T t = o as T;
                    if (function(t, node))
                    {
                        return true;
                    }
                }
            }
            foreach (TreeNode n in node.Nodes)
            {
                if (Perform<T>(n, function))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
