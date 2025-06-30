using DataWarehouse.Interfaces;
using ErrorHandler;
using NamedTree;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdbcWarehouse.Interface
{
    internal class Leaf : DataWarehouse.Classes.Abstract.Leaf
    {

        #region Ctor
        public Leaf(IDataRecord record, IDirectory directory, DataBaseInterface posgreSQLWarehouse)
        {
            DataBaseInterface = posgreSQLWarehouse;
            Parent = directory;
            Id = record[0];
            name = record.GetString(2);
            description = record.GetString(3);
            Extension = record.GetString(4);
        }

        public Leaf(ILeafData data, IDirectory directory, decimal id, DataBaseInterface posgreSQLWarehouseInterface) : base(data, directory)
        {
            Id = id;
            DataBaseInterface = posgreSQLWarehouseInterface;
        }

        #endregion

        DataBaseInterface DataBaseInterface { get; init; }


        #region Overriden
        protected override void Add(INode<INode> node)
        {
            throw new OwnNotImplemented("ODBC Leaf");
        }

        protected override byte[] GetDatabaseData()
        {
            throw new OwnNotImplemented("ODBC Leaf");
        }

        protected override void Remove(INode<INode> node)
        {
            throw new OwnNotImplemented("ODBC Leaf");
        }

        protected override bool RemoveFromDatabase()
        {
            throw new OwnNotImplemented("ODBC Leaf");
        }

        protected override bool SetDatabaseData(byte[] data)
        {
            throw new OwnNotImplemented("ODBC Leaf");
        }

        protected override bool SetDatabaseDescription(string description)
        {
            throw new OwnNotImplemented("ODBC Leaf");
        }

        protected override bool SetDatabaseName(string name)
        {
            throw new OwnNotImplemented("ODBC Leaf");
        }

        #endregion
    }
}
