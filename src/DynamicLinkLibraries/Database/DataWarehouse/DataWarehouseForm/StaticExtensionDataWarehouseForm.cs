using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using DataWarehouse.Interfaces;
using NamedTree;

using WindowsExtensions;

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

        static TreeNode Get(ILeaf leaf)
        {
            return new Forms.Tree.TreeNode(leaf);
        }

        public static void Fill(this TreeView treeView,  DatabaseInterface data, string ext, bool recursice = false, bool leaves = true)
        {
            IDirectory[] dir = data.GetRoots(new string[] { ext });
            foreach (IDirectory d in dir)
            {
                var nd = d.GetNode(recursice, leaves);
                treeView.Nodes.Add(nd);
            }
            foreach (System.Windows.Forms.TreeNode tn in treeView.Nodes)
            {
                SetDisposed(tn);
            }
        }

        static public async void FillNode(this IDirectory dir, System.Windows.Forms.TreeNode node,  bool recursive = false, bool leaves = true)
        {
            if (node.Nodes.Count > 0)
            {
                return;
            }
            IEnumerable<IDirectory> dirs = null;
            IEnumerable<ILeaf> cs = null; ;
            var act = () =>
            {
                IChildren<IDirectory> ed = dir;
                dirs = ed.Children;
                if (leaves)
                {
                    IChildren<ILeaf> lde = dir;
                    cs = lde.Children;

                }
            };
    //        var task = Task.FromResult(act);
            var complete = () =>
            {
                if (dirs.Any())
                {
                    List<IDirectory> ld = new List<IDirectory>();
                    ld.AddRange(dirs);
                    ld.Sort(NodeComparer.Singleton);
                    if (recursive)
                    {
                        foreach (var child in ld)
                        {
                            var n = GetNode(child, recursive, leaves);
                            node.Nodes.Add(n);
                        }
                    }
                    else
                    {
                        var act = () =>
                        {
                            foreach (var child in ld)
                            {
                                var n = leaves ? new Forms.Tree.TreeNode(child) : new Forms.Tree.TreeNode(child, leaves);
                                node.Nodes.Add(n);
                            }
                        };
                        
                        node.TreeView.InvokeIfNeeded(act);
                    }
                }
                if (!leaves)
                {
                    return;
                }
                if (cs == null || !cs.Any())
                {
                    return;
                }

                var ldp = new List<ILeaf>();
                ldp.AddRange(cs);
                ldp.Sort(NodeComparer.Singleton);
                foreach (var child in ldp)
                {
                    var n = Get(child);
                    n.Tag = child;
                    node.Nodes.Add(n);
                }
            };
            /*
            task.GetAwaiter().OnCompleted(complete);
            if (!task.IsCompleted)
            {
                task.Start();
            }
            await task;*/
            act();
            complete();
        }

        static  System.Windows.Forms.TreeNode GetNode(this IDirectory dir, bool recursive = false, bool leaves = true)
        {
            System.Windows.Forms.TreeNode node = leaves ?  new Forms.Tree.TreeNode(dir) : new Forms.Tree.TreeNode(dir, leaves);
            dir.FillNode(node, recursive, leaves);
            return node;
        }


        /// <summary>
        /// Gets node of directory
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static System.Windows.Forms.TreeNode GetNode(this IDirectory dir, Dictionary<INode, TreeNode> nodes)
        {
            
            IChildren<IDirectory> ed = dir;
            List<IDirectory> ld = new List<IDirectory>();
            ld.AddRange(ed.Children);
            ld.Sort(NodeComparer.Singleton);
            foreach (IDirectory dird in ld)
            {
                TreeNode tn = GetNode(dird, nodes);
              //  ln.Add(tn);
            }
            List<ILeaf> ll = new List<ILeaf>();
            IChildren<ILeaf> el = dir as IChildren<ILeaf>;
            ll.AddRange(el.Children);
            ll.Sort(NodeComparer.Singleton as IComparer<ILeaf>);
            foreach (ILeaf leaf in ll)
            {
                TreeNode tnl = Get(leaf);
                tnl.Tag = leaf;
                nodes[leaf] = tnl;
              //  ln.Add(tnl);
            }
           // TreeNode node = Get(dir, ln.ToArray());
         //   nodes[dir] = node;
           // node.SetDisposed();
            return null;
        }

        static void SetDisposed(this System.Windows.Forms.TreeNode node)
        {
            var nd = node as DataWarehouse.Forms.Tree.TreeNode;
            nd.SetDisposed();
            foreach (System.Windows.Forms.TreeNode n in node.Nodes)
            {
                n.SetDisposed();
            }
        }

    }
}
