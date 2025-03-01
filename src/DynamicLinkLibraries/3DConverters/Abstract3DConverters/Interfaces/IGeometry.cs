using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters.Interfaces
{
    public interface IGeometry
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


    }
}
