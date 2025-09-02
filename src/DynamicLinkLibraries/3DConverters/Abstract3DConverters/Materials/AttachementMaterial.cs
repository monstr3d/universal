using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Materials
{
    public class AttachementMaterial : MaterialGroup, IAttachement
    {
        protected AttachementMaterial(string name, object attachement) : base(name, attachement)
        {

        }

        object IAttachement.Attachement => Attachement;
    }
}
