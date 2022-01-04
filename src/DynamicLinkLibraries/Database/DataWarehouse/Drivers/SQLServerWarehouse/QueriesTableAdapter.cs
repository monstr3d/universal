using System;
using System.Collections.Generic;
using System.Text;
using SQLServerWarehouse.DataSetWarehouseTableAdapters;
using System.Data.Common;
using DataWarehouse.Interfaces;

namespace SQLServerWarehouse.DataSetWarehouseTableAdapters
{
    public partial class QueriesTableAdapter  : IDatabaseInterface
    {
        #region Fields

       internal Dictionary<Guid, DataSetWarehouse.BinaryTableRow> binaryRows =
            new Dictionary<Guid, DataSetWarehouse.BinaryTableRow>();

        #endregion

        

        #region Own Members




   
   
        #endregion

        #region IDatabaseInterface implementation

        byte[] IDatabaseInterface.GetData(string login, string password, object key, string id, ref string extension)
        {
            throw new NotImplementedException();
        }

        IDictionary<object, object> IDatabaseInterface.GetItems(string login, string password, object key, string extension)
        {
            throw new NotImplementedException();
        }

        IDirectory[] IDatabaseInterface.GetRoots(string login, string password, object key, string[] extensions)
        {
            throw new NotImplementedException();
        }

        void IDatabaseInterface.Login(string login, string password, object key)
        {
            
        }

        void IDatabaseInterface.Refresh(string login, string password, object key, string[] extension)
        {
            throw new NotImplementedException();
        }

        #endregion

        
    }
}
