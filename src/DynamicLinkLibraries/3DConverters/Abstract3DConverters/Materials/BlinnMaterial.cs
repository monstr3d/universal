using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Materials
{
    public class BlinnMaterial : MaterialGroup, IAttachement
    {
        public BlinnMaterial(string name, object attachement) : base(name, attachement)
        {

        }

        object IAttachement.Attachement => Attachement;
    }
}
