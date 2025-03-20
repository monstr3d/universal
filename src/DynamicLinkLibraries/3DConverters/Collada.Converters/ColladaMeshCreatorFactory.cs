using System.Xml;

using Abstract3DConverters;
using Abstract3DConverters.Fartories.Creators;
using Abstract3DConverters.Interfaces;

using Collada.Converters.MeshCreators;


namespace Collada.Converters
{
    [Abstract3DConverters.Attributes.Extension([".dae"])]
    public class ColladaMeshCreatorFactory : AbstractMeshCreatorFactory
    { 
        public ColladaMeshCreatorFactory()
        {

        }

        protected override IMeshCreator this[string filename, byte[] bytes]
        {
            get
            {
                try
                {
                    var doc = new XmlDocument();
                    using var stream = new MemoryStream(bytes);
                    using var reader = new StreamReader(stream);
                    var s = reader.ReadToEnd();
                    doc.LoadXml(s);
                    var version = doc.DocumentElement.GetAttribute("version");
                    if (version.StartsWith("1.4"))
                    {
                        return new ColladaMeshCreator2008(filename, doc);
                    }
                    if (version.StartsWith("1.5"))
                    {
                        return new ColladaMeshCreator2008(filename, doc);
                    }
                }
                catch (Exception exception)
                {
                    exception.HandleExceptionDouble("ColladaMeshCreatorFactory");
                }
                
                return null;
            }
        }
    }
}
