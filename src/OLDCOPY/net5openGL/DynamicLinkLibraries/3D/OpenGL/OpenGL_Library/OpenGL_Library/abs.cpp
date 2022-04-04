#include "StdAfx.h"
#include <complex>

double mabs(double a)
{
	if (a < 0)
	{
		return -a;
	}
	return a;
}

double mabs(std::complex<double> a)
{
	double r = a.real();
	double i = a.imag();
	return std::sqrt(r * r + i * i);
}
