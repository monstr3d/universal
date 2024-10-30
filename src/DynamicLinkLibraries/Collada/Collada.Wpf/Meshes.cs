using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace Collada.Wpf
{
    public struct Meshes
    {
        //
        // Summary:
        //     Gets or sets a collection of normal vectors for the System.Windows.Media.Media3D.MeshGeometry3D.
        //
        //
        // Returns:
        //     System.Windows.Media.Media3D.Vector3DCollection that contains the normal vectors
        //     for the MeshGeometry3D.
        public Vector3DCollection Normals { get; set; }
        //
        // Summary:
        //     Gets or sets a collection of vertex positions for a System.Windows.Media.Media3D.MeshGeometry3D.
        //
        //
        // Returns:
        //     System.Windows.Media.Media3D.Point3DCollection that contains the vertex positions
        //     of the MeshGeometry3D.
        public Point3DCollection Positions { get; set; }
        //
        // Summary:
        //     Gets or sets a collection of texture coordinates for the System.Windows.Media.Media3D.MeshGeometry3D.
        //
        //
        // Returns:
        //     System.Windows.Media.PointCollection that contains the texture coordinates for
        //     the MeshGeometry3D.
        public PointCollection TextureCoordinates { get; set; }
        //
        // Summary:
        //     Gets or sets a collection of triangle indices for the System.Windows.Media.Media3D.MeshGeometry3D.
        //
        //
        // Returns:
        //     Collection that contains the triangle indices of the MeshGeometry3D.
        public Int32Collection TriangleIndices { get; set; }

    }
}
