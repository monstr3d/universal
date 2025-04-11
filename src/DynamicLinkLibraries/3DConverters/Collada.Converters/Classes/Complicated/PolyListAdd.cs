using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Points;
using ErrorHandler;
using NamedTree;

namespace Collada.Converters.Classes.Complicated
{
    partial class PolyList
    {


        #region 
        INode<IMesh> INode<IMesh>.Parent { get => null; set { } }
        IEnumerable<INode<IMesh>> INode<IMesh>.Nodes { get => null; set { } }

        IMesh INode<IMesh>.Value => this;

        void INode<IMesh>.Add(INode<IMesh> node)
        {
            throw new IllegalSetPropetryException("PolyList");
        }



        string INamed.Name
        {
            get => throw new IllegalSetPropetryException("PolyList");
            set => throw new IllegalSetPropetryException("PolyList");
        }


        List<float[]> IGeometry.Vertices => ProtectedVertices;

        List<float[]> IGeometry.Normals => ProtectedNormals;

        List<float[]> IGeometry.Textures => ProtectedTextures;

        float[] IGeometry.TransformationMatrix => throw new IllegalSetPropetryException("PolyList");


        Abstract3DConverters.Materials.Effect IMesh.Effect => Effect;

        List<int[][]> IMesh.Indexes => throw new IllegalSetPropetryException("PolyList");

   
   
        List<float[]> IMesh.AbsoluteVertices => throw new IllegalSetPropetryException("PolyList");

   
   
        List<Polygon> IMesh.Polygons => Polygons;

    
        IMeshCreator IMesh.Creator => throw new IllegalSetPropetryException("PolyList");


        Abstract3DConverters.Materials.Effect IMesh.GetEffect(IMaterialCreator creator)
        {
            throw new IllegalSetPropetryException("PolyList");
        }

        #endregion

    }
}
