using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using CategoryTheory;
using Diagram.UI;
using SerializationInterface;
using BaseTypes;

using PhysicalField;
using DataPerformer;
using Motion6D.Interfaces;
using PhysicalField.Interfaces;
using Motion6D.Portable;
using NamedTree;
using System.Linq;

namespace Motion6D
{
    /// <summary>
    /// Relative field
    /// </summary>
    [Serializable()]
    public class RelativeField : CategoryObject, ISerializable, IFieldConsumer, IPositionObject, IVectorTransformer, IPostSetArrow
    {

        #region Fields

        private int num = -1;

        private IPhysicalField field;

        private ReferenceFrame fieldFrame;

        private IPosition position;

        private ReferenceFrame posFrame;

        private ReferenceFrame relative = new ReferenceFrame();

        private bool positive;

        private double[] x = new double[3];

        private Action<double[]> transform;

        private static readonly ArrayReturnType type = new ArrayReturnType((Double)0, new int[] { 3 }, false);

        const Double a = 0;

        bool isSerialized = false;


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="positive">Positive sign</param>
        public RelativeField(bool positive)
        {
            this.positive = positive;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected RelativeField(SerializationInfo info, StreamingContext context)
        {
            num = (int)info.GetValue("Num", typeof(int));
            positive = (bool)info.GetValue("Positive", typeof(bool));
            isSerialized = true;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Num", num, typeof(int));
            info.AddValue("Positive", positive, typeof(bool));
        }

        #endregion

        #region IFieldConsumer Members

        int IFieldConsumer.SpaceDimension
        {
            get { return 3; }
        }

        int IFieldConsumer.Count
        {
            get { return (field == null) ? 0 : 1; }
        }

        IPhysicalField IFieldConsumer.this[int n]
        {
            get { return field; }
        }

        void IFieldConsumer.Add(IPhysicalField field)
        {
            if (this.field != null)
            {
                throw new ErrorHandler.OwnException("Field of this object already exist");
            }
            if (!(field is IPositionObject))
            {
                throw new ErrorHandler.OwnException("Field has no postion");
            }
            this.field = field;
            IPositionObject po = field as IPositionObject;
            fieldFrame = ReferenceFrame.GetOwnFrame(po.Position);
            CreateDelegate();
        }

        void IFieldConsumer.Remove(IPhysicalField field)
        {
            this.field = null;
            transform = null;
            num = -1;
        }

        void IFieldConsumer.Consume()
        {
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
                CreateDelegate();
            }
        }

        #endregion

        #region IVectorTransformer Members

        Action<double[]> IVectorTransformer.Transformer
        {
            get { return transform; }
        }

        #endregion
 
        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            CreateTempDelegate();
            isSerialized = false;
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Numbers of accepted fields
        /// </summary>
        public int[] Numbers
        {
            get
            {
                if (field == null)
                {
                    return null;
                }
                List<int> l = new List<int>();
                for (int i = 0; i < field.Count; i++)
                {
                    object t = field.GetTransformationType(i);
                    if (!t.Equals(Field3D_Types.CovariantVector))
                    {
                        continue;
                    }
                    if (!field.GetType(i).Equals(type))
                    {
                        continue;
                    }
                    l.Add(i);
                }
                return l.ToArray();
            }
        }

        /// <summary>
        /// The field
        /// </summary>
        public IPhysicalField Field
        {
            get
            {
                return field;
            }
        }

        /// <summary>
        /// Number of field
        /// </summary>
        public int Number
        {
            get
            {
                return num;
            }
            set
            {
                if (value == -1)
                {
                    num = -1;
                    transform = null;
                    return;
                }
                if (field == null)
                {
                    throw new ErrorHandler.OwnException("Field is abscent");
                }
                object t = field.GetTransformationType(value);
                if (!t.Equals(Field3D_Types.CovariantVector))
                {
                    throw new ErrorHandler.OwnException("Illegal type of field");
                }
                if (!field.GetType(value).Equals(type))
                {
                    throw new ErrorHandler.OwnException("Illegal type of field");
                }
                num = value;
                CreateDelegate();
            }
        }

        /// <summary>
        /// Saves itself
        /// </summary>
        /// <param name="info">Serialization info</param>
        public void Save(SerializationInfo info)
        {
            info.Serialize<RelativeField>("RelativeField", this);
        }


        /// <summary>
        /// Loading
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="o">Loaded object</param>
        /// <returns>Result of loading</returns>
        public static RelativeField Load(SerializationInfo info, object o)
        {
            RelativeField f = info.Deserialize<RelativeField>("RelativeField");
            if (o != null)
            {
                if (o is IChildren<IAssociatedObject> ch)
                {
                    var ccc = ch.Children.ToArray();
                    if (ccc.Length != 0)
                    {
                        if (ccc.Length > 0)
                        {
                            ccc[0] = f;
                        }
                    }
                }
            }
            return f;
        }


        private void CreateDelegate()
        {
            if (isSerialized)
            {
                return;
            }
            CreateTempDelegate();
        }



        private void CreateTempDelegate()
        {
            
            if (num < 0)
            {
                transform = null;
                return;
            }
            if (field == null | position == null)
            {
                transform = null;
                num = -1;
                return;
            }
            posFrame = position.GetParentFrame();
            if (posFrame == fieldFrame)
            {
                if (positive)
                {
                    transform = SimpleTransform;
                    return;
                }
                transform = InverseTransform;
                return;
            }
            if (positive)
            {
                transform = CalcPlus;
                return;
            }
            transform = CalcMinus;
        }


        private void SimpleTransform(double[] x)
        {
            double[] a = field[position.Position][num] as double[];
            for (int i = 0; i < 3; i++)
            {
                x[i] += a[i];
            }
        }

        private void InverseTransform(double[] x)
        {
            double[] a = field[position.Position][num] as double[];
            for (int i = 0; i < 3; i++)
            {
                x[i] -= a[i];
            }
        }


        private void CalcPlus(double[] v)
        {
            CalcRelative();
            for (int i = 0; i < 3; i++)
            {
                v[i] += x[i];
            }
        }

        private void CalcMinus(double[] v)
        {
            CalcRelative();
            for (int i = 0; i < 3; i++)
            {
                v[i] -= x[i];
            }
        }

        private void CalcRelative()
        {
            ReferenceFrame.GetRelativeFrame(posFrame, fieldFrame, relative);
            double[] r = relative.Position;
            double[,] m = relative.Matrix;
            object[] o = field[r];
            double[] a = o[num] as double[];
            PhysicalFieldMeasurements3D.ProcessCovariantVector(a, m, x);
        }

        #endregion

    }
}
