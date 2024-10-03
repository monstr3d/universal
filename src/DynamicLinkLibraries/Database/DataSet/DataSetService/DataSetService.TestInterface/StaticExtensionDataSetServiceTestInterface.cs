using AssemblyService.Attributes;

namespace DataSetService.TestInterface
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDataSetServiceTestInterface
    {
        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionDataSetServiceTestInterface()
        {
            new TestCreator();
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }
    }
}
