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

        static internal KeyCode QuitKey = KeyCode.F2;

        static GameObject explosion;

        static GameObject station;

        static GameObject earth;

        static internal KeyActivation keyActivation;

        static internal IBlinked blinkedLamps;


        #region Ctor

        public KeyActivation()
        {
            this.AddKeyListener();
            IActivation activation = this;
            StaticExtensionUnity.LevelAction = () =>
            {
                Type t = activation.GetActivationType(StaticExtensionUnity.Activation.level);
                t.GetConstructor(new Type[0]).Invoke(new object[0]);
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
                    return;
                    // MeshRenderer mr = earth.GetGameObjectComponents<MeshRenderer>()[Level0.Earth][0];
                    // mr.materials[0].mainTexture = StaticExtensionUnity.Activation.textures[0];
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


        /// <summary>
        /// Gets activation type from the level
        /// </summary>
        /// <param name="level">The level</param>
        /// <returns>The activation type</returns>
        Type IActivation.GetActivationType(int level)
        {
            int p = Math.Abs(level);
            int i = 1;
            while (true)
            {
                string s = "Level" + (StaticExtensionUnity.Activation.level < 0 ? "m" : "") + i;
                Type t = StaticExtensionUnity.StringUpates[s];
                if (i == p)
                {
                    return t;
                }
                ++i;
                s += "_Fuel";
                if (StaticExtensionUnity.StringUpates.ContainsKey(s))
                {
                    if (i == p)
                    {
                        return StaticExtensionUnity.StringUpates[s];
                    }
                    ++i;
                    s += "_Timer";
                    if (StaticExtensionUnity.StringUpates.ContainsKey(s))
                    {
                        if (i == p)
                        {
                            return StaticExtensionUnity.StringUpates[s];
                        }
                        ++i;
                    }
                }
                return null;
            }
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