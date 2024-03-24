using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diagram.UI.Interfaces;

namespace Diagram.UI
{
    /// <summary>
    /// Collection of components
    /// </summary>
    public class ComponentCollection : IComponentCollection
    {
        #region Fields

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

        #endregion
    }
}
