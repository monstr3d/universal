// MSISEDensity.h

#pragma once

using namespace System;

class Msise;

namespace MSISEAtmosphere
{

	public ref class Atmosphere : IDisposable
	{
	public:

		Atmosphere();
		
		~Atmosphere();
		
		!Atmosphere();

	

		property array<int> ^ TSelec
		{
			array<int> ^ get();
			void set(array<int> ^ value);
		}

		void Calculate(int year,      /* year, currently ignored */
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
			array<double> ^ t);

	private:
		
		void Set();

		void Delete();

		Msise * msise;

		bool * flags;

		nrlmsise_output * output;

		nrlmsise_input * input; 
		
		array<int> ^ selec;
	};
}
