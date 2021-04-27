// ID3DFaceArray.h: interface for the ID3DFaceArray class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_ID3DFACEARRAY_H__ACB5E98E_978C_4140_860C_8E48A52B8875__INCLUDED_)
#define AFX_ID3DFACEARRAY_H__ACB5E98E_978C_4140_860C_8E48A52B8875__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class ID3DFace;

////////////////////////////////////////////////////////////////////////
//
// Class: ID3DFaceArray
//
// Description:
//      Abstract interface for working with 3D graphics. (DirectX protype of this class is IDirect3DRMFaceArray)
//


class ID3DFaceArray  
{
public:

	virtual void SetPointer(void *p		// The pointer to corresponding 3D Graphics object
		) = 0;												// Sets the pointer to corresponding 3D Graphics object
	
	virtual void * GetPointer() = 0;	// Returns the pointer to corresponding 3D Graphics object

	virtual int GetElement(int index,	// The index of the face 
		ID3DFace **face					// The face
		) = 0;							// Gets the index - th face
	
	virtual int GetSize() = 0;			// Returns the quantity of faces
	
	ID3DFaceArray();					// Constructor
	
	virtual ~ID3DFaceArray();			// Destructor

};

#endif // !defined(AFX_ID3DFACEARRAY_H__ACB5E98E_978C_4140_860C_8E48A52B8875__INCLUDED_)
