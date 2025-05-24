using System;
using System.Collections.Generic;

using DataWarehouse.Interfaces;

using ErrorHandler;

using NamedTree;

namespace DataWarehouse.Classes
{
    public class Directory : IDirectory
    {
        #region Ctor

        public Directory(object Id, string Name, string Description, string Extension = null)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Extension = Extension;
        }

        #endregion

        #region IDirectory events

        /// <summary>
        /// Addchild event
        /// </summary>
        protected event Action<IDirectory> OnAddDirectory;

        /// <summary>
        /// Delete itself event
        /// </summary>
        protected event Action OnDeleteItself;

        /// <summary>
        /// Change itself event
        /// </summary>
        protected event Action<IDirectory> OnChangeItself;

        /// <summary>
        /// Add leaf event
        /// </summary>
        protected event Action<ILeaf> OnAddLeaf;

        event Action IDirectory.OnDeleteItself
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

        event Action<IDirectory> IDirectory.OnChangeItself
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

        event Action<ILeaf> IDirectory.OnAddLeaf
        {
            add
            {
                OnAddLeaf += value;
            }

            remove
            {
                OnAddLeaf -= value;
            }
        }

        event Action<IDirectory> IDirectory.OnAddDirectory
        {
            add
            {
               OnAddDirectory += value;
            }

            remove
            {
               OnAddDirectory -= value;
            }
        }

        #endregion


        #region Protected

        protected virtual object Id { get; set; }

        protected virtual string Name { get; set; }

        protected virtual string Extension { get; set; }

        protected virtual string Description { get; set; }


        protected virtual INode Value => this;

        protected virtual INode<INode> Parent { get; set; }

        protected virtual IEnumerable<INode<INode>> Nodes { get; set; } = new List<INode<INode>>();


        protected virtual IEnumerable<IDirectory> Children { get; set; } = new List<IDirectory>();

        protected virtual IEnumerable<ILeaf> Leaves { get; set; } = new List<ILeaf>();

        

        protected event Action<INode> OnAdd;

        protected event Action<INode> OnRemove;


        protected event Action<IDirectory> OnRemoveDirectory;

        protected event Action<ILeaf> OnRemoveLeaf;

 
        

        protected virtual void Add(INode<INode> node)
        {
          //  OnAdd?.Invoke(node as INode<INode>);
            throw new OwnNotImplemented("Directory Add");
        }

 
        protected virtual void Remove(INode<INode> node)
        {
            throw new OwnNotImplemented("Directory Remove");
        }

        protected virtual void RemoveItself()
        {
            throw new OwnNotImplemented("Directory Remove itself");
        }

        protected IDirectory Add(IDirectory directory)
        {
            OnAddDirectory?.Invoke(directory);
            throw new OwnNotImplemented("Directory Remove itself");
        }


        protected virtual ILeaf Add(ILeaf leaf)
        {
            OnAddLeaf?.Invoke(leaf);
            throw new OwnNotImplemented("Directory Remove itself");
        }


        protected virtual void Remove(IDirectory directory, string ext)
        {
            throw new OwnNotImplemented("Directory remove directory");
        }

        protected virtual void Remove(ILeaf leaf, string ext)
        {
            throw new OwnNotImplemented("Directory remove leaf");
        }





        #endregion

        object INode.Id => Id;

        string INode.Extension => Extension;

        string INamed.Name { get => Name; set => Name = value; }
        INode<INode> INode<INode>.Parent { get => Parent; set => Parent = value; }
        IEnumerable<INode<INode>> INode<INode>.Nodes { get => Nodes; set => Nodes = value; }

        INode INode<INode>.Value => Value;

        string IDescription.Description { get => Description; set => Description = value; }


        IEnumerable<IDirectory> IChildren<IDirectory>.Children => Children;

        IEnumerable<ILeaf> IChildren<ILeaf>.Children => Leaves;

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


 
        event Action<IDirectory> IChildren<IDirectory>.OnAdd
        {
            add
            {
                OnAddDirectory += value;
            }

            remove
            {
                OnAddDirectory -= value;
            }
        }

        event Action<ILeaf> IChildren<ILeaf>.OnAdd
        {
            add
            {
                OnAddLeaf += value;
            }

            remove
            {
                OnAddLeaf -= value;
            }
        }

    
        event Action<IDirectory> IChildren<IDirectory>.OnRemove
        {
            add
            {
                OnRemoveDirectory += value;
            }

            remove
            {
                OnRemoveDirectory -= value;
            }
        }

        event Action<ILeaf> IChildren<ILeaf>.OnRemove
        {
            add
            {
                OnRemoveLeaf += value;
            }

            remove
            {
                OnRemoveLeaf -= value;
            }
        }


        IDirectory IDirectory.Add(IDirectory directory)
        {
            return Add(directory);
        }

        ILeaf IDirectory.Add(ILeaf leaf)
        {
            return Add(leaf);
        }

        void IChildren<IDirectory>.AddChild(IDirectory child)
        {
            Add(child);
        }

        void IChildren<ILeaf>.AddChild(ILeaf child)
        {
            Add(child);
        }

        void IChildren<IDirectory>.RemoveChild(IDirectory child)
        {
            Remove(child);
        }

        void IChildren<ILeaf>.RemoveChild(ILeaf child)
        {
            Remove(child);
        }
    }
}
