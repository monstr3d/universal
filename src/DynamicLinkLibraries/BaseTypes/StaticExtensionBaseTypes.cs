using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Reflection;

using BaseTypes.Interfaces;
using BaseTypes.Attributes;

namespace BaseTypes
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    public static class StaticExtensionBaseTypes
    {
        #region Fields
        /// <summary>
        /// Object of char type
        /// </summary>
        public const Char CharType = (char)0;

        /// <summary>
        /// Object of sbyte type
        /// </summary>
        public const SByte SByteType = (sbyte)0;

        /// <summary>
        /// Object of short type
        /// </summary>
        public const Int16 Int16Type = (short)0;

        /// <summary>
        /// Object of int type
        /// </summary>
        public const Int32 Int32Type = (int)0;

        /// <summary>
        /// Object of long type
        /// </summary>
        public const Int64 Int64Type = (long)0;

        /// <summary>
        /// Object of byte type
        /// </summary>
        public const Byte ByteType = (byte)0;

        /// <summary>
        /// Object of ushort type
        /// </summary>
        public const UInt16 UInt16Type = (ushort)0;

        /// <summary>
        /// Object of uint type
        /// </summary>
        public const UInt32 UInt32Type = (uint)0;

        /// <summary>
        /// Object of ulong type
        /// </summary>
        public const UInt64 UInt64Type = (ulong)0;

        /// <summary>
        /// Object of bool type
        /// </summary>
        public const Boolean BooleanType = false;

        /// <summary>
        /// Object of double type
        /// </summary>
        public const Double DoubleType = 0;

        /// <summary>
        /// Object of single type
        /// </summary>
        public const Single SingleType = 0;

        /// <summary>
        /// Object of string type
        /// </summary>
        public const string StringType = "";

        /// <summary>
        /// Types of objects
        /// </summary>
        public static readonly object[] SimpleTypes = new object[]{ CharType, DoubleType, SingleType,
            BooleanType, ByteType, SByteType, UInt16Type, UInt32Type, UInt64Type,
		    Int16Type, Int32Type, Int64Type, StringType };

        public static readonly List<object> SimpleTypeList = new List<object>(SimpleTypes);


        private static Dictionary<Type, object> typeDictionary = new Dictionary<Type, object>();

        /// <summary>
        /// Names of types
        /// </summary>
        public static readonly string[] TypeNames = {"Char", "Double", "Single", "Boolean", "Byte",  "SByte", 
                                                       "UInt16Type", "UInt32Type", "UInt64Type",
			"Int16", "Int32", "Int64", "String"};



        /// <summary>
        /// Ticks of day
        /// </summary>
        public static readonly long DayTicks = (new TimeSpan(1, 0, 0, 0, 0)).Ticks;

        private static readonly Dictionary<object, Func<Func<object, double>>> toDouble = new Dictionary<object, Func<Func<object, double>>>()
        {
            {DoubleType, () => {return (object obj) => {return (double)obj;};}},
            {BooleanType, () => {return (object obj) => { bool b = (bool)obj; return b ? 1 : 0;};}},
            {ByteType, () => {return (object obj) => {return (double)((byte)obj);};}},
            {SByteType, () => {return (object obj) => {return (double)((sbyte)obj);};}},
            {UInt16Type, () => {return (object obj) => {return (double)((ushort)obj);};}},
            {Int16Type, () => {return (object obj) => {return (double)((short)obj);};}},
            {UInt32Type, () => {return (object obj) => {return (double)((uint)obj);};}},
            {Int32Type, () => {return (object obj) => {return (double)((int)obj);};}},
            {UInt64Type, () => {return (object obj) => {return (double)((ulong)obj);};}},
            {Int64Type, () => {return (object obj) => {return (double)((long)obj);};}}
        };
   
        #endregion

        #region Ctor

        static StaticExtensionBaseTypes()
        {
            DateTime = new DateTime((long)0, DateTimeKind.Utc);
            foreach (object o in SimpleTypes)
            {
                typeDictionary[o.GetType()] = o;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Transformation to operation type
        /// </summary>
        /// <param name="type">Thw type</param>
        /// <returns>The operation type</returns>
        public static object ToObjectType(this Type type)
        {
            if (typeDictionary.ContainsKey(type))
            {
                return typeDictionary[type];
            }
            return type;
        }

        /// <summary>
        /// Date time
        /// </summary>
        public static DateTime DateTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Double function
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Double value function</returns>
        public static Func<object, double> GetDoubleFunction(object type)
        {
            return IntertnalDouble.CreateFunction(type);
        }

  
        /// <summary>
        /// Object from string
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="type">Type</param>
        /// <returns>Object</returns>
        public static object FromStringBT(this string str, object type)
        {
            double a = 0;
            if (type.Equals(a))
            {
                return ParseDouble(str); 
            }
            return str;
        }

    
   

        /// <summary>
        /// Converts double variale
        /// </summary>
        /// <param name="type">Return type</param>
        /// <param name="x">The variable</param>
        /// <returns>Coversion result</returns>
        static public object Convert(this object type, double x)
        {
            if (type.Equals(DoubleType))
            {
                return x;
            }
            if (type.Equals(SingleType))
            {
                return (float)x;
            }
            if (type.Equals(BooleanType))
            {
                if (x == 0)
                {
                    return false;
                }
                if (x == 1)
                {
                    return true;
                }
                throw new Exception("Can not convert double parameter value to boolean");
            }
            if (type.Equals(SByteType))
            {
                return (sbyte)x;
            }
            if (type.Equals(Int16Type))
            {
                return (short)x;
            }
            if (type.Equals(Int32Type))
            {
                return (int)x;
            }
            if (type.Equals(Int64Type))
            {
                return (long)x;
            }
            if (type.Equals(ByteType))
            {
                return (byte)x;
            }
            if (type.Equals(UInt16Type))
            {
                return (ushort)x;
            }
            if (type.Equals(UInt32Type))
            {
                return (uint)x;
            }
            if (type.Equals(UInt64Type))
            {
                return (ulong)x;
            }
            throw new Exception("Type cannot be converted from double");
        }

        /// <summary>
        /// Checks whether operation is powered
        /// </summary>
        /// <param name="operation">Operation</param>
        /// <returns>True if operation is powered and false otherwise</returns>
        public static bool IsPowered(this IObjectOperation operation)
        {
            if (operation is IPowered)
            {
                IPowered p = operation as IPowered;
                return p.IsPowered;
            }
            return false;
        }

        /// <summary>
        /// Gets string type
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Type</returns>
        public static object GetStringType(this string str)
        {
            for (int i = 0; i < TypeNames.Length; i++)
            {
                if (TypeNames[i].Equals(str))
                {
                    return SimpleTypes[i];
                }
            }
            return 0;
        }

        /// <summary>
        /// Gets type string
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>String</returns>
        public static string GetTypeString(this object obj)
        {
            for (int i = 0; i < SimpleTypes.Length; i++)
            {
                if (SimpleTypes[i].Equals(obj))
                {
                    return TypeNames[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Converts strings to types
        /// </summary>
        /// <param name="strings">Strings</param>
        /// <returns>Types</returns>
        public static List<Tuple<string, object>> StringToTypes(this string[] strings)
        {
            List<Tuple<string, object>> types = new List<Tuple<string,object>>();
            for (int i = 0; i < strings.Length; i++)
            {
                string s = strings[i];
                ++i;
                object o = strings[i].GetStringType();
                types.Add(new Tuple<string, object>(s, o));
            }
            return types;
        }

        /// <summary>
        /// Converts types to strings
        /// </summary>
        /// <param name="types">Types</param>
        /// <returns>Strings</returns>
        public static string[] TypesToStrings(this List<Tuple<string, object>> types)
        {
            List<string> l = new List<string>();
            foreach (Tuple<string, object> t in types)
            {
                l.Add(t.Item1);
                l.Add(t.Item2.GetTypeString());
            }
            return l.ToArray();
        }

        /// <summary>
        /// Parses double
        /// </summary>
        /// <param name="str">String value</param>
        /// <returns>Double</returns>
        public static double ParseDouble(this string str)
        {
            return Double.Parse(str, CultureInfo.InvariantCulture); 
        }

        /// <summary>
        /// Gets object representation of type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>Object representation</returns>
        public static object GetObjectFromType(this Type type)
        {
            return FixedTypes.GetType(type);
        }

        /// <summary>
        /// Coverts day to date time
        /// </summary>
        /// <param name="a">Day</param>
        /// <returns>Date time</returns>
        public static DateTime DayToDateTime(this double a)
        {
            double x = a % 1;
            double y = a - x;
            DateTime dt = DateTime + new TimeSpan((long)(864000000000.0 * x)) + new TimeSpan((int)y, 0, 0, 0);
            return DateTime.SpecifyKind(dt, DateTimeKind.Utc);
        }

        /// <summary>
        /// Coverts day to date time
        /// </summary>
        /// <param name="dt">Date Time</param>
        /// <returns>Day</returns>
        public static double DateTimeToDay(this DateTime dt)
        {
            TimeSpan ts = dt - DateTime;
            return ts.TotalDays;
        }

        /// Gets default value of object
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Default value</returns>
        public static string GetDefaultStringValue(this object obj)
        {
            DefaultValueAttribute attr = obj.GetAttributeBT<DefaultValueAttribute>();
            if (attr == null)
            {
                return null;
            }
            return attr.DefaultValue;
        }

        /// <summary>
        /// Hash Set Attribute
        /// <summary>
        /// Checks whether object has attribute
        /// </summary>
        /// <typeparam name="T">Attribute type</typeparam>
        /// <param name="obj">The object</param>
        /// <returns>True if object has attribute</returns>
        public static bool HasAttributeBT<T>(this object obj) where T : Attribute
        {
            return obj.GetAttributeBT<T>() != null;
        }


        /// <summary>
        /// Checks whether object is fiction
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsFiction(this object obj)
        {
            return HasAttributeBT<FictionAttribute>(obj);
        }

        /// Checks whether object is constant
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>True if constant and false otherwise</returns>
        public static bool IsConst(this object obj)
        {
            return obj.GetAttributeBT<ConstantObjectAttribute>() != null;
        }

        /// Checks whether object is empty
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>True if empty and false otherwise</returns>
        public static bool IsEmpty(this object obj)
        {
            return obj.GetAttributeBT<EmptyAttribute>() != null;
         }

        /// <summary>
        /// Converts object to type info
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        public static TypeInfo ToTypeInfoBT(this object ob)
        {
            return IntrospectionExtensions.GetTypeInfo(ob.GetType());
        }

        /// <summary>
        /// Gets attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T GetAttributeBT<T>(this object obj) where T : Attribute
        {
            return CustomAttributeExtensions.GetCustomAttribute<T>(obj.ToTypeInfoBT());
        }


        /// <summary>
        /// Gets physical types
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Types</returns>
        public static PhysicalUnitTypeAttribute GetPhysicalType(this object obj)
        {
            if (obj is IPhysicalUnitTypeAttribute)
            {
                return (obj as IPhysicalUnitTypeAttribute).PhysicalUnitTypeAttribute;
            }
            return obj.GetAttributeBT<PhysicalUnitTypeAttribute>();
        }

        /// <summary>
        /// Converts from one unit to another one
        /// </summary>
        /// <typeparam name="T">Variable type</typeparam>
        /// <param name="source">From type</param>
        /// <param name="target">To type</param>
        /// <param name="value">Input value</param>
        /// <returns>Conversion result</returns>
        public static double Convert<T>(this T source, T target, double value)
        {
            Dictionary<T, double> d = dCoefficients[typeof(T)] as Dictionary<T, double>;
            double kFrom = d[source];
            double kTo = d[target];
            return (value * kTo) / kFrom;
        }



        /// <summary>
        /// Coefficient of physical unit
        /// </summary>
        /// <typeparam name="T">From</typeparam>
        /// <param name="source">From unit</param>
        /// <param name="target">To unit</param>
        /// <returns>Coefficient</returns>
        public static double Coefficient<T>(this T source, T target)
        {
            Dictionary<T, double> d = dCoefficients[typeof(T)] as Dictionary<T, double>;
            double kFrom = d[source];
            double kTo = d[target];
            return kTo / kFrom;
        }


        /// <summary>
        /// Gets coefficients
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="target">Target</param>
        /// <param name="dictionary">Physical unit dictionary</param>
        /// <returns>Coefficient</returns>
        public static double Coefficient(this PhysicalUnitTypeAttribute source,
            PhysicalUnitTypeAttribute target, Dictionary<Type, int> dictionary)
        {
            if (dictionary == null)
            {
                return 1;
            }
            double a = 1;
            Dictionary<Type, PropertyInfo> p = PhysicalUnitTypeAttribute.Properties;
            foreach (Type t in dictionary.Keys)
            {
                Func<object, object, double> f = functions[t];
                PropertyInfo pi = p[t];
                object from = pi.GetValue(source);
                object to = pi.GetValue(target);
                double k = f(from, to);
                if (k == 1)
                {
                    continue;
                }
                int m = dictionary[t];
                if (m < 0)
                {
                    m = -m;
                    k = 1.0 / k;
                }
                for (int i = 0; i < m; i++)
                {
                    a *= k;
                }
            }
            return a;
        }

        /// <summary>
        /// Converts angle to radian
        /// </summary>
        /// <param name="attribute">Physical Unit Type</param>
        /// <param name="angle">Angle</param>
        /// <returns>Radians</returns>
        public static double ToRadians(this PhysicalUnitTypeAttribute attribute, double angle)
        {
            return angle * Coefficient<AngleType>(attribute.AngleType, AngleType.Radian);
        }

        /// <summary>
        /// Coefficient of physical unit
        /// </summary>
        /// <param name="from">From unit</param>
        /// <param name="to">To unit</param>
        /// <returns>Coefficient</returns>
        public static double Coefficient(this TimeType from, TimeType to)
        {
            return Coefficient<TimeType>(from, to);
        }



        #endregion

        #region Private Members
        #region Private Members

        /// <summary>
        /// Dictionaries which contain coefficients
        /// </summary>
        private static readonly Dictionary<Type, object> dCoefficients = new Dictionary<Type, object>()
        {
           {typeof(AngleType),   new Dictionary<AngleType, double>()
            {
                {AngleType.Radian, 1},
                {AngleType.Degree, 180 / Math.PI},
                {AngleType.Circle, 2 * Math.PI}
            }
            },
           {typeof(LengthType),    new Dictionary<LengthType, double>()
            {
                {LengthType.Meter, 1},
                {LengthType.Kilometer, 1000},
                {LengthType.Centimeter, 0.01}
            }
           },
           {typeof(MassType),   new Dictionary<MassType, double>()
            {
                {MassType.Kilogram, 1},
                {MassType.Gram, 0.001}
            }
           },
           {typeof(TimeType),   new Dictionary<TimeType, double>()
            {
                {TimeType.Day, 1},
                {TimeType.Second, 86400}
            }
            }
       };

        private static readonly Type[] unitTypes = new Type[]
        {
            typeof(AngleType),  typeof(LengthType),  typeof(MassType),  typeof(TimeType)
        };

        /// <summary>
        /// Coefficient functions
        /// </summary>
        private static readonly Dictionary<Type, Func<object, object, double>> functions = new Dictionary<Type, Func<object, object, double>>()
        {
             {typeof(AngleType), (object a, object b) =>
                 { return Coefficient((AngleType)a, (AngleType)b);} },
             {typeof(LengthType), (object a, object b) =>
                 { return Coefficient((LengthType)a, (LengthType)b);} },
             {typeof(MassType), (object a, object b) =>
                 { return Coefficient((MassType)a, (MassType)b);} },
             {typeof(TimeType), (object a, object b) =>
                 { return Coefficient((TimeType)a, (TimeType)b);} }
        };


        #endregion


        #endregion

    }
}
