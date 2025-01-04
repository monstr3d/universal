using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;

namespace MathGraph
{
    /// <summary>
    /// Edge of digraph
    /// </summary>
    public class DigraphEdge : IAssociatedObject, IDisposable
    {
        /// <summary>
        /// Linked object
        /// </summary>
        protected object obj;

        /// <summary>
        /// Edge source
        /// </summary>
        protected DigraphVertex source;

        /// <summary>
        /// Edge target
        /// </summary>
        protected DigraphVertex target;

        /// <summary>
        /// The associated object
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
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public DigraphEdge()
        {

        }

        /// <summary>
        /// Edge source
        /// </summary>
        public DigraphVertex Source
        {
            set
            {
                if (source != null)
                {
                    throw new Exception("Source is already defined");
                }
                if (target != null)
                {
                    if (value.Parent != target.Parent)
                    {
                        throw new Exception("Different parents of source and target");
                    }
                }
                source = value;
                source.AddOutcoming(this);
            }
            get
            {
                return source;
            }
        }

        /// <summary>
        /// Edge target
        /// </summary>
        public DigraphVertex Target
        {
            set
            {
                if (target != null)
                {
                    throw new Exception("Target is already defined");
                }
                if (source != null)
                {
                    if (value.Parent != source.Parent)
                    {
                        throw new Exception("Different parents of source and target");
                    }
                }
                target = value;
                target.AddIncoming(this);
            }
            get
            {
                return target;
            }
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        void IDisposable.Dispose() 
        {
            source.RemoveOutcoming(this);
            target.RemoveIncoming(this);
        }

        /// <summary>
        /// Associated category object
        /// </summary>
        public ICategoryObject CategoryObject
        {
            get
            {
                if (obj == null)
                {
                    return null;
                }
                if (obj is ICategoryObject)
                {
                    return obj as ICategoryObject;
                }
                if (obj is IAssociatedObject)
                {
                    IAssociatedObject ao = obj as IAssociatedObject;
                    object o = ao.Object;
                    if (o != null)
                    {
                        if (o is ICategoryObject)
                        {
                            return o as ICategoryObject;
                        }
                    }
                }
                return null;
            }
        }

    }
}
