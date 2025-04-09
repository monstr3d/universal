using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using ErrorHandler;

namespace Abstract3DConverters.MaterialCreators
{
    public abstract class IdenticalMaterialCreator : AbstractMaterialCreator
    {

        protected IdenticalMaterialCreator(IMeshConverter meshConcerter, Dictionary<string, object> images = null) :
            base(meshConcerter, images)
        {
        }

        public override object Create(Image image)
        {
            return (image == null) ? null : image.Clone();
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
            throw new IllegalSetPropetryException("Identilal material cretator");
        }

        public override void Set(object material, Color color)
        {
            base.Set(material, color);
        }

        public override object SetImage(object material, object image)
        {
            throw new IllegalSetPropetryException("Identilal material cretator");
        }

   
        public override void SetOpacity(object material, float opacity)
        {
            throw new IllegalSetPropetryException("Identilal material cretator");
        }

        public override void SetPower(object material, float power)
        {
            throw new IllegalSetPropetryException("Identilal material cretator");
        }

     }
}
