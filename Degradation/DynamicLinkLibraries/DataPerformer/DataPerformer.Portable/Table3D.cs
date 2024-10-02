using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI;

using BaseTypes;
using BaseTypes.Interfaces;

using DataPerformer.Interfaces;
using Diagram.UI.Labels;
using DataPerformer.Portable.Measurements;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Table of three parameters
    /// This table uses linear interpolation
    /// </summary>
    public class Table3D : Basic.Table3D, ICategoryObject, IDataConsumer, IMeasurements, IObjectOperation,
       IPowered, IPostSetArrow
    {

        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };

        /// <summary>
        /// Associated object
        /// </summary>
        private object obj;

        /// <summary>
        /// Output measurements
        /// </summary>
        private IMeasurement[] output = null;

        /// <summary>
        /// Arguments
        /// </summary>
        private string[] arguments;

        /// <summary>
        /// Input measurements
        /// </summary>
        private IMeasurement[] input = new IMeasurement[2];

        /// <summary>
        /// The x, y - arguments
        /// </summary>
        private readonly string[] xy = new string[] { "x", "y" };

        /// <summary>
        /// Measurements
        /// </summary>
        private List<IMeasurements> measurements = new List<IMeasurements>();

        /// <summary>
        /// The "is updated" sign
        /// </summary>
        private bool isUpdated;

        /// <summary>
        /// The "has derivation" sign
        /// </summary>
        private bool hasDerivation = true;

        private const double type = 0;

        private readonly object[] types = new object[] { new ArrayReturnType((double)0, new int[] { 2 }, false) };


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Table3D()
        {
            Func<object> fn = () => { return this; };
            output = new IMeasurement[] { new Measurement(this, fn, "Function", this) };
        }



        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
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

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return 1; }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return output[n]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            /*
            if (input[0] == null)
            {
                return;
            }
            if (isUpdated)
            {
                return;
            }
            try
            {
                IDataConsumer c = this;
                c.UpdateChildrenData();
                Calculate((double)input[0].Parameter(), (double)input[1].Parameter());
                if (hasDerivation)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        IDerivation der = input[i] as IDerivation;
                        result[1] += dx[i] * (double)der.Derivation.Parameter();
                    }
                }
                isUpdated = true;
            }
            catch (Exception e)
            {
                e.ShowError(10);
                this.Throw(e);
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

        #region IObjectOperation Members

        object[] IObjectOperation.InputTypes
        {
            get { return types; }
        }

        object IObjectOperation.this[object[] x]
        {
            get
            {
                object[] o = x[0] as object[];
                return Calculate((double)o[0], (double)o[1], (double)o[2]);
            }
        }

        object IObjectOperation.ReturnType
        {
            get { return type; }
        }

        bool IPowered.IsPowered
        {
            get { return false; }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            try
            {
                AcceptArguments();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// The "has derivation" sign
        /// </summary>
        public bool HasDerivation
        {
            get
            {
                return hasDerivation;
            }
        }

 
        /// <summary>
        /// Arguments
        /// </summary>
        public string[] Arguments
        {
            get
            {
                return arguments;
            }
        }

        /// <summary>
        /// Pre initialization
        /// </summary>
        protected override void PreInit()
        {
            arguments = new string[] { "", "" };
        }


        /// <summary>
        /// Accepts arguments
        /// </summary>
        private void AcceptArguments()
        {
            foreach (IMeasurements measurements in this.measurements)
            {
                IAssociatedObject cont = measurements as IAssociatedObject;
                INamedComponent c = cont.Object as INamedComponent;
                string name = c.Name;
                for (int i = 0; i < measurements.Count; i++)
                {
                    IMeasurement measure = measurements[i];
                    string p = name + "." + measure.Name;
                    for (int j = 0; j < 2; j++)
                    {
                        if (arguments[j].Equals(p))
                        {
                            input[j] = measure;
                            break;
                        }
                    }
                }
            }
            /* !!! Arguments are relict delete after check Table3D
            for (int i = 0; i < 2; i++)
            {
                if (arguments[i].Equals("Time"))
                {
                    input[i] = DataPerformer.Portable.StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasure;
                }
            }
             */
            hasDerivation = true;
            for (int i = 0; i < input.Length; i++)
            {
                IDerivation der = input[i] as IDerivation;
                if (der == null)
                {
                    hasDerivation = false;
                    break;
                }
            }
        }


        #endregion
    }
}
