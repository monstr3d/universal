using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataWarehouse.Classes;
using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
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

   
        public static async Task Fill(this TreeView treeView,  DatabaseInterface data, string ext, bool recursice, bool leaves, Action<Issue> action)
        {
            IDirectory[] dir = null; 
            var act = () => treeView.Fill(dir, recursice, leaves, action);
            if (!data.SupportsAsync)
            {
                dir = data.GetRoots(new string[] { ext });
                act();
                return;
            }
            var t = data.GetRootsAsync(new string[] { ext });
            await t;
            var r = t.Result;
            dir = (from d in  r select d as IDirectory).ToArray();
            treeView.InvokeIfNeeded(act);
            
         }

        static async void Fill(this TreeView treeView, IEnumerable<IDirectory> dir, bool recursice, bool leaves, Action<Issue> action)
        {
            foreach (IDirectory d in dir)
            {
                var nd = d.GetNode(recursice, leaves, action);
                await nd;
                treeView.Nodes.Add(nd.Result);
            }
            foreach (System.Windows.Forms.TreeNode tn in treeView.Nodes)
            {
                SetDisposed(tn);
            }

        }

        static public async Task FillNode(this IDirectory dir, System.Windows.Forms.TreeNode node, 
            bool recursive, bool leaves, Action<Issue> action)
        {
            if (node.Nodes.Count > 0)
            {
                return;
            }
            if (dir is IDirectoryAsync directoryAsync)
            {
                var t = directoryAsync.LoadChildren();
                await t;
                var tl = directoryAsync.LoadLeaves();
                await tl;
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
            var complete = async () =>
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
                            var n = GetNodeSimple(child, recursive, leaves, action);
                            node.Nodes.Add(n);
                        }
                    }
                    else
                    {
                        var act = () =>
                        {
                            foreach (var child in ld)
                            {
                                var n = leaves ? new Forms.Tree.TreeNode(child, action) : new Forms.Tree.TreeNode(child, leaves, action);
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
                    var n = new Forms.Tree.TreeNode(child, action);
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

        static System.Windows.Forms.TreeNode GetNodeSimple(this IDirectory dir, bool recursive, bool leaves, Action<Issue> action)
        {
            TreeNode node = leaves ? new Forms.Tree.TreeNode(dir, action) : new Forms.Tree.TreeNode(dir, leaves, action);
            return node;
        }


        static async Task<System.Windows.Forms.TreeNode> GetNode(this IDirectory dir, bool recursive , bool leaves, Action<Issue> action)
        {
            var node = dir.GetNodeSimple(recursive, leaves, action);
            var t = dir.FillNode(node, recursive, leaves, action);
            await t;
            return node;
        }


        /// <summary>
        /// Gets node of directory
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static System.Windows.Forms.TreeNode GetNode(this IDirectory dir, 
            Dictionary<INode, TreeNode> nodes, Action<Issue> action)
        {
            
            IChildren<IDirectory> ed = dir;
            List<IDirectory> ld = new List<IDirectory>();
            ld.AddRange(ed.Children);
            ld.Sort(NodeComparer.Singleton);
            foreach (IDirectory dird in ld)
            {
                TreeNode tn = GetNode(dird, nodes, action);
              //  ln.Add(tn);
            }
            List<ILeaf> ll = new List<ILeaf>();
            IChildren<ILeaf> el = dir as IChildren<ILeaf>;
            ll.AddRange(el.Children);
            ll.Sort(NodeComparer.Singleton as IComparer<ILeaf>);
            foreach (ILeaf leaf in ll)
            {
                TreeNode tnl = new Forms.Tree.TreeNode(leaf, action);
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
