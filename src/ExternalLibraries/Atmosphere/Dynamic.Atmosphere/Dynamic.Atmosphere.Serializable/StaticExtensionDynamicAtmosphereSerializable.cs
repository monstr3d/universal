using AssemblyService.Attributes;
using Diagram.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic.Atmosphere.Serializable
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDynamicAtmosphereSerializable
    {
        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionDynamicAtmosphereSerializable()
        {
            new Binder();
        }

        class Binder : SerializationBinder
        {
            internal Binder()
            {
                this.Add();
            }

            public override Type BindToType(string assemblyName, string typeName)
            {
                string ass = assemblyName;
                string tn = typeName;
                if (assemblyName.Contains("Dynamic.Atmosphere.Serializable,"))
                {
                    var a = typeof(Binder).Assembly.FullName;
                    Type type = Type.GetType(string.Format("{0}, {1}", tn, a));
                    if (type != null)
                    {
                        return type;
                    }
                }
                return null;
            }
        }


    }
}
