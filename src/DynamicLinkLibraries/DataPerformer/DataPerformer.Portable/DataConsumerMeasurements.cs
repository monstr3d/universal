using System;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Diagram.UI.Aliases;

using BaseTypes.Interfaces;

using DataPerformer.Interfaces;

using Event.Interfaces;
using ErrorHandler;

namespace DataPerformer.Portable
{

    /// <summary>
    /// Data consumer + measurements
    /// </summary>
    public abstract class DataConsumerMeasurements : DataConsumer,
        IMeasurements, IAlias, ICheckCorrectness
      {

        #region Fields

        /// <summary>
        /// String representation of formulas
        /// </summary>
        protected string[] formulaString = new string[0];

        /// <summary>
        /// Resource string
        /// </summary>
        public static readonly string ExternalParameter_ = "External parameter ";

        /// <summary>
        /// Resource string
        /// </summary>
        public static readonly string _IsNotDefined = " is not defined";


        /// <summary>
        /// Output measurements
        /// </summary>
        protected IMeasurement[] measurements = new IMeasurement[0];

        /// <summary>
        /// Results of calculation
        /// </summary>
        protected object[,] result;


        /// <summary>
        /// Input parameter
        /// </summary>
        protected DynamicalParameter par;

        /// <summary>
        /// Input arguments
        /// </summary>
        protected List<string> arguments = new List<string>();

        /// <summary>
        /// All variables
        /// </summary>
        protected string allVariables;

        /// <summary>
        /// Parameters
        /// </summary>
        protected Dictionary<string, object> parameters = new Dictionary<string, object>();

 
        /// <summary>
        /// External unaries
        /// </summary>
        protected List<IObjectOperation> operations = new List<IObjectOperation>();

        /// <summary>
        /// The "Formula" string
        /// </summary>
        protected static readonly string Formula_ = "Formula_";



        /// <summary>
        /// Names of unaries
        /// </summary>
        protected Dictionary<int, string> operationNames = new Dictionary<int, string>();

        /// <summary>
        /// The "is serialized" sign
        /// </summary>
        protected bool isSerialized = false;

        /// <summary>
        /// The "Calculate derivation" sign
        /// </summary>
        protected bool calculateDerivation = false;


        /// <summary>
        /// Order of derivation
        /// </summary>
        protected int deriOrder = 0;

  
        /// <summary>
        /// Feedback
        /// </summary>
        protected Dictionary<int, string> feedback = new Dictionary<int, string>();


        /// <summary>
        /// Feedback aliases
        /// </summary>
        protected Dictionary<int, AliasName> feedAliases = new Dictionary<int, AliasName>();

       /// <summary>
        /// Update
        /// </summary>
        protected Action update;

   
        /// <summary>
        /// Replacement of feedback
        /// </summary>
        protected Dictionary<string, string> replacement = new Dictionary<string, string>();

        /// <summary>
        /// Forward Aliases
        /// </summary>
        protected Dictionary<IMeasurement, IAliasName> forward = new Dictionary<IMeasurement, IAliasName>();

        /// <summary>
        /// Guid
        /// </summary>
        protected Guid guid = Guid.NewGuid();

        /// <summary>
        /// Change alias event
        /// </summary>
        protected event Action<IAlias, string> onChange = (IAlias a, string name) => { };

        /// <summary>
        /// Should runtime update sign
        /// </summary>
        protected  bool shouldRuntimeUpdate = true;

        /// <summary>
        /// Forward aliases
        /// </summary>
        protected Dictionary<int, string> forwardAliases = new Dictionary<int, string>();

        /// <summary>
        /// Level of error
        /// </summary>
        protected int errorLevel = 10;


        /// <summary>
        /// The input dynamical parameter
        /// </summary>

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        protected DataConsumerMeasurements()
                : base(39)
        {
            
        }


  
        #endregion

        #region IAlias Members

        /// <summary>
        /// Names of aliases
        /// </summary>
        public virtual IList<string> AliasNames
        {
            get
            {
                List<string> s = new List<string>();
                foreach (string str in parameters.Keys)
                {
                    s.Add(str);
                }
                return s;
            }
        }

        /// <summary>
        /// Access to alias object
        /// </summary>
        public virtual object this[string alias]
        {
            get
            {
                return parameters[alias];
            }
            set
            {
                parameters[alias] = value;
            }
        }

        /// <summary>
        /// Gets object type
        /// </summary>
        /// <param name="name">Object name</param>
        /// <returns>Returns type of alias object</returns>
        public virtual object GetType(string name)
        {
            return AliasTypeDetector.Detector.DetectType(this[name]);
        }

        event Action<IAlias, string> IAlias.OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        #region IMeasurements Members

        /// <summary>
        /// The count of measurements
        /// </summary>
        int IMeasurements.Count
        {
            get
            {
                return MeasurementsCount;
            }
        }

        /// <summary>
        /// Access to n - th measurement
        /// </summary>
        IMeasurement IMeasurements.this[int n]
        {
            get
            {
                if (measurements == null)
                {
                    this.Throw(new Exception("Undefined measurements"));
                }
                IMeasurement measurement = measurements[n];
                if (measurement == null)
                {
                    this.Throw(new Exception("Undefined measure"));
                }
                return measurement;
            }
        }

        /// <summary>
        /// Updates measurements data
        /// </summary>
        void IMeasurements.UpdateMeasurements()
        {
            if (IsUpdated)
            {
                return;
            }
            try
            {
                if (par == null)
                {
                    throw new Exception(DynamicalParameter.UndefinedParameters);
                }
                if (measurements == null)
                {
                    throw new Exception("Formulas are not accepted");
                }
                update();
                foreach (int i in feedAliases.Keys)
                {
                    IMeasurement m = measurements[i];
                    object r = m.Parameter();
                    if (r != null)
                    {
                        feedAliases[i].SetValue(r);
                    }
                }
                isUpdated = true;
            }
            catch (Exception exception)
            {
                exception.HandleException(errorLevel);
            }
        }

        #endregion

        #region ICheckCorrectness Members

        /// <summary>
        /// Checks its correctenss
        /// </summary>
        public void CheckCorrectness()
        {
            try
            {
            }
            catch (Exception e)
            {
                e.HandleException(10);
                this.Throw(e);
            }
        }

        #endregion

        #region Public Members

        #region Overriden

        /// <summary>
        /// Calculation reason
        /// </summary>
        public override string CalculationReason
        {
            get
            {
                return base.CalculationReason;
            }

            set
            {
                errorLevel = value.IsRealtimeAnalysis() ? -1 : 10;
                base.CalculationReason = value;
            }
        }

        #endregion

        /// <summary>
        /// Arguments of this object
        /// </summary>
        public virtual List<string> Arguments
        {
            get
            {
                return arguments;
            }
            set
            {
                string str = Variables;
                //bool b = false;
                foreach (char c in str)
                {
                    foreach (string s in value)
                    {
                        if (s[0] == c)
                        {
                            goto m;
                        }
                    }
                    throw new Exception(VariablesShortage + " : " + c);
                m:
                    continue;
                }
                arguments = value;
            }
        }


        /// <summary>
        /// Names of external unatries
        /// </summary>
        public Dictionary<int, string> OperationNames
        {
            get
            {
                return operationNames;
            }
        }

        /// <summary>
        /// Sets value of "Should Runtime Update" sign
        /// </summary>
        /// <param name="shouldRuntimeUpdate">The "Should Runtime Update" sign</param>
        public void SetShouldRuntimeUpdate(bool shouldRuntimeUpdate)
        {
            this.shouldRuntimeUpdate = shouldRuntimeUpdate;
        }

        /// <summary>
        /// Feedback
        /// </summary>
        public Dictionary<int, string> Feedback
        {
            get
            {
                return feedback;
            }
            set
            {
                feedback = value;
                SetFeedback();
            }
        }

        /// <summary>
        /// Adds operation
        /// </summary>
        /// <param name="op">The operation to add</param>
        public void AddOperation(IObjectOperation op)
        {
            operations.Add(op);
        }

        /// <summary>
        /// Count of external operations
        /// </summary>
        public int OperationsCount
        {
            get
            {
                return operations.Count;
            }
        }

        /// <summary>
        /// Gets i - th external opreation
        /// </summary>
        /// <param name="i">The index of operation</param>
        /// <returns>The i - th unary</returns>
        public IObjectOperation GetOperation(int i)
        {
            return operations[i] as IObjectOperation;
        }

        /// <summary>
        /// Removes operation source
        /// </summary>
        /// <param name="op">The source to add</param>
        public void RemoveOperation(IObjectOperation op)
        {
            operations.Remove(op);
        }

        /// <summary>
        /// The "Calculate derivation" sign
        /// </summary>
        public bool CalculateDerivation
        {
            get
            {
                return calculateDerivation;
            }
            set
            {
                calculateDerivation = value;
            }
        }

        /// <summary>
        /// Input parameters
        /// </summary>
        public virtual string InputParameters
        {
            get
            {
                string var = Variables;
                string s = "";
                foreach (char c in var)
                {
                    if (parameters.ContainsKey("" + c))
                    {
                        continue;
                    }
                    s += c;
                }
                return s;
            }
        }

        /// <summary>
        /// The name of measurements source
        /// </summary>
        public string SourceName
        {
            get
            {
                INamedComponent comp = Object as INamedComponent;
                return comp.Name;
            }
        }

        /// <summary>
        /// The correctness sign
        /// </summary>
        public bool IsCorrect
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Operations
        /// </summary>
        public List<IObjectOperation> Operations
        {
            get
            {
                return operations;
            }
        }

        /// <summary>
        /// Order of derivation
        /// </summary>
        public int DerivationOrder
        {
            get
            {
                return deriOrder;
            }
            set
            {
                deriOrder = value;
            }
        }

        /// <summary>
        /// Create aliases
        /// </summary>
        /// <param name="str">String of aliases</param>
        public void CreateAliases(string str)
        {
            parameters.Clear();
            foreach (char c in str)
            {
                double a = 0;
                parameters["" + c] = a;
            }
        }

        #endregion

        #region Abstract Members


        /// <summary>
        /// The input dynamical parameter
        /// </summary>
        public abstract DynamicalParameter Parameter
        {
            set;
        }

        /// <summary>
        /// All formulas variables
        /// </summary>
        public abstract string AllVariables
        {
            get;
        }
        /// <summary>
        /// Variables
        /// </summary>
        public abstract string Variables
        {
            get;
        }

        /// <summary>
        /// Table of operations
        /// </summary>
        protected abstract Dictionary<int, ICategoryObject> InternalOperationTable
        {
            get;
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// The count of measurements
        /// </summary>
        protected virtual int MeasurementsCount
        {
            get { return measurements.Length; }
        }

        protected virtual void SetFeedback()
        {
            feedAliases.Clear();
            foreach (int i in feedback.Keys)
            {
                feedAliases[i] = this.FindAliasName(feedback[i], false);
            }
        }


        #endregion

        #region Private Members



        #endregion

    }
}