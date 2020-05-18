using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using Diagram.UI.Interfaces;

using Scada.Interfaces;
using Scada.Desktop;


namespace Unity.Standard
{
    /// <summary>
    /// Abstract update
    /// </summary>
    public abstract class AbstractUpdate : IUpdate
    {
        #region Fields

        protected Action<double>[] dInp;

        protected Func<double>[] dOut;

        protected MonoBehaviorWrapper wrapper;

        protected ScriptWithWrapper mono;


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
        public virtual void Set(MonoBehaviorWrapper wrapper, 
            ScriptWithWrapper mono)
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
