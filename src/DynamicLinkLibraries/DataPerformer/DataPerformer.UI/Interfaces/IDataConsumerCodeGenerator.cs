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
        /// <param name="nameSpace">Namespace</param>
        /// <param name="className">Name of class</param>
        /// <param name="obj">Additional object</param>
        void Generate(GraphLabel label, string nameSpace, string className, object obj);

        /// <summary>
        /// Check whether the genreator requres aliases
        /// </summary>
        bool RequireAliases {  get; }

    }
}
