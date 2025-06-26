using System.Data;

using DataWarehouse.Interfaces;
using ErrorHandler;
using NamedTree;

namespace PosgreSQLWarehouse
{
    public class Directory : DataWarehouse.Classes.Abstract.Directory
    {
        PosgreSQLWarehouseInterface posgreSQLWarehouse;

        public Directory(IDataRecord record, PosgreSQLWarehouseInterface posgreSQLWarehouse)
        {
            this.posgreSQLWarehouse = posgreSQLWarehouse;
            Id = record[0];
            var p = record[1];
            Name = record.GetString(2);
            Description = record.GetString(3);
            Extension = record.GetString(4);
            base.Children = null;
            base.Leaves = null;
            Init();
        }

        internal Directory(IDirectory directory, Guid guid, PosgreSQLWarehouseInterface posgreSQLWarehouse)
        {
            Init();
            var t = new Tuple<Guid, Guid, string, string, string>(guid, guid, directory.Name, directory.Description,
                directory.Extension);
            Parent = directory;
            var l = Children as List<IDirectory>;
            l.Add(this);
            Create(t, posgreSQLWarehouse);
        }


        internal Directory(Tuple<Guid, Guid, string, string, string> t, 
            PosgreSQLWarehouseInterface posgreSQLWarehouse)
        {
            Init();
            Create(t, posgreSQLWarehouse);
        }


        void Create(Tuple<Guid, Guid, string, string, string> t,
            PosgreSQLWarehouseInterface posgreSQLWarehouse)
        {
            this.posgreSQLWarehouse = posgreSQLWarehouse;
            Id = t.Item1;
            Name = t.Item3;
            Description = t.Item4;
            Extension = t.Item5;

        }


        private void Init()
        {
            base.Children = null;
            base.Leaves = null;
            GetChildern = GetChildernInit;

        }


        protected override IEnumerable<IDirectory> Children { get => GetChildern(); set => base.Children = value; }

        IEnumerable<IDirectory>  GetChildernInit()
        {
            if (base.Children == null)
            {
                base.Children =  new List<IDirectory>();
            }
            GetChildern = () => base.Children;
            return Children;

        }



        Func<IEnumerable<IDirectory>> GetChildern;

        protected override void Add(INode<INode> node)
        {
            throw new OwnNotImplemented();
        }

        protected override IDirectory Add(IDirectory directory)
        {
            var c = Children;
            var tt = new Tuple<Guid, IDirectory>((Guid)Id, directory);
            var t = posgreSQLWarehouse.Insert(tt);
            return (directory == null) ? new Directory(t, posgreSQLWarehouse) : 
                new Directory(this, t.Item1, posgreSQLWarehouse);
        }


  



        protected override ILeaf Add(ILeaf leaf)
        {
            var data = leaf as ILeafData;
            return posgreSQLWarehouse.Get(this, data);
        }

        protected override void Remove(INode<INode> node)
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

        protected override void RemoveItself()
        {
            throw new OwnNotImplemented();
        }
    }
}
