using AssemblyService.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Portable.TypeScript
{
    [InitAssembly]
    public static class StaticExtensionDataPerformerPortableTypeScript
    {
        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionDataPerformerPortableTypeScript()
        {
            new TSCodeCreator();
        }

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

    }
}
