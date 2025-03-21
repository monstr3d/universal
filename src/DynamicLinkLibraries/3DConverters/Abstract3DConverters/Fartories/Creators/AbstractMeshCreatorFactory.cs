using System.Reflection;
using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Fartories.Creators
{
    public abstract class AbstractMeshCreatorFactory : IMeshCreatorFactory
    {
        List<string> IMeshCreatorFactory.Extensions => Extensions;

        IMeshCreator IMeshCreatorFactory.this[string extension, byte[] bytes, object additional] => this[extension, bytes, additional];

        protected abstract IMeshCreator this[string extension, byte[] bytes, object additional] { get; }

        protected virtual List<string> Extensions
        {
            get;
        } = new();

        protected AbstractMeshCreatorFactory()
        {
            var type = GetType();
            var ca = CustomAttributeExtensions.GetCustomAttribute<ExtensionAttribute>(IntrospectionExtensions.GetTypeInfo(type));
            if (ca != null)
            {
                var keys = ca.Extensions;
                Extensions.AddRange(keys);
            }
        }
    }
}
