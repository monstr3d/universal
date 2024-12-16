using AssemblyService.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.TestInterface.UI
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDataPerformerTestInterfaceUI
    {
        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionDataPerformerTestInterfaceUI()
        {
            new TestCreator();
        }

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }
    }
}
