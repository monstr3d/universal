using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Xml;


using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;

using BaseTypes.Interfaces;


using GeneralLinearMethod;
using AnalyticPolynom;

using DataPerformer.Interfaces;
using FormulaEditor.Interfaces;


namespace DataPerformer
{
/*
    /// <summary>
    /// The state machine
    /// </summary>
    [Serializable()]
    public class StateMachine : DataConsumer, ISerializable,
        IPostSetArrow, IStarted, IMeasurements
    {
        /// <summary>
        /// Table of input parameters
        /// </summary>
        private Hashtable parameters = new Hashtable();

        /// <summary>
        /// Parameters
        /// </summary>
        private Hashtable pars;

        /// <summary>
        /// State transition table
        /// </summary>
        private int[,] table;

        /// <summary>
        /// Current state
        /// </summary>
        private int state;

        /// <summary>
        /// Initial state
        /// </summary>
        private int initialState;

        /// <summary>
        /// Table of parameters
        /// </summary>
        private Hashtable doubleParameters = new Hashtable();

        /// <summary>
        /// Output measurement
        /// </summary>
        private IMeasure measure;

        /// <summary>
        /// Constructor
        /// </summary>
        public StateMachine()
            : base(33)
        {
            pars = new Hashtable();
            init();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public StateMachine(SerializationInfo info, StreamingContext context)
            :
            base(33)
        {
            table = (int[,])info.GetValue("Table", typeof(int[,]));
            pars = (Hashtable)info.GetValue("Parameters", typeof(Hashtable));
            initialState = (int)info.GetValue("Initial", typeof(int));
            init();
        }

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        new public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Table", table);
            info.AddValue("Parameters", pars);
            info.AddValue("Initial", initialState);
        }

        /// <summary>
        /// Access to table
        /// </summary>
        public int this[int i, int j]
        {
            get
            {
                return table[i, j];
            }
        }

        /// <summary>
        /// The state
        /// </summary>
        public int State
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

        /// <summary>
        /// The initial state
        /// </summary>
        public int InitialState
        {
            set
            {
                initialState = value;
            }
            get
            {
                return initialState;
            }
        }

        /// <summary>
        /// Gets state table dimension
        /// </summary>
        /// <param name="i">Numer of dimension</param>
        /// <returns></returns>
        public int GetLength(int i)
        {
            if (table == null)
            {
                return 0;
            }
            return table.GetLength(i);
        }

        /// <summary>
        /// The machine state transition table
        /// </summary>
        public int[,] Table
        {
            set
            {
                for (int i = 0; i < value.GetLength(0); i++)
                {
                    for (int j = 0; j < value.GetLength(1); j++)
                    {
                        if (value[i, j] >= value.GetLength(0))
                        {
                            throw new Exception("State machine out of range");
                        }
                    }
                }
                doubleParameters.Clear();
                parameters.Clear();
                pars.Clear();
                table = value;
            }
        }

        /// <summary>
        /// The n th measurement
        /// </summary>
        new public IMeasure this[int n]
        {
            get
            {
                return parameters[n] as IMeasure;
            }
        }

        /// <summary>
        /// The count of measurements
        /// </summary>
        int IMeasurements.Count
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Access to n - th measurement
        /// </summary>
        IMeasurement IMeasurements.this[int n]
        {
            get
            {
                return measure;
            }
        }

        /// <summary>
        /// The keys of input parameters
        /// </summary>
        public ICollection Keys
        {
            get
            {
                return parameters.Keys;
            }
        }



        /// <summary>
        /// Creates correspond xml
        /// </summary>
        /// <param name="doc">document to create element</param>
        /// <returns>The created element</returns>
        /*new public XmlElement CreateXml(XmlDocument doc)
        {
            XmlElement el = doc.CreateElement("DifferentialEquationSolver");
            return el;
        }/





        /// <summary>
        /// The operation that performs after arrows setting
        /// </summary>
        public void PostSetArrow()
        {
            postDeserialize();
            parameters.Clear();
            foreach (IMeasurements measurements in measurementsData)
            {
                string name = StaticDataPerformer.GetName(this, measurements);//c.Name;
                for (int i = 0; i < measurements.Count; i++)
                {
                    IMeasure measure = measurements[i];
                    string p = name + "." + measure.Name;
                    foreach (int j in pars.Keys)
                    {
                        string s = pars[j] as string;
                        if (s.Equals(p))
                        {
                            parameters[j] = measure;
                        }
                    }
                }
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
        /// Starts this object
        /// </summary>
        new public void Start()
        {
            try
            {
                foreach (int i in Keys)
                {
                    double a = -1;
                    doubleParameters[i] = a;
                }
                state = initialState;
            }
            catch (Exception e)
            {
                PureDesktop.Throw(this, e);
            }
        }

        /// <summary>
        /// Sets i - th input parameter
        /// </summary>
        /// <param name="i">The parameter number</param>
        /// <param name="name">The parameter name</param>
        /// <param name="m">The input measurement</param>
        public void SetParameter(int i, string name, IMeasure m)
        {
            parameters[i] = m;
            pars[i] = name + "." + m.Name;
        }

        /// <summary>
        /// Clears parameters
        /// </summary>
        public void ClearParameters()
        {
            parameters.Clear();
            pars.Clear();
            doubleParameters.Clear();
        }

        /// <summary>
        /// Gets name of i - th parameter
        /// </summary>
        /// <param name="i">The parameter number</param>
        /// <returns>The name of i - th parameter</returns>
        public string GetParameter(int i)
        {
            return pars[i] as string;
        }

        /// <summary>
        /// Operation after deserialization
        /// </summary>
        private void postDeserialize()
        {
            doubleParameters.Clear();
            parameters.Clear();
        }

        /// <summary>
        /// Gets state
        /// </summary>
        /// <returns></returns>
        private object getState()
        {
            return state;
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void init()
        {
            Int32 a = 0;
            measure = new Measure(a, getState, "State");
        }

    }

*/
    /// <summary>
    /// Link to unary
    /// </summary>
    [Serializable()]
    public class UnaryLink : ICategoryArrow, ISerializable,
        IRemovableObject
    {
        private VectorFormulaConsumer source;

        private IObjectOperation target;

        /// <summary>
        /// Linked object
        /// </summary>
        protected object obj;

        int a;

        /// <summary>
        /// Default constructor
        /// </summary>
        public UnaryLink()
        {
            a = 0;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public UnaryLink(SerializationInfo info, StreamingContext context)
        {
            a = (int)info.GetValue("A", typeof(int));
        }
        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("A", a);
        }

        /*public XmlElement CreateXml(XmlDocument doc)
        {
            XmlElement el = doc.CreateElement("SeriesLink");
            return el;
        }*/



        /// <summary>
        /// Composes this arrow "f" with next arrow "g" 
        /// </summary>
        /// <param name="category"> The category of arrow</param>
        /// <param name="next"> The next arrow "g" </param>
        /// <returns>Composition "fg" </returns>
        public ICategoryArrow Compose(ICategory category, ICategoryArrow next)
        {
            return null;
        }

        /// <summary>
        /// The category of this object
        /// </summary>
        public ICategory Category
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Associated object
        /// </summary>
        public object Object
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


        /// <summary>
        /// The post remove operation
        /// </summary>
        public void RemoveObject()
        {
            source.RemoveOperation(target);
        }



        /// <summary>
        /// The source of this arrow
        /// </summary>
        public ICategoryObject Source
        {
            get
            {
                return source;
            }
            set
            {
                if (!(value is VectorFormulaConsumer))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                source = value as VectorFormulaConsumer;
            }
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        public ICategoryObject Target
        {
            get
            {
                return target as ICategoryObject;
            }
            set
            {
                if (!(value is IObjectOperation))
                {
                    CategoryException.ThrowIllegalTargetException();
                }
                target = value as IObjectOperation;
                source.AddOperation(target);
            }
        }

        /// <summary>
        /// The "is monomorphism" sign
        /// </summary>
        public bool IsMonomorphism
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// The "is epimorphism" sign
        /// </summary>
        public bool IsEpimorphism
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// The "is isomorphism" sign
        /// </summary>
        public bool IsIsomorphism
        {
            get
            {
                return false;
            }
        }

    }



    /*	[Serializable()]
        public class FormulaRegressionLink : ICategoryArrow, ISerializable, 
            IRemovableObject
        {
            /// <summary>
            /// The source
            /// </summary>
            private FormulaRegression source;

            /// <summary>
            /// The target
            /// </summary>
            private ICategoryObject target;

            /// <summary>
            /// Linked object
            /// </summary>
            protected object obj;
            int a;
            public FormulaRegressionLink()
            {
                a = 0;
            }
            public  FormulaRegressionLink(SerializationInfo info, StreamingContext context)
            {
                a = (int)info.GetValue("A", typeof(int));
            }
            /// <summary>
            /// ISerializable interface implementation
            /// </summary>
            /// <param name="info">Serialization info</param>
            /// <param name="context">Streaming context</param>
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("A", a);
            }

            /// <summary>
            /// Creates correspond xml
            /// </summary>
            /// <param name="doc">document to create element</param>
            /// <returns>The created element</returns>
            /*public XmlElement CreateXml(XmlDocument doc)
            {
                XmlElement el = doc.CreateElement("FormulaRegressionLink");
                return el;
            }*/



     /*		public ICategoryArrow Compose(ICategory category, ICategoryArrow next)
            {
                return null;
            }
		
            /// <summary>
            /// The category of this object
            /// </summary>
            public ICategory Category
            {
                get
                {
                    return null;
                }
            }

            /// <summary>
            /// Associated object
            /// </summary>
            public object Object
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


            /// <summary>
            /// The source of this arrow
            /// </summary>
            public ICategoryObject Source
            {
                get
                {
                    return source;
                }
                set
                {
                    if (!(value is FormulaRegression))
                    {
                        CategoryException.ThrowIllegalSourceException();
                    }
                    source = value as FormulaRegression;
                }
            }
		
            /// <summary>
            /// The target of this arrow
            /// </summary>
            public ICategoryObject Target
            {
                get
                {
                    return target;
                }
                set
                {
                    if (source == null)
                    {
                        throw new Exception("Source object is missing");
                    }
                    if (source == value)
                    {
                        throw new Exception("Target of switch link should not concide with source");
                    }
                    if (value is IArgumentSelection)
                    {
                        source.AddSelection(value as IArgumentSelection);
                        target = value;
                        return;
                    }
                    if (value is VectorFormulaConsumer)
                    {
                        source.Formula = value as VectorFormulaConsumer;
                        target = value;
                        return;
                    }
                    CategoryException.ThrowIllegalTargetException();
                }
            }

            public bool IsMonomorphism
            {
                get
                {
                    return false;
                }
            }

            public bool IsEpimorphism
            {
                get
                {
                    return false;
                }
            }

            public bool IsIsomorphism
            {
                get
                {
                    return false;
                }
            }


            /// <summary>
            /// The post remove operation
            /// </summary>
            public void RemoveObject()
            {
                if (target is IArgumentSelection)
                {
                    IArgumentSelection s = target as IArgumentSelection;
                    source.RemoveSelection(s);
                }
            }


        }*/

    /// <summary>
    /// Selection with arguments
    /// </summary>
    public class ArgumentMultiSelection : IArgumentSelection
    {

        private ArrayList selections = new ArrayList();
        private ArrayList etalons = new ArrayList();
        //private int pointsCount;
        private int dim = 0;
        private string name = "";

        /// <summary>
        /// Count of points
        /// </summary>
        public int PointsCount
        {
            get
            {
                return first.PointsCount;
            }
        }

        /// <summary>
        /// Free variables
        /// </summary>
        public string[] Variables
        {
            get
            {
                return first.Variables;
            }
        }
        /// <summary>
        /// Dimension of output vector
        /// </summary>
        public int VectorDimension
        {
            get
            {
                return dim;
            }
        }

        /// <summary>
        /// Gets value of variable
        /// </summary>
        public double this[int i, string str]
        {
            get
            {
                return first[i, str];
            }
        }

        /// <summary>
        /// Adds seletion
        /// </summary>
        /// <param name="sel">Selection to add</param>
        public void AddSelection(IArgumentSelection sel)
        {
            if (selections.Count == 0)
            {
                selections.Add(sel);
                etalons.Add(sel);
                dim += sel.VectorDimension;
                return;
            }
            string[] variables = first.Variables;
            string[] var = sel.Variables;
            if (var.Length != variables.Length)
            {
                throw new Exception("Illegal number of variables");
            }
            foreach (string s in var)
            {
                foreach (string s1 in variables)
                {
                    if (s.Equals(s1))
                    {
                        goto m1;
                    }
                }
                throw new Exception("Illegal variables");
            m1: continue;
            }
            dim += sel.VectorDimension;
            etalons.Add(sel);
            selections.Add(sel.SynchronizedSelection(selections[0] as IArgumentSelection));
        }

        /// <summary>
        /// Removes selection
        /// </summary>
        /// <param name="sel">Selection to remove</param>
        public void RemoveSelection(IArgumentSelection sel)
        {
            int n = etalons.IndexOf(sel);
            if (n >= 0)
            {
                etalons.RemoveAt(n);
                selections.RemoveAt(n);
                dim -= sel.VectorDimension;
            }
        }

        /// <summary>
        /// Component of i - th selection
        /// </summary>
        /// <param name="i">Selection number</param>
        /// <returns>The component</returns>
        public IObjectLabel GetComponent(int i)
        {
            ICategoryObject o = etalons[i] as ICategoryObject;
            return o.Object as IObjectLabel;
        }


        /// <summary>
        /// Dimension of data
        /// </summary>
        public int DataDimension
        {
            get
            {
                return PointsCount * VectorDimension;
            }
        }

        /// <summary>
        /// Access to n - th element
        /// </summary>
        public double? this[int n]
        {
            get
            {
                int m = n / dim;
                int k = n - dim * m;
                IArgumentSelection s = selections[k] as IArgumentSelection;
                return s[m];
            }
        }

        /// <summary>
        /// Weight of n - th element
        /// </summary>
        /// <param name="n">Element number</param>
        /// <returns>The weight</returns>
        public double GetWeight(int n)
        {
            return 1;
        }

        /// <summary>
        /// Aprior weight of n - th element
        /// </summary>
        /// <param name="n">Element number</param>
        /// <returns>The weight</returns>
        public double GetApriorWeight(int n)
        {
            return 0;
        }

        /// <summary>
        /// Tolerance of it - th element
        /// </summary>
        /// <param name="n">Element number</param>
        /// <returns>Tolerance</returns>
        public int GetTolerance(int n)
        {
            return 0;
        }

        /// <summary>
        /// Sets tolerance of n - th element
        /// </summary>
        /// <param name="n">Element number</param>
        /// <param name="tolerance">Tolerance to set</param>
        public void SetTolerance(int n, int tolerance)
        {
        }

        /// <summary>
        /// The "is fixed amount" sign
        /// </summary>
        public bool HasFixedAmount
        {
            get
            {
                foreach (IStructuredSelection s in selections)
                {
                    if (!s.HasFixedAmount)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Selection name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Calculates synchronized selection
        /// </summary>
        /// <param name="selection">The etalon selection</param>
        /// <returns>Synchronized selection</returns>
        public IArgumentSelection SynchronizedSelection(IArgumentSelection selection)
        {
            ArgumentMultiSelection sel = new ArgumentMultiSelection();
            for (int i = 0; i < selections.Count; i++)
            {
                IArgumentSelection s = selections[i] as IArgumentSelection;
                sel.AddSelection(s.SynchronizedSelection(selection));
            }
            return sel;
        }

        /// <summary>
        /// Gets i - th selection
        /// </summary>
        /// <param name="i">The selection nubmer</param>
        /// <returns>Choosen selection</returns>
        public IArgumentSelection GetSelection(int i)
        {
            return selections[i] as IArgumentSelection;
        }

        /// <summary>
        /// Count of selections
        /// </summary>
        public int SelectionCount
        {
            get
            {
                return selections.Count;
            }
        }

        /// <summary>
        /// First selection
        /// </summary>
        private IArgumentSelection first
        {
            get
            {
                if (selections.Count == 0)
                {
                    return null;
                }
                return selections[0] as IArgumentSelection;
            }
        }

    }






    /// <summary>
    /// ArrayCalculatorAccociated with formulas
    /// </summary>
    public class FormulaArrayCalculator
    {

        /// <summary>
        /// Number of calculator
        /// </summary>
        static private int staticNumber = 0;


        /// <summary>
        /// Calculators
        /// </summary>
        static private Hashtable calculators = new Hashtable();

        /// <summary>
        /// Number of calculator
        /// </summary>
        private int number;

        /// <summary>
        /// Arguments
        /// </summary>
        private string[] arguments;

        /// <summary>
        /// Signal dimension
        /// </summary>
        private int dim;

        /// <summary>
        /// Formula consumer
        /// </summary>
        private VectorFormulaConsumer formulas;

        /// <summary>
        /// Diagram calculator
        /// </summary>
        private Action<int, int, double[], double[]> calculator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="formulas">Formula consumer</param>
        public FormulaArrayCalculator(VectorFormulaConsumer formulas)
        {
            this.formulas = formulas;
            IMeasurements m = formulas;
            IList<string> al = formulas.AliasNames;
            List<string> a = new List<string>();
            for (int i = 0; i < al.Count; i++)
            {
                a.Add(al[i]);
            }
            a.Sort();
            arguments = new string[al.Count];
            for (int i = 0; i < a.Count; i++)
            {
                arguments[i] = a[i] as string;
            }
            dim = formulas.Count;
            calculator = calculate;
            number = staticNumber;
            //AddCalculator(calculator);
        }


        /*public ArrayCalculator Calculator
        {
            get
            {
                return calculator;
            }
        }*/

        /*
        ~FormulaArrayCalculator()
        {
            calculators[number] = null;
        }*/

        /*		public static void Calculate(int i, int n, int m, double[] x, double [] data)
                {
                    ArrayCalculator calc = calculators[i] as ArrayCalculator;
                    calc(n, m, x, data);
                }*/


        /*public static int AddCalculator(ArrayCalculator calculator)
        {
            calculators[staticNumber] = calculator;
            if (staticNumber == 0)
            {
                ArrayCalculatorWrapper.SetGlobalCalculator(GlobalCalculator);
            }
            staticNumber++;
            return staticNumber - 1;
        }*/

        /// <summary>
        /// Output dimension
        /// </summary>
        public int Dim
        {
            get
            {
                return dim;
            }
        }

        /// <summary>
        /// Formula calculator
        /// </summary>
        public Action<int, int, double[], double[]> Calculator
        {
            get
            {
                return calculator;
            }
        }

        /// <summary>
        /// Number of calculator
        /// </summary>
        public int Number
        {
            get
            {
                return number;
            }
        }

        /// <summary>
        /// Arguments of calculator
        /// </summary>
        public string[] Arguments
        {
            get
            {
                return arguments;
            }
        }


        private void calculate(int n, int m, double[] x, double[] data)
        {
            for (int i = 0; i < n; i++)
            {
                formulas[arguments[i]] = x[i];
            }
            IMeasurements mea = formulas;
            mea.UpdateMeasurements();
            for (int i = 0; i < m; i++)
            {
                data[i] = (double)mea[i].Parameter();
            }
        }
    }

 


 
    /// <summary>
    /// Scale selector
    /// </summary>
    public interface IScaleSelector
    {
        /// <summary>
        /// Selects scale
        /// </summary>
        /// <param name="scale">Scale</param>
        /// <returns>Selected scale</returns>
        double SelectScale(double scale);
    }


    /// <summary>
    /// Power scale selector
    /// </summary>
    public class PowerScaleSelector : IScaleSelector
    {

        #region Fields

        double begin;

        double pow;

        double[] scales;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="begin">Begin</param>
        /// <param name="pow">Power</param>
        /// <param name="scales">Array of scales</param>
        public PowerScaleSelector(double begin, double pow, double[] scales)
        {
            this.begin = begin;
            this.pow = pow;
            this.scales = scales;
        }

        #endregion


        #region IScaleSelector Members

        /// <summary>
        /// Selects scale
        /// </summary>
        /// <param name="scale">The scale</param>
        /// <returns></returns>
        public double SelectScale(double scale)
        {
            double log = Math.Floor(Math.Log(scale / (begin * scales[0])) / Math.Log(pow));
            double b = begin * Math.Exp(log * Math.Log(pow));
            for (int i = 0; i < scales.Length; i++)
            {
                if (b * scales[i] > scale)
                {
                    return b * scales[i];
                }
            }
            return 1;
        }

        #endregion
    }

    /// <summary>
    /// Histogram
    /// </summary>
    public class Histogram
    {

        /// <summary>
        /// Gets histogram
        /// </summary>
        /// <param name="selection">Selection</param>
        /// <param name="scaleSelector">Scale selector</param>
        /// <param name="prefferedSize">Preffered size</param>
        /// <returns>The histogram</returns>
        public static double[,] GetHistogram(double[] selection, IScaleSelector scaleSelector, int prefferedSize)
        {
            ArrayList l = new ArrayList(selection);
            l.Sort();
            double min = (double)l[0];
            double max = (double)l[selection.Length - 1];
            double a = (max - min) / (prefferedSize + 1);
            double scale = a;
            if (scaleSelector != null)
            {
                scale = scaleSelector.SelectScale(a);
            }
            int nmin = (int)(Math.Floor(min) / scale);
            int nmax = (int)(Math.Ceiling(max) / scale);
            int diapCount = nmax - nmin;
            double[,] data = new double[diapCount, 2];
            double current = (double)(nmin * scale);
            int nSel = 0;
            for (int i = 0; i < diapCount; i++)
            {
                data[i, 0] = current;
                data[i, 1] = 0;
                if (nSel < l.Count)
                {
                    while (true)
                    {
                        double x = (double)l[nSel];
                        if (x > (current + scale))
                        {
                            break;
                        }
                        ++data[i, 1];
                        ++nSel;
                        if (nSel >= l.Count)
                        {
                            break;
                        }
                    }
                }
                current += scale;
            }
            return data;
        }
    }
}