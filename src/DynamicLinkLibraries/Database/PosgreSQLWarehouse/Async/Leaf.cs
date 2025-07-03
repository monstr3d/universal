using System.Data;

using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using ErrorHandler;
using NamedTree;

namespace PostgreSQLWarehouse.Async
{
    internal class Leaf :  DataWarehouse.Classes.Abstract.Async.Leaf
    {

        PostgreSQLWarehouseInterface warehouseInterface;

        ILeafAsync async;

        #region Ctor
        public Leaf(IDataRecord record, IDirectory directory, PostgreSQLWarehouseInterface posgreSQLWarehouse)
        {
            async = this;
            warehouseInterface = posgreSQLWarehouse;
            Parent = directory;
            Id = record[0];
            name = record.GetString(2);
            description = record.GetString(3);
            Extension = record.GetString(4);
        }

        public Leaf(ILeafData data, IDirectory directory, Guid id, PostgreSQLWarehouseInterface posgreSQLWarehouseInterface) 
        {
            async = this;
            Id = id;
            warehouseInterface = posgreSQLWarehouseInterface;
        }


        #endregion

        protected override void Add(INode<INode> node)
        {
            throw new OwnNotImplemented();
        }

        protected override Task<byte[]> GetDataAsync()
        {
            return warehouseInterface.GetDataAsync(this);
        }

        protected override byte[] GetDatabaseData()
        {
            throw new OwnNotImplemented();
        }

        protected override void Remove(INode<INode> node)
        {
            throw new OwnNotImplemented();
        }

        protected override bool RemoveFromDatabase()
        {
            throw new OwnNotImplemented();
        }

        protected override async Task<bool> RemoveItselfAsync()
        {
            var t = warehouseInterface.RemoveAsync(this);
            await t;
            return t.Result;
        }

        protected override bool SetDatabaseData(byte[] data)
        {
            throw new OwnNotImplemented();
        }

        protected override bool SetDatabaseDescription(string description)
        {
            throw new OwnNotImplemented();
        }

        protected override bool SetDatabaseName(string name)
        {
            throw new OwnNotImplemented();
        }

        protected override async Task<byte[]> UpdateDataAcync(byte[] data)
        {
            var t = warehouseInterface.UpdateDataAcync(data, this);
            await t;
            return t.Result;
        }

        protected override Task<string> UpdateDescriptionAsync(string description)
        {
            throw new OwnNotImplemented();
        }

        protected override Task<string> UpdateNameAsync(string name)
        {
            throw new OwnNotImplemented();
        }
    }
}
