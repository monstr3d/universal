using Event.Log.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event.Log.Database.UI
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    public static class StaticExtensionEventLogDatabaseUI
    {
        static internal IComparer<TreeNode> Comparer = TreeNodeComparer.Singleton;

        static ImageList list = new ImageList();
         
        static internal ImageList ImageList
        {
            get
            {
                return list;
            }
        } 
        
        /// <summary>
        /// Images
        /// </summary>
        static public Image[]  Images
        {
            set
            {
                list = new ImageList();
                list.Images.AddRange(new Image[] { Properties.Resources.Directory.ToBitmap(),
                    Properties.Resources.OpenedDirectory.ToBitmap(),
                value[0], value[1] });
            }
        }

        static internal TreeNode Find(this TreeNode node, string url)
        {
            object o = node.Tag;
            if (o is ILogItem)
            {
                ILogItem li = o as ILogItem;
                if (li.GetUrl().Equals(url))
                {
                    return node;
                }
            }
            foreach (TreeNode tn in node.Nodes)
            {
                TreeNode t = Find(tn, url);
                if (t != null)
                {
                    return t;
                }
            }
            return null;
        }

        static internal TreeNode Find(this TreeView tv, string url)
        {
           foreach (TreeNode node in tv.Nodes)
            {
                TreeNode tn = node.Find(url);
                if (tn != null)
                {
                    return tn;
                }
            }
            return null;
        }

        static internal TreeNode CreateNode(this ILogItem item, 
            bool openedDir = false)
        {
            int n2 = 0;
            int n3 = 1;
            int n4 = 2;
            if (openedDir)
            {
                ++n2;
                ++n3;
                ++n4;
            }
            TreeNode n = null;
            if (item is ILogDirectory)
            {
                ILogDirectory d = item as ILogDirectory;
                List<TreeNode> l = new List<TreeNode>();
                foreach (ILogItem it in d.Children)
                {
                    TreeNode tn = it.CreateNode(openedDir);
                    if (tn != null)
                    {
                        l.Add(it.CreateNode(openedDir));
                    }
                }
                l.Sort(TreeNodeComparer.Singleton);
                n = new TreeNode(item.Name, 0, 1, l.ToArray());
            }
            else
            {
                if (!openedDir)
                {
                    n = new TreeNode(item.Name, 2, 3);
                }
                else
                {
                    return null;
                }
            }
            n.Tag = item;
            return n;
        }

        static StaticExtensionEventLogDatabaseUI()
        {
            list.Images.AddRange(new Image[] { Properties.Resources.Directory.ToBitmap(),
                Properties.Resources.OpenedDirectory.ToBitmap(),
                Properties.Resources.File.ToBitmap(), Properties.Resources.OpenedFile.ToBitmap() });
        }

        #region TreeNodeComparer class

        class TreeNodeComparer : IComparer<TreeNode>
        {

            static internal TreeNodeComparer Singleton = new TreeNodeComparer();

            int IComparer<TreeNode>.Compare(TreeNode x, TreeNode y)
            {
                ILogItem lx = x.Tag as ILogItem;
                ILogItem ly = y.Tag as ILogItem;
                if ((lx is ILogDirectory))
                {
                    if (ly is ILogDirectory)
                    {
                        return x.Text.CompareTo(y.Text);
                    }
                    return -1;
                }
                if (ly is ILogDirectory)
                {
                    return 1;
                }
                return x.Text.CompareTo(y.Text);
            }
        }

        #endregion

    }
}
