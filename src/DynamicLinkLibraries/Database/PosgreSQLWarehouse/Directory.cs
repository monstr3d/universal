using DataWarehouse.Interfaces;
using ErrorHandler;
using NamedTree;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            GetChildern = GetChildernInit;
        }

        protected override IEnumerable<IDirectory> Children { get => GetChildern(); set => base.Children = value; }

        IEnumerable<IDirectory>  GetChildernInit()
        {
            GetChildern = () => base.Children;
            return new List<IDirectory>();

        }



        Func<IEnumerable<IDirectory>> GetChildern;

        protected override void Add(INode<INode> node)
        {
            throw new OwnNotImplemented();
        }

        protected override IDirectory Add(IDirectory directory)
        {
            if (Children == null)
            {
                Children = new List<IDirectory>();
            }
            throw new OwnNotImplemented();
        }

        IDirectory GetDirectory(NpgsqlCommand cmd, IDirectory dir)
        {
            return null;
        }


        protected override ILeaf Add(ILeaf leaf)
        {
            throw new OwnNotImplemented();
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
