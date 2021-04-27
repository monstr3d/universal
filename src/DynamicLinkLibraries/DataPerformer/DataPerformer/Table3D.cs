using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.IO;


using CategoryTheory;

using BaseTypes.Interfaces;
using BaseTypes;


using Diagram.UI;
using Diagram.UI.Labels;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;


namespace DataPerformer
{
    /// <summary>
    /// Table of three parameters
    /// This table uses linear interpolation
    /// </summary>
    [Serializable()]
    public class Table3D : Portable.Table3D, ISerializable, IPostSetArrow
    {

        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        /// <summary>
        /// Associated object
        /// </summary>
        private object obj;

        /// <summary>
        /// Output measurements
        /// </summary>
        private IMeasurement[] output = null;

        /// <summary>
        /// Arguments
        /// </summary>
        private string[] arguments;

        /// <summary>
        /// Input measurements
        /// </summary>
        private IMeasurement[] input = new IMeasurement[2];

        /// <summary>
        /// The x, y - arguments
        /// </summary>
        private readonly string[] xy = new string[] { "x", "y" };

        /// <summary>
        /// Measurements
        /// </summary>
        private List<IMeasurements> measurements = new List<IMeasurements>();

        /// <summary>
        /// The "is updated" sign
        /// </summary>
        private bool isUpdated;

        /// <summary>
        /// The "has derivation" sign
        /// </summary>
        private bool hasDerivation = true;

        private const double type = 0;

        private readonly object[] types = new object[] { new ArrayReturnType((double)0, new int[] { 2 }, false) };


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Table3D()
        {
        }

        /// <summary>
        /// Deserilaization constructor
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected Table3D(SerializationInfo info, StreamingContext context)
        {
            args = info.GetValue("Args", typeof(double[][])) as double[][];
            fun = info.GetValue("Fun", typeof(double[,,])) as double[,,];
            throwsOutOfRangeException = info.GetBoolean("ThrowsOutOfRangeException");
            comments = info.GetValue("Comments", typeof(byte[])) as byte[];

            Func<object> fn = () => { return this; };
            output = new IMeasurement[]{ new Measurement(this, fn, "Function")};
            
            /*arguments = (string[])info.GetValue("Arguments", typeof(string[]));
            Double a = 0;
            output[0] = new MeasurementDerivation(a, new Func<object>(GetFunction), new Measure(GetDerivation, "Der_Value"), "Value");
            Func<object> fn = () => { return this; };
            output[1] = new Measure(this, fn, "Function");
            try
            {
                throwsOutOfRangeException =
                    info.GetBoolean("ThrowsOutOfRangeException");
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }*/
        }


        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Args", args, typeof(double[][]));
            info.AddValue("Fun", fun, typeof(double[,,]));
            info.AddValue("ThrowsOutOfRangeException", throwsOutOfRangeException);
            info.AddValue("Comments", comments, typeof(byte[]));
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            try
            {
                AcceptArguments();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        #endregion

        #region Public Members

 
        /// <summary>
        /// Comments
        /// </summary>
        public ICollection Comments
        {
            get
            {
                return PureDesktopPeer.Deserialize(comments) as ICollection;
            }
            set
            {
                comments = PureDesktopPeer.Serialize(value);
            }
        }

        #endregion


        #region Private Members

        /// <summary>
        /// Accepts arguments
        /// </summary>
        private void AcceptArguments()
        {
            foreach (IMeasurements measurements in this.measurements)
            {
                IAssociatedObject cont = measurements as IAssociatedObject;
                INamedComponent c = cont.Object as INamedComponent;
                string name = c.Name;
                for (int i = 0; i < measurements.Count; i++)
                {
                    IMeasurement measure = measurements[i];
                    string p = name + "." + measure.Name;
                    for (int j = 0; j < 2; j++)
                    {
                        if (arguments[j].Equals(p))
                        {
                            input[j] = measure;
                            break;
                        }
                    }
                }
            }
            hasDerivation = true;
            for (int i = 0; i < input.Length; i++)
            {
                IDerivation der = input[i] as IDerivation;
                if (der == null)
                {
                    hasDerivation = false;
                    break;
                }
            }
        }

        #endregion
    }
}
