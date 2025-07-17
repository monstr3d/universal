using System;
using System.Collections.Generic;
using System.Linq;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using NamedTree;

namespace Diagram.UI.Portable
{


    /// <summary>
    /// Container of objects
    /// </summary>
    /// </summary>
    public class ObjectContainer : CategoryObject, IObjectContainer, IPostSetArrow
    {


        #region Fields

        IComponentCollection components;

        protected NamedTree.Performer p = new NamedTree.Performer();

        protected Performer perf = new Performer();


        /// <summary>
        /// Interface
        /// </summary>
        protected Dictionary<string, object> inter = new Dictionary<string, object>();


        /// <summary>
        /// Type
        /// </summary>
        protected string type;


        /// <summary>
        /// Child desktop
        /// </summary>
        protected IDesktop desktop = null;

        protected virtual IDesktop Desktop
        {
            get => desktop;
            set => desktop = value;
        }

        Performer performer = new Performer();

        /// <summary>
        /// The "is loaded" sign
        /// </summary>
        protected bool isLoaded = false;

        /// <summary>
        /// The "is post loaded" sign
        /// </summary>
        protected bool isPostLoaded = false;



        #endregion

        #region Constructors

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="desktop">The parent desktop</param>
        protected ObjectContainer(IDesktop desktop)
        {
            components = this;
            Desktop = desktop;
        }


        #endregion

        #region IPostSetArrow Members

        public virtual void PostSetArrow()
        {
            //        Load();
            //       PostLoad();
        }

        #endregion

        #region IObjectCollection Members

        string[] IObjectCollection.Names
        {
            get { return desktop.GetNames(); }
        }

        object IObjectCollection.this[string name]
        {
            get
            {
                return desktop.GetObject(name);
            }
        }

        #endregion

        #region IComponentCollection Members

        IEnumerable<T> IComponentCollection.Get<T>() where T : class
        {
            return performer.GetObjectsAndArrows<T>(this);
        }

        IEnumerable<object> IComponentCollection.AllComponents
        {
            get { return desktop.AllComponents; }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Loaded Desktop
        /// </summary>
        /// <returns></returns>
        public virtual IDesktop LoadDesktop()
        {
            return desktop;
        }

        /// <summary>
        /// The desktop
        /// </summary>
        IDesktop IComponentCollection.Desktop
        {
            get
            {
                return Desktop;
            }
        }

        /// <summary>
        /// The interface
        /// </summary>
        public Dictionary<string, object> Interface
        {
            get
            {
                return inter;
            }
        }


        /// <summary>
        /// Loads itself
        /// </summary>
        /// <returns>True in success</returns>
        public virtual bool Load()
        {
            if (isLoaded)
            {
                return false;
            }
            isLoaded = true;
            if (desktop is PureDesktop pure)
            {
                pure.HasParent = true;
            }
            LoadProtected();
            return true;
        }

        /// <summary>
        /// The post load operation
        /// </summary>
        public virtual bool PostLoad()
        {
            if (!isLoaded)
            {
                return false;
            }
            if (isPostLoaded)
            {
                return true;
            }
            isPostLoaded = true;
            if (desktop is PureDesktop pure)
            {
                return pure.PostLoad();
            }
            return false;
        }

        /// <summary>
        /// Gets relative name of component
        /// </summary>
        /// <param name="comp">The component</param>
        /// <returns>The relative name</returns>
        public string GetName(INamedComponent comp)
        {
            return comp.GetName(desktop);
        }

        /// <summary>
        /// All child objects
        /// </summary>
        public ICollection<object> AllObjects
        {
            get
            {
                return desktop.GetAllObjects();
            }
        }

        /// <summary>
        /// The type
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        IEnumerable<IObjectLabel> IComponentCollection.Objects => components.Get<IObjectLabel>();

        IEnumerable<IArrowLabel> IComponentCollection.Arrows => components.Get<IArrowLabel>();

        IEnumerable<INamedComponent> IComponentCollection.NamedComponents => components.Get<INamedComponent>();

        IEnumerable<ICategoryObject> IComponentCollection.CategoryObjects => components.Get<ICategoryObject>();

        IEnumerable<ICategoryArrow> IComponentCollection.CategoryArrows => components.Get<ICategoryArrow>();

        /// <summary>
        /// Access to child by name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The child</returns>
        public INamedComponent this[string name]
        {
            get
            {
                return desktop[name];
            }
        }




        #endregion


        #region Public Members

        /// <summary>
        /// Sets parents of objects
        /// </summary>
        /// <param name="desktop">The desktop</param>
        public void SetParents(IDesktop desktop)
        {
            IEnumerable<IObjectLabel> objs = desktop.Objects.ToArray();
            INamedComponent comp = null;
            foreach (IObjectLabel ol in objs)
            {
                if (ol.Object == this)
                {
                    comp = ol;
                    break;
                }
            }
            IEnumerable<object> objects = this.desktop.Components.ToArray();
            foreach (INamedComponent nc in objects)
            {
                if (nc is IObjectLabel)
                {
                    IObjectLabel l = nc as IObjectLabel;
                    if (l.Object is IObjectContainer)
                    {
                        IObjectContainer oc = l.Object as IObjectContainer;
                        oc.Desktop.SetParents();
                    }
                }
                nc.Parent = comp;
            }
        }


        #endregion

        #region Protected Members

        IComponentCollection collection;

        /// <summary>
        /// All objects
        /// </summary>
        ICollection<object> allObjects;

 
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

        event Action<IComponentCollection> INode<IComponentCollection>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IComponentCollection> INode<IComponentCollection>.OnRemove
        {
            add
            {
            }

            remove
            {
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




        /// <summary>
        /// Protected load
        /// </summary>
        protected void LoadProtected()
        {
            foreach (INamedComponent nc in desktop.Components)
            {
                if (nc.Parent == null)
                {
                    nc.Parent = Object as INamedComponent;
                }
                nc.Desktop = desktop;
            }
            if (Desktop is PureDesktop pure)
            {
                pure.setParent(this);
            }
        }

        #endregion

        #region NEW

        #region NEW


        string INamed.Name { get => Name; set => Name = value; }

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

        #endregion

    }
}
