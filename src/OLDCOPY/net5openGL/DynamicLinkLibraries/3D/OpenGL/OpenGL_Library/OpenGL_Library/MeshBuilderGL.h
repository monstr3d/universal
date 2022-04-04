// MeshBuilderGL.h: interface for the MeshBuilderGL class.
//
//////////////////////////////////////////////////////////////////////

#pragma once

#include <vector>
#include "IMeshBuilder.h"


////////////////////////////////////////////////////////////////////////
//
// Class: MeshBuilderGL
//
// Description:
//      OpenGL implementation of IMeshBuilder interface
//

class D3DFaceGL;
class EuclideranTransform;

class MeshBuilderGL : public IMeshBuilder , public VisibleObject 
{

private:

	std::vector<D3DFaceGL *> faces;				// The faces
	EuclideanTransform * frame;

public:
	
	MeshBuilderGL();							// Constructor
	
	virtual ~MeshBuilderGL();					// Destructor
	
	void SetPointer(void * p);					// Overriden function of base class
	
	void* GetPointer();							// Overriden function of base class
	
	void AddVisual(IMeshBuilder * mb);			// Overriden function of base class
	
	void Release();								// Overriden function of base class
	
	void SetPerspective(bool b);				// Overriden function of base class
	
	void Load(const char* filename);			// Overriden function of base class
	
	int AddFrame(ID3DFrame * frame);			// Overriden function of base class	
	
	int AddVertex(double x, double y, double z);// Overriden function of base class
	
	int AddNormal(double x, double y, double z);// Overriden function of base class
	
	int CreateFace(ID3DFace ** face);			// Overriden function of base class
	
	int GetFaces(ID3DFaceArray ** faces);		// Overriden function of base class
	
	void DrawGL();								// Draws this object

	void Draw();								// Draws this object

	virtual void Draw(HDC hdc,			// Device context 
		EuclideanTransform & transform,	// Visibility point
		int showNumber,					// Show number
		int w,							// Width
		int h,							// Height	
		int * order,					// Order
		double size						// Object size
		);								// Auxiliary drawing for visibility calculation




	EuclideanTransform * GetVisualTransform();
	
	void SetTransform(EuclideanTransform * Frame);

};

