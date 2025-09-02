using System.Xml;

using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.MaterialCreators
{
    public class EmplyMaterialCreator : XmlMaterialCreator
    {
        public EmplyMaterialCreator(XmlDocument doc, string xmlns, IMeshConverter meshConcerter, Dictionary<string, object> images) : 
            base(doc, xmlns, meshConcerter, images)
        {

        }
    }
}
