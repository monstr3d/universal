using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    public abstract class CreatorOfCrerator
    {

        public abstract ITreeCollectionProxyFactory this[ITreeCollection treeCollection]
        {  get;  }
    }
}
    
