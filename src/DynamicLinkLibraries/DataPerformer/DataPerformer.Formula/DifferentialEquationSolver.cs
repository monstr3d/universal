﻿using System;
using System.Collections.Generic;
using System.Collections;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI.Aliases;

using BaseTypes.Interfaces;

using FormulaEditor;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

using DataPerformer.Formula.Interfaces;
using ErrorHandler;
using NamedTree;

namespace DataPerformer.Formula
{
    /// <summary>
    /// Solver of ordinary differential equations system
    /// </summary>
    public class DifferentialEquationSolver : DataConsumerMeasurements, 
        IDifferentialEquationSolver, 
        IStarted,  ICheckCorrectness, IVariableDetector,
        IDynamical, ITreeCollection, ITimeVariable, IStack, 
        IRuntimeUpdate, IPostSetArrow
    {

        #region Fields


        internal Dictionary<object, object> Hpars;

        internal Dictionary<object, object> Haliases;

        DataPerformerFormula dataPerformerFormula;

        /// <summary>
        /// Input dynamical parameter
        /// </summary>
    //    private Formula.DynamicalParameter par;

        /// <summary>
        /// Table of variables of equations. Table contains initial values and derivations of variables
        /// </summary>
        protected Dictionary<object, object> variables = new ();

        /// <summary>
        /// Table representation of input parameters
        /// </summary>
        new private Dictionary<char, VariableMeasurement> parameters = new ();


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
        /// Operation table
        /// </summary>
        protected Dictionary<int, IOperationAcceptor> opTable;

        /// <summary>
        /// Table representation of variables
        /// </summary>
        protected Dictionary<object, object> vars = new ();

        /// <summary>
        /// Table representation of parameters
        /// </summary>
        protected Dictionary<object, object> pars = new ();

        /// <summary>
        /// Table of aliases
        /// </summary>
        protected Dictionary<object, object> aliases = new ();

        /// <summary>
        /// Table of aliases names
        /// </summary>
        protected Dictionary<object, object> aliasNames = new ();

        /// <summary>
        /// Table of external aliases
        /// </summary>
        private Dictionary<Variable, AliasName> externalAliases = new ();

        /// <summary>
        /// List of variables
        /// </summary>
        private List<Variable> varlist = new ();


        protected List<string> variabelstr = new ();




        /// <summary>
        /// Dictionary of acceptors
        /// </summary>
        private Dictionary<string, IOperationAcceptor> acc = new ();

        /// <summary>
        /// Formula creator
        /// </summary>
        private IFormulaObjectCreator creator;


        /// <summary>
        /// Start preparation
        /// </summary>
        private Action prepareStart;

        /// <summary>
        /// Measurements
        /// </summary>
        private List<IMeasurement> formulas = new ();


        private List<FormulaMeasurement> fom = new ();

        /// <summary>
        /// Time variable
        /// </summary>
        private VariableMeasurement timeVariable;

        /// <summary>
        /// Orders of derivations
        /// </summary>
        protected Dictionary<string, int> deriOrders = new ();

        /// <summary>
        /// Proxy factory
        /// </summary>
        protected ITreeCollectionProxyFactory proxyFactory = null;

        private double[] outputD;


        private List<object> args = new ();

        ITreeCollectionProxy proxy;

        #endregion

        #region Constructors

        /// <summary>
        /// Consructor
        /// </summary>
        public DifferentialEquationSolver()
        {
            dataPerformerFormula = new(this);
            proxyFactory = StaticExtensionDataPerformerFormula.CreatorFactory(this);
            init();
            vars = new Dictionary<object, object>();
            pars = new Dictionary<object, object>();
            aliases = new Dictionary<object, object>();
            creator = VariableDetector.GetCreator(this);
        }



        #endregion

        #region Members

        #region Public Memmbers

        /// <summary>
        /// Gets formula
        /// </summary>
        /// <param name="i">Number of the formula</param>
        /// <returns>The formula</returns>
        public string GetFormula(int i)
        {
            return formulaString[i];
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
        void IDifferentialEquationSolver.CopyVariablesToSolver(int offset, double[] variables)
        {
            int i = offset;
            foreach (Variable v in output)
            {
                v.Value = variables[i];
                ++i;
            }
        }

        /// <summary>
        /// Calculates derivations
        /// </summary>
        void IDifferentialEquationSolver.CalculateDerivations()
        {
            try
            {
                foreach (Variable v in externalAliases.Keys)
                {
                    AliasName an = externalAliases[v];
                    IMeasurement m = v;
                    var p = m.Parameter;
                    var value = p();
                    if (value == null)
                    {

                    }
                    an.SetValue(value);
                }
                foreach (IMeasurements m in Dependent)
                {
                    m.IsUpdated = false;
                    m.UpdateMeasurements();
                }
                update();
            }
            catch (Exception e)
            {
                e.HandleException();
            }
        }

        /// <summary>
        /// Table of external aliases
        /// </summary>
        public Dictionary<object, object> ExternalAliases
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
        new public int DerivationOrder
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
        /// Arguments of equations
        /// </summary>
        public override List<string> Arguments
        {
            get
            {
                if (pars.Count != arguments.Count)
                {
                    arguments.Clear();
                    foreach (char c in pars.Keys)
                    {
                        arguments.Add(c + " = " + pars[c]);
                    }
                }
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
        public override string AllVariables
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
            double a = 0;
            string var = AllVariables;
            Dictionary<object, object> table = new Dictionary<object, object>();
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
            List<object> l = new List<object>(variables.Keys);
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
                v.SetTree(t, ne, aa, formulas, this);
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
        public override string InputParameters
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
            VariableMeasurement v = dataPerformerFormula.Create(c, m, this, this);
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

        /// <summary>
        /// Clears set of variables
        /// </summary>
        public void ClearVariables()
        {
            variables.Clear();
            vars.Clear();
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// The operation that performs after arrows setting
        /// </summary>
        protected virtual void PostSetArrowProtected()
        {
            postDeserialize();
            postSetAlias();
            isSerialized = true;
            foreach (IMeasurements measurements in measurementsData)
            {
                string name = this.GetMeasurementsName(measurements);
                for (int i = 0; i < measurements.Count; i++)
                {
                    IMeasurement measure = measurements[i];
                    string p = name + "." + measure.Name;
                    List<string> arg = new List<string>(arguments);
                    foreach (string s in arg)
                    {
                        string ss = s.Substring(4);
                        //!!!TEMP====================
                        bool b = ss.Equals(p);
                        if (!b)
                        {
                            if (ss.Replace("/", "_").Equals(p))
                            {
                                arguments.Remove(s);
                                arguments.Add(s.Substring(0, 4) + p);
                                b = true;
                            }
                        }
                        if (b)
                        //!!!TEMP ===
                        {
                            char c = s[0];
                            //                           parameter.Add(c, measure);
                            string key = c + "";
                            if (!acc.ContainsKey(key))
                            {
                                acc[c + ""] = dataPerformerFormula.Create(c, measure, this, this);
                            }
                        }
                    }
                }
                isSerialized = false;
            }

        }

        /// <summary>
        /// Performs operations after deserialization
        /// </summary>
        protected virtual void postDeserialize()
        {
            Hpars = new Dictionary<object, object>(pars);
            Haliases = new Dictionary<object, object>(aliases);
            //      Harguments = new Dictionary<object, object>(arguments);
            foreach (string s in args)
            {
                arguments.Add(s);
            }
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
            var fl = new List<string>();
            foreach (char c in vars.Keys)
            {
                object[] o = vars[c] as object[];
                string st = o[0] as string;
                fl.Add(st);
                MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, st);
                string s = ElementaryObjectDetector.GetVariables(f);
            }
            formulaString = fl.ToArray();
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
            Dictionary<object, object> table = new Dictionary<object, object>();
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
                        if (parameters.ContainsKey(c))
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
                            if (!acc.ContainsKey(c + ""))
                            {
                                acc[c + ""] = dataPerformerFormula.Create(c, m, this, this);
                            }
                        }
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
                        acc[s] = new Variable(s, aa, this);
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
            List<object> l = new List<object>(variables.Keys);
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
                v.SetTree(t, ne, aa, formulas, this);
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
                proxy = proxyFactory.CreateProxy(this, StaticExtensionFormulaEditor.CheckValue);
                // PROXY UPDATE
                update = proxy.Update;
                FormulaMeasurement.Set(formulas, proxy);
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
        }

 
        #endregion

        #region Private Members

        int VariablesCount
        {
            get
            {
                IMeasurements m = this;
                return m.Count;
            }
        }

        // !!! MAY BE DELETE !!!
        private void SetParameter()
        {
            DynamicalParameter parameter = new DynamicalParameter();
            foreach (IMeasurements measurements in measurementsData)
            {
                string name = this.GetMeasurementsName(measurements);
                for (int i = 0; i < measurements.Count; i++)
                {
                    IMeasurement measure = measurements[i];
                    string p = name + "." + measure.Name;
                    List<string> arg = new List<string>(arguments);
                    foreach (string s in arg)
                    {
                        string ss = s.Substring(4);
                        //!!!TEMP====================
                        bool b = ss.Equals(p);
                        if (!b)
                        {
                            if (ss.Replace("/", "_").Equals(p))
                            {
                                arguments.Remove(s);
                                arguments.Add(s.Substring(0, 4) + p);
                                b = true;
                            }
                        }
                        if (b)
                        //!!!TEMP ===
                        {
                            char c = s[0];
                            parameter.Add(c, measure);
                            string key = c + "";
                            if (!acc.ContainsKey(key))
                            {
                                acc[c + ""] = dataPerformerFormula.Create(c, measure, this, this);
                            }
                        }
                    }
                }
            }
            timeVariable = null;
            IMeasurement timeMeasurement =
                StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement;
            foreach (string s in arguments)
            {
                if (s.Substring(4).Equals("Time"))
                {
                    //timeChar = s[0];
                    // parameter.Add(s[0], timeMeasure);
                    string key = s[0] + "";
                    if (!acc.ContainsKey(key))
                    {
                        timeVariable = dataPerformerFormula.Create(s[0], timeMeasurement, this, this);
                        acc[key] = timeVariable;
                    }
                }
            }
        }

        /// <summary>
        /// Accepts measurements
        /// </summary>
        private void acceptMeasurements()
        {
            timeVariable = null;
            Portable.DynamicalParameter parameter = new Portable.DynamicalParameter();
            parameters.Clear();
            foreach (IMeasurements measurements in measurementsData)
            {
                string name = this.GetMeasurementsName(measurements);
                for (int i = 0; i < measurements.Count; i++)
                {
                    IMeasurement measurement = measurements[i];
                    string p = name + "." + measurement.Name;
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
                            parameter.Add(c, measurement);
                            if (!acc.ContainsKey(c + ""))
                            {
                                var vm = dataPerformerFormula.Create(c, measurement, this, this);
                                parameters[c] = vm;
                                acc[c + ""] = vm;
                            }
                        }
                    }
                }
            }
            foreach (string s in arguments)
            {
                if (s.Substring(s.Length - 4).Equals("Time"))
                {
                    var tp = StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement;
                    timeVariable = dataPerformerFormula.Create(s[0], tp, this, this);
                    if (timeVariable is IOperationAcceptor acceptor)
                    {
                        if (!acc.ContainsKey(s[0] + ""))
                        {
                            acc[s[0] + ""] = acceptor;
                        }
                    }
                    parameters[s[0]] = timeVariable;
                }
            }
            foreach (char c in pars.Keys)
            {
                if (!parameters.ContainsKey(c))
                {
                    if (pars[c] != null)
                    {
                        /*!!!   this.Throw(new Exception(PureDesktop.GetResourceString(VectorFormulaConsumer.ExternalParameter_) +
                               c + PureDesktop.GetResourceString(VectorFormulaConsumer._IsNotDefined)));
                       */
                    }
                }
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
            Variable v = new Variable(str, aa, this);
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

        #endregion

        #region IMeasurements Members


        protected override IEnumerable<IMeasurement> Children => output;

        /// <summary>
        /// Updates measurements data
        /// </summary>
        protected override void UpdateMeasurements()
        {
            if (IsUpdated)
            {
                return;
            }
            try
            {
                //!!! UpdateChildrenData();
               // CalculateDerivations();
                isUpdated = true;
            }
            catch (Exception e)
            {
                e.HandleException(10);
                this.Throw(e);
            }
        }


        protected override int MeasurementsCount
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

        protected override IMeasurement GetMeasurement(int n)
        {
            return output[n];
        }
  

    

        #endregion

        #region IAlias Members

        /// <summary>
        /// Names of aliases
        /// </summary>
        public override IList<string> AliasNames
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
        public override object this[string alias]
        {
            get
            {
                return aliases[alias];
            }
            set
            {
                char c = alias[0];
                aliases[alias] = value;
                if (variables.ContainsKey(c))
                {
                    SetValue(c, value);
                }
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
                return  FormulaMeasurement.GetTrees(fom.ToArray());
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
            if (output == null) return;
            foreach (IStack s in output)
            {
                s.Push();
            }
        }

        void IStack.Pop()
        {
            if (output == null) return;
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

        #region IStarted Members

        /// <summary>
        /// Starts this object
        /// </summary>
        void IStarted.Start(double time)
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
                e.HandleException(10);
                this.Throw(e);
            }
        }

        #endregion

        #region IPostSetArrow

        void IPostSetArrow.PostSetArrow()
        {
            var s = ToString();
            PostSetArrowProtected();
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Time measure
        /// </summary>
        protected override IMeasurement TimeMeasurement
        {
            get
            {
                var m =  base.TimeMeasurement;
                if (m != null)
                {
                    return m;
                }
                return dataPerformerFormula.GetTimeMeasurement(this);
            }
            set
            {
                dataPerformerFormula.Set(value, this);
                base.TimeMeasurement = value;
            }
        }

        /// <summary>
        /// Table of operations
        /// </summary>
        protected override Dictionary<int, ICategoryObject> InternalOperationTable
        {
            get
            {
                Dictionary<int, ICategoryObject> t = new Dictionary<int, ICategoryObject>();
                foreach (ICategoryObject o in operations)
                {
                    IObjectLabel l = o.Object as IObjectLabel;
                    string name = this.GetRelativeName(o);//l.Name;
                    if (!operationNames.ContainsValue(name))
                    {
                        continue;
                    }
                    foreach (int i in operationNames.Keys)
                    {
                        if (name.Equals(operationNames[i]))
                        {
                            t[i] = o;
                            break;
                        }
                    }
                }
                return t;
            }
        }




        /// <summary>
        /// The input dynamical parameter
        /// </summary>
        public override Portable.DynamicalParameter Parameter
        {
            set
            {
                par = value;
                proxy = null;
                if (!isSerialized)
                {
                    acc.Clear();
                    foreach (char c in par.Variables)
                    {
                        string key = c + "";
                        if (!acc.ContainsKey(key))
                        {
                            VariableMeasurement v = c.Create(par[c], this, this);
                            acc[key] = v;
                        }
                    }
                }
                int n = VariablesCount;
                measurements = new FormulaMeasurement[n];
                result = new object[n, 2];
                if (!isSerialized)
                {
                    arguments.Clear();
                }
                object ops = InternalOperationTable;
                if (!isSerialized)
                {
                    ops = opTable;
                }
                isSerialized = false;
                Dictionary<char, object> table = new Dictionary<char, object>();
                string var = par.Variables;
                Double a = 0;
                if (allVariables == null)
                {
                    allVariables = AllVariables;
                }
                foreach (char c in allVariables)
                {
                    table[c] = a;
                }
                string proh = "";
                foreach (char c in var)
                {
                    IMeasurement m = par[c];
                    object t = m.Type;
                    if (t is IOneVariableFunction | t is Table2D | t is Table3D)
                    {
                        proh += c;
                        table[c] = m.Parameter();
                    }
                    else
                    {
                        table[c] = t;
                    }
                }
                foreach (var s in parameters.Keys)
                {
                    object o = parameters[s];
                    table[s] = AliasTypeDetector.Detector.DetectType(o);
                    if (!acc.ContainsKey(s + ""))
                    {
                        acc[s + ""] = new AliasNameVariable(s + "", this, s + "");
                    }
                }
                AssociatedAddition aa = new AssociatedAddition(this, null);
                var l = new List<object>(variables.Keys);
                l.Sort();
                for (int i = 0; i < n; i++)
                {
                    var c = l[i];
                    object[] oo = variables[c] as object[];
                    MathFormula f = (variables[c] as object[])[1] as MathFormula;
                    Dictionary<int, IOperationAcceptor> dop = new Dictionary<int, IOperationAcceptor>();
                    if (ops is Dictionary<int, IOperationAcceptor>)
                    {
                        dop = ops as Dictionary<int, IOperationAcceptor>;
                    }
                    SeriesSymbol.SetOperations(f, dop);
                    try
                    {
                        if (creator == null)
                        {
                            creator = VariableDetector.GetCreator(this);
                        }
                        ObjectFormulaTree t = oo[2] as ObjectFormulaTree;
                        if (t == null)
                        {
                            t = ObjectFormulaTree.CreateTree(f, creator);
                            oo[2] = t;
                        }
                        measurements[i] = FormulaMeasurement.Create(t, deriOrder, Formula_ + (i + 1), aa, this);
                    }
                    catch (Exception ex)
                    {
                        ex.HandleException(10);
                        if (ex.Message.Equals("VariableMeasure.Derivation"))
                        {
                            throw ex;
                        }
                        throw new Exception("Formula " + (i + 1) + " : " + ex.Message);
                    }
                }
                try
                {
                    proxy = null;
                    proxy = proxyFactory.CreateProxy(this, StaticExtensionFormulaEditor.CheckValue);
                    update = proxy.Update;
                    FormulaMeasurement.Set(measurements, proxy);
                    foreach (string key in replacement.Keys)
                    {
                        string varp = key[0] + "";
                        if (!acc.ContainsKey(varp))
                        {
                            continue;
                        }
                        object o = acc[varp];
                        if (!(o is VariableMeasurement))
                        {
                            continue;
                        }
                        VariableMeasurement vm = o as VariableMeasurement;
                        string name = key.Substring(4);
                        foreach (IMeasurements mea in measurementsData)
                        {
                            string sn = this.GetRelativeName(mea as IAssociatedObject);
                            for (int i = 0; i < mea.Count; i++)
                            {
                                IMeasurement mm = mea[i];
                                string snn = sn + "." + mm.Name;
                                if (snn.Equals(name))
                                {
                                    vm.SetMeasurement(mm);
                                    goto me;
                                }
                            }
                        }
                    me:
                        continue;
                    }
                    SetFeedback();
                }
                catch (Exception ex)
                {
                    ex.HandleException(-1);
                }
            }
        }

        /// <summary>
        /// Variables
        /// </summary>
        public override string Variables
        {
            get
            {
                string s = "";
                foreach(var c in vars.Keys)
                {
                    s += c;
                }
                return s;
            }
        }

        internal Dictionary<object, object> VariableValues => vars;



        #endregion

        #region Classes & Delegates

        class Variable : IObjectOperation, 
            IPowered, IOperationAcceptor, IMeasurement, IDerivation, 
            IDerivationOperation, IStack, IMeasurementHolder, IAssociatedObject
        {

            #region Fields

            private Stack<double> stack = new Stack<double>();

            const double a = 0;

            double value;

            FormulaMeasurement derivation;

            FormulaMeasurementDerivation temp;

            ObjectFormulaTree tree;

            Func<object> parameter;


            private string symbol;

            protected AssociatedAddition addition;

            DifferentialEquationSolver equationSolver;

            #endregion

            #region Ctor

            internal Variable(string symbol, AssociatedAddition addition, DifferentialEquationSolver equationSolver)
            {
                this.symbol = symbol;
                parameter = GetValue;
                this.addition = addition;
                this.equationSolver = equationSolver;

            }

            #endregion

            #region IAssociatedObject Members

            object IAssociatedObject.Object
            {
                get => equationSolver;
                set { }
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
                get => derivation;
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
                get { return parameter; }
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

            public override string ToString()
            {
                return equationSolver.ToString() +  base.ToString();
            }


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
                IList<IMeasurement> list, object obj)
            {
                string dn = "D" + symbol;
                this.tree = tree;
                IDistribution d = DeltaFunction.GetDistribution(tree);
                if (next)
                {
                    if (d != null)
                    {
                        temp = new FormulaMeasurementDerivationDistribution(tree, null, symbol, addition, obj);
                    }
                    else
                    {
                        temp = new FormulaMeasurementDerivation(tree, null, symbol, addition, obj);
                    }
                    derivation = temp;
                    list.Add(derivation);
                    return;
                }
                if (d != null)
                {
                    derivation = new FormulaMeasurementDistribution(tree, symbol, addition, obj);
                }
                else
                {
                    derivation = new FormulaMeasurement(tree, symbol, addition, obj);
                }
                list.Add(derivation);
                return;
            }

            internal void Iterate(bool next)
            {
                AssociatedAddition aa = FormulaMeasurementDerivation.Create(addition);
                temp = temp.Iterate(next, aa, equationSolver);
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

            #region IMeasurementHolder Members

            IMeasurement IMeasurementHolder.Measurement => this;

            #endregion

        }

        #endregion

    }
}
