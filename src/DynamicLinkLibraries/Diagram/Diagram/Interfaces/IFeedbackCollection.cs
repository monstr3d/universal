using System.Collections.Generic;

using BaseTypes.Interfaces;

namespace Diagram.UI.Interfaces
{
    public interface IFeedbackCollection
    {
        /// <summary>
        /// Aliases
        /// </summary>
        IEnumerable<IFeedback> Feedbacks { get; }

        /// <summary>
        /// Adds alias
        /// </summary>
        /// <param name="feedback">The alias</param>
        void Add(IFeedback feedback);

        /// <summary>
        /// Fills itself
        /// </summary>
        void Fill();

        /// <summary>
        /// Holder
        /// </summary>
        IFeedbackCollectionHolder Holder { get; }

        /// <summary>
        /// Sets itself
        /// </summary>
        void Set();

        /// <summary>
        /// The "is empty" sign
        /// </summary>
        bool IsEmpty { get; }

    }


    public interface IFeedbackCollectionDictionary : IFeedbackCollection
    {
        Dictionary<string, string> Dictionary { get; }
    }

    public interface IFeedbackAliasCollection : IFeedbackCollectionDictionary
    {
        Dictionary<string, string> Dictionary { get; }


        IEnumerable<IFeedbackAlias> Aliases { get; }

        Dictionary<IValue, IFeedbackAlias> Measurements { get; }
    }



}
