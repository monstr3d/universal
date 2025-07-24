using System;

using BaseTypes;
using BaseTypes.Interfaces;

using DataPerformer.Interfaces;

using Diagram.UI;

using NamedTree;

namespace DataPerformer.Portable.Measurements
{
    /// <summary>
    /// Measurement
    /// </summary>
    public class Measurement : IMeasurement, IAssociatedObject
    {


        /// <summary>
        /// Measurement parameter
        /// </summary>
        protected Func<object> parameter;


        /// <summary>
        /// Measurement name
        /// </summary>
        private string name;


        /// <summary>
        /// Type of parameter
        /// </summary>
        private object type;

        /// <summary>
        /// Double type
        /// </summary>
        private static readonly Double a = 0;

        /// <summary>
        /// Object
        /// </summary>
        private object obj;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of parameter</param>
        /// <param name="parameter">Measurement parameter</param>
        /// <param name="name">Measurement name</param>
        /// <param name="obj">Associated object</param>
        public Measurement(object type, Func<object> parameter, string name, object obj)
        {
            this.parameter = parameter;
            this.name = name;
            this.type = type;
            this.obj = obj;
        }

        /// <summary>
        /// Constructor of real measure
        /// </summary>
        /// <param name="parameter">Parameter</param>
        /// <param name="name">Name of measure</param>
        /// <param name="obj">Associated object</param>
        public Measurement(Func<object> parameter, string name, object obj)
            :
            this(a, parameter, name, obj)
        {

        }


        /// <summary>
        /// Parameter of measurement
        /// </summary>
        public Func<object> Parameter
        {
            get
            {
                return parameter;
            }
        }

        /// <summary>
        /// Type of parameter
        /// </summary>
        public object Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// The measurement name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// The associated object
        /// </summary>
        object IAssociatedObject.Object 
        { get => obj; set => obj = value; }

        /// <summary>
        /// Overriden ToString
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            return this.ToStringStatic();
        }

        /// <summary>
        /// Gets name of type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>Type name</returns>
        public static string GetTypeName(object type)
        {
            string str = "";
            object t = ArrayReturnType.GetBaseType(type);
            if (t is Double)
            {
                str = "Double";
            }
            if (t is Single)
            {
                str = "Single";
            }
            if (t is Boolean)
            {
                str = "Boolean";
            }
            if (t is Byte)
            {
                str = "Byte";
            }
            if (t is UInt16)
            {
                str = "UInt16";
            }
            if (t is UInt32)
            {
                str = "UInt32";
            }
            if (t is UInt64)
            {
                str = "UInt64";
            }
            if (t is SByte)
            {
                str = "SByte";
            }
            if (t is Int16)
            {
                str = "Int16";
            }
            if (t is Int32)
            {
                str = "Int32";
            }
            if (t is Int64)
            {
                str = "Int64";
            }
            if (t is string)
            {
                str = "String";
            }
            if (str.Length == 0)
            {
                if (t is Type)
                {
                    Type tt = t as Type;
                    str = tt.Name;
                }
            }
            if (type is ArrayReturnType)
            {
                str = PureDesktop.GetResourceString(str);
                ArrayReturnType art = type as ArrayReturnType;
                int[] n = art.Dimension;
                for (int i = n.Length - 1; i >= 0; i--)
                {
                    int k = n[i];
                    string ss = (k == -1) ? "?" : k + "";
                    str = str + "[" +ss + "]";
                }
                return str;
            }
            if (type is IOneVariableFunction)
            {
                IOneVariableFunction f = type as IOneVariableFunction;
                string s = GetTypeName(f.ReturnType) + " f(" + GetTypeName(f.VariableType) + ")";
                return s;
            }
            return PureDesktop.GetResourceString(str);
        }
    }
}
