using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics3D.Interfaces
{
	/// <summary>
	///  Abstract interface for working with 3D graphics. 
	///  (DirectX protype of this class is IDirect3DRMMeshBuilder)
	/// </summary>
	public interface IMeshBuilder
	{
		/// <summary>
		/// The pointer to corresponding 3D Graphics object
		/// </summary>
		object Pointer
		{ get; set; }

		/// <summary>
		///  Creates the face
		/// </summary>
		/// <param name="face"> Creates the face</param>
		/// <returns>Created face</returns>
		int CreateFace(out ID3DFace face);

		/// <summary>
		/// Adds normal to builder
		/// </summary>
		/// <param name="x">The x coordinate of normal</param>
		/// <param name="y">The y coordinate of normal</param>
		/// <param name="z">The z coordinate of normal</param>
		/// <returns>index</returns>
		int AddNormal(double x, double y, double z);

		/// <summary>
		/// Adds vertex to builder
		/// </summary>
		/// <param name="x">The x coordinate of normal</param>
		/// <param name="y">The y coordinate of normal</param>
		/// <param name="z">The z coordinate of normal</param>
		/// <returns>index</returns>
		int AddVertex(double x, double y, double z);

		//	virtual int AddFrame(ID3DFrame* frame   // The frame to add
		//		) = 0;								// Adds the frame

		/// <summary>
		///  Adds visual
		/// </summary>
		/// <param name="mb">The mesh builder to add</param>
		void AddVisual(IMeshBuilder mb); 

		/// <summary>
		/// Releases this object
		/// </summary>
		void Release();             

		bool IsPerspective
		{ get; set; }

		/// <summary>
		/// Loads this object from file
		/// </summary>
		/// <param name="filename">The filename</param>
		void Load(string filename);

		/// <summary>
		/// Gets the face array
		/// </summary>
		/// <param name="faces">The face array</param>
		/// <returns>The index</returns>
	}

}
