using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI.Aliases;

using BaseTypes.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

using FormulaEditor;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;
using DataPerformer.Formula;
using DataPerformer.Formula.Interfaces;

namespace DataPerformer
{
    /// <summary>
    /// Solver of ordinary differential equations system
    /// </summary>
    [Serializable()]
    public class DifferentialEquationSolver : DataConsumer, IDifferentialEquationSolver, ISerializable,
        IStarted, IAlias, ICheckCorrectness,  IVariableDetector,
        IDynamical, ITreeCollection, ITimeVariable, IStack, IRuntimeUpdate, IPostSetArrow
    {

        #region Fields

        /// <summary>
        /// Input dynamical parameter
        /// </summary>
        private Formula.DynamicalParameter par;

        /// <summary>
        /// Table of variables of equations. Table contains initial values and derivations of variables
        /// </summary>
        private Hashtable variables = new Hashtable();

        /// <summary>
        /// Table representation of input parameters
        /// </summary>
        private Dictionary<char, VariableMeasurement> parameters = new Dictionary<char, VariableMeasurement>();

        /// <summary>
        /// Output parameters
        /// </summary>
        private Variable[] output;

        /// <summary>
        /// The time
        /// </summary>
        private double time;

        /// <summary>
        /// Current time
        /// </summary>
        private double timeOld;

        /// <summary>
        /// List of right parts arguments
        /// </summary>
        private List<string> arguments = new List<string>();

        /// <summary>
        /// Table representation of variables
        /// </summary>
        private Hashtable vars = new Hashtable();

        /// <summary>
        /// Table representation of parameters
        /// </summary>
        private Hashtable pars = new Hashtable();

        /// <summary>
        /// Table of aliases
        /// </summary>
        private Hashtable aliases = new Hashtable();

        /// <summary>
        /// Table of aliases names
        /// </summary>
        private Hashtable aliasNames = new Hashtable();

        /// <summary>
        /// Table of external aliases
        /// </summary>
        private Dictionary<Variable, AliasName> externalAliases = new Dictionary<Variable, AliasName>();

        /// <summary>
        /// List of variables
        /// </summary>
        private List<Variable> varlist = new List<Variable>();


        private List<string> variabelstr = new List<string>();


        /// <summary>
        /// The "is serialized" flag
        /// </summary>
        private bool isSerialized = false;


        /// <summary>
        /// Dictionary of acceptors
        /// </summary>
        private Dictionary<string, IOperationAcceptor> acc = new Dictionary<string, IOperationAcceptor>();

        /// <summary>
        /// Formula creator
        /// </summary>
        private IFormulaObjectCreator creator;

        /// <summary>
        /// Order of derivation
        /// </summary>
        private int deriOrder = 0;

        /// <summary>
        /// Start preparation
        /// </summary>
        private Action prepareStart;

        /// <summary>
        /// Update action
        /// </summary>
        private Action update;

        /// <summary>
        /// Measurements
        /// </summary>
        private List<IMeasurement> formulas = new List<IMeasurement>();


        private List<FormulaMeasurement> fom = new List<FormulaMeasurement>();

        /// <summary>
        /// Time variable
        /// </summary>
        private VariableMeasurement timeVariable;

        /// <summary>
        /// Orders of derivations
        /// </summary>
        private Dictionary<string, int> deriOrders = new Dictionary<string, int>();

        private double[] outputD;

        /// <summary>
        /// Change alias event
        /// </summary>
        event Action<IAlias, string> onChange = (IAlias a, string name) => { };


        private ArrayList args = new ArrayList();

        ITreeCollectionProxy proxy;

        #endregion

        #region Constructors

        /// <summary>
        /// Consructor
        /// </summary>
        public DifferentialEquationSolver()
            : base(30)
        {
            init();
            vars = new Hashtable();
            pars = new Hashtable();
            aliases = new Hashtable();
  
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public DifferentialEquationSolver(SerializationInfo info, StreamingContext context)
            :
            base(30)
        {
            init();
            try
            {
                isSerialized = true;
                vars = (Hashtable)info.GetValue("Vars", typeof(Hashtable));
                pars = (Hashtable)info.GetValue("Pars", typeof(Hashtable));
                aliases = (Hashtable)info.GetValue("Aliases", typeof(Hashtable));
                args = (ArrayList)info.GetValue("Arguments", typeof(ArrayList));
                aliasNames = (Hashtable)info.GetValue("AliasNames", typeof(Hashtable));
                comments = (byte[])info.GetValue("Comments", typeof(byte[]));
            }
            catch (Exception ex)
            {
                comments = new byte[0];
                ex.ShowError(100);
            }
            try
            {
                deriOrder = (int)info.GetValue("DerivationOrder", typeof(int));
                deriOrders = info.GetValue("DerivationOrders", typeof(Dictionary<string, int>))
                    as Dictionary<string, int>;
            }
            catch (Exception exc)
            {
                exc.ShowError(10);
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        new public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Vars", vars);
            info.AddValue("Pars", pars);
            info.AddValue("Aliases", aliases);
            args = new ArrayList();
            foreach (string s in arguments)
            {
                args.Add(s);
            }
            info.AddValue("Arguments", args);
            info.AddValue("AliasNames", aliasNames);
            if (comments != null)
            {
                info.AddValue("Comments", comments);
            }
            info.AddValue("DerivationOrder", deriOrder);
            info.AddValue("DerivationOrders", deriOrders, typeof(Dictionary<string, int>));

        }

        /// <summary>
        /// Keys of variables
        /// </summary>
        public ICollection Keys
        {
            get
            {
                return variables.Keys;
            }
        }

        /// <summary>
        /// Access to variable
        /// </summary>
        public string this[char c]
        {
            get
            {
                object[] o = variables[c] as object[];
                return o[0] as string;
            }
        }

        /// <summary>
        /// Copies variables from processor to solver 
        /// </summary>
        /// <param name="offset">Offset</param>
        /// <param name="variables">Vector of all desktop differential equations variables</param>
        public void CopyVariablesToSolver(int offset, double[] variables)
        {
            int i = offset;
            foreach (Variable v in output)
            {
                v.Value = variables[i];
                ++i;
            }
        }


        /// <summary>
        /// Comments
        /// </summary>
        public ArrayList Comments
        {
            get
            {
                return PureDesktopPeer.Deserialize(comments) as ArrayList;
            }
            set
            {
                comments = PureDesktopPeer.Serialize(value);
            }
        }


        /// <summary>
        /// The count of measurements
        /// </summary>
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

        int VariablesCount
        {
            get
            {
                IMeasurements m = this;
                return m.Count;
            }
        }


        /// <summary>
        /// Access to n - th measurement
        /// </summary>
        IMeasurement IMeasurements.this[int n]
        {
            get
            {
                return output[n];
            }
        }



        /// <summary>
        /// Updates measurements data
        /// </summary>
        public void UpdateMeasurements()
        {
            if (IsUpdated)
            {
                return;
            }
            try
            {
               // UpdateChildrenData();
                CalculateDerivations();
                isUpdated = true;
            }
            catch (Exception e)
            {
                e.ShowError(10);
                this.Throw(e);
            }
        }


        /// <summary>
        /// The time
        /// </summary>
        public double Time
        {
            set
            {
                time = value;
            }
        }

        /// <summary>
        /// The operation that performs after arrows setting
        /// </summary>
        public void PostSetArrow()
        {
            postDeserialize();
            postSetAlias();
        }

        /// <summary>
        /// Checks its correctenss
        /// </summary>
        public void CheckCorrectness()
        {
            try
            {
                //PostSetArrow();
            }
            catch (Exception e)
            {
                e.ShowError(10);
                this.Throw(e);
            }
        }


        /// <summary>
        /// Accepts measurements
        /// </summary>
        private void acceptMeasurements()
        {
            timeVariable = null;
           Formula.DynamicalParameter parameter = new Formula.DynamicalParameter();
            parameters.Clear();
            foreach (IMeasurements measurements in measurementsData)
            {
                string name = this.GetMeasurementsName(measurements);
                for (int i = 0; i < measurements.Count; i++)
                {
                    IMeasurement measure = measurements[i];
                    string p = name + "." + measure.Name;
                    foreach (char c in pars.Keys)
                    {
                        if (!pars.ContainsKey(c))
                        {
                            continue;
                        }
                        if (pars[c] == null)
                        {
                            continue;
                        }
                        string s = pars[c] as string;
                        if (s.Equals(p))
                        {
                            parameter.Add(c, measure);
                            VariableMeasurement vm = c.Create(measure, this);
                            parameters[c] = vm;
                        }
                    }
                }
            }
            foreach (string s in arguments)
            {
                if (s.Substring(s.Length - 4).Equals("Time"))
                {
                    timeVariable = s[0].Create(
                      StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement,
                        this);
                    parameters[s[0]] = timeVariable;
                }
            }
            foreach (char c in pars.Keys)
            {
                if (!parameters.ContainsKey(c))
                {
                    if (pars[c] != null)
                    {
                        this.Throw(new Exception(PureDesktop.GetResourceString(VectorFormulaConsumer.ExternalParameter_) +
                            c + PureDesktop.GetResourceString(VectorFormulaConsumer._IsNotDefined)));
                    }
                }
            }
            Parameter = parameter;
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
        /// Arguments of equations
        /// </summary>
        public List<string> Arguments
        {
            get
            {
                return arguments;
            }
            set
            {
                bool b = false;
                string str = InputParameters;
                string sc = ConstantNames;
                foreach (char c in str)
                {
                    if (aliases.ContainsKey(c + ""))
                    {
                        continue;
                    }
                    foreach (string s in value)
                    {
                        if (s[0] == c)
                        {
                            goto m;
                        }
                    }
                    throw new Exception(DataConsumer.VariablesShortage + " : " + c);
                m:
                    b = !b;
                }
                arguments = value;
                pars.Clear();
                foreach (string s in arguments)
                {
                    pars[s[0]] = s.Substring(4);
                }
            }
        }

        /// <summary>
        /// Input dynamical parameter
        /// </summary>
        public Formula.DynamicalParameter Parameter
        {
            set
            {
                par = value;
            }
        }

        /// <summary>
        /// Starts this object
        /// </summary>
        new public void Start(double time)
        {
            try
            {
                timeOld = time;
                foreach (Variable v in output)
                {
                    char c = v.Symbol;
                    object[] o = variables[c] as object[];
                    v.Value = (double)o[4];
                }
                prepareStart = () =>
                {
                    UpdateChildrenData();

                    foreach (object[] o in variables.Values)
                    {
                        ObjectFormulaTree t = o[2] as ObjectFormulaTree;
                        object ob = t.Result;
                        DeltaFunction.Reset(t);
                    }
                    prepareStart = () => { };
                };
            }
            catch (Exception e)
            {
                e.ShowError(10);
                this.Throw(e);
            }
        }

        /// <summary>
        /// Calculates initial value of variable
        /// </summary>
        /// <param name="c">The variable key</param>
        /// <returns>Initial value of variable</returns>
        public double GetInitialValue(char c)
        {
            object[] o = variables[c] as object[];
            return (double)o[4];
        }

        /// <summary>
        /// Adds variable
        /// </summary>
        /// <param name="c">The variable key</param>
        public void AddVariable(char c)
        {
            double a = 0;
            variables[c] = new object[] { "", null, null, a, a, a };
            vars[c] = new object[] { "", a };
        }

        /// <summary>
        /// Sets right part formula to variable
        /// </summary>
        /// <param name="c">The variable key</param>
        /// <param name="formula">The string representation of formula</param>
        public void SetVariable(char c, string formula)
        {
            object[] o = variables[c] as object[];
            o[0] = formula;
            object[] ob = vars[c] as object[];
            ob[0] = formula;
        }

        /// <summary>
        /// Sets initial value of variable
        /// </summary>
        /// <param name="c">The variable key</param>
        /// <param name="a">Initial value of variable</param>
        public void SetValue(char c, object a)
        {
            object[] o = variables[c] as object[];
            o[4] = a;
            object[] ob = vars[c] as object[];
            ob[1] = a;
        }

        /// <summary>
        /// All variabeles in formulas
        /// </summary>
        public string AllVariables
        {
            get
            {
                string s = "";
                foreach (object[] o in variables.Values)
                {
                    string st = o[0] as string;
                    MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, st);
                    string str = ElementaryObjectDetector.GetVariables(f);
                    foreach (char c in str)
                    {
                        if (s.IndexOf(c) < 0)
                        {
                            s += c;
                        }
                    }
                }
                return s;
            }
        }

        /// <summary>
        /// Preparation
        /// </summary>
        new public void Prepare()
        {

            //parameters.Clear();
            //string str = "";
            //            aliases.Clear();
            Double a = 0;
            string var = AllVariables;
            Hashtable table = new Hashtable();
            foreach (char c in var)
            {
                table[c] = a;
            }
            string proh = "\u03B4";
            foreach (char c in par.Variables)
            {
                IMeasurement m = par[c];
                object t = m.Type;
                if (t is IOneVariableFunction)
                {
                    proh += c;
                    table[c] = m.Parameter();
                }
                else
                {
                    table[c] = t;
                }
            }
            ArrayList l = new ArrayList(variables.Keys);
            l.Sort();
            output = new Variable[l.Count];
            variabelstr.Clear();
            AssociatedAddition aa = new AssociatedAddition(this, null);
            for (int i = 0; i < l.Count; i++)
            {
                char c = (char)l[i];
                AddVariable(c, aa);
            }
            formulas.Clear();
            fom.Clear();
            for (int i = 0; i < l.Count; i++)
            {
                char c = (char)l[i];
                object[] o = variables[c] as object[];
                string st = o[0] as string;
                MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, st);
                o[1] = f;
                ObjectFormulaTree t = ObjectFormulaTree.CreateTree(f.FullTransform(proh), creator);
                o[2] = t;
                string vn = c + "";
                Variable v = acc[vn] as Variable;
                output[i] = v;
                bool ne = deriOrder > 0;
                if (deriOrders.ContainsKey(vn))
                {
                    if (deriOrders[vn] > 0)
                    {
                        ne = true;
                    }
                }
                v.SetTree(t, ne, aa, formulas);
            }
            SetDerivations();
        }

        /// <summary>
        /// Orders of derivations
        /// </summary>
        public Dictionary<string, int> DerivationOrders
        {
            get
            {
                return deriOrders;
            }
        }

        /// <summary>
        /// Clears parameters
        /// </summary>
        public void ClearParameters()
        {
            parameters.Clear();
            pars.Clear();
        }

        /// <summary>
        /// String of parameters
        /// </summary>
        public string Parameters
        {
            get
            {
                string s = "";
                foreach (char c in parameters.Keys)
                {
                    s += c;
                }
                return s;
            }
        }

        /// <summary>
        /// String of input parameters
        /// </summary>
        public string InputParameters
        {
            get
            {
                string s = "";
                string all = AllVariables;
                foreach (char c in all)
                {
                    if (aliases.ContainsKey("" + c) | variables.ContainsKey(c))
                    {
                        continue;
                    }
                    s += c;
                }
                return s;
            }
        }

        /// <summary>
        /// String of input parameters
        /// </summary>
        public string AllParameters
        {
            get
            {
                string s = "";
                string all = AllVariables;
                foreach (char c in all)
                {
                    if (variables.ContainsKey(c))
                    {
                        continue;
                    }
                    s += c;
                }
                return s;
            }
        }


        /// <summary>
        /// Clears aliases
        /// </summary>
        public void ResetAliases()
        {
            aliases.Clear();
            acc.Clear();
            foreach (char c in vars.Keys)
            {
                AddAlias("" + c);
            }
        }

        /// <summary>
        /// Adds alias
        /// </summary>
        /// <param name="alias">The alias to add</param>
        public void AddAlias(string alias)
        {
            double a = 0;
            aliases[alias] = a;
        }

        /// <summary>
        /// Sets input parameter
        /// </summary>
        /// <param name="c">The parameter key</param>
        /// <param name="m">The parameter measurement</param>
        public void SetParameter(char c, IMeasurement m)
        {
            VariableMeasurement v = c.Create(m, this);
            parameters[c] = v;
            string s = m.Name;
            pars[c] = s;
        }


        /// <summary>
        /// String of constants names
        /// </summary>
        public string ConstantNames
        {
            get
            {
                string str = "";
                IList<string> l = AliasNames;
                foreach (string s in l)
                {
                    if (!vars.ContainsKey(s[0]))
                    {
                        str += s;
                    }
                }
                return str;
            }
        }


        #region IAlias Members

        /// <summary>
        /// Names of aliases
        /// </summary>
        public IList<string> AliasNames
        {
            get
            {
                List<string> s = new List<string>();
                foreach (string str in aliases.Keys)
                {
                    s.Add(str);
                }
                return s;
            }
        }

        /// <summary>
        /// Access to alias object
        /// </summary>
        public object this[string alias]
        {
            get
            {
                return aliases[alias];
            }
            set
            {
                char c = alias[0];
                // double a = (double)value;
                aliases[alias] = value;
                if (variables.ContainsKey(c))
                {
                    SetValue(c, value);
                }
            }
        }

        /// <summary>
        /// Gets object type
        /// </summary>
        /// <param name="name">Object name</param>
        /// <returns>Returns type of alias object</returns>
        public object GetType(string name)
        {
            return AliasTypeDetector.Detector.DetectType(this[name]);
        }

        event Action<IAlias, string> IAlias.OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        /// <summary>
        /// Clears set of variables
        /// </summary>
        public void ClearVariables()
        {
            variables.Clear();
            vars.Clear();
        }



        /// <summary>
        /// Performs operations after deserialization
        /// </summary>
        private void postDeserialize()
        {
            foreach (string s in args)
            {
                arguments.Add(s);
            }
            args.Clear();
            foreach (char c in vars.Keys)
            {
                object[] o = vars[c] as object[];
                double d = 0;
                if (!variables.ContainsKey(c))
                {
                    variables[c] = new object[] { o[0], null, null, o[1], o[1], d };
                }
            }
            string str = "";
            foreach (char c in vars.Keys)
            {
                object[] o = vars[c] as object[];
                string st = o[0] as string;
                MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, st);
                string s = ElementaryObjectDetector.GetVariables(f);
            }
            Double a = 0;
            varlist.Clear();
            foreach (char c in variables.Keys)
            {
                if (str.IndexOf(c) < 0)
                {
                    str += c;
                }
            }
            foreach (string s in aliases.Keys)
            {
                if (!str.Contains(s))
                {
                    str += s;
                }
            }
            if (!isSerialized)
            {
                pars.Clear();
                isSerialized = false;
                foreach (string ps in arguments)
                {
                    pars[ps[0]] = ps.Substring(4);
                }
            }
            acceptMeasurements();
            Hashtable table = new Hashtable();
            foreach (char c in str)
            {
                table[c] = a;
            }
            string proh = "\u03B4";
            foreach (char c in pars.Keys)
            {
                if (pars.ContainsKey(c))
                {
                    if (pars[c] != null)
                    {
                        VariableMeasurement v = parameters[c];
                        IMeasurement m = v.Measurement;
                        object t = m.Type;
                        if (t is IOneVariableFunction)
                        {
                            proh += c;
                            table[c] = m.Parameter();
                        }
                        else
                        {
                            table[c] = t;
                        }
                        acc[c + ""] = c.Create(m, this);
                    }
                }
            }
            AssociatedAddition aa = new AssociatedAddition(this, null);
            foreach (string s in aliases.Keys)
            {
                if (variables.ContainsKey(s[0]))
                {
                    if (!acc.ContainsKey(s))
                    {
                        acc[s] = new Variable(s, aa);
                    }
                }
                else
                {
                    if (!acc.ContainsKey(s))
                    {
                        acc[s] = new AliasNameVariable(s, this, s);
                    }
                }
            }
            ArrayList l = new ArrayList(variables.Keys);
            l.Sort();
            output = new Variable[l.Count];
            for (int i = 0; i < l.Count; i++)
            {
                char c = (char)l[i];
                AddVariable(c, aa);
            }
            formulas.Clear();
            for (int i = 0; i < l.Count; i++)
            {
                char c = (char)l[i];
                object[] o = variables[c] as object[];
                string st = o[0] as string;
                MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, st);
                o[1] = f;
                ObjectFormulaTree t = ObjectFormulaTree.CreateTree(f.FullTransform(proh), creator);
                o[2] = t;
                string vn = c + "";
                Variable v = acc[vn] as Variable;
                output[i] = v;
                bool ne = deriOrder > 0;
                int dor = deriOrder;
                if (deriOrders.ContainsKey(vn))
                {
                    int dd = deriOrders[vn];
                    if (dd > dor)
                    {
                        dor = dd;
                    }
                    if (dor > 0)
                    {
                        ne = true;
                    }
                }
                v.SetTree(t, ne, aa, formulas);
            }
            foreach (IMeasurement mf in formulas)
            {
                if (mf is FormulaMeasurement)
                {
                    fom.Add(mf as FormulaMeasurement);
                }
            }
            SetDerivations();
            try
            {
                proxy = null;
                proxy = this.CreateProxy();
                // PROXY UPDATE
                update = proxy.Update;
                FormulaMeasurement.Set(formulas, proxy);
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

   /*!!! PROXY TEST     ITreeCollectionProxy Proxy
        {
            get
            {
                ITreeCollection t = this;
                return new Calculation.Calculate(t.Trees, (object o) => { });
            }
        }
        */

        /// <summary>
        /// Calculates derivations
        /// </summary>
        public void CalculateDerivations()
        {
            try
            {
                foreach (Variable v in externalAliases.Keys)
                {
                    AliasName an = externalAliases[v];
                    IMeasurement m = v;
                    an.SetValue(m.Parameter());
                }
                foreach (IMeasurements m in dependent)
                {
                    m.IsUpdated = false;
                    m.UpdateMeasurements();
                }
                update();
            }
            catch (Exception e)
            {
                e.ShowError();
            }
        }

        /// <summary>
        /// Table of external aliases
        /// </summary>
        public Hashtable ExternalAliases
        {
            get
            {
                return aliasNames;
            }
            set
            {
                aliasNames = value;
                postSetAlias();
            }
        }

        /// <summary>
        /// Names of all aliases
        /// </summary>
        public override List<string> AllAliases
        {
            get
            {
                List<string> a = new List<string>();
                this.GetAliases(a, null);
                return a;
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
        /// Initialization
        /// </summary>
        private void init()
        {
            creator = VariableDetector.GetCreator(this);
            prepareStart = () => { };
            update = () =>
            {
                foreach (Variable v in output)
                {
                    v.Update();
                }
            };

        }

        /// <summary>
        /// Gets value of variable
        /// </summary>
        /// <param name="c">The variable keu</param>
        /// <returns>The value of variable</returns>
        private double GetValue(char c)
        {
            object[] o = variables[c] as object[];
            return (double)o[3];
        }

        private IDistribution GetDistribution(char c)
        {
            object[] ob = variables[c] as object[];
            object o = ob[2];
            if (o == null)
            {
                return null;
            }
            ObjectFormulaTree t = o as ObjectFormulaTree;
            return DeltaFunction.GetDistribution(t);
        }



        private void postSetAlias()
        {
            externalAliases.Clear();
            if (aliasNames == null)
            {
                return;
            }
            foreach (char c in aliasNames.Keys)
            {
                string s = aliasNames[c] as string;
                Variable v = acc[c + ""] as Variable;
                externalAliases[v] = this.FindAliasName(s, false);
            }
        }


        private void SetDerivations()
        {
            bool next = true;
            //bool br = false;
            for (int j = 1; ; j++)
            {
                bool ret = j >= deriOrder - 1;
                if (j > (deriOrder - 1))
                {
                    next = false;
                }
                for (int k = 0; k < output.Length; k++)
                {
                    Variable lv = output[k];
                    string symb = lv.String;
                    bool ne = next;
                    bool cont = j < deriOrder;
                    if (!ne)
                    {
                        if (deriOrders.ContainsKey(symb))
                        {
                            int dor = deriOrders[symb];
                            if (j <= dor)
                            {
                                ret = false;
                                cont = true;
                                if (j < dor - 1)
                                {
                                    ret = false;
                                }
                                if (j < dor)
                                {
                                    ne = true;
                                }
                            }
                        }
                    }
                    if (cont)
                    {
                        lv.Iterate(ne);
                    }
                }
                if (ret)
                {
                    break;
                }

            }
        }

        private void AddVariable(char c, AssociatedAddition aa)
        {
            string str = c + "";
            Variable v = new Variable(str, aa);
            if (!acc.ContainsKey(str))
            {
                acc[str] = v;
            }
            if (!variabelstr.Contains(str))
            {
                variabelstr.Add(str);
            }
        }

        #endregion

        #region IVariableDetector Members

        IOperationAcceptor IVariableDetector.Detect(MathSymbol sym)
        {
            if (sym.SymbolType != (int)FormulaConstants.Variable)
            {
                return null;
            }
            string s = sym.Symbol + "";
            if (acc.ContainsKey(s))
            {
                return acc[s];
            }
            return null;
        }

        #endregion

        #region IDynamical Members

        double IDynamical.Time
        {
            set { prepareStart(); }
        }

        #endregion

        #region ITreeCollection Members

        ObjectFormulaTree[] ITreeCollection.Trees
        {
            get
            {
                return FormulaMeasurement.GetTrees(fom.ToArray());
            }
        }

        bool ITreeCollection.IsValid
        {
            get
            {
                return proxy != null;
            }
        }

        #endregion

        #region ITimeVariable Members

        VariableMeasurement ITimeVariable.Variable
        {
            get { return timeVariable; }
        }

        #endregion

        #region IRuntimeUpdate Members

        bool IRuntimeUpdate.ShouldRuntimeUpdate
        {
            get { return true; }
            set { }
        }

        #endregion

     
        #region IStack Members

        void IStack.Push()
        {
            foreach (IStack s in output)
            {
                s.Push();
            }
        }

        void IStack.Pop()
        {
            foreach (IStack s in output)
            {
                s.Pop();
            }
        }

        #endregion

        #region IStateDoubleVariables Members

        List<string> IStateDoubleVariables.Variables
        {
            get { return variabelstr; }
        }

        double[] IStateDoubleVariables.Vector
        {
            get
            {
                if (outputD == null)
                {
                    outputD = new double[output.Length];
                }
                else if (outputD.Length != output.Length)
                {
                    outputD = new double[outputD.Length];
                }
                int i = 0;
                foreach (IMeasurement m in output)
                {
                    outputD[i] = (double)m.Parameter();
                    ++i;
                }
                return outputD;
            }
            set
            {
                int i = 0;
                foreach (Variable v in output)
                {
                    double x = value[i];
                    v.Value = x;
                    object[] o = variables[v.Symbol] as object[];
                    o[4] = x;
                    ++i;
                }
            }
        }


        void IStateDoubleVariables.Set(double[] input, int offset, int length)
        {
            int i = offset;
            foreach (Variable v in output)
            {
                double x = input[i];
                v.Value = x;
                object[] o = variables[v.Symbol] as object[];
                o[4] = x;
                ++i;
            }
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Time measure
        /// </summary>
        protected override IMeasurement TimeMeasure
        {
            get
            {
                return this.GetTimeMeasure();
            }
            set
            {
                value.Set(this);
            }
        }


        #endregion

        #region Classes & Delegates

        class Variable : IObjectOperation, IPowered, IOperationAcceptor, IMeasurement, IDerivation, IDerivationOperation, IStack
        {

            #region Fields

            private Stack<double> stack = new Stack<double>();

            const Double a = 0;

            double value;

            FormulaMeasurement derivation;

            FormulaMeasurementDerivation temp;

            ObjectFormulaTree tree;

            Func<object> par;


            private string symbol;

            protected AssociatedAddition addition;

            #endregion

            #region Ctor

            internal Variable(string symbol, AssociatedAddition addition)
            {
                this.symbol = symbol;
                par = GetValue;
                this.addition = addition;
            }



            #endregion

            #region IObjectOperation Members

            object[] IObjectOperation.InputTypes
            {
                get { return new object[0]; }
            }

            object IObjectOperation.this[object[] x]
            {
                get { return value; }
            }

            object IObjectOperation.ReturnType
            {
                get { return a; }
            }

            bool IPowered.IsPowered
            {
                get { return true; }
            }

            #endregion

            #region IOperationAcceptor Members

            IObjectOperation IOperationAcceptor.Accept(object type)
            {
                return this;
            }

            #endregion

            #region IDerivation Members

            IMeasurement IDerivation.Derivation
            {
                get { return derivation; }
            }

            #endregion

            #region IDerivationOperation Members

            ObjectFormulaTree IDerivationOperation.Derivation(ObjectFormulaTree tree, string s)
            {
                if (s.Equals("d/dt"))
                {
                    return this.tree;
                }
                return null;
            }

            #endregion

            #region IMeasurement Members

            Func<object> IMeasurement.Parameter
            {
                get { return par; }
            }

            string IMeasurement.Name
            {
                get { return symbol; }
            }

            object IMeasurement.Type
            {
                get { return a; }
            }

            #endregion

            #region Members


            internal string String
            {
                get
                {
                    return symbol;
                }
            }

            internal void SetTree(ObjectFormulaTree tree,
                bool next,
                AssociatedAddition addition,
                IList<IMeasurement> list)
            {
                string dn = "D" + symbol;
                this.tree = tree;
                IDistribution d = DeltaFunction.GetDistribution(tree);
                if (next)
                {
                    if (d != null)
                    {
                        temp = new FormulaMeasurementDerivationDistribution(tree, null, symbol, addition);
                    }
                    else
                    {
                        temp = new FormulaMeasurementDerivation(tree, null, symbol, addition);
                    }
                    derivation = temp;
                    list.Add(derivation);
                    return;
                }
                if (d != null)
                {
                    derivation = new FormulaMeasurementDistribution(tree, symbol, addition);
                }
                else
                {
                    derivation = new FormulaMeasurement(tree, symbol, addition);
                }
                list.Add(derivation);
                return;
            }

            internal void Iterate(bool next)
            {
                AssociatedAddition aa = FormulaMeasurementDerivation.Create(addition);
                temp = temp.Iterate(next, aa);
            }

            internal char Symbol
            {
                get
                {
                    return symbol[0];
                }
            }

            internal double Value
            {
                set
                {
                    this.value = value;
                }
            }

            internal void Update()
            {
                derivation.Update();
            }

            private object GetValue()
            {
                return value;
            }

            #endregion

            #region IStack Members

            void IStack.Push()
            {
                stack.Push(value);
            }

            void IStack.Pop()
            {
                value = stack.Pop();
            }

            #endregion
        }

        //delegate void PrepareStart(); */

        #endregion
 
    }
}

/* !!!  DEBUG OF ORBIT DETERMINATION
namespace Calculation
{

    public class Calculate : FormulaEditor.Interfaces.ITreeCollectionProxy
    {


        public void Update()
        {
            currentTree = trees[0];
            currentArray = treeArray_0;
            var_0 = (double)currentTree.Calculate(currentArray);
            currentTree = trees[1];
            currentArray = treeArray_1;
            var_1 = (double)currentTree.Calculate(currentArray);
            currentTree = trees[2];
            currentArray = treeArray_2;
            var_2 = (double)currentTree.Calculate(currentArray);
            var_3 = (var_1) * (var_2);
            currentTree = trees[4];
            currentArray = treeArray_4;
            var_4 = (double)currentTree.Calculate(currentArray);
            currentTree = trees[5];
            currentArray = treeArray_5;
            var_5 = (double)currentTree.Calculate(currentArray);
            var_6 = (var_4) * (var_5);
            currentTree = trees[7];
            currentArray = treeArray_7;
            var_7 = (double)currentTree.Calculate(currentArray);
            var_8 = (var_6) * (var_7);
            currentTree = trees[9];
            currentArray = treeArray_9;
            var_9 = (double)currentTree.Calculate(currentArray);
            var_10 = (var_8) * (var_9);
            var_11 = (var_3) - (var_10);
            var_12 = (var_0) + (var_11);
            currentTree = trees[13];
            currentArray = treeArray_13;
            var_13 = (double)currentTree.Calculate(currentArray);
            currentTree = trees[14];
            currentArray = treeArray_14;
            var_14 = (double)currentTree.Calculate(currentArray);
            var_15 = (var_13) * (var_14);
            var_16 = (var_12) + (var_15);
            currentTree = trees[17];
            currentArray = treeArray_17;
            var_17 = (double)currentTree.Calculate(currentArray);
            currentTree = trees[18];
            currentArray = treeArray_18;
            var_18 = (double)currentTree.Calculate(currentArray);
            var_19 = (var_1) * (var_18);
            var_20 = (var_4) * (var_5);
            var_21 = (var_20) * (var_7);
            currentTree = trees[22];
            currentArray = treeArray_22;
            var_22 = (double)currentTree.Calculate(currentArray);
            var_23 = (var_21) * (var_22);
            var_24 = (var_19) - (var_23);
            currentTree = trees[25];
            currentArray = treeArray_25;
            var_25 = (double)currentTree.Calculate(currentArray);
            var_26 = (var_13) * (var_25);
            var_27 = (var_24) - (var_26);
            var_28 = (var_17) + (var_27);
            currentTree = trees[29];
            currentArray = treeArray_29;
            var_29 = (double)currentTree.Calculate(currentArray);
            var_30 = (var_4) * (var_5);
            var_31 = (var_30) * (var_7);
            currentTree = trees[32];
            currentArray = treeArray_32;
            var_32 = (double)currentTree.Calculate(currentArray);
            var_33 = (var_31) * (var_32);
            var_34 = (var_29) - (var_33);
            currentTree = trees[35];
            currentArray = treeArray_35;
            var_35 = (double)currentTree.Calculate(currentArray);
            currentTree = trees[36];
            currentArray = treeArray_36;
            var_36 = (double)currentTree.Calculate(currentArray);
            currentTree = trees[37];
            currentArray = treeArray_37;
            var_37 = (double)currentTree.Calculate(currentArray);
            checkValue(var_0);
            checkValue(var_1);
            checkValue(var_2);
            checkValue(var_3);
            checkValue(var_4);
            checkValue(var_5);
            checkValue(var_6);
            checkValue(var_7);
            checkValue(var_8);
            checkValue(var_9);
            checkValue(var_10);
            checkValue(var_11);
            checkValue(var_12);
            checkValue(var_13);
            checkValue(var_14);
            checkValue(var_15);
            checkValue(var_16);
            checkValue(var_17);
            checkValue(var_18);
            checkValue(var_19);
            checkValue(var_20);
            checkValue(var_21);
            checkValue(var_22);
            checkValue(var_23);
            checkValue(var_24);
            checkValue(var_25);
            checkValue(var_26);
            checkValue(var_27);
            checkValue(var_28);
            checkValue(var_29);
            checkValue(var_30);
            checkValue(var_31);
            checkValue(var_32);
            checkValue(var_33);
            checkValue(var_34);
            checkValue(var_35);
            checkValue(var_36);
            checkValue(var_37);
        }

        public Calculate(FormulaEditor.ObjectFormulaTree[] trees, BaseTypes.ObjectAction checkValue)
        {
            this.trees = trees;
            this.checkValue = checkValue;
            dictionary[trees[16]] = Get_16;
            dictionary[trees[28]] = Get_28;
            dictionary[trees[34]] = Get_34;
            dictionary[trees[35]] = Get_35;
            dictionary[trees[36]] = Get_36;
            dictionary[trees[37]] = Get_37;
        }

        public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
        { get { return dictionary[tree]; } }

        Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();

        object[] treeArray_0 = new object[0];
        object[] treeArray_1 = new object[0];
        object[] treeArray_2 = new object[0];
        object[] treeArray_4 = new object[0];
        object[] treeArray_5 = new object[0];
        object[] treeArray_7 = new object[0];
        object[] treeArray_9 = new object[0];
        object[] treeArray_13 = new object[0];
        object[] treeArray_14 = new object[0];
        object[] treeArray_17 = new object[0];
        object[] treeArray_18 = new object[0];
        object[] treeArray_22 = new object[0];
        object[] treeArray_25 = new object[0];
        object[] treeArray_29 = new object[0];
        object[] treeArray_32 = new object[0];
        object[] treeArray_35 = new object[0];
        object[] treeArray_36 = new object[0];
        object[] treeArray_37 = new object[0];
        FormulaEditor.ObjectFormulaTree currentTree = null;
        object[] currentArray = null;
        double doubleValue = 0;
        FormulaEditor.ObjectFormulaTree[] trees = null;
        double var_0 = 0;
        double var_1 = 0;
        double var_2 = 0;
        double var_3 = 0;
        double var_4 = 0;
        double var_5 = 0;
        double var_6 = 0;
        double var_7 = 0;
        double var_8 = 0;
        double var_9 = 0;
        double var_10 = 0;
        double var_11 = 0;
        double var_12 = 0;
        double var_13 = 0;
        double var_14 = 0;
        double var_15 = 0;
        double var_16 = 0;
        double var_17 = 0;
        double var_18 = 0;
        double var_19 = 0;
        double var_20 = 0;
        double var_21 = 0;
        double var_22 = 0;
        double var_23 = 0;
        double var_24 = 0;
        double var_25 = 0;
        double var_26 = 0;
        double var_27 = 0;
        double var_28 = 0;
        double var_29 = 0;
        double var_30 = 0;
        double var_31 = 0;
        double var_32 = 0;
        double var_33 = 0;
        double var_34 = 0;
        double var_35 = 0;
        double var_36 = 0;
        double var_37 = 0;

        object Get_16()
        {
            return var_16;
        }

        object Get_28()
        {
            return var_28;
        }

        object Get_34()
        {
            return var_34;
        }

        object Get_35()
        {
            return var_35;
        }

        object Get_36()
        {
            return var_36;
        }

        object Get_37()
        {
            return var_37;
        }

        BaseTypes.ObjectAction checkValue;

    }
}
*/

