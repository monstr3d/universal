using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Abstract3DConverters.MaterialCreators;

namespace Collada.Converters.MaterialCreators
{
    internal class ColladaMaterialCreator : XmlMaterialCreator
    {
        internal ColladaMaterialCreator(XmlDocument doc, string xmlns, Dictionary<string, object> images) : base(doc, xmlns, images)
        {

        }
    }
}
