using System;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using CategoryTheory;

using DataPerformer.Formula.Interfaces;
using DataPerformer.Interfaces;
using DataPerformer.Portable;

using Diagram.UI;
using Diagram.UI.Aliases;
using Diagram.UI.Attributes;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using FormulaEditor;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

using ErrorHandler;

using NamedTree;
using DataPerformer.Interfaces.Attributes;

namespace DataPerformer.Formula
{
    /// <summary>
    /// Recurrent object
    /// </summary>
    [CodeCreator(InitialState = true)]
    public class Recursive : CategoryObject, IDataConsumer, IMeasurements, IStarted, IRunning, IAlias,
		ICheckCorrectness, IStep, IRuntimeUpdate, ITimeMeasurementConsumer,
		IVariableDetector, ITreeCollection, ITimeVariable, IInitialDictionary,
		IStringTreeDictionary, IFeedbackCollectionHolder,
        IPostSetArrow
	{

		#region Fields



        protected IFeedbackAliasCollection feedbackAliasCollection;

        protected IInitialValueCollection initial;


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
		protected Dictionary<object, object> VariablesL
		{
			get;
		} = new Dictionary<object, object>();

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
		private List<IMeasurement> output = new List<IMeasurement>();

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
		internal ITreeCollectionProxy Proxy
		{
			get;
			set;
		}

   

        /// <summary>
        /// Proxy factory
        /// </summary>
        protected ITreeCollectionProxyFactory proxyFactory = null;

		/// <summary>
		/// Update
		/// </summary>
		protected Action Update
		{
			get;
			set;
		}

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
			feedbackAliasCollection = new  FeedbackAliasCollection(this, this, FeedBack);
            proxyFactory = StaticExtensionDataPerformerFormula.CreatorFactory(this);
			Update = UpdateFormulas;
		}

		#endregion

		#region IDataConsumer Members

		/// <summary>
		/// Adds measurements provider 
		/// </summary>
		/// <param name="m">Provider to add</param>
		void IChildren<IMeasurements>.AddChild(IMeasurements m)
		{
			measurements.Add(m);
		}

		/// <summary>
		/// Removes measurements provider
		/// </summary>
		/// <param name="m">Provider to remove</param>
		void IChildren<IMeasurements>.RemoveChild(IMeasurements m)
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
                feedbackAliasCollection.Set();
				UpdateChildrenData();
				Update();
				foreach (var x in output)
				{
					if (x is IUpdateItself updateItself)
					{
						updateItself.UpdateItself();
					}
				}
				isUpdated = true;
			}
			catch (Exception e)
			{
				e.HandleException(10);
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

		event Action<IMeasurement> IChildren<IMeasurement>.OnAdd
		{
			add
			{
			}

			remove
			{
			}
		}

		event Action<IMeasurement> IChildren<IMeasurement>.OnRemove
		{
			add
			{
			}

			remove
			{
			}
		}

		event Action<IMeasurements> IChildren<IMeasurements>.OnAdd
		{
			add
			{
			}

			remove
			{
			}
		}

		event Action<IMeasurements> IChildren<IMeasurements>.OnRemove
		{
			add
			{
			}

			remove
			{
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
				PostSetArrow();
			}
			catch (Exception e)
			{
				e.HandleException(10);
				this.Throw(e);
			}
		}

		#endregion

		#region IStep Members

		/// <summary>
		/// Step
		/// </summary>
		long IStep.Step
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
				return Proxy != null;
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

		void IPostSetArrow.PostSetArrow()
		{
			PostSetArrow();
		}

		/// <summary>
		/// The operation that performs after arrows setting
		/// </summary>
		protected virtual void PostSetArrow()
		{
			try
			{
				if (varc.Count == 0)
				{
					Order();
				}
				acceptParameters();
				AcceptFormulas();
				ExternalAliases = externalAls;
				CreateProxyInternal();
				Finish();
			}
			catch (Exception ex)
			{
				ex.HandleException();
			}
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
						throw new OwnException("Shortage of variables");
					}
				}
				foreach (char c in varc)
				{
					if (!value.ContainsKey(c))
					{
						throw new OwnException("Shortage of formulas");
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
						throw new OwnException(DataConsumer.VariablesShortage + " : " + c);
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
				FeedBack.Clear();
				foreach (char c in externalAls.Keys)
				{
					string s = externalAls[c] as string;
					FeedBack[c + ""] = s;

					object[] o = this.FindAlias(s);
					externalAliases[c] = o;
				}
				Finish();
			}
		}

        #endregion

        #region Protected Members

   
        protected virtual Dictionary<string, string>  FeedBack
		{
			get;
		} = new Dictionary<string, string>();

        /// <summary>
        /// Orders variables
        /// </summary>
        protected void Order()
		{
			varc.Clear();
			foreach (char c in vars.Keys)
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
				output.Add(Variable.GetMeasurement(c, this, out v));
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
				if (!vars.ContainsKey(c))
				{
					AliasNameVariable v = new AliasNameVariable(c, this);
					acc[c + ""] = v;
					object[] o = aliases[c] as object[];
				}
				else
				{

				}
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
			VariablesL.Clear();
			foreach (char c in varc)
			{
				VariablesL[c] = new object[4];
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
			td.Clear();
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
				object[] ol = VariablesL[c] as object[];
				string f = os[1] as string;
				MathFormula form = MathFormula.FromString(MathSymbolFactory.Sizes, f);
				ObjectFormulaTree tree = ObjectFormulaTree.CreateTree(form.FullTransform(proh), creator);
				if (!t.Equals(tree.ReturnType))
				{
					throw new OwnException("Illegal return type");
				}
				ol[1] = tree;
				tt.Add(tree);
				td[c + ""] = tree;
			}
			trees = tt.ToArray();
			Finish();
		}

		protected Dictionary<string, object> Initial
		{
			get
			{
				var d = new Dictionary<string, object>();
				foreach (var c in vars)
				{
					var k = c.Key;
					var val = c.Value as object[];
					d[c.Key + ""] = val[2];
				}
				return d;
			}
		}
	


		void Finish()
		{
			IAlias al = this;
			feedbackAliasCollection.Fill();
			initial = new AliasInitialValueCollection(this, this);
		}

		#endregion

		#region Internal Members

		internal Dictionary<object, object> Aliases => aliases;

		internal Dictionary<object, object> Pars => pars;

		IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => output;

		IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => measurements;

		Dictionary<string, object> IInitialDictionary.Dictionary => Initial;

        Dictionary<string, ObjectFormulaTree> td = new Dictionary<string, ObjectFormulaTree>();

        #endregion

        #region Private Members



        Dictionary<string, ObjectFormulaTree> IStringTreeDictionary.Dictionary => td;

		void Start(bool stated)
		{
			if (stated)
			{
				initial.Set();
				return;

				foreach (char c in varc)
				{
				}
				oldStep = step;
				tempAliases.Clear();
				foreach (var alias in aliases.Keys)
				{
					tempAliases[alias] = aliases[alias];
				}
				return;
			}
			return;
			foreach (var alias in tempAliases.Keys)
			{
				aliases[alias] = tempAliases[alias];
			}
		}

		private void UpdateFormulas()
		{
			foreach (char c in varc)
			{
				object[] o = VariablesL[c] as object[];
				ObjectFormulaTree tree = o[1] as ObjectFormulaTree;
				o[3] = tree.Result;
			}
		}

		internal Dictionary<char, ObjectFormulaTree> OutDic
		{
			get;
		} = new Dictionary<char, ObjectFormulaTree>();

        IFeedbackCollection IFeedbackCollectionHolder.Feedback => feedbackAliasCollection;

        private void CreateProxyInternal()
		{
			try
			{
				OutDic.Clear();

				List<IMeasurement> outNew = new List<IMeasurement>();
				Update = UpdateFormulas;
				Proxy = null;
				Proxy = proxyFactory.CreateProxy(this, StaticExtensionFormulaEditor.CheckValue);
				//int k = 0;
				dictF = new Dictionary<char, FormulaMeasurement>();
				AssociatedAddition aa = new AssociatedAddition(this, null);
				foreach (char c in varc)
				{
					object[] o = VariablesL[c] as object[];
					ObjectFormulaTree tree = o[1] as ObjectFormulaTree;
					OutDic.Add(c, tree);
					FormulaMeasurement fm = FormulaMeasurement.Create(tree, 0, c + "", aa, this);
					dictF[c] = fm;
					outNew.Add(fm);
				}
				List<IMeasurement> lm = new List<IMeasurement>();
				foreach (IMeasurement mm in dictF.Values)
				{
					lm.Add(mm);
				}
				FormulaMeasurement.Set(lm, Proxy);
				Update = UpdateProxy;
				Finish();
				// !!! VERY BAD	output = outNew;
			}
			catch (Exception ex)
			{
				ex.HandleException(10);
			}
		}

		private void UpdateProxy()
		{
			Proxy.Update();
			foreach (char c in varc)
			{
				object[] o = VariablesL[c] as object[];
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
			Finish();
		}

		void IChildren<IMeasurement>.AddChild(IMeasurement child)
		{
			output.Add(child);
			throw new ErrorHandler.OwnException();

		}

		void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
		{
			output.Remove(child);
		}

		#endregion

		#region Variable

		/// <summary>
		/// Auxiliary class for measurement
		/// </summary>
		[CodeCreator(InitialState = true)]
		[InternalVariable]
        internal class Variable : IObjectOperation, IPowered, IOperationAcceptor, IMeasurement, 
			IMeasurementHolder, IAliasNameHolder, ITreeAssociated, IValue, IUpdateItself, 
			IOutputTree, ITreeCreator
		{

			#region Fields

			ObjectFormulaTree tree;
	
            protected Portable.Performer performer = new Portable.Performer();

			protected Func<object> formulaGet;

	
			object GetInitial()
			{
				IOutputTree output = this;
				var t = output.Tree;
				if (Recursive.Proxy == null | t == null)
				{
					return null;
				}
				var g = Recursive.Proxy[t];
				formulaGet = g;
				var a = formulaGet();
				return a;
            }

            protected virtual ObjectFormulaTree Tree
			{
				get;
				set;
			}


			/// <summary>
			/// Measure key
			/// </summary>
			protected char key;

			/// <summary>
			/// Parent
			/// </summary>
			protected Recursive Recursive
			{
				get;
				set;
			}

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
            protected Variable(char key, Recursive r)
			{
				this.key = key;
				Recursive = r;
				name = key + "";
				type = r.GetType(name);
				formulaGet = GetInitial;
				tree = new ObjectFormulaTree(this);
			}

			#endregion

			#region IMeasurement Members

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
				get { return GetValue(); }
			}

			object IObjectOperation.ReturnType
			{
				get { return Recursive.GetType(key + ""); }
			}

			bool IPowered.IsPowered
			{
				get { return true; }
			}

			IMeasurement IMeasurementHolder.Measurement => this;

            IAliasName IAliasNameHolder.AliasName => new AliasName(Recursive, name);

            ObjectFormulaTree ITreeAssociated.ObjectFormulaTree { get => Tree; set => Tree = value; }

            object IValue.Value 
			{
				get => GetValue();
				set => SetValue(value); 
			}

            ObjectFormulaTree outTree;


            ObjectFormulaTree IOutputTree.Tree
			{
				get
				{
					if (outTree == null)
					{
                        IStringTreeDictionary dc = Recursive;
						var d = dc.Dictionary;
						if (d.ContainsKey(name))
						{
							outTree = d[name];
						}
					}
					return outTree;
				}
			}

            ObjectFormulaTree ITreeCreator.Tree => tree;


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
                return Recursive.ToString() + base.ToString();
            }

            /// <summary>
            /// Variable measurements
            /// </summary>
            /// <param name="key">Measure key</param>
            /// <param name="r">Parent</param>
            /// <param name="v">Variable</param>
            /// <returns>The measure</returns>
            static internal IMeasurement GetMeasurement(char key, Recursive r, out Variable v)
			{
				v = new Variable(key, r);
				return v;
			}

			protected void SetValue(object value)
			{
                object[] o = Recursive.VariablesL[key] as object[];
				o[0] = value;
            }


            /// <summary>
            /// Gets value of measurement
            /// </summary>
            /// <returns></returns>
            protected object GetValue()
			{
				object[] o = Recursive.VariablesL[key] as object[];
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

            void IUpdateItself.UpdateItself()
            {
				var x = formulaGet();
                if (x != null)
                {
					SetValue(x);
                }
            }



            #endregion

        }

		#endregion

	}

}
