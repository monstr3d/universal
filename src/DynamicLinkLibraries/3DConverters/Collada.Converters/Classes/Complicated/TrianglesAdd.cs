using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Points;

namespace Collada.Converters.Classes.Complicated
{
    partial class Triangles
    {

        #region 

        List<float[]> IGeometry.Vertices => ProtectedVertices;

        List<float[]> IGeometry.Normals => ProtectedNormals;

        List<float[]> IGeometry.Textures => ProtectedTextures;

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

        #endregion

    }
}
