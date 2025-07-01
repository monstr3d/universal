using PostgreSQLWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQLWarehouse
{
    internal static class StaticExtension
    {

       internal static PostgreSqlWarehouseContext Context { get; set; } 
    }
}
