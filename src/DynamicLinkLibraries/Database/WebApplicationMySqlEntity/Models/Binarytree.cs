using System;
using System.Collections.Generic;

namespace MyWebApp.Models;

public partial class Binarytree
{
    public ulong Id { get; set; }

    public ulong ParentId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Extension { get; set; } = null!;

    public virtual ICollection<Binarytable> Binarytables { get; set; } = new List<Binarytable>();

    public virtual ICollection<Binarytree> InverseParent { get; set; } = new List<Binarytree>();

    public virtual Binarytree Parent { get; set; } = null!;
}
