using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using ErrorHandler;
using NamedTree;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQLWarehouse.Async
{
    public class Directory : DataWarehouse.Classes.Abstract.Async.Directory
    {
        private Async.PostgreSQLWarehouseInterface warehouseInterface;

        #region Ctor

        public Directory(IDataRecord record, PostgreSQLWarehouseInterface postgreSQLWarehouse)
        {
            warehouseInterface = postgreSQLWarehouse;
            Id = record[0];
            var p = record[1];
            name = record.GetString(2);
            description = record.GetString(3);
            Extension = record.GetString(4);
        }

        public Directory(IDirectory directory, object id, PostgreSQLWarehouseInterface postgreSQLWarehouse)
        {
            warehouseInterface = postgreSQLWarehouse;
            Id = id;
            name = directory.Name;
            description = directory.Description;
            Extension = directory.Extension;
        }

        public Directory(IDataRecord record, IDirectory parent, PostgreSQLWarehouseInterface postgreSQLWarehouse) :
            this(record, postgreSQLWarehouse)
        {
            Parent = parent;
        }


        internal Directory(IDirectory directory, Guid guid, PostgreSQLWarehouseInterface postgreSQLWarehouse)
        {
            var t = new Tuple<Guid, Guid, string, string, string>(guid, guid, directory.Name, directory.Description,
                directory.Extension);
            Create(t, postgreSQLWarehouse);
        }


        internal Directory(Tuple<Guid, Guid, string, string, string> t,
            PostgreSQLWarehouseInterface posgreSQLWarehouse)
        {
            Create(t, posgreSQLWarehouse);
        }


        void Create(Tuple<Guid, Guid, string, string, string> t,
            PostgreSQLWarehouseInterface postgreSQLWarehouse)
        {
            warehouseInterface = postgreSQLWarehouse;
            Id = t.Item1;
            name = t.Item3;
            description = t.Item4;
            Extension = t.Item5;

        }

        #endregion

        protected override Task<List<IDirectoryAsync>> LoadChildren()
        {
            return warehouseInterface.LoadChildren(this);
        }

        protected override Task<List<ILeafAsync>> LoadLeaves()
        {
            return warehouseInterface.GetLeavesAsync(this);


        }


        protected override async Task<bool> RemoveItselfAsync()
        {
            var t = warehouseInterface.RemoveAsync(this);
            await t;
            return (t.Result != null);
        }

        protected override void Add(INode<INode> node)
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

        protected override IDirectory AddToDatabase(IDirectory directory)
        {
            throw new OwnNotImplemented();
        }

        protected override ILeaf AddToDatabase(ILeaf leaf)
        {
            throw new OwnNotImplemented();
        }

        protected override void Remove(IDirectory directory, string ext)
        {
            throw new OwnNotImplemented();
        }

        protected override void Remove(ILeaf leaf, string ext)
        {
            throw new OwnNotImplemented();
        }

        protected override bool SetDatabaseName(string name)
        {
            throw new OwnNotImplemented();
        }

        protected override bool SetDatabaseDescription(string description)
        {
            throw new OwnNotImplemented();
        }

        protected override List<ILeaf> GetLeavesFormDatabase()
        {
            throw new OwnNotImplemented();
        }

        protected override List<IDirectory> GetDirectoriesFormDatabase()
        {
            throw new OwnNotImplemented();
        }

        protected override async Task<IDirectoryAsync> Add(IDirectory directory)
        {
            var t = warehouseInterface.Add(this, directory);
            await t;
            return t.Result;
        }
    }
}