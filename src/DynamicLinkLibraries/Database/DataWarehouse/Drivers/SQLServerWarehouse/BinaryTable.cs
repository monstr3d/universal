
using System;

using DataWarehouse.Interfaces;
using NamedTree;

using ErrorHandler;
using System.Collections.Generic;

namespace SQLServerWarehouse.Models
{
    [Leaf<INode>]
    public partial class BinaryTable : ILeaf
    {
        #region Fields

 
        #endregion

        object INode.Id => Id;

        string INode.Extension => Ext;

        byte[] ILeaf.Data { get=> Data; set => SetData(value); }
        string INode.Description { get => throw new OwnNotImplemented("Binary Table"); set => throw new OwnNotImplemented("Binary Table"); }
        string INamed.Name { get => throw new OwnNotImplemented("Binary Table"); set => throw new OwnNotImplemented("Binary Table"); }
        INode<INode> INode<INode>.Parent { get => Parent; set => throw new OwnNotImplemented("Binary Table"); }
        IEnumerable<INode<INode>> INode<INode>.Nodes { get => throw new OwnNotImplemented("Binary Table"); set => throw new OwnNotImplemented("Binary Table"); }

        INode INode<INode>.Value => this;

        event Action<INode> INode<INode>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<INode> INode<INode>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        void INode<INode>.Add(INode<INode> node)
        {
            throw new OwnNotImplemented("Binary Table");
        }

        void INode<INode>.Remove(INode<INode> node)
        {
            throw new OwnNotImplemented("Binary Table");
        }

        void INode.RemoveItself()
        {
            StaticExtension.Context.BinaryTables.Remove(this);
            Parent.Remove(this);
            StaticExtension.Context.SaveChanges();
            
        }

        void SetData(byte[] data)
        {
            using (DataWarehouseContext context = new DataWarehouseContext())
            {
                Data = data;
                context.SaveChanges();
            }
        }
    }
}
