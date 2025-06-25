using PosgreSQLWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosgreSQLWarehouse
{
    internal static class StaticExtension
    {

       internal static PostgreSqlWarehouseContext Context { get; set; } 
    }
}
