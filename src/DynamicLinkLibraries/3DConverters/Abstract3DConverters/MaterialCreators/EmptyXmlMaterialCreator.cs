using System;
using System.Xml;

namespace Abstract3DConverters.MaterialCreators
{
    public class EmptyXmlMaterialCreator : XmlMaterialCreator
    {
        public EmptyXmlMaterialCreator(XmlDocument doc, string xmlns, Dictionary<string, object> images) : 
            base(doc, xmlns, images)
        {
        }
    }
}
