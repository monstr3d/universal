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
        //  Host=127.0.0.1;Database=PostgreSQL_Warehouse;Username=postgres;Password=GREM0nP0

        internal static PostgreSqlWarehouseContext Context { get; set; } 
    }
}
