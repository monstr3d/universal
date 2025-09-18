using System.Linq;
using System.Collections.Generic;

using Diagram.UI.Interfaces;

namespace Diagram.UI
{
    public class EnumerableFeedbackCollecton<T> : IFeedbackCollection where T : class
    {
        NamedTree.Performer performer = new NamedTree.Performer();

        protected virtual bool IsEmpty { get; set; } = true;


        protected IEnumerable<T> Feedback { get; set; }

        protected virtual IFeedbackCollectionHolder Holder { get; set; }

        public EnumerableFeedbackCollecton(IEnumerable<T> feedback, IFeedbackCollectionHolder holder)
        {  
            Feedback = feedback; 
            Holder = holder;
            IsEmpty = !feedback.Any();
        }

        IEnumerable<IFeedback> IFeedbackCollection.Feedbacks => [];

        IFeedbackCollectionHolder IFeedbackCollection.Holder => Holder;

        bool IFeedbackCollection.IsEmpty => IsEmpty;

        void IFeedbackCollection.Add(IFeedback feedback)
        {
        }

        void IFeedbackCollection.Fill()
        {
        }

        void IFeedbackCollection.Set()
        {
            var l = performer.Convert<IFeedback, T>(Feedback);
            var p = from value in l select Get(value);
            p.ToArray();
        }

  
        IFeedback Get(IFeedback feedback)
        {
            feedback.Set();
            return feedback;
        }
    }

}
