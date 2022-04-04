// GLCamera.cpp: implementation of the GLCamera class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "windows.h"
#include "DIBUTIL.H" 
#include "DIBAPI.H" 
#include <fstream>
#include <complex>
#include <map>
#include <vector>
#include "GLCamera.h"
#include "MultiVertex.h"
#include "Reper.h"

//void SaveHDC(HDC hDC, LPSTR filename, int width, int height);
BOOL bSetupPixelFormat(HDC hdc, int mode);

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

GLCamera::GLCamera(int W, int H)
: first(true)
{
	w = W;
	h = H;
}

GLCamera::~GLCamera()
{
}


void GLCamera::AddObject(VisibleObject ** obj)
{
	objects.push_back(obj);
}


void GLCamera::RemoveObject(VisibleObject ** obj)
{
	for (size_t i = 0; i < objects.size(); i++)
	{
		if (objects[i] == obj)
		{
			objects.erase(objects.begin() + i);
			return;
		}
	}
}

void GLCamera::Draw(HDC hdc, VisibleObject & object, EuclideanTransform & transform)
{
	if (first)
	{
		PrepareHDC(hdc, 0);
		first = false;
	}
	HGLRC hrc = wglCreateContext(hdc);
	bool bo = wglMakeCurrent(hdc, hrc);
	glClearColor(0.0, 0.0, 1.0, 1.0);
	glClearIndex( (GLfloat)16);
	glClearDepth(1.0);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); 
	glViewport(0, 0, w, h);

	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LESS);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(ReferenceAngle, 1, 1, 1000);
    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_COLOR_MATERIAL);
    glColorMaterial(GL_FRONT, GL_AMBIENT_AND_DIFFUSE);
    glShadeModel(GL_SMOOTH);
	glLightf(GL_LIGHT0, GL_SPOT_CUTOFF, 180);


	Draw(object, transform);


	glDisable(GL_DEPTH_TEST);

	glFinish(); 
	HDC hDC = wglGetCurrentDC(); 
	SwapBuffers(hDC);
	wglMakeCurrent(NULL, NULL);
	wglDeleteContext(hrc);
	glFlush();
}

void GLCamera::BeginPaint(HDC hdc)
{
	hrc = wglCreateContext(hdc);
	bool bo = wglMakeCurrent(hdc, hrc);
	glClearColor(0.0, 0.0, 1.0, 1.0);
	glClearIndex( (GLfloat)16);
	glClearDepth(1.0);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); 
	glViewport(0, 0, w, h);

	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LESS);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(ReferenceAngle, 1, 1, 1000);
    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_COLOR_MATERIAL);
    glColorMaterial(GL_FRONT, GL_AMBIENT_AND_DIFFUSE);
    glShadeModel(GL_SMOOTH);
	glLightf(GL_LIGHT0, GL_SPOT_CUTOFF, 180);
}

void GLCamera::EndPaint(HDC hdc)
{
	glDisable(GL_DEPTH_TEST);
	glFinish(); 
	HDC hDC = wglGetCurrentDC(); 
	SwapBuffers(hDC);
	wglMakeCurrent(NULL, NULL);
	wglDeleteContext(hrc);
	glFlush();

}




/*
void GLCamera::Draw(HDC hdc, char* filename)
{
	Draw(hdc);
	SaveHDC(hdc, filename, w, h);
}*/

void GLCamera::Draw(HDC hdc, bool invertY)
{
	HGLRC hrc = wglCreateContext(hdc);
	bool bo = wglMakeCurrent(hdc, hrc);
	glClearColor(0.0, 0.0, 1.0, 1.0);
	glClearIndex( (GLfloat)16);
	glClearDepth(1.0);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); 
	glViewport(0, 0, w, h);

	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LESS);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	if (invertY)
	{
		double AM[3][3] = {{1, 0, 0}, {0, -1, 0}, {0, 0, 1}};
		GLdouble m[16];
		int j;
		for (j = 0; j < 3; j++)
		{
			int k = 4 * j;
			for (int l = 0; l < 3; l++)
			{
				m[k + l] = AM[j][l];
			}
			m[k + 3] = 0;
		}
		for (j = 0; j < 3; j++)
		{
			m[j + 12] = 0;
		}
		m[15] = 1;
		glPushMatrix();
		glMatrixMode(GL_PROJECTION);
		glLoadMatrixd(m);
	}
	double min = 0;
	double max = 0;
	CalculateRange(min, max);
	if (min < 0)
	{
		min = 1;
	}
	if (max < min)
	{
		max = 2 * min;
	}
	gluPerspective(ReferenceAngle, 1, min, max);
    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_COLOR_MATERIAL);
    glColorMaterial(GL_FRONT, GL_AMBIENT_AND_DIFFUSE);
    glShadeModel(GL_SMOOTH);
	glLightf(GL_LIGHT0, GL_SPOT_CUTOFF, 180);



	Draw();

	glDisable(GL_DEPTH_TEST);

	glFinish(); 
	HDC hDC = wglGetCurrentDC(); 
	SwapBuffers(hDC);
	wglMakeCurrent(NULL, NULL);
	wglDeleteContext(hrc);
	
	glFlush();

}

void GLCamera::BeginPaint(HDC hdc, bool invertY)
{
	HGLRC hrc = wglCreateContext(hdc);
	bool bo = wglMakeCurrent(hdc, hrc);
	glClearColor(0.0, 0.0, 1.0, 1.0);
	glClearIndex( (GLfloat)16);
	glClearDepth(1.0);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); 
	glViewport(0, 0, w, h);

	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LESS);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	if (invertY)
	{
		double AM[3][3] = {{1, 0, 0}, {0, -1, 0}, {0, 0, 1}};
		GLdouble m[16];
		int j;
		for (j = 0; j < 3; j++)
		{
			int k = 4 * j;
			for (int l = 0; l < 3; l++)
			{
				m[k + l] = AM[j][l];
			}
			m[k + 3] = 0;
		}
		for (j = 0; j < 3; j++)
		{
			m[j + 12] = 0;
		}
		m[15] = 1;
		glPushMatrix();
		glMatrixMode(GL_PROJECTION);
		glLoadMatrixd(m);
	}

	double min = 0;
	double max = 0;
	CalculateRange(min, max);
	if (min < 0)
	{
		min = 1;
	}
	if (max < min)
	{
		max = 2 * min;
	}
	gluPerspective(ReferenceAngle, 1, 1, 40);
    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_COLOR_MATERIAL);
    glColorMaterial(GL_FRONT, GL_AMBIENT_AND_DIFFUSE);
    glShadeModel(GL_SMOOTH);
	glLightf(GL_LIGHT0, GL_SPOT_CUTOFF, 180);

}


void GLCamera::Draw(HDC hdc, const double * a, bool invertY)
{
	HGLRC hrc = wglCreateContext(hdc);
	bool bo = wglMakeCurrent(hdc, hrc);
	glClearColor(0.0, 0.0, 1.0, 1.0);
	glClearIndex( (GLfloat)16);
	glClearDepth(1.0);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); 
	glViewport(0, 0, w, h);

	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LESS);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	GLdouble m[16];
	if (invertY)
	{
		double AM[3][3] = {{1, 0, 0}, {0, -1, 0}, {0, 0, 1}};
		int j;
		for (j = 0; j < 3; j++)
		{
			int k = 4 * j;
			for (int l = 0; l < 3; l++)
			{
				m[k + l] = AM[j][l];
			}
			m[k + 3] = 0;
		}
		for (j = 0; j < 3; j++)
		{
			m[j + 12] = 0;
		}
		m[15] = 1;
		glPushMatrix();
		glMatrixMode(GL_PROJECTION);
		glLoadMatrixd(m);
	}
	for (int i = 0; i < 16; i++)
	{
		m[i] = a[i];
	}
	glPushMatrix();
	glMatrixMode(GL_PROJECTION);
	glLoadMatrixd(m);

	double min = 0;
	double max = 0;
	CalculateRange(min, max);
	if (min < 0)
	{
		min = 1;
	}
	if (max < min)
	{
		max = 2 * min;
	}
	gluPerspective(ReferenceAngle, 1, max, min);
    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_COLOR_MATERIAL);
    glColorMaterial(GL_FRONT, GL_AMBIENT_AND_DIFFUSE);
    glShadeModel(GL_SMOOTH);
	glLightf(GL_LIGHT0, GL_SPOT_CUTOFF, 180);


	Draw();

	glDisable(GL_DEPTH_TEST);

	glFinish(); 
	HDC hDC = wglGetCurrentDC(); 
	SwapBuffers(hDC);
	wglMakeCurrent(NULL, NULL);
	wglDeleteContext(hrc);
	
	glFlush();

}



void GLCamera::Draw()
{
	 
	
	//glEnable(GL_BLEND);
	//glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
/*	if (!Vertex::GetColored())
	{
		glEnable(GL_BLEND);
		glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
		glEnable(GL_ALPHA_TEST);
		glAlphaFunc(GL_GREATER, 0.0);
	}

*/	
	for (size_t i = 0; i < objects.size(); i++)
	{
		VisibleObject ** object = objects[i];
		EuclideanTransform & transform = *(*object)->GetVisualTransform();
		MatrixD AM(GetOrientation(transform));
		VectorD xm(transform.GetPosition(*this));
		GLdouble m[16];
		int j;
		for (j = 0; j < 3; j++)
		{
			int k = 4 * j;
			for (int l = 0; l < 3; l++)
			{
				m[k + l] = AM[j][l];
			}
			m[k + 3] = 0;
		}
		for (j = 0; j < 3; j++)
		{
			m[j + 12] = xm[j];
		}
		m[15] = 1;
		glPushMatrix();
		glMatrixMode(GL_MODELVIEW);
		glLoadMatrixd(m);
		(*object)->Draw();
		glPopMatrix();
	}
}





void GLCamera::Draw(VisibleObject & object, EuclideanTransform & transform)
{
	const MatrixD & AM = transform.GetOrientation();
	const VectorD & xm = transform.GetPosition();
	GLdouble m[16];
	int j;
	for (j = 0; j < 3; j++)
	{
		int k = 4 * j;
		for (int l = 0; l < 3; l++)
		{
			m[k + l] = AM[j][l];
		}
		m[k + 3] = 0;
	}
	for (j = 0; j < 3; j++)
	{
		m[j + 12] = xm[j];
	}
	m[15] = 1;
	glPushMatrix();
	glMatrixMode(GL_MODELVIEW);
	glLoadMatrixd(m);
	object.Draw();
	glPopMatrix();
}

void GLCamera::SetReferenceAngle(double angle)
{
	ReferenceAngle = angle;
}


void GLCamera::PrepareHDC(HDC hdc, int mode)
{
	BOOL bo = false;
	//do
	//{
		bo = bSetupPixelFormat(hdc, mode);
	//}
	//while (!bo);
}

void GLCamera::CalculateRange(double & min,	double & max)
{
	min = 0;
	max = 0;
	for (size_t i = 0; i < objects.size(); i++)
	{
		VisibleObject * object = *objects[i];
		EuclideanTransform & transform = *(object->GetVisualTransform());
		VectorD x = GetPosition(transform);
		double a = ::norm(x);
		//MultiVertexWrapper * mv = dynamic_cast<MultiVertexWrapper*>(object);
		double mi = a;
		double ma = a;
		if (true)//mv != NULL)
		{
			double s = 20;//mv->GetMaxSize();
			mi -= s;
			ma += s;
		}
		if (i == 0)
		{
			min = mi;
		}
		else if (mi < min)
		{
			min = mi;
		}
		if (ma > max)
		{
			max = ma;
		}
	}
}

void GLCamera::Draw(HDC hdc, MultiVertex * shape,	array<double> ^ state)
{
	GLdouble m[16];
	int j;
	for (j = 0; j < 16; j++)
	{
		m[j] = state[j];
	}
	glPushMatrix();
	glMatrixMode(GL_MODELVIEW);
	glLoadMatrixd(m);
	shape->Draw();
	glPopMatrix();
}

void GLCamera::Draw(HDC hdc, Reper * reper,	array<double> ^ state)
{
	GLdouble m[16];
	int j;
	for (j = 0; j < 16; j++)
	{
		m[j] = state[j];
	}
	glPushMatrix();
	glMatrixMode(GL_MODELVIEW);
	glLoadMatrixd(m);
	reper->Draw();
	glPopMatrix();
}



