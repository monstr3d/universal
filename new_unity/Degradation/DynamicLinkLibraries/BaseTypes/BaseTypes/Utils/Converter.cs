using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes.Utils
{
    /// <summary>
    /// Converter of numeric objects
    /// </summary>
    public static class Converter
    {
        /*  public static Func<object, object> GetFunction<T,S>()
          {
              Func<object, T> f = Transform<T>
          }*/

        /// <summary>
        /// Conversion
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>The function</returns>
        static public Func<object, T> Transform<T>()
        {
            return (object o) =>
            {
                return (T)o;
            };
        }

      
        /// <summary>
        /// Conversion of numeric parameters
        /// </summary>
        /// <param name="input">Type of input</param>
        /// <param name="output">Type of output</param>
        /// <returns>Conversion function</returns>
        public static Func<object, object> Convert(this object input, object output)
        {
            if (input.Equals(output))
            {
                return (object o) => { return o; };
            }
            if (input is sbyte)
            {
                return ConvertSByte(output);
            }
            if (input is byte)
            {
                return ConvertByte(output);
            }
            if (input is short)
            {
                return ConvertShort(output);
            }
            if (input is ushort)
            {
                return ConvertUShort(output);
            }
            if (input is int)
            {
                return ConvertInt(output);
            }
            if (input is uint)
            {
                return ConvertUInt(output);
            }
            if (input is long)
            {
                return ConvertLong(output);
            }
            if (input is ulong)
            {
                return ConvertULong(output);
            }
            if (input is float)
            {
                return ConvertFloat(output);
            }
            if (input is double)
            {
                return ConvertDouble(output);
            }
            return null;
        }

        /// <summary>
        /// Converts object to byte
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>Conversion resule</returns>
        public static byte ToByte(object o)
        {
            if (o is Double)
            {
                double b = (double)o;
                return (byte)b;
            }
            if (o is Byte)
            {
                byte b = (byte)o;
                return b;
            }
            if (o is UInt16)
            {
                ushort b = (ushort)o;
                return (byte)b;
            }
            if (o is UInt32)
            {
                uint b = (uint)o;
                return (byte)b;
            }
            if (o is UInt64)
            {
                ulong b = (ulong)o;
                return (byte)b;
            }
            if (o is SByte)
            {
                sbyte b = (sbyte)o;
                return (byte)b;
            }
            if (o is Int16)
            {
                short b = (short)o;
                return (byte)b;
            }
            if (o is Int32)
            {
                int b = (int)o;
                return (byte)b;
            }
            if (o is Int64)
            {
                long b = (long)o;
                return (byte)b;
            }
            return 0;
        }

        /// <summary>
        /// Converts object to ushort
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>Conversion result</returns>
        public static ushort ToUInt16(object o)
        {
            if (o is Double)
            {
                double b = (double)o;
                return (ushort)b;
            }
            if (o is Byte)
            {
                byte b = (byte)o;
                return (ushort)b;
            }
            if (o is UInt16)
            {
                ushort b = (ushort)o;
                return b;
            }
            if (o is UInt32)
            {
                uint b = (uint)o;
                return (ushort)b;
            }
            if (o is UInt64)
            {
                ulong b = (ulong)o;
                return (ushort)b;
            }
            if (o is SByte)
            {
                sbyte b = (sbyte)o;
                return (ushort)b;
            }
            if (o is Int16)
            {
                short b = (short)o;
                return (ushort)b;
            }
            if (o is Int32)
            {
                int b = (int)o;
                return (ushort)b;
            }
            if (o is Int64)
            {
                long b = (long)o;
                return (ushort)b;
            }
            return 0;
        }


        /// <summary>
        /// Converts object to uint
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>Conversion result</returns>
        public static uint ToUInt32(object o)
        {
            if (o is Double)
            {
                double b = (double)o;
                return (uint)b;
            }
            if (o is Byte)
            {
                byte b = (byte)o;
                return (uint)b;
            }
            if (o is UInt16)
            {
                ushort b = (ushort)o;
                return (uint)b;
            }
            if (o is UInt32)
            {
                uint b = (uint)o;
                return b;
            }
            if (o is UInt64)
            {
                ulong b = (ulong)o;
                return (uint)b;
            }
            if (o is SByte)
            {
                sbyte b = (sbyte)o;
                return (uint)b;
            }
            if (o is Int16)
            {
                short b = (short)o;
                return (uint)b;
            }
            if (o is Int32)
            {
                int b = (int)o;
                return (uint)b;
            }
            if (o is Int64)
            {
                long b = (long)o;
                return (uint)b;
            }
            return 0;
        }

        /// <summary>
        /// Converts object to ulong
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>Conversion result</returns>
        public static ulong ToUInt64(object o)
        {
            if (o is Double)
            {
                double b = (double)o;
                return (ulong)b;
            }
            if (o is Byte)
            {
                byte b = (byte)o;
                return (ulong)b;
            }
            if (o is UInt16)
            {
                ushort b = (ushort)o;
                return (ulong)b;
            }
            if (o is UInt32)
            {
                uint b = (uint)o;
                return (ulong)b;
            }
            if (o is UInt64)
            {
                ulong b = (ulong)o;
                return b;
            }
            if (o is SByte)
            {
                sbyte b = (sbyte)o;
                return (ulong)b;
            }
            if (o is Int16)
            {
                short b = (short)o;
                return (ulong)b;
            }
            if (o is Int32)
            {
                int b = (int)o;
                return (ulong)b;
            }
            if (o is Int64)
            {
                long b = (long)o;
                return (ulong)b;
            }
            return 0;
        }

        /// <summary>
        /// Converts object to sbyte
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>Conversion result</returns>
        public static sbyte ToSByte(object o)
        {
            if (o is Double)
            {
                double b = (double)o;
                return (sbyte)b;
            }
            if (o is Byte)
            {
                byte b = (byte)o;
                return (sbyte)b;
            }
            if (o is UInt16)
            {
                ushort b = (ushort)o;
                return (sbyte)b;
            }
            if (o is UInt32)
            {
                uint b = (uint)o;
                return (sbyte)b;
            }
            if (o is UInt64)
            {
                ulong b = (ulong)o;
                return (sbyte)b;
            }
            if (o is SByte)
            {
                sbyte b = (sbyte)o;
                return b;
            }
            if (o is Int16)
            {
                short b = (short)o;
                return (sbyte)b;
            }
            if (o is Int32)
            {
                int b = (int)o;
                return (sbyte)b;
            }
            if (o is Int64)
            {
                long b = (long)o;
                return (sbyte)b;
            }
            return 0;
        }

        /// <summary>
        /// Converts object to short
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>Conversion result</returns>
        public static short ToInt16(object o)
        {
            if (o is Double)
            {
                double b = (double)o;
                return (short)b;
            }
            if (o is Byte)
            {
                byte b = (byte)o;
                return (short)b;
            }
            if (o is UInt16)
            {
                ushort b = (ushort)o;
                return (short)b;
            }
            if (o is UInt32)
            {
                uint b = (uint)o;
                return (short)b;
            }
            if (o is UInt64)
            {
                ulong b = (ulong)o;
                return (short)b;
            }
            if (o is SByte)
            {
                sbyte b = (sbyte)o;
                return (short)b;
            }
            if (o is Int16)
            {
                short b = (short)o;
                return b;
            }
            if (o is Int32)
            {
                int b = (int)o;
                return (short)b;
            }
            if (o is Int64)
            {
                long b = (long)o;
                return (short)b;
            }
            return 0;
        }

        /// <summary>
        /// Converts object to int
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>Conversion result</returns>
        public static int ToInt32(object o)
        {
            if (o is Double)
            {
                double b = (double)o;
                return (int)b;
            }
            if (o is Byte)
            {
                byte b = (byte)o;
                return (int)b;
            }
            if (o is UInt16)
            {
                ushort b = (ushort)o;
                return (int)b;
            }
            if (o is UInt32)
            {
                uint b = (uint)o;
                return (int)b;
            }
            if (o is UInt64)
            {
                ulong b = (ulong)o;
                return (int)b;
            }
            if (o is SByte)
            {
                sbyte b = (sbyte)o;
                return (int)b;
            }
            if (o is Int16)
            {
                short b = (short)o;
                return (int)b;
            }
            if (o is Int32)
            {
                int b = (int)o;
                return b;
            }
            if (o is Int64)
            {
                long b = (long)o;
                return (int)b;
            }
            return 0;
        }

        /// <summary>
        /// Converts object to long
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>Conversion result</returns>
        public static long ToInt64(object o)
        {
            if (o is Double)
            {
                double b = (double)o;
                return (long)b;
            }
            if (o is Byte)
            {
                byte b = (byte)o;
                return (long)b;
            }
            if (o is UInt16)
            {
                ushort b = (ushort)o;
                return (long)b;
            }
            if (o is UInt32)
            {
                uint b = (uint)o;
                return (long)b;
            }
            if (o is UInt64)
            {
                ulong b = (ulong)o;
                return (long)b;
            }
            if (o is SByte)
            {
                sbyte b = (sbyte)o;
                return (long)b;
            }
            if (o is Int16)
            {
                short b = (short)o;
                return (long)b;
            }
            if (o is Int32)
            {
                int b = (int)o;
                return (long)b;
            }
            if (o is Int64)
            {
                long b = (long)o;
                return b;
            }
            return 0;
        }

        /// <summary>
        /// Converts object to double
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>Conversion result</returns>
        public static double? ToNullDouble(this object o)
        {
            if (o == null)
            {
                return null;
            } 
            return o.ToDouble();
        }



        /// <summary>
        /// Converts object to double
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>Conversion result</returns>
        public static double ToDouble(this object o)
        {
            if (o is decimal)
            {
                decimal dec = (decimal)o;
                return Double.Parse(dec + "");
            }
            if (o is Double)
            {
                double b = (double)o;
                return b;
            }
            if (o is Byte)
            {
                byte b = (byte)o;
                return (double)b;
            }
            if (o is UInt16)
            {
                ushort b = (ushort)o;
                return (double)b;
            }
            if (o is UInt32)
            {
                uint b = (uint)o;
                return (double)b;
            }
            if (o is UInt64)
            {
                ulong b = (ulong)o;
                return (double)b;
            }
            if (o is SByte)
            {
                sbyte b = (sbyte)o;
                return (double)b;
            }
            if (o is Int16)
            {
                short b = (short)o;
                return (double)b;
            }
            if (o is Int32)
            {
                int b = (int)o;
                return (double)b;
            }
            if (o is Int64)
            {
                long b = (long)o;
                return (double)b;
            }
            if (o is Boolean)
            {
                bool b = (bool)o;
                return b ? 1 : 0;
            }
            if (o is Single)
            {
                float f = (float)o;
                return (double)f;
            }
            return 0;
        }

        #region Private Members

        #region Converter Functions

        static Func<object, object> ConvertFloat(object output)
        {
            Func<object, float> f = Transform<float>();
            if (output is float)
            {
                return (object o) =>
                {
                    return (float)f(o);
                };
            }
            if (output is double)
            {
                return (object o) =>
                {
                    return (double)f(o);
                };
            }
            if (output is sbyte)
            {
                return (object o) =>
                {
                    return (sbyte)f(o);
                };
            }
            if (output is byte)
            {
                return (object o) =>
                {
                    return (byte)f(o);
                };
            }
            if (output is ushort)
            {
                return (object o) =>
                {
                    return (ushort)f(o);
                };
            }
            if (output is short)
            {
                return (object o) =>
                {
                    return (short)f(o);
                };
            }
            if (output is uint)
            {
                return (object o) =>
                {
                    return (uint)f(o);
                };
            }
            if (output is int)
            {
                return (object o) =>
                {
                    return (int)f(o);
                };
            }
            if (output is long)
            {
                return (object o) =>
                {
                    return (long)f(o);
                };
            }
            if (output is ulong)
            {
                return (object o) =>
                {
                    return (ulong)f(o);
                };
            }
            return null;
        }

        static Func<object, object> ConvertDouble(object output)
        {
            Func<object, double> f = Transform<double>();
            if (output is float)
            {
                return (object o) =>
                {
                    return (float)f(o);
                };
            }
            if (output is double)
            {
                return (object o) =>
                {
                    return (double)f(o);
                };
            }
            if (output is sbyte)
            {
                return (object o) =>
                {
                    return (sbyte)f(o);
                };
            }
            if (output is byte)
            {
                return (object o) =>
                {
                    return (byte)f(o);
                };
            }
            if (output is ushort)
            {
                return (object o) =>
                {
                    return (ushort)f(o);
                };
            }
            if (output is short)
            {
                return (object o) =>
                {
                    return (short)f(o);
                };
            }
            if (output is uint)
            {
                return (object o) =>
                {
                    return (uint)f(o);
                };
            }
            if (output is int)
            {
                return (object o) =>
                {
                    return (int)f(o);
                };
            }
            if (output is long)
            {
                return (object o) =>
                {
                    return (long)f(o);
                };
            }
            if (output is ulong)
            {
                return (object o) =>
                {
                    return (ulong)f(o);
                };
            }
            return null;
        }

        static Func<object, object> ConvertByte(object output)
        {
            Func<object, byte> f = Transform<byte>();
            if (output is float)
            {
                return (object o) =>
                {
                    return (float)f(o);
                };
            }
            if (output is double)
            {
                return (object o) =>
                {
                    return (double)f(o);
                };
            }
            if (output is sbyte)
            {
                return (object o) =>
                {
                    return (sbyte)f(o);
                };
            }
            if (output is byte)
            {
                return (object o) =>
                {
                    return (byte)f(o);
                };
            }
            if (output is ushort)
            {
                return (object o) =>
                {
                    return (ushort)f(o);
                };
            }
            if (output is short)
            {
                return (object o) =>
                {
                    return (short)f(o);
                };
            }
            if (output is uint)
            {
                return (object o) =>
                {
                    return (uint)f(o);
                };
            }
            if (output is int)
            {
                return (object o) =>
                {
                    return (int)f(o);
                };
            }
            if (output is long)
            {
                return (object o) =>
                {
                    return (long)f(o);
                };
            }
            if (output is ulong)
            {
                return (object o) =>
                {
                    return (ulong)f(o);
                };
            }
            return null;
        }

        static Func<object, object> ConvertSByte(object output)
        {
            Func<object, sbyte> f = Transform<sbyte>();
            if (output is float)
            {
                return (object o) =>
                {
                    return (float)f(o);
                };
            }
            if (output is double)
            {
                return (object o) =>
                {
                    return (double)f(o);
                };
            }
            if (output is sbyte)
            {
                return (object o) =>
                {
                    return (sbyte)f(o);
                };
            }
            if (output is byte)
            {
                return (object o) =>
                {
                    return (byte)f(o);
                };
            }
            if (output is ushort)
            {
                return (object o) =>
                {
                    return (ushort)f(o);
                };
            }
            if (output is short)
            {
                return (object o) =>
                {
                    return (short)f(o);
                };
            }
            if (output is uint)
            {
                return (object o) =>
                {
                    return (uint)f(o);
                };
            }
            if (output is int)
            {
                return (object o) =>
                {
                    return (int)f(o);
                };
            }
            if (output is long)
            {
                return (object o) =>
                {
                    return (long)f(o);
                };
            }
            if (output is ulong)
            {
                return (object o) =>
                {
                    return (ulong)f(o);
                };
            }
            return null;
        }

        static Func<object, object> ConvertShort(object output)
        {
            Func<object, short> f = Transform<short>();
            if (output is float)
            {
                return (object o) =>
                {
                    return (float)f(o);
                };
            }
            if (output is double)
            {
                return (object o) =>
                {
                    return (double)f(o);
                };
            }
            if (output is sbyte)
            {
                return (object o) =>
                {
                    return (sbyte)f(o);
                };
            }
            if (output is byte)
            {
                return (object o) =>
                {
                    return (byte)f(o);
                };
            }
            if (output is ushort)
            {
                return (object o) =>
                {
                    return (ushort)f(o);
                };
            }
            if (output is short)
            {
                return (object o) =>
                {
                    return (short)f(o);
                };
            }
            if (output is uint)
            {
                return (object o) =>
                {
                    return (uint)f(o);
                };
            }
            if (output is int)
            {
                return (object o) =>
                {
                    return (int)f(o);
                };
            }
            if (output is long)
            {
                return (object o) =>
                {
                    return (long)f(o);
                };
            }
            if (output is ulong)
            {
                return (object o) =>
                {
                    return (ulong)f(o);
                };
            }
            return null;
        }

        static Func<object, object> ConvertUShort(object output)
        {
            Func<object, ushort> f = Transform<ushort>();
            if (output is float)
            {
                return (object o) =>
                {
                    return (float)f(o);
                };
            }
            if (output is double)
            {
                return (object o) =>
                {
                    return (double)f(o);
                };
            }
            if (output is sbyte)
            {
                return (object o) =>
                {
                    return (sbyte)f(o);
                };
            }
            if (output is byte)
            {
                return (object o) =>
                {
                    return (byte)f(o);
                };
            }
            if (output is ushort)
            {
                return (object o) =>
                {
                    return (ushort)f(o);
                };
            }
            if (output is short)
            {
                return (object o) =>
                {
                    return (short)f(o);
                };
            }
            if (output is uint)
            {
                return (object o) =>
                {
                    return (uint)f(o);
                };
            }
            if (output is int)
            {
                return (object o) =>
                {
                    return (int)f(o);
                };
            }
            if (output is long)
            {
                return (object o) =>
                {
                    return (long)f(o);
                };
            }
            if (output is ulong)
            {
                return (object o) =>
                {
                    return (ulong)f(o);
                };
            }
            return null;
        }

        static Func<object, object> ConvertInt(object output)
        {
            Func<object, int> f = Transform<int>();
            if (output is float)
            {
                return (object o) =>
                {
                    return (float)f(o);
                };
            }
            if (output is double)
            {
                return (object o) =>
                {
                    return (double)f(o);
                };
            }
            if (output is sbyte)
            {
                return (object o) =>
                {
                    return (sbyte)f(o);
                };
            }
            if (output is byte)
            {
                return (object o) =>
                {
                    return (byte)f(o);
                };
            }
            if (output is ushort)
            {
                return (object o) =>
                {
                    return (ushort)f(o);
                };
            }
            if (output is short)
            {
                return (object o) =>
                {
                    return (short)f(o);
                };
            }
            if (output is uint)
            {
                return (object o) =>
                {
                    return (uint)f(o);
                };
            }
            if (output is int)
            {
                return (object o) =>
                {
                    return (int)f(o);
                };
            }
            if (output is long)
            {
                return (object o) =>
                {
                    return (long)f(o);
                };
            }
            if (output is ulong)
            {
                return (object o) =>
                {
                    return (ulong)f(o);
                };
            }
            return null;
        }

        static Func<object, object> ConvertUInt(object output)
        {
            Func<object, uint> f = Transform<uint>();
            if (output is float)
            {
                return (object o) =>
                {
                    return (float)f(o);
                };
            }
            if (output is double)
            {
                return (object o) =>
                {
                    return (double)f(o);
                };
            }
            if (output is sbyte)
            {
                return (object o) =>
                {
                    return (sbyte)f(o);
                };
            }
            if (output is byte)
            {
                return (object o) =>
                {
                    return (byte)f(o);
                };
            }
            if (output is ushort)
            {
                return (object o) =>
                {
                    return (ushort)f(o);
                };
            }
            if (output is short)
            {
                return (object o) =>
                {
                    return (short)f(o);
                };
            }
            if (output is uint)
            {
                return (object o) =>
                {
                    return (uint)f(o);
                };
            }
            if (output is int)
            {
                return (object o) =>
                {
                    return (int)f(o);
                };
            }
            if (output is long)
            {
                return (object o) =>
                {
                    return (long)f(o);
                };
            }
            if (output is ulong)
            {
                return (object o) =>
                {
                    return (ulong)f(o);
                };
            }
            return null;
        }

        static Func<object, object> ConvertLong(object output)
        {
            Func<object, long> f = Transform<long>();
            if (output is float)
            {
                return (object o) =>
                {
                    return (float)f(o);
                };
            }
            if (output is double)
            {
                return (object o) =>
                {
                    return (double)f(o);
                };
            }
            if (output is sbyte)
            {
                return (object o) =>
                {
                    return (sbyte)f(o);
                };
            }
            if (output is byte)
            {
                return (object o) =>
                {
                    return (byte)f(o);
                };
            }
            if (output is ushort)
            {
                return (object o) =>
                {
                    return (ushort)f(o);
                };
            }
            if (output is short)
            {
                return (object o) =>
                {
                    return (short)f(o);
                };
            }
            if (output is uint)
            {
                return (object o) =>
                {
                    return (uint)f(o);
                };
            }
            if (output is int)
            {
                return (object o) =>
                {
                    return (int)f(o);
                };
            }
            if (output is long)
            {
                return (object o) =>
                {
                    return (long)f(o);
                };
            }
            if (output is ulong)
            {
                return (object o) =>
                {
                    return (ulong)f(o);
                };
            }
            return null;
        }

        static Func<object, object> ConvertULong(object output)
        {
            Func<object, ulong> f = Transform<ulong>();
            if (output is float)
            {
                return (object o) =>
                {
                    return (float)f(o);
                };
            }
            if (output is double)
            {
                return (object o) =>
                {
                    return (double)f(o);
                };
            }
            if (output is sbyte)
            {
                return (object o) =>
                {
                    return (sbyte)f(o);
                };
            }
            if (output is byte)
            {
                return (object o) =>
                {
                    return (byte)f(o);
                };
            }
            if (output is ushort)
            {
                return (object o) =>
                {
                    return (ushort)f(o);
                };
            }
            if (output is short)
            {
                return (object o) =>
                {
                    return (short)f(o);
                };
            }
            if (output is uint)
            {
                return (object o) =>
                {
                    return (uint)f(o);
                };
            }
            if (output is int)
            {
                return (object o) =>
                {
                    return (int)f(o);
                };
            }
            if (output is long)
            {
                return (object o) =>
                {
                    return (long)f(o);
                };
            }
            if (output is ulong)
            {
                return (object o) =>
                {
                    return (ulong)f(o);
                };
            }
            return null;
        }



        #endregion

        #endregion

    }
}
