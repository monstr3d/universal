// D3DGL.cpp: implementation of the D3DGL class.
//
//////////////////////////////////////////////////////////////////////
#include "StdAfx.h"

#include <vector>
#include "cmat.h"
#include "D3DFaceGL.h"
#include "VisibleObject.h"
#include "MeshBuilderGL.h"
#include "D3DGL.h"


extern ID3D * d3d = new D3DGL();
//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

D3DGL::D3DGL()
{

}

D3DGL::~D3DGL()
{

}

int D3DGL::CreateMeshBuilder(IMeshBuilder ** builder)
{
	*builder = new MeshBuilderGL();
	return 0;
}

void D3DGL::SetPointer(void *p)
{
	
}

void * D3DGL::GetPointer()
{
	return NULL;
}
