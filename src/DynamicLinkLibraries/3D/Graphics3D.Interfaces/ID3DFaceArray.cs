using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics3D.Interfaces
{
    /// <summary>
    /// Abstract interface for working with 3D graphics. 
    /// (DirectX protype of this class is IDirect3DRMFaceArray)
    /// </summary>
    public interface ID3DFaceArray
    {
        /// The pointer to corresponding 3D Graphics object
        /// </summary>
        object Pointer
        { get; set; }

        /// <summary>
        /// Gets a face
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="face">The face</param>
        /// <returns>The index</returns>
        int GetElement(int index, out ID3DFace face);

        /// <summary>
        /// Count of faces
        /// </summary>
        int Count
            { get; }

    }
}
