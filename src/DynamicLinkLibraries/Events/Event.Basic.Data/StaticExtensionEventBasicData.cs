using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI;

using Event.Interfaces;

namespace Event.Basic.Data
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [CategoryTheory.InitAssembly]
    public static class StaticExtensionEventBasicData
    {
        /// <summary>
        /// Inits itself
        /// </summary>
        public static void Init()
        {

        }

        static StaticExtensionEventBasicData()
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
                if (assemblyName.Contains("Event.Basic.Data"))
                {
                    if (tn.Contains("LogListHolder"))
                    {
                        ass = typeof(LogHolder).Assembly.FullName;
                        tn = tn.Replace("LogListHolder", "LogHolder");
                    }
                }
                Type t = Type.GetType(string.Format("{0}, {1}", tn, ass));
                return t;
            }
        }

    }
}
