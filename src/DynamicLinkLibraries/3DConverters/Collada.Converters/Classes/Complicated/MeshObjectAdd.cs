using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Points;
using ErrorHandler;
using NamedTree;

namespace Collada.Converters.Classes.Complicated
{
    partial class MeshObject 
    {

        #region IMesh implementation

        List<float[]> IGeometry.Vertices => ProtectedVertices;

        List<float[]> IGeometry.Normals => ProtectedNormals;

        List<float[]> IGeometry.Textures => ProtectedTextures;

        float[] IGeometry.TransformationMatrix => throw new IllegalSetPropetryException("MeshObject");


        Abstract3DConverters.Materials.Effect IMesh.Effect => Effect;

        List<int[][]> IMesh.Indexes => throw new IllegalSetPropetryException("MeshObject");



        List<float[]> IMesh.AbsoluteVertices => throw new IllegalSetPropetryException("MeshObject");


        INode<IMesh> INode<IMesh>.Parent { get => null; set { } }
        IEnumerable<INode<IMesh>> INode<IMesh>.Nodes { get => null; set { } }

        IMesh INode<IMesh>.Value => this;

        void INode<IMesh>.Add(INode<IMesh> node)
        {
            throw new IllegalSetPropetryException("MeshObject");
        }



        string INamed.Name
        {
            get => throw new IllegalSetPropetryException("MeshObject");
            set => throw new IllegalSetPropetryException("MeshObject");
        }

        List<Polygon> IMesh.Polygons => Polygons;

        List<IMesh> IMesh.Children => throw  new IllegalSetPropetryException("MeshObject");

        IMeshCreator IMesh.Creator => throw new IllegalSetPropetryException("MeshObject");


        Abstract3DConverters.Materials.Effect IMesh.GetEffect(IMaterialCreator creator)
        {
            throw new IllegalSetPropetryException("MeshObject");
        }

        void IMesh.CalculateAbsolute()
        {
            throw new IllegalSetPropetryException("MeshObject");
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
