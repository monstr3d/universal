using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Points;
using ErrorHandler;
using NamedTree;

namespace Collada.Converters.Classes.Complicated
{
    partial class Triangles
    {

        #region 

        INode<IMesh> INode<IMesh>.Parent { get => null; set { } }
        IEnumerable<INode<IMesh>> INode<IMesh>.Nodes { get => null; set { } }

        IMesh INode<IMesh>.Value => this;

        void INode<IMesh>.Add(INode<IMesh> node)
        {
            throw new IllegalSetPropetryException("Triangle");
        }



        string INamed.Name
        {
            get => throw new IllegalSetPropetryException("Triangle");
            set => throw new IllegalSetPropetryException("Triangle");
        }



        List<float[]> IGeometry.Vertices => ProtectedVertices;

        List<float[]> IGeometry.Normals => ProtectedNormals;

        List<float[]> IGeometry.Textures => ProtectedTextures;

        Abstract3DConverters.Materials.Effect IMesh.Effect => Effect;

        List<int[][]> IMesh.Indexes => throw new IllegalSetPropetryException("Triangle");

 
        List<float[]> IMesh.AbsoluteVertices => throw new IllegalSetPropetryException("Triangle");


 
        List<Polygon> IMesh.Polygons => Polygons;


        IMeshCreator IMesh.Creator => throw new IllegalSetPropetryException("Triangle");
 
        Abstract3DConverters.Materials.Effect IMesh.GetEffect(IMaterialCreator creator)
        {
            throw new IllegalSetPropetryException("Triangle");
        }

        #endregion

    }
}
