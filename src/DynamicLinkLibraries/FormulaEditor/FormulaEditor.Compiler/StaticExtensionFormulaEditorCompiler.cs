using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Compiler
{   
    /// <summary>
    /// Static extension methods
    /// </summary>
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
