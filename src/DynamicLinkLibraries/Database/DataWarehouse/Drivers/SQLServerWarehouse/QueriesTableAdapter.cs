using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using DataWarehouse.Interfaces;

using ErrorHandler;

using NamedTree;


namespace SQLServerWarehouse.DataSetWarehouseTableAdapters
{
    public partial class QueriesTableAdapter  : IDatabaseInterface
    {
        #region Fields

       internal Dictionary<Guid, DataSetWarehouse.BinaryTableRow> binaryRows =
            new Dictionary<Guid, DataSetWarehouse.BinaryTableRow>();

        #endregion

        public void SetConnection(SqlConnection connection)
        {
            foreach (var command in CommandCollection)
            {
                command.Connection = connection;
            }
        }

        #region Own Members






        #endregion

        #region IDatabaseInterface implementation

        IDirectory[] IDatabaseInterface.GetRoots(params string[] extensions)
        {
            return StaticExtension.Roots.ToArray();
        }

        #endregion

        
    }
}
