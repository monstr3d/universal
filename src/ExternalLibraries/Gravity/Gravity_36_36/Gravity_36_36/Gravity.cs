using System;
using System.Collections.Generic;

namespace Gravity_36_36
{
    /// <summary>
    /// Gravity field
    /// </summary>
    public class Gravity
    {
        #region Fields

        protected double[] R = new double[3];

        protected double[] C = new double[700];

        protected double[] S = new double[700];

        protected double[] HP = new double[37];

        protected double[] CO = new double[37];

        protected double[] SI = new double[37];

        protected double[] AR = new double[37];

        protected double[] CF = new double[37];

        protected double[] PNK = new double[37];

        protected double[] ANAI = new double[478];

        static private readonly double[] SK = new double[]
        {
            1.732050807568877E0,  1.936491673103709E0,2.091650066335189E0,
            2.218529918662356E0,  2.326813808623286E0,2.421824596249695E0,
            2.506826616960176E0,  2.583977731709147E0,2.654784752117980E0,
            2.720344864917320E0,  2.781483843970261E0,2.838840060634283E0,
            2.892918063839265E0,  2.944124128779573E0,2.992790634483277E0,
            3.039193256447120E0,  3.083563388216997E0,3.126097306274296E0,
            3.166963057815222E0,  3.206305722292480E0,3.244251489527417E0,
            3.280910862053330E0,  3.316381199514726E0,3.350748761981671E0,
            3.384090366884451E0,  3.416474744628894E0,3.447963656780269E0,
            3.478612825366963E0,  3.508472710600489E0,3.537589165949811E0,
            3.566003993231045E0,  3.593755415611321E0,3.620878482777667E0,
            3.647405419702514E0,  3.673365928240249E0,3.698787449063569E0
        };

        protected int n0;

        protected int nk;

        protected string[] inp;

        protected int pos;

        const double ret = 0;

        /// <summary>
        /// Inputs
        /// </summary>
        static private readonly string[] inps = new string[] { "x", "y", "z" };

        /// <summary>
        /// Outputs
        /// </summary>
        static private readonly string[] outs = new string[] { "Gx", "Gy", "Gz" };

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public Gravity()
        {

        }

        #endregion

        #region Members

        #region Public Members

        /// <summary>
        /// Degree of Legendre polynomial
        /// </summary>
        public int N0
        {
            get
            {
                return n0;
            }
            set
            {
                n0 = value;
            }
        }

        /// <summary>
        /// Order of Legengre polynomial
        /// </summary>
        public int NK
        {
            get
            {
                return nk;
            }
            set
            {
                nk = value;
            }
        }

        /// <summary>
        /// Generalized Gravity parameter
        /// </summary>
        public double[] MUR
        {
            get
            {
                return R;
            }
        }

        /// <summary>
        /// Cos coefficients
        /// </summary>
        public double[] Cnm
        {
            get
            {
                return C;
            }
        }

        /// <summary>
        /// Sin coefficients
        /// </summary>
        public double[] Snm
        {
            get
            {
                return S;
            }
        }


        /// <summary>
        /// Calculation of gravity accelerations
        /// </summary>
        /// <param name="X">X - coordinate</param>
        /// <param name="Y">Y - coordinate</param>
        /// <param name="Z">Z - coordinate</param>
        /// <param name="FX">X - component of gravitational acceleration</param>
        /// <param name="FY">Y - component of gravitational acceleration</param>
        /// <param name="FZ">Z - component of gravitational acceleration</param>
        public void Forces(double X, double Y, double Z, out double FX,
         out double FY, out double FZ)
        {
            Forces(n0, nk, X, Y, Z, out FX, out FY, out FZ);
        }


        /// <summary>
        /// Calculation of gravity accelerations
        /// </summary>
        /// <param name="N0">Degree of Legendre polinomials</param>
        /// <param name="NK">Number of harmonics</param>
        /// <param name="X">X - coordinate</param>
        /// <param name="Y">Y - coordinate</param>
        /// <param name="Z">Z - coordinate</param>
        /// <param name="FX">X - component of gravitational acceleration</param>
        /// <param name="FY">Y - component of gravitational acceleration</param>
        /// <param name="FZ">Z - component of gravitational acceleration</param>
        public void Forces(int N0, int NK, double X, double Y, double Z, out double FX,
                out double FY, out double FZ)
        {
            bool LOG;
            double FR, FF, FL, R2, R3, R1, SF, GR, A, P20 = 0, P30 = 0, PN0, CK1, CK2, TG, AN;
            int N, N5, N4, N3, N2, N1, J, M;
            FR = 0.0;
            FF = 0;
            FL = 0;
            R2 = X * X + Y * Y;
            R3 = 1 / (R2 + Z * Z);
            R1 = sqrt(R3);
            R2 = sqrt(R2);
            SF = Z * R1;
            CF[0] = R2 * R1;
            R2 = 1 / R2;
            CO[0] = X * R2;
            SI[0] = Y * R2;
            GR = R[0] * R3;
            if (N0 != 0 || NK != 0)
            {
                CF[1] = CF[0] * CF[0];
                AR[0] = R[1] * R1;
                for (N = 1; N < N0; N++)
                {           //1
                    N3 = N - 1;
                    AR[N] = AR[0] * AR[N3];
                    A = C[N3] * AR[N];
                    if (N == 1)
                    {            //1.1
                        P20 = /*SQ[4]*/sqrt(5) * (1 - 1.5 * CF[1]);
                        PNK[0] =/*SQ[14]*/sqrt(15) * CF[0] * SF;
                        FR = 3 * A * P20;
                        FF = A * PNK[0] * sqrt(3);//SQ[2];
                    }            //1.1
                    else if (N == 2)
                    {               //1.2
                        P30 = /*SQ[6]*/sqrt(7) * (1 - 2.5 * CF[1]) * SF;
                        PNK[1] =/*SQ[62]/SQ[23]*/sqrt(63) / sqrt(24) * CF[0] * (4 - 5 * CF[1]);
                        FR += 4 * A * P30;
                        FF += A * PNK[1] * sqrt(6);//SQ[5];
                    }             //1.2
                    else
                    {             //1.3
                        N1 = N + N3 + 1;
                        N2 = N1 + 2;
                        N4 = N + 1;
                        AN = (double)(N + 1);
                        PN0 = sqrt(N2 + 1)/*SQ[N2]*// AN * (/*SQ[N1]*/sqrt(N1 + 1) * SF * P30 - (double)(N3 + 1) / /*SQ[N1-2]*/sqrt(N1 - 1) * P20);
                        PNK[N3] = sqrt(N2 + 1) / (sqrt(N3 + 1) * sqrt(N4 + 1)) * (sqrt(N1 + 1) * SF * PNK[N - 2] - sqrt(N + 1) *
                               sqrt(N - 1) / sqrt(N1 - 1) * PNK[N - 3]);
                        FR += (double)(N4 + 1) * A * PN0;
                        FF += A */*SQ[N]*SQ[N4]/SQ[1]*/sqrt(N + 1) * sqrt(N4 + 1) / sqrt(2) * PNK[N3];
                        P20 = P30;
                        P30 = PN0;
                    }      //1.3
                } //1 CONTINUE
                if (NK == 0) goto m5;
                LOG = (NK >= 3);
                A = CO[0] + CO[0];
                CO[1] = A * CO[0] - 1;
                SI[1] = A * SI[0];
                TG = Z * R2;
                if (LOG)
                    for (N = 2; N < NK; N++)
                    {          //2
                        N1 = N - 1;
                        N2 = N - 2;
                        CF[N] = CF[0] * CF[N1];
                        CO[N] = A * CO[N1] - CO[N2];
                        SI[N] = A * SI[N1] - SI[N2];
                    }             //2
                CK1 = (C[35] * CO[0] + S[35] * SI[0]) * AR[1];
                CK2 = (C[35] * SI[0] - S[35] * CO[0]) * AR[1];
                A = PNK[0];
                PNK[0] = SK[1] * CF[1];
                FR += CK1 * 3 * A;
                FF += CK1 * (PNK[0] + PNK[0] - TG * A);
                FL += CK2 * A;
                J = 35;
                if (LOG)
                    for (N = 2; N < NK; N++)    //commain
                    {                //3
                        J++;
                        N1 = N - 1;
                        N2 = N + N + 1;
                        N3 = N + 1;
                        A = PNK[N1];
                        CK1 = (C[J] * CO[0] + S[J] * SI[0]) * AR[N];
                        CK2 = (C[J] * SI[0] - S[J] * CO[0]) * AR[N];
                        if (N == 2)
                            PNK[1] = /*SQ[6]*/sqrt(7) * SF * PNK[0];
                        else
                            PNK[N1] = sqrt(N2 + 2) / (sqrt(N - 1) * sqrt(N + 3)) * (sqrt(N2) *
                            SF * PNK[N - 2] - sqrt(N3 + 1) * sqrt(N - 2) / sqrt(N2 - 2) * PNK[N - 3]);
                        FR += (N3 + 1) * CK1 * A;
                        FF += CK1 * (PNK[N1] */*SQ[N1]*/sqrt(N1 + 1) */*SQ[N+2]*/sqrt(N + 3) - TG * A);
                        FL += CK2 * A;
                    } //ENDIF //3
                for (M = 1; M < NK; M++)
                {                      // 4
                    J = (int)(ANAI[1 + M]) - 1;
                    for (N = M; N < NK; N++)
                    {                       //4.1
                        N1 = N - M;
                        N2 = N + M + 1;
                        N3 = N + N + 2;
                        N4 = N1 - 2;
                        N5 = N1 - 3;
                        A = PNK[N1];
                        AN = (double)(M + 1) * A;
                        CK1 = AR[N] * (C[J] * CO[M] + S[J] * SI[M]);
                        CK2 = AR[N] * (C[J] * SI[M] - S[J] * CO[M]);
                        if (N1 > 2)
                            PNK[N1 - 1] = sqrt(N3 + 1) / (sqrt(N4 + 1) * sqrt(N2 + 2)) * (sqrt(N3 - 1) *
                                 SF * PNK[N4] - sqrt(N2 + 1) * sqrt(N5 + 1) / sqrt(N3 - 3) * PNK[N5]);
                        else if (N1 == 0)
                        {                          //4.1.1
                            FR += HP[N] * CK1 * A;
                            FF -= CK1 * AN * TG;
                            FL += CK2 * AN;
                            goto m12;
                        }                          //4.1.1
                        else if (N1 == 1)

                            PNK[0] = SK[N] * CF[N];
                        else if (N1 == 2)
                            PNK[1] = /*SQ[N3]*/sqrt(N3 + 1) * SF * PNK[0];
                        FR += HP[N] * CK1 * A;
                        FF += CK1 * (PNK[N1 - 1] */*SQ[N1-1]*SQ[N2+1]*/sqrt(N1) * sqrt(N2 + 2) - TG * AN);
                        FL += CK2 * AN;
                        m12: J++;
                    }     //4.1
                }     //4
                //    5
            } //0
            m5:
            FR = -GR * FR - R[2] * R3;
            FF = GR * FF;
            FL = -GR / CF[0] * FL;
            A = FF * SF;
            FX = FR * (X * R1) - A * CO[0] - FL * SI[0];
            FY = FR * (Y * R1) - A * SI[0] + FL * CO[0];
            FZ = FR * SF + FF * CF[0];

        }

        /// <summary>
        /// Saver
        /// </summary>
        public List<object> Saver
        {
            get
            {
                List<object> l = new List<object>();
                l.Add(R);
                l.Add(C);
                l.Add(S);
                l.Add(HP);
                l.Add(CO);
                l.Add(SI);
                l.Add(AR);
                l.Add(CF);
                l.Add(PNK);
                l.Add(ANAI);
                l.Add(n0);
                l.Add(nk);
                return l;
            }
            set
            {
                int k = 0;
                R = value[k] as double[]; ++k;
                C = value[k] as double[]; ++k;
                S = value[k] as double[]; ++k;
                HP = value[k] as double[]; ++k;
                CO = value[k] as double[]; ++k;
                SI = value[k] as double[]; ++k;
                AR = value[k] as double[]; ++k;
                CF = value[k] as double[]; ++k;
                PNK = value[k] as double[]; ++k;
                ANAI = value[k] as double[]; ++k;
                n0 = (int)value[k]; ++k;
                nk = (int)value[k]; ++k;
                GC.Collect();
            }
        }


  

        #endregion

        #region Private Members


        private double sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        private double sqrt(int i)
        {
            return Math.Sqrt((double)i);
        }

        #endregion


        #endregion

    }
}
