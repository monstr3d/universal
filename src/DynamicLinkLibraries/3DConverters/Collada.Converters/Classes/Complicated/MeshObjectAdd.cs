using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Points;

namespace Collada.Converters.Classes.Complicated
{
    partial class MeshObject 
    {

        #region IMesh implementation

        List<float[]> IGeometry.Vertices => ProtectedVertices;

        List<float[]> IGeometry.Normals => ProtectedNormals;

        List<float[]> IGeometry.Textures => ProtectedTextures;

        float[] IGeometry.TransformationMatrix => throw new NotImplementedException();


        Abstract3DConverters.Materials.Effect IMesh.Effect => Effect;

        List<int[][]> IMesh.Indexes => throw new NotImplementedException();



        List<float[]> IMesh.AbsoluteVertices => throw new NotImplementedException();


        string IMesh.Name => throw new NotImplementedException();

        List<Polygon> IMesh.Polygons => Polygons;

        List<IMesh> IMesh.Children => throw new NotImplementedException();

        IMeshCreator IMesh.Creator => throw new NotImplementedException();


        Abstract3DConverters.Materials.Effect IMesh.GetEffect(IMaterialCreator creator)
        {
            throw new NotImplementedException();
        }

        void IMesh.CalculateAbsolute()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Own
        protected List<float[]> ProtectedVertices { get; set; } = new List<float[]>();

        protected List<float[]> ProtectedTextures { get; set; } = new List<float[]>();

        protected List<float[]> ProtectedNormals { get; set; } = new List<float[]>();

        internal List<Polygon> Polygons
        {
            get;
            private set;
        } = new List<Polygon>();

        protected Abstract3DConverters.Materials.Effect Effect { get; private set; }

        #endregion
    }
}
