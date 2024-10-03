using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CategoryTheory;

using Diagram.UI.Labels;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Object container
    /// </summary>
    public interface IObjectContainer : IObjectCollection
    {

        /// <summary>
        /// Gets relative name of component
        /// </summary>
        /// <param name="comp">The component</param>
        /// <returns>The relative name</returns>
        string GetName(INamedComponent comp);

        /// <summary>
        /// Gets named component from name
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Component</returns>
        new INamedComponent this[string name]
        {
            get;
        }

        /// <summary>
        /// All child objects
        /// </summary>
        ICollection<object> AllObjects
        {
            get;
        }


        /// <summary>
        /// Post load opreation
        /// </summary>
        /// <returns></returns>
        bool PostLoad();

        /// <summary>
        /// Sets parents of objects
        /// </summary>
        /// <param name="desktop">The desktop</param>
        void SetParents(IDesktop desktop);

        /// <summary>
        /// Loads itself
        /// </summary>
        /// <returns>True in success</returns>
        bool Load();

        /// <summary>
        /// Public interface
        /// </summary>
        Dictionary<string, object> Interface
        {
            get;
        }

        /// <summary>
        /// Loads desktop
        /// </summary>
        /// <returns>Desktop</returns>
        IDesktop LoadDesktop();

    }
}
