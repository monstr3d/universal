// ID3DFace.h: interface for the ID3DFace class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_ID3DFACE_H__0D5FC1E7_CAB3_428E_B8B6_4642DED4DD82__INCLUDED_)
#define AFX_ID3DFACE_H__0D5FC1E7_CAB3_428E_B8B6_4642DED4DD82__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "cmat.h"

////////////////////////////////////////////////////////////////////////
//
// Class: ID3DFace
//
// Description:
//      Abstract interface for working with 3D graphics. (DirectX prototype of this class is IDirect3DRMFace)
//


class ID3DFace  
{
public:
	ID3DFace();												//Constructor
	
	virtual ~ID3DFace();									// Destructor
	
	virtual void SetPointer(void *p							// The pointer to corresponding 3D Graphics object
		) = 0;												// Sets the pointer to corresponding 3D Graphics object
	
	virtual void * GetPointer() = 0;						// Returns the pointer to corresponding 3D Graphics object

	virtual int AddVertexAndNormalIndexed(int vertex, int normal) = 0;

	virtual int GetVertexCount() = 0;						// Returns count of vertices

	virtual TNT::Vector<double> GetNormal() = 0;			// Returns the normal vector

	virtual TNT::Vector<double> GetVertex(int i				// The number of vertex
		) = 0;												// Returns the i - th vertex

	virtual TNT::Vector<double> GetColorV() = 0;			// Gets color of the face

	virtual void SetColorV(const TNT::Vector<double> & v	// The color vector
		) = 0;												// Sets the color of the face
	
	virtual int AddVertex(const TNT::Vector<double> & v		// The vertex vector
		) = 0;												// Adds new vertex

	virtual void SetNormal(const TNT::Vector<double> & v	// The normal
		) = 0;												// Sets the normal of the face
	
	virtual void SetNumber(unsigned int number				// Face number
		) = 0;												// Sets number

	virtual unsigned int GetNumber() = 0;					// Gets number

};

#endif // !defined(AFX_ID3DFACE_H__0D5FC1E7_CAB3_428E_B8B6_4642DED4DD82__INCLUDED_)
