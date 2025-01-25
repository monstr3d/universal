using Abstract3DConverters.Interfaces;
using Collada.Converters.MeshCreators;
using System.Xml;

namespace Collada.Converters
{
    [Abstract3DConverters.Attributes.Extension([".dae"])]
    public class ColladaMeshCreatorFactory : IMeshCreatorFactory
    { 
        public ColladaMeshCreatorFactory()
        {

        }

        public IMeshCreator this[string filename, byte[] bytes] => Get(filename, bytes);

        IMeshCreator Get(string filename, byte[] bytes)
        {
            var doc = new XmlDocument();
            using var stream = new MemoryStream(bytes);
            using var reader = new StreamReader(stream);
            var s = reader.ReadToEnd();
            doc.LoadXml(s);
            /*  var b = new byte[stream.Length];
              stream.Read(b);
              using (var r = new StreamReader(new MemoryStream(b)))
              {
                  var s = r.ReadToEnd();
                  var doc = new XmlDocument();
                  doc.LoadXml(s);
              }
              return null;*/
            var version = doc.DocumentElement.GetAttribute("version");
            if (version.StartsWith("1.4"))
            {
                return new ColladaMeshCreator2008(filename, doc);
            }
            if (version.StartsWith("1.5"))
            {
                return new ColladaMeshCreator2008(filename, doc);
            }
            return null;

        }
    }
}
