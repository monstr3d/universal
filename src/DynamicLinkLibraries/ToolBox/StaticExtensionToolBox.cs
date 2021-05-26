using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AssemblyService.Attributes;
using Diagram.UI;

namespace ToolBox
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionToolBox
    {
        static  StaticExtensionToolBox()
        {

        }
        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {
            new Binder();
        }

        class Binder : System.Runtime.Serialization.SerializationBinder
        {
            string assN = typeof(Binder).Assembly.FullName;
            internal Binder()
            {
                this.Add();
            }

            public override Type BindToType(string assemblyName, string typeName)
            {
                if (assemblyName.Contains("ToolBox"))
                {
                    return Type.GetType(String.Format("{0}, {1}",
                        typeName,
                        assN));
                }
                return null;
            }
        }
    }
}
