using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;
using System.IO;


using CategoryTheory;

using BaseTypes.Interfaces;
using BaseTypes;


using Diagram.UI;
using Diagram.UI.Labels;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;

namespace DataPerformer
{
    /// <summary>
    /// Table of two parameters
    /// This table uses linear interpolation
    /// </summary>
    [Serializable()]
    public class Table2D : Portable.Table2D, ISerializable
    {
        #region Fields

        /// <summary>
        /// Tags of arguments
        /// </summary>
        private static readonly string[] argumentTags = new string[] { "ArgumentX", "ArgumentY" };

        /// <summary>
        /// Tags of arguments
        /// </summary>
        private static readonly string[] argumentAttr = new string[] { "nX", "nY" };


        private const string Values = "Values";

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Table2D()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="arguments">Values of arguments</param>
        /// <param name="function">Values of function</param>
        public Table2D(double[][] arguments, double[,] function) : base()
        {
            Set(arguments, function);
        }

        /// <summary>
        /// Deserilaization constructor
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected Table2D(SerializationInfo info, StreamingContext context)
        {
            args = (double[][])info.GetValue("Args", typeof(double[][]));
            fun = (double[,])info.GetValue("Fun", typeof(double[,]));

            try
            {
                comments = info.GetValue("Comments", typeof(byte[])) as byte[];
            }
            catch (Exception)
            {

            }
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
            info.AddValue("Args", args);
            info.AddValue("Fun", fun);
            info.AddValue("ThrowsOutOfRangeException", throwsOutOfRangeException);
            info.AddValue("Comments", comments, typeof(byte[]));
        }

        #endregion

        #region Specific Members

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
            args[0] = new double[n];
            args[1] = new double[m];
            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 0; j < args[i].Length; j++)
                {
                    args[i][j] = reader.ReadDouble();
                }
            }
            fun = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    fun[i, j] = reader.ReadDouble();
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
                    writer.Write(fun[i, j]);
                }
            }
        }



        /// <summary>
        /// Comments
        /// </summary>
        public ICollection Comments
        {
            get
            {
                return PureDesktopPeer.Deserialize(comments) as ICollection;
            }
            set
            {
                comments = PureDesktopPeer.Serialize(value);
            }
        }


        #endregion

        #region Protected Members


        #endregion

        #region Private Members


        #endregion

        #endregion

    }
}
