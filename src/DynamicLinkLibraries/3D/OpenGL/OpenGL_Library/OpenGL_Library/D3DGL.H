// D3DGL.h: interface for the D3DGL class.
//
//////////////////////////////////////////////////////////////////////

#pragma once

#include "ID3D.h"

////////////////////////////////////////////////////////////////////////
//
// Class: D3DFrameGL
//
// Description:
//      OpenGL version of DirectX IDirect3DRM interface
//


class D3DGL : public ID3D  
{
public:
	D3DGL();
	virtual ~D3DGL();

	// There are overriden fucntions of ID3DFace class

	
	int CreateMeshBuilder(IMeshBuilder ** builder);
	void SetPointer(void *p);
	void * GetPointer();

};

