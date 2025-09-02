using System;
using System.Numerics;
using Vector3D.Interfaces;


namespace Vector3D
{

    /// <summary>
    /// Static extension methods
    /// </summary>
    public static class StaticExtensionVector3D
	{
/*
        #region Fields

        private static readonly double[] idQuaternion = new double[] { 1, 0, 0, 0 };

        #endregion

        /// <summary>
        /// The copysign function
        /// </summary>
        /// <param name="a">Fisrt arqument</param>
        /// <param name="b">Second argument</param>
        /// <returns>The value of the function</returns>
        static double CopySign(double a, double b)
        {
            return  Math.Abs(a) * Math.Sign(b);
        }

        /// <summary>
        ///  Sets the Euler angles from the quaternion
        /// </summary>
        /// <param name="angles">The angles</param>
        /// <param name="quaternion">The quaternion</param>
        public static void Set(this EulerAngles angles, double[] quaternion)
        {
            angles.Set(quaternion[1], quaternion[2], quaternion[3], quaternion[0]);
        }

        /// <summary>
        ///  Sets the Euler angles from the quaternion
        /// </summary>
        /// <param name="angles">The angles</param>
        /// <param name="offset">The offset</param>
        /// <param name="quaternion">The quaternion</param>
        public static void Set(this EulerAngles angles, int offset, double[] quaternion)
        {
            angles.Set(quaternion[1 + offset], quaternion[2 + offset], 
                quaternion[3 + offset], quaternion[offset]);
        }

        /// <summary>
        /// Converts Euler angles to quaternion
        /// </summary>
        /// <param name="angles">The angles</param>
        /// <param name="q">The quaternion</param>
        static public void ToQuaternion(this EulerAngles angles, double[] q)
        {
            // Abbreviations for the various angular functions
            double cy = Math.Cos(angles.yaw * 0.5);
            double sy = Math.Sin(angles.yaw * 0.5);
            double cp = Math.Cos(angles.pitch * 0.5);
            double sp = Math.Sin(angles.pitch * 0.5);
            double cr = Math.Cos(angles.roll * 0.5);
            double sr = Math.Sin(angles.roll * 0.5);
            q[0] = cr * cp * cy + sr * sp * sy;
            q[1] = sr * cp * cy - cr * sp * sy;
            q[2] = cr * sp * cy + sr * cp * sy;
            q[3] = cr * cp * sy - sr * sp * cy;
        }

        /// <summary>
        /// Converts Euler angles to quaternion
        /// </summary>
        /// <param name="angles">The angles</param>
        /// <param name="offset">The offset</param>
        /// <param name="q">The quaternion</param>
        static public void ToQuaternion(this EulerAngles angles, int offset, double[] q)
        {
            // Abbreviations for the various angular functions
            double cy = Math.Cos(angles.yaw * 0.5);
            double sy = Math.Sin(angles.yaw * 0.5);
            double cp = Math.Cos(angles.pitch * 0.5);
            double sp = Math.Sin(angles.pitch * 0.5);
            double cr = Math.Cos(angles.roll * 0.5);
            double sr = Math.Sin(angles.roll * 0.5);
            q[offset] = cr * cp * cy + sr * sp * sy;
            q[offset + 1] = sr * cp * cy - cr * sp * sy;
            q[offset + 2] = cr * sp * cy + sr * cp * sy;
            q[offset + 3] = cr * cp * sy - sr * sp * cy;
        }


        /// <summary>
        /// Sets Euler angles by quaternion components
        /// </summary>
        /// <param name="angles">The angles</param>
        /// <param name="x">x - quaternion component</param>
        /// <param name="y">y - quaternion component</param>
        /// <param name="z">z - quaternion component</param>
        /// <param name="w">w - quaternion component</param>
        public static void  Set(this EulerAngles angles, double x, double y, double z, double w)
        {
         
            // roll (x-axis rotation)
            double sinr_cosp = 2 * (w * x + y * z);
            double cosr_cosp = 1 - 2 * (x * x + y * y);
            angles.roll = Math.Atan2(sinr_cosp, cosr_cosp);

            // pitch (y-axis rotation)
            double sinp = 2 * (w * y - z * x);
            if (Math.Abs(sinp) >= 1)
            {
                angles.pitch = CopySign(Math.PI / 2, sinp);
                //std::copysign(M_PI / 2, sinp); // use 90 degrees if out of range
            }
            else
            {
                angles.pitch = Math.Asin(sinp);
            }

            // yaw (z-axis rotation)
            double siny_cosp = 2 * (w * z + x * y);
            double cosy_cosp = 1 - 2 * (y * y + z * z);
            angles.yaw = Math.Atan2(siny_cosp, cosy_cosp);
        }

        /// <summary>
        /// Rotated quaternion
        /// </summary>
        /// <param name="omega"></param>
        /// <param name="quaternion"></param>
        /// <param name="time"></param>
        public static void RotateOmega(this double[] omega, double[] quaternion, double time)
        {
            double o = omega.PartialNorm(0, 3);
            double phi = 0.5 * o * time;
            double s = Math.Sin(phi);
            quaternion[0] = Math.Sqrt(1 - s * s);
            o = 1 / o;
            for (int i = 0; i < 3; i++)
            {
                quaternion[i + 1] = o * s * omega[i];
            }
        }

        /// <summary>
        /// Rotated quaternion
        /// </summary>
        /// <param name="omega"></param>
        /// <param name="time"></param>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="aux"></param>
        public static void RotateOmega(this double[] omega,  double time,
           double[] source, double[] target, double[] aux)
        {
            omega.RotateOmega(aux, time);
            QuaternionMultiply(source, aux, target);
        }

        /// <summary>
        /// Calculates rotation matrix from Euler amgles
        /// </summary>
        /// <param name="psi">Psi angle - pitch</param>
        /// <param name="theta">Theta angle - hunting</param>
        /// <param name="gamma">Gamma angle - roll </param>
        /// <param name="matrix">The matrix</param>
        public static void CalculateRotationMatrixFromPitchRollHunting(double psi, 
            double theta, double gamma, double[,] matrix)
        {
            double cp = Math.Cos(psi);
            double sp = Math.Sin(psi);
            double ct = Math.Cos(theta);
            double st = Math.Sin(theta);
            double cg = Math.Cos(gamma);
            double sg = Math.Sin(gamma);
            matrix[0, 0] = ct * cp;
            matrix[0, 1] = ct * sp;
            matrix[0, 2] = -st;
            matrix[1, 0] = -cg * sp + sg * st * cp;
            matrix[1, 1] = cg * cp + sg * st * sp;
            matrix[1, 2] = sg * ct;
            matrix[2, 0] = sg * sp + cg * st * cp;
            matrix[2, 1] = -sg * cp + cg * st * sp;
            matrix[2, 2] = cg * ct;
        }

        /// <summary>
        /// Product of acceleration data by coeffient
        /// </summary>
        /// <param name="acceleration">Acceleration data</param>
        /// <param name="coefficient">Coefficient</param>
        /// <returns>Product</returns>
        public static double[] Product(this IAccelerationData acceleration, double coefficient)
        {
            double[] output = new double[3];
            output[0] = coefficient * acceleration.AccelerationX;
            output[1] = coefficient * acceleration.AccelerationY;
            output[2] = coefficient * acceleration.AccelerationZ;
            return output;
        }
        

        /// <summary>
        /// Power of the norm
        /// </summary>
        /// <param name="acceleration">Acceleration</param>
        /// <param name="power">Power</param>
        /// <returns>Power of the norm</returns>
        public static double NormPower(this IAccelerationData acceleration, double power)
        {
            return Math.Pow(acceleration.Norm(), power);
        }

        /// <summary>
        /// Norm of accelation
        /// </summary>
        /// <param name="acceleration">Acceleration</param>
        /// <returns>Norm</returns>
        public static double Norm(this IAccelerationData acceleration)
        {
            double x = acceleration.AccelerationX;
            double y = acceleration.AccelerationY;
            double z = acceleration.AccelerationZ;
            return Math.Sqrt(x * x + y * y + z * z);
        }

        /// <summary>
        /// Sets quaternion
        /// </summary>
        /// <param name="orientation"></param>
        public static void SetQuaternion(this IFloatOrientation orientation)
        {
            orientation.RotationMatrix.SetQuaternion(orientation.Quaternion);
        }

        /// <summary>
        /// Calculates matrix of quaternion
        /// </summary>
        /// <param name="quaternion">Quaterion</param>
        /// <param name="m11">M11 element</param>
        /// <param name="m12"></param>
        /// <param name="m13"></param>
        /// <param name="m21"></param>
        /// <param name="m22"></param>
        /// <param name="m23"></param>
        /// <param name="m31"></param>
        /// <param name="m32"></param>
        /// <param name="m33"></param>
        public static void CalculateRotationMatrix(this IFloatQuaternion quaternion,
            out float m11, out float m12, out float m13,
            out float m21, out float m22, out float m23,
            out float m31, out float m32, out float m33)
        {
            float w = quaternion.W;
            float x = quaternion.X;
            float y = quaternion.Y;
            float z = quaternion.Z;
            float a00 = w * w;
            float a01 = w * x;
            float a02 = w * y;
            float a03 = w * z;
            float a11 = x * x;
            float a12 = x * y;
            float a13 = x * z;
            float a22 = y * y;
            float a23 = y * z;
            float a33 = z * z;
            m11 = a00 + a11 - a22 - a33;
            m12 = 2 * (a12 - a03);
            m13 = 2 * (a02 + a13);
            m21 = 2 * (a03 + a12);
            m22 = a00 - a11 + a22 - a33;
            m23 = 2 * (a23 - a01);
            m31 = 2 * (a13 - a02);
            m32 = 2 * (a01 + a23);
            m33 = a00 - a11 - a22 + a33;
         }


        /// <summary>
        /// Sets quaternion to Id
        /// </summary>
        /// <param name="quaternion">Quaternion</param>
        public static void SetIdQuaternion(this double[] quaternion)
        {
            Array.Copy(idQuaternion, quaternion, 4);
        }

		/// <summary>
		/// Vector multiplication of two vectors
		/// </summary>
		/// <param name="x">First vector</param>
		/// <param name="y">Second vector</param>
		/// <returns>Vector product</returns>
		public static double[] VectorPoduct(this double[] x, double[] y)
		{
			double[] z = new double[3];
			z[0] = x[1] * y[2] - x[2] * y[1];
			z[1] = x[2] * y[0] - x[0] * y[2];
			z[2] = x[0] * y[1] - x[1] * y[0];
			return z;
		}

		/// <summary>
		/// Vector multiplication of two vectors
		/// </summary>
		/// <param name="x">First vector</param>
		/// <param name="y">Second vector</param>
		/// <param name="z">Result vector</param>
		public static void VectorPoduct(this double[] x, double[] y, double[] z)
		{
			z[0] = x[1] * y[2] - x[2] * y[1];
			z[1] = x[2] * y[0] - x[0] * y[2];
			z[2] = x[0] * y[1] - x[1] * y[0];
		}

		/// <summary>
		/// Scalar multiplication of two vectors
		/// </summary>
		/// <param name="x">First vector</param>
		/// <param name="y">Second vector</param>
		/// <returns></returns>
		public static double ScalarProduct3d(this double[] x, double[] y)
		{
			return x[0] * y[0] + x[1] * y[1] + x[2] * y[2];
		}
		
		/// <summary>
		/// Scalar norm of vector
		/// </summary>
		/// <param name="x">The vector</param>
		/// <returns>The square norm</returns>
		public static double ScalarNorm3d(this double[] x)
		{
			return Math.Sqrt(Square3d(x));
		}

        /// <summary>
        /// Square of vector
        /// </summary>
        /// <param name="x">The vector</param>
        /// <returns>The square</returns>
        public static double Square3d(double[] x)
        {
            // !!! EXCEPTION DELETE
            if (x.Length != 3)
            {
                throw new ArgumentException();
            }
            return x[0] * x[0] + x[1] * x[1] + x[2] * x[2];
        }


        /// <summary>
        /// Noramalization
        /// </summary>
        /// <param name="x">Noralizable vector</param>
        /// <returns>Normalization result</returns>
		public static double[] VectorNorm3d(double[] x)
		{
            // !!! EXCEPTION DELETE
            if (x.Length != 3)
            {
                throw new ArgumentException();
            }
            double a = ScalarNorm3d(x);
			return Multiply3d(1 / a, x);
		}

		/// <summary>
		/// Normalization of vector
		/// </summary>
		/// <param name="x">The vector</param>
		public static void Normalize3d(this double[] x)
		{
			double a = 1 / ScalarNorm3d(x);
			for (int i = 0; i < x.Length; i++)
			{
				x[i] *= a;
			}
		}

  
        /// <summary>
        /// Multiplication of scalar and vector
        /// </summary>
        /// <param name="a">The scalar</param>
        /// <param name="x">The vector</param>
        /// <returns></returns>
        public static double[] Multiply3d(this double a, double[] x)
		{
			double[] y = new double[3];
			for (int i = 0; i < 3; i++)
			{
				y[i] = x[i] * a;
			}
			return y;
		}
		/// <summary>
		/// Construction of reper by two vectors
		/// </summary>
		/// <param name="x">First vector</param>
		/// <param name="y">Second vector</param>
		/// <returns>Reper matrix</returns>
		public static double[][] Reper(this double[] x, double[] y)
		{
			double[][] a = new double[3][];
			a[0] = VectorNorm3d(x);
			a[2] = VectorPoduct(a[0], y);
			a[2] = VectorNorm3d(a[2]);
			a[1] = VectorPoduct(a[2], a[0]);
			return a;
		}

        /// <summary>
        /// Construction of reper by 6D vector
        /// </summary>
        /// <param name="x">The vector</param>
        /// <returns>The reper</returns>
        public static double[][] Reper(this double[] x)
        {
            double[] v = new double[3];
            for (int i = 0; i < 3; i++)
            {
                v[i] = x[i + 3];
            }
            return Reper(x, v);
        }

        /// <summary>
        /// Normalization of quaternion
        /// </summary>
        /// <param name="The quaternion"></param>
        public static void QuaternionNormalize(this double[] quaternion)
        {
            // !!! DELETE EXCEPTION
            if (quaternion.Length != 4)
            {
                throw new ArgumentException();
            }
            double a = 0;
            foreach (var q in quaternion)
            {
                a += q * q;

            }
            a = 1 / Math.Sqrt(a);
            for (var i = 0; i < 4; i++)
            {
                quaternion[i] *= a;
                    
            }
        }

        /// <summary>
        /// The miss between line and zero point
        /// </summary>
        /// <param name="x">Radius-vector</param>
        /// <param name="v">Velocity</param>
        /// <param name="miss">Value of miss</param>
        /// <returns></returns>
        public static double[] Miss(this double[] x, double[] v, ref double miss)
		{
			double[][] a = Reper(v, x);
			miss = ScalarProduct3d(a[1], x);
			return Multiply3d(miss, a[1]);
		}
		
		/// <summary>
		/// Normalization of transition matrix
		/// </summary>
		/// <param name="matrix">The matrix</param>
		public static void NormMatrix(this double[,] matrix)
		{
			double[][] a = new double[2][];
			for (int i = 0; i < 2; i++)
			{
				a[i] = new double[3];
				for (int j = 0; j < 3; j++)
				{
					a[i][j] = matrix[i, j];
				}
			}
			a = Reper(a[0], a[1]);
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix[i, j] = a[i][j];
				}
			}
		}


		/// <summary>
		/// Calculates the coefficients of transition matrix by quaternion
		/// </summary>
		/// <param name="q">Coefficients of quaternion</param>
		/// <param name="m">Transition matrix</param>
		/// <param name="qq">Auxiliary matrix</param>
		public static void QuaternionToMatrix(this double[] q, double[,] m, double[,] qq)
		{
			double norm = 1 / Math.Sqrt(q[0] * q[0] + q[1] * q[1] + q[2] * q[2] + q[3] * q[3]);
			for (int i = 0; i < 4; i++)
			{
				q[i] *= norm; 
			}
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j <= i; j++)
				{
					qq[i, j] = q[i] * q[j];
				}
			}
			m[0, 0] = qq[0, 0] + qq[1, 1] - qq[2, 2] - qq[3, 3];
			m[0, 1] = 2 * (qq[2, 1] - qq[3, 0]);
			m[0, 2] = 2 * (qq[2, 0] + qq[3, 1]);
			m[1, 0] = 2 * (qq[3, 0] + qq[2, 1]);
			m[1, 1] = qq[0, 0] - qq[1, 1] + qq[2, 2] - qq[3, 3];
			m[1, 2] = 2 * (qq[3, 2] - qq[1, 0]);
			m[2, 0] = 2 * (qq[3, 1]-qq[2, 0]);
			m[2, 1] = 2 * (qq[1, 0] + qq[3, 2]);
			m[2, 2] = qq[0, 0] - qq[1, 1] - qq[2, 2] + qq[3, 3];
		}

  		/// <summary>
  		/// Calculation of dynamics
  		/// </summary>
  		/// <param name="q">Quaternion</param>
  		/// <param name="der">Derivation</param>
  		/// <param name="m">Axiliary matrix</param>
  		/// <param name="omega">Angular velicity</param>
  		/// <param name="qq">Auxliary variable</param>
  		/// <param name="qd">Auxiliary varible</param>
		public static void CalculateDynamics(this double[] q, double[] der, double[,] m, double[] omega, 
            double[,] qq, double[,] qd)
		{
            CalculateDynamics(q, der, omega, qd);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    qq[i, j] = q[i] * q[j];
                }
            }

            m[0, 0] = qq[0, 0] + qq[1, 1] - qq[2, 2] - qq[3, 3];
            m[0, 1] = 2 * (qq[2, 1] - qq[3, 0]);
            m[0, 2] = 2 * (qq[2, 0] + qq[3, 1]);
            m[1, 0] = 2 * (qq[3, 0] + qq[2, 1]);
            m[1, 1] = qq[0, 0] - qq[1, 1] + qq[2, 2] - qq[3, 3];
            m[1, 2] = 2 * (qq[3, 2] - qq[1, 0]);
            m[2, 0] = 2 * (qq[3, 1] - qq[2, 0]);
            m[2, 1] = 2 * (qq[1, 0] + qq[3, 2]);
            m[2, 2] = qq[0, 0] - qq[1, 1] - qq[2, 2] + qq[3, 3];
        }

        /// <summary>
        /// Calculates angular velocity by derivation of quaternion
        /// </summary>
        /// <param name="q">Quaternion</param>
        /// <param name="der">Quaternion derivation</param>
        /// <param name="omega">Angular velocity</param>
        /// <param name="qd">Auxiliary array</param>
        public static void CalculateDynamics(this double[] q, double[] der, double[] omega, double[,] qd)
        {
            double norm = 1 / Math.Sqrt(q[0] * q[0] + q[1] * q[1] + q[2] * q[2] + q[3] * q[3]);
            for (int i = 0; i < 4; i++)
            {
                q[i] *= norm;
                der[i] *= norm;
            }
            for (int i = 0; i < 4; i++)
            {
                 for (int j = 0; j < 4; j++)
                {
                    qd[i, j] = q[i] * der[j];
                }

            }
            omega[0] = 2 * (-qd[2, 3] + qd[3, 2] + qd[0, 1] - qd[1, 0]);
            omega[1] = 2 * (-qd[3, 1] + qd[1, 3] + qd[0, 2] - qd[2, 0]);
            omega[2] = 2 * (-qd[1, 2] + qd[2, 1] + qd[0, 3] - qd[3, 0]);
        }

        /// <summary>
        /// Calculates quaternion derivation by angular velocity
        /// </summary>
        /// <param name="quaternion">Quaternion</param>
        /// <param name="omega">Angular velocity</param>
        /// <param name="quaternionDerivation">Derivation of quaternion</param>
        /// <param name="auxQuaternion">Auxiliary quaternion</param>
        public static void CalculateQuaternionDerivation(this double[] quaternion, double[] omega, 
            double[] quaternionDerivation, double[] auxQuaternion)
        {
            auxQuaternion[0] = 0;
            Array.Copy(omega, 0, auxQuaternion, 1, 3);
            QuaternionMultiply(quaternion, auxQuaternion, quaternionDerivation);
            for (int i = 0; i < 4; i++)
            {
                quaternionDerivation[i] *= 0.5;
            }
        }


        /// <summary>
        /// Calculates accelerated dynamics
        /// </summary>
        /// <param name="q">Quaternion</param>
        /// <param name="der">Quaternion derivation</param>
        /// <param name="omega">Omega</param>
        /// <param name="qd">Auxiliary variable</param>
        /// <param name="dder">Quaternion second derivation</param>
        /// <param name="eps">Angular acceleration</param>
        public static void CalculateAcceleratedDynamics(this double[] q, double[] der, double[] omega, double[,] qd,
            double[] dder, double[] eps)
        {
            double norm = 1 / Math.Sqrt(q[0] * q[0] + q[1] * q[1] + q[2] * q[2] + q[3] * q[3]);
            for (int i = 0; i < 4; i++)
            {
                q[i] *= norm;
                der[i] *= norm;
                dder[i] *= norm;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    qd[i, j] = q[i] * der[j];
                }

            }
            omega[0] = 2 * (-qd[2, 3] + qd[3, 2] + qd[0, 1] - qd[1, 0]);
            omega[1] = 2 * (-qd[3, 1] + qd[1, 3] + qd[0, 2] - qd[2, 0]);
            omega[2] = 2 * (-qd[1, 2] + qd[2, 1] + qd[0, 3] - qd[3, 0]);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    qd[i, j] = q[i] * dder[j];
                }
            }
            eps[0] = 2 * (-qd[2, 3] + qd[3, 2] + qd[0, 1] - qd[1, 0]);
            eps[1] = 2 * (-qd[3, 1] + qd[1, 3] + qd[0, 2] - qd[2, 0]);
            eps[2] = 2 * (-qd[1, 2] + qd[2, 1] + qd[0, 3] - qd[3, 0]);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    double a = (j == 0) ? 0 : omega[j - 1];
                    qd[i, j] = der[i] * a;
                }
            }
            eps[0] -= 2 * (-qd[2, 3] + qd[3, 2] + qd[0, 1] - qd[1, 0]);
            eps[1] -= 2 * (-qd[3, 1] + qd[1, 3] + qd[0, 2] - qd[2, 0]);
            eps[2] -= 2 * (-qd[1, 2] + qd[2, 1] + qd[0, 3] - qd[3, 0]);


        }
        /// <summary>
        /// Calculates angular velocity matrix form angular velocity vector
        /// </summary>
        /// <param name="vector">Angular velocity vector</param>
        /// <param name="matrix">Angular velocity matrix</param>
        public static void CreateVectorProductMatrtix(this double[] vector, double[,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                matrix[i, i] = 0;
            }
            matrix[0, 1] = vector[2];
            matrix[0, 2] = -vector[1];
            matrix[1, 0] = -vector[2];
            matrix[1, 2] = vector[0];
            matrix[2, 0] = vector[1];
            matrix[2, 1] = -vector[0];
        }


        /// <summary>
        /// Calculates matrix by quaternion
        /// </summary>
        /// <param name="m">Matrix</param>
        /// <param name="q">Quaternion</param>
        public static void MatrixToQuaternion(this double[,] m, double[] q)
		{
			q[0] = 0.5 * Math.Sqrt(1.0 + m[0, 0] + m[1, 1] + m[2, 2]);
			double	m1 = 0;
			if (Math.Abs(q[0]) > 0.001)
			{
				m1 = 1 / (4 * q[0]);
				q[1] = (m[2, 1] - m[1, 2]) * m1;
				q[2] = (m[0, 2] - m[2, 0]) * m1;
				q[3] = (m[1, 0] - m[0, 1]) * m1;
				return;
			}
			q[1] = 0.5 * Math.Sqrt(1.0 + m[0, 0] - m[1, 1] - m[2, 2]);
			if (Math.Abs(q[1]) > 0.001)
			{
				m1 = 1.0 / (4 * q[1]);
				q[0] = (m[2, 1] - m[1, 2]) * m1;
				q[2] = (m[0, 1] + m[1, 0]) * m1;
				q[3] = (m[0, 2] + m[2, 0]) * m1;
				return;
			}
			q[2] = 0.5 * Math.Sqrt(1.0 - m[0, 0] + m[1, 1] - m[2, 2]);
			if (Math.Abs(q[2]) > 0.001)
			{
				m1 = 1.0 / (4 * q[2]);
				q[0] = (m[0, 2] - m[2, 0]) * m1;
				q[1] = (m[0, 1] + m[1, 0]) * m1;
				q[3] = (m[1, 2] + m[2, 1]) * m1;
				return;
			}
			q[3] = 0.5 * Math.Sqrt(1 - m[0, 0] - m[1, 1] + m[2, 2]);
			m1 = 1.0 / (4 * q[3]);
			q[0] = (m[0, 1] - m[1, 0]) * m1;
			q[1] = (m[0, 2] + m[2, 0]) * m1;
			q[2] = (m[1, 2] + m[2, 1]) * m1;

		}

        /// <summary>
        /// Converts vector form of so(3) generator to matrix represenation
        /// </summary>
        /// <param name="vector">so(3) generator</param>
        /// <param name="matrix">Matrix</param>
        public static void SO3VectorToSO3Matrix(this double[] vector, double[,] matrix)
        {
            double w0 = vector[0];
            double w1 = vector[1];
            double w2 = vector[2];

            matrix[0, 0] = 0;
            matrix[0, 1] = w2;
            matrix[0, 2] = -w1;

            matrix[1, 0] = -w2;
            matrix[1, 1] = 0;
            matrix[1, 2] = w0;

            matrix[2, 0] = w1;
            matrix[2, 1] = -w0;
            matrix[2, 2] = 0;
        }

        /// <summary>
        /// Multiplication of quaternion
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">Product</param>
        public static void QuaternionMultiply(this double[] x, double[] y, double[] z)
        {
            z[0] = x[0] * y[0] - x[1] * y[1] - x[2] * y[2] - x[3] * y[3];
            z[1] = x[0] * y[1] + x[1] * y[0] + x[2] * y[3] - x[3] * y[2];
            z[2] = x[0] * y[2] + x[2] * y[0] + x[3] * y[1] - x[1] * y[3];
            z[3] = x[0] * y[3] + x[3] * y[0] + x[1] * y[2] - x[2] * y[1];
        }

        /// <summary>
        /// Invert multiplication of quaternions
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">Product</param>
        public static void QuaternionInvertMultiply(this double[] x, double[] y, double[] z)
        {
            z[0] = x[0] * y[0] + x[1] * y[1] + x[2] * y[2] + x[3] * y[3];
            z[1] = x[0] * y[1] - x[1] * y[0] - x[2] * y[3] + x[3] * y[2];
            z[2] = x[0] * y[2] - x[2] * y[0] - x[3] * y[1] + x[1] * y[3];
            z[3] = x[0] * y[3] - x[3] * y[0] - x[1] * y[2] + x[2] * y[1];
        }

        /// <summary>
        /// Quaternion omega multiplication
        /// </summary>
        /// <param name="quaterinon">Quaterinon</param>
        /// <param name="omegaIn">Input omega</param>
        /// <param name="omegaOut">Output omega</param>
        public static void QuaternionInvertOmega(this double[] quaterinon, double[] omegaIn, double[] omegaOut)
        {
            omegaOut[0] = quaterinon[0] * omegaIn[0] - quaterinon[2] * omegaIn[2] + quaterinon[3] * omegaIn[1];
            omegaOut[1] = quaterinon[0] * omegaIn[1] - quaterinon[3] * omegaIn[0] + quaterinon[1] * omegaIn[2];
            omegaOut[2] = quaterinon[0] * omegaIn[2] - quaterinon[1] * omegaIn[1] + quaterinon[2] * omegaIn[0];
        }


        /// <summary>
        /// Rotation quaternion
        /// </summary>
        /// <param name="angle">Rotation angle</param>
        /// <param name="axis">Number of rotation axis</param>
        /// <param name="quaternion">Rotation quaternion</param>
        public static void Rotate(double angle, int axis, double[] quaternion)
        {
            for (int i = 1; i < 4; i++)
            {
                quaternion[i] = 0;
            }
            double a = 0.5 * angle;
            quaternion[0] = Math.Cos(a);
            quaternion[axis] = Math.Sin(a);
         }

        /// <summary>
        /// Rotation quaternions
        /// </summary>
        /// <param name="angles">Rotation angles</param>
        /// <param name="axis">Numbers of rotation axis</param>
        /// <param name="quaternion">Rotation quaternion</param>
        /// <param name="buffer">Buffer</param>
        /// <param name="buff">Additinal buffer</param>
        public static void Rotate(double[] angles, int[] axis, 
            double[] quaternion, double[][] buffer, double[] buff)
        {
            Rotate(angles[0], axis[0], quaternion);
            for (int i = 0; i < angles.Length - 1; i++)
            {
                Rotate(angles[i + 1], axis[i + 1], buffer[i]);
            }
            for (int i = 0; i < angles.Length - 1; i++)
            {
                QuaternionMultiply(buffer[i], quaternion, buff);
                Array.Copy(buff, quaternion, 4);
            }
        }

        /// <summary>
        /// Sets quaternion to identity
        /// </summary>
        /// <param name="quaternion">Quaternion to set</param>
        public static void QuaternionSetIdentity(this double[] quaternion)
        {
            quaternion[0] = 1;
            quaternion[1] = 0;
            quaternion[2] = 0;
            quaternion[3] = 0;
        }

        /// <summary>
        /// Rotation quaternion
        /// </summary>
        /// <param name="angle">Rotation angle</param>
        /// <param name="axis">Number of rotation axis</param>
        /// <param name="quaternion">Rotation quaternion</param>
        /// <param name="buffer1">Fist buffer</param>
        /// <param name="buffer2">Second buffer</param>
        public static void Rotate(this double angle, int axis, double[] quaternion, double[] buffer1, double[] buffer2)
        {
            Array.Copy(quaternion, buffer1, quaternion.Length);
            Rotate(angle, axis, buffer2);
            QuaternionMultiply(buffer1, buffer2, quaternion);
        }


        /// <summary>
        /// Partial square of vector
        /// </summary>
        /// <param name="x">The vector</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="length">Length</param>
        /// <returns>The partial square</returns>
        public static double PartialSquare(this double[] x, int startIndex, int length)
        {
            double a = 0;
            for (int i = 0; i < length; i++)
            {
                double c = x[i + startIndex];
                a += c * c;
            }
            return a;
        }

        /// <summary>
        /// Partial norm of vector
        /// </summary>
        /// <param name="x">The vector</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="length">Length</param>
        /// <returns>The partial norm</returns>
        public static double PartialNorm(this double[] x, int startIndex, int length)
        {
            return Math.Sqrt(PartialSquare(x, startIndex, length));
        }

        /// <summary>
        /// Converts jagged array to square array
        /// </summary>
        /// <param name="x">Jagged array</param>
        /// <returns>Square array</returns>
        static public double[,] ToSquare(this double[][] x)
        {
            double[,] a = new double[x.Length, x[0].Length];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = x[i][j];
                }
            }
            return a;
        }

        /// <summary>
        /// Square reper matrix
        /// </summary>
        /// <param name="x">Input vector</param>
        /// <returns>Reper matrix</returns>
        static public double[,] SquareReper(this double[] x)
        {
            return ToSquare(Reper(x));
        }


        static public void RotateOmega(this double[] omega, double dt, double[] quaternion)
        {
            double a = 0;
            for (int i = 0; i < 3; i++)
            {
                double o = omega[i] * dt;
                a += o * o;
            }
          //  a = Math.Sin(Math.)
        }

        /// <summary>
        /// Fills spherical matrix
        /// </summary>
        /// <param name="cphi">Cos phi</param>
        /// <param name="sphi">Sin phi</param>
        /// <param name="ctheta">Cos theta</param>
        /// <param name="stheta">Sin theta</param>
        /// <param name="matrix">Spherical matrix</param>
        static public void FillSphericalMatrix(this double cphi, double sphi, 
            double ctheta, double stheta, double[,] matrix)
        {
            matrix[0, 0] = cphi * ctheta;
            matrix[0, 1] = cphi * stheta;
            matrix[0, 2] = -sphi;
            matrix[1, 0] = sphi * ctheta;
            matrix[1, 1] = sphi * stheta;
            matrix[1, 2] = cphi;
            matrix[2, 0] = stheta;
            matrix[2, 1] = 0;
            matrix[2, 2] = ctheta;
        }

        /// <summary>
        /// Calculates relative accelerations
        /// </summary>
        /// <param name="acc">Linear acceleration</param>
        /// <param name="omega">Angular velocity</param>
        /// <param name="eps">Angular acceleration</param>
        /// <param name="velocity">Velocity</param>
        /// <param name="position">Position</param>
        /// <param name="buffer">Auxiliary buffer</param>
        /// <param name="buffer1">Auxiliary buffer</param>
        /// <param name="result">Result acceleration</param>
        static public void CalculateRelativeAcceleration(this double[] acc, double[] omega, double[] eps, double[] velocity,
          double[] position,  double[] buffer, double[] buffer1, double[] result)
        {
            Array.Copy(acc, result, 3);
            VectorPoduct(omega, velocity, buffer);
            for (int i = 0; i < 3; i++)
            {
                result[i] += buffer[i];
            }
            VectorPoduct(omega, position, buffer1);
            VectorPoduct(omega, buffer1, buffer);
            VectorPoduct(eps, position, buffer1);
            for (int i = 0; i < 3; i++)
            {
                result[i] += buffer[i] + buffer1[i];
            }
        }*/
    }
}
