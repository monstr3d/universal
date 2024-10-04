using System;

using Diagram.UI.Interfaces;

using Scada.Interfaces;
using Scada.Desktop;
using Unity.Standard.Interfaces;

namespace Unity.Standard.Abstract
{
    /// <summary>
    /// Abstract update
    /// </summary>
    public abstract class AbstractUpdate : IUpdate
    {
        #region Fields

        protected Action<double>[] dInp;

        protected Func<double?>[] dOut;

        protected MonoBehaviourWrapper wrapper;

        protected ReferenceFrameBehavior mono;


        protected IScadaInterface scada;

        protected IDesktop desktop;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AbstractUpdate()
        {

        }

        #endregion

        #region IUpdate implementation

        /// <summary>
        /// Sets objects
        /// </summary>
        /// <param name="wrapper">Wrapper</param>
        /// <param name="mono">Script</param>
        public virtual void Set(MonoBehaviourWrapper wrapper,
            ReferenceFrameBehavior mono)
        {
            this.wrapper = wrapper;
            this.mono = mono;
            dInp = mono.dInp;
            dOut = mono.dOut;
            scada = wrapper.Scada;
            desktop = scada.GetDesktop();
        }

        /// <summary>
        /// Updates
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Starts itself
        /// </summary>
        public abstract void Start();

        #endregion
    }
}
