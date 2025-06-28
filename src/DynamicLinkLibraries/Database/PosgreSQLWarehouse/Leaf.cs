using System.Data;

using DataWarehouse.Interfaces;
using ErrorHandler;
using NamedTree;

namespace PosgreSQLWarehouse
{
    internal class Leaf : DataWarehouse.Classes.Abstract.Leaf
    {
        PosgreSQLWarehouseInterface PosgreSQLWarehouseInterface { get; init; }

        #region Abstract

        protected override byte[] GetDatabaseData()
        {
            return PosgreSQLWarehouseInterface.GetData(this);
        }

        protected override bool SetDatabaseName(string name)
        {
            return PosgreSQLWarehouseInterface.SetName(this, name) != null;

        }

        protected override bool SetDatabaseDescription(string description)
        {
            return PosgreSQLWarehouseInterface.SetDescription(this, description) != null;

        }

        protected override bool SetDatabaseData(byte[] data)
        {
            return PosgreSQLWarehouseInterface.SetData(this, data) != null;
        }


        #endregion


        public Leaf(IDataRecord record, IDirectory directory, PosgreSQLWarehouseInterface posgreSQLWarehouse)
        {
            PosgreSQLWarehouseInterface = posgreSQLWarehouse;
            Parent = directory;
            Id = record[0];
            name = record.GetString(2);
            description = record.GetString(3);
            Extension = record.GetString(4);
        }

        public Leaf(ILeafData data, IDirectory directory, Guid id, PosgreSQLWarehouseInterface posgreSQLWarehouseInterface) : base(data, directory)
        {
            Id = id;
            PosgreSQLWarehouseInterface = posgreSQLWarehouseInterface;
        }

   

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
            return PosgreSQLWarehouseInterface.Remove(this) != null;
        }

    }
}
