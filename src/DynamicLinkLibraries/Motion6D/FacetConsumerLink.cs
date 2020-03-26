using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using Motion6D.Interfaces;


namespace Motion6D
{
    /// <summary>
    /// Link to facet
    /// </summary>
    [Serializable()]
    public class FacetConsumerLink : CategoryArrow, IRemovableObject
    {

        #region Fields

        IFacetConsumer consumer;

        IFacet facet;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FacetConsumerLink()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected FacetConsumerLink(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// The source of this arrow
        /// </summary>
        public override ICategoryObject Source
        {
            get
            {
                return consumer as ICategoryObject;
            }
            set
            {
                consumer = value.GetSource<IFacetConsumer>();
            }
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        public override ICategoryObject Target
        {
            get
            {
                return facet as ICategoryObject;
            }
            set
            {
                facet = value.GetTarget<IFacet>();
                consumer.Facet = facet;
            }
        }

        #endregion

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            if (consumer != null)
            {
                consumer.Facet = null;
            }
            consumer = null;
            facet = null;
        }

        #endregion
    }
}
