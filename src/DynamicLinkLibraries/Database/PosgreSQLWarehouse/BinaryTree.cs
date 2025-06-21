using System;
using System.Collections.Generic;

namespace PosgreSQLWarehouse;

public partial class BinaryTree
{
    public Guid Id { get; set; }

    public Guid ParentId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Ext { get; set; } = null!;

    public virtual ICollection<BinaryTable> BinaryTables { get; set; } = new List<BinaryTable>();

    public virtual ICollection<BinaryTree> InverseParent { get; set; } = new List<BinaryTree>();

    public virtual BinaryTree Parent { get; set; } = null!;
}
