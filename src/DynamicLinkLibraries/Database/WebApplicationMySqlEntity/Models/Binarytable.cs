using System;
using System.Collections.Generic;

namespace MyWebApp.Models;

public partial class Binarytable
{
    public ulong Id { get; set; }

    public ulong ParentId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Extension { get; set; } = null!;

    public byte[] Data { get; set; } = null!;

    public virtual Binarytree Parent { get; set; } = null!;
}
