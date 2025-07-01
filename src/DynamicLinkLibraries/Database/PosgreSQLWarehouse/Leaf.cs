using System.Data;

using DataWarehouse.Interfaces;
using ErrorHandler;
using NamedTree;

namespace PostgreSQLWarehouse
{
    internal class Leaf : DataWarehouse.Classes.Abstract.Leaf
    {

        #region Ctor
        protected Leaf()
        {

        }

        public Leaf(IDataRecord record, IDirectory directory, PostgreSQLWarehouseInterface posgreSQLWarehouse)
        {
            PostgreSQLWarehouseInterface = posgreSQLWarehouse;
            Parent = directory;
            Id = record[0];
            name = record.GetString(2);
            description = record.GetString(3);
            Extension = record.GetString(4);
        }

        public Leaf(ILeafData data, IDirectory directory, Guid id, PostgreSQLWarehouseInterface posgreSQLWarehouseInterface) : base(data, directory)
        {
            Id = id;
            PostgreSQLWarehouseInterface = posgreSQLWarehouseInterface;
        }

        #endregion


        PostgreSQLWarehouseInterface PostgreSQLWarehouseInterface { get; init; }

        #region Abstract

        protected override byte[] GetDatabaseData()
        {
            return PostgreSQLWarehouseInterface.GetData(this);
        }

        protected override bool SetDatabaseName(string name)
        {
            return PostgreSQLWarehouseInterface.SetName(this, name) != null;

        }

        protected override bool SetDatabaseDescription(string description)
        {
            return PostgreSQLWarehouseInterface.SetDescription(this, description) != null;

        }

        protected override bool SetDatabaseData(byte[] data)
        {
            return PostgreSQLWarehouseInterface.SetData(this, data) != null;
        }

 
        #endregion


        protected override void Add(INode<INode> node)
        {
            throw new OwnNotImplemented("Leaf");
        }

        protected override void Remove(INode<INode> node)
        {
            throw new OwnNotImplemented("Leaf");
        }

        protected override bool RemoveFromDatabase()
        {
            return PostgreSQLWarehouseInterface.Remove(this) != null;
        }

    }
}
