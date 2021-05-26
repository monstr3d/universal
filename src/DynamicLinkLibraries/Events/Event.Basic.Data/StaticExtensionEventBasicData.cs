using System;
using System.Runtime.Serialization;
using AssemblyService.Attributes;
using CategoryTheory;

using Diagram.UI;

using Event.Interfaces;

namespace Event.Basic.Data
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionEventBasicData
    {
        /// <summary>
        /// Inits itself
        /// </summary>
        public static void Init()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
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
                if (assemblyName.Contains("Event.Basic.Data,"))
                {
                    var a = typeof(Binder).Assembly.FullName;
                    Type type = Type.GetType(string.Format("{0}, {1}", tn, a));
                    if (type != null)
                    {
                        return type;
                    }
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
