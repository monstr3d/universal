using System;
using System.Collections.Generic;
using System.Text;


using CategoryTheory;
using Diagram.UI.Aliases;

using DataPerformer.Portable;
using DataPerformer.Interfaces;

using PhysicalField.Interfaces;


namespace PhysicalField.Portable
{
    /// <summary>
    /// Consumer of physical field
    /// </summary>
    public abstract class PhysicalFieldDataConsumer : CategoryObject, IPhysicalField,  
        IDataConsumer, IPostSetArrow 
    {
       
        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };


        protected string[] input = null;

        protected string[] output = null;

        protected IMeasurement[] measures = null;

        protected List<IMeasurements> measurements = new List<IMeasurements>();

        protected object[] transformationTypes;

        protected object[] result;

        protected AliasName[] al = null;

        protected IDataConsumer cons;

        //private Dictionary<IMeasurements, bool> isUpdated = new Dictionary<IMeasurements, bool>();

        #endregion

        #region Ctor


        /// <summary>
        /// Default constructor
        /// </summary>
        protected PhysicalFieldDataConsumer()
        {
            cons = this;
            IPhysicalField f = this;
            input = new string[f.SpaceDimension];
        }

        #endregion

        #region IPhysicalField Members

        public abstract int SpaceDimension
        {
            get;
        }


        int IPhysicalField.Count
        {
            get 
            {
                if (measures == null)
                {
                    return 0;
                }
                return measures.Length; 
            }
        }

        object IPhysicalField.GetType(int n)
        {
            return measures[n].Type;
        }

        object IPhysicalField.GetTransformationType(int n)
        {
            return transformationTypes[n];
        }

        /// <summary>
        /// Calculates field
        /// </summary>
        /// <param name="position">Position</param>
        /// <returns>Array of components of field</returns>
        public virtual object[] this[double[] position]
        {
            get
            {
                for (int i = 0; i < position.Length; i++)
                {
                    AliasName an = al[i];
                    an.SetValue(position[i]);
                }
                foreach (IMeasurements m in measurements)
                {
                    m.UpdateMeasurements();
                }
                for (int i = 0; i < measures.Length; i++)
                {
                    result[i] = measures[i].Parameter();
                }
                this.FullReset();
                return result;
            }
        }

        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
           // isUpdated[measurements] = false;
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
           // isUpdated.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            foreach (IMeasurements m in measurements)
            {
                m.UpdateMeasurements();
            }
        }

        int IDataConsumer.Count
        {
            get { return measurements.Count; }
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

        #region IPostSetArrow Members

        public virtual void PostSetArrow()
        {
            setAliases();
            setMea();
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Input parameters
        /// </summary>
        public string[] Input
        {
            get
            {
                return input;
            }
            set
            {
                input = value;
                setAliases();
            }
        }

        public object[] TransformationTypes
        {
            set
            {
                transformationTypes = value;
            }
        }

        public string[] Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
                setMea();
            }
        }

        public static int[] GetFields(IPhysicalField field, object type, 
            object transformationType)
        {
            List<int> l = new List<int>();
            int n = field.Count;
            for (int i = 0; i < n; i++)
            {
                object t = field.GetType(i);
                object tr = field.GetTransformationType(i);
                if (t.Equals(type) & tr.Equals(transformationType))
                {
                    l.Add(i);
                }
            }
            return l.ToArray();
        }

        private void setAliases()
        {
            if (input == null)
            {
                return;
            }
            al = new AliasName[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                al[i] = cons.FindAliasName(input[i], false);
               /* IAlias a = o[0] as IAlias;
                string n = o[1] as string;
                AlName an = new AlName();
                an.alias = a;
                an.name = n;
                al[i] = an;*/
            }
        }

        private void setMea()
        {
            if (output == null)
            {
                return;
            }
            measures = new IMeasurement[output.Length];
            result = new object[output.Length];
            for (int i = 0; i < measures.Length; i++)
            {
                measures[i] = this.FindMeasurement(output[i], false);
            }
        }

        #endregion

        #region Auxilary structure

 /*       struct AlName
        {
            /// <summary>
            /// Alias
            /// </summary>
            internal IAlias alias;

            /// <summary>
            /// Name
            /// </summary>
            internal string name;
        }*/

        #endregion

    }
}
