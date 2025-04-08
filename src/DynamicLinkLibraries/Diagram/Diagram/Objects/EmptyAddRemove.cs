using Diagram.UI.Interfaces;
using NamedTree;
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
