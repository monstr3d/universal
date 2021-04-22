// ID3D.h: interface for the ID3D class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_ID3D_H__300A4DD4_D73E_4CF8_9DE1_E701ADC3FA82__INCLUDED_)
#define AFX_ID3D_H__300A4DD4_D73E_4CF8_9DE1_E701ADC3FA82__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class IMeshBuilder;


////////////////////////////////////////////////////////////////////////
//
// Class: ID3D
//
// Description:
//      Abstract interface for working with 3D graphics. (DirectX protype of this class is IDirect3DRM)
//


class ID3D  
{
public:
	ID3D();													// Constructor
	
	virtual ~ID3D();										// Destructor
	
	virtual int CreateMeshBuilder(IMeshBuilder ** builder	// The mesh builder
		) = 0;
	
	virtual void SetPointer(void *p							// The pointer to corresponding 3D Graphics object
		) = 0;												// Sets the pointer to corresponding 3D Graphics object
	
	virtual void * GetPointer() = 0;						// Returns the pointer to corresponding 3D Graphics object
};

#endif // !defined(AFX_ID3D_H__300A4DD4_D73E_4CF8_9DE1_E701ADC3FA82__INCLUDED_)
