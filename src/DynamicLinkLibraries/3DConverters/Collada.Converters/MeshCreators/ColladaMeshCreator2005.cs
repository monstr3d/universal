using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Converters.MeshCreators
{
    public class ColladaMeshCreator2005 : ColladaMeshCreator
    {
        public ColladaMeshCreator2005(string filename, XmlDocument doc) : base(filename, doc)
        {

        }
    }
}