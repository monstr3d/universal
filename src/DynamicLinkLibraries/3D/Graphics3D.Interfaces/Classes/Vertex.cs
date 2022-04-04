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
        #region Fields

        Vector3D.Vector3 Position = new Vector3D.Vector3();                // The relative position
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
        /// <summary>
        /// Size
        /// </summary>
        double size = 0;
        protected double[] color = new double[4];

        #endregion

        #region Public Members


        public void Init()
        {
            var v1 = (vertices[1] - vertices[0]);
            var v2 = (vertices[2] - vertices[0]);
            var v3 = (vertices[1] - vertices[2]);
            size = Math.Max(v1.Norm, Math.Max(v2.Norm, v3.Norm));
            size = v1.Norm;
            Position.CopyFrom(vertices[0] + (1.0 / 3.0) * (v1 + v2));
            for (int i = 0; i < 3; i++)
            {
                relative[i] = vertices[i] - Position;
            }
            norm = (VectorC)(v1 ^ v2);
            area = sqrt((norm | norm).real()) / 2;
            if (area < 1.0E-12)
            {
                norm = ComplexD(0);
            }
            else
            {
                norm = ComplexD(0.5 / area) * norm;
            }
            //    source = Position;
            normD.newsize(3);
            for (int i = 0; i < 3; i++)
            {
                normD[i] = norm[i].real();
            }
            parent = NULL;
            VisibleMat.newsize(3, 3);
            face = NULL;
        }


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
        public void SetColor(double alpha, double red, double green, double blue)
        {
            color[0] = red;
            color[1] = green;
            color[2] = blue;
            color[3] = alpha;
        }

        #endregion



    }
}
