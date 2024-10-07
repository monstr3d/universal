using System;

using BaseTypes;

using DataPerformer.Interfaces;


namespace Regression.Portable
{
    /// <summary>
    /// Array selection
    /// </summary>
    public class ArraySelection : IMeasurement, IStructuredSelection
    {

        #region Fields

        /// <summary>
        /// Name of object
        /// </summary>
        protected string name = "";

        /// <summary>
        /// Selection data
        /// </summary>
        protected double[] data;

        private Func<object> p;
        private ArrayReturnType type;
 
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Selection name</param>
        /// <param name="data">Selection data</param>
        public ArraySelection(string name, double[] data)
        {
            p = parameter;
            this.name = name + "";
            Array = data;
        }

        #endregion

        #region IMeasurement Members

        /// <summary>
        /// Function of selection
        /// </summary>
        public Func<object> Parameter
        {
            get
            {
                return p;
            }
        }

        /// <summary>
        /// Derivation function
        /// </summary>
        public Func<object> Derivation
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }
        

        /// <summary>
        /// Factor
        /// </summary>
        public double Factor
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Measure type
        /// </summary>
        public object Type
        {
            get
            {
                return type;
            }
        }

        #endregion

        #region IStructuredSelection Members

        /// <summary>
        /// The "is fixed amount" sign
        /// </summary>
        public bool HasFixedAmount
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Access to n - th element
        /// </summary>
        public double? this[int n]
        {
            get
            {
                return data[n];
            }
        }

        /// <summary>
        /// Tolerance of it - th element
        /// </summary>
        /// <param name="n">Element number</param>
        /// <returns>Tolerance</returns>
        public int GetTolerance(int n)
        {
            return 0;
        }

        /// <summary>
        /// Sets tolerance of n - th element
        /// </summary>
        /// <param name="n">Element number</param>
        /// <param name="tolerance">Tolerance to set</param>
        public void SetTolerance(int n, int tolerance)
        {
        }

        /// <summary>
        /// Weight of n - th element
        /// </summary>
        /// <param name="n">Element number</param>
        /// <returns>The weight</returns>
        public double GetWeight(int n)
        {
            return 1;
        }

        /// <summary>
        /// Dimension of data
        /// </summary>
        public int DataDimension
        {
            get
            {
                return data.Length;
            }
        }

        /// <summary>
        /// Aprior weight of n - th element
        /// </summary>
        /// <param name="n">Element number</param>
        /// <returns>The weight</returns>
        public double GetApriorWeight(int n)
        {
            return 0;
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Data array
        /// </summary>
        public double[] Array
        {
            set
            {
                Double a = 0;
                data = new double[value.Length];
                type = new ArrayReturnType(a, new int[]{value.Length}, false);
                for (int i = 0; i < value.Length; i++)
                {
                    data[i] = value[i];
                    //type[i] = 0;
                }
            }
        }

        /// <summary>
        /// Name of measure
        /// </summary>
        public string MeasureName
        {
            set
            {
                name = value;
            }
        }

        private object parameter()
        {
            return data;
        }

        #endregion
    }
}
