using BaseTypes.Interfaces;

using Diagram.UI.Interfaces;

namespace Diagram.UI
{
    public class FeedbackAliasValue : IFeedbackAlias
    {
        IValue value;

        IAliasName aliasName;

        public FeedbackAliasValue(IValue value, IAliasName aliasName)
        {
            this.value = value;
            this.aliasName = aliasName;
        }

        IAliasName IFeedbackAlias.AliasName => aliasName;

        IValue IFeedbackAlias.Value => value;

        void IFeedback.Set()
        {
            var val = value.Value;
            if (val != null)
            {
                aliasName.Value = val;
            }
        }
    }
}
