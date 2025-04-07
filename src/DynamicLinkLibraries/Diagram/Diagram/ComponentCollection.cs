using System.Collections.Generic;
using CategoryTheory;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using NamedTree;


namespace Diagram.UI
{
    class A : IComponentCollection
    {

        #region NEW
        IEnumerable<object> IComponentCollection.AllComponents => throw new System.NotImplementedException();

        IDesktop IComponentCollection.Desktop => throw new System.NotImplementedException();

        IEnumerable<IObjectLabel> IComponentCollection.Objects => throw new System.NotImplementedException();

        IEnumerable<IArrowLabel> IComponentCollection.Arrows => throw new System.NotImplementedException();

        IEnumerable<INamedComponent> IComponentCollection.NamedComponents => throw new System.NotImplementedException();

        IEnumerable<ICategoryObject> IComponentCollection.CategoryObjects => throw new System.NotImplementedException();

        IEnumerable<ICategoryArrow> IComponentCollection.CategoryArrows => throw new System.NotImplementedException();

        string INamed.Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        IEnumerable<T> IComponentCollection.Get<T>()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }


    /// <summary>
    /// Collection of components
    /// </summary>
    public class ComponentCollection : IComponentCollection
    {
        #region Fields

        Performer pefrormer = new Performer();

        /// <summary>
        /// All objects
        /// </summary>
        ICollection<object> allObjects;

        /// <summary>
        /// Desktop;
        /// </summary>
        IDesktop desktop;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="allObjects">All objects</param>
        /// <param name="desktop">Desktop</param>
        public ComponentCollection(ICollection<object> allObjects, IDesktop desktop)
        {
            this.allObjects = allObjects;
            this.desktop = desktop;
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
   
        IEnumerable<IObjectLabel> IComponentCollection.Objects => throw new System.NotImplementedException();

        IEnumerable<IArrowLabel> IComponentCollection.Arrows => throw new System.NotImplementedException();

        IEnumerable<INamedComponent> IComponentCollection.NamedComponents => throw new System.NotImplementedException();

        IEnumerable<ICategoryObject> IComponentCollection.CategoryObjects => throw new System.NotImplementedException();

        IEnumerable<ICategoryArrow> IComponentCollection.CategoryArrows => throw new System.NotImplementedException();

        string INamed.Name { get => Name; set => Name = value; }

        IEnumerable<T> IComponentCollection.Get<T>() where T : class
        {
            return pefrormer.GetObjectsAndArrows<T>(this);
        }

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
