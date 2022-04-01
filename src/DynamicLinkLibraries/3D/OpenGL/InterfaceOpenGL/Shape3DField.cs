using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using CategoryTheory;

using BaseTypes;

using Motion6D;
using Motion6D.Interfaces;

using PhysicalField;

namespace InterfaceOpenGL
{
    /// <summary>
    /// Shape 3 and field consumer
    /// </summary>
    [Serializable()]
    public class Shape3DField : ShapeGL, ISerializable, IFacet, IPositionObject, IChildrenObject
    {

        #region Fields

        /// <summary>
        /// Field consumer of 3D field
        /// </summary>
        private FieldConsumer3D consumer = null;

        private IPosition position;

        /// <summary>
        /// Types of parameters
        /// </summary>
        static private readonly object[] typesArray = 
            new object[] { (Double)0, (Int32)0, (Boolean)false };

        int count;

        List<object> types = new List<object>();

        /// <summary>
        /// Children
        /// </summary>
        IAssociatedObject[] children = new IAssociatedObject[1];

        object[,] parameters = null;

        private double[][] centers;

        private double[] areas;

        private double[][] normales;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        internal Shape3DField()
        {
            consumer = new FieldConsumer3D(this);

            // Field cosumer as child
            children[0] = consumer;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Shape3DField(SerializationInfo info, StreamingContext context)
        {
            filename = info.GetValue("FileName", typeof(string)) as string;
            consumer = info.GetValue("Consumer", typeof(FieldConsumer3D)) as FieldConsumer3D;
            consumer.Facet = this;
            children[0] = consumer;
            Initialize();
        }

        #endregion

        #region ISerializable Members

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FileName", filename, typeof(string));
            info.AddValue("Consumer", consumer, typeof(FieldConsumer3D));
        }

        #endregion

        #region IFacet Members

        int IFacet.Count
        {
            get { return facetNumber; }
        }

        int IFacet.ParametersCount
        {
            get { return types.Count; }
        }

        object IFacet.GetType(int n)
        {
            return types[n];
        }

        object IFacet.this[int facet, int parameter]
        {
            get { return parameters[facet, parameter]; }
        }

        double[] IFacet.this[int n]
        {
            get { return centers[n]; }
        }

        void IFacet.SetColor(int n, double alpha, double red, double green, double blue)
        {
            shape.SetColor(n, alpha, red, green, blue);
        }

        string IFacet.Id
        {
            get
            {
                return base.Filename;
            }
            set
            {
                base.Filename = value;
            }
        }

        /// <summary>
        /// Gets facet area
        /// </summary>
        /// <param name="n">Facet number</param>
        /// <returns>Area</returns>
        double IFacet.GetArea(int n)
        {
            return areas[n];
        }

        /// <summary>
        /// Gets Normal
        /// </summary>
        /// <param name="n">Facet number</param>
        /// <returns>Normal</returns>
        double[] IFacet.GetNormal(int n)
        {
            return normales[n];
        }




        bool IFacet.IsColored
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
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
                position = value as IPosition;
                if (consumer is IPositionObject)
                {
                    IPositionObject po = consumer as IPositionObject;
                    po.Position = value;
                }
            }
        }

        #endregion

        #region IChildrenObject Members

        IAssociatedObject[] IChildrenObject.Children
        {
            get { return children; }
        }

        #endregion

        #region Overriden Members


        /// <summary>
        /// Initialization
        /// </summary>
        protected override void Initialize()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory +
                Path.DirectorySeparatorChar + "Shapes" + Path.DirectorySeparatorChar + filename; 
            if (!File.Exists(fileName))
            {
                return;
            }
            using (Stream stream = File.OpenRead(fileName))
            {
 
                BinaryReader reader = new BinaryReader(stream);

                // number of facetes
                facetNumber = reader.ReadInt32();

                // =========== Reading of types of surface propreties ============

                count = reader.ReadInt32(); // count of surface parameters
                for (int i = 0; i < count; i++) // Cyclic reading of parameters
                {
                    object type = null;      
                    int dimension = reader.ReadInt32(); // Number of parameters
                    int typeNumber = reader.ReadInt32();  // Number of type
                    object typeElement = typesArray[typeNumber]; // Type of element
                    bool ot = reader.ReadBoolean();              // Object type
                    int[] d = new int[dimension];                // Dimensions
                    for (int j = 0; j < dimension; j++)          // Reading of dimensions
                    {
                        d[j] = reader.ReadInt32();              
                    }
                    if (dimension == 1 & d[0] == 1)
                    {
                        type = typeElement;
                    }
                    else
                    {
                        type = new ArrayReturnType(typeElement, d, ot); // Type of array
                    }
                    types.Add(type);                                    // Types
                }
                
                //============ End reading of types ===================

                //============ Reading of facets ======================

                if (facetNumber > 0)
                {
                    facetCoordinates = new double[12 * facetNumber];
                    for (int i = 0; i < facetCoordinates.Length; i++)
                    {
                        facetCoordinates[i] = reader.ReadDouble();
                    }
                    centers = new double[facetNumber][];
                    int nc = 0;
                    for (int i = 0; i < facetNumber; i++)
                    {
                        double[] center = new double[3];
                        centers[i] = center;
                        for (int j = 0; j < 3; j++)
                        {
                            center[j] = facetCoordinates[nc];
                            ++nc;
                        }
                        nc += 9;
                    }
                    
                    //========== End reading of facets ========

                    // Sets facets to C++ shape object
                    shape.Set(facetNumber, facetCoordinates);

                    //==== Reading pararameters of surface ======
                    parameters = new object[facetNumber, count];
                    for (int i = 0; i < facetNumber; i++)
                    {
                        for (int j = 0; j < count; j++)
                        {
                            object ct = types[j];
                            object o = null;
                            if (ct is ArrayReturnType)
                            {
                                ArrayReturnType at = ct as ArrayReturnType;
                                object et = at.ElementType;
                                int[] dt = at.Dimension;
                                if (dt.Length == 1)
                                {
                                    if (!at.IsObjectType)
                                    {
                                        if (et.Equals(typesArray[0]))
                                        {
                                            double[] v = new double[dt[0]];
                                            o = v;
                                            for (int k = 0; k < v.Length; k++)
                                            {
                                                v[k] = reader.ReadDouble();
                                            }
                                        }
                                    }
                                }
                                parameters[i, j] = o;
                            }
                        }
                    }
                }
            }
            Post(facetCoordinates);
        }
        

        #endregion

        #region Specific Members

        internal FieldConsumer3D Consumer
        {
            get
            {
                return consumer;
            }
        }

        object readObject(object type, BinaryReader reader)
        {
            if (type.Equals(typesArray[0]))
            {
                return reader.ReadDouble();
            }
            if (type.Equals(typesArray[1]))
            {
                return reader.ReadInt32();
            }
            return reader.ReadBoolean();
        }

        private void Post(double[] x)
        {
            areas = new double[centers.Length];
            normales = new double[areas.Length][];
            double[] x1 = new double[3];
            double[] x2 = new double[3];
            for (int i = 0; i < areas.Length; i++)
            {
                int k = 12 * i;
                double[] center = centers[i];
                for (int j = 0; j < 3; j++)
                {
                    double c = center[j];
                    x1[j] = x[k + j + 3] - c;
                    x2[j] = x[k + j + 6] - c;
                }
                double[] x3 = Vector3D.StaticExtensionVector3D.VectorPoduct(x1, x2);
                double ar = Vector3D.StaticExtensionVector3D.ScalarNorm(x3) / 2;
                normales[i] = x3;
                areas[i] = ar;
            }
        }

        #endregion

    }
}
