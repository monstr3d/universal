using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Converters.MeshCreators
{
    class ColladaMeshCreator2008 : ColladaMeshCreator
    {
        public ColladaMeshCreator2008(string filename, XmlDocument doc) : base(filename, doc)
        {

        }
    }
}