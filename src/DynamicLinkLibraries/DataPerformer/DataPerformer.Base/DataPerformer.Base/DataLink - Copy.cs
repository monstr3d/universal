using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;


using DataPerformer.Interfaces;
using DataPerformer.Portable.Interfaces;

namespace DataPerformer
{
    /// <summary>
    /// The link between data provider and data consumer
    /// </summary>
    [Serializable()]
    public class DataLink : DataPerformer.Portable.DataLink, ISerializable,
        IRemovableObject, IDataLinkFactory
    {

        #region Fields

   
  

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataLink()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DataLink(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }


        #endregion

        #region ICategoryArrow Members

 
        #endregion
/*
        #region IDataLinkFactory Members

        IDataConsumer IDataLinkFactory.GetConsumer(ICategoryObject source)
        {
            IAssociatedObject ao = source;
            object o = ao.Object;
            if (o is INamedComponent)
            {
                IDataConsumer dcl = null;
                INamedComponent comp = o as INamedComponent;
                IDesktop desktop = comp.Root.Desktop;
                desktop.ForEach<DataLink>((DataLink dl) =>
                {
                    if (dcl != null)
                    {
                        return;
                    }
                    object dt = dl.Source;
                    if (dt is IAssociatedObject)
                    {
                        IAssociatedObject aot = dt as IAssociatedObject;
                        if (aot.Object == o)
                        {
                            dcl = dl.source as IDataConsumer;
                        }
                    }
                });
                if (dcl != null)
                {
                    return dcl;
                }
            }

            IDataConsumer dc = DataConsumerWrapper.Create(source);
            if (dc == null)
            {
                CategoryException.ThrowIllegalTargetException();
            }
            return dc;
        }

        IMeasurements IDataLinkFactory.GetMeasurements(ICategoryObject target)
        {
            IAssociatedObject ao = target;
            object o = ao.Object;
            if (o is INamedComponent)
            {
                IMeasurements ml = null;
                INamedComponent comp = o as INamedComponent;
                IDesktop d = null;
                INamedComponent r = comp.Root;
                if (r != null)
                {
                    d = r.Desktop;
                }
                else
                {
                    d = comp.Desktop;
                }
                if (d != null)
                {
                    d.ForEach<DataLink>((DataLink dl) =>
                    {
                        if (ml != null)
                        {
                            return;
                        }
                        object dt = dl.Target;
                        if (dt is IAssociatedObject)
                        {
                            IAssociatedObject aot = dt as IAssociatedObject;
                            if (aot.Object == o)
                            {
                                ml = dl.Target as IMeasurements;
                            }
                        }
                    });
                    if (ml != null)
                    {
                        return ml;
                    }
                }
            }
            IMeasurements m = MeasurementsWrapper.Create(target);
            if (m == null)
            {
                CategoryException.ThrowIllegalTargetException();
            }
            return m;
        }

        #endregion
*/
    }
}
