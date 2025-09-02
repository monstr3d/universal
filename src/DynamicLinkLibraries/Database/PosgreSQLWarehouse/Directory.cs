using System.Data;

using DataWarehouse.Interfaces;

using ErrorHandler;

using NamedTree;

namespace PostgreSQLWarehouse
{
  
    public class Directory : DataWarehouse.Classes.Abstract.Directory
    {

        protected PostgreSQLWarehouseInterface postgreSQLWarehouse;

        #region Ctor

        public Directory(IDataRecord record, PostgreSQLWarehouseInterface postgreSQLWarehouse, bool b) : base(b)
        {
            this.postgreSQLWarehouse = postgreSQLWarehouse;
            Id = record[0];
            var p = record[1];
            name = record.GetString(2);
            description = record.GetString(3);
            Extension = record.GetString(4);
        }

        public Directory(IDataRecord record, IDirectory parent, PostgreSQLWarehouseInterface postgreSQLWarehouse, bool b)  :
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
            this.postgreSQLWarehouse = postgreSQLWarehouse;
            Id = t.Item1;
            name = t.Item3;
            description = t.Item4;
            Extension = t.Item5;

        }

        #endregion

        #region NEW


        protected override bool SetDatabaseName(string name)
        {
            return postgreSQLWarehouse.SetName(this, name) != null;
        }


        protected override bool RemoveFromDatabase()
        {
            var o = postgreSQLWarehouse.Remove(this);
            return o != null;
        }


        protected override bool SetDatabaseDescription(string description)
        {
            return postgreSQLWarehouse.SetDescription(this, description) != null;
        }

        protected override List<ILeaf> GetLeavesFormDatabase()
        {
            return postgreSQLWarehouse.GetLeaves(this);
        }

        protected override List<IDirectory> GetDirectoriesFormDatabase()
        {
            return postgreSQLWarehouse.GetChildren(this);
        }



        #endregion

        protected override void Add(INode<INode> node)
        {
            throw new OwnNotImplemented();
        }

        protected override IDirectory AddToDatabase(IDirectory directory)
        {

            var tt = new Tuple<Guid, IDirectory>((Guid)Id, directory);
            var t = postgreSQLWarehouse.Insert(tt);
            return (directory == null) ? new Directory(t, postgreSQLWarehouse, true) :
                new Directory(directory, t.Item1, postgreSQLWarehouse, true);
        }

        protected override ILeaf AddToDatabase(ILeaf leaf)
        {
            var data = leaf as ILeafData;
            return postgreSQLWarehouse.Get(this, data);
        }

 
        protected override void Remove(INode<INode> node)
        {
            if (node is ILeaf leaf)
            {
                leaves.Remove(leaf);
                Names.Remove(leaf.Name);
            }
        }

        protected override void Remove(IDirectory directory, string ext)
        {
            throw new OwnNotImplemented();
        }

        protected override void Remove(ILeaf leaf, string ext)
        {
            throw new OwnNotImplemented();
        }

        

     

        void SetName(string name)
        {
            throw new OwnNotImplemented();
        }

        void SetDescription(string description)
        {
            throw new OwnNotImplemented();
        }
    }
}
