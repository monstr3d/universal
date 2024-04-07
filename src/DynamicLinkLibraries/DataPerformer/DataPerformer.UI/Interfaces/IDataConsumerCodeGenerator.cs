using DataPerformer.UI.Labels;

namespace DataPerformer.UI.Interfaces
{
    /// <summary>
    /// Generator 
    /// </summary>
    public interface  IDataConsumerCodeGenerator
    {

        /// <summary>
        /// Generates code
        /// </summary>
        /// <param name="label">Label</param>
        void Generate(GraphLabel label);

 
    }
}
