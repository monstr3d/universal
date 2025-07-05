using System.Data;

using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using ErrorHandler;
using NamedTree;

namespace PostgreSQLWarehouse.Async
{
    internal class Leaf :  DataWarehouse.Classes.Abstract.Async.Leaf
    {
        PostgreSQLWarehouseInterface wi;

        PostgreSQLWarehouseInterface WarehouseInterface
        {
            get => wi;
            set
            {
                wi = value;

            }
        }

        ILeafAsync Async => this;

        ILeaf leaf => this;


        

        #region Ctor
        public Leaf(IDataRecord record, IDirectory directory, PostgreSQLWarehouseInterface posgreSQLWarehouse)
        {
           WarehouseInterface = posgreSQLWarehouse;
            Parent = directory;
            Id = record[0];
            name = record.GetString(2);
            if (name == null)
            {
                throw new OwnException();
            }
            var n = leaf.Name;
            if (n == null)
            {
                throw new OwnException();
            }
            description = record.GetString(3);
            Extension = record.GetString(4);
        }

        public Leaf(ILeafData data, IDirectory directory, Guid id, PostgreSQLWarehouseInterface posgreSQLWarehouseInterface) 
        {
            Id = id;
           WarehouseInterface = posgreSQLWarehouseInterface;
            Parent = directory;
            name = data.Name;
            description = data.Description;
            Extension = data.Extension;

        }


        #endregion

        protected override void Add(INode<INode> node)
        {
            throw new OwnNotImplemented();
        }

        protected override Task<byte[]> GetDataAsync()
        {
            return WarehouseInterface.GetDataAsync(this);
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
            var t =WarehouseInterface.RemoveAsync(this);
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
            var t =WarehouseInterface.UpdateDataAcync(data, this);
            await t;
            return t.Result;
        }

        protected override Task<string> UpdateDescriptionAsync(string description)
        {
            throw new OwnNotImplemented();
        }

        protected override async Task<string> UpdateNameAsync(string name)
        {
            var t =WarehouseInterface.UpdateLeafNameAsync(name, this);
            await t;
            return t.Result;
        }
    }
}
