using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using BaseTypes;

using Motion6D;
using Motion6D.Interfaces;

using Vector3D;
using SphericalFields;
using PhysicalField.Interfaces;
using Motion6D.Portable;

namespace PhysicalField
{
    /// <summary>
    /// Spherical magnetic Field
    /// </summary>
    [Serializable()]
    public class SphericalFieldWrapper : CategoryObject, ISerializable, IPhysicalField, IPositionObject
    {
        #region Fields

        /// <summary>
        /// Position
        /// </summary>
        private IPosition position;

        /// <summary>
        /// Field
        /// </summary>
        private SphericalField field;

        /// <summary>
        /// Type of field
        /// </summary>
        static private readonly ArrayReturnType type = new ArrayReturnType((double)0, new int[] { 3 }, false);

        /// <summary>
        /// Cosine ciefficients
        /// </summary>
        private double[][] ccoeff;

        /// <summary>
        /// Sin coeff
        /// </summary>
        private double[][] scoeff;

        /// <summary>
        /// The n - parameter
        /// </summary>
        private int n;

        /// <summary>
        /// The m - parameter
        /// </summary>
        private int m;

        /// <summary>
        /// Typical radius
        /// </summary>
        private double radius;

        /// <summary>
        /// Result
        /// </summary>
        private double[] result = new double[3];

        /// <summary>
        /// Transition matrix
        /// </summary>
        private double[,] matrix = new double[3, 3];

        /// <summary>
        /// Type of field
        /// </summary>
        private int fieldType;


        /// <summary>
        /// Object result
        /// </summary>
        private object[] objectResult;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SphericalFieldWrapper(int fieldType)
        {
            this.fieldType = fieldType;
            CreateField();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SphericalFieldWrapper(SerializationInfo info, StreamingContext context)
        {
            ccoeff = info.GetValue("Cos", typeof(double[][])) as double[][];
            scoeff = info.GetValue("Sin", typeof(double[][])) as double[][];
            radius = (double)info.GetValue("Radius", typeof(double));
            n = (int)info.GetValue("N", typeof(int));
            m = (int)info.GetValue("M", typeof(int));
            fieldType = (int)info.GetValue("FieldType", typeof(int));
            CreateField();
            Init();
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Cos", ccoeff, typeof(double[][]));
            info.AddValue("Sin", scoeff, typeof(double[][]));
            info.AddValue("Radius", radius, typeof(double));
            info.AddValue("N", n, typeof(int));
            info.AddValue("M", m, typeof(int));
            info.AddValue("FieldType", fieldType, typeof(int));
        }

        #endregion

        #region IPhysicalField Members

        int IPhysicalField.SpaceDimension
        {
            get { return 3; }
        }

        int IPhysicalField.Count
        {
            get { return 1; }
        }

        object IPhysicalField.GetType(int n)
        {
            return type;
        }

        object IPhysicalField.GetTransformationType(int n)
        {
            return Field3D_Types.CovariantVector;
        }

        object[] IPhysicalField.this[double[] position]
        {
            get 
            { 
                Calculate(position);
                return objectResult;
            }
        }

        #endregion

        #region IPositionObject Members

        public IPosition Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// The N parameter
        /// </summary>
        public int N
        {
            get
            {
                return n;
            }
        }

        /// <summary>
        /// The M parameter
        /// </summary>
        public int M
        {
            get
            {
                return m;
            }
        }

        /// <summary>
        /// Radius
        /// </summary>
        public double Radius
        {
            get
            {
                return radius;
            }
        }

        /// <summary>
        /// Cosine coefficients
        /// </summary>
        public double[][] Cos
        {
            get
            {
                return ccoeff;
            }
        }

        /// <summary>
        /// Sin coefficients
        /// </summary>
        public double[][] Sin
        {
            get
            {
                return scoeff;
            }
        }

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="n">The N parameter</param>
        /// <param name="m">The M parameter</param>
        /// <param name="ccoeff">Cosine coefficients</param>
        /// <param name="scoeff">Sin coefficients</param>
        /// <param name="radius">Radius</param>
        public void Set(int n, int m, double[][] ccoeff, double[][] scoeff, double radius)
        {
            this.n = n;
            this.m = m;
            this.ccoeff = ccoeff;
            this.scoeff = scoeff;
            this.radius = radius;
            Init();
        }

        /// <summary>
        /// Creates field
        /// </summary>
        private void CreateField()
        {
            field = SphericalField.CreateField(fieldType);
        }

        /// <summary>
        /// Initialisation
        /// </summary>
        private void Init()
        {
            double[][] c = new double[ccoeff.Length][];
            double[][] s = new double[scoeff.Length][];
            for (int i = 0; i < c.Length; i++)
            {
                double[] cc = ccoeff[i];
                double[] ccc = new double[cc.Length];
                Array.Copy(cc, ccc, cc.Length);
                c[i] = ccc;
                double[] ss = scoeff[i];
                double[] sss = new double[ss.Length];
                Array.Copy(ss, sss, ss.Length);
                s[i] = sss;
            }
            field.Set(n, m, radius, c, s);
            if (objectResult == null)
            {
                objectResult = new object[] { result };
            }
        }

        /// <summary>
        /// Calculates field
        /// </summary>
        /// <param name="position">Position</param>
        private void Calculate(double[] position)
        {
            double rho, r, cphi, sphi, ctheta, stheta;
            SphericalTrigonometry.CalculateSphericalCoorditates(position, out ctheta, out stheta, out cphi, out sphi, out rho, out r);
            field.Caclulate(ctheta, stheta, cphi, sphi, r);
            double[] v = field.Value as double[];
            double Brho = v[0] * ctheta + v[1] * stheta;
            result[0] = Brho * cphi - v[2] * sphi;
            result[1] = Brho * sphi + v[2] * cphi;
            result[2] = v[0] * stheta + v[1] * ctheta;
        }

        #endregion

    }
}
