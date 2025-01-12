using System;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI.Aliases;
using Diagram.Interfaces;

using FormulaEditor;
using FormulaEditor.Symbols;
using FormulaEditor.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

using DataPerformer.Formula.Interfaces;

namespace DataPerformer.Formula
{
	/// <summary>
	/// Recurrent object
	/// </summary>
	public class Recursive : CategoryObject,  IDataConsumer, IMeasurements, IStarted, IRunning, IAlias,
		ICheckCorrectness, IStep, IRuntimeUpdate, ITimeMeasurementConsumer, 
		IVariableDetector, ITreeCollection,	ITimeVariable, IPostSetArrow
	{

        #region Fields

 
        /// <summary>
        /// Ordered variables
        /// </summary>
        protected List<char> varc = new List<char>();

		/// <summary>
		/// The "is running" sign
		/// </summary>
		protected bool isRunning = false;

		/// <summary>
		/// Internal variables
		/// </summary>
		protected Dictionary<object,object> variables = new Dictionary<object, object>();

		/// <summary>
		/// Aliases
		/// </summary>
		protected Dictionary<object, object> aliases = new Dictionary<object, object>();

		/// <summary>
		/// Temporary aliases
		/// </summary>
		protected Dictionary<object, object> tempAliases = new Dictionary<object, object>();

        /// <summary>
        /// String representation of internal variables
        /// </summary>
        protected Dictionary<object, object> vars = new Dictionary<object, object>();

		/// <summary>
		/// String representation of external parameters
		/// </summary>
		protected Dictionary<object, object> pars = new Dictionary<object, object>();

		/// <summary>
		/// String represntation of external aliases
		/// </summary>
		protected Dictionary<object, object> externalAls = new Dictionary<object, object>();

		/// <summary>
		/// External aliases
		/// </summary>
		private Dictionary<object, object> externalAliases = new Dictionary<object, object>();

		/// <summary>
		/// The "is updated" sign
		/// </summary>
		protected bool isUpdated = false;


		/// <summary>
		/// Number of step
		/// </summary>
		protected long step;

		/// <summary>
		/// Number of old step
		/// </summary>
		protected long oldStep;


		/// <summary>
		/// Change input event
		/// </summary>
		private event Action onChangeInput = () => { };

		/// <summary>
		/// External parameters
		/// </summary>
		private Dictionary<char, IMeasurement> parameters = new Dictionary<char, IMeasurement>();


		/// <summary>
		/// Output measurements
		/// </summary>
		private IList<IMeasurement> output = new List<IMeasurement>();

		/// <summary>
		/// Data links
		/// </summary>
		private List<IMeasurements> measurements = new List<IMeasurements>();

		/// <summary>
		/// Trees
		/// </summary>
		private ObjectFormulaTree[] trees;
		
		/// <summary>
		/// Time variable
		/// </summary>
		private VariableMeasurement timeVariable;

		/// <summary>
		/// Dictionary of acceptors
		/// </summary>
		private Dictionary<string, IOperationAcceptor> acc = new Dictionary<string, IOperationAcceptor>();

		/// <summary>
		/// Proxy
		/// </summary>
		protected ITreeCollectionProxy proxy;

		/// <summary>
		/// Proxy factory
		/// </summary>
		protected ITreeCollectionProxyFactory proxyFactory = null;

		/// <summary>
		/// Update
		/// </summary>
		protected Action update;

		/// <summary>
		/// Dictionary of formulas
		/// </summary>
		protected Dictionary<char, FormulaMeasurement> dictF;

		/// <summary>
		/// Change alias event
		/// </summary>
		event Action<IAlias, string> onChange = (IAlias a, string name) => { };

		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public Recursive()
		{
			proxyFactory = StaticExtensionDataPerformerFormula.CreatorFactory(this);
            update = UpdateFormulas;
		}

        #endregion

        #region IDataConsumer Members

        /// <summary>
        /// Adds measurements provider 
        /// </summary>
        /// <param name="m">Provider to add</param>
        public void Add(IMeasurements m)
		{
			measurements.Add(m);
		}


		/// <summary>
		/// Removes measurements provider
		/// </summary>
		/// <param name="m">Provider to remove</param>
		public void Remove(IMeasurements m)
		{
			measurements.Remove(m);
		}

		/// <summary>
		/// Updates data of data providers
		/// </summary>
		public void UpdateChildrenData()
		{
			foreach (IMeasurements m in measurements)
			{
				m.UpdateMeasurements();
			}
		}

		int IDataConsumer.Count
		{
			get
			{
				return measurements.Count;
			}
		}

		/// <summary>
		/// Access to n - th provider
		/// </summary>
		public IMeasurements this[int n]
		{
			get
			{
				return measurements[n];
			}
		}

		/// <summary>
		/// Resets measurements
		/// </summary>
		public void Reset()
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

		IMeasurement IMeasurements.this[int n]
		{
			get
			{
				return output[n];
			}
		}

		void IMeasurements.UpdateMeasurements()
		{
			if (IsUpdated)
			{
				return;
			}
			try
			{
				foreach (char c in externalAliases.Keys)
				{
					object[] o = externalAliases[c] as object[];
					IAlias al = o[0] as IAlias;
					string key = o[1] as string;
					object[] ob = variables[c] as object[];
					al[key] = ob[0];
				}
				UpdateChildrenData();
				update();
				foreach (char c in varc)
				{
					object[] o = variables[c] as object[];
					o[0] = o[3];
				}
				isUpdated = true;
			}
			catch (Exception e)
			{
				e.ShowError(10);
				this.Throw(e);
			}
		}



		/// <summary>
		/// Shows, wreather the object is updated
		/// </summary>
		public bool IsUpdated
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

		int IMeasurements.Count
		{
			get
			{
				return output.Count;
			}
		}

        #endregion

        #region IStarted Members

        /// <summary>
        /// Starts this object
        /// </summary>
        /// <param name="time">Start time</param>
        void IStarted.Start(double time)
        {
            Start(true);
        }

        #endregion

        #region IRunning Members

        /// <summary>
		/// The "is running" sign
		/// </summary>
        bool IRunning.IsRunning
        {
			get => isRunning;
			set
			{
				isRunning = value;
				Start(value);
				running?.Invoke(this, value);
			}
        }

        Action<IRunning, bool> running;

        event Action<IRunning, bool> IRunning.Running
        {
            add
            {
                running += value;
            }

            remove
            {
                running -= value;
            }
        }


        #endregion

        #region IAlias Members

        /// <summary>
        /// List of alias names
        /// </summary>
        public IList<string> AliasNames
		{
			get
			{
				List<string> list = new List<string>();
				foreach (char c in aliases.Keys)
				{
					list.Add(c + "");
				}
				foreach (char c in varc)
				{
					list.Add(c + "");
				}
				return list;
			}
		}

		object IAlias.this[string alias]
		{
			get
			{
				if (aliases.ContainsKey(alias[0]))
				{
					return aliases[alias[0]];
				}
				object[] o = vars[alias[0]] as object[];
				return o[2];
			}
			set
			{
				if (aliases.ContainsKey(alias[0]))
				{
					aliases[alias[0]] = value;
					return;
				}
				object[] o = vars[alias[0]] as object[];
				o[2] = value;
			}
		}

		/// <summary>
		/// Gets object type
		/// </summary>
		/// <param name="name">Object name</param>
		/// <returns>Returns type of alias object</returns>
		public object GetType(string name)
		{
			IAlias al = this;
			return AliasTypeDetector.Detector.DetectType(al[name]);
		}

		event Action<IAlias, string> IAlias.OnChange
		{
			add { onChange += value; }
			remove { onChange -= value; }
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
				PostSetArrow();
			}
			catch (Exception e)
			{
				e.ShowError(10);
				this.Throw(e);
			}
		}

		#endregion

		#region IStep Members

		/// <summary>
		/// Step
		/// </summary>
		public long Step
		{
			get
			{
				return step;
			}
			set
			{
				step = value;
			}
		}

		#endregion

		#region ITimeMeasureConsumer Members

		IMeasurement ITimeMeasurementConsumer.Time
		{
			get
			{
				return this.GetTimeMeasurement();
			}
			set
			{
				value.Set(this);
			}
		}

		#endregion

		#region IVariableDetector Members

		IOperationAcceptor IVariableDetector.Detect(MathSymbol sym)
		{
			return VariableDetector.Detect(sym, acc);
		}

		#endregion

		#region ITreeCollection Members

		ObjectFormulaTree[] ITreeCollection.Trees
		{
			get { return trees; }
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
			get { return null; }
		}

		#endregion

		#region IRuntimeUpdate Members

		bool IRuntimeUpdate.ShouldRuntimeUpdate
		{
			get { return true; }
			set { }
		}

		#endregion

		#region IPostSetArrow Members

		/// <summary>
		/// The operation that performs after arrows setting
		/// </summary>
		public virtual void PostSetArrow()
		{
			if (varc.Count == 0)
			{
				Order();
			}
			acceptParameters();
			AcceptFormulas();
			ExternalAliases = externalAls;
			CreateProxyInternal();
		}
		#endregion

		#region Specific Members

		/// <summary>
		/// Name of source
		/// </summary>
		public string SourceName
		{
			get
			{
				IObjectLabel lab = Object as IObjectLabel;
				return lab.Name;
			}
		}

		/// <summary>
		/// String representation of internal variables
		/// </summary>
		public Dictionary<object, object> Variables
		{
			get
			{
				return vars;
			}
			set
			{
				vars = value;
				Order();
			}
		}

		/// <summary>
		/// Recursive formulas
		/// </summary>
		public Dictionary<object, object> Formulas
		{
			set
			{
				foreach (char c in value.Keys)
				{
					if (!vars.ContainsKey(c))
					{
						throw new Exception("Shortage of variables");
					}
				}
				foreach (char c in varc)
				{
					if (!value.ContainsKey(c))
					{
						throw new Exception("Shortage of formulas");
					}
				}
				foreach (char c in value.Keys)
				{
					object[] o = vars[c] as object[];
					o[1] = value[c];
				}
			}
		}

		/// <summary>
		/// All variabes those are not internal
		/// </summary>
		public string AllExternalVariables
		{
			get
			{
				string s = "";
				foreach (object[] o in vars.Values)
				{
					string f = o[1] as string;
					if (f == null)
					{
						continue;
					}
					MathFormula form = MathFormula.FromString(MathSymbolFactory.Sizes, f);
					string v = ElementaryObjectDetector.GetVariables(form);
					foreach (char c in v)
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
		/// String of alias parameters
		/// </summary>
		public string AliasesString
		{
			set
			{
				aliases.Clear();
				foreach (char c in value)
				{
					aliases[c] = new object[2];
				}
				string str = AllExternalVariables;
				pars.Clear();
				parameters.Clear();
				foreach (char c in str)
				{
					if (vars.ContainsKey(c))
					{
						continue;
					}
					if (aliases.ContainsKey(c))
					{
						continue;
					}
					object[] o = new object[3];
					pars[c] = o;
				}
				double a = 0;
				IAlias al = this;
				foreach (char c in value)
				{
					al[c + ""] = a;
				}
			}
			get
			{
				string s = "";
				foreach (char c in aliases.Keys)
				{
					s += c;
				}
				return s;
			}
		}

		/// <summary>
		/// Dynalical parameter
		/// </summary>
		public Formula.DynamicalParameter Parameter
		{
			set
			{
				string s = value.Variables;
				parameters.Clear();
				foreach (char c in s)
				{
					parameters[c] = value[c];
				}
			}
		}

		/// <summary>
		/// External arguments table
		/// </summary>
		public Dictionary<object, object> Arguments
		{
			get
			{
				return pars;
			}
			set
			{
				string str = AllExternalVariables;
				string s = "";
				foreach (char c in str)
				{
					if (vars.ContainsKey(c))
					{
						continue;
					}
					if (aliases.ContainsKey(c))
					{
						continue;
					}
					s += c;
				}
				foreach (char c in s)
				{
					if (!value.ContainsKey(c))
					{
						throw new Exception(DataConsumer.VariablesShortage + " : " + c);
					}
				}
				pars = value;
				acceptParameters();
				AcceptFormulas();
			}
		}

		/// <summary>
		/// External arguments table
		/// </summary>
		public List<object> ExternalArguments
		{
			get
			{
				List<object> list = new List<object>();
				foreach (char c in pars.Keys)
				{
					string s = pars[c] as string;
					list.Add(c + " = " + s);
				}
				return list;
			}
		}

		/// <summary>
		/// Ordered variables
		/// </summary>
		public List<char> OrderedVariables
		{
			get => varc;
		}

		/// <summary>
		/// External aliases table
		/// </summary>
		public Dictionary<object, object> ExternalAliases
		{
			get
			{
				return externalAls;
			}
			set
			{
				externalAls = value;
				externalAliases.Clear();
				foreach (char c in externalAls.Keys)
				{
					string s = externalAls[c] as string;
					object[] o = this.FindAlias(s);
					externalAliases[c] = o;
				}
			}
		}

        #endregion

        #region Protected Members

		/// <summary>
		/// Orders variables
		/// </summary>
		protected void Order()
		{
			varc.Clear();
			foreach(char c in vars.Keys)
			{
				varc.Add(c);
			}
			varc.Sort();
		}

        /// <summary>
        /// Accepts formulas
        /// </summary>
        protected void AcceptFormulas()
        {
            output.Clear();
            acc.Clear();
            foreach (char c in varc)
            {
                Variable v;
                output.Add(Variable.GetMeasure(c, this, out v));
                acc[c + ""] = v;
            }
            foreach (char c in parameters.Keys)
            {
                IMeasurement m = parameters[c] as IMeasurement;
                VariableMeasurement v = c.Create(m, this, this);
                acc[c + ""] = v;
            }
            foreach (char c in aliases.Keys)
            {
                AliasNameVariable v = new AliasNameVariable(c, this);
                acc[c + ""] = v;
                object[] o = aliases[c] as object[];
            }
            IAlias al = this;
            IList<string> l = al.AliasNames;
            foreach (string n in l)
            {
                if (n.Length == 1)
                {
                }
            }
            IFormulaObjectCreator creator = VariableDetector.GetCreator(this);
            variables.Clear();
            foreach (char c in varc)
            {
                variables[c] = new object[4];
            }
            IList<string> an = AliasNames;
            List<ObjectFormulaTree> tt = new List<ObjectFormulaTree>();
            string proh = "\u03B4";
            foreach (char c in parameters.Keys)
            {
                IMeasurement m = parameters[c];
                if (m.Type is IOneVariableFunction)
                {
                    proh += c;
                }
            }
            foreach (char c in varc)
            {
                object t = null;
                object[] os = vars[c] as object[];
                if (an.Contains(c + ""))
                {
                    t = GetType(c + "");
                }
                else
                {
                    t = os[2];
                }
                if (t is IOneVariableFunction)
                {
                    proh += c;
                }
            }
            foreach (char c in varc)
            {
                object[] os = vars[c] as object[];
                object t = null;
                if (an.Contains(c + ""))
                {
                    t = GetType(c + "");
                }
                else
                {
                    t = os[2];
                }
                object[] ol = variables[c] as object[];
                string f = os[1] as string;
                MathFormula form = MathFormula.FromString(MathSymbolFactory.Sizes, f);
                ObjectFormulaTree tree = ObjectFormulaTree.CreateTree(form.FullTransform(proh), creator);
                if (!t.Equals(tree.ReturnType))
                {
                    throw new Exception("Illegal return type");
                }
                ol[1] = tree;
                tt.Add(tree);
            }
            trees = tt.ToArray();
        }


        #endregion

        #region Internal Members

        internal Dictionary<object, object> Aliases => aliases;

		internal Dictionary<object, object> Pars => pars;

		#endregion

		#region Private Members

		void Start(bool stated)
		{
			if (stated)
			{
				foreach (char c in varc)
				{
					object[] o0 = vars[c] as object[];
					object[] o = variables[c] as object[];
					o[0] = o0[2];
				}
				oldStep = step;
				tempAliases.Clear();
				foreach (var alias in aliases.Keys)
				{
					tempAliases[alias] = aliases[alias];
				}
				return;
			}
            foreach (var alias in tempAliases.Keys)
            {
                aliases[alias] = tempAliases[alias];
            }


        }

        private void UpdateFormulas()
		{
			foreach (char c in varc)
			{
				object[] o = variables[c] as object[];
				ObjectFormulaTree tree = o[1] as ObjectFormulaTree;
				o[3] = tree.Result;
			}
		}

		private void CreateProxyInternal()
		{
			try
			{
				List<IMeasurement> outNew = new List<IMeasurement>();
				update = UpdateFormulas;
				proxy = null;
				proxy = proxyFactory.CreateProxy(this, StaticExtensionFormulaEditor.CheckValue);
                //int k = 0;
                dictF = new Dictionary<char, FormulaMeasurement>();
				AssociatedAddition aa = new AssociatedAddition(this, null);
				foreach (char c in varc)
				{
					object[] o = variables[c] as object[];
					ObjectFormulaTree tree = o[1] as ObjectFormulaTree;
					FormulaMeasurement fm = FormulaMeasurement.Create(tree, 0, c + "", aa, this);
					dictF[c] = fm;
					outNew.Add(fm);
				}
				List<IMeasurement> lm = new List<IMeasurement>();
				foreach (IMeasurement mm in dictF.Values)
				{
					lm.Add(mm);
				}
				FormulaMeasurement.Set(lm, proxy);
				update = UpdateProxy;
			// !!! VERY BAD	output = outNew;
			}
			catch (Exception ex)
			{
				ex.ShowError(10);
			}
		}

		private void UpdateProxy()
		{
			proxy.Update();
			foreach (char c in varc)
			{
				object[] o = variables[c] as object[];
				IMeasurement m = dictF[c];
				o[3] = m.Parameter();
			}
		}


		/// <summary>
		/// Accepts external parameters
		/// </summary>
		private void acceptParameters()
		{
			parameters.Clear();
			timeVariable = null;
			foreach (char c in pars.Keys)
			{
				string s = pars[c] as string;
				if (s.Equals("Time"))
				{
					timeVariable = c.Create(
						StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement, this, this);
					parameters[c] = timeVariable.Measurement;
					continue;
				}
				foreach (IMeasurements m in measurements)
				{
					string name = this.GetMeasurementsName(m);
					for (int i = 0; i < m.Count; i++)
					{
						IMeasurement mea = m[i];
						string str = name + "." + mea.Name;
						if (s.Equals(str))
						{
							parameters[c] = mea;
							goto next;
						}
					}
				}
			next:
				continue;
			}
		}

		#endregion

		#region Variable

		/// <summary>
		/// Auxiliary class for measurement providinf
		/// </summary>
		class Variable : IObjectOperation, IPowered, IOperationAcceptor, IMeasurement, IMeasurementHolder
		{

			#region Fields

			/// <summary>
			/// Measure key
			/// </summary>
			private char key;

			/// <summary>
			/// Parent
			/// </summary>
			private Recursive r;

			/// <summary>
			/// Type
			/// </summary>
			private object type;

			/// <summary>
			/// Name
			/// </summary>
			private string name;

			#endregion

			#region Ctor

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="key">Measure key</param>
			/// <param name="r">Parent</param>
			private Variable(char key, Recursive r)
			{
				this.key = key;
				this.r = r;
				name = key + "";
				type = r.GetType(name);
			}

			#endregion

			#region IMeasurement Members

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
				get { return type; }
			}

			#endregion

			#region IObjectOperation Members

			object[] IObjectOperation.InputTypes
			{
				get { return new object[0]; }
			}

			object IObjectOperation.this[object[] x]
			{
				get { return getValue(); }
			}

			object IObjectOperation.ReturnType
			{
				get { return r.GetType(key + ""); }
			}

			bool IPowered.IsPowered
			{
				get { return true; }
			}

			IMeasurement IMeasurementHolder.Measurement => this;

			#endregion

			#region IOperationAcceptor Members

			IObjectOperation IOperationAcceptor.Accept(object type)
			{
				return this;
			}

            #endregion

            #region Members

            public override string ToString()
            {
                return r.ToString() + base.ToString();
            }

            /// <summary>
            /// Variable measurements
            /// </summary>
            /// <param name="key">Measure key</param>
            /// <param name="r">Parent</param>
            /// <param name="v">Variable</param>
            /// <returns>The measure</returns>
            static internal IMeasurement GetMeasure(char key, Recursive r, out Variable v)
			{
				v = new Variable(key, r);
				return v;
			}

			/// <summary>
			/// Gets value of measurement
			/// </summary>
			/// <returns></returns>
			private object getValue()
			{
				object[] o = r.variables[key] as object[];
				return o[0];
			}

			/// <summary>
			/// Gets derivation
			/// </summary>
			/// <returns></returns>
			private object getDerivation()
			{
				double a = 0;
				return a;
			}


			#endregion

		}

		#endregion

	}

}
