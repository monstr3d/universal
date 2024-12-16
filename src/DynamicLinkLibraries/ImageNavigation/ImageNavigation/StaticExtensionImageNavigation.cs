using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AssemblyService.Attributes;
using CategoryTheory;
using Diagram.UI;

namespace ImgeNavigation
{
    [InitAssembly]
    public static class StaticExtensionImageNavigation
    {
        #region Public Members

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        #endregion


        #region Private

        static StaticExtensionImageNavigation()
        {
            new Binder();
        }

        #endregion

        class Binder : SerializationBinder
        {

            internal Binder()
            {
                this.Add();
            }
            public override Type BindToType(string assemblyName, string typeName)
            {
                if (assemblyName.Contains("ImageNavigation") | assemblyName.Contains("ImgeNavigation"))
                {
                    var a = typeof(Binder).Assembly.FullName;
                    var type = Type.GetType(String.Format("{0}, {1}",
                        typeName, a));
                    return type ?? null; 
                }
                return null;
            }
        }
    }
}
