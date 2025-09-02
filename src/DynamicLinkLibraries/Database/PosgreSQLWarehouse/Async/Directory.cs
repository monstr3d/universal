using System.Data;
using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using ErrorHandler;
using NamedTree;

namespace PostgreSQLWarehouse.Async
{
    public class Directory : DataWarehouse.Classes.Abstract.Async.Directory
    {
        private Async.PostgreSQLWarehouseInterface wi;

        private Async.PostgreSQLWarehouseInterface WarehouseInterface
        {
            get => wi;
            set
            {
                wi = value;
                directory.Post();
            }
        }

        private IDirectory directory => this;

        protected override DataWarehouse.Classes.SyncMode SyncMode => (WarehouseInterface as IDatabaseInterfaceAsync).SyncMode;

        #region Ctor

        public Directory(IDataRecord record, PostgreSQLWarehouseInterface postgreSQLWarehouse, bool b) : base(b)
        {
            try
            {
                WarehouseInterface = postgreSQLWarehouse;
                Id = record[0];
                var p = record[1];
                name = record.GetString(2);
                description = record.GetString(3);
                Extension = record.GetString(4);
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }


        }

        public Directory(IDirectory directory, object id, PostgreSQLWarehouseInterface postgreSQLWarehouse, bool b) : base(b)
        {
           WarehouseInterface = postgreSQLWarehouse;
            Id = id;
            name = directory.Name;
            description = directory.Description;
            Extension = directory.Extension;
        }

        public Directory(IDataRecord record, IDirectory parent, PostgreSQLWarehouseInterface postgreSQLWarehouse, bool b) :
            this(record, postgreSQLWarehouse, b)
        {
            Parent = parent;
        }


        internal Directory(IDirectory directory, Guid guid, PostgreSQLWarehouseInterface postgreSQLWarehouse, bool b) : base(b)
        {
            var t = new Tuple<Guid, Guid, string, string, string>(guid, guid, directory.Name, directory.Description,
                directory.Extension);
            Create(t, postgreSQLWarehouse);
        }


        internal Directory(Tuple<Guid, Guid, string, string, string> t,
            PostgreSQLWarehouseInterface posgreSQLWarehouse, bool b) : base(b)
        {
            Create(t, posgreSQLWarehouse);
        }


        void Create(Tuple<Guid, Guid, string, string, string> t,
            PostgreSQLWarehouseInterface postgreSQLWarehouse)
        {
           WarehouseInterface = postgreSQLWarehouse;
            Id = t.Item1;
            name = t.Item3;
            description = t.Item4;
            Extension = t.Item5;

        }

        #endregion

        protected override IDirectory Add(IDirectory directory)
        {
            return base.Add(directory);
        }

        protected override Task<List<IDirectoryAsync>> LoadChildren(CancellationToken cancellationToken)
        {
            return WarehouseInterface.LoadChildren(this);
        }

        protected override Task<List<ILeafAsync>> LoadLeaves(CancellationToken cancellationToken)
        {
            return WarehouseInterface.GetLeavesAsync(this);

        }

        IDatabaseInterfaceAsync Async =>WarehouseInterface;

        protected override async Task<ILeafAsync> AddAsync(ILeaf leaf, CancellationToken cancellationToken)
        {
            var t = WarehouseInterface.Add(this, leaf as ILeafData);
            if (SyncMode == DataWarehouse.Classes.SyncMode.Synchronous)
            {
                if (!t.IsCompleted)
                {
                    t.RunSynchronously();
                }
                return t.Result;
            }
            await t;
            return t.Result;
        }


        protected override async Task<bool> RemoveItselfAsync(CancellationToken cancellationToken)
        {
            var t = WarehouseInterface.RemoveAsync(this);
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

        

    

        protected override async Task<IDirectoryAsync> AddAsync(IDirectory directory, CancellationToken cancellationToken)
        {
            var t = WarehouseInterface.Add(this, directory);
            await t;
            return t.Result;
        }


        protected override async Task<string> UpdateNameAsync(string name, CancellationToken cancellationToken)
        {
            var t = WarehouseInterface.UpdateDirNameAsync(name, this);
            await t;
            return t.Result;
        }

        protected override async Task<string> UpdateDescriptionAsync(string description, CancellationToken cancellationToken)
        {
            var t = WarehouseInterface.UpdateDirDecriptionAsync(description, this);
            await t;
            return t.Result;
        }

        protected override IDirectory AddToDatabase(IDirectory directory)
        {

            var tt = new Tuple<Guid, IDirectory>((Guid)Id, directory);
            var  t = WarehouseInterface.Insert(tt);
            return (directory == null) ? new Directory(t,WarehouseInterface, true) :
                new Directory(directory, t.Item1,WarehouseInterface, true);
        }

        protected override List<ILeaf> GetLeavesFormDatabase()
        {
            throw new OwnNotImplemented();
        }

        protected override List<IDirectory> GetDirectoriesFormDatabase()
        {
            throw new OwnNotImplemented();
        }
    }
}