using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics3D.Interfaces.Classes
{
    /// <summary>
    /// Shape having a collection of vertices
    /// </summary>
    public class MultiVertex
    {
        #region Fields

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected bool external;                      // auxiliary variable

        /// <summary>
        /// The number of vertices
        /// </summary>
        protected int nVertex;                        // The number of vertixes

        /// <summary>
        /// The number of edges
        /// </summary>
        protected int nEdges;                         // The number of edges

        /// <summary>
        /// The array of vertices
        /// </summary>
        protected Vertex[] vertices;              // The array of vertixes

        /// <summary>
        /// Interrior visibility matrix
        /// </summary>
        protected bool[][] visibility;                  // Iterrior visibility matrix

        /// <summary>
        ///External visibility array
        /// </summary>
        protected bool[] externalVisibility;           // External visibility array

        /// <summary>
        /// 
        /// </summary>
        protected int w;                              // Width of bitmap

        /// <summary>
        /// Width of bitmap
        /// </summary>
        protected int h;                              // Height of bitmap

        /// <summary>
        /// Height of bitmap
        /// </summary>
        protected double size;                      // Size 

        /// <summary>
        /// The maximal size of facet
        /// </summary>
        private double facetSize;                         // The maximal size of facet

        /// <summary>
        ///  Number of layers materials
        /// </summary>
        private int nLayersMaterials;                       // Number of layers materials

        /// <summary>
        /// Number of edges types
        /// </summary>
        private int nEdgesTypes;                            // Number of edges types


        #endregion



        #region Ctor


        MultiVertex(ID3DFaceArray faces)
        {
            nLayersMaterials = 0;
            nVertex = faces.Count;
            vertices = new Vertex[nVertex];
            for (int i = 0; i < nVertex; i++)
            {
                vertices[i] = new Vertex();
                ID3DFace face;
                faces.GetElement(i, out face);
                vertices[i].SetFace(face);
            }
            CalculateVisibility();
        }

        #endregion


        #region Public Members

        /// <summary>
        /// Number of vertices
        /// </summary>
        public int Count
        { get => nVertex; }

        /// <summary>
        /// Sets color
        /// </summary>
        /// <param name="index">Index of vertex</param>
        /// <param name="alpha">Alpha</param>
        /// <param name="red">Red</param>
        /// <param name="green">Green</param>
        /// <param name="blue">Blue</param>
        void SetColor(int index, double alpha, double red, double green, double blue)
        {
            vertices[index].SetColor(alpha, red, green, blue);
        }

        #endregion


        #region Protected Members

        void CalculateVisibility()
        {
            externalVisibility = new bool[nVertex];
            visibility = new bool[nVertex][];
            return;
            /*       for (int i = 0; i < nVertex; i++)
                   {
                           visibility[i] = new bool[i + 1];
                           visibility[i][i] = false;
                          for (int j = 0; j < i; j++)
                           {
                                   Vertex& v1 = *vertices[i];
                                   Vertex& v2 = *vertices[j];
                                   VectorD diff(v2.GetSource() - v1.GetSource());
                                   double a1 = diff | v1.GetNorm();
                                   double a2 = diff | v2.GetNorm();
                                   if (a2 != 0)
                                   {
                                           a1 = a1;
                                   }
                                   visibility[i][j] = a1 > 0 && a2 < 0;
                           }
                   }
                   for (int is = 0; is < nVertex; is++)
                   {
                           const Vertex & vi = *vertices[is];
                           for (int j = 0; j < nVertex; j++)
                           {
                                   if (!GetVisibility(is, j))
                                   {
                                           continue;
                                   }
                                   Vertex& vj = *vertices[j];
                                   vj.SetVisibilityPoint(vi.GetSource());
                                   for (int k = 0; k < is; k++)
                                   {
                                           const Vertex & vk = *vertices[k];
                                           if (visibility[is][k])
                                           {
                                                   continue;
                                           }
                                           if (!vj.isVisible(vk.GetSource()))
                                           {
                                                   visibility[is][k] = false;
                                           }
                                   }
                           }
                   }*/
        }


        #endregion
    }
}
