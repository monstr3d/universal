using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataPerformer.Interfaces;

using Motion6D.Interfaces;

namespace Motion6D.Portable.Comparation
{
    /// <summary>
    /// Comparer of measurements
    /// </summary>
    public class MeasurementsComparer : 
        DataPerformer.Portable.Comparation.MeasurementsComparer
    {
        #region Fields

        Diagram.UI.Performer p = new ();

        /// <summary>
        /// Singleton
        /// </summary>
        public readonly new static MeasurementsComparer Singleton = new MeasurementsComparer();

        List<IDataConsumer> l = new List<IDataConsumer>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected MeasurementsComparer()
        {
        }

        #endregion

        #region Overriden

        /// <summary>
        /// The "is source" detector
        /// </summary>
        /// <param name="dc">Data consumer</param>
        /// <param name="m">Measurements</param>
        /// <returns>True is "measuements" is source of "data consumer"</returns>
        protected override bool IsSource(IDataConsumer dc, IMeasurements m)
        {
            l.Clear();
            return IsSourcePrivate(dc, m);
        }

        #endregion

        #region Private

        private  bool IsSourcePrivate(IDataConsumer dc, IMeasurements m)
        {
            if (l.Contains(dc))
            {
                return false;
            }
            l.Add(dc);
            if (dc == null)
            {
                return false;
            }
            int count = dc.Count;
            for (int i = 0; i < count; i++)
            {
                IMeasurements x = dc[i];
                if (x is RelativeMeasurements)
                {
                    RelativeMeasurements rm = x as RelativeMeasurements;
                    IPosition[] positions = new IPosition[] { rm.Source, rm.Target };
                    foreach (IPosition position in positions)
                    {
                        if (position == null)
                        {
                            continue;
                        }
                        List<IPosition> path = p.GetPath(position).ToList();
                        foreach (IPosition pos in path)
                        {
                            if (pos != dc)
                            {
                                if (IsSource(pos, m))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                if (m == x)
                {
                    return true;
                }
                if (x is IDataConsumer)
                {
                    if (x != dc)
                    {
                        if (IsSourcePrivate(x as IDataConsumer, m))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        bool IsSource(IPosition position, IMeasurements m)
        {
            if (position is IDataConsumer)
            {
                bool b = IsSourcePrivate(position as IDataConsumer, m);
                if (b)
                {
                    return true;
                }
            }
            IPosition parent = position.Parent;
            if (parent != null)
            {
                return IsSource(parent, m);
            }
            return false;
        }

        #endregion

    }
}
