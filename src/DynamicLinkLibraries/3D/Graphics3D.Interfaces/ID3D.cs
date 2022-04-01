using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics3D.Interfaces
{

    /// <summary>
    /// Abstract interface for working with 3D graphics. (DirectX protype of this class is IDirect3DRM)
    /// </summary>
    public interface ID3D
    {
        /// <summary>
        /// The pointer to corresponding 3D Graphics object
        /// </summary>
        object Pointer
        { get; set; }

        /// <summary>
        /// Creates mesh builder
        /// </summary>
        /// <param name="builder">The mesh builder</param>
        /// <returns>The index</returns>
        int CreateMeshBuilder(out IMeshBuilder builder);
    }
}
