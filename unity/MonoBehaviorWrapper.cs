
using System;

using Unity;
using UnityEngine;

using Diagram.UI;

using BaseTypes.Attributes;
using DataPerformer.Portable.Interfaces;
using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

using Event.Interfaces;

using Scada.Interfaces;
using Scada.Desktop;
using System.Collections.Generic;

namespace Unity.Standard
{
    public class MonoBehaviorWrapper : MonoBehaviorTimerFactory
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

