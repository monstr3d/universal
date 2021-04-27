#include "stdafx.h"
#include "ReperGL.h"

OpenGL_Library::ReperGL::ReperGL(void)
{
	reper = new Reper();
}
OpenGL_Library::ReperGL::~ReperGL(void)
{
	Delete();
}


void OpenGL_Library::ReperGL::SetLength(double length)
{
	reper->SetLength(length);
}
	

Reper * OpenGL_Library::ReperGL::GetReper()
{
	return reper;
}

void OpenGL_Library::ReperGL::Delete(void)
{
	if (reper != NULL)
	{
		delete reper;
		reper = NULL;
	}
}

