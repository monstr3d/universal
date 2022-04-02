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
        Vector3D.Vector3[] vertices = new Vector3D.Vector3[3];			 // Array of vertices
        MultiVertex parent;			 // Parent object
        double[] ownColor = new double[3];                // Own color of the vertex
        double sum;                      // Auxiliary variable
        double[] relative = new double[3];             // relative vectors;
        double[] distanceIn = new double[3];            // Input distances
        double[] distanceOut  = new double[3];           // Output distances
        double sourceDistance;           // Distance to source

        protected double[] color = new double[4];


        public void SetFace(ID3DFace face)
        {
            for (int i = 0; i < 3; i++)
            {
                vertices[i] = face[i];
            }
            Init();
            this.face = face;
            normD = face.Normal;
            for (var ii = 0; ii < 3; ii ++)
            {
                norm[ii] = normD[ii];
            }
            ownColor = face.GetColorV();
            parent = null;
        }

        /// <summary>
        /// Sets color
        /// </summary>
        /// <param name="alpha">Alpha</param>
        /// <param name="red">Red</param>
        /// <param name="green">Green</param>
        /// <param name="blue">Blue</param>
        void SetColor(double alpha, double red, double green, double blue)
        {
            color[0] = red;
            color[1] = green;
            color[2] = blue;
            color[3] = alpha;
        }



    }
}
