using System;
using System.Collections.Generic;

#nullable disable

namespace SQLServerWarehouse.Models
{
    public partial class BinaryTree
    {
        public BinaryTree()
        {
            BinaryTables = new HashSet<BinaryTable>();
            InverseParent = new HashSet<BinaryTree>();
        }

        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public virtual string Name { get; set; }
        public string Description { get; set; }
        public string Ext { get; set; }

        public virtual BinaryTree Parent { get; set; }
        public virtual ICollection<BinaryTable> BinaryTables { get; set; }
        public virtual ICollection<BinaryTree> InverseParent { get; set; }
    }
}
