using AssemblyService.Attributes;

using CompilerService.Interfaces;

using FormulaEditor.Compiler;

namespace CompilerBridge
{
    /// <summary>
    /// Static Extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionComplerBridge
    {
        /// <summary>
        /// Constructor
        /// </summary>
        static  StaticExtensionComplerBridge()
        {
            ICompiler c =  new CodeAnalysis.Compilers.CSharpCompiler();
            StaticExtensionFormulaEditorCompiler.Compiler = c;
        }

        /// <summary>
        /// Initialize itself
        /// </summary>
        /// <param name="attr">Initialization attribute</param>
        static public void Init(InitAssemblyAttribute attr)
        {

        }
    }
}
