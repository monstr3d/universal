using System;
using System.Collections.Generic;

namespace ConsoleSQLServerWarehouse.OutputDirectory
{
    public partial class ViewBinaryTableInfo
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ext { get; set; }
    }
}
