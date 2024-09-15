using AssemblyService.Attributes;

using CompilerService.Interfaces;

namespace FormulaEditor.Compiler
{   
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionFormulaEditorCompiler
    {
        /// <summary>
        /// Compiler
        /// </summary>
        static private ICompiler compiler;

        /// <summary>
        /// Compiler
        /// </summary>
        static public ICompiler Compiler
        {
            get => compiler;
            set => compiler = value;
        }

        /// <summary>
        /// Initialization
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {
  
        }

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionFormulaEditorCompiler()
        {
            StaticExtensionFormulaEditor.Init();
            CSharpTreeCollectionProxyFactory f = new CSharpTreeCollectionProxyFactory(null);
            StaticExtensionFormulaEditor.CreatorFactory = new CreatorOfCreator();
            StaticExtensionFormulaEditor.TreeCollectionCodeCreator = f;
        }
    }
}
