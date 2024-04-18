using AssemblyService.Attributes;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WindowsExtensions;

namespace DataPerformer.WebGenerator
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionWebGenerators
    {
        static StaticExtensionWebGenerators()
        {
            new Generator();
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

  
    }
}
