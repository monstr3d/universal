using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataWarehouse.Classes;
using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using ErrorHandler;
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

        static void Wrap(System.Windows.Forms.TreeView treeView)
        {
            var curs = treeView.Cursor;
           // treeView.Cursor = Cursors.WaitCursor;
            treeView.Enabled = false;
            try
            {
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            treeView.Cursor = Cursors.Default;
            treeView.Enabled = true;

        }

        public static async Task Fill(this TreeView treeView,  DatabaseInterface data, string ext, bool recursice, bool leaves, Action<Issue> action)
        {
            treeView.Cursor = Cursors.WaitCursor;
            treeView.Enabled = false;
            try
            {
                IDirectory[] dir = null;
                var act = () =>
                {
                    treeView.Fill(dir, recursice, leaves, action);
                };
                if (!data.SupportsAsync)
                {
                    dir = data.GetRoots(new string[] { ext });
                    act();
                    return;
                }
                var t = data.GetRootsAsync(new string[] { ext });
                await t;
                var r = t.Result;
                dir = (from d in r select d as IDirectory).ToArray();
                treeView.InvokeIfNeeded(act);
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            var actf = () =>
            {
                treeView.Cursor = Cursors.Default;
                treeView.Enabled = true;
            };
            treeView.InvokeIfNeeded(actf);
            

        }

        static async void Fill(this TreeView treeView, IEnumerable<IDirectory> dir, bool recursice, bool leaves, Action<Issue> action)
        {
            var curs = treeView.Cursor;
            treeView.Cursor = Cursors.WaitCursor;
            treeView.Enabled = false;
            try
            {
                foreach (IDirectory d in dir)
                {
                    var nd = d.GetNode(recursice, leaves, action);
                    treeView.Nodes.Add(nd);
                    var t = d.FillNode(nd, recursice, leaves, action);
                    await t;
                }
                foreach (System.Windows.Forms.TreeNode tn in treeView.Nodes)
                {
                    SetDisposed(tn);
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            var actf = () =>
            {
                treeView.Cursor = Cursors.Default;
                treeView.Enabled = true;
            };
            treeView.InvokeIfNeeded(actf);

        }

        static public async Task FillNode(this IDirectory dir, 
            System.Windows.Forms.TreeNode node,
            bool recursive, bool leaves, Action<Issue> action)
        {
            var treeView = node.TreeView;
            var curs = treeView.Cursor;
            treeView.Cursor = Cursors.WaitCursor;
            treeView.Enabled = false;
            try
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
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            var actf = () =>
            {
                treeView.Cursor = Cursors.Default;
                treeView.Enabled = true;
            };
            treeView.InvokeIfNeeded(actf);


            return;
            IEnumerable<IDirectory> dirs = null;
            IEnumerable<ILeaf> cs = null; ;
            IChildren<IDirectory> ed = dir;
            dirs = ed.Children;
            if (leaves)
            {
                IChildren<ILeaf> lde = dir;
                cs = lde.Children;
            }
            if (dirs.Any())
            {
                var ldir = new List<IDirectory>();
                foreach (var dd in dirs)
                {
                    if (ldir.Contains(dd))
                    {
                        continue;
                    }
                }
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
        }

        static System.Windows.Forms.TreeNode GetNodeSimple(this IDirectory dir, bool recursive, bool leaves, Action<Issue> action)
        {
            TreeNode node = leaves ? new Forms.Tree.TreeNode(dir, action) : new Forms.Tree.TreeNode(dir, leaves, action);
            return node;
        }


        static TreeNode GetNode(this IDirectory dir, bool recursive, bool leaves, Action<Issue> action)
        {
            var node = dir.GetNodeSimple(recursive, leaves, action);
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
            TreeView treeView = null;
            if (!nodes.Any())
            {
                return null;
            }
            foreach (var node in nodes)
            {
                treeView = node.Value.TreeView;
                break;
            }
            if (treeView == null)
            {
                return null;
            }
            var curs = treeView.Cursor;
            treeView.Cursor = Cursors.WaitCursor;
            treeView.Enabled = false;
            try
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

            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            treeView.Cursor = Cursors.Default;
            treeView.Enabled = true;

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
