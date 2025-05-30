﻿using ErrorHandler;
using System;
using System.Collections.Generic;

namespace RealMatrixProcessor
{
    /// <summary>
    /// Operations with real matrices
    /// </summary>
    public class RealMatrix
    {
        /// <summary>
        /// Conversion of arrays
        /// </summary>
        /// <typeparam name="T">Type of output</typeparam>
        /// <param name="objects">Input</param>
        /// <returns>Output</returns>
        public T[] Convert<T>(object[] objects)
        {
            var x = new T[objects.Length];
            for (int i = 0; i < objects.Length; i++)
            {
                var o = objects[i];
                if (o == null)
                {
                    return null;
                }
                x[i] = (T)o;
            }
            return x;
        }

        /// <summary>
        /// Normalization of vector
        /// </summary>
        /// <param name="inp">Input</param>
        /// <param name="outp">Output</param>
        /// <param name="offset">Offset</param>
        public double Normalize(double[] inp, double[] outp, int offset)
        {
            double a = 0;
            for (int i = offset; i < outp.Length + offset; i++)
            {
                double b = inp[i];
                a += b * b;
            }
            a = Math.Sqrt(a);
            double c = 1 / a;
            for (int i = 0; i < outp.Length; i++)
            {
                outp[i] = c * inp[i + offset];
            }
            return a;
        }

        /// <summary>
        /// Normalization of vector
        /// </summary>
        /// <param name="inp">Input</param>
        /// <param name="outp">Output</param>
        /// <param name="offset">Offset</param>
        public double Normalize(float[] inp, float[] outp, int offset)
        {
            float a = 0;
            for (int i = offset; i < outp.Length + offset; i++)
            {
                float b = inp[i];
                a += b * b;
            }
            a = MathF.Sqrt(a);
            float c = 1 / a;
            for (int i = 0; i < outp.Length; i++)
            {
                outp[i] = c * inp[i + offset];
            }
            return a;
        }


        /// <summary>
        /// Inverts a matrix
        /// </summary>
        /// <param name="a">Matrix to invert</param>
        /// <returns>Inverted matrix</returns>
        public double[,] Invert(double[,] a)
        {
            int n = a.GetLength(0);
            var inv = new double[n, n];
            Invert(a, inv);
            return inv;
        }

        /// <summary>
        /// Inverts a matrix
        /// </summary>
        /// <param name="a">Matrix to invert</param>
        /// <returns>Inverted matrix</returns>
        public float[,] Invert(float[,] a)
        {
            int n = a.GetLength(0);
            var inv = new float[n, n];
            Invert(a, inv);
            return inv;
        }


        /// <summary>
        /// Inverts matrix
        /// </summary>
        /// <param name="a">Matrix to invert</param>
        /// <param name="aInverted">Result of inversion</param>
		public void Invert(double[,] a, double[,] aInverted)
        {
            double e, y, det, w, d = 0, d1;
            int i, j, k, ir, ip, n = a.GetLength(0);
            int[] jz = new int[n];
            double[] c = new double[n];
            double[] ab = new double[n];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    aInverted[i, j] = a[i, j];
                }
            }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    e = Math.Abs(aInverted[i, j]);
                    if (d < e) d = e;
                }
            }
            d1 = 1 / d;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    aInverted[i, j] *= d1;
                }
            }
            e = 1.0e-26;
            det = 1;
            for (i = 0; i < n; i++)
            {
                jz[i] = i;
            }
            for (i = 0; i < n; i++)
            {
                k = i;
                y = aInverted[i, i];
                ir = i - 1;
                ip = i + 1;
                if (ip < n)
                {
                    for (j = ip; j < n; j++)
                    {
                        w = aInverted[i, j];
                        if (Math.Abs(w) > Math.Abs(y))
                        {
                            k = j;
                            y = w;
                        }
                    }
                }
                det *= y;
                y = 1.0 / y;
                for (j = 0; j < n; j++)
                {
                    c[j] = aInverted[j, k];
                    aInverted[j, k] = aInverted[j, i];
                    aInverted[j, i] = -c[j] * y;
                    ab[j] = aInverted[i, j] * y;
                    aInverted[i, j] = ab[j];
                }
                aInverted[i, i] = y;
                j = jz[i];
                jz[i] = jz[k];
                jz[k] = j;
                k = 0;
                do
                {
                    if ((k <= ir) | (k >= ip))
                    {
                        j = 0;
                        do
                        {
                            if ((j <= ir) | (j >= ip))
                            {
                                aInverted[k, j] -= ab[j] * c[k];
                            }
                            j++;
                        }
                        while (j < n);
                    }
                    k++;
                }
                while (k < n);
            }
            i = 0;
            do
            {
                k = jz[i];
                if (k != i)
                {
                    for (j = 0; j < n; j++)
                    {
                        w = aInverted[i, j];
                        aInverted[i, j] = aInverted[k, j];
                        aInverted[k, j] = w;
                    }
                    ip = jz[i];
                    jz[i] = jz[k];
                    jz[k] = ip;
                    det = -det;
                }
                else
                {
                    i++;
                }
            }
            while (i < n);
            d1 = 1.0 / d;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    aInverted[i, j] *= d1;
                }
            }
        }

        /// <summary>
        /// Inverts matrix
        /// </summary>
        /// <param name="a">Matrix to invert</param>
        /// <param name="aInverted">Result of inversion</param>
        public void Invert(float[,] a, float[,] aInverted)
        {
            float e, y, det, w, d = 0, d1;
            int i, j, k, ir, ip, n = a.GetLength(0);
            int[] jz = new int[n];
            float[] c = new float[n];
            float[] ab = new float[n];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    aInverted[i, j] = a[i, j];
                }
            }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    e = Math.Abs(aInverted[i, j]);
                    if (d < e) d = e;
                }
            }
            d1 = 1 / d;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    aInverted[i, j] *= d1;
                }
            }
            e = float.Epsilon;
            det = 1;
            for (i = 0; i < n; i++)
            {
                jz[i] = i;
            }
            for (i = 0; i < n; i++)
            {
                k = i;
                y = aInverted[i, i];
                ir = i - 1;
                ip = i + 1;
                if (ip < n)
                {
                    for (j = ip; j < n; j++)
                    {
                        w = aInverted[i, j];
                        if (Math.Abs(w) > Math.Abs(y))
                        {
                            k = j;
                            y = w;
                        }
                    }
                }
                det *= y;
                y = 1f / y;
                for (j = 0; j < n; j++)
                {
                    c[j] = aInverted[j, k];
                    aInverted[j, k] = aInverted[j, i];
                    aInverted[j, i] = -c[j] * y;
                    ab[j] = aInverted[i, j] * y;
                    aInverted[i, j] = ab[j];
                }
                aInverted[i, i] = y;
                j = jz[i];
                jz[i] = jz[k];
                jz[k] = j;
                k = 0;
                do
                {
                    if ((k <= ir) | (k >= ip))
                    {
                        j = 0;
                        do
                        {
                            if ((j <= ir) | (j >= ip))
                            {
                                aInverted[k, j] -= ab[j] * c[k];
                            }
                            j++;
                        }
                        while (j < n);
                    }
                    k++;
                }
                while (k < n);
            }
            i = 0;
            do
            {
                k = jz[i];
                if (k != i)
                {
                    for (j = 0; j < n; j++)
                    {
                        w = aInverted[i, j];
                        aInverted[i, j] = aInverted[k, j];
                        aInverted[k, j] = w;
                    }
                    ip = jz[i];
                    jz[i] = jz[k];
                    jz[k] = ip;
                    det = -det;
                }
                else
                {
                    i++;
                }
            }
            while (i < n);
            d1 = 1f / d;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    aInverted[i, j] *= d1;
                }
            }
        }



        /// <summary>
        /// Calculates determinant of matrix
        /// </summary>
        /// <param name="a">The matrix</param>
        /// <returns>The determinant</returns>
        public double Det(double[,] a)
        {
            double[,] A = new double[a.GetLength(0), a.GetLength(1)];
            for (int ii = 0; ii < a.GetLength(0); ii++)
            {
                for (int jj = 0; jj < a.GetLength(1); jj++)
                {
                    A[ii, jj] = a[ii, jj];
                }
            }
            double MAX = 0;
            double D = 1;
            double T = 0;
            int k, i, j = 0;
            double z = 0;
            int n = a.GetLength(0);
            for (k = 0; k < n; k++)
            {
                MAX = 0;
                for (i = k; i < n; i++)
                {
                    T = A[i, k];
                    if (!(T == 0))
                    {
                        MAX = T;
                        j = i;
                        goto calc;
                    }
                }
            calc:
                if (MAX == 0)
                {
                    return z;
                }
                if (j != k)
                {
                    D = -D;
                    for (i = k; i < n; i++)
                    {
                        T = A[j, i];
                        A[j, i] = A[k, i];
                        A[k, i] = T;
                    }
                }
                for (i = k + 1; i < n; i++)
                {
                    T = A[i, k] / MAX;
                    for (j = k + 1; j < n; j++)
                    {
                        A[i, j] = A[i, j] - T * A[k, j];
                    }
                }
                D = D * A[k, k];
            }
            return D;
        }

        /// <summary>
        /// Calculates determinant of matrix
        /// </summary>
        /// <param name="a">The matrix</param>
        /// <returns>The determinant</returns>
        public float Det(float[,] a)
        {
            float[,] A = new float[a.GetLength(0), a.GetLength(1)];
            for (int ii = 0; ii < a.GetLength(0); ii++)
            {
                for (int jj = 0; jj < a.GetLength(1); jj++)
                {
                    A[ii, jj] = a[ii, jj];
                }
            }
            float MAX = 0;
            float D = 1;
            float T = 0;
            int k, i, j = 0;
            float z = 0;
            int n = a.GetLength(0);
            for (k = 0; k < n; k++)
            {
                MAX = 0;
                for (i = k; i < n; i++)
                {
                    T = A[i, k];
                    if (!(T == 0))
                    {
                        MAX = T;
                        j = i;
                        goto calc;
                    }
                }
            calc:
                if (MAX == 0)
                {
                    return z;
                }
                if (j != k)
                {
                    D = -D;
                    for (i = k; i < n; i++)
                    {
                        T = A[j, i];
                        A[j, i] = A[k, i];
                        A[k, i] = T;
                    }
                }
                for (i = k + 1; i < n; i++)
                {
                    T = A[i, k] / MAX;
                    for (j = k + 1; j < n; j++)
                    {
                        A[i, j] = A[i, j] - T * A[k, j];
                    }
                }
                D = D * A[k, k];
            }
            return D;
        }


        /// <summary>
        /// Scalar product
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>The product</returns>
        public double ScalarProduct(double[] x, double[] y)
        {
            double sum = 0;
            for (var i = 0; i < x.Length; i++)
            {
                sum += x[i] * y[i];
            }
            return sum;
        }

        /// <summary>
        /// Scalar product
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>The product</returns>
        public float ScalarProduct(float[] x, float[] y)
        {
            float sum = 0;
            for (var i = 0; i < x.Length; i++)
            {
                sum += x[i] * y[i];
            }
            return sum;
        }

        /// <summary>
        /// Multiplication of vector by coefficient
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="coefficient">Coefficient</param>
        public void Multiply(float[] vector, float coefficient)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = vector[i] * coefficient;
            }
        }


        /// <summary>
        /// Multiplication of vector by coefficient
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="coefficient">Coefficient</param>
        public void Multiply(double[] vector, double coefficient)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = vector[i] * coefficient;
            }
        }


        /// <summary>
        /// Matrix product
        /// </summary>
        /// <param name="a">First term</param>
        /// <param name="b">Second term</param>
        /// <param name="c">Product</param>
        public void Multiply(double[,] a, double[,] b, double[,] c)
        {
            if ((a.GetLength(1) != b.GetLength(0)) | (a.GetLength(0) != c.GetLength(0)) |
                (b.GetLength(1) != c.GetLength(1)))
            {
                throw new OwnException("Illegal matrix product dimension");
            }
            int i, j, k = 0;
            for (i = 0; i < c.GetLength(0); i++)
            {
                for (j = 0; j < c.GetLength(1); j++)
                {
                    c[i, j] = 0;
                }
            }

            for (i = 0; i < a.GetLength(0); i++)
            {
                for (j = 0; j < b.GetLength(1); j++)
                {
                    for (k = 0; k < a.GetLength(1); k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
        }


        /// <summary>
        /// Matrix product
        /// </summary>
        /// <param name="a">First term</param>
        /// <param name="b">Second term</param>
        /// <param name="c">Product</param>
        public void Multiply(float[,] a, float[,] b, float[,] c)
        {
            if ((a.GetLength(1) != b.GetLength(0)) | (a.GetLength(0) != c.GetLength(0)) |
                (b.GetLength(1) != c.GetLength(1)))
            {
                throw new OwnException("Illegal matrix product dimension");
            }
            int i, j, k = 0;
            for (i = 0; i < c.GetLength(0); i++)
            {
                for (j = 0; j < c.GetLength(1); j++)
                {
                    c[i, j] = 0;
                }
            }

            for (i = 0; i < a.GetLength(0); i++)
            {
                for (j = 0; j < b.GetLength(1); j++)
                {
                    for (k = 0; k < a.GetLength(1); k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
        }


        /// <summary>
        /// Square of vector
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <returns>Square</returns>
        public double Square(double[] vector)
        {
            double a = 0;
            foreach (double x in vector)
            {
                a += x * x;
            }
            return a;
        }

        /// <summary>
        /// Square of vector
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <returns>Square</returns>
        public float Square(float[] vector)
        {
            float a = 0;
            foreach (float x in vector)
            {
                a += x * x;
            }
            return a;
        }

        /// <summary>
        /// Norm of vector
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <returns>Norm</returns>
        public double Norm(double[] vector)
        {
            return Math.Sqrt(Square(vector));
        }

        /// <summary>
        /// Norm of vector
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <returns>Norm</returns>
        public float Norm(float[] vector)
        {
            return MathF.Sqrt(Square(vector));
        }


        /// <summary>
        /// Matrix - vector product
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="vector">The vector</param>
        /// <param name="product">The product</param>
        public void Multiply(double[,] matrix, double[] vector, double[] product)
        {
            if ((matrix.GetLength(1) != vector.Length) | (matrix.GetLength(0) != product.Length))
            {
                throw new OwnException("Illegal dimension of vector or matrix product");
            }
            int i, j = 0;
            for (i = 0; i < product.Length; i++)
            {
                product[i] = 0;
            }
            for (i = 0; i < matrix.GetLength(0); i++)
            {
                for (j = 0; j < vector.Length; j++)
                {
                    product[i] += matrix[i, j] * vector[j];
                }
            }
        }

        /// <summary>
        /// Vector - matrix product
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="product">The product</param>
		 public void Multiply(double[] vector, double[,] matrix, double[] product)
        {
            if ((matrix.GetLength(0) != vector.Length) | (matrix.GetLength(1) != product.Length))
            {
                throw new OwnException("Illegal dimension of vector or matrix product");
            }
            int i, j = 0;
            for (i = 0; i < product.Length; i++)
            {
                product[i] = 0;
            }
            for (i = 0; i < matrix.GetLength(1); i++)
            {
                for (j = 0; j < vector.Length; j++)
                {
                    product[i] += matrix[j, i] * vector[j];
                }
            }
        }

        /// <summary>
        /// Matrix - vector multiplication
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <param name="vector">Vector</param>
        /// <param name="vectorOffset">Vector offset</param>
        /// <param name="product">Result</param>
        /// <param name="productOffset">Result offset</param>
         public void Multiply(double[,] matrix, double[] vector, int vectorOffset, double[] product, int productOffset)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int e = productOffset + m;
            for (int i = productOffset; i < e; i++)
            {
                product[i] = 0;
            }
            for (int i = 0; i < n; i++)
            {
                int k = productOffset + i;
                product[k] = 0;
                for (int j = 0; j < m; j++)
                {
                    int l = j + vectorOffset;
                    product[k] += matrix[i, j] + vector[l];
                }
            }
        }

        /// <summary>
        /// Multiplication
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="matrix">Matrix</param>
        /// <param name="vectorOffset">Vector offset</param>
        /// <param name="product">Product</param>
        /// <param name="productOffset">Product offset</param>
         public void Multiply(double[] vector, double[,] matrix, int vectorOffset, double[] product, int productOffset)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int e = productOffset + n;
            for (int i = productOffset; i < e; i++)
            {
                product[i] = 0;
            }
            for (int i = 0; i < m; i++)
            {
                int k = productOffset + i;
                product[k] = 0;
                for (int j = 0; j < n; j++)
                {
                    int l = j + vectorOffset;
                    product[k] += matrix[j, i] + vector[l];
                }
            }
        }

        /// <summary>
        /// Transposition of matrix
        /// </summary>
        /// <param name="x">Matrix to transpose</param>
        /// <param name="y">Transposed matrix</param>
        public void Transpose(double[,] x, double[,] y)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    y[j, i] = x[i, j];
                }
            }
        }


        /// <summary>
        /// Performing following matrix operation B - Ht A H; Where H is transposed H
        /// </summary>
        /// <param name="h">The H matrix</param>
        /// <param name="a">The A matrix</param>
        /// <param name="result">The B matrix</param>
        public void HtAH(double[,] h, double[,] a, double[,] result)
        {
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < a.GetLength(0); k++)
                    {
                        for (int l = 0; l < a.GetLength(1); l++)
                        {
                            result[i, j] += h[k, i] * a[k, l] * h[l, j];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sum of matrixes
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">Sum</param>
        public void Add(double[,] x, double[,] y, double[,] z)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    z[i, j] = x[i, j] + y[i, j];
                }
            }
        }


        /// <summary>
        /// Sum of vectors
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">The sum</param>
        public void Add(double[] x, double[] y, double[] z)
        {
            for (int i = 0; i < x.Length; i++)
            {
                z[i] = x[i] + y[i];
            }
        }

        /// <summary>
        /// Matrix - vector product
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="vector">The vector</param>
        /// <param name="product">The product</param>
        public void Multiply(float[,] matrix, float[] vector, float[] product)
        {
            if ((matrix.GetLength(1) != vector.Length) | (matrix.GetLength(0) != product.Length))
            {
                throw new OwnException("Illegal dimension of vector or matrix product");
            }
            int i, j = 0;
            for (i = 0; i < product.Length; i++)
            {
                product[i] = 0;
            }
            for (i = 0; i < matrix.GetLength(0); i++)
            {
                for (j = 0; j < vector.Length; j++)
                {
                    product[i] += matrix[i, j] * vector[j];
                }
            }
        }

        /// <summary>
        /// Vector - matrix product
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="product">The product</param>
        public void Multiply(float[] vector, float[,] matrix, float[] product)
        {
            if ((matrix.GetLength(0) != vector.Length) | (matrix.GetLength(1) != product.Length))
            {
                throw new OwnException("Illegal dimension of vector or matrix product");
            }
            int i, j = 0;
            for (i = 0; i < product.Length; i++)
            {
                product[i] = 0;
            }
            for (i = 0; i < matrix.GetLength(1); i++)
            {
                for (j = 0; j < vector.Length; j++)
                {
                    product[i] += matrix[j, i] * vector[j];
                }
            }
        }

        /// <summary>
        /// Matrix - vector multiplication
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <param name="vector">Vector</param>
        /// <param name="vectorOffset">Vector offset</param>
        /// <param name="product">Result</param>
        /// <param name="productOffset">Result offset</param>
        public void Multiply(float[,] matrix, float[] vector, int vectorOffset, float[] product, int productOffset)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int e = productOffset + m;
            for (int i = productOffset; i < e; i++)
            {
                product[i] = 0;
            }
            for (int i = 0; i < n; i++)
            {
                int k = productOffset + i;
                product[k] = 0;
                for (int j = 0; j < m; j++)
                {
                    int l = j + vectorOffset;
                    product[k] += matrix[i, j] + vector[l];
                }
            }
        }

        /// <summary>
        /// Multiplication
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="matrix">Matrix</param>
        /// <param name="vectorOffset">Vector offset</param>
        /// <param name="product">Product</param>
        /// <param name="productOffset">Product offset</param>
        public void Multiply(float[] vector, float[,] matrix, int vectorOffset, float[] product, int productOffset)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int e = productOffset + n;
            for (int i = productOffset; i < e; i++)
            {
                product[i] = 0;
            }
            for (int i = 0; i < m; i++)
            {
                int k = productOffset + i;
                product[k] = 0;
                for (int j = 0; j < n; j++)
                {
                    int l = j + vectorOffset;
                    product[k] += matrix[j, i] + vector[l];
                }
            }
        }

        /// <summary>
        /// Transposition of matrix
        /// </summary>
        /// <param name="x">Matrix to transpose</param>
        /// <param name="y">Transposed matrix</param>
        public void Transpose(float[,] x, float[,] y)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    y[j, i] = x[i, j];
                }
            }
        }


        /// <summary>
        /// Performing following matrix operation B - Ht A H; Where H is transposed H
        /// </summary>
        /// <param name="h">The H matrix</param>
        /// <param name="a">The A matrix</param>
        /// <param name="result">The B matrix</param>
        public void HtAH(float[,] h, float[,] a, float[,] result)
        {
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < a.GetLength(0); k++)
                    {
                        for (int l = 0; l < a.GetLength(1); l++)
                        {
                            result[i, j] += h[k, i] * a[k, l] * h[l, j];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sum of matrixes
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">Sum</param>
        public void Add(float[,] x, float[,] y, float[,] z)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    z[i, j] = x[i, j] + y[i, j];
                }
            }
        }


        /// <summary>
        /// Sum of vercors
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">The sum</param>
        public void Add(float[] x, float[] y, float[] z)
        {
            for (int i = 0; i < x.Length; i++)
            {
                z[i] = x[i] + y[i];
            }
        }



        /// <summary>
        /// Sum of vectors
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="offset1">First offset</param>
        /// <param name="vector2">Second vector</param>
        /// <param name="offset2">Second offset</param>
        /// <param name="sum">Sum</param>
        /// <param name="offsetSum">Sum offset</param>
        /// <param name="length">Length of vector</param>
        public void Add(double[] vector1, int offset1, double[] vector2, int offset2, double[] sum,
            int offsetSum, int length)
        {
            for (int i = 0; i < length; i++)
            {
                sum[i + offsetSum] = vector1[i + offset1] + vector2[i + offset2];
            }
        }

        /// <summary>
        /// Matrix substraction
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">Difference</param>
        public void Difference(double[,] x, double[,] y, double[,] z)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    z[i, j] = x[i, j] - y[i, j];
                }
            }
        }

        /// <summary>
        /// Vector substraction
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">Difference</param>
        public void Difference(double[] x, double[] y, double[] z)
        {
            for (int i = 0; i < x.Length; i++)
            {
                z[i] = x[i] - y[i];
            }
        }


        /// <summary>
        /// Normalizes vector x
        /// </summary>
        /// <param name="x">Vector for normalization</param>
        public void Normalize(double[] x)
        {
            double a = 0;
            for (int i = 0; i < x.Length; i++)
            {
                double b = x[i];
                a += b * b;
            }
            a = 1 / Math.Sqrt(a);
            for (int i = 0; i < x.Length; i++)
            {
                x[i] *= a;
            }
        }

        /// <summary>
        /// Normalization of vector
        /// </summary>
        /// <param name="x">The vector</param>
        /// <param name="offset">Offset</param>
        /// <param name="length">Length</param>
        public void Normalize(double[] x, int offset, int length)
        {
            double a = 0;
            int k = offset + length;
            for (int i = offset; i < k; i++)
            {
                double b = x[i];
                a += b * b;
            }
            a = 1 / Math.Sqrt(a);
            for (int i = offset; i < k; i++)
            {
                x[i] *= a;
            }

        }

        /// <summary>
        /// Lagrange interpolation
        /// </summary>
        /// <param name="t">Argument</param>
        /// <param name="degree">degree</param>
        /// <param name="begin">begin index</param>
        /// <param name="x">Coefficients</param>
        /// <returns>Value of interpolated polynom</returns>
        public double LagrangeInterpolation(double t, int degree, int begin, object[,] x)
        {
            double result = 0;
            int n = degree + 1;
            for (int i = 0; i < n; i++)
            {
                int k = i + begin;
                double a = 1;
                double b = 1;
                double arg = (double)x[k, 0];
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    int l = j + begin;
                    double curr = (double)x[l, 0];
                    a *= t - curr;
                    b *= arg - curr;
                }
                result += ((double)x[k, 1]) * a / b;
            }
            return result;
        }

        /// <summary>
        /// Lagrange interpolation
        /// </summary>
        /// <param name="t">Argument</param>
        /// <param name="degree">degree</param>
        /// <param name="begin">begin index</param>
        /// <param name="x">Coefficients</param>
        /// <returns>Value of interpolated polynom</returns>
        public double LagrangeInterpolation(double t, int degree, int begin, IList<object[]> x)
        {
            int d = degree;
            if (d > x.Count - 1)
            {
                d = x.Count - 1;
            }
            double result = 0;
            int n = d + 1;
            for (int i = 0; i < n; i++)
            {
                int k = i + begin;
                double a = 1;
                double b = 1;
                double arg = (double)x[k][0];
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    int l = j + begin;
                    double curr = (double)x[l][0];
                    a *= t - curr;
                    b *= arg - curr;
                }
                result += ((double)x[k][1]) * a / b;
            }
            return result;
        }


        /// <summary>
        /// LU decomposition of matrix
        /// </summary>
        /// <param name="A">The matrix</param>
        /// <param name="indx">Decomposition indx</param>
        /// <returns>True in success and false otherwise</returns>
        public bool LU_Factor(double[,] A, int[] indx)
        {
            int i = 0, j = 0, k = 0;
            int jp = 0;
            double t = 0;
            int M = A.GetLength(0);
            int N = A.GetLength(1);
            int minMN = (M < N ? M : N);

            for (j = 0; j < minMN; j++)
            {

                // find pivot in column j and  test for singularity.

                jp = j;
                t = Math.Abs(A[j, j]);
                for (i = j + 1; i < M; i++)
                {
                    if (Math.Abs(A[i, j]) > Math.Abs(t))
                    {
                        jp = i;
                        t = Math.Abs(A[i, j]);
                    }
                }

                indx[j] = jp;

                // jp now has the index of maximum element
                // of column j, below the diagonal
                double zero = 0;


                if (A[jp, j] == zero)
                {
                    return false;       // factorization failed because of zero pivot
                }


                if (jp != j)            // swap rows j and jp
                {
                    for (k = 0; k < N; k++)
                    {
                        t = A[j, k];
                        A[j, k] = A[jp, k];
                        A[jp, k] = t;
                    }
                }

                if (j < M - 1)                // compute elements j+1:M of jth column
                {
                    // note A(j,j), was A(jp,p) previously which was
                    // guarranteed not to be zero (Label #1)
                    double y = 1;
                    double recp = y / A[j, j];
                    for (k = j + 1; k < M; k++)
                    {
                        A[k, j] *= recp;
                    }
                }


                if (j < minMN - 1)
                {
                    // rank-1 update to trailing submatrix:   E = E - x*y;
                    //
                    // E is the region A(j+1:M, j+1:N)
                    // x is the column vector A(j+1:M,j)
                    // y is row vector A(j,j+1:N)

                    int ii, jj;

                    for (ii = j + 1; ii < M; ii++)
                    {
                        for (jj = j + 1; jj < N; jj++)
                        {
                            A[ii, jj] -= A[ii, j] * A[j, jj];
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Solution of linear equations by LU Decomposition
        /// </summary>
        /// <param name="A">Matrix</param>
        /// <param name="indx">Decomposition index</param>
        /// <param name="b">Right part</param>
        /// <returns>True in success and false otherwise</returns>
        public bool LU_Solve(double[,] A, int[] indx, double[] b)
        {
            int i, ii = -1, ip = 0, j;
            int n = b.Length;
            double sum = 0;

            for (i = 0; i < n; i++)
            {
                ip = indx[i];
                sum = b[ip];
                b[ip] = b[i];
                if (ii >= 0)
                {
                    for (j = ii; j < i; j++)
                    {
                        sum -= A[i, j] * b[j];
                    }
                }
                else if (Math.Abs(sum) > 0)
                {
                    ii = i;
                }
                b[i] = sum;
            }
            for (i = n - 1; i >= 0; i--)
            {
                sum = b[i];
                for (j = i + 1; j < n; j++)
                {
                    sum -= A[i, j] * b[j];
                }
                b[i] = sum / A[i, i];
            }
            return true;
        }

        /// <summary>
        /// += operation for arrays
        /// </summary>
        /// <param name="x">First argument</param>
        /// <param name="y">Secong Argument</param>
        public void PlusEqual(double[] x, double[] y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] += y[i];
            }
        }
        /// <summary>
        /// -= operation for arrays
        /// </summary>
        /// <param name="x">First argument</param>
        /// <param name="y">Secong Argument</param>
        public void MinusEqual(double[] x, double[] y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] -= y[i];
            }
        }

        /// <summary>
        /// Solves system of linear equations
        /// </summary>
        /// <param name="a">Matrix of equations</param>
        /// <param name="b">Right part</param>
        /// <param name="indx">Auxiliary array</param>
        /// <returns>True in succces and false otherwise</returns>
        public bool Solve(double[,] a, double[] b, int[] indx)
        {
            if (!LU_Factor(a, indx))
            {
                return false;
            }
            if (!LU_Solve(a, indx, b))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets main minor of matrix
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="order">Order of minor</param>
        /// <returns>The minor</returns>
        public double[,] GetMainMinor(double[,] matrix, int order)
        {
            double[,] b = new double[order, order];
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    b[i, j] = matrix[i, j];
                }
            }
            return b;
        }


        /// <summary>
        /// Kalman filter
        /// </summary>
        /// <param name="state">State</param>
        /// <param name="delta">Delta</param>
        /// <param name="transition">Transition matrix</param>
        /// <param name="partial">Partial derivation matrix</param>
        /// <param name="covariation">Covariation matrix</param>
        /// <param name="errorCovariation">State error covariation</param>
        /// <param name="measurementCovariation">Measurements error covariation</param>
        /// <param name="coefficient">Auxiliary variable</param>
        /// <param name="partialTrans">Auxiliary variable</param>
        /// <param name="partialPeer">Auxiliary variable</param>
        /// <param name="errorCovariationPeer">Auxiliary variable</param>
        /// <param name="errorCovariationPeerPlus">Auxiliary variable</param>
        /// <param name="statePeer">Auxiliary variable</param>
        /// <param name="covariationPeer">Auxiliary variable</param>
        /// <param name="covariationPeerPlus">Auxiliary variable</param>
        public void KalmanFilter(double[] state, double[] delta,
            double[,] transition, double[,] partial, double[,] covariation,
            double[,] errorCovariation, double[,] measurementCovariation, double[,] coefficient, double[,] partialTrans,
            double[,] partialPeer, double[,] errorCovariationPeer, double[,] errorCovariationPeerPlus,
            double[] statePeer, double[,] covariationPeer, double[,] covariationPeerPlus)
        {
            Transpose(transition, covariationPeer);
            Multiply(covariation, covariationPeer, covariationPeerPlus);
            Multiply(transition, covariationPeerPlus, covariationPeer);
            Add(covariationPeer, errorCovariation, covariation);
            Transpose(partial, partialTrans);
            Multiply(covariation, partialTrans, partialPeer);
            Multiply(partial, partialPeer, errorCovariationPeer);
            Add(errorCovariationPeer, measurementCovariation, errorCovariationPeerPlus);
            Invert(errorCovariationPeerPlus, errorCovariationPeer);
            Multiply(partialPeer, errorCovariationPeer, coefficient);
            Multiply(coefficient, delta, statePeer);
            for (int i = 0; i < state.Length; i++)
            {
                state[i] -= statePeer[i];
            }
            Multiply(coefficient, partial, covariationPeer);
            Multiply(covariationPeer, covariation, covariationPeerPlus);
            for (int i = 0; i < covariation.GetLength(0); i++)
            {
                for (int j = 0; j < covariation.GetLength(1); j++)
                {
                    covariation[i, j] -= covariationPeerPlus[i, j];
                }
            }
        }

 
  
 
 


        /// <summary>
        /// Matrix substraction
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">Difference</param>
        public void Difference(float[,] x, float[,] y, float[,] z)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    z[i, j] = x[i, j] - y[i, j];
                }
            }
        }

        /// <summary>
        /// Vector substraction
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">Difference</param>
        public void Difference(float[] x, float[] y, float[] z)
        {
            for (int i = 0; i < x.Length; i++)
            {
                z[i] = x[i] - y[i];
            }
        }


        /// <summary>
        /// Normalizes vector x
        /// </summary>
        /// <param name="x">Vector for normalization</param>
        public void Normalize(float[] x)
        {
            float a = 0;
            for (int i = 0; i < x.Length; i++)
            {
                float b = x[i];
                a += b * b;
            }
            a = 1 / MathF.Sqrt(a);
            for (int i = 0; i < x.Length; i++)
            {
                x[i] *= a;
            }
        }

        /// <summary>
        /// Normalization of vector
        /// </summary>
        /// <param name="x">The vector</param>
        /// <param name="offset">Offset</param>
        /// <param name="length">Length</param>
        public void Normalize(float[] x, int offset, int length)
        {
            float a = 0;
            int k = offset + length;
            for (int i = offset; i < k; i++)
            {
                float b = x[i];
                a += b * b;
            }
            a = 1 / MathF.Sqrt(a);
            for (int i = offset; i < k; i++)
            {
                x[i] *= a;
            }

        }

        /// <summary>
        /// Lagrange interpolation
        /// </summary>
        /// <param name="t">Argument</param>
        /// <param name="degree">degree</param>
        /// <param name="begin">begin index</param>
        /// <param name="x">Coefficients</param>
        /// <returns>Value of interpolated polynom</returns>
        public float LagrangeInterpolation(float t, int degree, int begin, object[,] x)
        {
            float result = 0;
            int n = degree + 1;
            for (int i = 0; i < n; i++)
            {
                int k = i + begin;
                float a = 1;
                float b = 1;
                float arg = (float)x[k, 0];
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    int l = j + begin;
                    float curr = (float)x[l, 0];
                    a *= t - curr;
                    b *= arg - curr;
                }
                result += ((float)x[k, 1]) * a / b;
            }
            return result;
        }

        /// <summary>
        /// Lagrange interpolation
        /// </summary>
        /// <param name="t">Argument</param>
        /// <param name="degree">degree</param>
        /// <param name="begin">begin index</param>
        /// <param name="x">Coefficients</param>
        /// <returns>Value of interpolated polynom</returns>
        public float LagrangeInterpolation(float t, int degree, int begin, IList<object[]> x)
        {
            int d = degree;
            if (d > x.Count - 1)
            {
                d = x.Count - 1;
            }
            float result = 0;
            int n = d + 1;
            for (int i = 0; i < n; i++)
            {
                int k = i + begin;
                float a = 1;
                float b = 1;
                float arg = (float)x[k][0];
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    int l = j + begin;
                    float curr = (float)x[l][0];
                    a *= t - curr;
                    b *= arg - curr;
                }
                result += ((float)x[k][1]) * a / b;
            }
            return result;
        }


        /// <summary>
        /// LU decomposition of matrix
        /// </summary>
        /// <param name="A">The matrix</param>
        /// <param name="indx">Decomposition indx</param>
        /// <returns>True in success and false otherwise</returns>
        public bool LU_Factor(float[,] A, int[] indx)
        {
            int i = 0, j = 0, k = 0;
            int jp = 0;
            float t = 0;
            int M = A.GetLength(0);
            int N = A.GetLength(1);
            int minMN = (M < N ? M : N);

            for (j = 0; j < minMN; j++)
            {

                // find pivot in column j and  test for singularity.

                jp = j;
                t = Math.Abs(A[j, j]);
                for (i = j + 1; i < M; i++)
                {
                    if (Math.Abs(A[i, j]) > Math.Abs(t))
                    {
                        jp = i;
                        t = Math.Abs(A[i, j]);
                    }
                }

                indx[j] = jp;

                // jp now has the index of maximum element
                // of column j, below the diagonal
                float zero = 0;


                if (A[jp, j] == zero)
                {
                    return false;       // factorization failed because of zero pivot
                }


                if (jp != j)            // swap rows j and jp
                {
                    for (k = 0; k < N; k++)
                    {
                        t = A[j, k];
                        A[j, k] = A[jp, k];
                        A[jp, k] = t;
                    }
                }

                if (j < M - 1)                // compute elements j+1:M of jth column
                {
                    // note A(j,j), was A(jp,p) previously which was
                    // guarranteed not to be zero (Label #1)
                    float y = 1;
                    float recp = y / A[j, j];
                    for (k = j + 1; k < M; k++)
                    {
                        A[k, j] *= recp;
                    }
                }


                if (j < minMN - 1)
                {
                    // rank-1 update to trailing submatrix:   E = E - x*y;
                    //
                    // E is the region A(j+1:M, j+1:N)
                    // x is the column vector A(j+1:M,j)
                    // y is row vector A(j,j+1:N)

                    int ii, jj;

                    for (ii = j + 1; ii < M; ii++)
                    {
                        for (jj = j + 1; jj < N; jj++)
                        {
                            A[ii, jj] -= A[ii, j] * A[j, jj];
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Solution of linear equations by LU Decomposition
        /// </summary>
        /// <param name="A">Matrix</param>
        /// <param name="indx">Decomposition index</param>
        /// <param name="b">Right part</param>
        /// <returns>True in success and false otherwise</returns>
        public bool LU_Solve(float[,] A, int[] indx, float[] b)
        {
            int i, ii = -1, ip = 0, j;
            int n = b.Length;
            float sum = 0;

            for (i = 0; i < n; i++)
            {
                ip = indx[i];
                sum = b[ip];
                b[ip] = b[i];
                if (ii >= 0)
                {
                    for (j = ii; j < i; j++)
                    {
                        sum -= A[i, j] * b[j];
                    }
                }
                else if (Math.Abs(sum) > 0)
                {
                    ii = i;
                }
                b[i] = sum;
            }
            for (i = n - 1; i >= 0; i--)
            {
                sum = b[i];
                for (j = i + 1; j < n; j++)
                {
                    sum -= A[i, j] * b[j];
                }
                b[i] = sum / A[i, i];
            }
            return true;
        }

        /// <summary>
        /// += operation for arrays
        /// </summary>
        /// <param name="x">First argument</param>
        /// <param name="y">Secong Argument</param>
        public void PlusEqual(float[] x, float[] y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] += y[i];
            }
        }
        /// <summary>
        /// -= operation for arrays
        /// </summary>
        /// <param name="x">First argument</param>
        /// <param name="y">Secong Argument</param>
        public void MinusEqual(float[] x, float[] y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] -= y[i];
            }
        }

        /// <summary>
        /// Solves system of linear equations
        /// </summary>
        /// <param name="a">Matrix of equations</param>
        /// <param name="b">Right part</param>
        /// <param name="indx">Auxiliary array</param>
        /// <returns>True in succces and false otherwise</returns>
        public bool Solve(float[,] a, float[] b, int[] indx)
        {
            if (!LU_Factor(a, indx))
            {
                return false;
            }
            if (!LU_Solve(a, indx, b))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets main minor of matrix
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="order">Order of minor</param>
        /// <returns>The minor</returns>
        public float[,] GetMainMinor(float[,] matrix, int order)
        {
            float[,] b = new float[order, order];
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    b[i, j] = matrix[i, j];
                }
            }
            return b;
        }


        /// <summary>
        /// Kalman filter
        /// </summary>
        /// <param name="state">State</param>
        /// <param name="delta">Delta</param>
        /// <param name="transition">Transition matrix</param>
        /// <param name="partial">Partial derivation matrix</param>
        /// <param name="covariation">Covariation matrix</param>
        /// <param name="errorCovariation">State error covariation</param>
        /// <param name="measurementCovariation">Measurements error covariation</param>
        /// <param name="coefficient">Auxiliary variable</param>
        /// <param name="partialTrans">Auxiliary variable</param>
        /// <param name="partialPeer">Auxiliary variable</param>
        /// <param name="errorCovariationPeer">Auxiliary variable</param>
        /// <param name="errorCovariationPeerPlus">Auxiliary variable</param>
        /// <param name="statePeer">Auxiliary variable</param>
        /// <param name="covariationPeer">Auxiliary variable</param>
        /// <param name="covariationPeerPlus">Auxiliary variable</param>
  
        //c diagonalisation of positive defined matrix A (N*N)
        //c A=S*B*St (1) (B - diagonal matrix, S- orthogonal one)
        //c N - dimension
        //c RHO - accuracy
        //c A(N,N) - input - matrix A, output - matrix B (see (1))
        //c S(N,N) - orthogonal matrix (see (1)) 
        //      dimension A(n,n),S(n,n)


        /// <summary>
        /// Diagonalization by Jacoby method 
        /// a=s*b*st (1) (b - diagonal matrix, s- orthogonal one)
        /// </summary>
        /// <param name="a">Diagonal matrix</param>
        /// <param name="s">Orthogonal matrix</param>
        /// <param name="eps">Accuracy</param>
        public void Jacoby(double[,] a, double[,] s, double eps)
        {
            int n = a.GetLength(0);
            double int1 = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s[i, j] = (i == j) ? 1 : 0;
                    int1 += a[i, j];
                }
            }
            double norm1 = Math.Sqrt(int1);
            double thr = norm1;
            double norm2 = (eps / n) * norm1;
            bool ind;
            do
            {
                ind = false;
                thr /= n;
                do
                {
                    ind = false;
                    for (int q = 0; q < n; q++)
                    {
                        for (int p = 0; p < q; p++)
                        {
                            if (Math.Abs(a[p, q]) <= thr)
                            {
                                continue;
                            }
                            ind = true;
                            double V1 = a[p, p];
                            double V2 = a[p, q];
                            double V3 = a[q, q];
                            double MU = 0.5 * (V1 - V3);
                            double oMEGA = (MU == 0) ? -1 : -(V2 / Math.Sqrt(V2 * V2 + MU * MU)) * ((MU > 0) ? 1 : -1);
                            double SINT = oMEGA / Math.Sqrt(2 * (1 + Math.Sqrt(1 - oMEGA * oMEGA)));
                            double CoST = Math.Sqrt(1 - SINT * SINT);
                            for (int i = 0; i < n; i++)
                            {
                                int1 = a[i, p] * CoST - a[i, q] * SINT;
                                a[i, q] = a[i, p] * SINT + a[i, q] * CoST;
                                a[i, p] = int1;
                                int1 = s[i, p] * CoST - s[i, q] * SINT;
                                s[i, q] = s[i, p] * SINT + s[i, q] * CoST;
                                s[i, p] = int1;
                            }
                            for (int i = 0; i < n; i++)
                            {
                                a[p, i] = a[i, p];
                                a[q, i] = a[i, q];
                            }
                            a[p, p] = V1 * CoST * CoST + V3 * SINT * SINT - 2 * V2 * SINT * CoST;
                            a[q, q] = V1 * SINT * SINT + V3 * CoST * CoST + 2 * V2 * SINT * CoST;
                            a[p, q] = (V1 - V3) * SINT * CoST + V2 * (CoST * CoST - SINT * SINT);
                            a[q, p] = a[p, q];
                        }
                    }
                }
                while (ind);
            }
            while (thr >= norm2);
        }

    }
}


