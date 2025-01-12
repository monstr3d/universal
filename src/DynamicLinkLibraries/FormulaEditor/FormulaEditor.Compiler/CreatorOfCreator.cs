using FormulaEditor.Interfaces;

namespace FormulaEditor.Compiler
{
    internal class CreatorOfCreator : FormulaEditor.CreatorOfCrerator
    {
        static CreatorOfCreator()
        {
            Instance = new CreatorOfCreator();
        }

        public override ITreeCollectionProxyFactory this[ITreeCollection treeCollection] => 
            new CSharpTreeCollectionProxyFactory(treeCollection);
    }
}
