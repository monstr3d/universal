using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Indicator of postition collection
    /// </summary>
    [Serializable()]
    public class PositionCollectionIndicator : RigidReferenceFrame
    {

        #region Fields

        /// <summary>
        /// Indicated collection
        /// </summary>
        protected IPositionCollection positions;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PositionCollectionIndicator()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected PositionCollectionIndicator(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }


        #endregion

        #region Specific Members

        /// <summary>
        /// Postitions object
        /// </summary>
        public IPositionCollection Positions
        {
            get { return positions; }
            set
            {
                if (value != null & positions != null)
                {
                    throw new Exception("Positios already exists");
                }
                positions = value;
            }
        }

        #endregion
    }
}
