using System;

namespace Graphics3D.Interfaces
{
	/// <summary>
	///  Abstract interface for working with 3D graphics. (DirectX prototype of this class is IDirect3DRMFace)
	/// </summary>
	public interface ID3DFace
	{
		/// The pointer to corresponding 3D Graphics object
		/// </summary>
		object Pointer
		{ get; set; }

		/// <summary>
		/// Adds indexed vertex and normal
		/// </summary>
		/// <param name="vertex">The vertex index</param>
		/// <param name="normal">The normal index</param>
		/// <returns>The index</returns>
		int AddVertexAndNormalIndexed(int vertex, int normal);

		/// <summary>
		/// Count of vertices
		/// </summary>
		int VertexCount
		{ get; }

		/// <summary>
		/// Normal
		/// </summary>
		double[] Normal
		{ get; set; }

		/// <summary>
		/// Vertex by index
		/// </summary>
		/// <param name="index">Index</param>
		/// <returns>The vertex</returns>
		double[] this[int index]
		{ get; }

		/// <summary>
		/// Gets count of vertices
		/// </summary>
		int Count
		{ get; }

		/// <summary>
		/// Color vector
		/// </summary>
		double[] ColorV
		{ get; set; }

		/// <summary>
		/// Adds a vertex
		/// </summary>
		/// <param name="vertrex">The vertex to add</param>
		/// <returns>Index</returns>
		int AddVertex(double[] vertrex);

		/// <summary>
		/// Number
		/// </summary>
		uint Number
		{ get; set; }

	}
}
