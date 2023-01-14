using AssemblyService.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.TestInterface.UI
{
    [InitAssembly]
    public static class StaticExtensionDataPerformerTestInterfaceUI
    {
        static StaticExtensionDataPerformerTestInterfaceUI()
        {
            new TestCreator();
        }

        static public void Init()
        {

        }
    }
}
