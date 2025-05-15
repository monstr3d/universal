using System;
using System.Collections.Generic;
using System.Globalization;

using BaseTypes.Attributes;
using BaseTypes.Interfaces;

using ErrorHandler;


namespace BaseTypes
{
    public class Performer
    {

        #region Fields


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
                 { return StaticExtensionBaseTypes.Coefficient((AngleType)a, (AngleType)b);} },
             {typeof(LengthType), (object a, object b) =>
                 { return  StaticExtensionBaseTypes.Coefficient((LengthType)a, (LengthType)b);} },
             {typeof(MassType), (object a, object b) =>
                 { return  StaticExtensionBaseTypes.Coefficient((MassType)a, (MassType)b);} },
             {typeof(TimeType), (object a, object b) =>
                 { return  StaticExtensionBaseTypes.Coefficient((TimeType)a, (TimeType)b);} }
        };



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

        /// <summary>
        /// Gets Double function
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Double value function</returns>
        public Func<object, double> GetDoubleFunction(object type)
        {
            return IntertnalDouble.CreateFunction(type);
        }

        /// <summary>
        /// Object from string
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="type">Type</param>
        /// <returns>Object</returns>
        public  object FromStringBT(string str, object type)
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
        public object Convert(object type, double x)
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
                throw new OwnException("Can not convert double parameter value to boolean");
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
            throw new OwnException("Type cannot be converted from double");
        }

        /// <summary>
        /// Converts from one unit to another one
        /// </summary>
        /// <typeparam name="T">Variable type</typeparam>
        /// <param name="source">From type</param>
        /// <param name="target">To type</param>
        /// <param name="value">Input value</param>
        /// <returns>Conversion result</returns>
        public  double Convert<T>(T source, T target, double value)
        {
            Dictionary<T, double> d = dCoefficients[typeof(T)] as Dictionary<T, double>;
            double kFrom = d[source];
            double kTo = d[target];
            return (value * kTo) / kFrom;
        }


        /// <summary>
        /// Checks whether operation is powered
        /// </summary>
        /// <param name="operation">Operation</param>
        /// <returns>True if operation is powered and false otherwise</returns>
        public bool IsPowered(IObjectOperation operation)
        {
            if (operation is IPowered p)
            {
                return p.IsPowered;
            }
            return false;
        }

        /// <summary>
        /// Gets string type
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Type</returns>
        public  object GetStringType(string str)
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
        public  string GetTypeString(object obj)
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
        public  List<Tuple<string, object>> StringToTypes(string[] strings)
        {
            List<Tuple<string, object>> types = new List<Tuple<string, object>>();
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
        public  string[] TypesToStrings(List<Tuple<string, object>> types)
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
        public double ParseDouble(string str)
        {
            return double.Parse(str, CultureInfo.InvariantCulture);
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
        public void Add<T, S>( Dictionary<T, List<S>> dictionary, T key, S value,
            bool unique = true)
        {
            List<S> l;
            if (dictionary.ContainsKey(key))
            {
                l = dictionary[key];
            }
            else
            {
                l = new List<S>();
                dictionary[key] = l;
            }
            if (!unique)
            {
                l.Add(value);
                return;
            }
            if (!l.Contains(value))
            {
                l.Add(value);
            }
        }


        /// <summary>
        /// Adds the action
        /// </summary>
        /// <typeparam name="T">Action type</typeparam>
        /// <param name="action">The action</param>
        /// <param name="addition">The addition</param>
        /// <returns>The sum of actions</returns>
        public Action<T> Add<T>(Action<T> action, Action<T> addition)
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
        /// Conversion
        /// </summary>
        /// <param name="timeType">Type of time</param>
        /// <param name="begin">Bebin</param>
        /// <param name="isAbsolute">Is absolute</param>
        /// <returns>value</returns>
        public Func<DateTime, double> Convert(TimeType timeType, 
            DateTime begin, bool isAbsolute = true)
        {
            if (timeType.Equals(TimeType.Day))
            {
                if (!isAbsolute)
                {
                    return (Dt) => (Dt - begin).TotalDays;
                }
                else
                {
                    return (Dt) => DateTimeToDay(Dt);
                }
            }
            double coeff = TimeType.Day.Coefficient<TimeType>(timeType);
            if (!isAbsolute)
            {
                return (Dt) => coeff * (Dt - begin).TotalDays;
            }
            return (Dt) => coeff * DateTimeToDay(Dt);
        }

        /// <summary>
        /// Conversion
        /// </summary>
        /// <param name="timeType">Type of time</param>
        /// <param name="begin">Bebin</param>
        /// <param name="isAbsolute">Is absolute</param>
        /// <returns>value</returns>
        public Func<double, DateTime> ConvertInvert(TimeType timeType,
            double begin, bool isAbsolute = true)
        {
            if (timeType.Equals(TimeType.Day))
            {
                if (!isAbsolute)
                {
                    return (Dt) => DayToDateTime((Dt - begin));
                }
                else
                {
                    return (Dt) => DayToDateTime(Dt);
                }
            }
            double coeff = TimeType.Day.Coefficient<TimeType>(timeType);
            var c = 1 / coeff;
            if (!isAbsolute)
            {
                return (Dt) => DayToDateTime(c * (Dt - begin));
            }
            return (Dt)  => DayToDateTime(c * Dt);
        }


        /// <summary>
        /// Trasforms a collection of actions to the single action
        /// </summary>
        /// <param name="actions">The collection of action</param>
        /// <returns>The single</returns>
        public Action ToSingleAction(IEnumerable<Action> actions)
        {
            Action action = null;
            foreach (var act in actions)
            {
                if (act == null)
                {
                    continue;
                }
                action = (action == null) ? act : action + act;
            }
            return action;
        }


        /// <summary>
        /// Date time
        /// </summary>
        public DateTime DateTime
        {
            get;
            set;
        }

        /// <summary>
        /// Converts day to date time
        /// </summary>
        /// <param name="a">Day</param>
        /// <returns>Date time</returns>
        public DateTime DayToDateTime(double a)
        {
            double x = a % 1;
            double y = a - x;
            DateTime dt = DateTime + new TimeSpan((long)(864000000000.0 * x)) + new TimeSpan((int)y, 0, 0, 0);
            return DateTime.SpecifyKind(dt, DateTimeKind.Utc);
        }

        /// <summary>
        /// Converts day to date time
        /// </summary>
        /// <param name="dt">Date Time</param>
        /// <returns>Day</returns>
        public double DateTimeToDay(DateTime dt)
        {
            TimeSpan ts = dt - DateTime;
            return ts.TotalDays;
        }


    }
}
