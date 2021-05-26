using System;

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
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }
    }
}
