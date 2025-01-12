using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerWarehouse
{
    namespace DataSetWarehouseTableAdapters
    {

        public partial class InsertBinaryTableAdapter
        {
            public void SetConnection(SqlConnection connection)
            {
                Connection = connection;
            }
        }

        public partial class SelectBinaryTreeTableAdapter
        {
            public void SetConnection(SqlConnection connection)
            {
                Connection = connection;
            }
        }

        public partial class SelectBinaryTableTableAdapter
        {
            public void SetConnection(SqlConnection connection)
            {
                Connection = connection;
            }
        }

        public partial class SelectBinaryTableAdapter
        {
            public void SetConnection(SqlConnection connection)
            {
                Connection = connection;
            }
        }
        public partial class InsertTreeTableAdapter
        {
            public void SetConnection(SqlConnection connection)
            {
                Connection = connection;
            }
        }

        public partial class SelectBinaryContentsTableAdapter
        {
            public void SetConnection(SqlConnection connection)
            {
                Connection = connection;
            }
        }

        public partial class  InsertBinaryNodeTableAdapter
        {
            public void SetConnection(SqlConnection connection)
            {
                Connection = connection;
            }
        }
    }
}
