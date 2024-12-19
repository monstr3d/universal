using Abstract3DConverters.Interfaces;
using Collada.Converter.Creators;
using System.Xml;

namespace Collada.Converter
{
    [Abstract3DConverters.Attributes.Extension([".dae"])]
    public class ColladaMeshCreatorFactory : IMeshCreatorFactory
    {
        public IMeshCreator this[string filename] => Get(filename);

        IMeshCreator Get(string filename)
        {
            var doc = new XmlDocument();
            doc.Load(filename);
            var version = doc.DocumentElement.GetAttribute("version");
            if (version.StartsWith("1.4"))
            {
                return new Collada14MeshCreator();
            }
            if (version.StartsWith("1.5"))
            {
                return new Collada15MeshCreator();
            }
            return null;
        }
    }
}
