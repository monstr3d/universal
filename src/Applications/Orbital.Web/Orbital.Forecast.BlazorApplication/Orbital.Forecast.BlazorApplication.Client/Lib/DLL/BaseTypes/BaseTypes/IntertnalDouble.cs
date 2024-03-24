using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTypes
{
    class IntertnalDouble
    {
        private Func<object, double> f = null;
        private IntertnalDouble(object type)
        {
            if (type.Equals(StaticExtensionBaseTypes.DoubleType))
            {
                f = (object obj) => { return (double)obj; };
            }
            if (type.Equals(StaticExtensionBaseTypes.BooleanType))
            {
                f = (object obj) => { bool b = (bool)obj; return b ? 1 : 0;};
            }
            if (type.Equals(StaticExtensionBaseTypes.SByteType))
            {
                f = (object obj) => { return (double)((sbyte)obj); };
            }
            if (type.Equals(StaticExtensionBaseTypes.Int16Type))
            {
                f = (object obj) => { return (double)((short)obj); };
            }
            if (type.Equals(StaticExtensionBaseTypes.Int32Type))
            {
                f = (object obj) => { return (double)((int)obj); };
            }
            if (type.Equals(StaticExtensionBaseTypes.Int64Type))
            {
                f = (object obj) => { return (double)((long)obj); };
            }
            if (type.Equals(StaticExtensionBaseTypes.ByteType))
            {
                f = (object obj) => { return (double)((byte)obj); };
            }
            if (type.Equals(StaticExtensionBaseTypes.UInt16Type))
            {
                f = (object obj) => { return (double)((ushort)obj); };
            }
            if (type.Equals(StaticExtensionBaseTypes.UInt32Type))
            {
                f = (object obj) => { return (double)((uint)obj); };
            }
            if (type.Equals(StaticExtensionBaseTypes.UInt64Type))
            {
                f = (object obj) => { return (double)((ulong)obj); };
            }
        }

        static internal Func<object, double> CreateFunction(object type)
        {
            return (new IntertnalDouble(type)).f;
        }
    }
}
