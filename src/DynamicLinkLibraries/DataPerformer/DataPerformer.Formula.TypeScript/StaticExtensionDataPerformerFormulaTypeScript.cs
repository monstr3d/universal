using AssemblyService.Attributes;

namespace DataPerformer.Formula.TypeScript
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDataPerformerFormulaTypeScript
    {
        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionDataPerformerFormulaTypeScript()
        {
            new TSCodeCreator();
        }

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }


    }
}
