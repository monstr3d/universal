using System;
using System.Collections.Generic;

using DataWarehouse;
using DataWarehouse.Interfaces;

using ErrorHandler;

using NamedTree;

namespace SQLServerWarehouse.Models
{
    public partial class ViewBinaryTableInfo : ILeaf
    {
        

        #region Implementation of interfaces

        byte[] IData.Data { get => Id.GetData(); set => Id.SetData(value); }

        object INode.Id => Id;

         string IDescription.Description { get => Description; set => UpdateDescription(value); }

        string INode.Extension => Ext;

        event Action<INode> INode<INode>.OnAdd
        {
            add
            {
                throw new OwnNotImplemented("DataWarehouse");
            }

            remove
            {
                throw new OwnNotImplemented("DataWarehouse");
            }
        }

        event Action<INode> INode<INode>.OnRemove
        {
            add
            {
                throw new OwnNotImplemented("DataWarehouse");
            }

            remove
            {
                throw new OwnNotImplemented("DataWarehouse");
            }
        }

        void INode.RemoveItself()
        {
            Action action = () => { StaticExtension.TableAdapter.DeleteBinary(Id); };
            StaticExtension.TableAdapter.ConnectionAction(action);
            if (Parent != null)
            {
                Parent.Remove(this);
            }
            //StaticExtension.Context.ViewBinaryTableInfos.Remove(this);
        }

        #endregion


        #region ILeaf events

        /// <summary>
        /// Delete itself event
        /// </summary>
        protected event Action<ILeaf> OnDeleteItself;

        /// <summary>
        /// Chande itseld evenr
        /// </summary>
        protected event Action<ILeaf> OnChangeItself;


        event Action<ILeaf> ILeaf.OnDeleteItself
        {
            add
            {
                OnDeleteItself += value;
            }

            remove
            {
                OnDeleteItself -= value;
            }
        }

        event Action<ILeaf> ILeaf.OnChangeItself
        {
            add
            {
                OnChangeItself += value;
            }

            remove
            {
                OnChangeItself -= value;
            }
        }



        #endregion


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
            Action action = () => { StaticExtension.TableAdapter.UpdateBinaryTreeName(Id, name); };
            StaticExtension.TableAdapter.ConnectionAction(action);
            Parent.Names.Remove(Name);
            Parent.Names.Add(name);
            Name = name;
            this.Change();
        }

        void UpdateDescription(string description)
        {
            Action action = () => { StaticExtension.TableAdapter.UpdateBinaryTreeDescription(Id, description); };
            StaticExtension.TableAdapter.ConnectionAction(action);
            Description = description;
            this.Change();
        }

        internal BinaryTree Parent
        { get; set; }
        INode<INode> INode<INode>.Parent { get => Parent; set => throw new OwnNotImplemented("DataWarehouse"); }
        IEnumerable<INode<INode>> INode<INode>.Nodes { get => throw new OwnNotImplemented("DataWarehouse"); set => throw new OwnNotImplemented("DataWarehouse"); }

        INode INode<INode>.Value => this;

        string INamed.Name { get => Name; set => Name = value; }

        public override string ToString()
        {
            return Name + " " + GetType(); 
        }

        void INode<INode>.Add(INode<INode> node)
        {
            throw new OwnNotImplemented("DataWarehouse");
        }

        void INode<INode>.Remove(INode<INode> node)
        {
            throw new OwnNotImplemented("DataWarehouse");
        }
    }
}
