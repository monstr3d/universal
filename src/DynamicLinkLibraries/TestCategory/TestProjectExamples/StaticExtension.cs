using DataPerformer.Portable;
using TestCategory;
using TestCategory.Standard;

namespace TestProjectExamples
{
    /// <summary>
    /// Static Extension
    /// </summary>
    internal static class StaticExtension
    {
        /// <summary>
        /// Constructor
        /// </summary>

        static StaticExtension()
        {
            StaticExtensionTestCategoryStandard.Init();
            DataPerformer.Portable.Runtime.DataRuntimeFactory.Singleton.SetBase();
        }

        /// <summary>
        /// Fact
        /// </summary>
        /// <param name="bytes">Byte array</param>
        internal static void Fact(this byte[] bytes)
        {
            Assert.True(bytes.Test().Item1);
        }
    }
}