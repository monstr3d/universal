using DataPerformer.Portable;
using TestCategory.Standard;

namespace TestExamplesBitmapConsoleApp
{
    internal static class StaticExtension
    {
        static StaticExtension()
        {
            StaticExtensionTestCategoryStandard.Init();
            StaticExtensionDataPerformerPortable.Init();

            //  DataPerformer.Portable.Runtime.DataRuntimeFactory.Singleton.SetBase();
        }

        internal static void Init()
        {

        }

    }
}
