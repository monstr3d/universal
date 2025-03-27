using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Fartories.Creators
{
    public abstract class AbstractMeshCreatorFactory : IMeshCreatorFactory
    {
        protected Service s = new Service();
        List<string> IMeshCreatorFactory.Extensions => Extensions;

        IMeshCreator IMeshCreatorFactory.this[string extension, params object[] objects] => this[extension, objects];

        protected abstract IMeshCreator this[string extension, params object[] objects] { get; }

        protected virtual List<string> Extensions
        {
            get;
        } = new();

        protected AbstractMeshCreatorFactory()
        {
            var ca =  s.GetAttribute<ExtensionAttribute>(this);
            if (ca != null)
            {
                var keys = ca.Extensions;
                Extensions.AddRange(keys);
            }
        }
    }
}
