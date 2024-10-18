using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI.Interfaces;

namespace Diagram.UI
{
    /// <summary>
    /// The belongs to collection link
    /// </summary>
    public class BelongsToCollectionPortable : CategoryArrow, IDisposable
    {
        #region Fields

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
        public BelongsToCollectionPortable()
        {
        }

 
        #endregion
 
        #region Overriden Members

        /// <summary>
        /// Source
        /// </summary>
        public override ICategoryObject Source
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
        public override ICategoryObject Target
        {
            get
            {
                return target as ICategoryObject;
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

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if ((source != null) & (target != null))
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
            if (value is IChildrenObject)
            {
                IChildrenObject ch = value as IChildrenObject;
                IAssociatedObject[] ass = ch.Children;
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
