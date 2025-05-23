using System;
using System.Collections.Generic;

using Unity;
using UnityEngine;

using Diagram.UI;



namespace Unity.Standard
{
    public class MonoBehaviourWrapper : MonoBehaviourTimerFactory
    {
        #region Fields

        private MonoBehaviour monoBehaviour;



        #endregion

        #region Ctor

        public MonoBehaviourWrapper(MonoBehaviour monoBehaviour,
             string name = null) : base(name)
        {
        }

        #endregion

        #region Members

        #region Public Members

        #endregion

        #region Internal Members
        #endregion

        #endregion

        #region Private Members

        #endregion
    }

}

