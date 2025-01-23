using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Abstract3DConverters.MaterialCreators
{
    public class EmplyMaterialCreator : XmlMaterialCreator
    {
        public EmplyMaterialCreator(XmlDocument doc, string xmlns, Dictionary<string, object> images) : base(doc, xmlns, images)
        {

        }
    }
}
