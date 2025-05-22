using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataWarehouse.Interfaces;
using NamedTree;

namespace DataWarehouse
{
    /// <summary>
    /// Extension methods
    /// </summary>
    static public class StaticExtensionDataWarehouseForm
    {
        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="exception">Error exception</param>
        static internal void ShowError(this Control control, Exception exception)
        {
            //control.HandleException(exception, FormulaEditor.UI.Utils.ControlUtilites.Resources);
        }

        /// <summary>
        /// Loads resources for control
        /// </summary>
        /// <param name="control">Control</param>
        static public void LoadControlResources(this Control control)
        {
            ResourceService.StaticExtensionResourceService.LoadControlResources(control, DataWarehouse.Utils.ControlUtilites.Resources);
        }

        /// <summary>
        /// Gets node of directory
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static TreeNode GetNode(this IDirectory dir, Dictionary<INode, TreeNode> nodes)
        {
            List<TreeNode> ln = new List<TreeNode>();
            IChildren<IDirectory> ed = dir;
            List<IDirectory> ld = new List<IDirectory>();
            ld.AddRange(ed.Children);
            ld.Sort(NodeComparer.Singleton);
            foreach (IDirectory dird in ld)
            {
                
                TreeNode tn = GetNode(dird, nodes);
                ln.Add(tn);
            }
            List<ILeaf> ll = new List<ILeaf>();
            IChildren<ILeaf> el = dir as IChildren<ILeaf>;
            ll.AddRange(el.Children);
            ll.Sort(NodeComparer.Singleton as IComparer<ILeaf>);
            foreach (ILeaf leaf in ll)
            {
                TreeNode tnl = new TreeNode(leaf.Name, 2, 2);
                tnl.Tag = leaf;
                nodes[leaf] = tnl;
                ln.Add(tnl);
            }
            TreeNode node = new TreeNode(dir.Name, 0, 1, ln.ToArray());
            nodes[dir] = node;
            return node;
        }

    }
}
