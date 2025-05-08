
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

        byte[] IData.Data { get=> Data; set => SetData(value); }
        string IDescription.Description { get => Description; set => UpdateDescription(value); }
        string INamed.Name { get => Name; set => UpdateName(value); }
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
        }

        void INode<INode>.Remove(INode<INode> node)
        {
        }

        void INode.RemoveItself()
        {
            try
            {


                StaticExtension.Context.BinaryTables.Remove(this);
                Parent.Remove(this);
                StaticExtension.Context.SaveChanges();
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Remove database binary item");
            }
            
        }

        void SetData(byte[] data)
        {
            using (DataWarehouseContext context = new DataWarehouseContext())
            {
                Data = data;
                context.SaveChanges();
            }
        }

        void UpdateName(string name)
        {
            if (name == Name)
            {
                return;
            }
            if (!Parent.Check(name))
            {
                return;
            }
            Action action = () => { StaticExtension.TableAdapter.UpdateBinaryTableName(Id, name); };
            StaticExtension.TableAdapter.ConnectionAction(action);
            Parent.Names.Remove(Name);
            Parent.Names.Add(name);
            Name = name;
       //     this.Change();
        }

        void UpdateDescription(string description)
        {
            Action action = () => { StaticExtension.TableAdapter.UpdateBinaryTableDescription(Id, description); };
            StaticExtension.TableAdapter.ConnectionAction(action);
            Description = description;
    //        this.Change();
        }


    }
}
