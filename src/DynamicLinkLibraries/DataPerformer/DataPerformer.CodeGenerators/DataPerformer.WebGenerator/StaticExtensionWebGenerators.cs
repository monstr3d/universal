using AssemblyService.Attributes;

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
