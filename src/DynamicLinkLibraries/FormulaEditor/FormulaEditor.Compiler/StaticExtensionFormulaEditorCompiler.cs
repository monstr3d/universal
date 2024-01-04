using System;
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
        static private ICompiler compiler;

        /// <summary>
        /// Compiler
        /// </summary>
        static public ICompiler Compiler
        {
            get => compiler;
            set 
            { 
                compiler = value; 
            } 
        }

        /// <summary>
        /// Initialization
        /// </summary>
        public static void Init()
        {
  
        }

        static StaticExtensionFormulaEditorCompiler()
        {
            StaticExtensionFormulaEditor.Init();
            CSharpTreeCollectionProxyFactory f = new CSharpTreeCollectionProxyFactory();
            StaticExtensionFormulaEditor.Factory = f;
            StaticExtensionFormulaEditor.TreeCollectionCodeCreator = f;
        }
    }
}
