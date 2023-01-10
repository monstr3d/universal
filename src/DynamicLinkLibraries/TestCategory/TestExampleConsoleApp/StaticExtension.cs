using DataPerformer.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCategory.Standard;

namespace TestExampleConsoleApp
{
    internal class StaticExtension
    {
        static StaticExtension()
        {
            StaticExtensionTestCategoryStandard.Init();
            StaticExtensionDataPerformerPortable.Init();
        }

        internal static void Init()
        {

        }

    }
}
