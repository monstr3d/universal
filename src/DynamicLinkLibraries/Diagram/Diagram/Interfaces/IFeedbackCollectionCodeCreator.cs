using System.Collections.Generic;

namespace Diagram.UI.Interfaces
{

    public interface IFeedbackCollectionCodeCreator
    {
        Dictionary<string, List<string>> Create(IFeedbackCollectionHolder holder);
    }
}
