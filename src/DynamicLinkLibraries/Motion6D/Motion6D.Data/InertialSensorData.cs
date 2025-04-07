using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using Diagram.UI;
using BaseTypes;

using DataPerformer;
using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

using Motion6D.Interfaces;
using NamedTree;

namespace Motion6D
{
    /// <summary>
    /// Data for inertial sensor
    /// </summary>
    [Serializable()]
    public class InertialSensorData : CategoryObject, ISerializable, IMeasurements,
        IPositionObject, IPostSetArrow, IChildren<IAssociatedObject>
    {
        #region Fields


        /// <summary>
        /// Measurements
        /// </summary>
        IMeasurement[] measurements = new IMeasurement[8];

        /// <summary>
        /// Acceleration
        /// </summary>
        double[] acc = new double[3];

        /// <summary>
        /// Angular acceleration
        /// </summary>
        double[] eps = new double[3];

        /// <summary>
        /// Relative acceleration
        /// </summary>
        double[] relacc = new double[3];

        /// <summary>
        /// Transformation
        /// </summary>
        Action<double[]> transform;

        /// <summary>
        /// The "is updated" sign
        /// </summary>
        bool isUpdated;

        /// <summary>
        /// Accelerated frame
        /// </summary>
        IAcceleration accframe;

        /// <summary>
        /// Angular frame
        /// </summary>
        IAngularAcceleration ancframe;

        /// <summary>
        /// Frame
        /// </summary>
        ReferenceFrame frame;

        /// <summary>
        /// Position
        /// </summary>
        IPosition pos;

        /// <summary>
        /// Return type
        /// </summary>
        private static readonly ArrayReturnType type = new ArrayReturnType((Double)0, new int[] { 3 }, false);

        /// <summary>
        /// Relative frame
        /// </summary>
        RelativeField relative = new RelativeField(false);

        /// <summary>
        /// Children
        /// </summary>
        IAssociatedObject[] children = new IAssociatedObject[1];


        #endregion

        #region Ctor

        /// <summary>
        /// Default ctor
        /// </summary>
        public InertialSensorData()
        {
            CreateMeasurements();
            transform = Copy;
            children[0] = relative;
            post();
        }

        /// <summary>
        /// Deserialization ctor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected InertialSensorData(SerializationInfo info, StreamingContext context)
            : this()
        {
            relative = RelativeField.Load(info, this);
            post();
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            relative.Save(info);
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return measurements.Length; }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return measurements[n]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            update();
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return isUpdated;
            }
            set
            {
                isUpdated = value;
            }
        }

        #endregion

        #region IPositionObject Members

        IPosition IPositionObject.Position
        {
            get
            {
                return pos;
            }
            set
            {
                ReferenceFrame f = value.GetFrame();
                if (!(f is IAcceleration))
                {
                    throw new Exception("You should set this component on accelerated frame");
                }
                pos = value;
                frame = f;
                accframe = f as IAcceleration;
                ancframe = f as IAngularAcceleration;
                IPositionObject po = relative as IPositionObject;
                po.Position = value;
            }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            IPostSetArrow p = relative as IPostSetArrow;
            p.PostSetArrow();
            transform = VectorOperations.CreateTransformer(Copy, this);
        }

        #endregion

        #region IChildrenObject Members


        IEnumerable<IAssociatedObject> IChildren<IAssociatedObject>.Children => children;

        #endregion

        #region Members

        /// <summary>
        /// Returns field
        /// </summary>
        public RelativeField Field
        {
            get
            {
                return relative;
            }
        }

        void post()
        {
            IPositionObject po = relative;
            po.Position = pos;
        }

 

        void Copy(double[] x)
        {
            Array.Copy(accframe.LinearAcceleration, x, 3);
        }



        void update()
        {
            Array.Copy(ancframe.AngularAcceleration, eps, 3);
            transform(acc);
        }


        void CreateMeasurements()
        {
 
            measurements[0] = new Measurement(type, getA, "A", this);
            measurements[1] = new Measurement(type, getEps, "E", this);
            measurements[2] = new Measurement(getAx, "Ax", this);
            measurements[3] = new Measurement(getAy, "Ay", this);
            measurements[4] = new Measurement(getAz, "Az", this);
            measurements[5] = new Measurement(getEx, "Ex", this);
            measurements[6] = new Measurement(getEy, "Ey", this);
            measurements[7] = new Measurement(getEz, "Ez", this);
        }

        object getAx()
        {
            return acc[0];
        }

        object getAy()
        {
            return acc[1];
        }
        object getAz()
        {
            return acc[2];
        }

        object getA()
        {
            return acc;
        }


        object getEx()
        {
            return eps[0];
        }

        object getEy()
        {
            return eps[1];
        }

        object getEz()
        {
            return eps[2];
        }

        object getEps()
        {
            return eps;
        }


        #endregion

    }
}
