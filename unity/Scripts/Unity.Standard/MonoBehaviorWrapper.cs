
using System.Collections.Generic;

using UnityEngine;

using Diagram.UI;


namespace Unity.Standard
{
    public class MonoBehaviorWrapper : MonoBehaviourTimerFactory
    {
        #region Fields

        private MonoBehaviour monoBehaviour;


        private Dictionary<string, Motion6D.Interfaces.IReferenceFrame> frames =
            new Dictionary<string, Motion6D.Interfaces.IReferenceFrame>();



        #endregion

        #region Ctor

        public MonoBehaviorWrapper(MonoBehaviour monoBehaviour,
             string name = null) : base(name)
        {
            desktop.ForEach((Motion6D.Interfaces.IReferenceFrame frame) =>
            {
                string fn = frame.GetName(desktop);
                frames[fn] = frame;
            });
        }

        #endregion

        #region Members

        #region Public Members


        public Dictionary<string, Motion6D.Interfaces.IReferenceFrame> Frames { get => frames; }

        #endregion

        #region Internal Members
        #endregion

        #endregion


        #region Private Members

        #endregion
    }

}

