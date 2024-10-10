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
        /// Zip interface
        /// </summary>
        static IZipInterface zipInterface;

        /// <summary>
        /// Zip interface
        /// </summary>
        public static IZipInterface ZipInterface
        {
            get => zipInterface;
            set
            {
                if (zipInterface != null)
                {
                    throw new InvalidOperationException();
                }
                zipInterface = value;
            }
        }
  

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {
        
        }

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionZipService()
        {
            ZipListLoader.Singleton.AddListLoader();
            StaticExtensionEventInterfaces.LogFactory = new ZipLog();
        }

    }
}
