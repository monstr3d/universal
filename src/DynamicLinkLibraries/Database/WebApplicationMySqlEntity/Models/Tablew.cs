using System;
using System.Collections.Generic;

namespace MyWebApp.Models;

public partial class Tablew
{
    public ulong Id { get; set; }

    public ulong ParentId { get; set; }

    public string Name { get; set; } = null!;

    public string Extension { get; set; } = null!;
}
