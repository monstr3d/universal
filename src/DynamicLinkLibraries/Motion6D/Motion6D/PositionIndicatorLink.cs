using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Link to position indicator
    /// </summary>
    [Serializable()]
    public class PositionIndicatorLink : ISerializable, ICategoryArrow, IRemovableObject
    {
        #region Fields
        object obj;

        PositionCollectionIndicator indicator;

        IPositionCollection collecion;
        #endregion


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PositionIndicatorLink()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private PositionIndicatorLink(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }

        #endregion

        #region ICategoryArrow Members

        ICategoryObject ICategoryArrow.Source
        {
            get
            {
                return indicator;
            }
            set
            {
                if (!(value is PositionCollectionIndicator))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                indicator = value as PositionCollectionIndicator;
            }
        }

        ICategoryObject ICategoryArrow.Target
        {
            get
            {
                return collecion as ICategoryObject;
            }
            set
            {
                if (!(value is IPositionCollection))
                {
                    CategoryException.ThrowIllegalTargetException();
                }
                collecion = value as IPositionCollection;
                indicator.Positions = collecion;
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
            indicator.Positions = null;
        }

        #endregion
    }
}
