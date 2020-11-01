using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPerformer.Interfaces;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Multidimensional dynamical parameter
    /// </summary>
    public class DynamicalParameter
    {
        #region Fields

        /// <summary>
        /// Strig of parameters labels
        /// </summary>
        protected string labels = "";

        /// <summary>
        /// List of parameters
        /// </summary>
        protected List<IMeasurement> parameters = new List<IMeasurement>();

        /// <summary>
        /// Error message of undefined parameter
        /// </summary>
        public static readonly string UndefinedParameter = "Undefined parameter";

        /// <summary>
        /// Error message of undefined parameters
        /// </summary>
        public static readonly string UndefinedParameters = "Undefined parameters";

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public DynamicalParameter()
        {
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Adds measurement
        /// </summary>
        /// <param name="c">Measurement label</param>
        /// <param name="m">Measurement</param>
        public void Add(char c, IMeasurement m)
        {
            if (labels.IndexOf(c) >= 0)
            {
                throw new Exception("Double parameter '" + c + "'");
            }
            labels += c;
            parameters.Add(m);
        }

        /// <summary>
        /// Replaces measure
        /// </summary>
        /// <param name="c">Letter of measure</param>
        /// <param name="measure">New value of measure</param>
        public void Replace(char c, IMeasurement measure)
        {
            int k = labels.IndexOf(c);
            List<IMeasurement> p = new List<IMeasurement>();
            for (int i = 0; i < k; i++)
            {
                p.Add(parameters[i]);
            }
            p.Add(measure);
            for (int i = k; i < parameters.Count; i++)
            {
                p.Add(parameters[i]);
            }
            parameters = p;
            p = null;
        }

        /// <summary>
        /// Gets measurement
        /// </summary>
        public IMeasurement this[char c]
        {
            get
            {
                int n = labels.IndexOf(c);
                if (n < 0)
                {
                    throw new Exception(UndefinedParameter);
                }
                return parameters[n] as IMeasurement;
            }
        }

        /// <summary>
        /// String of parameter variables
        /// </summary>
        public string Variables
        {
            get
            {
                return labels;
            }
        }

        #endregion
    }
}
