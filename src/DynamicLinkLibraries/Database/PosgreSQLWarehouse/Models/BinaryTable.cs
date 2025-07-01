using System;
using System.Collections.Generic;

namespace PostgreSQLWarehouse.Models;

public partial class BinaryTable
{
    public Guid Id { get; set; }

    public Guid ParentId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte[] Data { get; set; } = null!;

    public string Length { get; set; } = null!;

    public string Ext { get; set; } = null!;

    public virtual BinaryTree Parent { get; set; } = null!;
}
