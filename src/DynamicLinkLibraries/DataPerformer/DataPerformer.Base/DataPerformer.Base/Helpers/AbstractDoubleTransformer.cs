using System;
using System.Collections.Generic;

using CategoryTheory;

using BaseTypes;

using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Interfaces;
using DataPerformer.Portable;

using NamedTree;

namespace DataPerformer.Helpers
{
    /// <summary>
    /// Abstrat transformer of double variables
    /// </summary>
    public abstract class AbstractDoubleTransformer : IAssociatedObject, IObjectTransformer, IPostSetArrow, IDisposable
    {
        #region Fields

        /// <summary>
        /// Collection of objects
        /// </summary>
        protected IObjectCollection collection;


        static readonly private string[][] inout = new string[][] { new string[] { "Input" }, new string[] { "Output" } };

        /// <summary>
        /// Objet type
        /// </summary>
        protected ArrayReturnType type;

        /// <summary>
        /// Strategy
        /// </summary>
        protected IDataRuntimeFactory strategy;

        /// <summary>
        /// Double type
        /// </summary>
        protected const Double a = 0;


        object obj;

        bool isDisposed = false;

        Action<object> act;

        /// <summary>
        /// Output buffer
        /// </summary>
        protected double[] outbuffer;

        /// <summary>
        /// Runtime
        /// </summary>
        protected IDataRuntime runtime;

        #endregion

        #region Ctor

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="collection">Collection</param>
        protected AbstractDoubleTransformer(IObjectCollection collection)
        {
            runtime = StaticExtensionDataPerformerPortable.Factory.Create(collection, 0);
            this.collection = collection;
            SetEvents();
            type = new ArrayReturnType(a, new int[] { 1 }, true);
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

        #region IObjectTransformer Members

        string[] IObjectTransformer.Input
        {
            get { return inout[0]; }
        }

        /// <summary>
        /// Output variables
        /// </summary>
        public virtual string[] Output
        {
            get { return inout[1]; }
        }

        object IObjectTransformer.GetInputType(int i)
        {
            return type;
        }

        /// <summary>
        /// Gets type of i - th output variable
        /// </summary>
        /// <param name="i">Variable index</param>
        /// <returns>The type</returns>
        public virtual object GetOutputType(int i)
        {
            return type;
        }

        /// <summary>
        /// Calculation
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="output">Output</param>
        public abstract void Calculate(object[] input, object[] output);


        #endregion

        #region Members

        void SetEvents()
        {
            Prepare();
            if (!(collection is IAddRemove))
            {
                return;
            }
            act = (object o) => { Prepare(); };
            IAddRemove r = collection as IAddRemove;
            r.OnAdd += act;
            r.OnRemove += act;
        }

        /// <summary>
        /// Prepares itself
        /// </summary>
        protected virtual void Prepare()
        {
            runtime = StaticExtensionDataPerformerPortable.Factory.Create(collection, 0);
            List<string[]> l = collection.GetDoubleVariables();
            type = new ArrayReturnType(a, new int[] { l.Count }, false);
            outbuffer = new double[l.Count];
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Prepare();
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (isDisposed)
            {
                return;
            }
            if (!(collection is IAddRemove))
            {
                return;
            }
            IAddRemove r = collection as IAddRemove;
            r.OnAdd -= act;
            r.OnRemove -= act;
            isDisposed = true;
        }

        #endregion

    }
}
