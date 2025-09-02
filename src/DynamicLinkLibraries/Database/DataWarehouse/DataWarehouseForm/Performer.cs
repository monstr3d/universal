using System.Threading;
using System.Windows.Forms;

using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using NamedTree;

namespace DataWarehouse.Forms
{
    public class Performer : DataWarehouse.Performer
    {
        public Performer() : base() { }

        CancellationToken cancellationToken;

        public Performer(CancellationToken cancellationToken)  : base(cancellationToken) 
        {
        }

        public async void BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var node = e.Node;
            var tag = node.Tag;
            if (tag is IChildren<IDirectory> children)
            {
                var ch = children.Children;
                foreach (var child in ch)
                {
                    if (child is IDirectoryAsync Async)
                    {
                        var t = Async.LoadChildren(cancellationToken);
                        await t;
                        var tl = Async.LoadLeaves(cancellationToken);
                        await tl;
                    }
                }
            }
        }
    }
}