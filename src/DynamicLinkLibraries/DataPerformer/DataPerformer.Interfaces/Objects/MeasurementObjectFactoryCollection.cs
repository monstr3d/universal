using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Interfaces.Objects
{
    /// <summary>
    /// Collection of measure object factories
    /// </summary>
    public class MeasurementObjectFactoryCollection : IMeasurementObjectFactory
    {

        #region Fields

        List<IMeasurementObjectFactory> list = new List<IMeasurementObjectFactory>();

        #endregion

        #region IMeasureObjectFactory Members

        object IMeasurementObjectFactory.this[IMeasurement measure]
        {
            get
            {
                foreach (IMeasurementObjectFactory f in list)
                {
                    object o = f[measure];
                    if (o != null)
                    {
                        return o;
                    }
                }
                return null;
            }
        }

        object IMeasurementObjectFactory.this[string name, IMeasurement measure]
        {
            get
            {
                foreach (IMeasurementObjectFactory f in list)
                {
                    object o = f[name, measure];
                    if (o != null)
                    {
                        return o;
                    }
                }
                return null;
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Adds a factory
        /// </summary>
        /// <param name="factory">The factory for the addition</param>
        public void Add(IMeasurementObjectFactory factory)
        {
            list.Add(factory);
        }

        #endregion

    }
}
