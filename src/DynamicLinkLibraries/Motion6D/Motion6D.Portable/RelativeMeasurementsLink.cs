using System;
using System.Collections.Generic;
using System.Text;


using CategoryTheory;

using Motion6D.Interfaces;

namespace Motion6D.Portable
{
    /// <summary>
    /// Link for relative measurements
    /// </summary>
    public class RelativeMeasurementsLink : CategoryArrow,  IRemovableObject
    {

        #region Fields


        ICategoryObject source;

        ICategoryObject target;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RelativeMeasurementsLink()
        {

        }


        #endregion

        #region ICategoryArrow Members

        /// <summary>
        /// The source of this arrow
        /// </summary>
        public override ICategoryObject Source
        {
            get
            {
                return source;
            }
            set
            {
                source = GetObject(value);
            }
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        public override ICategoryObject Target
        {
            get
            {
                return target;
            }
            set
            {
                if (value is RelativeMeasurements)
                {
                    if (measurements != null)
                    {
                        throw new Exception("Measurements already exists");
                    }
                    target = value;
                    measurements.Source = source as IPosition;
                    return;
                }
                IPosition p = value.GetObject<IPosition>();
                if (p == null)
                {
                    throw new Exception("Illegal type");
                }
                target = value;
                measurements.Target = target.GetTarget<IPosition>();
            }
        }

        #endregion

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            if (measurements == source)
            {
                measurements.Target = null;
                return;
            }
            if (measurements != null)
            {
                measurements.Source = null;
            }
        }

        #endregion

        #region Specific Members

        private ICategoryObject GetObject(ICategoryObject obj)
        {
            if (obj is RelativeMeasurements)
            {
                return obj;
            }
            IPosition p = obj.GetObject<IPosition>();
            if (p != null)
            {
                return p as ICategoryObject;
            }
            throw new Exception("Illegal type");
        }

        RelativeMeasurements measurements
        {
            get
            {
                if (source != null)
                {
                    if (source is RelativeMeasurements)
                    {
                        return source as RelativeMeasurements;
                    }
                }
                if (target != null)
                {
                    if (target is RelativeMeasurements)
                    {
                        return target as RelativeMeasurements;
                    }
                }
                return null;
            }
        }

        #endregion
    }
}
