using System;
using System.Collections.Generic;

using UnityEngine;


using Unity.Standard;
using Scada.Interfaces;

namespace Assets
{
    public class KeyActivation : IActivation, IKeyListener
    {
        #region Fields

        static internal KeyCode Pause = KeyCode.Escape;

        static internal KeyCode StopKey = KeyCode.Return;

        static internal KeyCode QuitKey = KeyCode.F1;

        static GameObject explosion;

        static GameObject station;


        #region Ctor

        public KeyActivation()
        {
            this.AddKeyListener();
            StaticExtensionUnity.Collision += (Tuple<GameObject, Component, IScadaInterface, ICollisionAction> obj) =>
            {

                Explosion();
            };

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
            foreach (var m in monoBehaviours)
            {
                if (m.name == "Station")
                {
                    station = m.gameObject;
                }
                if (m.name == "Main Camera")
                {
                    explosion = m.gameObject.GetGameObjectComponents<Component>()["Explosion"][0].gameObject;
                }
            }
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

        #region Internal Members

        static internal void Explosion()
        {
            explosion.SetActive(true);
            station.SetActive(false);
        }

        #endregion

        void SetKey(KeyCode keyCode)
        {
            if (keyCode == Pause)
            {
                Activation.PauseRestart();
                return;
            }
            if (keyCode == StopKey)
            {
                ResultIndicator.Stop();
            }
        }
    }
}