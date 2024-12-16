using System;
using System.Runtime.Serialization;

using AssemblyService.Attributes;
using Diagram.UI;

namespace AliasRegression
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    class StaticExtensionAliasRegression
    {
        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionAliasRegression()
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
                if (assemblyName.Contains("AliasRegression,"))
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
