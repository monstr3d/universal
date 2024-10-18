using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;


using Diagram.UI;
using DataPerformer.Interfaces;

namespace DataPerformer.Helpers
{
    /// <summary>
    /// Collection and transformer
    /// </summary>
    [Serializable()]
    public class DataPerformerCollectionStateTransformer : ObjectsCollection, IChildrenObject, IPostSetArrow, IDisposable
    {
        #region Fields

        IAssociatedObject[] children = new IAssociatedObject[1];

        /// <summary>
        /// Child transformer
        /// </summary>
        AbstractDoubleTransformer transformer;

        Type transformerType = typeof(StateTransformer);

        string measurements = "";

        double step = 0;

        #endregion


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataPerformerCollectionStateTransformer()
            : base(typeof(object))
        {
            SetChildren();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DataPerformerCollectionStateTransformer(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            try
            {
                step = info.GetDouble("Step");
                measurements = info.GetString("Measurements");
                transformerType = info.GetValue("TransformerType", typeof(Type)) as Type;
            }
            catch (Exception)
            {
            }
            SetChildren();
        }
        

        #endregion

        #region IChildrenObject Members

        IAssociatedObject[] IChildrenObject.Children
        {
            get { return children; }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Measurements = measurements;
            Step = step;
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            IDisposable d = transformer;
            d.Dispose();
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            try
            {
                base.GetObjectData(info, context);
                info.AddValue("Step", step);
                info.AddValue("Measurements", measurements);
                info.AddValue("TransformerType", transformerType, typeof(Type));
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Type of transformer
        /// </summary>
        public Type TransformerType
        {
            get
            {
                return transformerType;
            }
            set
            {
                if (transformerType != null)
                {
                    if (transformerType.Equals(value))
                    {
                        return;
                    }
                }
                transformerType = value;
                SetChildren();
            }
        }

        /// <summary>
        /// Transformer
        /// </summary>
        public AbstractDoubleTransformer Transformer
        {
            get
            {
                return transformer;
            }
        }


        /// <summary>
        /// Step
        /// </summary>
        public double Step
        {
            get
            {
                if (transformer is ITimeMeasurementProvider)
                {
                    ITimeMeasurementProvider pr = transformer as ITimeMeasurementProvider;
                    return pr.Step;
                }
                return 0;
            }
            set
            {
                step = value;
                if (transformer is ITimeMeasurementProvider)
                {
                    ITimeMeasurementProvider pr = transformer as ITimeMeasurementProvider;
                    pr.Step = value;
                }
            }
        }

        /// <summary>
        /// Measurements
        /// </summary>
        public string Measurements
        {
            get
            {
                return measurements;
            }
            set
            {
                measurements = value;
                if (transformer is StateVariableTransformer)
                {
                    StateVariableTransformer smt = transformer as StateVariableTransformer;
                    smt.Measurements = measurements;
                }
            }
        }

        /// <summary>
        /// Sets child transformer
        /// </summary>
        void SetChildren()
        {
            if (transformer != null)
            {
                if (transformer.GetType().Equals(transformerType))
                {
                    return;
                }
                IDisposable d = transformer;
                d.Dispose();
            }
            if (transformerType.Equals(typeof(StateTransformer)))
            {
                transformer = new StateTransformer(this);
            }
            else
            {
                transformer = new StateVariableTransformer(this);
            }
            children[0] = transformer;
        }

        #endregion

   }
}
