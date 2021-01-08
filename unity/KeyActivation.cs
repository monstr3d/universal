using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Standard;
using UnityEngine;

namespace Assets
{
    public class KeyActivation : IActivation, IKeyListener
    {
        #region Fields

        static internal KeyCode Pause = KeyCode.Escape;

        static internal KeyCode StopKey = KeyCode.Return;

        static internal KeyCode QuitKey = KeyCode.F1;

        #region Ctor

        public KeyActivation()
        {
            this.AddKeyListener();
        }

        #endregion


        #endregion

        #region IKeyListener Members

        public List<KeyCode> Keys => new List<KeyCode>() { Pause, StopKey, QuitKey };

        public Action<KeyCode> Action => SetKey;

        #endregion

        #region IActivation Members

        int IActivation.Level { get => StaticExtensionUnity.StaticLevel; set { } }

        Action IActivation.Update => () => { };

        void IActivation.Activate(MonoBehaviour[] monoBehaviours)
        {

        }

        int IActivation.SetConstants(float[] constants)
        {
            return 0;
        }

        int IActivation.SetConstants(string[] constants)
        {
            return 0;
        }

        #endregion

        void SetKey(KeyCode keyCode)
        {
            if (keyCode == Pause)
            {
                Activation.PauseRestart();
                return;
            }
        }

    }
}