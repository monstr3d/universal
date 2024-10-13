using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using BaseTypes;

using Diagram.UI;

using DataPerformer.Interfaces;

using RealMatrixProcessor;
using DataPerformer.Portable.Measurements;

namespace DataPerformer.Helpers
{
    /// <summary>
    /// Kalman filter
    /// </summary>
    [Serializable()]
    public class KalmanFilter : ObjectsCollection, IMeasurements, IStarted, IPostSetArrow
    {
        #region Fields

        RealMatrix realMatrix = new();

        string trans = "";

        string meas = "";

        string covState = "";

        string covMea = "";

        //string covariationStr = "";


        string realMeasurements = "";

        IMeasurements[] inmea;

        IFiniteDerivationMatrix transitionObjectM;


        IFiniteDerivationMatrix measurementsM;

        double[] init;


        double[] diff;

        double[] meaDiff;

        double[] state;
        double[] delta;
        double[,] transition;
        double[,] covariation;
        double[,] initialCovariation;
        double[,] errorCovariation;
        double[,] coefficient;
        double[,] partialTrans;
        double[,] partialPeer;
        double[,] errorCovariationPeer;
        double[,] errorCovariationPeerPlus;
        double[] statePeer;
        double[,] covariationPeer;
        double[,] covariationPeerPlus;

        bool isSerialized = false;

        IMeasurement[] output;

        bool isUpdated = false;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public KalmanFilter()
            : base(typeof(object))
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected KalmanFilter(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            trans = info.GetString("Transition");
            meas = info.GetString("Measurements");
            realMeasurements = info.GetString("RealMeasurements");
            covState = info.GetString("CovariationState");
            covMea = info.GetString("CovariationMeasurements");
            init = info.GetValue("InitialState", typeof(double[])) as double[];
            initialCovariation = info.GetValue("InitialCovariation", typeof(double[,])) as double[,];
            diff = info.GetValue("Difference", typeof(double[])) as double[];
            meaDiff = info.GetValue("MeaDifference", typeof(double[])) as double[];
            isSerialized = true;
        }


        #endregion

        #region IStarted Members

        void IStarted.Start(double time)
        {
            Array.Copy(init, state, init.Length);
            for (int i = 0; i < initialCovariation.GetLength(0); i++)
            {
                for (int j = 0; j < initialCovariation.GetLength(1); j++)
                {
                    covariation[i, j] = initialCovariation[i, j];
                }
            }
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return output.Length; }
        }

        IMeasurement IMeasurements.this[int number]
        {
            get { return output[number]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            foreach (IMeasurements mea in inmea)
            {
                mea.UpdateMeasurements();
            }
            transitionObjectM.State = state;
            transition = transitionObjectM.Matrix();
            double[] st = transitionObjectM.Output;
            Array.Copy(st, state, state.Length);
            measurementsM.State = state;
            double[,] partial = measurementsM.Matrix();
            double[] y = measurementsM.Output;
            double[] y1 = inmea[0][0].Parameter() as double[];
            double[,] ec = inmea[1][0].Parameter() as double[,];
            double[,] mc = inmea[2][0].Parameter() as double[,];
            for (int i = 0; i < y.Length; i++)
            {
                delta[i] = y1[i] - y[i];
            }
            realMatrix.KalmanFilter(state, delta, transition, partial, covariation, ec, mc,
                coefficient, partialTrans, partialPeer, errorCovariationPeer, errorCovariationPeerPlus,
                statePeer, covariationPeer, covariationPeerPlus);
        }

        bool IMeasurements.IsUpdated
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

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Set(trans, meas, realMeasurements, covState, covMea);
            Set(init, diff, meaDiff);
            if (delta == null)
            {
                int[][] n = new int[][]{
                    FiniteMatrixDerivationTransformer.IsAccessible(transitionObjectM.Transformer),
                    FiniteMatrixDerivationTransformer.IsAccessible(measurementsM.Transformer)
                };
                CreateAdd(n);
            }
            isSerialized = false;
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Transition", trans);
            info.AddValue("Measurements", meas);
            info.AddValue("RealMeasurements", realMeasurements);
            info.AddValue("CovariationState", covState);
            info.AddValue("CovariationMeasurements", covMea);
            info.AddValue("InitialState", init, typeof(double[]));
            info.AddValue("InitialCovariation", initialCovariation, typeof(double[,]));
            info.AddValue("Difference", diff, typeof(double[]));
            info.AddValue("MeaDifference", meaDiff, typeof(double[]));
        }

        #endregion

        #region Members

        /// <summary>
        /// Transition
        /// </summary>
        public string Transition
        {
            get
            {
                return trans;
            }
        }

        /// <summary>
        /// Measurements
        /// </summary>
        public string Measurements
        {
            get
            {
                return meas;
            }
        }

        /// <summary>
        /// Real measurements
        /// </summary>
        public string RealMeasurements
        {
            get
            {
                return realMeasurements;
            }
        }

        /// <summary>
        /// Measurements of covariation matrix
        /// </summary>
        public string CovariationMeasurements
        {
            get
            {
                return covMea;
            }
        }


        /// <summary>
        /// Covariation of state vector
        /// </summary>
        public string CovariationState
        {
            get
            {
                return covState;
            }
        }

        /// <summary>
        /// Initial state
        /// </summary>
        public double[] InitialState
        {
            get
            {
                return init;
            }
        }

        /// <summary>
        /// Finite difference of state
        /// </summary>
        public double[] Difference
        {
            get
            {
                return diff;
            }
        }

        /// <summary>
        /// Finite difference of measurements
        /// </summary>
        public double[] MeaDifference
        {
            get
            {
                return meaDiff;
            }
        }

        /// <summary>
        /// Initial covariation matrix
        /// </summary>
        public double[,] InitialCovariation
        {
            get
            {
                return initialCovariation;
            }
        }

        /// <summary>
        /// Set parameters
        /// </summary>
        /// <param name="trans">Transition</param>
        /// <param name="meas">Measurements</param>
        /// <param name="realMeasurements">Real measurements</param>
        /// <param name="covState">Covariation of state vector</param>
        /// <param name="covMea">Measurements of covariation matrix</param>
        /// <returns>True in success and false otherwise</returns>
        public bool Set(string trans, string meas, string realMeasurements, string covState, string covMea)
        {
            string[] str = new string[] { trans, meas };
            IObjectTransformer[] tr = new IObjectTransformer[2];
            int[][] n = new int[2][];
            Diagram.UI.Interfaces.IComponentCollection cc = this;
            for (int i = 0; i < str.Length; i++)
            {
                IObjectTransformer trt = cc.GetCollectionObject<IObjectTransformer>(str[i]);
                int[] k = FiniteMatrixDerivationTransformer.IsAccessible(
                    cc.GetCollectionObject<IObjectTransformer>(str[i]));
                if (k == null)
                {
                    return false;
                }
                n[i] = k;
                tr[i] = trt;
            }
            if ((n[0][0] != n[0][1]) | (n[0][1] != n[1][0]))
            {
                return false;
            }
            IMeasurements[] mm = new IMeasurements[]
            {
                cc.GetCollectionObject<IMeasurements>(realMeasurements),
                cc.GetCollectionObject<IMeasurements>(covState),
                cc.GetCollectionObject<IMeasurements>(covMea)
            };
            ArrayReturnType[] art = new ArrayReturnType[3];
            Double a = 0;
            int[] d = new int[] { 1, 2, 2 };
            for (int i = 0; i < art.Length; i++)
            {
                IMeasurements mea = mm[i];
                if (mea == null)
                {
                    return false;
                }

                if (mea.Count != 1)
                {
                    return false;
                }
                object r = mea[0].Type;
                if (!(r is ArrayReturnType))
                {
                    return false;
                }
                ArrayReturnType att = r as ArrayReturnType;
                art[i] = att;
                if (!att.ElementType.Equals(a))
                {
                    return false;
                }
                if (att.Dimension.Length != d[i])
                {
                    return false;
                }
            }
            ArrayReturnType at = art[0];
            if (at.Dimension[0] != n[1][1])
            {
                return false;
            }
            at = art[1];
            if ((at.Dimension[0] != n[0][0]) | (at.Dimension[1] != n[0][0]))
            {
                return false;
            }
            at = art[2];
            if ((at.Dimension[0] != n[1][1]) | (at.Dimension[1] != n[1][1]))
            {
                return false;
            }
            inmea = mm;
            this.trans = trans;
            this.meas = meas;
            this.realMeasurements = realMeasurements;
            this.covState = covState;
            this.covMea = covMea;
            transitionObjectM = new FiniteMatrixDerivationTransformer(tr[0]);
            measurementsM = new FiniteMatrixDerivationTransformer(tr[1]);
            CreateMeas(n[1]);
            state = Create(n[0][0]);
            covariation = Create(n[0]);
            if (!isSerialized)
            {
                CreateArrays(n);
            }
            return true;
        }


        /// <summary>
        /// Sets real parameters
        /// </summary>
        /// <param name="init">Initial state</param>
        /// <param name="diff">Finite difference of state</param>
        /// <param name="meaDiff">Finite difference of measurements</param>
        public void Set(double[] init, double[] diff, double[] meaDiff)
        {
            Array.Copy(init, this.init, init.Length);
            Array.Copy(diff, this.diff, diff.Length);
            Array.Copy(meaDiff, this.meaDiff, meaDiff.Length);
            transitionObjectM.FiniteDifference = diff;
            measurementsM.FiniteDifference = meaDiff;
        }


        #endregion

        #region Private Members

        object GetState()
        {
            return state;
        }

        object GetMatrix()
        {
            return covariation;
        }


        void CreateArrays(int[][] n)
        {
            int k = n[0][0];
            int l = n[1][1];
            init = Create(k);
            initialCovariation = Create(n[0]);
            diff = Create(k, 1e-6);
            meaDiff = Create(k, 1e-6);
            CreateAdd(n);
        }

        void CreateAdd(int[][] n)
        {
            int k = n[0][0];
            int l = n[1][1];
            delta = Create(l);
            state = Create(k);
            transition = Create(n[0]);
            errorCovariation = Create(n[0]);
            coefficient = new double[k, l];
            partialTrans = new double[k, l];
            partialPeer = Create(n[1]);
            errorCovariationPeer = new double[l, l];
            errorCovariationPeerPlus = new double[l, l];
            statePeer = new double[k];
            covariationPeer = Create(n[0]);
            covariationPeerPlus = Create(n[0]);

        }

        double[] Create(int n)
        {
            return new double[n];
        }

        double[] Create(int n, double val)
        {
            double[] x = new double[n];
            for (int i = 0; i < n; i++)
            {
                x[i] = val;
            }
            return x;
        }

        double[,] Create(int[] n)
        {
            return new double[n[0], n[1]];
        }

        void CreateMeas(int[] n)
        {
            Double a = 0;
            output = new IMeasurement[] {
                new Measurement(new ArrayReturnType(a, new int[]{n[0]}, false), GetState, "State", this),
                new Measurement(new ArrayReturnType(a, new int[]{n[0], n[0]}, false), GetMatrix, "Covariation", this)
            };
        }



        #endregion
    }
}
