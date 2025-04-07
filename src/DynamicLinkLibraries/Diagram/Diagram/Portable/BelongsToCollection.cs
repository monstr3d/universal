using System;
using System.Collections.Generic;
using System.Linq;
using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Interfaces;
using NamedTree;

namespace Diagram.UI.Portable
{
    /// <summary>
    /// The belongs to collection link
    /// </summary>
    public class BelongsToCollection : ICategoryArrow, IDisposable
    {
        #region Fields

        /// <summary>
        /// Associated object
        /// </summary>
        private object obj;

        /// <summary>
        /// Source
        /// </summary>
        private IAddRemove source;

        /// <summary>
        /// Target
        /// </summary>
        private ICategoryObject target;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BelongsToCollection()
        {

        }


        #endregion

        #region ICategoryArrow Members

        /// <summary>
        /// Source
        /// </summary>
        ICategoryObject ICategoryArrow.Source
        {
            get
            {
                return source as ICategoryObject;
            }
            set
            {
                source = value.GetObject<IAddRemove>();
            }
        }

        /// <summary>
        /// Target
        /// </summary>
        ICategoryObject ICategoryArrow.Target
        {
            get
            {
                return target;
            }
            set
            {
                if (Check(value))
                {
                    return;
                }
                CategoryException.ThrowIllegalTargetException();
            }
        }

        /// <summary>
        /// The associated object
        /// </summary>
        object IAssociatedObject.Object { get => obj; set => obj = value; }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (source != null & target != null)
            {
                source.Remove(target);
                source = null;
                target = null;
            }
        }

        #endregion

        #region Members

        private void Accept(ICategoryObject value)
        {
            target = value;
            source.Add(target);
        }

        private bool Check(ICategoryObject value)
        {
            Type t = value.GetType();
            System.Reflection.TypeInfo ti = System.Reflection.IntrospectionExtensions.GetTypeInfo(t);
            Type to = source.Type;
            if (t.Equals(to) | ti.IsSubclassOf(to))
            {
                Accept(value);
                return true;
            }
            IEnumerable<Type> types = ti.ImplementedInterfaces;
            foreach (Type tp in types)
            {
                if (tp.Equals(to))
                {
                    Accept(value);
                    return true;
                }
            }
            if (value is IChildren<IAssociatedObject> ch)
            {
                IAssociatedObject[] ass = ch.Children.ToArray();
                if (ass != null)
                {
                    foreach (object o in ass)
                    {
                        if (o is ICategoryObject)
                        {
                            ICategoryObject co = o as ICategoryObject;
                            if (Check(co))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        #endregion

    }
}
