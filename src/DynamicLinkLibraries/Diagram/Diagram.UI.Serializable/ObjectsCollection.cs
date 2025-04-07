using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using System.Dynamic;

namespace Diagram.UI
{
    /// <summary>
    /// Collection of objects
    /// </summary>
    [Serializable()]
    public class ObjectsCollection : CategoryObject, ISerializable, IObjectCollection, IAddRemove
    {
        #region Fields

        Performer performer = new();

        /// <summary>
        /// Type of element
        /// </summary>
        private Type type;

        /// <summary>
        /// The collection
        /// </summary>
        private List<object> list = new List<object>();

        /// <summary>
        /// Add event
        /// </summary>
        protected event Action<object> add = (object o) => { };
        
        /// <summary>
        /// Remove event
        /// </summary>
        protected event Action<object> remove = (object o) => { };

        IComponentCollection components = null;



        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of element</param>
        public ObjectsCollection(Type type)
        {
            components = this;
            this.type = type;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ObjectsCollection(SerializationInfo info, StreamingContext context)
        {
            components = this;
            try
            {
                type = info.GetValue("Type", typeof(Type)) as Type;
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            try
            {
                info.AddValue("Type", type, typeof(Type));
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region IObjectCollection Members

        IEnumerable<T> IComponentCollection.Get<T>() where T : class
        {
            return performer.GetObjectsAndArrows<T>(this);
        }

        string[] IObjectCollection.Names
        {
            get 
            {
                List<string> ll = new List<string>();
                foreach (object o in list)
                {
                    if (o is IAssociatedObject)
                    {
                       ll.Add(this.GetRelativeName(o as IAssociatedObject));
                   }
                }
                return ll.ToArray();
            }
        }

        object IObjectCollection.this[string name]
        {
            get
            {
                foreach (object o in list)
                {
                    if (o is IAssociatedObject)
                    {
                      string n = this.GetRelativeName(o as IAssociatedObject);
                      if (n.Equals(name))
                      {
                          if (o is ICategoryObject | o is ICategoryArrow)
                          {
                              return o;
                          }
                      }
                   }
                    if (o is IObjectLabel)
                    {
                        IObjectLabel ol = o as IObjectLabel;
                        return ol.Object;
                    }
                    if (o is IArrowLabel)
                    {
                        IArrowLabel al = o as IArrowLabel;
                        return al.Arrow;
                    }
                }
                return null;
            }
        }

        #endregion

        #region IComponentCollection Members

   
        IEnumerable<object> IComponentCollection.AllComponents
        {
            get
            {
                List<object> l = new List<object>();
                foreach (object o in list)
                {
                    if (o is INamedComponent)
                    {
                        if (!l.Contains(o))
                        {
                            l.Add(o);
                            continue;
                        }
                    }
                    if (o is IAssociatedObject)
                    {
                        IAssociatedObject ao = o as IAssociatedObject;
                        object ob = ao.Object;
                        if (ob is INamedComponent)
                        {
                            if (!l.Contains(ob))
                            {
                                l.Add(ob);
                                continue;
                            }
                        }
                    }
                }
                return l;
            }
        }


        IDesktop IComponentCollection.Desktop
        {
            get 
            {
               object o = Object;
                if (o != null)
                {
                    if (o is IObjectLabel)
                    {
                        IObjectLabel ol = o as IObjectLabel;
                        return ol.Desktop;
                    }
                }
                return null;
            }
        }

        
        
        #endregion

        #region Members

        /// <summary>
        /// Type of element
        /// </summary>
        public Type Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// Count of elements
        /// </summary>
        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        IEnumerable<IObjectLabel> IComponentCollection.Objects => components.Get<IObjectLabel>();

        IEnumerable<IArrowLabel> IComponentCollection.Arrows => components.Get<IArrowLabel>();

        IEnumerable<INamedComponent> IComponentCollection.NamedComponents => components.Get<INamedComponent>();

        IEnumerable<ICategoryObject> IComponentCollection.CategoryObjects => components.Get<ICategoryObject>();

        IEnumerable<ICategoryArrow> IComponentCollection.CategoryArrows => components.Get<ICategoryArrow>();

        /// <summary>
        /// Access to element
        /// </summary>
        /// <param name="number">Number of element</param>
        /// <returns></returns>
        public object this[int number]
        {
            get
            {
                return list[number];
            }
        }

        /// <summary>
        /// Adds object
        /// </summary>
        /// <param name="obj">The object to add</param>
        public void Add(object obj)
        {
            list.Add(obj);
            add(obj);
        }

        /// <summary>
        /// Removes object
        /// </summary>
        /// <param name="obj">The object to remove</param>
        public void Remove(object obj)
        {
            list.Remove(obj);
            remove(obj);
        }

        #endregion

        #region IAddRemove Members

  
        event Action<object> IAddRemove.AddAction
        {
            add { add += value; }
            remove { add -= value; }
        }

        event Action<object> IAddRemove.RemoveAction
        {
            add { remove += value; }
            remove { remove -= value; }
        }

        #endregion
  
    }
}
