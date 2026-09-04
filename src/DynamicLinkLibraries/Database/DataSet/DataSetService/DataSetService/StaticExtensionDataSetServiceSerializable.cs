using AssemblyService.Attributes;
using Diagram.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace DataSetService
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDataSetServiceSerializable
    {
        static string assName = "";

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionDataSetServiceSerializable()
        {
            var b = new Binder();
            assName = b.GetType().Assembly.FullName;
        }

        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }


        class Binder : SerializationBinder
        {
            internal Binder()
            {
                this.Add();
            }

            public override Type BindToType(string assemblyName, string typeName)
            {
                if (typeName.Contains("DataSetService."))
                {
                    try
                    {
                        var fullName = string.Format("{0}, {1}", typeName, assemblyName);
                        var t = Type.GetType(fullName);
                        if (t != null)
                        {
                            return t;
                        }

                    }
                    catch (Exception)
                    {

                    }
                    try
                    {
                        
                        var tn = typeName.Replace("DataSetService", "DataSetService.Pure");
                        var an = assemblyName;
                        if (an.Contains("DataSetService") & !an.Contains("DataSetService.Pure"))
                        {
                          an =   an.Replace("DataSetService", "DataSetService.Pure");
                        }
                        tn = tn.Replace("DataSetService.Pure.", "DataSetService.Pure.Interfaces.");
                        var fullName = string.Format("{0}, {1}", tn, an);
                        var t = Type.GetType(fullName);
                        if (t != null)
                        {
                            return t;
                        }

                    }
                    catch (Exception)
                    {

                    }

                }
                return null;
            }
        }
    }
}