using Abstract3DConverters.Interfaces;
using Collada.Converter.Creators;
using Collada150.Creators;
using System.Xml;

namespace Collada.Converter
{
    [Abstract3DConverters.Attributes.Extension([".dae"])]
    public class ColladaMeshCreatorFactory : IMeshCreatorFactory
    {
        public IMeshCreator this[string filename, Stream stream] => Get(filename, stream);

        IMeshCreator Get(string filename, Stream stream)
        {
            using (var r = new StreamReader(stream))
            {
                var s = r.ReadToEnd();
                var doc = new XmlDocument();
                doc.LoadXml(s); ;
                var version = doc.DocumentElement.GetAttribute("version");
                if (version.StartsWith("1.4"))
                {
                    return new Collada14MeshCreator(doc);
                }
                if (version.StartsWith("1.5"))
                {
                    return new Collada15MeshCreator(doc);
                }
            }
            return null;
        }
    }
}
