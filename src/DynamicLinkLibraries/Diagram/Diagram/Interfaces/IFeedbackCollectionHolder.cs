
namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Hiolder of feedback
    /// </summary>
    public interface IFeedbackCollectionHolder
    {
        /// <summary>
        /// The feedback
        /// </summary>
        IFeedbackCollection Feedback { get; }

    }
}
