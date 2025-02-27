using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;

namespace Abstract3DConverters.Interfaces
{
    public interface IMesh
    {
        /// <summary>
        /// Vertices
        /// </summary>
        List<float[]> Vertices { get; }

        /// <summary>
        /// Normals
        /// </summary>
        List<float[]> Normals { get; }

        /// <summary>
        /// Textures
        /// </summary>
        List<float[]> Textures { get; }

        /// <summary>
        /// Effect
        /// </summary>
        Effect Effect { get; }

        /// <summary>
        /// Indexes
        /// </summary>
        List<int[][]> Indexes { get; }

        /// <summary>
        /// Has polygons sign
        /// </summary>
        bool HasPolygons { get; }

        /// <summary>
        /// Absolute points
        /// </summary>
        List<Point> AbsolutePoints { get; }

        /// <summary>
        /// Absolute Verices
        /// </summary>
        public List<float[]> AbsoluteVertices { get; }


        /// <summary>
        /// Transformation matrix
        /// </summary>
        float[] TransformationMatrix { get; }

        /// <summary>
        /// Gets effect
        /// </summary>
        /// <param name="creator">Material creator</param>
        /// <returns>The effect</returns>
        Effect GetEffect(IMaterialCreator creator);

        /// <summary>
        /// The name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Polygons
        /// </summary>
        List<Polygon> Polygons
        {
            get;

        }

        /// <summary>
        /// Children
        /// </summary>
        List<IMesh> Children { get; }

        /// <summary>
        /// Creator of meshes
        /// </summary>
        IMeshCreator Creator { get; }

    }
}
