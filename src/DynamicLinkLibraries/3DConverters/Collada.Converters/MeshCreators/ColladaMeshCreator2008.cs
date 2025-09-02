using System.Xml;

namespace Collada.Converters.MeshCreators
{
    class ColladaMeshCreator2008 : ColladaMeshCreator
    {
        public ColladaMeshCreator2008(string filename, string directory, XmlDocument doc) : 
            base(filename, directory, doc)
        {

        }
    }
}