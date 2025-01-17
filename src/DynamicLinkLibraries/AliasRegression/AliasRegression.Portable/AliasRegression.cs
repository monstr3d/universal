using System;
using System.Collections;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using DataPerformer.Portable;
using DataPerformer.Interfaces;

using GeneralLinearMethod;
using ErrorHandler;

namespace Regression.Portable
{
	/// <summary>
	/// Regression based on the aliases 
	/// </summary>
    public class AliasRegression : CategoryObject, IDataConsumer, 
        IStructuredSelectionConsumer, IStructuredCalculation,
        IPostSetArrow
	{
		
		#region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
 
		/// <summary>
		/// Measurements
		/// </summary>
		private List<IMeasurements> measurements = new List<IMeasurements>();

        /// <summary>
        /// Dependent measurements
        /// </summary>
        protected List<IMeasurements> dependent = new List<IMeasurements>();

        /// <summary>
        /// Dependent objects
        /// </summary>
        protected List<object> l = new List<object>();


		/// <summary>
		/// Selections
		/// </summary>
		protected List<IStructuredSelectionCollection> selections = 
			new List<IStructuredSelectionCollection>();

		/// <summary>
		/// Selected selections
		/// </summary>
		protected Dictionary<int, IStructuredSelection> selectedSelections = 
			new Dictionary<int, IStructuredSelection>();

		/// <summary>
		/// Names of aliases
		/// </summary>
		protected ArrayList aliasNames = new ArrayList();

		/// <summary>
		/// Names of measures
		/// </summary>
		protected Hashtable measurementsNames = new Hashtable();

		/// <summary>
		/// Selecion names
		/// </summary>
		protected Hashtable selectionNames = new Hashtable();

		/// <summary>
		/// Measuements
		/// </summary>
		protected Dictionary<int, IMeasurement> measurementsDitcionary = 
			new Dictionary<int, IMeasurement>();

		/// <summary>
		/// Aliases
		/// </summary>
		protected IAliasName[] aliases;

		/// <summary>
		/// Dispersions
		/// </summary>
		protected double[] dispersions;

		/// <summary>
		/// Delta
		/// </summary>
		protected double[] delta;

		/// <summary>
		/// Input data
		/// </summary>
		protected double[] x;

		/// <summary>
		/// Output data
		/// </summary>
		protected double?[] y;

		/// <summary>
		/// Auxiliary output data
		/// </summary>
		protected double?[] y1;

		/// <summary>
		/// Auxiliary matrix
		/// </summary>
		protected double?[,] h;

		/// <summary>
		/// Aggregate selection
		/// </summary>
		protected AggregateSelection selection = new AggregateSelection();

		/// <summary>
		/// General linear method
		/// </summary>
		protected StructuredGLM method;

		/// <summary>
		/// Number of tests
		/// </summary>
		protected static int numberOfTests = 0;

		/// <summary>
		/// Standard derivation
		/// </summary>
		protected double standardDeviation = 0;


		protected IDataRuntime runtime;

 
		#endregion
	
		#region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
		public AliasRegression()
		{

		}

		#endregion

		#region IDataConsumer Members

		void IDataConsumer.Add(IMeasurements arrow)
		{
			measurements.Add(arrow);
            measurements.GetDependent(l, dependent);
		}

        void IDataConsumer.Remove(IMeasurements arrow)
		{
			measurements.Remove(arrow);
            measurements.GetDependent(l, dependent);
		}

        /// <summary>
        /// Updates data of data providers
        /// </summary>
        public void UpdateChildrenData()
        {
            foreach (IMeasurements m in measurements)
            {
                try
                {
                    m.UpdateMeasurements();
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                    this.Throw(ex);
                }
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

		#region IStructuredSelectionConsumer Members

        /// <summary>
        /// Adds selection collection
        /// </summary>
        /// <param name="selection">Selection to add</param>
        public void Add(IStructuredSelectionCollection selection)
		{
			selections.Add(selection);
		}

        /// <summary>
        /// Removes selection collecion
        /// </summary>
        /// <param name="selection">Selection to remove</param>
        public void Remove(IStructuredSelectionCollection selection)
		{
			selections.Remove(selection);
		}

		#endregion

        #region IStructuredCalculation Members

        /// <summary>
        /// Calculates parameters
        /// </summary>
        /// <param name="x">Input</param>
        /// <param name="selection">Selection</param>
        /// <param name="y">Output</param>
        public void Calculate(double[] x, IStructuredSelection selection, double?[] y)
		{
			double a = 0;
			for (int i = 0; i < x.Length; i++)
			{
                aliases[i].Value = x[i];
			}
            runtime.UpdateAll();
			int n = 0;
			for (int i = 0; i < measurementsDitcionary.Count; i++)
			{
				IMeasurement m = measurementsDitcionary[i];
				var parameter = m.Parameter;
				object t = m.Type;
				if (t.Equals(a))
				{
					y[n] = (double) parameter();
					++n;
					continue;
				}
				else
				{
					Array ar = parameter() as Array;
					for (int j = 0; j < ar.GetLength(0); j++)
					{
                        y[n] = (double)ar.GetValue(j);
						++n;
					}
				}
			}
		}

        /// <summary>
        /// Dimension
        /// </summary>
		public int Dimension
		{
			get
			{
                if (aliases == null)
                {
                    return 0;
                }
				return aliases.Length;
			}
		}

        /// <summary>
        /// Number of aliases
        /// </summary>
        public int NumberOfAliases
        {
            get
            {
                return aliasNames.Count;
            }
        }

		#endregion

        #region IParametersCount Members

        /// <summary>
        /// Count of parameters
        /// </summary>
        public int ParametersCount
        {
            get 
            {
                if (aliases == null)
                {
                    return 0;
                }
                return aliases.Length;
            }
        }

        /// <summary>
        /// Standard deviation
        /// </summary>
        public double StandardDeviation
        {
            get 
            {
                return standardDeviation;
            }
        }

        #endregion
 
		#region IPostSetArrow Members

        /// <summary>
        /// The operation that performs after arrows setting
        /// </summary>
        public virtual void PostSetArrow()
		{
            List<IAliasName> lan = new List<IAliasName>();
			foreach (string s in aliasNames)
			{
                IAliasName[] arr = this.FindAllAliasName(s, false);
				if (arr != null)
				{
					lan.AddRange(arr);
				}
			}
            aliases = lan.ToArray();
			int nmea = 0;
			for (int i = 0; i < measurementsNames.Count; i++)
			{
				string name = measurementsNames[i] as string;
				int n = name.LastIndexOf(".");
				string m = name.Substring(0, n);
                foreach (IMeasurements meas in measurements)
				{
					IAssociatedObject ao = meas as IAssociatedObject;
					//INamedComponent nc = ao.Object as INamedComponent;
					if (!m.Equals(this.GetRelativeName(ao)))
					{
						continue;
					}
					string suff = name.Substring(n + 1);
					for (int j = 0; j < meas.Count; j++)
					{
						IMeasurement mea = meas[j];
						if (!mea.Name.Equals(suff))
						{
							continue;
						}
						measurementsDitcionary[nmea] = mea;
						++nmea;
					}
				}
			}
			for (int i = 0; i < selectionNames.Count; i++)
			{
				string sn = selectionNames[i] as string;
				foreach (IStructuredSelectionCollection s in selections)
				{
					IAssociatedObject ao = s as IAssociatedObject;
					//INamedComponent nc = ao.Object as INamedComponent;
					string name = this.GetRelativeName(ao);//nc.Name;
					for (int j = 0; j < s.Count; j++)
					{
						
						if (!sn.Equals(name + "." + s[j].Name))
						{
							continue;
						}
						selectedSelections[i] = s[j];
					}
				}
			}
			Init();
		}


        #endregion

        #region Specific members

        /// <summary>
        /// Coefficient
        /// </summary>
        public double Coefficient
		{
			get;
			set;
		} = 1;

        /// <summary>
        /// Number of tests
        /// </summary>
        public static int NumberOtTests
        {
            get
            {
                return numberOfTests;
            }
            set
            {
                numberOfTests = value;
            }
        }

		/// <summary>
		/// Aliases
		/// </summary>
		public Dictionary<int, object[]> Aliases
		{
			set
			{
				for (int i = 0; i < value.Count; i++)
				{
					if (!value.ContainsKey(i))
					{
						throw new Exception("Abscent alias");
					}
				}
				aliasNames.Clear();
                List<IAliasName> ali = new List<IAliasName>();
                List<double> disp = new List<double>();
                List<double> del = new List<double>();
				for (int i = 0; i < value.Count; i++)
				{
					object[] o = value[i];
					string name = o[0] as string;
                    IAliasName[] ob = this.FindAllAliasName(name, false);
                    ali.AddRange(ob);
                    for (int j = 0; j < ob.Length; j++)
                    {
                        disp.Add((double)o[1]);
                        del.Add((double)o[2]);
                    }
					//aliases[i] = ob;
					aliasNames.Add(name);
				}
                aliases = ali.ToArray();
                dispersions = disp.ToArray();
                delta = del.ToArray();
			}
			get
			{
                Dictionary<int, object[]> t = new Dictionary<int, object[]>();
				for (int i = 0; i < aliasNames.Count; i++)
				{
					string name = aliasNames[i] as string;
					t[i] = new object[]{name, dispersions[i], delta[i]};
				}
				return t;
			}
		}


		/// <summary>
		/// Names of selections
		/// </summary>
		public Hashtable SelectionsNames
		{
			get
			{
				return selectionNames;
			}
			set
			{
				for (int i = 0; i < value.Count; i++)
				{
					if (!value.ContainsKey(i))
					{
						throw new Exception("Shortage of selections");
					}
				}
				selectionNames = value;
				selectedSelections.Clear();
				foreach (IStructuredSelectionCollection s in selections)
				{
					IAssociatedObject ao = s as IAssociatedObject;
					//INamedComponent nc = ao.Object as INamedComponent;
					string name = this.GetRelativeName(ao);
					foreach (int i in selectionNames.Keys)
					{
						for (int j = 0; j < s.Count; j++)
						{
							string sn = name + "." + s[j].Name;
							if (sn.Equals(selectionNames[i]))
							{
								selectedSelections[i] = s[j];
								break;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Selections
		/// </summary>
		public List<IStructuredSelectionCollection> Selections
		{
			get
			{
				return selections;
			}
		}

		/// <summary>
		/// Names of neasurements
		/// </summary>
		public Hashtable MeasuresNames
		{
			get
			{
				return measurementsNames;
			}
			set
			{
				for (int i = 0; i < value.Count; i++)
				{
					if (!value.ContainsKey(i))
					{
						throw new Exception("Shortage of measurements");
					}
				}
				measurementsNames = value;
				measurementsDitcionary.Clear();
				for (int i = 0; i < measurementsNames.Count; i++)
				{
					string s = measurementsNames[i] as string;
					int n = s.LastIndexOf(".");
					string name = s.Substring(0, n);
					foreach (IAssociatedObject ao in measurements)
					{
						IAssociatedObject ob = null;
						if (ao is DataLink)
						{
							IArrowLabel ar = ao.Object as IArrowLabel;
							IObjectLabel l = ar.Target;
							ob = l.Object as IAssociatedObject;
						}
						else
						{
							ob = ao;
						}
						INamedComponent nc = ob.Object as INamedComponent;
						if (!name.Equals(this.GetRelativeName(ao)))
						{
							continue;
						}
						string suffix = s.Substring(n + 1);
						IMeasurements meas = ob as IMeasurements;
						for (int j = 0; j < meas.Count; j++)
						{
							IMeasurement m = meas[j];
							if (m.Name.Equals(suffix))
							{
								measurementsDitcionary[i] = m;
								goto fin;
							}
						}
					fin:
						int k = 0;
						++k;
					}
				}
			}
		}
		
		/// <summary>
		/// Initialaztion
		/// </summary>
		public void Init()
		{
    		selection.Selections = selectedSelections;
			method = new StructuredGLM(selection, this);
            runtime = this.CreateRuntime(StaticExtensionDataPerformerInterfaces.Calculation);
		}

		/// <summary>
		/// Updates selections
		/// </summary>
		public void UpdateSelections()
		{
			foreach (object o in selectedSelections.Values)
			{
				if (o is IUpdatableSelection)
				{
					IUpdatableSelection s = o as IUpdatableSelection;
					s.UpdateSelection();
				}
			}
		}

		/// <summary>
		/// Performs iteration step
		/// </summary>
		/// <returns>Sogma0</returns>
		public double Iterate()
		{
			MeasuresNames = measurementsNames;
			SelectionsNames = selectionNames;
			Init();
			int n = Dimension;
			int l = selection.DataDimension;
			if (x == null)
			{
				x = new double[n];
			}
			else if (x.Length != n)
			{
				x = new double[n];
			}
			if (y == null)
			{
				y = new double?[l];
				y1 = new double?[l];
			}
			else if (y.Length != l)
			{
				y = new double?[l];
				y1 = new double?[l];
			}
			if (h == null)
			{
				h = new double?[n, l];
			}
			else if ((h.GetLength(0) != n) | (h.GetLength(1) != l))
			{
				h = new double?[n, l];
			}
			for (int i = 0; i < x.Length; i++)
			{
				IAliasName al = aliases[i];
				x[i] = (double) al.Value;

                /*!!! ====  Test of test ===========
                x[i] = (double) al.Value + 0.000001;
                //*/ //==============================

            }
            if (delta.Length != x.Length)
            {
                double[] d = new double[x.Length];
                for (int i = 0; (i < x.Length) & (i < delta.Length); i++)
                {
                    d[i] = delta[i];
                }
                delta = d;
            }
			method.Iterate(x, delta, dispersions, y, y1, h, Coefficient);
			for (int i = 0; i < x.Length; i++)
			{
                IAliasName al = aliases[i];
				al.Value = x[i];
			}
            return standardDeviation;
		}
		
		/// <summary>
		/// Gets sigma
		/// </summary>
		public double SquareResidual
		{
			get
			{
				int n = Dimension;
				int l = selection.DataDimension;
				if (x == null)
				{
					x = new double[n];
				}
				else if (x.Length != n)
				{
					x = new double[n];
				}
				if (y == null)
				{
					y = new double?[l];
				}
				else if (y.Length != l)
				{
					y = new double?[l];
				}
				standardDeviation = (double) method.GetSquareResidual(x, y);
                return standardDeviation;
			}
		}

		/// <summary>
		/// Dimension of data
		/// </summary>
		public int DataDimension
		{
			get
			{
				return selection.DataDimension;
			}
		}

        /// <summary>
        /// Sets aliases
        /// </summary>
		public void SetAliases()
		{
			for (int i = 0; i < x.Length; i++)
			{
				IAliasName al = aliases[i];
				al.Value = x[i];
			}
		}

        /// <summary>
        /// Backup
        /// </summary>
        public Dictionary<IAliasName, double> Backup
        {
            get
            {
                Dictionary<IAliasName, double> d = new Dictionary<IAliasName, double>();
                for (int i = 0; i < aliases.Length; i++)
                {
                    IAliasName al = aliases[i];
                    d[al] = (double)al.Value;
                }
                return d;
            }

        }

		/// <summary>
		/// Residuals
		/// </summary>
		public double?[] Residuals
		{
			get
			{
				return method.Residuals;
			}
		}
		
		/// <summary>
		/// Data
		/// </summary>
		public double?[] Data
		{
			get
			{
				return method.Data;
			}
		}

		/// <summary>
		/// Data processing method
		/// </summary>
		public StructuredGLM Method
		{
			get
			{
				return method;
			}
		}

		/// <summary>
		/// Full iteration with all updates
		/// </summary>
		public double FullIterate()
		{
			UpdateSelections();
			var a = Iterate();
			SetAliases();
			return a;
		}

        /// <summary>
        /// Tests itself
        /// </summary>
        /// <param name="d">Desktop</param>
        /// <param name="n">Number of iterations</param>
        public static void Test(IDesktop d, int n)
        {
            IEnumerable<ICategoryObject> objs = d.CategoryObjects;
            List<AliasRegression> reg = new List<AliasRegression>();
            foreach (object o in objs)
            {
                if (o is AliasRegression)
                {
                    AliasRegression ar = o as AliasRegression;
                    reg.Add(ar);
                }
            }
            for (int i = 0; i < n; i++)
            {
                foreach (AliasRegression ar in reg)
                {
                    ar.FullIterate();
                }
            }
        }

        #endregion

   }

}
