using System.Windows.Forms;

using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using NamedTree;

namespace DataWarehouse.Forms
{
    public class Performer
    {
        public async void BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var node = e.Node;
            var tag = node.Tag;
            if (tag is IChildren<IDirectory> children)
            {
                var ch = children.Children;
                foreach (var child in ch)
                {
                    if (child is IDirectoryAsync async)
                    {
                        await async.LoadChildren();
                        await async.LoadLeaves();
                    }
                }
            }
        }
    }
}
