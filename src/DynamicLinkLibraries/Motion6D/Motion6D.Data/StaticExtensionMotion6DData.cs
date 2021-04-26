using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Diagram.UI;


namespace Motion6D
{
    /// <summary>
    /// Extension of methods
    /// </summary>
    [CategoryTheory.InitAssembly]
    public static class StaticExtensionMotion6DData
    {

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        static StaticExtensionMotion6DData()
        {
            new Binder();
        }



        class Binder : System.Runtime.Serialization.SerializationBinder
        {
            static readonly Dictionary<string, string> ass = new Dictionary<string, string>()
        {
            {"Motion6D", typeof(Binder).Assembly.FullName}
        };

            internal Binder()
            {
                this.Add();
            }
            public override Type BindToType(string assemblyName, string typeName)
            {
                foreach (string key in ass.Keys)
                {
                    if (assemblyName.Contains(key))
                    {
                        Type t = Type.GetType(String.Format("{0}, {1}",
                            typeName,
                            ass[key]));
                        if (t != null)
                        {
                            return t;
                        }
                    }
                }
                return null;
            }
        }




    }
}
