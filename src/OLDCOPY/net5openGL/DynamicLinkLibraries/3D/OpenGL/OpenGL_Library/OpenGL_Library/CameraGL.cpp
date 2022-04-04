#include "StdAfx.h"
#include "CameraGL.h"
#include "MultiVertex.h"
#include "ShapeGL.h"
#include "Reper.h"
#include "ReperGL.h"


OpenGL_Library::CameraGL::CameraGL(int w, int h)
{
	camera = new GLCamera(w, h);
}

OpenGL_Library::CameraGL::~CameraGL()
{
	Delete();
}

void OpenGL_Library::CameraGL::Draw(void * hdc, OpenGL_Library::ShapeGL ^ shape, array<double> ^ state)
{
	MultiVertex * mv = shape->GetShape();
	if (mv == NULL)
	{
		return;
	}
	HDC h = (HDC)hdc;
	camera->Draw(h, mv, state);
}

void OpenGL_Library::CameraGL::Draw(void * hdc, OpenGL_Library::ReperGL ^ reper, array<double> ^ state)
{
	HDC h = (HDC)hdc;
	camera->Draw(h, reper->GetReper(), state);
}


void OpenGL_Library::CameraGL::BeginPaint(void * hdc)
{
	HDC h = (HDC)hdc;
	camera->BeginPaint(h);
}

void OpenGL_Library::CameraGL::BeginPaint(void * hdc, bool invertY)
{
	HDC h = (HDC)hdc;
	camera->BeginPaint(h, invertY);
}

void OpenGL_Library::CameraGL::EndPaint(void * hdc)
{
	HDC h = (HDC)hdc;
	camera->EndPaint(h);
}

void OpenGL_Library::CameraGL::SetReferenceAngle(double angle)
{
	camera->SetReferenceAngle(angle);
}

void OpenGL_Library::CameraGL::PrepareHDC(void * hdc, int mode)
{
	HDC h = (HDC)hdc;
	camera->PrepareHDC(h, mode);
}

void OpenGL_Library::CameraGL::Delete()
{
	if (camera != NULL)
	{
			delete camera;
			camera = NULL;
	}
}



