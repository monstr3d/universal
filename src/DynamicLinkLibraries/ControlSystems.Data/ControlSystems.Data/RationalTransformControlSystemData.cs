using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


using CategoryTheory;

using BaseTypes.Interfaces;

using SerializationInterface;

using Diagram.UI;
using Diagram.UI.Interfaces;


using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Interfaces;

using OrdinaryDifferentialEquations;

using ControlSystemsWrapper;
using ErrorHandler;


namespace ControlSystems.Data
{
    /// <summary>
    /// Rational Transform Control System based on external data
    /// </summary>
    [Serializable()]
    public class RationalTransformControlSystemData : RationalTransformControlSystemFunctionWrapper, IMeasurement,
      DataPerformer.Interfaces.IDifferentialEquationSolver, IDataConsumer, 
        IPostSetArrow, IStarted, IDynamical, IAlias, IReplaceMeasurements,
        ISetFeedback
    {
        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        string measureString = "";

        string aliasString = "";

        const Double a = 0;

        double[] derivations;

        IDifferentialEquationsSystem system;

        IMeasurements measurements;

        IMeasurement[] measures;

        IMeasurement inp;


        bool isUpdated = false;

        IAliasName alias = null;

        bool isSerialized = true;

        Action reset;

        List<string> mes = new List<string>();

        Action SetFeedback = () => { };

        double[] outputs = null;

        /// <summary>
        /// Change alias event
        /// </summary>
        event Action<IAlias, string> onChange = (IAlias a, string name) => { };

       
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RationalTransformControlSystemData()
        {
            system = this;
            isSerialized = false;
            reset = () => { };
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected RationalTransformControlSystemData(SerializationInfo info, StreamingContext conext)
            : base(info, conext)
        {
            system = this;
            measureString = info.Deserialize<string>("Measure");
            reset = () => { };
            try
            {
                aliasString = info.Deserialize<string>("Alias");
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.Serialize<string>("Measure", measureString);
            info.Serialize<string>("Alias", aliasString);
        }

        #endregion

        #region IAlias Members

        IList<string> IAlias.AliasNames
        {
            get 
            {
                return new List<string>(variables.Keys);
            }
        }

        object IAlias.this[string name]
        {
            get
            {
                return variables[name];
            }
            set
            {
                variables[name] = (double)value;
                Initialize();
            }
        }

        object IAlias.GetType(string name)
        {
            return BaseTypes.FixedTypes.Double;
        }

        event Action<IAlias, string> IAlias.OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        #region IMeasure Members

        Func<object> IMeasurement.Parameter
        {
            get { return GetValue; }
        }

        string IMeasurement.Name
        {
            get { return "Output"; }
        }

        object IMeasurement.Type
        {
            get { return a; }
        }

        #endregion

        #region IDifferentialEquationSolver Members

        void DataPerformer.Interfaces.IDifferentialEquationSolver.CalculateDerivations()
        {
            action = (double)inp.Parameter();
            system.Calculate(0, derivations);
            SetFeedback();
        }

        void DataPerformer.Interfaces.IDifferentialEquationSolver.CopyVariablesToSolver(int offset, double[] variables)
        {
            Array.Copy(variables, offset, state, 0, state.Length);
        }

        int VariablesCount
        {
            get
            {
                return state.Length;
            }
        }


        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return measures.Length; }
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
            try
            {
                UpdateChildrenData();
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

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            if (this.measurements != null)
            {
                this.Throw(new Exception("Mesurements already exists"));
            }
            this.measurements = measurements;
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            this.measurements = null;
        }

        public void UpdateChildrenData()
        {
            try
            {
                if (measurements != null)
                {
                    measurements.UpdateMeasurements();
                }
            }
            catch (Exception e)
            {
                e.ShowError(10);
                this.Throw(e);
            }
        }

        int IDataConsumer.Count
        {
            get { return 1; }
        }

        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurements; }
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

        #region IStarted Members

        /// <summary>
        /// Starts itself
        /// </summary>
        /// <param name="time">The start time</param>
        void IStarted.Start(double time)
        {
            for (int i = 0; i < state.Length; i++)
            {
                state[i] = 0;
            }
            reset = ResetDistr;
        }

        #endregion

        #region IDynamical Members

        double IDynamical.Time
        {
            set { reset(); }
        }

        #endregion

        #region IReplaceMeasurements Members

        void IReplaceMeasurements.Replace(IMeasurements oldMeasurements, IMeasurement oldMeasure, IMeasurements newMeasurements, IMeasurement newMeasure)
        {
            string s = this.GetMeasurementsName(newMeasurements);
            measureString = s + "." + newMeasure.Name;
            inp = newMeasure;
        }

        #endregion

        #region ISetFeedback Members

        void ISetFeedback.AddFeedback(IMeasurement measure, IAlias alias, string name)
        {
           string an = this.GetRelativeName(alias as IAssociatedObject);
           aliasString = an + "." + name;
           Alias = aliasString;
        }

        #endregion

        #region IStateDoubleVariables Members

        List<string> IStateDoubleVariables.Variables
        {
            get 
            {
                return mes;
            }
        }

        double[] IStateDoubleVariables.Vector
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        void IStateDoubleVariables.Set(double[] input, int offset, int length)
        {
            Array.Copy(input, offset, state, 0, length);
        }


        #endregion
 
        #region IPostSetArrow Members

        public void PostSetArrow()
        {
            derivations = new double[state.Length];
            Input = measureString;
            measures = MeasureInternal.CreateMeasures(state, derivations, this, inp, out mes);
            Alias = aliasString;
        }

        #endregion

        #region Members

        /// <summary>
        /// Input measurements
        /// </summary>
        public ICollection<string> InputMeasurements
        {
            get
            {
                return this.GetAllMeasurementsType(a);
            }
        }

        /// <summary>
        /// Input
        /// </summary>
        public string Input
        {
            get
            {
                return measureString;
            }
            set
            {
                if (value.Length == 0)
                {
                    measureString = "";
                    inp = DataPerformer.Portable.StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement;
                    return;
                }
                inp = this.FindMeasurement(value, false);
                measureString = value;
            }
        }
        /// <summary>
        /// Alias
        /// </summary>
        public string Alias
        {
            get
            {
                return aliasString;
            }
            set
            {
                alias = this.FindAliasName(value, true);
                aliasString = value;
                if (alias == null)
                {
                    SetFeedback = () => { };
                }
                else
                {
                    SetFeedback = () =>
                    {
                        alias.Value = state[0];
                    };
                }

            }
        }

        /// <summary>
        /// Creates system
        /// </summary>
        /// <param name="formula">Formula</param>
        public override void CreateSystem(string formula)
        {
            base.CreateSystem(formula);
            if (isSerialized)
            {
                isSerialized = false;
                return;
            }
            PostSetArrow();
        }

        object GetValue()
        {
            return Output;
        }

        void ResetDistr()
        {
            UpdateChildrenData();
            foreach (IMeasurement m in measures)
            {
                if (m is IDerivation)
                {
                    IDerivation der = m as IDerivation;
                    IMeasurement md = der.Derivation;
                    if (md is IDistribution)
                    {
                        IDistribution distr = md as IDistribution;
                        distr.Reset();
                    }
                }
            }
            reset = () => { };
        }

        #endregion

        #region Classes & Delegates

        #region Measure Class

        /// <summary>
        /// Measure class
        /// </summary>
        class MeasureInternal : IMeasurement, IDerivation
        {
            int i;

            const Double a = 0;

            double[] state;

            string name;

            IMeasurement derivation;

            internal static IMeasurement[] CreateMeasures(double[] state, double[] der,
                RationalTransformControlSystemData transform, IMeasurement measure, out List<string> mes)
            {
                mes = new List<string>();
                List<IMeasurement> l = new List<IMeasurement>();
                new MeasureInternal(state, der, 0, "x", l, measure, mes);
                if (transform.nom.Length == transform.denom.Length)
                {
                    l.Add(transform);
                }
                else
                {
                    l.Add(new OutputMeasure(transform));
                }
                return l.ToArray();
            }


            private MeasureInternal(double[] state, double[] der, int i, string name, List<IMeasurement> l, 
                IMeasurement measure, List<string> mes)
            {
                this.state = state;
                this.name = name;
                mes.Add(name);
                this.i = i;
                l.Add(this);
                if (i < state.Length - 1)
                {
                    derivation = new MeasureInternal(state, der, i + 1, "D" + name, l, measure, mes);
                }
                else
                {
                    derivation = LastDer.Create(der, "D" + name, measure);
                }
            }

            private object GetValue()
            {
                return state[i];
            }


            #region IMeasure Members

            Func<object> IMeasurement.Parameter
            {
                get { return GetValue; }
            }

            string IMeasurement.Name
            {
                get { return name; }
            }

            object IMeasurement.Type
            {
                get { return a; }
            }

            #endregion

            #region IDerivation Members

            IMeasurement IDerivation.Derivation
            {
                get { return derivation; }
            }

            #endregion

            class LastDer : IMeasurement
            {
                double[] der;

                string name;

                const Double a = 0;

                int n;

                protected LastDer(double[] der, string name)
                {
                    this.der = der;
                    this.name = name;
                    n = der.Length - 1;
                }


                #region IMeasure Members

                Func<object> IMeasurement.Parameter
                {
                    get { return getValue; }
                }

                string IMeasurement.Name
                {
                    get { return name; }
                }

                object IMeasurement.Type
                {
                    get { return a; }
                }

                #endregion


                static internal LastDer Create(double[] der, string name, IMeasurement m)
                {
                    if (m is IDistribution)
                    {
                        IDistribution d = m as IDistribution;
                        return new LastDerDistr(der, name, d);
                    }
                    return new LastDer(der, name);
                }

                private object getValue()
                {
                    return der[n];
                }
            }

            class LastDerDistr : LastDer, IDistribution
            {
                IDistribution distr;
                internal LastDerDistr(double[] der, string name, IDistribution d)
                    : base(der, name)
                {
                    distr = d;
                }


                #region IDistribution Members

                void IDistribution.Reset()
                {
                    distr.Reset();
                }

                double IDistribution.Integral
                {
                    get { return distr.Integral; }
                }

                #endregion
            }
        }

        #endregion

        #region Output measure Class

        class OutputMeasure : IMeasurement, IDerivation
        {
            #region Fields

            OutputMeasure[] outputs;

            int i;

            Func<object> par;

            IMeasurement der;

            double a = 0;

            string name = "";

            double[] vector;

            #endregion

            #region Ctor

            internal OutputMeasure(RationalTransformControlSystemData transform)
            {
                name = "Output";
                vector = new double[transform.denom.Length - transform.nom.Length + 1];
                i = 0;
                outputs = new OutputMeasure[vector.Length - 1];
                outputs[0] = this;
                par = () =>
                {
                    transform.CalculateDerivations(vector);
                    return vector[i];
                };
                for (int j = 1; j < vector.Length - 1; j++)
                {
                    new OutputMeasure(j, vector, outputs);
                }
                for (int j = 0; j < vector.Length - 2; j++)
                {
                    outputs[j].der = outputs[j + 1];
                }
                int n = vector.Length - 1;
                outputs[vector.Length - 2].der = new LastMeasure(vector);
            }

            OutputMeasure(int i, double[] vector, OutputMeasure[] outputs)
            {
                this.i = i;
                this.outputs = outputs;
                outputs[i] = this;
                par = () => { return vector[i]; };
            }


            #endregion

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
                get { return a; }
            }
      

            IMeasurement IDerivation.Derivation
            {
                get { return der; }
            }

            class LastMeasure : IMeasurement
            {
                int n;

                double[] vector;

                Func<object> par;

                double a = 0;


                internal LastMeasure(double[] vector)
                {
                    n = vector.Length - 1;
                    par = () => { return vector[n]; };
                }


                Func<object> IMeasurement.Parameter
                {
                    get { return par; }
                }

                string IMeasurement.Name
                {
                    get { return ""; }
                }

                object IMeasurement.Type
                {
                    get { return a; }
                }
            }

    }

        #endregion

        #endregion

    }
}
