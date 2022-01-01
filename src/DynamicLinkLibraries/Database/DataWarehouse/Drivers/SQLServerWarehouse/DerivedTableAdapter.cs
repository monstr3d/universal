using System;
using System.Collections.Generic;
using System.Text;
using SQLServerWarehouse.DataSetWarehouseTableAdapters;
using System.Data.Common;

namespace SQLServerWarehouse
{
    class DerivedTableAdapter : QueriesTableAdapter
    {

        internal void SetConnection(DbConnection connection)
        {
            foreach (DbCommand command in CommandCollection)
            {
                command.Connection = connection;
            }
        }
    }
}
