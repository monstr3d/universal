using Abstract3DConverters.Interfaces;
using System.Xml;

namespace Abstract3DConverters.MeshCreatorFactory
{
    [Abstract3DConverters.Attributes.Extension([".dae"])]
    public class ColladaMeshCreatorFactory : IMeshCreatorFactory
    {
        public IMeshCreator this[string filename, Stream stream] => Get(filename, stream);

        IMeshCreator Get(string filename, Stream stream)
        {
            var b = new byte[stream.Length];
            stream.Read(b);
            using (var r = new StreamReader(new MemoryStream(b)))
            {
                var s = r.ReadToEnd();
                var doc = new XmlDocument();
                doc.LoadXml(s);
                var version = doc.DocumentElement.GetAttribute("version");
                if (version.StartsWith("1.4"))
                {
                    using (var ms = new MemoryStream(b))
                    {
                       // return new Collada14MeshCreator(ms);
                    }
                    //   return new Collada14MeshCreator(doc);
                   // return new Collada14MeshCreator(s);
                }
                if (version.StartsWith("1.5"))
                {
                   // return new Collada15MeshCreator(doc);
                }
            }
            return null;
        }
    }
}
