// IMeshBuilder.h: interface for the IMeshBuilder class.
//
//////////////////////////////////////////////////////////////////////
#pragma once
class ID3DFrame;
class ID3DFace;
class ID3DFaceArray;

////////////////////////////////////////////////////////////////////////
//
// Class: IMeshBuilder
//
// Description:
//      Abstract interface for working with 3D graphics. (DirectX protype of this class is IDirect3DRMMeshBuilder)
//



class IMeshBuilder  
{
public:
	
	IMeshBuilder();						// Constructor
	
	virtual ~IMeshBuilder();			// Destructor

	virtual void SetPointer(void *p		// The pointer to corresponding 3D Graphics object
		) = 0;							// Sets the pointer to corresponding 3D Graphics object
	
	virtual void * GetPointer() = 0;	// Returns the pointer to corresponding 3D Graphics object

	virtual int CreateFace(ID3DFace ** face	// The face to create
		) = 0;								// Creates the face
	
	virtual int AddNormal(double x,			// The x coordinate of normal
		double y,							// The y coordinate of normal
		double z							// The z coordinate of normal
		) = 0;								// Adds normal to builder
	
	virtual int AddVertex(double x,			// The x coordinate of vertex
		double y,							// The y coordinate of vertex
		double z							// The z coordinate of vertex
		) = 0;								// Adds vertex to builder
	
	virtual int AddFrame(ID3DFrame * frame	// The frame to add
		) = 0;								// Adds the frame
	
	virtual void AddVisual(IMeshBuilder * mb // The mesh builder to add
		) = 0;								 // Adds visual
	
	virtual void Release() = 0;				// Releases this object
	
	virtual void SetPerspective(bool b		// The perspective sign
		) = 0;								// Sets perspective
	
	virtual void Load(const char* filename	// The filename
		) = 0;								// Loads this object from file
	
	virtual int GetFaces(ID3DFaceArray ** faces  // The face array
		) = 0;									 // Gets the face array
	

};
