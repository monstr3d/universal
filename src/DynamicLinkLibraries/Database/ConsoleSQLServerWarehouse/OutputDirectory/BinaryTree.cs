using System;
using System.Collections.Generic;

namespace ConsoleSQLServerWarehouse.OutputDirectory
{
    public partial class BinaryTree
    {
        public BinaryTree()
        {
            BinaryTable = new HashSet<BinaryTable>();
            InverseParent = new HashSet<BinaryTree>();
        }

        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ext { get; set; }

        public virtual BinaryTree Parent { get; set; }
        public virtual ICollection<BinaryTable> BinaryTable { get; set; }
        public virtual ICollection<BinaryTree> InverseParent { get; set; }
    }
}
