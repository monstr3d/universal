#include "StdAfx.h"
#include <complex>
#include "cmat.h"
#include "EuclideanTransform.h"


EuclideanTransform::EuclideanTransform() : A(3, 3), AT(3, 3), x(3), V(3), Om(3)
{
	for (int i = 0; i < 3; i++)
	{
		A[i][i]  = 1.0;
		AT[i][i] = 1.0;
	}
}

EuclideanTransform::~EuclideanTransform()
{
	int a = 0;
	a *= a;
}

void EuclideanTransform::SetState(const MatrixD & a, const VectorD & X)
{
        A = a;
        x = X;
        AT = TNT::transpose(a);
}

void EuclideanTransform::SetStateVector(const MatrixD & a, const VectorD & X, 
										const VectorD & v, const VectorD & om)
{
        A = a;
        x = X;
        AT = TNT::transpose(a);
		V = v;
		Om = om;
}

void EuclideanTransform::SetVector(const VectorD & X)
{
        x = X;
}

void EuclideanTransform::SetMatrix(const MatrixD & a)
{
        A = a;
        AT = TNT::transpose(a);
}

const VectorD  EuclideanTransform::Transform(const VectorD & y) const
{
		/*=========================
		//!!! Unfinished code 
		double aaa[3][3];
		double aaat[3][3];
		double xxx[3];
		double yyy[3];
		double zzz[3];
		VectorD z = A * y + x;
		for (int i = 0; i < 3; i++)
		{
			xxx[i] = x[i];
			yyy[i] = y[i];
			zzz[i] = z[i];
			for (int j = 0; j < 3; j++)
			{
				aaa[i][j] = A[i][j];
				aaat[i][j] = AT[i][j];
			}

		}
		//======================*/
	return A * y + x;
}

const VectorD  EuclideanTransform::InverseTransform(const VectorD & y) const
{

		/*=========================
		//!!! Unfinished code 
		double aaa[3][3];
		double aaat[3][3];
		double xxx[3];
		double yyy[3];
		double zzz[3];
		VectorD z = AT * (y - x);
		for (int i = 0; i < 3; i++)
		{
			xxx[i] = x[i];
			yyy[i] = y[i];
			zzz[i] = z[i];
			for (int j = 0; j < 3; j++)
			{
				aaa[i][j] = A[i][j];
				aaat[i][j] = AT[i][j];
			}

		}
		//======================*/
        return AT * (y - x);
}

const VectorD EuclideanTransform::RepresentX(const EuclideanTransform & e1, const EuclideanTransform & e2) const
{
	return e1.A * (e2.x - e1.x);
}

const VectorD EuclideanTransform::RepresentV(const EuclideanTransform & e1, const EuclideanTransform & e2) const
{
	return e1.A * (e2.V - e1.V);
}

const VectorD EuclideanTransform::RepresentOm(const EuclideanTransform & e1, const EuclideanTransform & e2) const
{
	return e1.A * (e2.Om - e1.Om);
}

const VectorD  EuclideanTransform::LinAcceleration (const VectorD & f1, const VectorD & f2)const
{
	return f1 + A * f2;
}
const VectorD  EuclideanTransform::AngAcceleration (const VectorD & m1, const VectorD & m2)const
{
	return (A * m1 + m2);
}
const VectorC EuclideanTransform::Rotate(const VectorC & y) const
{
        return A * y;
}


const VectorD EuclideanTransform::Rotate(const VectorD & y) const
{
		return A * y;
}

const VectorC EuclideanTransform::InverseRotate(const VectorC & y) const
{
        return AT * y;
}

const VectorD EuclideanTransform::InverseRotate(const VectorD & y) const
{
        return AT * y;
}


MatrixD EuclideanTransform::GetOrientation(const EuclideanTransform& e)
{
/*========================================
double aaa[9];
	double aaat[9];
	for (int i = 0; i < 3; i++)
	{
		int k = 3 * i;
		for (int j = 0; j < 3; j++)
		{
			int l = k + j;
			aaa[l] = A[i][j];
			aaat[l] = e.AT[i][j];
		}
	}
	=====================================*/
	return e.AT * A;
}

VectorD EuclideanTransform::GetPosition(const EuclideanTransform& e)
{
	return e.AT * (x - e.x);
}

VectorD EuclideanTransform::GetVelocity(const EuclideanTransform& e)
{
	return e.AT * (V - e.V);
}

VectorD EuclideanTransform::GetAngularVelocity(const EuclideanTransform& e)
{
	return e.AT * (Om - e.Om);
}


void EuclideanTransform::SetOrientation(const EuclideanTransform& e, const MatrixD & m)
{
	A = e.A * m;
	AT = ~A;
}

void EuclideanTransform::SetPosition(const EuclideanTransform& e, const VectorD & v)
{
	x = e.AT * v;
}


const MatrixD & EuclideanTransform::GetOrientation()
{
	return A;
}

const VectorD & EuclideanTransform::GetPosition()
{
	return x;
}

const VectorD & EuclideanTransform::GetVelocity()
{
	return V;
}

const VectorD & EuclideanTransform::GetAngularVelocity()
{
	return Om;
}

int  EuclideanTransform::GetVectorCount() const 
{
	return 3;
}

TNT::Vector<double> EuclideanTransform::GetVector(int i) const
{
	return A.Column(i);
}


void EuclideanTransform::SetRelative(const EuclideanTransform &relative, const EuclideanTransform &base)
{
	A  = base.AT * relative.A;
	AT = ~A;
	x  = base.AT * (relative.x - base.x);
	/*=================================
	double b[3];
	double xxx[3];
	double r[3];
	double a[9];
	for (int i = 0; i < 3; i++)
	{
		b[i] = base.x[i];
		r[i] = relative.x[i];
		xxx[i] = x[i];
		for (int j = 0; j < 3; j++)
		{
			a[3 * i + j] = base.AT[i][j];
		}
	}
	long nnn = (long)this;
	a[0] = a[0];
	//=========================*/
}

void EuclideanTransform::SetAbsolute(const EuclideanTransform &relative, const EuclideanTransform &base)
{
	/*===============================
	double a[3], b[3], c[3];
	for (int i = 0; i < 3; i++)
	{
		a[i] = x[i];
		b[i] = base.x[i];
		c[i] = relative.x[i];
	}
	long nnn = (long)this;
	a[0] = a[0];
	//===============================*/

	A  = base.A * relative.A;
	AT = ~A;
	x  = base.x + base.A * relative.x;
	Om = base.Om + base.A * relative.Om;
	VectorD dV(base.Om % relative.x);
	V = base.V + base.A * (relative.V + dV);
	/*===============================
	for (int i = 0; i < 3; i++)
	{
		a[i] = x[i];
		b[i] = base.x[i];
		c[i] = relative.x[i];
	}
	a[0] = a[0];
	//===============================*/

}

void EuclideanTransform::SetRelativeState(const MatrixD & matrix, const VectorD & vector, const EuclideanTransform & base)
{
	VectorD vt(base.AT * (vector - base.x));
	SetState(matrix, vt);
}

void EuclideanTransform::SetRelativeState(const MatrixD & matrix, const VectorD & r, 
										  const VectorD & v, const VectorD & om, const EuclideanTransform & base)
{
	VectorD xt(base.AT * (r - base.x));
	VectorD vt(base.AT * (v - base.V));
	VectorD ot(base.AT * (om - base.Om));
	this->SetStateVector(matrix, xt, vt, ot);
}

VectorC operator^(const VectorC & x, const VectorC & y)
{
        VectorC z(3);
        z(1) = x(2) * y(3) - x(3) * y(2);
        z(2) = x(3) * y(1) - x(1) * y(3);
        z(3) = x(1) * y(2) - x(2) * y(1);
        return z;
}



VectorC operator^(const VectorD & x, const VectorC & y)
{
        VectorC z(3);
        z(1) = ComplexD(x(2)) * y(3) - ComplexD(x(3)) * y(2);
        z(2) = ComplexD(x(3)) * y(1) - ComplexD(x(1)) * y(3);
        z(3) = ComplexD(x(1)) * y(2) - ComplexD(x(2)) * y(1);
        return z;
}

VectorC operator^(const VectorC & x, const VectorD & y)
{
        VectorC z(3);
        z(1) = x(2) * ComplexD(y(3)) - x(3) * ComplexD(y(2));
        z(2) = x(3) * ComplexD(y(1)) - x(1) * ComplexD(y(3));
        z(3) = x(1) * ComplexD(y(2)) - x(2) * ComplexD(y(1));
        return z;
}

VectorC operator^(const VectorD & x, const VectorD & y)
{
        VectorC z(3);
        z(1) = x(2) * y(3) - x(3) * y(2);
        z(2) = x(3) * y(1) - x(1) * y(3);
        z(3) = x(1) * y(2) - x(2) * y(1);
        return z;
}


double norm(const VectorC & x)
{
        double a = 0;
        for (int i = 0; i < x.size(); i++)
        {
                a += x[i].real() * x[i].real() + x[i].imag() * x[i].imag();
        }
        return sqrt(a);
}

double norm(const VectorD & x)
{
        double a = 0;
        for (int i = 0; i < x.size(); i++)
        {
                a += x[i] * x[i];
        }
        return sqrt(a);
}

VectorD operator%(const VectorD & x, const VectorD & y)
{
        VectorD z(3);
		z[0] = x[1] * y[2] - x[2] * y[1];
        z[1] = x[2] * y[0] - x[0] * y[2];
        z[2] = x[0] * y[1] - x[1] * y[0];
        return z;
}

ComplexD operator % (const VectorC & x, const VectorC & y)
{
	ComplexD a = 0;
	for (int i = 0; i < x.size(); i++)
	{
		ComplexD b(y[i].real(), -y[i].imag());
		a += x[i] * b;
	}
	return a;
}

double Angle(const VectorD & x, const VectorD & y)
{
	double a = (x | x) * (y | y);
	a = sqrt(a);
	double b = x | y;
	return acos(b / a);
}

ComplexD operator|(const VectorD & x, const VectorC & y)
{
	ComplexD a(0.);
	for (int i = 0; i < x.size(); i++)
	{
		a += ComplexD(x[i]) * y[i];
	}
	return a;
}
VectorD EuclideanTransform::GetOwnAngularVelocity(void)
{
	return AT * Om;
}
