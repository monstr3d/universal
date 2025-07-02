using System;
using System.Collections.Generic;
using System.Text;
using ErrorHandler;
using NamedTree;

namespace CategoryTheory
{
    /// <summary>
    /// Wrapper of category object
    /// </summary>
    public class CategoryObjectWrapper : ICategoryObject, IChildren<IAssociatedObject>
    {
        #region Fields

       Performer performer = new Performer();


        /// <summary>
        /// The internal object
        /// </summary>
        protected ICategoryObject theObject;

        /// <summary>
        /// Children
        /// </summary>
        protected IAssociatedObject[] children = new IAssociatedObject[1];

        /// <summary>
        /// The associated object;
        /// </summary>
        object obj;


        #endregion

        #region IAssociatedObject Members

        /// <summary>
        /// Associated object
        /// </summary>
        public object Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
                if (theObject != null)
                {
                    theObject.SetAssociatedObject(value);
                }
            }
        }

        #endregion 

        #region IChildrenObject Members

        string INamed.Name { get => performer.GetAssociatedName(this); 
            set =>new  ErrorHandler.WriteProhibitedException();
        }

        IEnumerable<IAssociatedObject> IChildren<IAssociatedObject>.Children => children;

        object IAssociatedObject.Object { get; set; }
        string INamed.NewName { get; set; }

        event Action<IAssociatedObject> IChildren<IAssociatedObject>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IAssociatedObject> IChildren<IAssociatedObject>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        void IChildren<IAssociatedObject>.AddChild(IAssociatedObject child)
        {
            children[0] = child;
        }

        void IChildren<IAssociatedObject>.RemoveChild(IAssociatedObject child)
        {
        }

        #endregion

    }
}
