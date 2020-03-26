using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using PhysicalField.Interfaces;

namespace PhysicalField
{
    /// <summary>
    /// Link between Physical field and irradiated object
    /// </summary>
    [Serializable()]
    public class FieldLink : ICategoryArrow, IRemovableObject, ISerializable, IFieldFactory
    {
        #region Fields

        /// <summary>
        /// Global factory
        /// </summary>
        static private IFieldFactory factory = new FieldLink(); 



        protected object obj;

        /// <summary>
        /// Source
        /// </summary>
        private IFieldConsumer source;

        /// <summary>
        /// Target
        /// </summary>
        private IPhysicalField target;

        #endregion

        #region Ctor

        public FieldLink()
        {
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected FieldLink(SerializationInfo info, StreamingContext context)
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
                // Checks whether "value" implements IFieldConsumer interface
                // If not then throws exception
                // If yes then assigns object to source field
               source = value.GetSource<IFieldConsumer>();
            }
        }

        ICategoryObject ICategoryArrow.Target
        {
            get
            {
                return target as ICategoryObject;
            }
            set
            {
                IFieldFactory f = factory;
                if (f != null)
                {
                    IPhysicalField ph = value.GetTarget<IPhysicalField>();
                    if (ph != null)
                    {
                        target = ph;
                        if (source.SpaceDimension != target.SpaceDimension)
                        {
                            throw new CategoryException("Illegal space dimension");
                        }
                        source.Add(target);
                        return;
                    }
                }
                CategoryException.ThrowIllegalTargetException();
            }
        }

 
        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
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

        #endregion

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            source.Remove(target);
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region IFieldFactory Members

        IFieldConsumer IFieldFactory.GetConsumer(object obj)
        {
            if (obj is IAssociatedObject)
            {
                IAssociatedObject ao = obj as IAssociatedObject;
                return ao.GetObject<IFieldConsumer>();
            }
            return null;
        }

        IPhysicalField IFieldFactory.GetField(IFieldConsumer consumer, object obj)
        {
            if (obj is IAssociatedObject)
            {
                IAssociatedObject ao = obj as IAssociatedObject;
                object o = ao.GetObject<PhysicalField.Interfaces.IPhysicalField>();
            }
            return null;
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Global factory
        /// </summary>
        static public IFieldFactory Factory
        {
            get
            {
                return factory;
            }
            set
            {
                factory = value;
            }
        }


        #endregion
    }
}
