using DataWarehouse;
using DataWarehouse.Interfaces;
using ErrorHandler;
using NamedTree;
using System.Data;

namespace OdbcWarehouse.Interface
{
    internal class Directory : DataWarehouse.Classes.Abstract.Directory
    {

        #region Ctor

        private Directory(DataBaseInterface databaseInterface)
        {
            DataBaseInterface = databaseInterface; 
        }

        public Directory(IDirectory directory, DataBaseInterface databaseInterface) : this(databaseInterface)
        {
            Name = directory.Name;
            description = directory.Description;
            Extension = directory.Extension;
            decimal i = 0;
            Id = i;
        }

        public Directory(IDataRecord record,  DataBaseInterface dataBaseInterface)
        {
            this.DataBaseInterface = dataBaseInterface;
            Id = record[0];
            var p = record[1];
            name = record.GetString(2);
            description = record.GetString(3);
            Extension = record.GetString(4);
        }

        public Directory(IDataRecord record, IDirectory parent, DataBaseInterface dataBaseInterface) :
            this(record, dataBaseInterface)
        {
            Parent = parent;
        }


        internal Directory(IDirectory directory, decimal id, DataBaseInterface dataBaseInterface)
        {
            var t = new Tuple<decimal, decimal, string, string, string>(id, id, directory.Name, directory.Description,
                directory.Extension);
            Create(t, dataBaseInterface);
        }


        internal Directory(Tuple<decimal, decimal, string, string, string> t,
            DataBaseInterface dataBaseInterface)
        {
            Create(t, dataBaseInterface);
        }


        void Create(Tuple<decimal, decimal, string, string, string> t,
            DataBaseInterface dataBaseInterface)
        {
            DataBaseInterface = dataBaseInterface;
            Id = t.Item1;
            name = t.Item3;
            description = t.Item4;
            Extension = t.Item5;

        }

        #endregion


        DataBaseInterface DataBaseInterface { get; set; }

        protected override void Add(INode<INode> node)
        {
            throw new OwnNotImplemented("ODBCDirectory");
        }

        protected override IDirectory AddToDatabase(IDirectory directory)
        {
            throw new OwnNotImplemented("ODBCDirectory");
        }

        protected override ILeaf AddToDatabase(ILeaf leaf)
        {
            throw new OwnNotImplemented("ODBCDirectory");
        }

        protected override List<IDirectory> GetDirectoriesFormDatabase()
        {
            throw new OwnNotImplemented("ODBCDirectory");
        }

        protected override List<ILeaf> GetLeavesFormDatabase()
        {
            throw new OwnNotImplemented("ODBCDirectory");
        }

        protected override void Remove(INode<INode> node)
        {
            throw new OwnNotImplemented("ODBCDirectory");
        }

        protected override void Remove(IDirectory directory, string ext)
        {
            throw new OwnNotImplemented("ODBCDirectory");
        }

        protected override void Remove(ILeaf leaf, string ext)
        {
            throw new OwnNotImplemented("ODBCDirectory");
        }

        protected override bool RemoveFromDatase()
        {
            throw new OwnNotImplemented("ODBCDirectory");
        }

        protected override bool SetDatabaseDescription(string description)
        {
            throw new OwnNotImplemented("ODBCDirectory");
        }

        protected override bool SetDatabaseName(string name)
        {
            throw new OwnNotImplemented("ODBCDirectory");
        }
    }
}
