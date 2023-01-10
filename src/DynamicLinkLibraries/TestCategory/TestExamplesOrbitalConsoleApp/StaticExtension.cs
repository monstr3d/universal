using DataPerformer.Portable;
using TestCategory.Standard;

namespace TestExamplesOrbitalConsoleApp
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
