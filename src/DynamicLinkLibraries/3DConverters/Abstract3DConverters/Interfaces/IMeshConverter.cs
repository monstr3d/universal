using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// The converter of meshes
    /// </summary>
    public interface IMeshConverter
    {
        /// <summary>
        /// The directory
        /// </summary>
        string Directory { get; set;  }


        /// <summary>
        /// The effects
        /// </summary>
        Dictionary<string, Effect> Effects
        {
            set;
        }


        /// <summary>
        /// The material creator
        /// </summary>
        IMaterialCreator MaterialCreator { get; }


        /// <summary>
        /// Creates a mesh object from the mesh
        /// </summary>
        /// <param name="mesh">The mesh</param>
        /// <returns>The mesh object</returns>
        object Create(AbstractMesh mesh);

        /// <summary>
        /// Sets effect to a mesh
        /// </summary>
        /// <param name="mesh">The mesh</param>
        /// <param name="effect">The material</param>
        void SetEffect(object mesh, object effect);

        /// <summary>
        /// Adds child mesh
        /// </summary>
        /// <param name="parent">The parent mesh</param>
        /// <param name="child">The child mesh</param>
        void Add(object parent, object child);

        /// <summary>
        /// Combines mashes
        /// </summary>
        /// <param name="meshes">The meshes</param>
        /// <returns>The combination result</returns>
        object Combine(IEnumerable<object> meshes);

        /// <summary>
        /// Sets transformation matrix to the mesh
        /// </summary>
        /// <param name="mesh">The mesh</param>
        /// <param name="transformation">The transformation matrix</param>
        void SetTransformation(object mesh, float[] transformation);

        /// <summary>
        /// Name of file
        /// </summary>
        string Filename { set; }


    }
}
