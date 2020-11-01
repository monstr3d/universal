using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

using Vector3D;

using Motion6D.Interfaces;

namespace Motion6D.Portable
{
    /// <summary>
    /// Differential equation realated to aggregate
    /// </summary>
    public class MechanicalAggregateEquation : IDifferentialEquationSolver, IStarted
    {

        #region Fields

        /// <summary>
        /// Wrapper of aggregate
        /// </summary>
        protected AggregableWrapper wrapper;
        
        /// <summary>
        /// Root aggregate
        /// </summary>
        protected IAggregableMechanicalObject aggregate;

        /// <summary>
        /// Numbers of aggregates
        /// </summary>
        protected Dictionary<IAggregableMechanicalObject, int> numbers = 
            new Dictionary<IAggregableMechanicalObject, int>();

        /// <summary>
        /// Links if aggregates
        /// </summary>
        protected List<MechanicalAggregateLink> links = new List<MechanicalAggregateLink>();

        /// <summary>
        /// Vector of inverted accelerations
        /// </summary>
        protected double[] vector;

        /// <summary>
        /// Inverted marix of acceleration
        /// </summary>
        protected double[,] matrix;

        /// <summary>
        /// Helper array for linear system solving
        /// </summary>
        protected int[] indx;

        /// <summary>
        /// Degrees of freedom
        /// </summary>
        protected int deg = 0;

        /// <summary>
        /// Indexes of aggregates
        /// </summary>
        protected int[] indexes;

        /// <summary>
        /// Aggregate wrappe
        /// </summary>
        protected AggregableWrapper[] aggrWrappres;

        /// <summary>
        /// Aggregates
        /// </summary>
        protected IAggregableMechanicalObject[] aggregates;

        /// <summary>
        /// Auxiliary quaternion
        /// </summary>
        protected double[] auxQuaternion = new double[4];

        /// <summary>
        /// Links
        /// </summary>
        protected List<int[]> linkNumbers = new List<int[]>();


        /// <summary>
        /// Array of links
        /// </summary>
        protected int[][] linkArray;

        /// <summary>
        /// List of aggregates
        /// </summary>
        protected List<AggregableWrapper> list 
            = new List<AggregableWrapper>();

        /// <summary>
        /// 
        /// </summary>
        protected List<IAggregableMechanicalObject> lm
            = new List<IAggregableMechanicalObject>();

        /// <summary>
        /// Derivations
        /// </summary>
        protected double[,] derivations;

        /// <summary>
        /// Measures
        /// </summary>
        protected IMeasurement[] measures;
        
        /// <summary>
        /// Quaternion
        /// </summary>
        protected double[] quater = new double[4];

        /// <summary>
        /// Angular velocity
        /// </summary>
        protected double[] omega = new double[3];

        /// <summary>
        /// Helper array
        /// </summary>
        protected double[] der = new double[4];

        /// <summary>
        /// Helper array
        /// </summary>
        protected double[,] qq = new double[4, 4];
        

        /// <summary>
        /// Dictionary of links
        /// </summary>
        protected Dictionary<AggregableWrapper, Dictionary<AggregableWrapper, int[]>> dict =
            new Dictionary<AggregableWrapper, Dictionary<AggregableWrapper, int[]>>();

        /// <summary>
        /// Dictionary of numbers
        /// </summary>
        protected Dictionary<AggregableWrapper, Dictionary<AggregableWrapper, int>> dictn =
            new Dictionary<AggregableWrapper, Dictionary<AggregableWrapper, int>>();

        /// <summary>
        /// Numbers dictionary
        /// </summary>
        protected Dictionary<IAggregableMechanicalObject, Dictionary<IAggregableMechanicalObject, int>> dictna =
            new Dictionary<IAggregableMechanicalObject, Dictionary<IAggregableMechanicalObject, int>>();

        /// <summary>
        /// Transforms forces to accelerations
        /// </summary>
        protected double[,] forcesToAccelerations;

        /// <summary>
        /// Transforms acceletations to connetion accelerations
        /// </summary>
        protected double[,] accelerationTransition;

        /// <summary>
        /// Forces in connections
        /// </summary>
        protected double[] connectionForces;

        /// <summary>
        /// Residues in connections
        /// </summary>
        protected double[] connectionResidues;


        /// <summary>
        /// Additional acceleration
        /// </summary>
        protected double[] addAcceleration;

        /// <summary>
        /// 6D Auxiliary vector
        /// </summary>
        protected double[] v6d = new double[6];


        private double[] gloVector;


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="aggregate">Root aggregate</param>
        protected MechanicalAggregateEquation(AggregableWrapper aggregate)
        {
            wrapper = aggregate;
            this.aggregate = wrapper.Aggregate;
            PreInit();
            Init();
        }

        #endregion

        #region IDifferentialEquationSolver Members

        void IDifferentialEquationSolver.CalculateDerivations()
        {
            Normalize(aggregate);
            foreach (AggregableWrapper aw in aggrWrappres)
            {
                IAggregableMechanicalObject obj = aw.Aggregate;
                if (obj is IUpdatableObject)
                {
                    IUpdatableObject uo = obj as IUpdatableObject;
                    if (uo.Update != null)
                    {
                        uo.Update();
                    }
                }
            }
            Solve();
            int n = 0;
            int kv = 0;
            for (int i = 0; i < aggrWrappres.Length; i++)
            {
                AggregableWrapper wrapper = aggrWrappres[i];
                IAggregableMechanicalObject agg = wrapper.Aggregate;
                Motion6DAcceleratedFrame frame = wrapper.OwnFrame;
                IVelocity vel = frame;
                IAcceleration acc = frame;
                IPosition pos = frame;
                double[] state = agg.State;
                double[] p = pos.Position;
                double[] v = vel.Velocity;
                for (int j = 0; j < 3; j++)
                {
                    p[j] = state[j];
                    derivations[n + j, 0] = state[j];
                    double a = state[j + 3];
                    v[j] = a;
                    derivations[n + j, 1] = a;
                    derivations[n + 3 + j, 0] = a;
                    derivations[n + 3 + j, 1] = vector[kv];
                    ++kv;
                }
                IOrientation or = frame;
                double[] q = or.Quaternion;
                for (int j = 0; j < 4; j++)
                {
                    double a = state[j + 6];
                    quater[j] = a;
                    q[j] = a;
                }
                IAngularVelocity av = frame;
                double[] om = av.Omega;
                for (int j = 0; j < 3; j++)
                {
                    double a = state[j + 10];
                    omega[j] = a;
                    om[j] = a;
                }
                StaticExtensionVector3D.CalculateQuaternionDerivation(quater, omega, der, auxQuaternion);
                for (int j = 0; j < 4; j++)
                {
                    derivations[n + 6 + j, 0] = quater[j];
                    derivations[n + 6 + j, 1] = der[j];
                }
                for (int j = 0; j < 3; j++)
                {
                    derivations[n + 10 + j, 0] = omega[j];
                    derivations[n + 10 + j, 1] = vector[kv];
                    ++kv;
                }
                int kk = n + 13;
                int stk = kk;
                int stv = 6;
                int sk = 13;
                for (int j = 13; j < agg.Dimension; j++)
                {
                    derivations[kk, 0] = state[sk];
                    double a = state[sk + 1];
                    derivations[kk, 1] = a;
                    ++kk;
                    ++stk;
                    ++sk;
                    derivations[kk, 0] = a;
                    derivations[kk, 1] = vector[kv];
                    ++sk;
                    ++kv;
                    ++stv;
                    ++kk;
                    ++j;

                }
                n += agg.Dimension;
            }
        }

        void IDifferentialEquationSolver.CopyVariablesToSolver(int offset, double[] variables)
        {
            int n = offset;
            for (int i = 0; i < aggrWrappres.Length; i++)
            {
                AggregableWrapper aw = aggrWrappres[i];
                IAggregableMechanicalObject ao = aw.Aggregate;
                double[] state = ao.State;
                for (int j = 0; j < state.Length; j++)
                {
                    double a = variables[n];
                    state[j] = a;
                    if (j < measures.Length)
                    {
                        AggergateDerivation der = measures[j] as AggergateDerivation;
                        der.Set(j, a);
                    }
                    ++n;
                }
                Motion6DAcceleratedFrame frame = aw.OwnFrame;
                IOrientation or = frame;
                Array.Copy(state, 6, or.Quaternion, 0, 4);
                IAngularVelocity w = frame;
                Array.Copy(state, 10, w.Omega, 0, 3);
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

        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return true;
            }
            set
            {

            }
        }

        #endregion

        #region IStarted Members

        void IStarted.Start(double time)
        {
            Reset();
            if (aggregate is IStarted)
            {
                IStarted s = aggregate as IStarted;
                s.Start(time);
            }

            Normalize(aggregate);
            IDifferentialEquationSolver so = this;
            so.CalculateDerivations();
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// The comparation
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns>True if equals</returns>
        public override bool Equals(object obj)
        {
            if (obj is MechanicalAggregateEquation)
            {
                MechanicalAggregateEquation eq = obj as MechanicalAggregateEquation;
                return eq.aggregate == aggregate;
            }
            return false;
        }

        /// <summary>
        /// Gets hash code
        /// </summary>
        /// <returns>The hash code</returns>
        public override int GetHashCode()
        {
            return aggregate.GetHashCode();
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Root aggegates of desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>Root aggregates</returns>
        public static ICollection<AggregableWrapper> GetRootAggregates(IEnumerable<object> desktop)
        {
            IEnumerable<object> objs = desktop.GetObjectsAndArrows();
            List<AggregableWrapper> l = new List<AggregableWrapper>();
            foreach (object o in objs)
            {
                if (!(o is AggregableWrapper))
                {
                    continue;
                }
                AggregableWrapper agg = o as AggregableWrapper;
                if (agg.Aggregate.Parent == null)
                {
                    if (!l.Contains(agg))
                    {
                        l.Add(agg);
                    }
                }
            }
            return l;
        }


 
        /// <summary>
        /// Normalizes aggregate
        /// </summary>
        /// <param name="aggregate">The aggregate for normalizing</param>
        protected static void Normalize(IAggregableMechanicalObject aggregate)
        {
            if (aggregate is INormalizable)
            {
                INormalizable n = aggregate as INormalizable;
                n.Normalize();
            }
            Dictionary<IAggregableMechanicalObject, int[]> d = aggregate.Children;
            if (d == null)
            {
                return;
            }
            foreach (IAggregableMechanicalObject agg in d.Keys)
            {
                int[] n = d[agg];
                agg[n[0]] = aggregate[n[1]];
                Normalize(agg);
            }
        }

        /// <summary>
        /// Solves equation
        /// </summary>
        protected virtual void Solve()
        {
            int k = 0;
            for (int i = 0; i < aggrWrappres.Length; i++)
            {
                AggregableWrapper frame = aggrWrappres[i];
                IAggregableMechanicalObject agg = frame.Aggregate;
                double[] intacc = agg.InternalAcceleration;
                int l = intacc.Length;
                Array.Copy(intacc, 0, vector, k, l);
                k += l;
            }
            if (matrix.GetLength(0) != 0)
            {
                CalculateLinkAccelerations();
                RealMatrixProcessor.RealMatrix.PlusEqual(vector, addAcceleration);
                for (int ln = 0; ln < links.Count; ln++)
                {
                    MechanicalAggregateLink ml = links[ln];
                    IAggregableMechanicalObject s = ml.SourceObject;
                    IAggregableMechanicalObject t = ml.TargetObject;
                    int sc = ml.SourceConnection;
                    int tc = ml.TargetConnection;
                    int sn = numbers[s];
                    int tn = numbers[t];
                    Add(s, t, sc, tc, tn);
                    Add(t, s, tc, sc, sn);
                  }
            }
        }

        /// <summary>
        /// Creates dictionary of aggregate
        /// </summary>
        /// <param name="aggregate">The aggregate</param>
        /// <param name="dic">The dictionary</param>
        /// <param name="deg">Degrees of freedom</param>
        /// <param name="add">Additional variables</param>
        /// <param name="acc">Akseleration number</param>
        private void CreateDictionary(AggregableWrapper aggregate,
            Dictionary<AggregableWrapper, Dictionary<AggregableWrapper, int[]>> dic,
            ref int deg, ref int add, ref int acc)
        {
            IAggregableMechanicalObject aggr = aggregate.Aggregate;
            numbers[aggr] = acc;
            int kd = add;
            int d0 = deg;
            deg += aggr.Dimension;
            list.Add(aggregate);
            lm.Add(aggr);
            acc += GetAcceleationDimension(aggr);
            Dictionary<IAggregableMechanicalObject, int[]> ch = aggr.Children;
            if (ch == null)
            {
                return;
            }
            if (ch.Count == 0)
            {
                return;
            }
            Dictionary<AggregableWrapper, int[]> d = new Dictionary<AggregableWrapper, int[]>();
            Dictionary<AggregableWrapper, int> dn = new Dictionary<AggregableWrapper, int>();
            Dictionary<IAggregableMechanicalObject, int> dna = new Dictionary<IAggregableMechanicalObject, int>();
            dictn[aggregate] = dn;
            dictna[aggregate.Aggregate] = dna;
            dic[aggregate] = d;
            foreach (IAggregableMechanicalObject agg in ch.Keys)
            {
                AggregableWrapper aw = FindWrapper(agg);
                int[] nc = ch[agg];
                d[aw] = nc;
                dn[aw] = add;
                dna[agg] = add;
                ++add;
                linkNumbers.Add(new int[] { kd, add, nc[1], nc[0], d0, deg });
                CreateDictionary(aw, dic, ref deg, ref add, ref acc);
            }
        }

        /// <summary>
        /// Finds wrapper of aggregable mechanical object
        /// </summary>
        /// <param name="obj">The aggregable mechanical object</param>
        /// <returns>The wrapper</returns>
        protected AggregableWrapper FindWrapper(IAggregableMechanicalObject obj)
        {
            IAssociatedObject ao = obj as IAssociatedObject;
            IObjectLabel l = ao.Object as IObjectLabel;
            IDesktop d = l.Desktop;
            IEnumerable<ICategoryObject> objs = d.CategoryObjects;
            foreach (ICategoryObject ob in objs)
            {
                if (ob is AggregableWrapper)
                {
                    AggregableWrapper wr = ob as AggregableWrapper;
                    if (wr.Aggregate == obj)
                    {
                        return wr;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Acceleration vector
        /// </summary>
        protected virtual double[] Vector
        {
            get
            {
                return vector;
            }
        }


        /// <summary>
        /// Pre initialization
        /// </summary>
        protected virtual void PreInit()
        {
            int add = 0;
            int acc = 0;
            numbers.Clear();
            CreateDictionary(wrapper, dict, ref deg, ref add, ref acc);
            links.Clear();
            List<MechanicalAggregateLink> l = MechanicalAggregateLink.Links;
            foreach (MechanicalAggregateLink ml in l)
            {
                foreach (IAggregableMechanicalObject amo in numbers.Keys)
                {
                    if ((ml.SourceObject) == amo | (ml.TargetObject == amo))
                    {
                        if (!links.Contains(ml))
                        {
                            links.Add(ml);
                        }
                        continue;
                    }
                }
            }
            int n = acc;
            vector = new double[n];
            addAcceleration = new double[n];
            int conn = 6 * links.Count;
            matrix = new double[conn, conn];
            forcesToAccelerations = new double[n, conn];
            accelerationTransition = new double[conn, n];
            connectionForces = new double[conn];
            connectionResidues = new double[conn];
            indx = new int[n];
            aggrWrappres = list.ToArray();
            
        }


        /// <summary>
        /// Initialization
        /// </summary>
        protected virtual void Init()
        {
            List<IAggregableMechanicalObject> lo = new List<IAggregableMechanicalObject>();
            foreach (AggregableWrapper aw in aggrWrappres)
            {
                lo.Add(aw.Aggregate);
            }
            aggregates = lo.ToArray();
            indexes = new int[aggrWrappres.Length];
            int kn = 0;
            int nn = 0;
            for (int i = 0; i < indexes.Length; i++)
            {
                int dd = aggrWrappres[i].Aggregate.Dimension;
                indexes[i] = kn;
                kn += aggrWrappres[i].Aggregate.Dimension;
                nn += dd;
            }
            derivations = new double[nn, 2];
            foreach (IAggregableMechanicalObject amo in aggregates)
            {
                if (amo is IStarted)
                {
                    IStarted st = amo as IStarted;
                    st.Start(0);
                }
            }
            IDifferentialEquationSolver s = this;
            Set(ref measures, derivations);
            s.CalculateDerivations();
        }


        private static void Set(ref IMeasurement[] measures, double[,] derivations)
        {
            if (measures == null)
            {
                measures = new IMeasurement[derivations.GetLength(0)];
                for (int i = 0; i < measures.Length; i++)
                {
                    measures[i] = new AggergateDerivation(derivations, i);
                }
                return;
            }
            IMeasurement[] old = measures;
            if (measures.Length != old.Length)
            {
                measures = new IMeasurement[derivations.Length];
            }
            for (int i = 0; i < measures.Length; i++)
            {
                if (i < old.Length)
                {
                    AggergateDerivation d = old[i] as AggergateDerivation;
                    d.Set(i, derivations);
                    measures[i] = d;
                    continue;
                }
                measures[i] = new AggergateDerivation(derivations, i);
            }
        }


        /// <summary>
        /// Gets dimension of aggregate acelerations
        /// </summary>
        /// <param name="aggeregate">The aggregate</param>
        /// <returns>Dimension of aceleration vector</returns>
        public static int GetAcceleationDimension(IAggregableMechanicalObject aggeregate)
        {
            return (aggeregate.Dimension - 1) / 2;
        }


 
        /// <summary>
        /// Calculates matrixes
        /// </summary>
        protected void CalculateMatrixes()
        {
            int n = vector.Length;
            int conn = connectionForces.Length;
            for (int i = 0; i < conn; i++)
            {
                for (int j = 0; j < conn; j++)
                {
                    matrix[i, j] = 0;
                }
                for (int j = 0; j < n; j++)
                {
                    forcesToAccelerations[j, i] = 0;
                    accelerationTransition[i, j] = 0;
                }
            }
            for (int ln = 0; ln < links.Count; ln++)
            {
                int k = ln * 6;
                MechanicalAggregateLink ml = links[ln];
                IAggregableMechanicalObject s = ml.SourceObject;
                IAggregableMechanicalObject t = ml.TargetObject;
                int sc = ml.SourceConnection;
                int tc = ml.TargetConnection;
                int sn = numbers[s];
                int tn = numbers[t];
                int ss = ml.SourceConnection;
                int tt = ml.TargetConnection;
                Fill(accelerationTransition, s.GetAccelerationMatrix(ss), k, sn);
                FillMinus(accelerationTransition, t.GetAccelerationMatrix(tt), k, tn);
                Fill(forcesToAccelerations, s.GetForcesMatrix(ss), sn, k);
                FillMinus(forcesToAccelerations, t.GetForcesMatrix(tt), tn, k);
            }
            RealMatrixProcessor.RealMatrix.Multiply(accelerationTransition, forcesToAccelerations, matrix);
        }

        /// <summary>
        /// Calculates residues of accelerations
        /// </summary>
        protected void CalculateResidues()
        {
            for (int ln = 0; ln < links.Count; ln++)
            {
                int k = ln * 6;
                MechanicalAggregateLink ml = links[ln];
                IAggregableMechanicalObject s = ml.SourceObject;
                IAggregableMechanicalObject t = ml.TargetObject;
                int sc = ml.SourceConnection;
                int tc = ml.TargetConnection;
                double[] sa = s.GetInternalAcceleration(sc);
                double[] ta = t.GetInternalAcceleration(tc);
                for (int i = 0; i < 6; i++)
                {
                    connectionResidues[i + k] = sa[i] - ta[i];
                }
            }
      }

        /// <summary>
        /// Calculates Link accelerations
        /// </summary>
        protected virtual void CalculateLinkAccelerations()
        {
        }


        private void AddLinkAccelerations()
        {

        }




        /// <summary>
        /// Fills matrix by Submatrix
        /// </summary>
        /// <param name="x">Submatrix</param>
        /// <param name="y">Matrix</param>
        /// <param name="offsetRow">Row offset</param>
        /// <param name="offsetColumn">Column offset</param>
        public static void Fill(double[,] x, double[,] y, int offsetRow, int offsetColumn)
        {
            for (int i = 0; i < y.GetLength(0); i++)
            {
                for (int j = 0; j < y.GetLength(1); j++)
                {
                    x[offsetRow + i, offsetColumn + j] = y[i, j];
                }
            }
        }

        /// <summary>
        /// Fills matrix by Submatrix with minus sign
        /// </summary>
        /// <param name="x">Submatrix</param>
        /// <param name="y">Matrix</param>
        /// <param name="offsetRow">Row offset</param>
        /// <param name="offsetColumn">Column offset</param>
        public static void FillMinus(double[,] x, double[,] y, int offsetRow, int offsetColumn)
        {
            for (int i = 0; i < y.GetLength(0); i++)
            {
                for (int j = 0; j < y.GetLength(1); j++)
                {
                    x[offsetRow + i, offsetColumn + j] = -y[i, j];
                }
            }
        }






        /// <summary>
        /// Creates aggregate equation
        /// </summary>
        /// <param name="aggregate">Root aggregate</param>
        /// <returns>Aggregate equation</returns>
        internal static MechanicalAggregateEquation CreateAggregateEquation(AggregableWrapper aggregate)
        {
            if (IsConstant(aggregate.Aggregate))
            {
                return new RigidMechanicalAggregateEquation(aggregate);
            }
            return new MechanicalAggregateEquation(aggregate);
        }


        /// <summary>
        /// Checks whether aggregate and all its children are constants
        /// </summary>
        /// <param name="aggregate">The aggregate</param>
        /// <returns>Result of checking</returns>
        static bool IsConstant(IAggregableMechanicalObject aggregate)
        {
            if (!aggregate.IsConstant)
            {
                return false;
            }
            foreach (IAggregableMechanicalObject ob in aggregate.Children.Keys)
            {
                if (!IsConstant(ob))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Creates solvers of desktop
        /// </summary>
        /// <param name="dict">The dictionary of solvers</param>
        /// <param name="desktop">The desktop</param>
        /// <returns>The collection</returns>
        internal static void GetSolvers(Dictionary<AggregableWrapper, MechanicalAggregateEquation> dict, IEnumerable<object> desktop)
        {
            ICollection<AggregableWrapper> coll = GetRootAggregates(desktop);
            foreach (AggregableWrapper o in coll)
            {
                if (dict.ContainsKey(o))
                {
                    continue;
                }
                dict[o] = CreateAggregateEquation(o);
            }
        }

        /// <summary>
        /// Resets itself
        /// </summary>
        internal void Reset()
        {
            Reset(aggregate);
        }

        private static void Add(double[,] m, double[] x, double[] y, double[] z, int offset)
        {
            for (int i = 0; i < y.Length; i++)
            {
                double a = 0;
                for (int j = 0; j < 6; j++)
                {
                    a += m[i, j] * x[j];
                }
                y[i] += a;
                z[i + offset] += a;
            }
         }

        private void Add(IAggregableMechanicalObject source, IAggregableMechanicalObject target, int sc, int tc, int tn)
        {
            double[] fs = source.GetConnectionForce(sc);
            double[,] mt = target.GetForcesMatrix(tc);
            double[] intt = target.InternalAcceleration;
            Add(mt, fs, intt, vector, tn);
        }



        private static void Reset(IAggregableMechanicalObject aggregate)
        {
            double[] intacc = aggregate.InternalAcceleration;
            if (intacc != null)
            {
                for (int i = 0; i < intacc.Length; i++)
                {
                    intacc[i] = 0;
                }
            }
            foreach (IAggregableMechanicalObject ao in aggregate.Children.Keys)
            {
                Reset(ao);
            }
        }

        #endregion

        #region Aggregate Derivation Class

        class AggergateDerivation : IMeasurement, IDerivation
        {
            #region Fields

            double[,] x;

            int i;

            static private Double type = 0;

            Func<object> par;

            IMeasurement derivation;


            #endregion

            #region Ctor

            internal AggergateDerivation(double[,] x, int i)
            {
                this.x = x;
                this.i = i;
                par = getValue;
                derivation = new Measurement(getDerivation, "");
            }



            #endregion


            #region IMeasurement Members

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
                get { return type; }
            }

            #endregion

            #region IDerivation Members

            IMeasurement IDerivation.Derivation
            {
                get { return derivation; }
            }

            #endregion

            #region Specific Members

            object getValue()
            {
                return x[i, 0];
            }

            object getDerivation()
            {
                return x[i, 1];
            }

            internal void Set(int i, double[,] x)
            {
                this.i = i;
                this.x = x;
            }
            
            internal void Set(int i, double a)
            {
                x[i, 0] = a;
            }


            #endregion


        }

        #endregion

        #region IStateDoubleVariables Members

        List<string> IStateDoubleVariables.Variables
        {
            get
            {
                int n = 0;
                for (int i = 0; i < aggrWrappres.Length; i++)
                {
                    AggregableWrapper aw = aggrWrappres[i];
                    IAggregableMechanicalObject ao = aw.Aggregate;
                    double[] state = ao.State;
                    n += state.Length;
                }
                List<string> l = new List<string>();
                for (int i = 0; i < n; i++)
                {
                    l.Add("var_" + i);
                }
                if (gloVector == null)
                {
                    gloVector = new double[n];
                }
                else if (gloVector.Length != n)
                {
                    gloVector = new double[n];
                }
                return l;
            }
        }


        double[] IStateDoubleVariables.Vector
        {
            get
            {
                int n = 0;
                for (int i = 0; i < aggrWrappres.Length; i++)
                {
                    AggregableWrapper aw = aggrWrappres[i];
                    IAggregableMechanicalObject ao = aw.Aggregate;
                    double[] state = ao.State;
                    for (int j = 0; j < state.Length; j++)
                    {
                        gloVector[n] = state[j];
                        ++n;
                    }
                }
                return gloVector;
            }
            set
            {
                int n = 0;
                for (int i = 0; i < aggrWrappres.Length; i++)
                {
                    AggregableWrapper aw = aggrWrappres[i];
                    IAggregableMechanicalObject ao = aw.Aggregate;
                    double[] state = ao.State;
                    for (int j = 0; j < state.Length; j++)
                    {
                        state[j] = value[n];
                        ++n;
                    }
                }
            }
        }

        void IStateDoubleVariables.Set(double[] input, int offset, int length)
        {
            int n = 0;
            for (int i = 0; i < aggrWrappres.Length; i++)
            {
                AggregableWrapper aw = aggrWrappres[i];
                IAggregableMechanicalObject ao = aw.Aggregate;
                double[] state = ao.State;
                for (int j = 0; j < state.Length; j++)
                {
                    state[j] = input[n + offset];
                    ++n;
                    if (n >= length)
                    {
                        return;
                    }
                }
            }
        }

        #endregion
    }
}
