namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Collection of trees
    /// </summary>
    public interface ITreeCollection
    {
        /// <summary>
        /// Collection of trees
        /// </summary>
        ObjectFormulaTree[] Trees
        {
            get;
        }

        /// <summary>
        /// The is valid sign
        /// </summary>
        bool IsValid
        {
            get;
        }

    }
}
