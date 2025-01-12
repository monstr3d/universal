using System;
using System.Collections.Generic;
using System.Windows.Markup;
using System.Windows.Media.Media3D;


using Motion6D.Interfaces;
using Motion6D;

using WpfInterface.Interfaces;
using WpfInterface.Animated;
using BaseTypes;

namespace WpfInterface
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionWpfInterface
    {

        #region Fields

        static double[] x = new double[3];

        private static Dictionary<string, Func<string, Visual3D>> dic = new();

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionWpfInterface()
        {

        }

        #region Public Members

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init()
        {

        }



        /// <summary>
        /// Sets transformation
        /// </summary>
        /// <param name="position">Position</param>
        /// <param name="transform">Transformation</param>
        public static void SetTransform(this IPosition position, MatrixTransform3D transform)
        {
            ReferenceFrame r = position.GetParentFrame();
            double[,] m = r.Matrix;
            double[] x = position.Position;
            Matrix3D matr = new Matrix3D(m[0, 0], m[1, 0], m[2, 0], 0,
                                         m[0, 1], m[1, 1], m[2, 1], 0,
                                         m[0, 2], m[1, 2], m[2, 2], 0,
                                           x[0], x[1], x[2], 1);
            transform.Matrix = matr;
       }

        /// <summary>
        /// Gets area
        /// </summary>
        /// <param name="points">Points</param>
        /// <returns>Area</returns>
        public static double GetArea(Point3D[] points)
        {
            return 0;
        }

        public static void SetTransform(this IPosition position, Visual3D visual)
        {
           
            SerializablePosition sp = position as SerializablePosition;
            IWpfVisible v = sp.Parameters as IWpfVisible;
            SetTransform(position, visual.Transform as MatrixTransform3D);
        }
   

        static public double GetArea(this Point3D[] points, out System.Windows.Media.Media3D.Vector3D normal)
        {
            System.Windows.Media.Media3D.Vector3D v1 = points[1] - points[0];
            System.Windows.Media.Media3D.Vector3D v2 = points[2] - points[0];
            System.Windows.Media.Media3D.Vector3D n = System.Windows.Media.Media3D.Vector3D.CrossProduct(v1, v2);
            double a = n.Length / 2;
            n.Normalize();
            normal = n;
            return a;
        }

        /// <summary>
        /// 3D file load
        /// </summary>
        public static Dictionary<string, Func<string, Visual3D>> FileLoad
        {
            get
            {
                return dic;
            }
        }

  
        static public void Create(this MeshGeometry3D mesh, out double[] areas, out double[][] centers)
        {
            Point3DCollection pos = mesh.Positions;
            Vector3DCollection vcol = new Vector3DCollection();
            int n = pos.Count / 3;
            areas = new double[n];
            centers = new double[n][];
            for (int i = 0; i < n; i++)
            {
                double[] center = new double[]{0, 0, 0};
                int k = 3 * i;
                Point3D[] p = new Point3D[]{pos[k], pos[k + 1], pos[k + 2]};
                for (int j = 0; j < 3; j++)
                {
                    center[0] += p[j].X;
                    center[1] += p[j].Y;
                    center[2] += p[j].Z;
                }
                for (int j = 0; j < 3; j++)
                {
                    center[j] /= 3;
                }
                centers[i] = center;
                System.Windows.Media.Media3D.Vector3D ved;
                areas[i] = p.GetArea(out ved);
                vcol.Add(ved);
            }
            mesh.Normals = vcol;
        }

        static public double GetCoordinate(this Point3D p, int i)
        {
            return (i == 0) ? p.X : ((i == 1) ? p.Y : p.Z);
        }

        #endregion

        #region Private & Internal Mebmers

        /// <summary>
        /// Enqueue animated object
        /// </summary>
        /// <param name="animatedObject">Animated Object</param>
        /// <param name="timeSpan">Time Span</param>
        internal static void Enqueue(this IAnimatedObject animatedObject, TimeSpan timeSpan)
        {
            ReferenceFrame frame = animatedObject.ReferenceFrame;
            double[] position = new double[3];
            Array.Copy(frame.Position, position, 3);
            double[] quaternion = new double[4];
            Array.Copy(frame.Quaternion, quaternion, 4);
            Tuple<TimeSpan, double[], double[]> parameters =
                new Tuple<TimeSpan, double[], double[]>(timeSpan, position, quaternion);
            foreach (AnimatableWrapper wrapper in animatedObject.Children)
            {
                wrapper.Enqueue(parameters);
            }
        }

    

        #endregion
    }
}
