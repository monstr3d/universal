﻿using System;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using CategoryTheory;

using Diagram.UI;


using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;
using ErrorHandler;
using NamedTree;



namespace DataPerformer.Portable.Advanced
{
    public class DynamicFunction : Abstract.AbstractDataTransformer, IStarted, ITimeMeasurementConsumer, IPostSetArrow
    {

        #region Fields

        const Double a = 0;

        protected string x = "";

        protected int size = 1;

        protected int degree = 0;

        FunctionDyn[] fd = new FunctionDyn[0];

        List<FunctionDyn> lfd = new List<FunctionDyn>();

        IMeasurement arg;

        int[] global = new int[3];

        IMeasurement time;

        double to;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DynamicFunction()
        {
            time = DataPerformer.Portable.StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement;
        }



        #endregion

        #region IMeasurements Members

        /// <summary>
        /// Updates measurements data
        /// </summary>
        public override void UpdateMeasurements()
        {
            double t = (double)time.Parameter();
            if (t == to)
            {
                return;
            }
            foreach (FunctionDyn f in fd)
            {
                f.Step();
            }
            global[2] = 0;
            to = t;
        }


        #endregion

        #region IStarted Members

        void IStarted.Start(double time)
        {
            Clear();
            global[0] = 0;
            global[1] = 1;
            global[2] = 0;
            to = time + 1;
        }


        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Post();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Approxamation degeree
        /// </summary>
        public int Degree
        {
            get
            {
                return degree;
            }
            set
            {
                if (value >= size)
                {
                    this.Throw("Degree shoud be strongly less than size");
                }
                degree = value;
                foreach (FunctionDyn f in fd)
                {
                    f.Degree = value;
                }
            }
        }

        /// <summary>
        /// Approxamation degeree
        /// </summary>
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                if (degree >= size)
                {
                    Degree = size - 1;
                }
                foreach (FunctionDyn f in fd)
                {
                    f.size = value;
                }
            }
        }

        /// <summary>
        /// Argument
        /// </summary>
        public string Argument
        {
            get
            {
                return x;
            }
            set
            {
                if (x.Equals(value))
                {
                    return;
                }
                x = value;
                Post();
            }
        }

        #endregion

        #region Private Members

        IMeasurement CreateMeasure(string preffix, IMeasurement m, object obj)
        {
            string n = m.Name;
            FunctionDyn f = new FunctionDyn(arg, m, global);
            f.size = size;
            lfd.Add(f);
            return new Measurement(f, () => f, preffix + n, obj);
        }

        void Post()
        {
            lfd.Clear();
            arg = this.FindMeasurement(x, true);
            if (arg == null)
            {
                x = "";
                this.Throw(new OwnException("Undefined argument"));
            }
            if (!arg.Type.Equals(a))
            {
                x = "";
                this.Throw(new OwnException("Argument shoud be real"));
            }
            List<IMeasurement> l = new List<IMeasurement>();
            foreach (IMeasurements mea in measurements)
            {
                string preffix = this.GetRelativeName(mea as IAssociatedObject);
                preffix = preffix.Replace("/", "_") + "_";
                int n = mea.Count;
                for (int i = 0; i < n; i++)
                {
                    l.Add(CreateMeasure(preffix, mea[i], this));
                }
            }
            Size = size;
            base.mea = l.ToArray();
            fd = lfd.ToArray();
            lfd.Clear();
            Degree = degree;
        }

        void Clear()
        {
            foreach (FunctionDyn f in fd)
            {
                f.Clear();
            }
        }

        #endregion

        #region Time function class

        /// <summary>
        /// Helper class for dynamical function
        /// </summary>
        class FunctionDyn : IOneVariableFunction
        {
            #region Fields

            const Double a = 0;

            List<object[]> l = new List<object[]>();

            internal int size;

            int degree;

            object type;

            object valType;

            IMeasurement arg;

            IMeasurement val;

            Func<int, int, double, object> GetResult;

            int[] global;





            #endregion

            #region Ctor

            internal FunctionDyn(IMeasurement arg, IMeasurement val, int[] global)
            {
                this.arg = arg;
                this.val = val;
                type = arg.Type;
                valType = val.Type;
                this.global = global;
                SetDefaultFunc();
            }


            #endregion

            #region Members

            internal void Step()
            {
                double x = (double)arg.Parameter();
                if (size > 0)
                {
                    if (l.Count >= size)
                    {
                        l.RemoveAt(0);
                    }
                }
                l.Add(new object[] { x, val.Parameter() });
            }

            internal void Clear()
            {
                l.Clear();
            }

            internal int Degree
            {
                get
                {
                    return degree;
                }
                set
                {
                    degree = value;
                    SetDegree();
                }
            }

            void SetDefaultFunc()
            {
                GetResult = (int i, int j, double x) => l[i][1];
            }

            void SetDegree()
            {
                SetDefaultFunc();
                Double a = 0;
                if (!valType.Equals(a))
                {
                    return;
                }
                if (degree == 1)
                {
                    GetResult = GetLinear;
                }
                else
                {
                    GetResult = GetInrepolation;
                }
            }

            object GetLinear(int i, int j, double arg)
            {
                object[] o = l[i];
                double x1 = (double)o[0];
                double y1 = (double)o[1];
                o = l[j];
                double x2 = (double)o[0];
                double y2 = (double)o[1];
                return y1 + ((y2 - y1) * (arg - x1)) / (x2 - x1);
            }

            object GetInrepolation(int i, int j, double arg)
            {
                int k = j - degree;
                if (k < 0)
                {
                    k = 0;
                }
                return rm.LagrangeInterpolation(arg, degree, k, l);
            }


            object GetValue(double arg)
            {
                return GetResult(0, 1, arg);
            }

            #endregion

            #region IOneVariableFunction Members

            object IOneVariableFunction.VariableType
            {
                get { return type; }
            }

            #endregion

            #region IObjectOperation Members

            object[] IObjectOperation.InputTypes
            {
                get { return new object[] { (double)0 }; }
            }

            object IObjectOperation.this[object[] x]
            {
                get { return GetValue((double)x[0]); }
            }

            object IObjectOperation.ReturnType
            {
                get { return type; }
            }

            #endregion
        }

        #endregion

        #region ITimeMeasurementConsumer Members

        IMeasurement ITimeMeasurementConsumer.Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }

        #endregion
    }
}