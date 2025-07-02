using System;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using NamedTree;

namespace Diagram.UI
{


    /// <summary>
    /// Collection of components
    /// </summary>
    public class ComponentCollection : IComponentCollection
    {
        #region Fields

        Performer pefrormer = new Performer();

        IComponentCollection collection;

        /// <summary>
        /// All objects
        /// </summary>
        ICollection<object> allObjects;

        /// <summary>
        /// Desktop;
        /// </summary>
        IDesktop desktop;

        protected INode<IComponentCollection> ParentNode
        {
            get; set;
        }

        protected virtual INode<IComponentCollection> Parent { get => ParentNode; set => ParentNode = value; }

        protected List<IComponentCollection> ChildrenNodes { get; } = new List<IComponentCollection>();

        protected virtual IEnumerable<IComponentCollection> Children => ChildrenNodes;

        protected event Action<IComponentCollection> onAdd;

        protected event Action<IComponentCollection> onRemove;

        protected virtual event Action<IComponentCollection> OnAdd
        {
            add
            {
                onAdd += value;
            }

            remove
            {
                onAdd -= value;
            }
        }


        protected virtual event Action<IComponentCollection> OnRemove
        {
            add
            {
                onRemove += value;
            }

            remove
            {
                onRemove -= value;
            }
        }


 
        protected virtual void Add(INode<IComponentCollection> collection)
        {
            ChildrenNodes.Add(collection.Value);
            onAdd?.Invoke(collection.Value);
        }

        protected virtual void Remove(INode<IComponentCollection> collection)
        {
            ChildrenNodes.Remove(collection.Value);
            onRemove?.Invoke(collection.Value);
        }



        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="allObjects">All objects</param>
        /// <param name="desktop">Desktop</param>
        public ComponentCollection(ICollection<object> allObjects, IDesktop desktop)
        {
            collection = this;
            this.allObjects = allObjects;
            this.desktop = desktop;
        }

        event Action<IComponentCollection> INode<IComponentCollection>.OnAdd
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

        event Action<IComponentCollection> INode<IComponentCollection>.OnRemove
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

        #endregion

        #region IComponentCollection Members

        IEnumerable<object> IComponentCollection.AllComponents
        {
            get { return allObjects; }
        }

        IDesktop IComponentCollection.Desktop
        {
            get { return desktop; }
        }

        #region NEW
   
        IEnumerable<IObjectLabel> IComponentCollection.Objects => collection.Get<IObjectLabel>();

        IEnumerable<IArrowLabel> IComponentCollection.Arrows => collection.Get<IArrowLabel>();

        IEnumerable<INamedComponent> IComponentCollection.NamedComponents => collection.Get<INamedComponent>();

        IEnumerable<ICategoryObject> IComponentCollection.CategoryObjects => collection.Get<ICategoryObject>();

        IEnumerable<ICategoryArrow> IComponentCollection.CategoryArrows => collection.Get<ICategoryArrow>();

        string INamed.Name { get => Name; set => Name = value; }

        IEnumerable<T> IComponentCollection.Get<T>() where T : class
        {
            return pefrormer.GetObjectsAndArrows<T>(this);
        }

        void INode<IComponentCollection>.Add(INode<IComponentCollection> node)
        {
            Add(node);
        }

        void INode<IComponentCollection>.Remove(INode<IComponentCollection> node)
        {
            Remove(node);
        }

        INode<IComponentCollection> INode<IComponentCollection>.Parent { get => Parent; set { Parent = value; } }
        IEnumerable<INode<IComponentCollection>> INode<IComponentCollection>.Nodes { get => Children; set { } }

        IComponentCollection INode<IComponentCollection>.Value => this;



        #endregion


        #endregion

        #region Protected

        protected virtual string Name
        {
            get;
            set;
        }
        string INamed.NewName { get; set; }

        #endregion

        #region 

        #endregion
    }
}
