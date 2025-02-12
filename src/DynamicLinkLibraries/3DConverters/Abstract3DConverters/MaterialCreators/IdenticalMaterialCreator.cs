using System.Reflection;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters.MaterialCreators
{
    public abstract class IdenticalMaterialCreator : AbstractMaterialCreator
    {

        protected IdenticalMaterialCreator(Dictionary<string, object> images = null) :
            base(images)
        {
        }

        public override object Create(Image image)
        {
            return image.Clone();
        }

        public override object Create(Color color)
        {
            return color.Clone();
        }

        public override object Create(DiffuseMaterial material)
        {
            return material.Clone();
        }

        public override object Create(SpecularMaterial material)
        {
            return material.Clone();
        }

        public override object Create(EmissiveMaterial material)
        {
            return material.Clone();
        }

        public override object Create(Material material)
        {
            return base.Create(material);
        }

        public override object Create(MaterialGroup material)
        {
            return base.Create(material);
        }

        public override object CreateGroup(MaterialGroup materialGroup)
        {
            return materialGroup.Clone();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

 
        public override void Set(object material, object color)
        {
            throw new NotImplementedException();
        }

        public override void Set(object material, Color color)
        {
            base.Set(material, color);
        }

        protected override object SetImage(object material, object image)
        {
            throw new NotImplementedException();
        }

        public override void SetImage(object material, Image image)
        {
            base.SetImage(material, image);
        }

        public override void SetOpacity(object material, float opacity)
        {
            throw new NotImplementedException();
        }

        public override void SetPower(object material, float power)
        {
            throw new NotImplementedException();
        }

     }
}
