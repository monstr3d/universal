using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.IO;

using CategoryTheory;

using Diagram.UI;

using Motion6D;
using Motion6D.Interfaces;

namespace InterfaceOpenGL
{
    [Serializable()]
    public class ShapeGL : CategoryObject, ISerializable, IVisible, IRemovableObject
    {

        #region Fields
        
        /// <summary>
        /// File name
        /// </summary>
        protected string filename = "";

        protected OpenGL_Library.ShapeGL shape = new OpenGL_Library.ShapeGL();

        /// <summary>
        /// Coordinates of facets
        /// </summary>
        internal double[] facetCoordinates;

        /// <summary>
        /// Number of facets
        /// </summary>
        internal int facetNumber;

        /// <summary>
        /// Position
        /// </summary>
        IPosition position;

        #endregion

        #region Ctor

        internal ShapeGL()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ShapeGL(SerializationInfo info, StreamingContext context)
        {
            filename = info.GetValue("FileName", typeof(string)) as string;
            Initialize();
        }

        ~ShapeGL()
        {
            try
            {
                IRemovableObject r = this;
                r.RemoveObject();
            }
            catch (Exception excepton)
            {
                excepton.ShowError();
            }
        }

        #endregion

        #region ISerializable Members

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FileName", filename, typeof(string));
        }

        #endregion

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            if (shape != null)
            {
                shape.Dispose();
                shape = null;
            }
        }

        #endregion

        #region IPositionObject Members

        IPosition IPositionObject.Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        #endregion
 
        #region Public & Protected Members

        /// <summary>
        /// Values of parameters
        /// </summary>
        public double[] Values
        {
            get
            {
                return facetCoordinates;
            }
        }

        /// <summary>
        /// Initialization
        /// </summary>
        protected virtual void Initialize()
        {
            string fn = AppDomain.CurrentDomain.BaseDirectory +
                "Shapes" + Path.DirectorySeparatorChar + filename;
            if (!File.Exists(fn))
            {
                this.Throw(new Exception("File: " + fn + " does not exist"));
            }
            Stream stream = File.OpenRead(fn);
            BinaryReader reader = new BinaryReader(stream);
            facetNumber = reader.ReadInt32();
            if (facetNumber > 0)
            {
                facetCoordinates = new double[12 * facetNumber];
                for (int i = 0; i < facetCoordinates.Length; i++)
                {
                    facetCoordinates[i] = reader.ReadDouble();
                }
                shape.Set(facetNumber, facetCoordinates);
            }
        }

        #endregion

        #region Internal & Private Members

        internal bool Save(Stream stream)
        {
            if (facetCoordinates == null)
            {
                return false;
            }
            BinaryWriter w = new BinaryWriter(stream);
            w.Write(facetNumber);
            for (int i = 0; i < facetCoordinates.Length; i++)
            {
                w.Write(facetCoordinates[i]);
            }
            return true;
        }

        internal string Filename
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
                Initialize();
            }
        }

        internal OpenGL_Library.ShapeGL Shape
        {
            get
            {
                return shape;
            }
        }
        
        #endregion

   }
}
