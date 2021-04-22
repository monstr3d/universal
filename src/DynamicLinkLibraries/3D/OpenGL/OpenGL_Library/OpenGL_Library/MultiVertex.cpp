//---------------------------------------------------------------------------
#include "StdAfx.h"
#include <fstream>
#include <complex>
#include <map>
#include "cmat.h"
#include "lu.h"
#include "EuclideanTransform.h"
#include "MultiVertex.h"
#include "Vertex.h"
#include "ID3DFaceArray.h"
#include "ID3D.h"
#include "IMeshBuilder.h"


//typedef std::map<Vertex*, Tetrahedron*> TetraMap;


MultiVertex::MultiVertex(ID3DFaceArray * faces)
{
	nLayersMaterials = 0;
	nVertex = faces->GetSize();
	
	std::ofstream ofs("fileN.dat");
	ofs << nVertex;
	ofs.close();
	vertices = new Vertex*[nVertex];
	for (int i = 0; i < nVertex; i++)
	{
		vertices[i] = new Vertex();
		ID3DFace * face;
		faces->GetElement(i, &face);
		vertices[i]->SetFace(face);
	}
	CalculateVisibility();
}

MultiVertex::MultiVertex(const char * filename, int nh, int nb, int ne)
{
        nLayersMaterials = 0;
		std::ifstream ifs;
		ifs.open(filename);
        char c[1000];
        nVertex = 0;
        do
        {
                ifs.getline(c, 999);
                nVertex++;
        }
        while (ifs);
        ifs.close();
        nVertex -= nh;
        vertices = new Vertex*[nVertex];
		std::ifstream input;
        input.open(filename);
        for (int i = 0; i < nh; i++)
        {
                input.getline(c, 999);
        }
		double a;
        for (int is = 0; is < nVertex; is++)
        {
				vertices[is] = new Vertex();
                for (int j = 0; j < nb; j++)
                {
                        input >> a;
                }
                input >> *vertices[is];
                vertices[is]->index = is;
				vertices[is]->parent = this;
                for (int js = 0; js < ne; js++)
                {
                        input >> a;
                }
        }
        CalculateVisibility();
}


bool MultiVertex::GetVisibility(int i, int j) const
{
        return (j < i) ? visibility[i][j] : visibility[j][i];
}

void MultiVertex::SetVisibility(int i, int j, bool v)
{
        if (j > i)
        {
                visibility[j][i] = v;
        }
        else
        {
                visibility[i][j] = v;
        }
}

void MultiVertex::ResetExternalVisibility()
{
	for (int i = 0; i < nVertex; i++)
	{
		externalVisibility[i] = false;
	}
}

void MultiVertex::SetExternalVisibility(int i, bool visible)
{
	if (i < 0 || i >= nVertex)
	{
		return;
	}
	externalVisibility[i] = visible;
}

double MultiVertex::GetVertexDistance(EuclideanTransform & transform, int i)
{
	VectorD x = transform.GetPosition(*this);
	Vertex & v = *vertices[i];
	x = x - v.Position;
	return ::norm(x);
}


void MultiVertex::CalculateVisibility()
{
		externalVisibility = new bool[nVertex];
        visibility = new bool*[nVertex];
		return;
 /*       for (int i = 0; i < nVertex; i++)
        {
                visibility[i] = new bool[i + 1];
                visibility[i][i] = false;
               for (int j = 0; j < i; j++)
                {
                        Vertex& v1 = *vertices[i];
                        Vertex& v2 = *vertices[j];
                        VectorD diff(v2.GetSource() - v1.GetSource());
                        double a1 = diff | v1.GetNorm();
                        double a2 = diff | v2.GetNorm();
                        if (a2 != 0)
                        {
                                a1 = a1;
                        }
                        visibility[i][j] = a1 > 0 && a2 < 0;
                }
        }
        for (int is = 0; is < nVertex; is++)
        {
                const Vertex & vi = *vertices[is];
                for (int j = 0; j < nVertex; j++)
                {
                        if (!GetVisibility(is, j))
                        {
                                continue;
                        }
                        Vertex& vj = *vertices[j];
                        vj.SetVisibilityPoint(vi.GetSource());
                        for (int k = 0; k < is; k++)
                        {
                                const Vertex & vk = *vertices[k];
                                if (visibility[is][k])
                                {
                                        continue;
                                }
                                if (!vj.isVisible(vk.GetSource()))
                                {
                                        visibility[is][k] = false;
                                }
                        }
                }
        }*/
}


int MultiVertex::GetVertexQuantity() const
{
        return nVertex;
}

void MultiVertex::SetColor(int n, double alpha, double red, double green, double blue)
{
	Vertex & v = *(vertices[n]);
	v.SetColor(alpha, red, green, blue);
}

void MultiVertex::CalculateMaxSize()
{
	for (int i = 0; i < nVertex; i++)
	{
		Vertex & v1 = *(vertices[i]);
		for (int j = 0; j < nVertex; j++)
		{
			Vertex & v2 = *vertices[j];
			for (int k = 0; k < 3; k++)
			{
				VectorD & x1 = v1.vertices[k];
				for (int l = 0; l < 3; l++)
				{
					VectorD & x2 = v2.vertices[l];
					double a = ::norm(x1 - x2);
					if (size < a)
					{
						size = a;
					}
				}
			}
		}
	}

}

double MultiVertex::GetMaxSize()
{
	return size;
}

void MultiVertex::Draw()
{
	if (vertices[0]->face == NULL)
	{
		return;
	}
	double a = 1;
/*
	for (int i = 0; i < nVertex; i++)
	{
		/*if (!externalVisibility[i])
		{
			continue;
		}
		double b = vertices[i]->sum;
		if (b > a)
		{
			a = b;
		}
	}*/

	for (int j = 0; j < nVertex; j++)
	{
		Vertex & ev = *vertices[j];
		double b = ev.sum;
		/*if (!externalVisibility[j])
		{
			ev.ResetColor();
		}
		else
		{
			//ev.Draw(a);
		}*/
		ev.ResetColor();
		
		ev.Draw(a);

		//ev.Draw(a);

		//if (externalVisibility[j])
		//{
		//}
		//else
		//{
		//}
	}

}

void MultiVertex::ResetColor()
{
	if (vertices[0]->face == NULL)
	{
		return;
	}
	for (int i = 0; i < nVertex; i++)
	{
		vertices[i]->ResetColor();
	}

}


void MultiVertex::ResetSum()
{
	for (int i = 0; i < nVertex; i++)
	{
		vertices[i]->ResetSum();
	}

}

void MultiVertex::AddSquare()
{
/*	for (int i = 0; i < nVertex; i++)
	{
		vertices[i]->AddSquare();
	}*/

}

void MultiVertex::GetData(double * x)
{
	for (int i = 0; i < nVertex; i++)
	{
		double * y = &x[12 * i];
		Vertex & v = *vertices[i];
		for (int j = 0; j < 3; j++)
		{
			double * z = &y[3 * j];
			const VectorD & vec = v.GetVertex(j);
			for (int k = 0; k < 3; k++)
			{
				z[k] = vec[k];
			}
		}
		for (int l = 9; l < 12; l++)
		{
			y[l] = 0;
		}
	}
}

void MultiVertex::GetMaterials(int * x)
{
	for (int i = 0; i < nVertex; i++)
	{
		Vertex & v = *vertices[i];
		x[i] = v.materialNumber;
	}
}



MultiVertex::MultiVertex(int n)
{
	nLayersMaterials = 0;
	nEdgesTypes = 0;
	nEdges = 0;
	nVertex = n;
	vertices = new Vertex*[n];
	externalVisibility = new bool[n];
	for (int i = 0; i < n; i++)
	{
		vertices[i] = new Vertex();
		vertices[i]->parent = this;
	}
}

MultiVertex::MultiVertex(std::vector<MultiVertex *> & vect)
{
	nLayersMaterials = 0;
	nEdgesTypes = 0;
	nEdges = 0;
	nVertex = 0;
	for (size_t i = 0; i < vect.size(); i++)
	{
		nVertex += vect[i]->nVertex;
	}
	int l = 0;
//	double min[3], max[3];
	externalVisibility = new bool[nVertex];
//	double a;
	vertices = new Vertex*[nVertex];
	int vn = 0;
	EuclideanTransform t;
	for (size_t i = 0; i < vect.size(); i++)
	{
		MultiVertex & mv = *vect[i];
		t.SetRelative(mv, *this);
		for (int nv = 0; nv < mv.nVertex; nv++)
		{
			vertices[vn] = new Vertex();
			Vertex & v = *vertices[vn];
			Vertex & vp = *mv.vertices[nv];
			for (int j = 0; j < 3; j++)
			{
				TNT::Vector<double> & x = v.vertices[j];
				x.newsize(3);
				TNT::Vector<double> & y = vp.vertices[j];
				x = t.Transform(y);
			}
			v.Init();
			v.parent = this;
			vn++;
		}
	}
	CalculateFacetSize();
}

MultiVertex::MultiVertex(const MultiVertex & mv, double Size)
{
	std::vector<Vertex *> collection;
	std::vector<Vertex *> del;
	Vertex ** vert = new Vertex*[mv.nVertex];
	for (int i = 0; i < mv.nVertex; i++)
	{
		vert[i] = new Vertex(*mv.vertices[i]);
	}
	for (int i = 0; i < mv.nVertex; i++)
	{
		vert[i]->CreateCollection(Size, collection, del);
	}
	for (size_t i = 0; i < del.size(); i++)
	{
		delete del[i];
	}
	nVertex = collection.size();
	vertices = new Vertex*[nVertex];
	for (int i = 0; i < nVertex; i++)
	{
		vertices[i] = collection[i];
		Vertex & v = *vertices[i];
		v.Init();
		v.parent = this;
	}
	CalculateFacetSize();
}

MultiVertex::MultiVertex(const MultiVertex & mv, bool mode)
{
	std::vector<Vertex *> collection;
	for (int i = 0; i < mv.nVertex; i++)
	{
		std::vector<Vertex *>	v = mv.vertices[i]->barycentric();
		for (size_t j = 0; j < v.size(); j++)
		{
			collection.push_back(v[j]);
		}
	}
	nVertex = collection.size();
	vertices = new Vertex*[nVertex];
	for (int i = 0; i < nVertex; i++)
	{
		vertices[i] = collection[i];
		Vertex & v = *vertices[i];
		v.Init();
		v.parent = this;
	}
	CalculateFacetSize();
}



MultiVertex::~MultiVertex()
{
	int n = GetVertexQuantity();
	for (int i = 0; i < n; i++)
	{
		delete vertices[i];
	}
	delete vertices;
}


void MultiVertex::CreateMeshBuilder(ID3D *d3d, IMeshBuilder **builder)
{
	IMeshBuilder *b;
	d3d->CreateMeshBuilder(&b);
	*builder = b;
	for (int i = 0; i < nVertex; i++)
	{
		Vertex& v = *vertices[i];
		ID3DFace *face;
		b->CreateFace(&face);
		face->SetNumber(i);
		for (int j = 0; j < 3; j++)
		{
			TNT::Vector<double> & x = v.vertices[j];
			face->AddVertex(x);
		}
		face->SetNormal(v.normD);
		v.face = face;
		v.ownColor = face->GetColorV();
		v.ResetColor();
		v.ResetSum();
		v.parent = NULL;
	}
}

void MultiVertex::CreatePointerMeshBuilder(ID3D *d3d, IMeshBuilder **builder)
{
	IMeshBuilder *b;
	d3d->CreateMeshBuilder(&b);
	*builder = b;
	for (int i = 0; i < nVertex; i++)
	{
		Vertex& v = *vertices[i];
		ID3DFace *face;
		b->CreateFace(&face);
		face->SetNumber(i + 1);
		for (int j = 0; j < 3; j++)
		{
			TNT::Vector<double> & x = v.vertices[j];
			face->SetPointer(v.vertices);
		}
		face->SetNormal(v.normD);
		v.face = face;
		v.ownColor = face->GetColorV();
		v.parent = NULL;
	}
}



void MultiVertex::SaveToFile(const char *filename)
{
	std::ofstream ofs(filename);
	ofs << nVertex << "\n";
	for (int i = 0; i < nVertex; i++)
	{
		Vertex & v = *vertices[i];
		for (int j = 0; j < 3; j++)
		{
			TNT::Vector<double> & x = v.vertices[j];
			for (int k = 0; k < 3; k++)
			{
				ofs << x[k] << " ";
			}
		}
		TNT::Vector<double> & x = v.normD;
		for (int k = 0; k < 3; k++)
		{
			ofs << x[k] << " ";
		}
		ofs << "\n";
	}
	ofs << nVertex << "\n";
	ofs.close();
}

MultiVertex::MultiVertex(const char *filename)
{
	nLayersMaterials = 0;
	nEdgesTypes = 0;
	nEdges = 0;
	std::ifstream ifs(filename);
	ifs >> nVertex;
	double min[3], max[3];
	externalVisibility = new bool[nVertex];
	double a;
	vertices = new Vertex*[nVertex];
	for (int i = 0; i < nVertex; i++)
	{
		vertices[i] = new Vertex();
		Vertex & v = *vertices[i];
		for (int j = 0; j < 3; j++)
		{
			TNT::Vector<double> & x = v.vertices[j];
			x.newsize(3);
			for (int k = 0; k < 3; k++)
			{
				ifs >> a;
				x[k] = a;
				if (!i)
				{
					min[k] = a;
					max[k] = a;
				}
				else
				{
					if (a < min[k])
					{
						min[k] = a;
					}
					if (a > max[k])
					{
						max[k] = a;
					}
				}
			}
		}
		TNT::Vector<double> & x = v.normD;
		x.newsize(3);
		for (int k = 0; k < 3; k++)
		{
				ifs >> a;
				x[k] = a;
		}
		v.Init();
	}
	ifs.close();
}

MultiVertex::MultiVertex(int n, const double *X, double size)
{
	nVertex = n;
	nEdgesTypes = 0;
	nEdges = 0;
	int l = 0;
	double min[3], max[3];
	externalVisibility = new bool[nVertex];
	double a;
	vertices = new Vertex*[nVertex];
	for (int i = 0; i < nVertex; i++)
	{
		vertices[i] = new Vertex();
		Vertex & v = *vertices[i];
		for (int j = 0; j < 3; j++)
		{
			TNT::Vector<double> & x = v.vertices[j];
			x.newsize(3);
			for (int k = 0; k < 3; k++)
			{
				a = X[l];
				x[k] = a;
				l++;
				if (!i)
				{
					min[k] = a;
					max[k] = a;
				}
				else
				{
					if (a < min[k])
					{
						min[k] = a;
					}
					if (a > max[k])
					{
						max[k] = a;
					}
				}
			}
		}
		TNT::Vector<double> & x = v.normD;
		x.newsize(3);
		for (int k = 0; k < 3; k++)
		{
			a = X[l];
			x[k] = a;
			l++;
		}
		v.Init();
		v.parent = this;
	}
	CalculateFacetSize();
	if (size < 0)
	{
		//CalculateMaxSize();
		this->size = 20;
	}
	else
	{
		this->size = size;
	}
}

void MultiVertex::SetSize(double size)
{
	this->size = size;
}

		
MultiVertex::MultiVertex(int n,	int nm,	const int * materials, const double * X, double size)
{
	nVertex = n;
	this->size = size;
	int l = 0;
	double min[3], max[3];
	nLayersMaterials = nm;
	nEdgesTypes = 0;
	nEdges = 0;
	externalVisibility = new bool[nVertex];
	double a;
	vertices = new Vertex*[nVertex];
	for (int i = 0; i < nVertex; i++)
	{
		int mat = materials[i];
		if (mat < 0)
		{
			vertices[i] = new Vertex();
			vertices[i]->materialNumber = -1;
		}
		else
		{
		}
		Vertex & v = *vertices[i];
		for (int j = 0; j < 3; j++)
		{
			TNT::Vector<double> & x = v.vertices[j];
			x.newsize(3);
			for (int k = 0; k < 3; k++)
			{
				a = X[l];
				x[k] = a;
				l++;
				if (!i)
				{
					min[k] = a;
					max[k] = a;
				}
				else
				{
					if (a < min[k])
					{
						min[k] = a;
					}
					if (a > max[k])
					{
						max[k] = a;
					}
				}
			}
		}
		TNT::Vector<double> & x = v.normD;
		x.newsize(3);
		for (int k = 0; k < 3; k++)
		{
			a = X[l];
			x[k] = a;
			l++;
		}
		MatrixD trans(3, 3);
		for (int k = 0; k < 3; k++)
		{
			for (int p = 0; p < 3; p++)
			{
				a = X[l];
				trans[k][p] = a;
				++l;
			}
		}
		v.SetTransitionMatrix(trans);
		v.Init();
		v.parent = this;
	}
}

MultiVertex::MultiVertex(int n, int nm, int NEdges, int net, const int * materials, const int * edgesTypes, 
	const double * facetsData, const double * edgesData)
{
	nVertex = n;
	int l = 0;
	double min[3], max[3];
	nLayersMaterials = nm;
	nEdgesTypes = net;
	nEdges = NEdges;
	externalVisibility = new bool[nVertex];
	double a;
	vertices = new Vertex*[nVertex];
	for (int i = 0; i < nVertex; i++)
	{
		int mat = materials[i];
		if (mat < 0)
		{
			vertices[i] = new Vertex();
			vertices[i]->materialNumber = - 1;
		}
		Vertex & v = *vertices[i];
		for (int j = 0; j < 3; j++)
		{
			TNT::Vector<double> & x = v.vertices[j];
			x.newsize(3);
			for (int k = 0; k < 3; k++)
			{
				a = facetsData[l];
				x[k] = a;
				l++;
				if (!i)
				{
					min[k] = a;
					max[k] = a;
				}
				else
				{
					if (a < min[k])
					{
						min[k] = a;
					}
					if (a > max[k])
					{
						max[k] = a;
					}
				}
			}
		}
		TNT::Vector<double> & x = v.normD;
		x.newsize(3);
		for (int k = 0; k < 3; k++)
		{
			a = facetsData[l];
			x[k] = a;
			l++;
		}
		MatrixD trans(3, 3);
		for (int k = 0; k < 3; k++)
		{
			for (int p = 0; p < 3; p++)
			{
				a = facetsData[l];
				trans[k][p] = a;
				++l;
			}
		}
		v.SetTransitionMatrix(trans);
		v.Init();
		v.parent = this;
	}
}


Vertex & MultiVertex::operator[](int i)
{
	return *vertices[i];
}

void MultiVertex::DrawValue(double min, double max)
{
	if (min == max)
	{
		return;
	}
	int n =	GetVertexQuantity();
	for (int i = 0; i < n; i++)
	{
		vertices[i]->DrawValue(min, max);
	}
}


void MultiVertex::CalculateFacetSize()
{
	int n =	GetVertexQuantity();
	facetSize = 0;
	for (int i = 0; i < n; i++)
	{
		double a = vertices[i]->size;
		if (a > facetSize)
		{
			facetSize = a;
		}
	}

}

double MultiVertex::GetFacetSize()
{
	return facetSize;
}

double MultiVertex::GetSolidAngleIntegral() const
{
	int n = GetVertexQuantity();
	double integral = 0;
	for (int i = 0; i < n; i++)
	{
		Vertex *v = vertices[i];
		integral += v->GetSolidAngleIntegral();
	}
	return integral;
}


