﻿using System;
using System.Runtime.Serialization;

namespace Event.Basic.Arrows
{
    /// <summary>
    /// Link between event and its handler
    /// </summary>
    [Serializable()]
    public class EventLink : Portable.Arrows.EventLink, ISerializable
    {
        #region Fields

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventLink()
        {
        }

                /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected EventLink(SerializationInfo info, StreamingContext conext)
        {

        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion


    }
}
