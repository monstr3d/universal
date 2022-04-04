// MeshBuilderGL.cpp: implementation of the MeshBuilderGL class.
//
//////////////////////////////////////////////////////////////////////

#include "StdAfx.h"
#include "D3DGL.h"
#include "GLHelp.h"
#include "cmat.h"
#include "EuclideanTransform.h"
#include "VisibleObject.h"
#include "MeshBuilderGL.h"
#include "D3DFaceGL.h"




//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

MeshBuilderGL::MeshBuilderGL()
{

}

MeshBuilderGL::~MeshBuilderGL()
{

}


void MeshBuilderGL::SetPointer(void * p)
{
}

void* MeshBuilderGL::GetPointer()
{
	return NULL;
}

void MeshBuilderGL::AddVisual(IMeshBuilder * mb)
{
}

void MeshBuilderGL::Release()
{
	for (size_t i = 0; i < faces.size(); i++)
	{
		delete faces[i];
	}
}

void MeshBuilderGL::SetPerspective(bool p)
{
}

void MeshBuilderGL::Load(const char* filename)
{
}

int MeshBuilderGL::AddFrame(ID3DFrame * frame)
{
	return 0;
}

int MeshBuilderGL::AddVertex(double x, double y, double z)
{
	return 0;
}

int MeshBuilderGL::AddNormal(double x, double y, double z)
{
	return 0;
}

int MeshBuilderGL::CreateFace(ID3DFace ** face)
{
	D3DFaceGL * f = new D3DFaceGL();
	faces.push_back(f);
	*face = f;
	return 0;
}

int MeshBuilderGL::GetFaces(ID3DFaceArray ** faces)
{
	return 0;
}

void MeshBuilderGL::DrawGL()
{
	for (size_t i = 0; i < faces.size(); i++)
	{
		faces[i]->DrawGL();
	}
}

void MeshBuilderGL::Draw()
{
	DrawGL();
}

void MeshBuilderGL::Draw(HDC hdc, EuclideanTransform & transform, int showNumber, int w, int h, int * order, double size)
{
	HGLRC hrc = wglCreateContext(hdc);
	bool bo = wglMakeCurrent(hdc, hrc);
	glClearColor(0.0, 0.0, 0.0, 0.0);
	glClearIndex( (GLfloat)16);
	glClearDepth(1.0);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); 
	glViewport(0, 0, w, h);

	GLdouble m[16];
	
	VectorD z = -transform.GetPosition(*frame);
	z = z / ::norm(z);
	double yy[] = {0, 1, 0};
	double zzz[3];
	for (int i = 0; i < 3; i++)
	{
		zzz[i] = z[i];
	}
	if (fabs(z[1]) > 0.9)
	{
		yy[2] = 1;
		yy[1] = 0;
	}
	VectorD y(3, yy);
	VectorD x = y % z;
	x = x / ::norm(x);
	y = z % x;
	VectorD * xyz[] = {&x, &y, &z};
	for (int i = 0; i < 3; i++)
	{
		const VectorD & v = *xyz[i];
		int k = 4 * i;
		for (int j = 0; j < 3; j++)
		{
			m[4 * j + i] = v[j];
		}
		m[k + 3] = 0;//zz[i];
	}
	for (int j = 0; j < 3; j++)
	{
		m[j + 12] = 0;
	}
	m[15] = 1;

	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glPushMatrix();
	glLoadMatrixd(m);
	glOrtho(-size, size, -size, size, size, -size); 
    glEnable(GL_COLOR_MATERIAL);
    glColorMaterial(GL_FRONT, GL_SHININESS);

	D3DFaceGL::SetShowNumber(showNumber + 1);
	size_t n = faces.size();
	for (size_t i = 0; i < n; i++)
	{
		faces[order[i]]->DrawGL();
	}

	D3DFaceGL::SetShowNumber(0);

	glFinish(); 
	HDC hDC = wglGetCurrentDC(); 
	SwapBuffers(hDC);
	wglMakeCurrent(NULL, NULL);
	wglDeleteContext(hrc);
	glFlush();

}


EuclideanTransform * MeshBuilderGL::GetVisualTransform()
{
	return frame;
}
	
void MeshBuilderGL::SetTransform(EuclideanTransform * Frame)
{
	frame = Frame;
}
