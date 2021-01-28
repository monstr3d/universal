using System;
using System.Collections.Generic;

using UnityEngine;


using Unity.Standard;
using Scada.Interfaces;
using Scada.Desktop;

namespace Scripts
{
    public class KeyActivation : IActivation, IKeyListener
    {
        #region Fields

        static internal KeyCode Pause = KeyCode.Escape;

        static internal KeyCode StopKey = KeyCode.Return;

        static internal KeyCode QuitKey = KeyCode.F1;

        static GameObject explosion;

        static GameObject station;
        static GameObject earth;

        static internal KeyActivation keyActivation;

        static internal IBlinked blinkedLamps;

        #region Ctor

        public KeyActivation()
        {
            this.AddKeyListener();
            // !!! CORRECT
            Action act = () => { StaticExtensionUnity.Level.GetConstructor(new Type[0]).Invoke(new object[0]); };
            Action act1 = () => { StaticExtensionUnity.Level.GetConstructor(new Type[] { typeof(bool) }).Invoke(new object[] { true }); };
            StaticExtensionUnity.LevelAction = () =>
            {
                if (StaticExtensionUnity.StaticLevel == 1)
                {
                    act1();
                    return;
                }
                act();
            };
            keyActivation = this;
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
                if (m.name == Level0.Station)
                {
                    station = m.gameObject;
                    var objs = station.GetGameObjectComponents<Component>();
                    var l = new List<GameObject>();
                    var ss = new string[] { "Sphere", "SphereLeft", "SphereRight" };
                    foreach (var s in ss)
                    {
                        l.Add(objs[s][0].gameObject);
                    }
                    blinkedLamps = new BlinkedEnabledGameObjects(l);
                    blinkedLamps.Start(new float[] { 1, 0.2f }, m);
                  //  var mr = station.GetGameObjectComponents<MeshRenderer>()[Level0.Station][0];
                  //  mr.materials = new Material[] { mr.materials[1] };
                  //  mr.materials[0].mainTexture = StaticExtensionUnity.Activation.textures[1];
                }
                if (m.name == Level0.Main_Camera)
                {
                    explosion = m.gameObject.GetGameObjectComponents<Component>()["Explosion"][0].gameObject;
                }
                if (m.name == Level0.Earth)
                {
                    earth = m.gameObject;
                    MeshRenderer mr = earth.GetGameObjectComponents<MeshRenderer>()[Level0.Earth][0];
                    mr.materials[0].mainTexture = StaticExtensionUnity.Activation.textures[0];
                }
            }
        }

        int IActivation.SetConstants(float[] constants)
        {
            return 0;
        }

        int IActivation.SetConstants(string[] constants)
        {

            var scada = Level0.RigidBodyStation.ToExistedScada();
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