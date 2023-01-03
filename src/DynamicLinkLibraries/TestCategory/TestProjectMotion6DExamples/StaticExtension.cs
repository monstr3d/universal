using Motion6D.Portable;
using TestCategory;
using TestCategory.Standard;

namespace TestProjectMotion6DExamples
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
            StaticExtensionMotion6DPortable.Init();
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
