using System;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

using RealMatrixProcessor;

namespace Regression.Portable
{

    /// <summary>
    /// General linear method with iterator
    /// </summary>
    public class IteratorGLM : CategoryObject,  IDataConsumer, 
      IIteratorConsumer,  IPostSetArrow
    {

        #region Fields

        RealMatrix realMatrix = new ();

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };

        /// <summary>
        /// String representations of aliases
        /// </summary>
        protected List<string> sAliases = new List<string>();

        /// <summary>
        /// String representations of left borders
        /// </summary>
        protected List<string> sLeft = new List<string>();

        /// <summary>
        /// String representations of left borders
        /// </summary>
        protected List<string> sRight = new List<string>();

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected List<List<string>> sR = new List<List<string>>();

        /// <summary>
        /// Array of finite differences for derivation calculation
        /// </summary>
        protected double[] dx;

        /// <summary>
        /// Additional matrix for stability
        /// </summary>
        protected double[,] d;

        /// <summary>
        /// Children iterators
        /// </summary>
        protected List<IIterator> iterators = new List<IIterator>();

        /// <summary>
        /// Aliases for estimation
        /// </summary>
        protected IAliasName[] aliases;

        /// <summary>
        /// Keys
        /// </summary>
        protected string[] keys;

        /// <summary>
        /// Left border measurements
        /// </summary>
        protected IMeasurement[] left;

        /// <summary>
        /// Right border measurements
        /// </summary>
        protected IMeasurement[] right;

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected double[,] ht;
       
        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected double[,] auliliaryA;
       
        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected int[] indxa;
       
        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected double[] z;
        
        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected double[,] mr;
        
        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected double[,] mr1;

        /// <summary>
        /// Covariation matrix measurements
        /// </summary>
        protected IMeasurement[,] r;

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected double[] y;
        
        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected double[] y1;
      
        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected double[] yr;
        
        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected double[,] htr;
        
        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected double[,] ad;

        /// <summary>
        /// Correct shift
        /// </summary>
        protected double[] correct;

        /// <summary>
        /// Own iterators
        /// </summary>
        protected List<IIterator> ownIterators = new List<IIterator>();

        /// <summary>
        /// Linked object
        /// </summary>
        protected object obj;

        /// <summary>
        /// This object as data consumer
        /// </summary>
        protected IDataConsumer consumer;

        List<IMeasurements> measurements = new List<IMeasurements>();

        static private readonly ConstMeasurement zero = new ConstMeasurement(0);
        
        static private readonly ConstMeasurement unity = new ConstMeasurement(1);

        List<IAliasName> aliasNames = new List<IAliasName>();

        List<double[]> buffer = new List<double[]>();

        double currentSigma = 0;
    
        #endregion

        #region Constuctors

        /// <summary>
        /// Default constructor
        /// </summary>
        public IteratorGLM()
        {
            consumer = this;
        }


        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            CreateArrays();
            SetZeros();
            Prepare();
        }

        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements mea)
        {
            measurements.Add(mea);
        }

        void IDataConsumer.Remove(IMeasurements mea)
        {
            measurements.Remove(mea);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            foreach (IMeasurements m in measurements)
            {
                m.UpdateMeasurements();
            }
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

        #region IIteratorConsumer Members

        void IIteratorConsumer.Add(IIterator iterator)
        {
            ownIterators.Add(iterator);
         }

        void IIteratorConsumer.Remove(IIterator iterator)
        {
            ownIterators.Remove(iterator);
         }

        #endregion

        #region Specific Members

        #region Public Members

        /// <summary>
        /// Backup of aliases
        /// </summary>
        public Dictionary<IAliasName, double> Backup
        {
            get
            {
                Dictionary<IAliasName, double> dictionary = new Dictionary<IAliasName, double>();
                foreach (IAliasName alias in aliasNames)
                {
                    dictionary[alias] = (double)alias.Value;
                }
                return dictionary;
            }
        }

        /// <summary>
        /// Sets all data
        /// </summary>
        /// <param name="aliases">Aliases</param>
        /// <param name="left">Left borders</param>
        /// <param name="right">Right borders</param>
        /// <param name="r">Covariation matrix calculation</param>
        /// <param name="dx">Shift for derivation calculation</param>
        /// <param name="d">Additional matrix for stability</param>
        public void Set(List<string> aliases, List<string> left,
            List<string> right, List<List<string>> r,
            double[] dx, double[,] d)
        {
            this.sAliases = aliases;
            this.sLeft = left;
            this.sRight = right;
            this.sR = r;
            this.dx = dx;
            this.d = d;
            CreateArrays();
            SetZeros();
            Prepare();
        }

        /// <summary>
        /// Count of data
        /// </summary>
        public int DataCount
        {
            get
            {
                return sLeft.Count;
            }
        }

        /// <summary>
        /// Count of aliases
        /// </summary>
        public int AliasesCount
        {
            get
            {
                return sAliases.Count;
            }
        }

        /// <summary>
        /// All aliases of object
        /// </summary>
        public List<string> AllAliases
        {
            get
            {
                List<string> l = new List<string>();
                this.GetAliases(l, null);
                return l;
            }
        }

        /// <summary>
        /// Gets i - th alias name
        /// </summary>
        /// <param name="i">Alias number</param>
        /// <returns>Name of alias</returns>
        public string GetAliasName(int i)
        {
            return sAliases[i];
        }

        /// <summary>
        /// Gets name of i-th left
        /// </summary>
        /// <param name="i">number</param>
        /// <returns>Name of i-th left</returns>
        public string GetLeftName(int i)
        {
            return sLeft[i];
        }

        /// <summary>
        /// Gets name of i-th right
        /// </summary>
        /// <param name="i"></param>
        /// <returns>name of i-th left</returns>
        public string GetRightName(int i)
        {
            return sRight[i];
        }

        /// <summary>
        /// All measurements of this object
        /// </summary>
        public List<string> AllMeasurements
        {
            get
            {
                IDataConsumer c = this;
                List<string> list = new List<string>();
                for (int i = 0; i < c.Count; i++)
                {
                    IMeasurements m = c[i];
                    IAssociatedObject ao = m as IAssociatedObject;
                    string on = this.GetRelativeName(ao) + ".";
                    for (int j = 0; j < m.Count; j++)
                    {
                        string s = on + m[j].Name;
                        list.Add(s);
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// Correction matrix
        /// </summary>
        public double[,] CorrectionMatrix
        {
            get
            {
                return d;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception();
                }
                int n = sAliases.Count;
                if (value.GetLength(0) != n | value.GetLength(1) != n)
                {
                    throw new Exception();
                }
                d = value;
            }
        }

        /// <summary>
        /// Performs full iteration
        /// </summary>
        /// <returns>Residue</returns>
        public double FullIterate()
        {
            PrepareIteration();
            for (int i = 0; i < auliliaryA.GetLength(0); i++)
            {
                for (int j = 0; j < auliliaryA.GetLength(1); j++)
                {
                    auliliaryA[i, j] = d[i, j];
                }
            }
            for (int i = 0; i < z.Length; i++)
            {
                z[i] = 0;
            }
            currentSigma = 0;
            List<double[]> c = Calculate();
            double s = currentSigma;
            List<double[]>[] ll = new List<double[]>[aliases.Length];
            double[,] h = new double[aliases.Length, c.Count];
            for (int i = 0; i < aliases.Length; i++)
            {
                IAliasName alias = aliases[i];
                double delta = dx[i];
                SetDelta(alias, delta);
                ll[i] = Calculate();
                SetDelta(alias, -delta);
            }
            for (int i = 0; i < y.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    mr[i, j] = (double)r[i, j].Parameter();
                    mr[j, i] = mr[i, j];
                }
            }
            realMatrix.Invert(mr, mr1);
            for (int im = 0; im < c.Count; im++)
            {
                double[] y0 = c[im];
                for (int i = 0; i < aliases.Length; i++)
                {
                    double[] y = ll[i][im];
                    for (int j = 0; j < y.Length; j++)
                    {
                        ht[i, j] = (y[j] - y0[j]) / dx[i];
                    }
                }
                realMatrix.Multiply(ht, mr1, htr);
                for (int i = 0; i < auliliaryA.GetLength(0); i++)
                {
                    for (int k = 0; k < htr.GetLength(1); k++)
                    {
                        z[i] -= htr[i, k] * y0[k];
                        for (int j = 0; j < auliliaryA.GetLength(1); j++)
                        {
                            auliliaryA[i, j] += htr[i, k] * ht[j, k];
                        }
                    }
                }
            }
            realMatrix.Solve(auliliaryA, z, indxa);
            for (int i = 0; i < z.Length; i++)
            {
                SetDelta(aliases[i], z[i]);
            }
            return s;
        }


  
        /// <summary>
        /// Performs iteration
        /// </summary>
        /// <returns>Residue</returns>
        public double Iterate()
        {
            PrepareIteration();
            double sigma = 0;
            List<IIterator> iterators;
            if (ownIterators.Count != 0)
            {
                iterators = ownIterators;
            }
            else
            {
                iterators = this.iterators;
            }
            if (iterators.Count == 0)
            {
                return 1;
            }
            foreach (IIterator it in iterators)
            {
                it.Reset();
            }
            for (int i = 0; i < auliliaryA.GetLength(0); i++)
            {
                for (int j = 0; j < auliliaryA.GetLength(1); j++)
                {
                    auliliaryA[i, j] = d[i, j];
                }
            }
            for (int i = 0; i < z.Length; i++)
            {
                z[i] = 0;
            }
            while (true)
            {
                consumer.Reset();
                try
                {
                    consumer.UpdateChildrenData();
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                    goto cycle;
                }
                for (int i = 0; i < y.Length; i++)
                {
                    object o = left[i].Parameter();
                    if (o == null)
                    {
                        goto cycle;
                    }
                    y[i] = (double)o;
                    o = right[i].Parameter();
                    if (o == null | o is DBNull)
                    {
                        goto cycle;
                    }
                    double res = (double)o - y[i];
                    yr[i] = res;
                    sigma += res * res;
                }
                for (int i = 0; i < aliases.Length; i++)
                {
                    IAliasName a = aliases[i];
                    double delta = dx[i];
                    SetDelta(a, delta);
                    consumer.Reset();
                    consumer.UpdateChildrenData();
                    for (int j = 0; j < y.Length; j++)
                    {
                        object obj = left[j].Parameter();
                        if (obj == null)
                        {
                            SetDelta(a, -delta);
                            goto cycle;
                        }
                        ht[i, j] = ((double)obj - y[j]) / delta;
                    }
                    SetDelta(a, -delta);
                }
                for (int i = 0; i < y.Length; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        mr[i, j] = (double)r[i, j].Parameter();
                        mr[j, i] = mr[i, j];
                    }
                }
                realMatrix.Invert(mr, mr1);
                realMatrix.Multiply(ht, mr1, htr);
                for (int i = 0; i < auliliaryA.GetLength(0); i++)
                {
                    for (int k = 0; k < htr.GetLength(1); k++)
                    {
                        z[i] += htr[i, k] * yr[k];
                        for (int j = 0; j < auliliaryA.GetLength(1); j++)
                        {
                            auliliaryA[i, j] += htr[i, k] * ht[j, k];
                        }
                    }
                }
                cycle:
                foreach (IIterator it in iterators)
                {
                    if (!it.Next())
                    {
                        goto m;
                    }
                }
            }
            m:
            realMatrix.Solve(auliliaryA, z, indxa);
            for (int i = 0; i < z.Length; i++)
            {
                SetDelta(aliases[i], z[i]);
            }
            return sigma;
        }


        /// <summary>
        /// Performs n iterations
        /// </summary>
        /// <param name="n">Number of itrerations</param>
        /// <returns>Residue</returns>
        public double Iterate(int n)
        {
            Dictionary<double, double[]> d = new Dictionary<double, double[]>();
            double[] res = null;
            double a = 0;
            for (int i = 0; i < n; i++)
            {
                Iterate();
                res = new double[z.Length];
                for (int j = 0; j < res.Length; j++)
                {
                    res[j] = GetValue(aliasNames[j]);
                }
                d[CalculatedSigma] = res;
            }
            List<double> l = new List<double>(d.Keys);
            l.Sort();
            a = l[0];
            res = d[a];
            for (int i = 0; i < res.Length; i++)
            {
              aliasNames[i].Value =  res[i];
            }
            double ss = CalculatedSigma;
            return a;
        }

        /// <summary>
        /// Tests itself
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="n">Number of iteratios</param>
        public static void Test(IDesktop desktop, int n)
        {
            IEnumerable<ICategoryObject> objs = desktop.CategoryObjects;
            IList<IteratorGLM> l = new List<IteratorGLM>();
            foreach (object o in objs)
            {
                if (o.GetType().FullName.Equals("DataPerformer.IteratorGLM"))
                {
                    IteratorGLM it = o as IteratorGLM;
                    l.Add(it);
                }
            }
            foreach (IteratorGLM it in l)
            {
                for (int i = 0; i < n; i++)
                {
                    it.Iterate();
                }
            }
            l = null;
            GC.Collect();
        }

        /// <summary>
        /// Calculates Sigma
        /// </summary>
        public double CalculatedSigma
        {
            get
            {
                double sigma = 0;
                List<IIterator> iterators;
                if (ownIterators.Count != 0)
                {
                    iterators = ownIterators;
                }
                else
                {
                    iterators = this.iterators;
                }
                if (iterators.Count == 0)
                {
                    return 1;
                }
                foreach (IIterator it in iterators)
                {
                    it.Reset();
                }
                while (true)
                {
                    consumer.Reset();
                    try
                    {
                        consumer.UpdateChildrenData();
                    }
                    catch (Exception ex)
                    {
                        ex.ShowError(10);
                        goto cycle;
                    }
                    for (int i = 0; i < y.Length; i++)
                    {
                        object o = left[i].Parameter();
                        if (o == null)
                        {
                            goto cycle;
                        }
                        y[i] = (double)o;
                        o = right[i].Parameter();
                        if (o == null | o is DBNull)
                        {
                            goto cycle;
                        }
                        double res = (double)o - y[i];
                        yr[i] = res;
                        sigma += res * res;
                    }
                cycle:
                    foreach (IIterator it in iterators)
                    {
                        if (!it.Next())
                        {
                            goto m;
                        }
                    }
                }
            m:
                return sigma;
            }
        }

        #endregion

        #region Protected Members

        List<IAliasName> Aliases
        {
            get
            {
                List<IAliasName> la = new List<IAliasName>();
                keys = new string[sAliases.Count];
                aliasNames.Clear();
                List<int> kp = new List<int>();
                for (int i = 0; i < sAliases.Count; i++)
                {
                    IAliasName[] ob = this.FindAllAliasName(sAliases[i], false);
                    la.AddRange(ob);
                    kp.Add(ob.Length);
                }
                if (la.Count != d.GetLength(0))
                {
                    double[,] dd = new double[la.Count, la.Count];
                    for (int i = 0; i < la.Count; i++)
                    {
                        for (int j = 0; j < la.Count; j++)
                        {
                            dd[i, j] = 0;
                        }
                    }
                    int p = 0;
                    for (int i = 0; i < kp.Count; i++)
                    {
                        int pp = p + kp[i];
                        double a = d[i, i];
                        double dddx = dx[i];
                        for (int j = p; j < pp; j++)
                        {
                            dd[j, j] = a;
                        }
                    }
                    d = dd;
                }
                if (dx.Length != la.Count)
                {
                    double[] ddx = new double[la.Count];
                    int p = 0;
                    for (int i = 0; i < kp.Count; i++)
                    {
                        int pp = p + kp[i];
                        double dddx = dx[i];
                        for (int j = p; j < pp; j++)
                        {
                            ddx[j] = dddx;
                        }
                    }
                    dx = ddx;
                }
                ht = new double[la.Count, sLeft.Count];
                htr = new double[la.Count, sLeft.Count];
                return la;
            }
        }

        /// <summary>
        /// Prepares itself
        /// </summary>
        protected void Prepare()
        {
            this.GetIterators(iterators);
            SetZeros();
            List<IAliasName> la = Aliases;
            aliases = la.ToArray();
            z = new double[la.Count];
            indxa = new int[la.Count];
            auliliaryA = new double[la.Count, la.Count];
            for (int i = 0; i < sLeft.Count; i++)
            {
                IMeasurement m = Find(sLeft[i]);
                left[i] = m;
            }
            for (int i = 0; i < sRight.Count; i++)
            {
                IMeasurement m = Find(sRight[i]);
                right[i] = m;
            }
            int n = sR.Count;
            int k = sLeft.Count;
            mr = new double[k, k];
            mr1 = new double[k, k];
            y = new double[k];
            y1 = new double[k];
            yr = new double[k];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    string sr = sR[i][j];
                    IMeasurement mea = Find(sr);
                    if (mea != null)
                    {
                        r[i, j] = mea;
                    }
                }
            }
        }

        #endregion

        #region Private Members

        void PrepareIteration()
        {
            IComponentCollection componentCollection = this.CreateCollection();
            componentCollection.SetComponentCollectionHolders();
        }

        List<double[]> Calculate()
        {
            List<double[]> l = new List<double[]>();
            List<IIterator> iterators;
            if (ownIterators.Count != 0)
            {
                iterators = ownIterators;
            }
            else
            {
                iterators = this.iterators;
            }
            foreach (IIterator it in iterators)
            {
                it.Reset();
            }
            while (true)
            {
                consumer.Reset();
                try
                {
                    consumer.UpdateChildrenData();
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
                double[] yy = new double[y.Length];
                for (int i = 0; i < y.Length; i++)
                {
                    double res = (double)left[i].Parameter() - (double)right[i].Parameter();
                    yy[i] = res;
                    currentSigma += res * res;
                }
                l.Add(yy);
                foreach (IIterator it in iterators)
                {
                    if (!it.Next())
                    {
                        goto m;
                    }
                }
            }
            m:
            return l;
        }

        void SetDelta(IAliasName a, double delta)
        {
            a.Value = (double)a.Value + delta;
        }

        double GetValue(IAliasName a)
        {
            return (double)a.Value;
        }

        void SetZeros()
        {
            if (left != null)
            {
                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = zero;
                    right[i] = zero;
                }
            }
            if (r != null)
            {
                for (int i = 0; i < r.GetLength(0); i++)
                {
                    for (int j = 0; j < r.GetLength(1); j++)
                    {
                        r[i, j] = (i == j) ? unity : zero;
                    }
                }
            }
            return;
        }

        private IMeasurement Find(string name)
        {
            int n = name.LastIndexOf(".");
            if (n < 0)
            {
                return null;
            }
            string cn = name.Substring(0, n);
            string suff = name.Substring(n + 1);
            for (int i = 0; i < measurements.Count; i++)
            {
                IMeasurements mea = measurements[i];
                IAssociatedObject ao = mea as IAssociatedObject;
                string na = this.GetRelativeName(ao);
                if (cn.Equals(na))
                {
                    for (int j = 0; j < mea.Count; j++)
                    {
                        IMeasurement m = mea[j];
                        if (suff.Equals(m.Name))
                        {
                            return m;
                        }
                    }
                }
            }
            return null;
        }

        private void CreateArrays()
        {
            if (dx != null)
            {
                if (dx.Length > 0)
                {
                    auliliaryA = new double[dx.Length, dx.Length];
                    indxa = new int[dx.Length];
                }
            }
            if (sLeft.Count > 0)
            {
                left = new IMeasurement[sLeft.Count];
                right = new IMeasurement[sLeft.Count];
                r = new IMeasurement[left.Length, left.Length];
                if (sAliases.Count > 0)
                {
                    ht = new double[sAliases.Count, sLeft.Count];
                    htr = new double[sAliases.Count, sLeft.Count];
                }
            }
        }

        #endregion

        #endregion

        #region Constant Measure

        class ConstMeasurement : IMeasurement, IDerivation
        {
            const Double t = 0;
            private double c;
            const double z = 0;

            Func<object> par;
            Func<object> der;

            public ConstMeasurement(double c)
            {
                this.c = c;
                par = getP;
                der = getD;
            }

            #region IMeasurement Members

            Func<object> IMeasurement.Parameter
            {
                get { return par; }
            }

            string IMeasurement.Name
            {
                get { return "const" + c; }
            }

            object IMeasurement.Type
            {
                get { return t; }
            }

            #endregion

            object getP()
            {
                return c;
            }
            object getD()
            {
                return z;
            }

            #region IDerivation Members

            IMeasurement IDerivation.Derivation
            {
                get { return DataPerformer.Portable.Measurements.ConstantMeasurement.Zero; }
            }

            #endregion
        }

        #endregion

    }
}
