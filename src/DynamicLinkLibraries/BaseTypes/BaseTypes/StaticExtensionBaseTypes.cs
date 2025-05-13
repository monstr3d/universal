using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

using BaseTypes.Interfaces;
using BaseTypes.Attributes;

using ErrorHandler;

namespace BaseTypes
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    public static class StaticExtensionBaseTypes
    {
        #region Fields

        static Performer Performer
        {
            get;
        } = new Performer();

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
        /// Gets size of x and y
        /// </summary>
        /// <param name="x">The x</param>
        /// <param name="y">The y</param>
        /// <returns>The size</returns>
        public static double[,] GetSize(this double[,] x, double[,] y)
        {
            if (x == null)
            {
                if (y != null)
                {
                    return y;
                }
                return null;
            }
            var d = new double[2, x.GetLength(1)];
            for (var i = 0; i < d.GetLength(1); i++)
            {
                d[0, i] = Math.Min(x[0, i], y[0, i]);
                d[1, i] = Math.Max(x[1, i], y[1, i]);
            }
            return d;
        }

        /// <summary>
        /// Conversion of array to sting list
        /// </summary>
        /// <param name="x">The array</param>
        /// <returns>The string list</returns>
        public static List<string> ToStringList(this double[,] x)
        {
            var l = new List<string>();
            if (x == null)
            {
                return l;
            }
            l.Add("{");
            for (var i = 0; i < x.GetLength(0); i++)
            {
                var s = "\t{";
                for (var j = 0; j < x.GetLength(1); j++)
                {
                    if (j > 0)
                    {
                        s += ", ";
                    }
                    s += x[i, j].ToString();
                }
                s += " }";
                if (i < x.GetLength(0) - 1)
                {
                    s += ",";
                }
                l.Add(s);
            }
            l.Add("};");
            return l;
        }

        /// <summary>
        /// Nullable type converion
        /// </summary>
        /// <typeparam name="T">Conversion type</typeparam>
        /// <param name="obj">Converted object</param>
        /// <returns>Conversion result</returns>
        static public T? ToNullable<T>(this object obj) where T : struct
        {
            if (obj == null) return null;
            return (T)obj;
        }

        /// <summary>
        /// Nullable type converion
        /// </summary>
        /// <typeparam name="T">Conversion type</typeparam>
        /// <param name="obj">Converted object</param>
        /// <returns>Conversion result</returns>
        static public T ToNullableObject<T>(this object obj) where T : class
        {
            if (obj == null) return null;
            return obj as T;
        }


        /// <summary>
        /// Checks whether nullable condition is true
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <returns>The resulst</returns>
        static public bool IsTrue(this bool? condition)
        {
            if (condition == null) return false;
            return condition.Value;
        }

 
        /// <summary>
        /// Adds the action
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="addition">The addition</param>
        /// <returns>The sum of actions</returns>
        public static Action Add(this Action action, Action addition)
        {
            if (addition == null)
            {
                return action;
            }
            if (action == null)
            {
                return addition;
            }
            return action + addition;
        }

        /// <summary>
        /// Trasforms a collection of actions to the single action
        /// </summary>
        /// <param name="actions">The collection of action</param>
        /// <returns>The single</returns>
        static public Action ToSingleAction(this IEnumerable<Action> actions)
        {
            return Performer.ToSingleAction(actions);
        }

        /// <summary>
        /// Adds the action
        /// </summary>
        /// <typeparam name="T">Action type</typeparam>
        /// <param name="action">The action</param>
        /// <param name="addition">The addition</param>
        /// <returns>The sum of actions</returns>
        public static Action<T> Add<T>(this Action<T> action, Action<T> addition)
        {
            return Performer.Add<T>(action, addition);
        }


        /// <summary>
        /// Adds element to dictionary
        /// </summary>
        /// <typeparam name="T">Key type</typeparam>
        /// <typeparam name="S">Value type</typeparam>
        /// <param name="dictionary">Dictionary</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="unique">The "unique" sign</param>
        public static void Add<T, S>(this Dictionary<T, List<S>> dictionary, T key, S value, 
            bool unique = true)
        {
            Performer.Add<T, S>(dictionary, key, value, unique);
        }

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
            get => Performer.DateTime;
            set => Performer.DateTime = value;
        }

        /// <summary>
        /// Gets Double function
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Double value function</returns>
        public static Func<object, double> GetDoubleFunction(object type)
        {
            return Performer.GetDoubleFunction(type);
        }

  
        /// <summary>
        /// Object from string
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="type">Type</param>
        /// <returns>Object</returns>
        public static object FromStringBT(this string str, object type)
        {
            return Performer.FromStringBT(str, type);
        }
 
        /// <summary>
        /// Converts double variale
        /// </summary>
        /// <param name="type">Return type</param>
        /// <param name="x">The variable</param>
        /// <returns>Coversion result</returns>
        static public object Convert(this object type, double x)
        {
            return Performer.Convert(type, x);
        }

        /// <summary>
        /// Checks whether operation is powered
        /// </summary>
        /// <param name="operation">Operation</param>
        /// <returns>True if operation is powered and false otherwise</returns>
        public static bool IsPowered(this IObjectOperation operation)
        {
            return Performer.IsPowered(operation);
        }

        /// <summary>
        /// Gets string type
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Type</returns>
        public static object GetStringType(this string str)
        {
            return Performer.GetStringType(str);
        }

        /// <summary>
        /// Gets type string
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>String</returns>
        public static string GetTypeString(this object obj)
        {
            return Performer.GetTypeString(obj);
        }

        /// <summary>
        /// Converts strings to types
        /// </summary>
        /// <param name="strings">Strings</param>
        /// <returns>Types</returns>
        public static List<Tuple<string, object>> StringToTypes(this string[] strings)
        {
            return Performer.StringToTypes(strings);
        }

        /// <summary>
        /// Converts types to strings
        /// </summary>
        /// <param name="types">Types</param>
        /// <returns>Strings</returns>
        public static string[] TypesToStrings(this List<Tuple<string, object>> types)
        {
            return Performer.TypesToStrings(types);
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
        /// Converts day to date time
        /// </summary>
        /// <param name="a">Day</param>
        /// <returns>Date time</returns>
        public static DateTime DayToDateTime(this double a)
        {
            return Performer.DayToDateTime(a);
        }

        /// <summary>
        /// Converts day to date time
        /// </summary>
        /// <param name="dt">Date Time</param>
        /// <returns>Day</returns>
        public static double DateTimeToDay(this DateTime dt)
        {
            return Performer.DateTimeToDay(dt);
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


        /// <summary>
        /// Conversion
        /// </summary>
        /// <param name="timeType">Type of time</param>
        /// <param name="begin">Bebin</param>
        /// <param name="isAbsolute">Is absolute</param>
        /// <returns>value</returns>
        public static Func<DateTime, double> Convert(this TimeType timeType,
            DateTime begin, bool isAbsolute = true)
        {
            return Performer.Convert(timeType, begin, isAbsolute);
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
