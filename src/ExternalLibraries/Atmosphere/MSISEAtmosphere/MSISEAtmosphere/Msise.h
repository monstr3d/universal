#ifndef _MSISE_H
#define _MSISE_H


class Msise
{
public:
	Msise(void);
	~Msise(void);

/* ------------------------------------------------------------------- */
/* ------------------------------- GTD7 ------------------------------ */
/* ------------------------------------------------------------------- */
	void gtd7(struct nrlmsise_input *input, 
		struct nrlmsise_flags *flags, struct nrlmsise_output *output);


/* ------------------------------------------------------------------- */
/* ------------------------------- GTD7D ----------------------------- */
/* ------------------------------------------------------------------- */
	void gtd7d(struct nrlmsise_input *input, struct nrlmsise_flags *flags, 
		struct nrlmsise_output *output);

/* ------------------------------------------------------------------- */
/* ------------------------------- GTD7 ------------------------------ */
/* ------------------------------------------------------------------- */
	void gtd7(struct nrlmsise_input *input, struct nrlmsise_output *output);


/* ------------------------------------------------------------------- */
/* ------------------------------- GTD7D ----------------------------- */
/* ------------------------------------------------------------------- */
	void gtd7d(struct nrlmsise_input *input, struct nrlmsise_output *output);


		void tselec(struct nrlmsise_flags *flags);

		void tselec(bool * flags);

				


private:
	void glatf(double lat, double *gv, double *reff);

	/*        CHEMISTRY/DISSOCIATION CORRECTION FOR MSIS MODELS
 *         ALT - altitude
 *         R - target ratio
 *         H1 - transition scale length
 *         ZH - altitude of 1/2 R
 */
	double ccor(double alt, double r, double h1, double zh);

 /*       CHEMISTRY/DISSOCIATION CORRECTION FOR MSIS MODELS
 *         ALT - altitude
 *         R - target ratio
 *         H1 - transition scale length
 *         ZH - altitude of 1/2 R
 *         H2 - transition scale length #2 ?
 */
	double ccor2(double alt, double r, double h1, double zh, double h2);

	double scalh(double alt, double xm, double temp);

	/*       TURBOPAUSE CORRECTION FOR MSIS MODELS
 *        Root mean density
 *         DD - diffusive density
 *         DM - full mixed density
 *         ZHM - transition scale length
 *         XMM - full mixed molecular weight
 *         XM  - species molecular weight
 *         DNET - combined density
 */
	double dnet (double dd, double dm, double zhm, double xmm, double xm);

	/*      INTEGRATE CUBIC SPLINE FUNCTION FROM XA(1) TO X
 *       XA,YA: ARRAYS OF TABULATED FUNCTION IN ASCENDING ORDER BY X
 *       Y2A: ARRAY OF SECOND DERIVATIVES
 *       N: SIZE OF ARRAYS XA,YA,Y2A
 *       X: ABSCISSA ENDPOINT FOR INTEGRATION
 *       Y: OUTPUT VALUE
 */
	void splini (double *xa, double *ya, double *y2a, int n, double x, double *y);

/*      CALCULATE CUBIC SPLINE INTERP VALUE
 *       ADAPTED FROM NUMERICAL RECIPES BY PRESS ET AL.
 *       XA,YA: ARRAYS OF TABULATED FUNCTION IN ASCENDING ORDER BY X
 *       Y2A: ARRAY OF SECOND DERIVATIVES
 *       N: SIZE OF ARRAYS XA,YA,Y2A
 *       X: ABSCISSA FOR INTERPOLATION
 *       Y: OUTPUT VALUE
 */
	void splint (double *xa, double *ya, double *y2a, int n, double x, double *y);

	/*       CALCULATE 2ND DERIVATIVES OF CUBIC SPLINE INTERP FUNCTION
 *       ADAPTED FROM NUMERICAL RECIPES BY PRESS ET AL
 *       X,Y: ARRAYS OF TABULATED FUNCTION IN ASCENDING ORDER BY X
 *       N: SIZE OF ARRAYS X,Y
 *       YP1,YPN: SPECIFIED DERIVATIVES AT X[0] AND X[N-1]; VALUES
 *                >= 1E30 SIGNAL SIGNAL SECOND DERIVATIVE ZERO
 *       Y2: OUTPUT ARRAY OF SECOND DERIVATIVES
 */
	void spline (double *x, double *y, int n, double yp1, double ypn, double *y2);

	double zeta(double zz, double zl);

	/*      Calculate Temperature and Density Profiles for lower atmos.  */
	double densm (double alt, double d0, double xm, double *tz, int mn3, double *zn3, 
			  double *tn3, double *tgn3, int mn2, double *zn2, double *tn2, double *tgn2);

	/*      Calculate Temperature and Density Profiles for MSIS models
 *      New lower thermo polynomial
 */
	double densu (double alt, double dlb, double tinf, double tlb, 
			  double xm, double alpha, double *tz, double zlb, double s2, int mn1, 
			  double *zn1, double *tn1, double *tgn1);

	/*    3hr Magnetic activity functions */
/*    Eq. A24d */
	double g0(double a, double *p);

	/*    Eq. A24c */
	double sumex(double ex);


/*    Eq. A24a */
	double sg0(double ex, double *p, double *ap);

/*       CALCULATE G(L) FUNCTION */

	double globe7(double *p, struct nrlmsise_input *input, struct nrlmsise_flags *flags);


	
/* ------------------------------------------------------------------- */
/* ------------------------------- GLOB7S ---------------------------- */
/* ------------------------------------------------------------------- */
/*    VERSION OF GLOBE FOR LOWER ATMOSPHERE 10/26/99 
 */
	double glob7s(double *p, struct nrlmsise_input *input, struct nrlmsise_flags *flags);


		
/* ------------------------------------------------------------------- */
/* -------------------------------- GHP7 ----------------------------- */
/* ------------------------------------------------------------------- */
	void ghp7(struct nrlmsise_input *input, struct nrlmsise_flags *flags, 
				struct nrlmsise_output *output, double press);

/* ------------------------------------------------------------------- */
/* ------------------------------- GTS7 ------------------------------ */
/* ------------------------------------------------------------------- */

	void gts7(struct nrlmsise_input *input, struct nrlmsise_flags *flags, struct nrlmsise_output *output);

    static double pt[150];
    static double pd[9][150];
    static double ps[150];
    static double pdl[2][25];
    static double ptl[4][100];
    static double pma[10][100];
    static double sam[100];

/* LOWER7 */
    static double ptm[10];
    static double pdm[8][10];
    static double pavgm[10];

//================================

/* PARMB */
     double gsurf;
     double re;

/* GTS3C */
     double dd;

/* DMIX */
     double dm04, dm16, dm28, dm32, dm40, dm01, dm14;

/* MESO7 */
     double meso_tn1[5];
     double meso_tn2[4];
     double meso_tn3[5];
     double meso_tgn1[2];
     double meso_tgn2[2];
     double meso_tgn3[2];

/* LPOLY */
     double dfa;
     double plg[4][9];
     double ctloc, stloc;
     double c2tloc, s2tloc;
     double s3tloc, c3tloc;
     double apdf, apt[4];

	nrlmsise_input input; 
	nrlmsise_flags flags;
	nrlmsise_output output;

};

#endif

