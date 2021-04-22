// D3DFaceGL.h: interface for the D3DFaceGL class.
//
//////////////////////////////////////////////////////////////////////
#pragma once
#include "ID3DFace.h"

////////////////////////////////////////////////////////////////////////
//
// Class: D3DFaceGL
//
// Description:
//      OpenGL version of DirectX IDirect3DRMFace interface
//

class D3DFaceGL : public ID3DFace  
{
private:
	TNT::Vector<double>* vertices[3];		// Vertices
	const TNT::Vector<double> * normal;		// Normal
	TNT::Vector<double> color;				// Color
	int colorNum[3];						// Number color
	unsigned int number;					// Number
	static int showNumber;					// Show number index
public:
	D3DFaceGL();
	virtual ~D3DFaceGL();

	// There are overriden fucntions of ID3DFace class

	int AddVertexAndNormalIndexed(int vertex, int normal);
	void SetPointer(void *p);
	void * GetPointer();
	int GetVertexCount();
	TNT::Vector<double> GetNormal();
	TNT::Vector<double> GetVertex(int i);
	TNT::Vector<double> GetColorV();
	void SetColorV(const TNT::Vector<double> & v);
	void SetColor(double alpha, double red, double green, double blue);
	int AddVertex(const TNT::Vector<double> & v);
	void SetNormal(const TNT::Vector<double> & v);

	void SetNumber(unsigned int number				// Face number
		);											// Sets number

	unsigned int GetNumber();						// Gets number

	
	void DrawGL();									// Draws the face
	void DrawGL(const TNT::Vector<double> & v		// The shift vector
		);											// Draws the face with shift

	static void SetShowNumber(int showNumber		// Show number
		);		// Sets show number
};

