using FormulaEditor.Interfaces;

namespace FormulaEditor.Compiler
{
    internal class CreatorOfCreator : FormulaEditor.CreatorOfCrerator
    {

        public override CSharp.CSharpTreeCollectionProxyFactory this[ITreeCollection treeCollection] => 
            new Compiler.CSharpTreeCollectionProxyFactory(treeCollection);
    }
}
