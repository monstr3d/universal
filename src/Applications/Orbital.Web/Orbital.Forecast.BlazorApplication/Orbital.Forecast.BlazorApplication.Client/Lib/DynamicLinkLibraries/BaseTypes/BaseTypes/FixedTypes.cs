using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes
{
    /// <summary>
    /// Fixed types
    /// </summary>
    public static class FixedTypes
    {

        #region Fields

        #region Public
        /// <summary>
        /// Double type
        /// </summary>
        public const Double Double = 0;

        /// <summary>
        /// Single type
        /// </summary>
        public const Single Single = 0;

        /// <summary>
        /// Byte type
        /// </summary>
        public const Byte Byte = 0;

        /// <summary>
        /// SByte type
        /// </summary>
        public const SByte SByte = 0;

        /// <summary>
        /// String type
        /// </summary>
        public const string String = "";

        /// <summary>
        /// Int16 type
        /// </summary>
        public const Int16 Int16 = 0;

        /// <summary>
        /// UInt16 type
        /// </summary>
        public const UInt16 UInt16 = 0;

        /// <summary>
        /// Int32 type
        /// </summary>
        public const Int32 Int32 = 0;

        /// <summary>
        /// UInt32 type
        /// </summary>
        public const UInt32 UInt32 = 0;

        /// <summary>
        /// Int64 type
        /// </summary>
        public const Int64 Int64 = 0;

        /// <summary>
        /// UInt64 type
        /// </summary>
        public const UInt64 UInt64 = 0;

        /// <summary>
        /// Boolean type
        /// </summary>
        public const Boolean Boolean = false;



        /// <summary>
        /// Zero time
        /// </summary>
        public static readonly DateTime DateTimeType = new DateTime((long)0, DateTimeKind.Utc);


      //  private

        #endregion

        #region Private

        /// <summary>
        /// Diñtionary of types
        /// </summary>
        private static Dictionary<Type, object> dtypes;

        private static Dictionary<object, string> shortNames;

        private static Dictionary<EnumType, object> eTypes;

        private static Dictionary<object, EnumType> tEnum = new Dictionary<object,EnumType>();


        #endregion

        #endregion

        #region Public Members


        /// <summary>
        /// DateTime
        /// </summary>
       // public static DateTime DateTime 



        /// <summary>
        /// Gets short name of object type
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The name</returns>
        public static string GetShortTypeName(this object obj)
        {
            return shortNames[obj];
        }

        /// <summary>
        /// Short names
        /// </summary>
        public static Dictionary<object, string> ShortNames
        {
            get
            {
                return shortNames;
            }
        }

        /// <summary>
        /// Coversion to type
        /// </summary>
        /// <param name="obj">The type</param>
        /// <returns>The  enum</returns>
        public static EnumType ToEnumType(this object obj)
        {
            return tEnum[obj];
        }

        /// <summary>
        /// Coverts enum to type
        /// </summary>
        /// <param name="en">Enum</param>
        /// <returns>Type</returns>
        public static object ToType(this EnumType en)
        {
            return eTypes[en];
        }

        /// <summary>
        /// Gets default value of object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>Default value</returns>
        static public object GetDefaultValue(this object obj)
        {
            if (shortNames.ContainsKey(obj))
            {
                return obj;
            }
            return null;
        }

        #endregion

        #region Non public members

        /// <summary>
        /// Gets object code of type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The objcet code type</returns>
        internal static object GetType(Type type)
        {
            if (dtypes.ContainsKey(type))
            {
                return dtypes[type];
            }
            return null;
        }

        /// <summary>
        /// Static initializer
        /// </summary>
        static FixedTypes()
        {
            dtypes = new Dictionary<Type, object>()
            {
                {typeof(Double), Double},
                {typeof(Single), Single},
                {typeof(Byte), Byte},
                {typeof(SByte), SByte},
                {typeof(String), String},
                {typeof(Int16), Int16},
                {typeof(UInt16), UInt16},
                {typeof(Int32), Int32},
                {typeof(UInt32), UInt32},
                {typeof(Int64), Int64},
                {typeof(UInt64), UInt64},
                {typeof(Boolean), Boolean},
               {typeof(DateTime), DateTimeType}
            };

            eTypes = new Dictionary<EnumType, object>()
            {
             {EnumType.Double, Double},
                {EnumType.Single, Single},
                {EnumType.Byte, Byte},
                {EnumType.SByte, SByte},
                {EnumType.String, String},
                {EnumType.Int16, Int16},
                {EnumType.UInt16, UInt16},
                {EnumType.Int32, Int32},
                {EnumType.UInt32, UInt32},
                {EnumType.Int64, Int64},
                {EnumType.UInt64, UInt64},
                {EnumType.Boolean, Boolean},
                {EnumType.DateTime, DateTimeType}
   
            };

            foreach (EnumType key in eTypes.Keys)
            {
                tEnum[eTypes[key]] = key;
            }

            shortNames = new Dictionary<object, string>()
            {
                {Double, "double"},
                {Single, "float"},
                {Byte, "byte"},
                {SByte, "sByte"},
                {String, "string"},
                {Int16, "short"},
                {UInt16, "ushort"},
                {Int32, "int"},
                {UInt32, "uint"},
                {Int64, "long"},
                {UInt64, "ulong"},
                {Boolean, "bool"},
               {DateTimeType, "DateTime"}
            };

        }

        #endregion

    }

 
}
