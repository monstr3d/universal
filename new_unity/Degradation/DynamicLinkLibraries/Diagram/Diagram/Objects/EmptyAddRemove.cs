using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        void IAddRemove.Add(object obj)
        {
        }

        void IAddRemove.Remove(object obj)
        {
        }

        Type IAddRemove.Type
        {
            get { return typeof(object); }
        }

        event Action<object> IAddRemove.AddAction
        {
            add {  }
            remove { throw new NotImplementedException(); }
        }

        event Action<object> IAddRemove.RemoveAction
        {
            add { }
            remove { }
        }

        #endregion
    }
}
