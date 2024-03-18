using FormulaEditor.Interfaces;

namespace FormulaEditor.Compiler
{
    internal class CreatorOfCreator : FormulaEditor.CreatorOfCrerator
    {

        public override ITreeCollectionProxyFactory this[ITreeCollection treeCollection] => 
            new CSharpTreeCollectionProxyFactory(treeCollection);
    }
}
