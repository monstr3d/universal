using Diagram.Attributes;
using Diagram.UI;
using Diagram.UI.Interfaces;

using ErrorHandler;

namespace Diagram.TypeScript
{
    [Language("TS")]
    internal class ObjectContainerClassCodeCreator : IClassCodeCreator
    {
        public ObjectContainerClassCodeCreator()
        {
            this.AddCodeCreator();
        }
        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {
            throw new OwnNotImplemented();
        }
    }
}