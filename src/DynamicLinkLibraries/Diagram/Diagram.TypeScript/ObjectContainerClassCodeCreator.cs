using Diagram.Attributes;
using Diagram.UI.Interfaces;

namespace Diagram.TypeScript
{
    [Language("TS")]
    internal class ObjectContainerClassCodeCreator : IClassCodeCreator
    {
        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {
            throw new OwnNotImplemented();
        }
    }
}