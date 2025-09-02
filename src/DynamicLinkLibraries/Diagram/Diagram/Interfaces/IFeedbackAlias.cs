using BaseTypes.Interfaces;

namespace Diagram.UI.Interfaces
{ 
    /// <summary>
    /// Feedback alias
    /// </summary>
    public interface IFeedback
    {
        /// <summary>
        /// Sets itself
        /// </summary>
        void Set();
    }


    public interface IFeedbackAlias : IFeedback
    {
        IAliasName AliasName { get; }

        IValue Value { get; }
    }


}
