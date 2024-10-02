using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using BaseTypes.Attributes;
using BaseTypes.Interfaces;

namespace BaseTypes
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    public static class StaticExtensionBaseTypesExtended
    {


        #region Public Members

        /// <summary>
        /// Binder
        /// </summary>
        public static readonly System.Runtime.Serialization.SerializationBinder Binder = new Binders();

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

        #endregion

 
        class Binders : System.Runtime.Serialization.SerializationBinder
        {
            static readonly Dictionary<string, string> ass = new Dictionary<string, string>()
        {
            {"BaseTypes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", typeof(StaticExtensionBaseTypesExtended).Assembly.FullName}
        };
            internal Binders()
            {
              
            }
      //      readonly string[] types = new string[] { "DataPerformerBase", "DataPerformer.Base" };
            public override Type BindToType(string assemblyName, string typeName)
            {
                foreach (string key in ass.Keys)
                {
                    if (assemblyName.Contains(key))
                    {
                        return Type.GetType(String.Format("{0}, {1}",
                            typeName,
                            ass[key]));
                    }
                }
                return null;
            }
        }


    }
}
