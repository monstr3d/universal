using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using ErrorHandler;

namespace Abstract3DConverters.MaterialCreators
{
    public  class ExeptionalMaterialCreator : IMaterialCreator
    {
        IMeshConverter IMaterialCreator.MeshConverter => null;

        public virtual void Add(object group, object value)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        public virtual object Create(Image image)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        public virtual object Create(Color color)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        public virtual object Create(MaterialGroup material)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        public virtual object Create(DiffuseMaterial material)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        public virtual object Create(SpecularMaterial material)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        public virtual object Create(EmissiveMaterial material)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        public virtual object Create(Material material)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        public virtual void SetImage(object material, object image)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        public virtual void SetOpacity(object material, float opacity)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        void IMaterialCreator.Add(object group, object value)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        object IMaterialCreator.Create(Image image)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        object IMaterialCreator.Create(Color color)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        object IMaterialCreator.Create(MaterialGroup material)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        object IMaterialCreator.Create(DiffuseMaterial material)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        object IMaterialCreator.Create(SpecularMaterial material)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        object IMaterialCreator.Create(EmissiveMaterial material)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        object IMaterialCreator.Create(Material material)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        object IMaterialCreator.Create(Effect effect)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        object IMaterialCreator.SetImage(object effect, object image)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }

        void IMaterialCreator.SetOpacity(object material, float opacity)
        {
            throw new IllegalSetPropetryException("Exeption material cretator");
        }
    }
}
