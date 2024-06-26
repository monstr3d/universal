﻿
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using BaseTypes;

using Scada.Interfaces;


using Unity.Standard;
using Scada.Desktop;
using Unity.Standard.Interfaces;
using Unity.Standard.Abstract;

namespace Scripts.Specific
{

    public class ForcesIndicatorFactory : IIndicatorFactory
    {
        public ForcesIndicatorFactory()
        {
            
        }

        IIndicator IIndicatorFactory.Get(GameObject gameObject)
        {
            if (gameObject.name == "ForcesIndicator")
            {
                IIndicator ind = ForcesIndicator.indicator;
                if (ind != null)
                {
                    return ind;
                }
                return new ForcesIndicator(gameObject);
            }
            return null;
        }
    }

    public class ForcesIndicator : AbstractIndicator, IJumpedIndicator
    {
        #region Fields

        static internal ForcesIndicator indicator;

  

        GameObject gameObject;

        GameObject parent;

        object[] o;

        RectTransform pivot, path;

        IScadaInterface scada;

      
        Dictionary<int, int> active = new Dictionary<int, int>();

        Dictionary<int, string[]> sprites = new Dictionary<int, string[]>()
        {
            {2, new string[] {"Forward", "Backward" } },
           {0, new string[] {"Right", "Left" } },
           {1, new string[] {"Up", "Down" } },
        };

        int acn = 0;

        AudioSource engine;

        ReferenceFrameBehavior mb;

        AudioSource torch;

        Dictionary<int, Image[]> blink = new Dictionary<int, Image[]>();

        RectTransform timeOver;

        Text timeOverText;


        #endregion

        #region Ctor

        public ForcesIndicator(GameObject gameObject)
        {
            indicator = this;
            type = typeof(object[]);
            GameObject camera = ForcesMomentumsUpdate.camera;
            mb = camera.GetComponent<ReferenceFrameBehavior>();
            Dictionary<string, List<AudioSource>> las =
               camera.GetGameObjectComponents<AudioSource>();
            torch = las["Torch"][0];
            engine = las["Engine"][0];
            var s = "RigidBodyStation";
            scada = s.ToExistedScada();
            var st = s + ".Force.";
            parameter = "";
            string[] ss = { "Fx", "Fy", "Fz", "Mx", "My", "Mz" };
            foreach (var c in ss)
            {
                parameter += st + c + ";";
            }
            this.gameObject = gameObject;
            RectTransform[] rr = gameObject.GetComponentsInParent<RectTransform>();
            foreach (var r in rr)
            {
                if (r.name == "Cockpit")
                {
                    parent = r.gameObject;
                    break;
                }
            }
            Dictionary<string, List<RectTransform>> rtv =
                parent.GetGameObjectComponents<RectTransform>();
            timeOver = rtv["TimeOver"][0];
            timeOverText = timeOver.gameObject.GetGameObjectComponents<Text>()["ValueText"][0];
            pivot = rtv["_pivot"][0];
            path = rtv["Path"][0];
            lpos = path.localPosition;
            var canv = parent.GetGameObjectComponents<Image>();
            var dictionary = Saver.saver.dictionary;
            foreach (int key in sprites.Keys)
            {
                Image[] im = new Image[2];
                string[] ssi = sprites[key];
                for (int i = 0; i < 2; i++)
                {
                    Image image = canv[ssi[i]][0];
                    image.enabled = false;
                    im[i] = image;
                }
                if (dictionary.ContainsKey(key))
                {
                    blink[key] = im;
                }

            }
            update = update.Add(UpdateSound);
            update = update.Add(UpdatePivot);
            update = update.Add(UpdatePath);
            blinkc.StartCoroutine();
        }

        #endregion

        #region Overriden

        protected override void PostSetGlobal(string str)
        {

        }

        protected override void PostSetActive()
        {

        }

        protected override bool SetValue(object o)
        {
            base.SetValue(o);
            return true;
        }

        protected override void PostSet()
        {
            UpdateActive(obj as object[]);
        }

        #endregion

        Vector2 lpos;

        float bp = 0.2f;


        #region Members


        internal void TimeOver()
        {
            Level0.TimeOverTime.ToGlobal().EnableDisable(false);
            timeOver.gameObject.SetActive(true);
            timeOverText.gameObject.SetActive(true);
            timeOverText.text = "Time over";

        }


        internal void StopAudio()
        {
            torch.enabled = false;
            engine.enabled = false;
        }

        void UpdateActive(object[] o)
        {
            this.o = o;
            for (int i = 0; i < o.Length; i++)
            {
                active[i] = Math.Sign((double)o[i]);
            }
   /// !!!         Torch();
            UpdatePath();
            UpdatePivot();
            UpdateSound();
       }


        System.Collections.IEnumerator enumeratorT
        {
            get
            {
                yield return new WaitForSeconds(0.5f);
                torch.enabled = false;
                yield return 0;
            }
        }



        public void Torch()
        {
            mb.Jump();
            torch.enabled = true;
            enumeratorT.StartCoroutine();
        }


        void UpdatePath()
        {
            float amp = 100;
            Vector2 p = new Vector2(lpos.x + active[4] * amp, lpos.y + active[3] * amp);
            if (!p.Equals(path.localPosition))
            {
                path.localPosition = p;
            }
        }

        void UpdateSound()
        {
            int aco = activeEn;
            if (aco != acn)
            {
                if (acn != aco)
                {
                    if (acn == 0)
                    {
                        engine.enabled = false;
                        engine.Stop();
                    }
                    if (aco != 0)
                    {
                        engine.enabled = true;
                    }
                    if (engine.enabled)
                    {
                        engine.volume = aco / 6f;
                    }

                }
                acn = aco;
            }
        }

        int activeEn
        {
            get
            {
                int k = 0;
                foreach (var i in active.Values)
                {
                    if (i != 0)
                    {
                        ++k;
                    }
                }
                return k;
            }
        }




        void Update()
        {
            if (o != null)
            {
                update?.Invoke();
            }
        }

        float ap = -60f;

        int lastPivot;

        void UpdatePivot()
        {
            int k = active[5];
            if (k == lastPivot)
            {
                return;
            }
            lastPivot = k;
            float r = ap * k;
            Vector3 euler = new Vector3(0, 0, r);
            pivot.rotation = Quaternion.Euler(euler);
       }

        System.Collections.IEnumerator blinkc
        {
            get
            {
                while (true)
                {
                    yield return new WaitForSeconds(bp);
                    pivot.gameObject.SetActive(false);
                    path.gameObject.SetActive(false);
                    foreach (Image[] im in blink.Values)
                    {
                        foreach (Image image in im)
                        {
                            image.enabled = false;
                        }
                    }
                    if (!scada.IsEnabled)
                    {
                        break;
                    }
                    yield return new WaitForSeconds(bp);
                    pivot.gameObject.SetActive(true);
                    path.gameObject.SetActive(true);
                    foreach (var key in blink.Keys)
                    {
                        if (!active.ContainsKey(key))
                        {
                            continue;
                        }
                        int k = active[key];
                        if (k == 0)
                        {
                            continue;
                        }
                        int a = 1 - Math.Sign(k + 1);
                        blink[key][a].enabled = true;
                    }
                }
            }
        }

    //    Action<string> IIndicator.Global => (string s) => { };

        string[] IJumpedIndicator.JumpEvents => new string[] { "RigidBodyStation.Force" };


        #endregion

    }
}
