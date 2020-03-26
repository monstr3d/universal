using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector3D.Interfaces;

namespace Vector3D
{
    public class EuclideanTransform : IVectorProvider
    {
        #region Fields

        protected double[] x = new double[3];                      // The shift vector
        protected double[][] A = new double[][]
             { new double[] {1, 0, 0 },
           new double[]{0,1, 0 },
          new double[] {0, 0, 1 } };                      // The 3D rotation matrix

        protected double[][] AT = new double[][]
            { new double[] {1, 0, 0 },
           new double[]{0,1, 0 },
          new double[] {0, 0, 1 } };                      // The 3D rotation matrix
                                                          //   double[] V;                      // The velocity vector
                                                          //  double[] Om;						// The angular velocity vector

        private double[] vt = new double[3];

        #endregion

        #region Ctor

        /// <summary>
        /// Default ructor
        /// </summary>
        /*    public EuclideanTransform()
             {
                 for (int i = 0; i < 3; i++)
                 {
                     A[i] = new double[3];
                     AT[i] = new double[3];
                     for (int j = 0; j < 3; j++)
                     {
                         A[i][j] = 0;
                         AT[i][j] = 0;

                     }
                     A[i][i] = 1.0;
                     AT[i][i] = 1.0;
                 }
             }*/

        #endregion

        #region Private Members

        void Transpose()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                { AT[j][i] = A[i][j]; }
            }
        }

        #endregion

        public void SetState(double[][] a, double[] X)
        {
            SetVector(X);
            SetMatrix(a);
        }

        public void SetVector(double[] X)
        {
            Array.Copy(X, x, 3);
        }


        void SetMatrix(double[][] a)
        {
            for (int i = 0; i < 3; i++)
            {
                Array.Copy(a[i], A[i], 3);
            }
            Transpose();
        }

        public void Transform(double[] y, double[] z)
        {
           for (int i = 0; i < 3; i++)
            {
                double a = 0;
                for (int j = 0; j < 3; j++)
                {
                    a += A[i][j] * y[j];
                }
                z[i] = a + x[i];
            }
        }

        public void InverseTransform(double[] y, double[] z)
        {

            for (int i = 0; i < 3; i++)
            {
                double a = 0;
                for (int j = 0; j < 3; j++)
                {
                    a += A[j][i] * (y[j] - x[j]);
                }
                z[i] = a;
            }
        }


        public void GetOrientation(EuclideanTransform e, double[][] a)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    double b = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        b += e.A[k][i] * A[k][j];
                    }
                    a[i][j] = b;
                }
            }
        }


        public void GetPosition(EuclideanTransform e, double[] X)
        {
            for (int i = 0; i < 3; i++)
            {
                double a = 0;
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        a += e.A[k][i] * (x[k] - e.x[k]);
                    }
                }
                X[i] = a;
            }
        }
  
        public void SetOrientation(EuclideanTransform e, double[][] m)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    double a = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        a += e.A[i][k] * m[k][j];
                    }
                    A[i][j] = a;
                }
            }
            Transpose();
        }

 
        public void SetPosition(EuclideanTransform e, double[] v, double[] x)
        {
            for (int i = 0; i < 3; i++)
            {
                double a = 0;
                for (int j = 0; j < 3; j++)
                {
                    a += e.A[j][i] * v[j];
                }
                x[i] = a;
            }
        }


        public double[][] Orientation
        {
            get
            { return A; }
        }

        public double[] Position
        {
            get
            {
                return x;
            }
        }

        #region IVectorProvider Members

        /// <summary>
        /// Count of vectors
        /// </summary>
        public virtual int Count
        {
            get
            {
                return 3;
            }
        }

        /// <summary>
        /// Gets i - th vector
        /// </summary>
        /// <param name="i"></param>
        /// <returns>The i-th vector</returns>
        public virtual double[] this[int i]
        {
            get
            {
                return AT[i];
            }
        }

       /*
                double[] GetPosition()
                {
                    return x;
                }

                /*
         double[] GetVelocity()
        {
            return V;
        }

         double[] GetAngularVelocity()
        {
            return Om;
        }

        int GetVectorCount() 
        {
            return 3;
        }


        TNT::Vector<double> GetVector(int i) 
        {
            return A.Column(i);
        }

        */
        public void SetRelative(EuclideanTransform relative, EuclideanTransform baseF)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    double a = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        a += baseF.A[k][i] * relative.A[k][j];
                    }
                    A[i][j] = a;
                    AT[j][i] = a;
                }
            }
            /*
            A = base.AT * relative.A;
            AT = ~A;
            x = base.AT * (relative.x - base.x);
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

        void SetAbsolute(EuclideanTransform relative, EuclideanTransform baseF)
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
            for (int i = 0; i < 3; i++)
            {
                double b = baseF.x[i];
                for (int j = 0; j < 3; j++)
                {
                    b += baseF.A[i][j] * relative.x[j];
                    double a = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        a += baseF.A[i][k] * relative.A[k][j];
                    }
                    A[i][j] = a;
                    AT[j][i] = a;
                }
                x[i] = b;
            }


            /*

            A = base.A * relative.A;
            AT = ~A;
            x = base.x + base.A * relative.x;


            /*
            Om = base.Om + base.A * relative.Om;
            double[] dV(base.Om % relative.x);
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

        void SetRelativeState(double[][] matrix, double[] vector, EuclideanTransform baseF)
        {
            //double[] vt(base.AT * (vector - base.x));
            for (int i = 0; i < 3; i++)
            {
                double a = 0;
                for (int j = 0; j < 3; j++)
                {
                    a += baseF[j][i] * (vector[j] - baseF.x[j]);
                }
                vt[i] = a;
            }

            SetState(matrix, vt);
        }


        /*
void SetRelativeState( double[,] matrix,  double[] r,
										   double[] v,  double[] om,  EuclideanTransform  base)
{
    double[] xt(base.AT * (r - base.x));
    double[] vt(base.AT * (v - base.V));
    double[] ot(base.AT * (om - base.Om));
    this->SetStateVector(matrix, xt, vt, ot);
}*/
        #endregion

    }
}



