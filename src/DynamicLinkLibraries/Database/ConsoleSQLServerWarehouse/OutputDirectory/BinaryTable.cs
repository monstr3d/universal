﻿using System;
using System.Collections.Generic;

namespace ConsoleSQLServerWarehouse.OutputDirectory
{
    public partial class BinaryTable
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Data { get; set; }
        public string Length { get; set; }
        public string Ext { get; set; }

        public virtual BinaryTree Parent { get; set; }
    }
}
