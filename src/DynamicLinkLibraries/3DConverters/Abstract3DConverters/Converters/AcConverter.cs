using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Converters
{
    internal class AcConverter : IMeshConverter
    {
        #region Fields

        MaterialCreator materialCreator = new MaterialCreator();

        Service s = new();


        List<float[]> vertices;

        List<float[]> textures;

        List<float[]> normals;



        #endregion

        #region Interface implementation

        Assembly IMeshConverter.Assembly => typeof(AcConverter).Assembly;

        Dictionary<string, Material> IMeshConverter.Materials { set => Set(value); }

        IMaterialCreator IMeshConverter.MaterialCreator => materialCreator;

        Dictionary<string, Image> IMeshConverter.Images { set => Set(value); }

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

        #region Members

        void Set(Dictionary<string, Image> images)
        {

        }

        void Set(Dictionary<string, Material> materials)
        {

        }


        #region


        #region Materail Creator

        class MaterialCreator : IMaterialCreator
        {

            internal MaterialCreator()
            {

            }
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
}
