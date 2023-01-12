using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;

using BaseTypes;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Attributes;


using Motion6D.Interfaces;
using Motion6D.Portable;

using PhysicalField.Interfaces;


namespace Motion6D
{
    /// <summary>
    /// Measurements of physical field
    /// </summary>
    [Serializable()]
    [ShouldComplete(true)]
    public class PhysicalFieldMeasurements3D : CategoryObject,  ISerializable, IMeasurements, 
        IPositionObject, IFieldConsumer, IPostSetArrow
    {
        #region Fields

        /// <summary>
        /// List of measures
        /// </summary>
        private IList<IMeasurement> measures = new List<IMeasurement>();

        /// <summary>
        /// Dictionary of measures
        /// </summary>
        private IDictionary<IPhysicalField, IList<IMeasurement>> dic = new Dictionary<IPhysicalField, IList<IMeasurement>>();

        /// <summary>
        /// Fields
        /// </summary>
        private IList<IPhysicalField> fields = new List<IPhysicalField>();

        /// <summary>
        /// Process field
        /// </summary>
        private IDictionary<IPhysicalField, IList<ProcessField>> proc = new Dictionary<IPhysicalField, IList<ProcessField>>();


        private IDictionary<IPhysicalField, IList<object>> results = new Dictionary<IPhysicalField, IList<object>>();

        /// <summary>
        /// Position
        /// </summary>
        private IPosition position;

        /// <summary>
        /// The "is updated" sign
        /// </summary>
        private bool isUpdated;

        /// <summary>
        /// Temporary frame
        /// </summary>
        private ReferenceFrame relative = new ReferenceFrame();


        /// <summary>
        /// The "is serialized" sign
        /// </summary>
        private bool isSerialized = false;


        private Dictionary<IPhysicalField, bool> updatedFields = new Dictionary<IPhysicalField, bool>();

        private Dictionary<IPhysicalField, object[]> fieldValue = new Dictionary<IPhysicalField, object[]>();

 
 
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PhysicalFieldMeasurements3D()
        {
        }
        
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected PhysicalFieldMeasurements3D(SerializationInfo info, StreamingContext context)
        {
            isSerialized = true;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return measures.Count; }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return measures[n]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            if (isUpdated)
            {
                return;
            }
            isUpdated = true;
            ReferenceFrame frame = position.GetParentFrame();
            foreach (IPhysicalField field in fields)
            {
                IPositionObject po = field as IPositionObject;
                IPosition p = po.Position;
                ReferenceFrame ff = po.Position.GetParentFrame();
                ReferenceFrame.GetRelativeFrame(ff, frame, relative);
                double[] r = relative.Position;
                double[,] m = relative.Matrix;
                object[] o = null;
                try
                {
                    o = field[r];
                    fieldValue[field] = o;
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                    o = GetFieldValue(field);
                }
               /* if (updatedFields[field])
                {
                    o = fieldValue[field];
                }
                else
                {
                    o = field[r];
                    updatedFields[field] = true;
                    fieldValue[field] = o;
                }*/
                IList<object> res = results[field];
                IList<ProcessField> pr = proc[field];
                for (int i = 0; i < o.Length; i++)
                {
                    object result = res[i];
                    ProcessField process = pr[i];
                    process(o[i], m, result);
                }
            }
            isUpdated = true;
            /*foreach (IPhysicalField field in fields)
            {
                updatedFields[field] = false;
            }*/
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return isUpdated;
            }
            set
            {
                isUpdated = value;
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

        #region IFieldConsumer Members

        int IFieldConsumer.SpaceDimension
        {
            get { return 3; }
        }

        int IFieldConsumer.Count
        {
            get { return fields.Count; }
        }

        IPhysicalField IFieldConsumer.this[int n]
        {
            get { return fields[n]; }
        }

        void IFieldConsumer.Add(IPhysicalField field)
        {
            object o = (field as IAssociatedObject).GetObject<IPositionObject>();
            if (o == null)
            {
                throw new Exception("Field should have position");
            }
            fields.Add(field);
            updatedFields[field] = false;
            if (!isSerialized)
            {
                CreateMesurements(field);
            }
        }

        void IFieldConsumer.Remove(IPhysicalField field)
        {
            fields.Remove(field);
            results.Remove(field);
            proc.Remove(field);
            updatedFields.Remove(field);
            IList<IMeasurement> del = dic[field];
            foreach (IMeasurement m in del)
            {
                measures.Remove(m);
            }
        }

        void IFieldConsumer.Consume()
        {
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            if (isSerialized)
            {
                foreach (IPhysicalField field in fields)
                {
                    Complete();
                }
            }
            isSerialized = false;
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Completion operation
        /// </summary>
        public void Complete()
        {
            foreach (IPhysicalField field in fields)
            {
                CreateMesurements(field);
            }
        }

        private object[] GetFieldValue(IPhysicalField field)
        {
            if (fieldValue.ContainsKey(field))
            {
                return fieldValue[field];
            }
            object[] o = new object[field.Count];
            for (int i = 0; i < o.Length; i++)
            {
                object type = field.GetType(i);
                if (type.GetType().Equals(typeof(double)))
                {
                    double a = 0;
                    o[i] = a;
                    continue;
                }
                if (type is ArrayReturnType)
                {
                    ArrayReturnType art = type as ArrayReturnType;
                    o[i] = new double[art.Dimension[0]];
                }
                fieldValue[field] = o;
            }
            return o;
        }

        private void CreateMesurements(IPhysicalField field)
        {
            string name = this.GetRelativeName(field as IAssociatedObject) + "_";
            name = name.Replace(".", "_");
            name = name.Replace("/", "_");
            int n = field.Count;
            IList<IMeasurement> lm = new List<IMeasurement>();
            IList<ProcessField> pr = new List<ProcessField>();
            IList<object> lo = new List<object>();
            dic[field] = lm;
            proc[field] = pr;
            results[field] = lo;
            IMeasurement mea = null;
            measures.Clear();
            for (int i = 0; i < n; i++)
            {
                object result = null;
                ProcessField pf = null;
                string na = name + (i + 1);
                object type = field.GetType(i);
                object tt = field.GetTransformationType(i);
                if (type is ArrayReturnType)
                {
                    if (tt.Equals(Field3D_Types.CovariantVector))
                    {
                        pf = ProcessCovariantVector;
                    }
                    else
                    {
                        pf = ProcessInvariantVector;
                    }
                    ArrayReturnType art = type as ArrayReturnType;
                    int dim = art.Dimension[0];
                    result = new double[dim];
                    mea = new FieldMeasurement(na, type, result);
                }
                else
                {
                    pf = ProcessSimpleType;
                    result = new object[1];
                    mea = new FieldMeasurementElement(na, type, result as object[]);
                }
                lm.Add(mea);
                pr.Add(pf);
                lo.Add(result);
                measures.Add(mea);
            }
            
        }

        /// <summary>
        /// Covariant vector process
        /// </summary>
        /// <param name="x">Input</param>
        /// <param name="matrix">Matrix</param>
        /// <param name="y">Output</param>
        static public void ProcessCovariantVector(double[] x, double[,] matrix, double[] y)
        {
            RealMatrixProcessor.StaticExtensionRealMatrix.Multiply(x, matrix, y);
        }


        static private void ProcessCovariantVector(object inp, double[,] matrix, object result)
        {
            double[] x = inp as double[];
            double[] y = result as double[];
            ProcessCovariantVector(x, matrix, y);
        }

        private void ProcessInvariantVector(object inp, double[,] matrix, object result)
        {
            double[] x = inp as double[];
            double[] y = result as double[];
            Array.Copy(x, y, x.Length);
        }

        private void ProcessSimpleType(object inp, double[,] matrix, object result)
        {
            object[] o = result as object[];
            o[0] = inp;
        }




        #endregion

        #region Field Measure

        /// <summary>
        /// Field object measure
        /// </summary>
        class FieldMeasurementElement : IMeasurement
        {
            #region Fields

            /// <summary>
            /// Result
            /// </summary>
            private object[] result;

            /// <summary>
            /// Type
            /// </summary>
            private object type;

            /// <summary>
            /// Name
            /// </summary>
            private string name;

            /// <summary>
            /// Parameter
            /// </summary>
            private Func<object> par;


            #endregion

            #region Ctor

            internal FieldMeasurementElement(string name, object type, object[] result)
            {
                this.name = name;
                this.type = type;
                this.result = result;
                par = GetValue;
            }

            #endregion

            #region IMeasurement Members

            Func<object> IMeasurement.Parameter
            {
                get { return par; }
            }

            string IMeasurement.Name
            {
                get { return name; }
            }

            object IMeasurement.Type
            {
                get { return type; }
            }

            #endregion

            #region Specific Members

            object GetValue()
            {
                return result[0];
            }

            #endregion
        }
        /// <summary>
        /// Field object measure
        /// </summary>
        class FieldMeasurement : IMeasurement
        {
            #region Fields

            /// <summary>
            /// Result
            /// </summary>
            private object result;

            /// <summary>
            /// Type
            /// </summary>
            private object type;

            /// <summary>
            /// Name
            /// </summary>
            private string name;

            /// <summary>
            /// Parameter
            /// </summary>
            private Func<object> par;


            #endregion

            #region Ctor

            internal FieldMeasurement(string name, object type, object result)
            {
                this.name = name;
                this.type = type;
                this.result = result;
                par = GetValue;
            }

            #endregion

            #region IMeasurement Members

            Func<object> IMeasurement.Parameter
            {
                get { return par; }
            }

            string IMeasurement.Name
            {
                get { return name; }
            }

            object IMeasurement.Type
            {
                get { return type; }
            }

            #endregion

            #region Specific Members

            object GetValue()
            {
                return result;
            }

            #endregion
        }

        #endregion

        #region Field Processing

        delegate void ProcessField(object inp, double[,] matrix, object result);
        

        #endregion

    }
}
