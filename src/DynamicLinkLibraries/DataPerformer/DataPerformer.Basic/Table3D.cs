using ErrorHandler;
using System;
using System.IO;
using System.Runtime.Serialization;



namespace DataPerformer.Basic
{
    /// <summary>
    /// 3D Table
    /// </summary>
    [Serializable()]
    public class Table3D : Portable.Basic.Table3D, ISerializable
    {
  
        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        protected Table3D()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="arguments">Values of arguments</param>
        /// <param name="function">Values of function</param>
        public Table3D(double[][] arguments, double[,,] function) : base(arguments, function)
        {
        }

       /// <summary>
        /// Deserilaization constructor
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected Table3D(SerializationInfo info, StreamingContext context)
        {
            args = info.GetValue("Args", typeof(double[][])) as double[][];
            fun = info.GetValue("Fun", typeof(double[, ,])) as double[, ,];
            throwsOutOfRangeException = info.GetBoolean("ThrowsOutOfRangeException");
            comments = info.GetValue("Comments", typeof(byte[])) as byte[];
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Args", args, typeof(double[][]));
            info.AddValue("Fun", fun, typeof(double[,,]));
            info.AddValue("ThrowsOutOfRangeException", throwsOutOfRangeException);
            info.AddValue("Comments", comments, typeof(byte[]));
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Loading
        /// </summary>
        /// <param name="stream">The stream to load</param>
        public void Load(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);
            int n = reader.ReadInt32();
            int m = reader.ReadInt32();
            int k = reader.ReadInt32();
            args[0] = new double[n];
            args[1] = new double[m];
            args[2] = new double[k];
            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 0; j < args[i].Length; j++)
                {
                    args[i][j] = reader.ReadDouble();
                }
            }
            fun = new double[n, m, k];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int l = 0; l < k; l++)
                    {
                        fun[i, j, l] = reader.ReadDouble();
                    }
                }
            }
        }

        /// <summary>
        /// Saving
        /// </summary>
        /// <param name="stream">The stream to save</param>
        public void Save(Stream stream)
        {
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(args[0].Length);
            writer.Write(args[1].Length);
            writer.Write(args[2].Length);
            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 0; j < args[i].Length; j++)
                {
                    writer.Write(args[i][j]);
                }
            }
            for (int i = 0; i < fun.GetLength(0); i++)
            {
                for (int j = 0; j < fun.GetLength(1); j++)
                {
                    for (int k = 0; k < fun.GetLength(2); k++)
                    {
                        writer.Write(fun[i, j, k]);
                    }
                }
            }
        }

 
 
        /// <summary>
        /// Array of extremums
        /// </summary>
      /*  public double[] Extremums
        {
            get
            {
                double[] e = new double[] { fun[0, 0], fun[0, 0] };
                for (int i = 0; i < fun.GetLength(0); i++)
                {
                    for (int j = 0; j < fun.GetLength(1); j++)
                    {
                        double x = fun[i, j];
                        if (x < e[0])
                        {
                            e[0] = x;
                        }
                        if (x > e[1])
                        {
                            e[1] = x;
                        }
                    }
                }
                return e;
            }
        }*/


  
        #endregion

        #region Protected Methods

        /// <summary>
        /// Calculates value of function
        /// </summary>
        /// <param name="x">X - argument</param>
        /// <param name="y">Y - argument</param>
        /// <param name="z">Z - argument</param>
        /// <returns>Value of function</returns>
        new protected double Calculate(double x, double y, double z)
        {
            arg[0] = x;
            arg[1] = y;
            arg[2] = z;
            for (int i = 0; i < 3; i++)
            {
                if ((arg[i] < args[i][0]) | (arg[i] > args[i][args[i].Length - 1]))
                {
                    if (throwsOutOfRangeException)
                    {
                        throw new OwnException("Out of range");
                    }
                }
                for (int j = 0; j < args[i].Length - 1; j++)
                {
                    if (arg[i] >= args[i][j] & arg[i] <= args[i][j + 1])
                    {
                        nm[i] = j;
                        goto m;
                    }
                }
                nm[i] = args[i].Length - 1;
            m:
                continue;
            }
            double f = fun[nm[0], nm[1], nm[2]];
            result[0] = f;
            result[1] = 0;
            double delta = 0;
            for (int i = 0; i < 2; i++)
            {
                double d = 0;
                if (i == 0)
                {
                    int k = nm[0] + 1;
                    if (k >= args[0].Length)
                    {
                        k = args[0].Length - 1;
                    }
                    d = fun[k, nm[1], nm[2]];
                    delta = args[0][k] - args[0][nm[0]];
                }
                else
                {
                    int k = nm[1] + 1;
                    if (k >= args[1].Length)
                    {
                        k = args[1].Length - 1;
                    }
                    d = fun[nm[0], k, k];
                    delta = args[1][k] - args[1][nm[1]];
                }
                dx[i] = (d - f) / delta;
                result[0] += dx[i] * (arg[i] - args[i][nm[i]]);
            }
            return result[0];
        }


        /// <summary>
        /// Pre initialization
        /// </summary>
        new protected virtual void PreInit()
        {
        }

        /// <summary>
        /// Gets function value
        /// </summary>
        /// <returns>The value</returns>
        new protected object GetFunction()
        {
            return result[0];
        }


        #endregion
    }
}
