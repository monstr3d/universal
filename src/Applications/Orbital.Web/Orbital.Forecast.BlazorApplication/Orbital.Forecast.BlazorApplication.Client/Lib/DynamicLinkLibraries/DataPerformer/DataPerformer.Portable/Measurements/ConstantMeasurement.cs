using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPerformer.Interfaces;

namespace DataPerformer.Portable.Measurements
{
    /// <summary>
    /// Constant measurement
    /// </summary>
    public class ConstantMeasurement : IMeasurement, IDerivation
    {
        #region Fields

        /// <summary>
        /// Return object
        /// </summary>
        private object obj;

        /// <summary>
        /// Return type
        /// </summary>
        private object type;

        /// <summary>
        /// Double return type
        /// </summary>
        static private readonly Double a = 0;

        /// <summary>
        /// Measure parameter
        /// </summary>
        private Func<object> par;

        /// <summary>
        /// Name of measure
        /// </summary>
        private string name;

        /// <summary>
        /// zero
        /// </summary>
        public static readonly ConstantMeasurement Zero = new ConstantMeasurement();


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor of zero constant measure
        /// </summary>
        private ConstantMeasurement()
            : this(0)
        {

        }

        /// <summary>
        /// Constructor of double constant measure
        /// </summary>
        /// <param name="x">The double</param>
        public ConstantMeasurement(double x)
        {
            par = getPar;
            this.obj = x;
            this.type = a;
            name = "";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="obj">Rerurn object</param>
        /// <param name="type">Return type</param>
        /// <param name="name">Name of measure</param>
        public ConstantMeasurement(object obj, object type, string name)
        {
            par = getPar;
            this.obj = obj;
            this.type = type;
            this.name = name;
        }

        #endregion

        #region IMeasurement Members

        Func<object> IMeasurement.Parameter
        {
            get { return par; }
        }

        string IMeasurement.Name
        {
            get { return name; }
        }

        object IMeasurement.Type
        {
            get { return type; }
        }

        #endregion

        #region IDerivation Members

        IMeasurement IDerivation.Derivation
        {
            get { return Zero; }
        }

        #endregion

        #region Specific Members

        object getPar()
        {
            return obj;
        }


        #endregion
    }
}
