// D3DFaceGL.cpp: implementation of the D3DFaceGL class.
//
//////////////////////////////////////////////////////////////////////
#include "StdAfx.h"

#include <vector>
#include "cmat.h"
#include "D3DFaceGL.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

D3DFaceGL::D3DFaceGL()
{
	color.newsize(4);
	for (int i = 0; i < 3; i++)
	{
		color[i] = 0.7;
	}
	color[3] = 1;
//	k = 0;
}

D3DFaceGL::~D3DFaceGL()
{

}

int D3DFaceGL::showNumber = 0;

int D3DFaceGL::AddVertexAndNormalIndexed(int vertex, int normal)
{
	return 0;
}

void D3DFaceGL::SetPointer(void *p)
{
	TNT::Vector<double>* v = (TNT::Vector<double>*)p;
	for (int i = 0; i < 3; i++)
	{
		vertices[i] = &v[i];
	}
}


void * D3DFaceGL::GetPointer()
{
	return vertices;
}

int D3DFaceGL::GetVertexCount()
{
	return 0;
}

TNT::Vector<double> D3DFaceGL::GetNormal()
{
	return *normal; 
}

TNT::Vector<double> D3DFaceGL::GetVertex(int i)
{
	return *vertices[i];
}

TNT::Vector<double> D3DFaceGL::GetColorV()
{
	return color;
}


void D3DFaceGL::SetColorV(const TNT::Vector<double> & v)
{
	color = v;
}

void D3DFaceGL::SetColor(double alpha, double red, double green, double blue)
{
	color[0] = red;
	color[1] = green;
	color[2] = blue;
	color[3] = alpha;
}


int D3DFaceGL::AddVertex(const TNT::Vector<double> & v)
{
	return 0;
}

void D3DFaceGL::SetNormal(const TNT::Vector<double> & v)
{
	normal = &v;
}	

void D3DFaceGL::DrawGL()
{
	if (showNumber)
	{
		glBegin(GL_POLYGON);
		const TNT::Vector<double> & n = *normal;
		glNormal3d(n[0], n[1], n[2]);
		GLint ind = colorNum[showNumber - 1];
		//glColor3b(colorNum[0], colorNum[1], colorNum[2]);
		glIndexi(ind);
		glMateriali(GL_FRONT, GL_SHININESS, ind);
		/*float mat[4];
		mat[0] = 0.5;
		mat[1] = 0.5;
		mat[2] = 0.5;
		mat[3] = color[3];
		glMaterialfv(GL_FRONT, GL_DIFFUSE, mat);*/
		for (int i = 0; i < 3; i++)
		{
			TNT::Vector<double>& v = *vertices[i];
			glVertex3d(v[0], v[1], v[2]);
		}
		glEnd();
		return;
	}
	glBegin(GL_POLYGON);
	const TNT::Vector<double> & n = *normal;
	glNormal3d(n[0], n[1], n[2]);	
	glColor4d(color[0], color[1], color[2], color[3]);
	float mat[4];
	mat[0] = (float) color[0];
	mat[1] = (float) color[1];
	mat[2] = (float) color[2];
	mat[3] = (float) color[3];
	
	glMaterialfv(GL_FRONT, GL_AMBIENT, mat);
	mat[0] = 0.5;
	mat[1] = 0.5;
	mat[2] = 0.5;
	mat[3] = (float) color[3];
	glMaterialfv(GL_FRONT, GL_DIFFUSE, mat);
	mat[0] = 0.5;
	mat[1] = 0.5;
	mat[2] = 0.5;
	mat[3] = (float) color[3];
	glMaterialfv(GL_FRONT, GL_SPECULAR, mat);
	for (int i = 0; i < 3; i++)
	{
		TNT::Vector<double>& v = *vertices[i];
		//int k = v.size();
		glVertex3d(v[0], v[1], v[2]);
	}
	glEnd();
}

void D3DFaceGL::DrawGL(const TNT::Vector<double> & shift)
{
	glBegin(GL_POLYGON);
	const TNT::Vector<double> & n = *normal;
	glNormal3d(n[0], n[1], n[2]);	
	glColor4d(color[0], color[1], color[2], color[3]);
	float mat[4];
	mat[0] = (float) color[0];
	mat[1] = (float) color[1];
	mat[2] = (float) color[2];
	mat[3] = 1.0;
	glMaterialfv(GL_FRONT, GL_AMBIENT, mat);
	mat[0] = 0.5;
	mat[1] = 0.5;
	mat[2] = 0.5;
	mat[3] = 1.0;
	glMaterialfv(GL_FRONT, GL_DIFFUSE, mat);
	mat[0] = 0.5;
	mat[1] = 0.5;
	mat[2] = 0.5;
	mat[3] = 1.0;
	glMaterialfv(GL_FRONT, GL_SPECULAR, mat);
	for (int i = 0; i < 3; i++)
	{
		TNT::Vector<double>& v = *vertices[i];
		int k = v.size();
		k = k;
		glVertex3d(v[0] + shift[0], v[1] + shift[1], v[2] + shift[2]);
	}
	glEnd();
}

void D3DFaceGL::SetNumber(unsigned int number)
{
	this->number = number;
	//int n = number + 1;
	for (int i = 0; i < 3; i++)
	{
		colorNum[i] = (number >> (7 * i)) & 0x7F;
		//colorNum[i]++;
	}
}


unsigned int D3DFaceGL::GetNumber()
{
	return number;
}

void D3DFaceGL::SetShowNumber(int sn)
{
	showNumber = sn;
}


