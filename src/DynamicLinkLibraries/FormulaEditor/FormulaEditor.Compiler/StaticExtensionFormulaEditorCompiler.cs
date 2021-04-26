using CategoryTheory;

namespace FormulaEditor.Compiler
{   
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionFormulaEditorCompiler
    {
        /// <summary>
        /// Initialization
        /// </summary>
        public static void Init()
        {

        }
        static StaticExtensionFormulaEditorCompiler()
        {
            CSharpTreeCollectionProxyFactory f = new CSharpTreeCollectionProxyFactory();
            StaticExtensionFormulaEditor.Factory = f;
            StaticExtensionFormulaEditor.TreeCollectionCodeCreator = f;
        }
    }
}
