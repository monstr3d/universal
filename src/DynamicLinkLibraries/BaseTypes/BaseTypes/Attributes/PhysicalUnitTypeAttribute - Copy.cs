using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace BaseTypes.Attributes
{
 
    /// <summary>
    /// Attribute of physical parameters
    /// </summary>
    public class PhysicalUnitTypeAttribute : Attribute
    {

        #region Fields

        static internal readonly Dictionary<Type, PropertyInfo> Properties =
            new Dictionary<Type, PropertyInfo>();


        /// <summary>
        /// Type of angle
        /// </summary>
        protected AngleType angleUnit;

        /// <summary>
        /// Type of length
        /// </summary>
        protected LengthType lengthUnit;

        /// <summary>
        /// Type of time
        /// </summary>
        protected TimeType timeUnit;

        /// <summary>
        /// Type of mass
        /// </summary>
        protected MassType massUnit;
 
        private event Action change = () => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="angleType">Type of angle</param>
        /// <param name="lengthType">Type of length</param>
        /// <param name="timeType">Type of time</param>
        /// <param name="massType">Type of mass</param>
        public PhysicalUnitTypeAttribute(AngleType angleType = AngleType.Radian,
            LengthType lengthType = LengthType.Meter,
            TimeType timeType = TimeType.Second,
            MassType massType = MassType.Kilogram)
        {
            this.angleUnit = angleType;
            this.lengthUnit = lengthType;
            this.timeUnit = timeType;
            this.massUnit = massType;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PhysicalUnitTypeAttribute()
        {
            angleUnit = AngleType.Radian;
            lengthUnit = LengthType.Meter;
            timeUnit = TimeType.Second;
            massUnit = MassType.Kilogram;
        }

   
        /// <summary>
        /// Constructor
        /// </summary>
        static PhysicalUnitTypeAttribute()
        {
            TypeInfo ti = IntrospectionExtensions.GetTypeInfo(typeof(PhysicalUnitTypeAttribute));
            IEnumerable<PropertyInfo> pi = ti.DeclaredProperties;
            foreach (PropertyInfo i in pi)
            {
                Type t = i.PropertyType;
                if (!t.Equals(typeof(object)))
                {
                    Properties[i.PropertyType] = i;
                }
            }
        }

  
        #endregion

 
        #region Public

        /// <summary>
        /// Change event
        /// </summary>
        public event Action Change
        {
            add { change += value; }
            remove { change -= value; }
        }


        /// <summary>
        /// Type of angle
        /// </summary>
        public AngleType AngleType
        {
            get
            {
                return angleUnit;
            }
            set
            {
                angleUnit = value;
                change();
            }
        }

        /// <summary>
        /// Type of length
        /// </summary>
        public LengthType LengthType
        {
            get
            {
                return lengthUnit;
            }
            set
            {
                lengthUnit = value;
                change();
            }
        }

        /// <summary>
        /// Type of time
        /// </summary>
        public TimeType TimeType
        {
            get
            {
                return timeUnit;
            }
            set
            {
                timeUnit = value;
                change();
            }
        }

        /// <summary>
        /// Type of mass
        /// </summary>
        public MassType MassType
        {
            get
            {
                return massUnit;
            }
            set
            {
                massUnit = value;
                change();
            }
        }

        #endregion

    }

    #region Enums

    /// <summary>
    /// Types of angle
    /// </summary>
    public enum AngleType
    {
        Radian, // Radian
        Circle, // Circle
        Degree  // Degree
    }

    /// <summary>
    /// Types of length
    /// </summary>
    public enum LengthType
    {
        Meter,      // Meter
        Centimeter, // Centimeter
        Kilometer   // Kilometer
    }

    /// <summary>
    /// Types of time
    /// </summary>
    public enum TimeType
    {
        Second, // Second
        Day     // Day
    }

    /// <summary>
    /// Types of mass
    /// </summary>
    public enum MassType
    {
        Kilogram,   // Kilogram
        Gram        // Gram
    }
 
    #endregion
}
