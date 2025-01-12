using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    public abstract class CreatorOfCrerator
    {
        public static CreatorOfCrerator Instance { get; set; }

        public abstract ITreeCollectionProxyFactory this[ITreeCollection treeCollection]
        {  get;  }
    }
}
    
