using System.Collections.Generic;
using System.Linq;
using BaseTypes.Interfaces;
using DataPerformer.Interfaces;

using Diagram.UI.Interfaces;


namespace DataPerformer.Portable
{
    public class FeedbackAliasCollection : IFeedbackAliasCollection
    {
        Performer performer = new Performer();

        IDataConsumer dataConsumer;

        protected FeedbackAliasCollection(IDataConsumer dataConsumer, IFeedbackCollectionHolder holder)
        {
            this.dataConsumer = dataConsumer;
            Holder = holder;
        }



        public FeedbackAliasCollection(IDataConsumer dataConsumer, IFeedbackCollectionHolder holder,
            Dictionary<string, string> dictionary) : this(dataConsumer, holder)
        {
            this.Dictionary = dictionary;
        }

        void IFeedbackCollection.Fill()
        {
            Fill();
        }
        protected virtual Dictionary<string, string> Dictionary { get; set; }

       protected   Dictionary<IValue, IFeedbackAlias> Get()
        {
            var d = new Dictionary<IValue, IFeedbackAlias>();
            foreach (var f in FeedbackAliases)
            {
                d[f.Value] = f;
            }
            return d;
        }

        protected virtual IFeedbackCollectionHolder Holder { get; set; }

        protected virtual List<IFeedbackAlias> FeedbackAliases { get; set; } = new();

        Dictionary<string, string> IFeedbackCollectionDictionary.Dictionary => Dictionary;

        IEnumerable<IFeedbackAlias> IFeedbackAliasCollection.Aliases => FeedbackAliases;

        IFeedbackCollectionHolder IFeedbackCollection.Holder => Holder;

        Dictionary<string, string> IFeedbackAliasCollection.Dictionary => Dictionary;

        IEnumerable<IFeedback> IFeedbackCollection.Feedbacks => FeedbackAliases;

        Dictionary<IValue, IFeedbackAlias> IFeedbackAliasCollection.Measurements => Get();

        bool IFeedbackCollection.IsEmpty => !FeedbackAliases.Any();

        void IFeedbackCollection.Add(IFeedback alias)
        {
            FeedbackAliases.Add(alias as IFeedbackAlias);
        }

        void IFeedbackCollection.Set()
        {
            if (Dictionary.Count > 0)
            {
                var f = FeedbackAliases;
                foreach (var alias in f)
                {
                    alias.Set();
                }
            }
        }

        protected virtual void Fill()
        {
            FeedbackAliases.Clear();
            performer.Fill(this, dataConsumer);
        }

    }
}
