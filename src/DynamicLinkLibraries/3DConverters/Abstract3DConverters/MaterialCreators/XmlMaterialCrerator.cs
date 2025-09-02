using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using System.Xml;

namespace Abstract3DConverters.MaterialCreators
{

    public abstract class XmlMaterialCreator : IdenticalMaterialCreator
    {

        protected XmlDocument doc;

        protected string xmlns;

        protected Dictionary<object, MaterialGroup> materials = new();

        protected XmlMaterialCreator(XmlDocument doc, string xmlns, IMeshConverter meshConcerter, Dictionary<string, object> images) :
            base(meshConcerter, images)
        {
            this.doc = doc;
            this.xmlns = xmlns;
        }

        protected XmlElement Create(string tag)
        {
            return doc.CreateElement(tag, xmlns);
        }

        public override object Create(Material material)
        {
            switch (material)
            {
                case DiffuseMaterial diff:
                    return Create(diff);
                    break;
                case EmissiveMaterial emi:
                    return Create(emi);
                    break;
                case SpecularMaterial spec:
                    return Create(spec);
                    break;
                case MaterialGroup mg:
                    object o = Create(mg);
                    materials[o] = mg;
                    return o;
                default:
                    return null;
            }
        }



        public override void Add(object group, object value)
        {
        }



    }
}
