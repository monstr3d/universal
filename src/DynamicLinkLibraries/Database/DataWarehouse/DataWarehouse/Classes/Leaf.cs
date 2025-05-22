using System;
using System.Collections.Generic;

using DataWarehouse.Interfaces;

using ErrorHandler;

using NamedTree;

namespace DataWarehouse.Classes
{
    /// <summary>
    /// Leaf 
    /// </summary>
    public class Leaf : ILeaf
    {
        public Leaf(object Id, string Name, string Description, byte[] Data, string Extension = null)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Data = Data;
            this.Extension = Extension;
        }

        #region Virtual

        protected virtual object Id { get; set; }

        protected virtual string Name { get; set; }

        protected virtual string Extension { get; set; }

        protected virtual string Description { get; set; }


        protected virtual INode Value => this;

        protected virtual INode<INode> Parent { get; set; }

        protected virtual IEnumerable<INode<INode>> Nodes { get; set; } = new List<INode<INode>>();

        protected virtual byte[] Data { get; set; }

        protected event Action<INode> OnAdd;

        protected event Action<INode> OnRemove;

        protected virtual void Add(INode<INode> node)
        {
            throw new OwnNotImplemented("Leaf Add");
        }

        protected virtual void Remove(INode<INode> node)
        {
            throw new OwnNotImplemented("Leaf Remove");
        }

        protected virtual void RemoveItself()
        {
            throw new OwnNotImplemented("Leaf Remove itself");
        }

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


        #endregion


        object INode.Id => Id;

        string INode.Extension =>   Extension;

        string INamed.Name { get => Name; set => Name = value; }
        INode<INode> INode<INode>.Parent { get => Parent; set => Parent = value; }
        IEnumerable<INode<INode>> INode<INode>.Nodes { get => Nodes; set => Nodes = value; }

        INode INode<INode>.Value => Value;

        string IDescription.Description { get => Description; set => Description = value; }
        byte[] IData.Data { get => Data; set => Data = value; }

        event Action<INode> INode<INode>.OnAdd
        {
            add
            {
                OnAdd += value;
            }

            remove
            {
                OnAdd -= value;
            }
        }

        event Action<INode> INode<INode>.OnRemove
        {
            add
            {
                OnRemove += value;
            }

            remove
            {
                OnRemove -= value;
            }
        }


        void INode<INode>.Add(INode<INode> node)
        {
            Add(node);
        }

        void INode<INode>.Remove(INode<INode> node)
        {
            Remove(node);
        }

        void INode.RemoveItself()
        {
            RemoveItself();
        }
    }
}
