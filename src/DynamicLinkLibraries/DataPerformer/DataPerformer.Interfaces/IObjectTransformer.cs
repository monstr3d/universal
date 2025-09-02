namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Transformer of objects
    /// </summary>
    public interface IObjectTransformer
    {
        /// <summary>
        /// Input variables
        /// </summary>
        string[] Input
        {
            get;
        }

        /// <summary>
        /// Output variables
        /// </summary>
        string[] Output
        {
            get;
        }

        /// <summary>
        /// Gets type of i - th input variable
        /// </summary>
        /// <param name="i">Variable index</param>
        /// <returns>The type</returns>
        object GetInputType(int i);

        /// <summary>
        /// Gets type of i - th output variable
        /// </summary>
        /// <param name="i">Variable index</param>
        /// <returns>The type</returns>
        object GetOutputType(int i);

        /// <summary>
        /// Calculation
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="output">Output</param>
        void Calculate(object[] input, object[] output);

    }
}
