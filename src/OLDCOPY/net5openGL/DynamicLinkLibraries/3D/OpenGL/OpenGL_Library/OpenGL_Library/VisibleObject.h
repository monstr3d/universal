// VisibleObject.h: interface for the VisibleObject class.
//
//////////////////////////////////////////////////////////////////////

#ifndef VISIBLE_OBJECT_H
#define VISIBLE_OBJECT_H

#include "windows.h"
#include "EuclideanTransform.h"


////////////////////////////////////////////////////////////////////////
//
// Class: VisibleObject;
//
// Description:
//      Interface for drawing visible object
//

//class GLCamera;

class VisibleObject   
{
public:
	
	VisibleObject();			// Constructor
	
	virtual ~VisibleObject();	// Destructor
	
	virtual void Draw() = 0;		// Draws this object

	virtual void Draw(HDC hdc,			// Device context 
		EuclideanTransform & transform,	// Visibility point
		int showNumber,					// Show number
		int w,							// Width
		int h,							// Height
		int * order,						// Order
		double size						// Object size
		) = 0;							// Auxiliary drawing for visibility calculation


	virtual EuclideanTransform * GetVisualTransform() = 0; // Gets transform

//	virtual void DrawElement(int number  // Element number
//		) = 0;							 // Draws element

//	virtual int GetCount() = 0;			// Count of elements

//	virtual void AddCamera(GLCamera * cam) = 0;
};

#endif // !defined(AFX_VISIBLEOBJECT_H__E10D8869_EF3A_483D_9DFB_973F7E19BA8F__INCLUDED_)
