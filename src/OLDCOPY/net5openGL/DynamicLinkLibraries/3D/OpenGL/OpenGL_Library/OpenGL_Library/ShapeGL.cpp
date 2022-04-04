#include "StdAfx.h"
#include "ShapeGL.h"
#include "MultiVertex.h"

extern ID3D * d3d;

OpenGL_Library::ShapeGL::ShapeGL(void)
{
	shape = NULL;
}

OpenGL_Library::ShapeGL::~ShapeGL(void)
{
	Delete();
}

void OpenGL_Library::ShapeGL::Set(int n, array<double> ^ x)
{
	IMeshBuilder ** mb = new IMeshBuilder*;
	if (shape != NULL)
	{
		delete shape;
		shape = NULL;
	}
	double * arr = new double[x->Length];
	for (int i = 0; i < x->Length; i++)
	{
		arr[i] = x[i];
	}
	shape = new MultiVertex(n, arr, 100000000);
	delete arr;
	shape->CreatePointerMeshBuilder(d3d, mb);
	delete *mb;
	delete mb;
}

MultiVertex * OpenGL_Library::ShapeGL::GetShape()
{
	return shape;
}

void OpenGL_Library::ShapeGL::SetColor(int n, double alpha, double red, double green, double blue)
{
	shape->SetColor(n, alpha, red, green, blue);
}

void OpenGL_Library::ShapeGL::Delete()
{
	if (shape != NULL)
	{
		delete shape;
		shape = NULL;
	}

}

