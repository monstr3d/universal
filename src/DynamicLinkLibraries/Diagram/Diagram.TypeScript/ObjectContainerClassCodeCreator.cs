using BaseTypes.Attributes;
using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;

using ErrorHandler;

namespace Diagram.UI.TypeScript
{
    [Language("TS")]
    internal class ObjectContainerClassCodeCreator : IClassCodeCreator
    {
        public ObjectContainerClassCodeCreator()
        {
            this.AddClassCodeCreator();
        }


        List<string> IClassCodeCreator.CreateCode(string preffix, object obj, string volume)
        {
            return null;
            throw new OwnNotImplemented();
        }

        protected virtual string BaseClassString(string prefix, object obj, string volume)
        {
            return obj.GetType().Name;
        }
        protected virtual IDesktopCodeCreator DesktopCodeCreator { get; set; }

        IDesktopCodeCreator IClassCodeCreator.DesktopCodeCreator { get => DesktopCodeCreator; set => DesktopCodeCreator = value; }

    }
}