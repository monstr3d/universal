// This is the main DLL file.

#include "stdafx.h"

#include "MSISEAtmosphere.h"



MSISEAtmosphere::Atmosphere::Atmosphere()
{
	msise = new Msise();
	selec = gcnew array<int>(24);
	flags = new bool[24];
	output = new nrlmsise_output;
	input = new nrlmsise_input;
	input->ap_a = new ap_array;
}

MSISEAtmosphere::Atmosphere::!Atmosphere()
{
	Delete();
}

MSISEAtmosphere::Atmosphere::~Atmosphere()
{
	Delete();
}

array<int> ^ MSISEAtmosphere::Atmosphere::TSelec::get()
{
	return selec;
}
			
void MSISEAtmosphere::Atmosphere::TSelec::set(array<int> ^ value)
{
	for (int i = 0; i < 24; i++)
	{
		selec[i] = value[i];
	}
	Set();
}



void MSISEAtmosphere::Atmosphere::Calculate(int year,      /* year, currently ignored */
			int doy,       /* day of year */
			double sec,    /* seconds in day (UT) */
			double alt,    /* altitude in kilometes */
			double g_lat,  /* geodetic latitude */
			double g_long, /* geodetic longitude */
			double lst,    /* local apparent solar time (hours), see note below */
			double f107A,  /* 81 day average of F10.7 flux (centered on doy) */
			double f107,   /* daily F10.7 flux for previous day */
			double ap,     /* magnetic index(daily) */
			array<double> ^ ap_a,
			array<double> ^ d,
			array<double> ^ t)
{
	input->doy = doy;
	input->sec = sec;
	input->alt = alt;
	input->g_lat = g_lat;
	input->g_long = g_long;
	input->lst = lst;
	input->f107 = f107;
	input->f107A = f107A;
	input->ap = ap;
	for (int i = 0; i < 7; i++)
	{
		input->ap_a->a[i] = ap_a[i];
	}
	msise->gtd7(input, output);
	for (int i = 0; i < 9; i++)
	{
		d[i] = output->d[i];
	}
	for (int i = 0; i < 2; i++)
	{
		t[i] = output->t[i];
	}
}


void MSISEAtmosphere::Atmosphere::Delete()
{
	if (msise != 0)
	{
		delete msise;
		msise = 0;
		delete flags;
		delete output;
		delete input->ap_a;
		delete input;
	}
}

void MSISEAtmosphere::Atmosphere::Set()
{
	for (int i = 0; i < 24; i++)
	{
		flags[i] = selec[i];
	}
	msise->tselec(flags);
}


