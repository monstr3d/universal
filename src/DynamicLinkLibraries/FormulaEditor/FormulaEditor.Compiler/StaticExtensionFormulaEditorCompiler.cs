using System;

using CategoryTheory;

using Diagram.UI;

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
            try
            {
                CSharpTreeCollectionProxyFactory f = new CSharpTreeCollectionProxyFactory();
                StaticExtensionFormulaEditor.Factory = f;
                StaticExtensionFormulaEditor.TreeCollectionCodeCreator = f;
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }
    }
}
