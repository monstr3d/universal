#include "stdafx.h"
#include <complex>
#include <fstream>
#include "cmat.h"
#include "lu.h"
#include "EuclideanTransform.h"
#include "Vertex.h"
#include <math.h>

#define M_PI       3.14159265358979323846

const std::complex<double> M_PI_COMPLEX = std::complex<double>(1, 0) / std::complex<double>(2 * M_PI, 0);


bool Vertex::Colored = true;

Vertex::Vertex(double* x)
{
	parent = NULL;
	proj.newsize(3);
	for (int i = 0; i < 3; i++)
	{
		relative[i].newsize(3);
	}
	Set(x);
}

Vertex::Vertex(const Vertex & v)
{
	parent = NULL;
	proj.newsize(3);
	for (int i = 0; i < 3; i++)
	{
		relative[i].newsize(3);
	}
	for (int i = 0; i < 3; i++)
	{
		vertices[i] = v.vertices[i];
	}
	Init();
}

Vertex::Vertex(const VectorD & x1, const VectorD & x2, const VectorD & x3)
{
	parent = NULL;
	proj.newsize(3);
	for (int i = 0; i < 3; i++)
	{
		relative[i].newsize(3);
	}
	vertices[0] = x1;
	vertices[1] = x2;
	vertices[2] = x3;
	Init();

}




Vertex::Vertex(ID3DFace * Face)
{
	parent = NULL;
	proj.newsize(3);
	for (int i = 0; i < 3; i++)
	{
		relative[i].newsize(3);
	}
	for (int i = 0; i < 3; i++)
	{
		vertices[i] = Face->GetVertex(i);
	}
	Init();
	face = Face;
	normD = face->GetNormal();
	double nd = sqrt(normD | normD);
	normD = normD / nd;
	for (int is = 0; is < 3; is++)
	{
		norm[is] = normD[is];
	}
}




Vertex::Vertex(double s, const VectorD & position, const VectorD & Norm)
{
        parent = NULL;
		normD = Norm;
        S = s;
		area = s;
        Position = position;
		proj.newsize(3);
}

Vertex::Vertex()
{
	parent = NULL;
	normD.newsize(3);
	Position.newsize(3);
	proj.newsize(3);
	area = 1;
	for (int i = 0; i < 3; i++)
	{
		Position[i] = 0;
	}
}

Vertex::~Vertex()
{
}


void Vertex::SetFace(ID3DFace * Face)
{
	for (int i = 0; i < 3; i++)
	{
		vertices[i] = Face->GetVertex(i);
	}
	Init();
	face = Face;
	normD = face->GetNormal();
	for (int is = 0; is < 3; is++)
	{
		norm[is] = normD[is];
	}
	ownColor = Face->GetColorV();
	parent = NULL;
}

void Vertex::ResetColor()
{
	face->SetColorV(ownColor);
}

void Vertex::Reset()
{
}



TNT::Vector<double> LColor(double a)
{

	double x = a;// + 0.5 * a * a;
	TNT::Vector<double> v(4);
	if (true)
	{
		v[0] = 0.7;
		v[1] = 0.7;
		v[2] = 0.7;
		v[3] = 1 - x;
		return v;
	}
	v[3] = 1;
	int k = int(x * 5);
	if (k < 0)
	{
		k = 0;
	}
	if (k > 4)
	{
		k = 4;
	}
	double y = 5 * (x - double(k) / 5.0);
	if (k == 0)
	{
		v[0] = 1;
		v[1] = y;
		v[2] = 0;
	}
	else if (k == 1)
	{
		v[0] = 1 - y;
		v[1] = 1;
		v[2] = 0;
	}
	else if (k == 2)
	{
		v[0] = 0;
		v[1] = 1;
		v[2] = y;
	}
	else if (k == 3)
	{
		v[0] = 0;
		v[1] = 1 - y;
		v[2] = 1;
	}
	else
	{
		v[0] = y;
		v[1] = 0;
		v[2] = 1;
	}
	return v;
}


void Vertex::Draw(double a)
{
//	double b = 0;
/*	for (int i = 0; i < 3; i++)
	{
		b += J[i].real() * J[i].real() + J[i].imag() * J[i].imag();
//		ofst << J[i] << "\t";
	}
	b = sqrt(b);
	double x = b / a;
//	ofst << x << "\t";
/*	if (x < 0.0001)
	{
		ResetColor();
		return;
	}*/
	/*sum = 0;
	double x = sqrt(sum / a);
	if (x > 1)
	{
		x = 1;
	}
	face->SetColorV(LColor(1 - x));*/
	D3DFaceGL * f = (D3DFaceGL*)face;
	face->SetColorV(ownColor);
	f->DrawGL();

}

const VectorD& Vertex::GetVertex(int i) const
{
        return vertices[i];
}

const VectorD& Vertex::GetNorm() const
{
        return normD;
}



void Vertex::LoadFromStream(std::istream& is)
{
        for (int i = 0; i < 3; i++)
        {    
			vertices[i].newsize(3);
            for (int j = 0; j < 3; j++)
            {
				is >> vertices[i][j];
            }
        }
        Init();

}


std::istream & operator >> (std::istream & is, Vertex & v)
{
        v.LoadFromStream(is);
        return is;
}



void Vertex::Init()
{
    VectorD v1(vertices[1] - vertices[0]);
    VectorD v2(vertices[2] - vertices[0]);
    VectorD v3(vertices[1] - vertices[2]);
	size = sqrt(v1 | v1);
	double a = sqrt(v2 | v2);
	if (a > size)
	{
		size = a;
	}
	a = sqrt(v3 | v3);
	if (a > size)
	{
		size = a;
	}
    Position = vertices[0] + (1.0 / 3.0) * (v1 + v2);
	for (int i = 0; i < 3; i++)
	{
		relative[i] = vertices[i] - Position;
	}
    norm = (VectorC)(v1 ^ v2);
	area = sqrt((norm | norm).real()) / 2;
	if (area < 1.0E-12)
	{
		norm = ComplexD(0);
	}
	else
	{
		norm =  ComplexD(0.5 / area) * norm;
	}
//    source = Position;
    normD.newsize(3);
    for (int i = 0; i < 3; i++)
    {
		normD[i] = norm[i].real();
    }
    parent = NULL;
    VisibleMat.newsize(3, 3);
	face = NULL;
}


void Vertex::SetVisibilityPoint(const VectorD & point)
{
        SourcePoint = point;
        for (int i = 0; i < 3; i++)
        {
                for (int j = 0; j < 3; j++)
                {
                        VisibleMat[i][j] = vertices[j][i] - point[j];
                }
        }
        VisibleMat = !VisibleMat;
        VisibleProjection = normD | vertices[0];
}

bool Vertex::isVisible(const VectorD & point)
{
        VectorD x(VisibleMat * point);
        for (int i = 0; i < 3; i++)
        {
                if (x[i] <= 0.0)
                {
                        return true;
                }
        }
        double a = (point | normD) - VisibleProjection;
        return a > 0;
}

void Vertex::ResetSum()
{
	sum = 0;
}


void Vertex::Set(double *x)
{
	for (int i = 0; i < 3; i++)
	{
		double* v = &x[3 * i];
		VectorD & vert = vertices[i];
		vertices[i].newsize(3);
		for (int j = 0; j < 3; j++)
		{
			vert[j] = v[j];
		}
	}
	Init();
}


void Vertex::SetParent(MultiVertex * Parent)
{
	parent = Parent;
}


const VectorD & Vertex::GetPosition()
{
	return Position;
}

void Vertex::SetColor(double alpha, double red, double green, double blue)
{
	VectorD & color = ownColor;
	color[0] = red;
	color[1] = green;
	color[2] = blue;
	color[3] = alpha;
}


void Vertex::SetValue(double Value)
{
	value = Value;
}

		
void Vertex::DrawValue(double min, double max)
{
	if (face == NULL)
	{
		return;
	}
	double a = (value - min) / (max - min);
	face->SetColorV(LColor(1 - a));
}



void Vertex::SetColorV(const VectorD & v)
{
	face->SetColorV(v);
}


void Vertex::SetTransitionMatrix(const MatrixD & m)
{
}

double Vertex::GetSolidAngleIntegral() const
{
	double amp = ::norm(Position);
	VectorD v[3];
	for (int i = 0; i < 3; i++)
	{
		v[i].newsize(3);
		double x = ::norm(vertices[i]);
		if (x == 0)
		{
			return 0;
		}
		v[i] = vertices[i] / ::norm(vertices[i]);
	}
	double s = ::norm((v[1] - v[0]) % (v[2] - v[0]));
	return 0.5 * s * amp;
}


std::vector<Vertex *> Vertex::barycentric()
{
	std::vector<Vertex *> v;
	VectorD center = (1.0 / 3.0) * (vertices[0] + vertices[1] + vertices[2]);
	VectorD v12 = 0.5 * (vertices[0] + vertices[1]);
	VectorD v23 = 0.5 * (vertices[1] + vertices[2]);
	VectorD v31 = 0.5 * (vertices[2] + vertices[0]);
	Vertex * v1 = new Vertex(vertices[0], v12, center);
	v.push_back(v1);
	Vertex * v2 = new Vertex(vertices[1], center, v12);
	v.push_back(v2);
	Vertex * v3 = new Vertex(vertices[1], v23, center);
	v.push_back(v3);
	Vertex * v4 = new Vertex(vertices[2], center, v23);
	v.push_back(v4);
	Vertex * v5 = new Vertex(vertices[2], v31, center);
	v.push_back(v5);
	Vertex * v6 = new Vertex(vertices[0], center, v31);
	v.push_back(v6);
	return v;
}

void Vertex::CreateCollection(double Size, std::vector<Vertex *> & collection, std::vector<Vertex *> & del)
{
	if (size < Size)
	{
		collection.push_back(this);
		return;
	}
	del.push_back(this);
	std::vector<Vertex *> v = barycentric();
	for (size_t i = 0; i < v.size(); i++)
	{
		v[i]->CreateCollection(Size, collection, del);
	}
}


