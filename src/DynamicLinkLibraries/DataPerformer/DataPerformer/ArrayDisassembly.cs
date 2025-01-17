using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


using CategoryTheory;

using Diagram.UI;

using BaseTypes;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using ErrorHandler;

namespace DataPerformer
{
    /// <summary>
    /// Disassembly of array
    /// This component provides access to
    /// components of array
    /// </summary>
    [Serializable()]
    public class ArrayDisassembly :  CategoryObject, ISerializable, IDataConsumer, IMeasurements, IPostSetArrow
    {
        #region Fields

        /// <summary>
        /// Name of array
        /// </summary>
        protected string arrayName = "";

        /// <summary>
        /// Output measurements
        /// </summary>
        protected IMeasurement[] output;

        /// <summary>
        /// Input measure
        /// </summary>
        protected IMeasurement input;

        /// <summary>
        /// External measurements
        /// </summary>
        protected List<IMeasurements> measurements = new List<IMeasurements>();

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        /// <summary>
        /// The "is updated" flag
        /// </summary>
        private bool isUpdated;

        /// <summary>
        /// Result of measurements
        /// </summary>
        private Array result;

        /// <summary>
        /// The "Element" string
        /// </summary>
        static private readonly string element = "Element";



        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ArrayDisassembly()
        {
        }

        /// <summary>
        /// Deserialization construcror
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ArrayDisassembly(SerializationInfo info, StreamingContext context)
        {
            arrayName = info.GetValue("ArrayName", typeof(string)) as string;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ArrayName", arrayName, typeof(string));
        }

        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            measurements.UpdateChildrenData();
        }

        int IDataConsumer.Count
        {
            get 
            {
                return measurements.Count;
            }
        }

        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurements[n]; }
        }

        void IDataConsumer.Reset()
        {
            this.FullReset();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get 
            {
                if (output == null)
                {
                    return 0;
                }
                return output.Length;
            }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return output[n]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            try
            {
                if (isUpdated)
                {
                    return;
                }
                IDataConsumer c = this;
                c.UpdateChildrenData();
                if (input != null)
                {
                    result = input.Parameter() as Array;
                }
                isUpdated = true;
            }
            catch (Exception e)
            {
                e.ShowError(10);
                this.Throw(e);
            }
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

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            post();
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// List of all measurements related to array
        /// </summary>
        public List<string> Measures
        {
            get
            {
                IDataConsumer consumer = this;
                List<string> list = new List<string>();
                for (int i = 0; i < consumer.Count; i++)
                {
                    IMeasurements m = consumer[i];
                    IAssociatedObject ao = m as IAssociatedObject;
                    IAssociatedObject th = consumer as IAssociatedObject;
                    string on = th.GetRelativeName(ao) + ".";
                    for (int j = 0; j < m.Count; j++)
                    {
                        IMeasurement mea = m[j];
                        string s = on + mea.Name;
                        if (mea.Type is ArrayReturnType)
                        {
                            list.Add(s);
                        }
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// String repesentation of measure
        /// </summary>
        public string Measure
        {
            get
            {
                return arrayName;
            }
            set
            {
                arrayName = value;
                createAll();
            }
        }

        private void post()
        {
            createAll();
        }

        Array Result
        {
            get
            {
                return result;
            }
        }

        void createAll()
        {
            input = this.FindMeasurement(arrayName, true);
            if (input == null)
            {
                return;
            }
            createMea();
        }

        void createMea()
        {
            if (input == null)
            {
                return;
            }
            object type = input.Type;
            if (!(type is ArrayReturnType))
            {
                return;
            }
            ArrayReturnType at = type as ArrayReturnType;
            int[] d = at.Dimension;
            int num = 1;
            for (int i = 0; i < d.Length; i++)
            {
                num *= d[i];
            }
            output = new IMeasurement[num];
            int curr = 0;
            object et = at.ElementType;
            for (int i = 0; i < d[0]; i++)
            {
                int[] n = new int[1];
                n[0] = i;
                createMea(et, d, n, ref curr);
            }
        }

        private void createMea(object type, int[] lengths, int[] n, ref int curr)
        {
            if (lengths.Length == n.Length)
            {
                createMea(type, n, ref curr);
                return;
            }
            int l = lengths[n.Length];
            for (int i = 0; i < l; i++)
            {
                int[] m = new int[n.Length + 1];
                Array.Copy(n, m, n.Length);
                m[m.Length - 1] = i;
                createMea(type, lengths, m, ref curr);
            }
        }

        private void createMea(object type, int[] n, ref int curr)
        {
            string s = element + "(";
            for (int i = 0; i < n.Length; i++)
            {
                s += (n[i] + 1);
                if (i < n.Length - 1)
                {
                    s += ", ";
                }
            }
            s += ")";
            output[curr] = new DisassemblyMeasure(type, n, this, s);
            ++curr;
        }

        #endregion

        #region Array component

        class DisassemblyMeasure : IMeasurement
        {
            #region Fields

            /// <summary>
            /// Indices
            /// </summary>
            int[] n;

            /// <summary>
            /// Parameter
            /// </summary>
            Func<object> par;

            /// <summary>
            /// array
            /// </summary>
            ArrayDisassembly array;

            /// <summary>
            /// Type of measure
            /// </summary>
            object type;

            /// <summary>
            /// Name of measure
            /// </summary>
            string name;

            #endregion

            #region Ctor

            internal DisassemblyMeasure(object type, int[] n, ArrayDisassembly array, string name)
            {
                this.type = type;
                this.n = n;
                this.array = array;
                this.name = name;
                par = getValue;
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

            object getValue()
            {
                return array.Result.GetValue(n);
            }

            #endregion
        }

        #endregion
    }
}
