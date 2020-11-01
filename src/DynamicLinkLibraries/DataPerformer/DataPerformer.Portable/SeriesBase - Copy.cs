using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml;


using CategoryTheory;
using BaseTypes;
using Diagram.UI.Labels;
using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;
using BaseTypes.Interfaces;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Base class of all series
    /// </summary>
    public class SeriesBase : Basic.Series,  ICategoryObject, IArgumentSelection,
       IStructuredSelection, IStructuredSelectionCollection, IMeasurement, 
        IMeasurements, 
        IAliasVector, IUnary, IObjectOperation, IPowered,  IOneVariableFunction
    {

        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly SeriesBase Singleton = new SeriesBase(false);


        private readonly string[] var = new string[] { "x" };



 
        /// <summary>
        /// Label of x - coordinate
        /// </summary>
        protected string x = "";

        /// <summary>
        /// Label of y - coordinate
        /// </summary>
        protected string y = "";
 
        /// <summary>
        /// Comments
        /// </summary>
        protected byte[] comments;

        /// <summary>
        /// The "X" measure
        /// </summary>
        protected object[] meaX = new object[2];

        /// <summary>
        /// The "Y" measure
        /// </summary>
        protected object[] meaY = new object[2];

        /// <summary>
        /// Measure parameter
        /// </summary>
        protected Func<object>[] measureParameter = new Func<object>[2];

        /// <summary>
        /// Function
        /// </summary>
        protected IMeasurement function;

        /// <summary>
        /// All measurements
        /// </summary>
        //!!! LATER IMeasurement[6];
        protected IMeasurement[] measurements = new IMeasurement[6];



        protected List<string> vectorNames = new List<string>();
        private IMeasurement measureY;
        protected IStructuredSelection[] selections;
        private object type = new object[] { a, a };
        static protected readonly string[] vNames = new string[] { "Ordinates" };

        private object obj;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SeriesBase()
        {
            foreach (string vn in vNames)
            {
                vectorNames.Add(vn);
            }
            selections = new IStructuredSelection[] { new XSelection(this), this };
            initialize();
            initFunc();
            Post();
        }

        private SeriesBase(bool b)
        {

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

        #region IMeasurements Members

        IMeasurement IMeasurements.this[int n]
        {
            get
            {
                if (n < measurements.Length)
                {
                    return measurements[n];
                }
                return function;
            }
        }

        /// <summary>
        /// Updates measurements
        /// </summary>
        public void UpdateMeasurements()
        {

        }

        /// <summary>
        /// Name of source
        /// </summary>
        public string SourceName
        {
            get
            {
                IObjectLabel l = obj as IObjectLabel;
                return l.Name;
            }
        }

        /// <summary>
        /// The "is updated" sign
        /// </summary>
        public bool IsUpdated
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        /// <summary>
        /// Count of measurements
        /// </summary>
        int IMeasurements.Count
        {
            get
            {
                return (function == null) ? measurements.Length : measurements.Length + 1;
            }
        }


        #endregion

        #region IMeasurement Members

        /// <summary>
        /// Parameter of this measure
        /// </summary>
        public Func<object> Parameter
        {
            get
            {
                return measureParameter[0];
            }
        }

        /// <summary>
        /// Derivation
        /// </summary>
        public Func<object> Derivation
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get
            {
                return "X";
            }
        }


        /// <summary>
        /// Factor
        /// </summary>
        public double Factor
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Type
        /// </summary>
        public object Type
        {
            get
            {
                InitialzeMeasurements();
                return type;
            }
        }

        #endregion

        #region IAliasVector Members

        IList<string> IAliasVector.AliasNames
        {
            get { return vectorNames; }
        }

        object IAliasVector.this[string name, int i]
        {
            get
            {
                return points[i][1];
            }
            set
            {
                double y = (double)value;
                points[i][1] = y;
                meaY[i] = y;
            }
        }

        object IAliasVector.GetType(string name)
        {
            return a;
        }

        int IAliasVector.GetCount(string name)
        {
            return points.Count;
        }

        #endregion

        #region IStructuredSelection Members

        /// <summary>
        /// Dimension of data
        /// </summary>
        public int DataDimension
        {
            get
            {
                return points.Count;
            }
        }

        /// <summary>
        /// Access to n - th element
        /// </summary>
        double? IStructuredSelection.this[int n]
        {
            get
            {
                return this[n, 1];
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
            return 1;
        }

        /// <summary>
        /// Tolerance of it - th element
        /// </summary>
        /// <param name="n">Element number</param>
        /// <returns>Tolerance</returns>
        public int GetTolerance(int n)
        {
            return 1;
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
                return true;
            }
        }

        string IStructuredSelection.Name
        {
            get
            {
                return "Y";
            }
        }

        /// <summary>
        /// Free variables
        /// </summary>
        public string[] Variables
        {
            get
            {
                return var;
            }
        }
        /// <summary>
        /// Dimension of output vector
        /// </summary>
        public int VectorDimension
        {
            get
            {
                return 1;
            }
        }

        #endregion

        #region IStructuredSelectionCollection Members

        int IStructuredSelectionCollection.Count
        {
            get
            {
                return 2;
            }
        }

        IStructuredSelection IStructuredSelectionCollection.this[int i]
        {
            get
            {
                return selections[i];
            }
        }

        #endregion

        #region IArgumentSelection Members

        /// <summary>
        /// Calculates synchronized selection
        /// </summary>
        /// <param name="selection">The etalon selection</param>
        /// <returns>Synchronized selection</returns>
        public IArgumentSelection SynchronizedSelection(IArgumentSelection selection)
        {
            if (!(selection is SeriesBase))
            {
                throw new Exception("Incompatible selections");
            }
            SeriesBase etalon = selection as SeriesBase;
            SeriesBase s = new SeriesBase();
            for (int i = 0; i < etalon.PointsCount; i++)
            {
                double x = etalon[i, 0];
                double a = this[0, 0];
                if (x < a)
                {
                    s.AddXY(x, this[0, 1]);
                    continue;
                }
                double b = this[PointsCount - 1, 0];
                if (x > b)
                {
                    s.AddXY(x, this[PointsCount - 1, 1]);
                    continue;
                }
                s.AddXY(x, this[x][1]);
            }
            return s;
        }

        /// <summary>
        /// Gets value of variable
        /// </summary>
        double IArgumentSelection.this[int i, string str]
        {
            get
            {
                return this[i, 0];
            }
        }


        #endregion

        #region IObjectOperation Members

        object IObjectOperation.this[object[] x]
        {
            get
            {
                double a = (double)x[0];
                return GetValue(a);
            }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get
            {
                return a;
            }
        }

        object[] IObjectOperation.InputTypes
        {
            get { return new object[] { (double)0 }; }
        }


        /// <summary>
        /// The "is powered" sign
        /// </summary>
        bool IPowered.IsPowered
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region IOneVariableFunction Members

        object IOneVariableFunction.VariableType
        {
            get { return a; }
        }

        #endregion

        #region IOperationAcceptor Members

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
        {
            if (type.Equals(a))
            {
                return this;
            }
            return null;
        }

        #endregion

        #region IUnary Members

        /// <summary>
        /// Gets value of function
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns></returns>
        public double GetValue(double x)
        {
            return this[x][0];
        }

        /// <summary>
        /// Gets derivation of function
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns></returns>
        public double GetDerivation(double x)
        {
            return this[x][1];
        }

        #endregion


        #region Specific Members

        /// <summary>
        /// The Has equal steps sign
        /// </summary>
        public string HasEqualSteps
        {
            get
            {
                if (step == 0)
                {
                    return PureDesktop.GetResourceString(HasEqualStepString[1]);
                }
                return PureDesktop.GetResourceString(HasEqualStepString[0]);
            }
        }

        /// <summary>
        /// Label of X - coordinate
        /// </summary>
        public string X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>
        /// Label of Y - coordinate
        /// </summary>
        public string Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }



        /// <summary>
        /// Count of points
        /// </summary>
        public int PointsCount
        {
            get
            {
                return points.Count;
            }
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Initialization of mesurements
        /// </summary>
        protected virtual void InitialzeMeasurements()
        {
            if (meaX.Length == points.Count)
            {
                return;
            }
            meaX = new object[points.Count];
            meaY = new object[meaX.Length];
            type = new object[meaX.Length];
            for (int i = 0; i < meaX.Length; i++)
            {
                meaX[i] = this[i, 0];
                meaY[i] = this[i, 1];
            }
            Double a = 0;
            type = new ArrayReturnType(a, new int[] { points.Count }, true);
        }

        /// <summary>
        /// Initialization
        /// </summary>
        protected virtual void initialize()
        {
            initMeasures();
            points = new List<double[]>();
            pointStart = new int[2];
            pointFinish = new int[2];
        }

        /// <summary>
        /// Post operation
        /// </summary>
        protected void Post()
        {
            initMeasures();
            measureY = YMeasure.getMeasure(this);
            measurements[1] = measureY;
            selections = new IStructuredSelection[] { new XSelection(this), this };
            CheckEqualStep();
        }

        protected void initFunc()
        {
            Func<object> par = func;
            function = new Measurement(Singleton, par, "Function");
        }


        #endregion

        #region Private Members


        private object func()
        {
            return this;
        }



        private object parX()
        {
            InitialzeMeasurements();
            return meaX;
        }

        private object parY()
        {
            InitialzeMeasurements();
            return meaY;
        }



        private void initMeasures()
        {
            measureParameter[0] = new Func<object>(parX);
            measureParameter[1] = new Func<object>(parY);
            IMeasurement[] m = EndPointMeasure.CreateMeasurements(this);
            measurements[0] = this;
            for (int i = 0; i < m.Length; i++)
            {
                measurements[i + 2] = m[i];
            }
        }

        #endregion

        #region Helper Classes

        class EndPointMeasure : IMeasurement
        {
            #region Fields

            private SeriesBase s;

            private string name;

            private Func<object> par;

            private const Double a = 0;

            #endregion

            #region Ctor

            private EndPointMeasure(int[] b, SeriesBase s)
            {
                this.s = s;
                if (b[0] == 0)
                {
                    name = "X_" + (b[1] + 1);
                    if (b[1] == 0)
                    {
                        par = x1;

                        return;
                    }
                    par = x2;
                    return;
                }
                name = "Y_" + (b[1] + 1);
                if (b[1] == 0)
                {
                    par = y1;
                    return;
                }
                par = y2;
            }


            #endregion

            #region Members

            internal static IMeasurement[] CreateMeasurements(SeriesBase s)
            {
                List<IMeasurement> l = new List<IMeasurement>();
                int[] b = new int[2];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        b[0] = j;
                        b[1] = i;
                        l.Add(new EndPointMeasure(b, s));
                    }
                }
                return l.ToArray();
            }

            object x1()
            {
                double a = 0;
                if (s.points.Count > 0)
                {
                    return s.points[0][0];
                }
                return a;

            }
            object y1()
            {
                double a = 0;
                if (s.points.Count > 0)
                {
                    return s.points[0][1];
                }
                return a;

            }
            object x2()
            {
                double a = 0;
                if (s.points.Count > 0)
                {
                    return s.points[s.points.Count - 1][0];
                }
                return a;

            }
            object y2()
            {
                double a = 0;
                if (s.points.Count > 0)
                {
                    return s.points[s.points.Count - 1][1];
                }
                return a;

            }

            #endregion


            #region IMeasurement Members

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

            #endregion
        }

        class YMeasure : IMeasurement
        {
            private SeriesBase s;

            public static IMeasurement getMeasure(SeriesBase s)
            {
                return new YMeasure(s);
            }

            YMeasure(SeriesBase s)
            {
                this.s = s;
            }
            #region IMeasurement Members

            public Func<object> Parameter
            {
                get
                {
                    return s.measureParameter[1];
                }
            }

            public Func<object> Derivation
            {
                get
                {
                    return null;
                }
            }

            public string Name
            {
                get
                {
                    return "Y";
                }
            }

            public double Factor
            {
                get
                {
                    return 1;
                }
            }

            public object Type
            {
                get
                {
                    return s.Type;
                }
            }

            #endregion
        }

        class XSelection : IStructuredSelection
        {
            private SeriesBase s;

            #region IStructuredSelection Members

            public XSelection(SeriesBase s)
            {
                this.s = s;
            }

            /// <summary>
            /// Dimension of data
            /// </summary>
            public int DataDimension
            {
                get
                {
                    return s.points.Count;
                }
            }

            /// <summary>
            /// Access to n - th element
            /// </summary>
            double? IStructuredSelection.this[int n]
            {
                get
                {
                    return s[n, 0];
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
                return 1;
            }

            /// <summary>
            /// Tolerance of it - th element
            /// </summary>
            /// <param name="n">Element number</param>
            /// <returns>Tolerance</returns>
            public int GetTolerance(int n)
            {
                return 1;
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
                    return true;
                }
            }

            /// <summary>
            /// Count of points
            /// </summary>
            public int PointsCount
            {
                get
                {
                    return s.points.Count;
                }
            }

            /// <summary>
            /// Free variables
            /// </summary>
            public string[] Variables
            {
                get
                {
                    return s.var;
                }
            }
            /// <summary>
            /// Dimension of output vector
            /// </summary>
            public int VectorDimension
            {
                get
                {
                    return 1;
                }
            }





            public string Name
            {
                get
                {
                    return "X";
                }
            }

            #endregion
        }

        #endregion
    }
}
