using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyService.Attributes;
using CategoryTheory;

using Event.Interfaces;

namespace Zip.Service
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionZipService
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
        static StaticExtensionZipService()
        {
            ZipListLoader.Singleton.AddListLoader();
         //!!! LOG   StaticExtensionEventInterfaces.LogFactory = new ZipLog();
        }

    }
}
