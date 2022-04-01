using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Graphics3D.Interfaces.Classes
{
    /// <summary>
    /// 3D vertex
    /// </summary>
    public class Vertex
    {
        double[] Position = new double[3];                // The relative position
        Complex[] norm = new Complex[3];                    // The normale vector
        double normD;					 // The real normale vector
        bool enabled;                    // Auxiliary field
        double S;                        // The area of vertex
        ID3DFace face;				 // The 3D graphics face associated with this object
        int index;						 // The index of the vertex
        double[] vertices = new double[3];			 // Array of vertices
        MultiVertex parent;			 // Parent object
        double[] ownColor = new double[3];                // Own color of the vertex
        double sum;                      // Auxiliary variable
        double[] relative = new double;             // relative vectors;
        double distanceIn[3];            // Input distances
        double distanceOut[3];           // Output distances
        double sourceDistance;			 // Distance to source

    }
}
