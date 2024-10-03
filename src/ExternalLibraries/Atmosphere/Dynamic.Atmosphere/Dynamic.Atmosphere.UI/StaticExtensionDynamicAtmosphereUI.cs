using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using AssemblyService.Attributes;

using CategoryTheory;

using Diagram.UI;

using Dynamic.Atmosphere.UI.Factory;

namespace Dynamic.Atmosphere.UI
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDynamicAtmosphereUI
    {
        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        static StaticExtensionDynamicAtmosphereUI()
        {
            (new UIFactory()).Add();
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
                if (assemblyName.Contains("Dynamic.Atmosphere.UI,"))
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
