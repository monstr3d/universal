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


        IDictionary<object, object> IDatabaseInterface.GetLeaves(string login, string password, object key, string extension)
        {
            throw new OwnNotImplemented("Leaves");
        }



        byte[] IDatabaseInterface.GetData(string login, string password, object key, string id, ref string extension)
        {
       
            return (id.ToLeaf() as IData).Data;
        }

        IDictionary<object, object> IDatabaseInterface.GetItems(string login, string password, object key, string extension)
        {
            return StaticExtension.Get(extension);        
        }

        IDirectory[] IDatabaseInterface.GetRoots(string login, string password, object key, string[] extensions)
        {
            return StaticExtension.Roots.ToArray();
        }

        void IDatabaseInterface.Login(string login, string password, object key)
        {
            
        }

        void IDatabaseInterface.Refresh(string login, string password, object key, string[] extension)
        {
            SQLWarehouse.Refresh();
        }

        #endregion

        
    }
}
