using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters.MaterialCreators
{
    public  class ExeptionalMaterialCreator : IMaterialCreator
    {
        IMeshConverter IMaterialCreator.MeshConverter => null;

        public virtual void Add(object group, object value)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(Image image)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(Color color)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(MaterialGroup material)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(DiffuseMaterial material)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(SpecularMaterial material)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(EmissiveMaterial material)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(Material material)
        {
            throw new NotImplementedException();
        }

        public virtual void SetImage(object material, object image)
        {
            throw new NotImplementedException();
        }

        public virtual void SetOpacity(object material, float opacity)
        {
            throw new NotImplementedException();
        }

        void IMaterialCreator.Add(object group, object value)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(Image image)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(Color color)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(MaterialGroup material)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(DiffuseMaterial material)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(SpecularMaterial material)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(EmissiveMaterial material)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(Material material)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(Effect effect)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.SetImage(object effect, object image)
        {
            throw new NotImplementedException();
        }

        void IMaterialCreator.SetOpacity(object material, float opacity)
        {
            throw new NotImplementedException();
        }
    }
}
