using System;
using System.Collections.Generic;

using Diagram.UI.Interfaces;
using NamedTree.Interfaces;

namespace Diagram.UI.Objects
{
    /// <summary>
    /// Empty add and remove
    /// </summary>
    public class EmptyAddRemove : CategoryTheory.CategoryObject, IAddRemove
    {
        #region Fields

        private Type type = typeof(object);

        #endregion

        #region IAddRemove Members

 

        void IChildren<object>.AddChild(object child)
        {
        }

        void IChildren<object>.RemoveChild(object child)
        {
        }

        Type IAddRemove.Type
        {
            get { return typeof(object); }
        }

        IEnumerable<object> IChildren<object>.Children => [];



        event Action<object> IChildren<object>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<object> IChildren<object>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        #endregion
    }
}
