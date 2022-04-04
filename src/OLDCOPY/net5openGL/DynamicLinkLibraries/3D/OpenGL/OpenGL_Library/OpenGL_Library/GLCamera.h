// GLCamera.h: interface for the GLCamera class.
//
//////////////////////////////////////////////////////////////////////
#ifndef GL_CAMERA_H
#define GL_CAMERA_H

////////////////////////////////////////////////////////////////////////
//
// Class: GLCamera
//
// Description:
//      OpenGL wrapper of a camera
//

#include <windows.h>
#include <vector>
#include "common.h"
//#include <GL/glu.h>
#include "EuclideanTransform.h"
#include "VisibleObject.h"

using namespace System;

class MultiVertex;
class Reper;

class GLCamera : public EuclideanTransform
{
public:

	GLCamera(int w, int h);								// Constructor

	virtual ~GLCamera();					// Destructor


	void Draw(HDC hdc,						// The hdc to draw
		bool invertY						// Flag of y coordinate inversion
		);									// Draws all objects
	
	void BeginPaint(HDC hdc,						// The hdc to draw
		bool invertY						// Flag of y coordinate inversion
		);									// Draws all objects

	void Draw(HDC hdc,						// The hdc to draw
		const double * a,					// Transformation
		bool invertY						// Flag of y coordinate inversion
		);									// Draws all objects
	
	//void Draw(HDC hdc,						// The hdc to draw
	//	char* filename						// Filename
	//	);									// Draws all objects and saves the picture

	void Draw(HDC hdc,					// The HDC to draw
	VisibleObject & object,				// The object to draw
	EuclideanTransform & transform		// Drawing transfirmation
	);									// Draws object with definite transformation

	void Draw(HDC hdc,					// The HDC to draw
		MultiVertex * shape,			// The shape
		array<double> ^ state			// State
		);								// Draws a shape

	void Draw(HDC hdc,					// The HDC to draw
		Reper * reper,					// The reper
		array<double> ^ state			// State
		);								// Draws a reper

	void AddObject(VisibleObject ** obj		// The object to add
		);									// Adds the object
	
	void RemoveObject(VisibleObject ** obj	// The object to remove
		);									// Removes object

	void SetReferenceAngle(double angle		// The new value of reference angle
		);	// Sets new value of reference angle


		// Prepares hdc of camera
	void PrepareHDC(HDC hdc, int mode);

	void BeginPaint(HDC hdc);
	void EndPaint(HDC hdc);

private:
		
	bool first; // first drawing

	int w; // Width
	int h; // Height

	std::vector<VisibleObject**> objects;		// Container of objects
	double ReferenceAngle;						// The reference frame

	void Draw();							// Draws visible objects
	
	void Draw(VisibleObject & object,		// The object to draw
		EuclideanTransform & transform		// Drawing transformation
		);									// Draws object with definite transformatin

	void CalculateRange(double & min,		// Min range 
		double & max						// Max range
		);									// Calculates range

	HGLRC hrc;
};

#endif 
