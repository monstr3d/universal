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
            vertices = new double[nVertex][] ;
	for (int i = 0; i<nVertex; i++)
	{
		vertices[i] = new double[3];
        ID3DFace face;
        faces.GetElement(i, out face);
        vertices[i].SetFace(face);
    }
    CalculateVisibility();
}





        #endregion
    }
}
