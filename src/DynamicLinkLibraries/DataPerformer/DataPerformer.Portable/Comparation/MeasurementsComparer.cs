using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPerformer.Interfaces;

namespace DataPerformer.Portable.Comparation
{
    /// <summary>
    /// Comparer of measurements
    /// </summary>
    public class MeasurementsComparer : IComparer<IMeasurements>, IComparer<IStarted>
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public readonly static MeasurementsComparer Singleton = new MeasurementsComparer();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected MeasurementsComparer()
        {
        }

        #endregion

        #region IComparer<IMeasurements> Members

        int IComparer<IMeasurements>.Compare(IMeasurements x, IMeasurements y)
        {
            if (x == y)
            {
                return 0;
            }
            if (x is IDataConsumer dcx)
            {
                if (IsSource(dcx, y))
                {
                    return 1;
                }
            }
            if (y is IDataConsumer dcy)
            {
                if (IsSource(dcy, x))
                {
                    return -1;
                }
            }
            return 0;
        }

        #endregion

        #region IComparer<IStarted> Members

        int IComparer<IStarted>.Compare(IStarted x, IStarted y)
        {
            if ((x is IMeasurements) & (y is IMeasurements))
            {
                IComparer<IMeasurements> c = this;
                return c.Compare(x as IMeasurements, y as IMeasurements);
            }
            return 0;
        }

        #endregion

        /// <summary>
        /// Sorts started objects
        /// </summary>
        /// <param name="started">Started objects</param>
        public static void Sort(List<IStarted> started)
        {
            started.Sort(Singleton);
        }


        #region Protected

        /// <summary>
        /// The "is source" detector
        /// </summary>
        /// <param name="dc">Data consumer</param>
        /// <param name="m">Measurements</param>
        /// <returns>True is "measuements" is source of "data consumer"</returns>
        protected virtual bool IsSource(IDataConsumer dc, IMeasurements m)
        {
            int count = dc.Count;
            for (int i = 0; i < count; i++)
            {
                IMeasurements x = dc[i];
                if (m == x)
                {
                    return true;
                }
                if (x is IDataConsumer)
                {
                    if (IsSource(x as IDataConsumer, m))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

    }
}
