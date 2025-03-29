using Abstract3DConverters.Interfaces;
using System;
using System.Xml;

namespace Abstract3DConverters.MaterialCreators
{
    public class EmptyXmlMaterialCreator : XmlMaterialCreator
    {
        public EmptyXmlMaterialCreator(XmlDocument doc, string xmlns, IMeshConverter meshConcerter, Dictionary<string, object> images) : 
            base(doc, xmlns, meshConcerter, images)
        {
        }
    }
}
