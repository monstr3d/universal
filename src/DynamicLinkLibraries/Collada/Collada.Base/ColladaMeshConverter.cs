using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters;
using System.Xml;
using Abstract3DConverters.Materials;
using System.Reflection;
using Abstract3DConverters.Meshes;

namespace Collada.Base
{
    public class ColladaMeshConverter : IMeshConverter, IStringRepresentation, IMaterialCreator
    {

        #region Fields

        protected XmlDocument doc = new();

        protected Service s = new();

  


        List<float[]> vertices;

        List<float[]> textures;

        List<float[]> normals;


        Dictionary<string, Image> images;

        Dictionary<string, Material> materials;



        protected IMeshConverter converter;

        string directory;

        #endregion


        #region Ctor

        protected ColladaMeshConverter(string directory)
        {
            this.directory = directory;
        }

        #endregion



        #region IMeshConverter implemebtation

        Assembly IMeshConverter.Assembly => typeof(Collada150Converter).Assembly;

        Dictionary<string, Material> IMeshConverter.Materials { set => Set(value); }

        IMaterialCreator IMeshConverter.MaterialCreator => this;

        Dictionary<string, Image> IMeshConverter.Images { set => Set(value); }

        string IMeshConverter.Directory => directory;

        void IMeshConverter.Add(object mesh, object child)
        {
            throw new NotImplementedException();
        }

        object IMeshConverter.Combine(IEnumerable<object> meshes)
        {
            throw new NotImplementedException();
        }

        object IMeshConverter.Create(AbstractMesh mesh)
        {
            throw new NotImplementedException();
        }

        void IMeshConverter.Init(object obj)
        {

            if (obj is Tuple<List<float[]>, List<float[]>, List<float[]>> t)
            {
                vertices = t.Item1;
                textures = t.Item2;
                normals = t.Item3;
            }
        }

        void IMeshConverter.SetMaterial(object mesh, object material)
        {
            throw new NotImplementedException();
        }

        void IMeshConverter.SetTransformation(object mesh, float[] transformation)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region IStringRepresentation Members

        string IStringRepresentation.ToString(object obj)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Membres

        protected virtual void Set(Dictionary<string, Image> images)
        {
            this.images = images;
        }


        protected virtual void Set(Dictionary<string, Material> materials)
        {
            this.materials = materials;
        }



        #endregion


        #region Material Creator

        Assembly IMaterialCreator.Assembly => throw new NotImplementedException();

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

        object IMaterialCreator.Create(Material material)
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

        void IMaterialCreator.Set(object material, object color)
        {
            throw new NotImplementedException();
        }

        void IMaterialCreator.Set(object material, Color color)
        {
            throw new NotImplementedException();
        }

        void IMaterialCreator.SetImage(object material, object image)
        {
            throw new NotImplementedException();
        }

        void IMaterialCreator.SetImage(object material, Image image)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
