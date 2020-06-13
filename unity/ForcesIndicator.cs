using BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using UnityEngine;

namespace Assets
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

    public class ForcesIndicator : IIndicator
    {
        #region Fields

        static internal ForcesIndicator indicator;

        Action<object[]> update;

        string parameter;

        bool isActive = true;

        MonoBehaviour mb;

        GameObject gameObject;

        GameObject parent;

        object[] o;

        RectTransform pivot, path;

        #endregion

        #region Ctor

        public ForcesIndicator(GameObject gameObject)
        {
            indicator = this;
            var st = "RigidBodyStation.Force.";
            parameter = "";
            string[] ss = { "Fx", "Fy", "Fz", "Mx", "My", "Mz" };
            foreach (var c in ss)
            {
                parameter += st + c + ";";
            }
            this.Add();
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
            mb = parent.GetComponent<MonoBehaviour>();
            Dictionary<string, List<RectTransform>> rtv =
                parent.GetGameObjectComponents<RectTransform>();
            pivot = rtv["_pivot"][0];
            path = rtv["Path"][0];
            update = update.Add(UpdatePivot);
        }

        #endregion


        #region IIndicator Members

        Action IIndicator.Update => Update;

        string IIndicator.Parameter => parameter;

        object IIndicator.Value { set => update?.Invoke(value as object[]); }

        object IIndicator.Type => typeof(object[]);

        bool IIndicator.IsActive
        {
            get => isActive;
            set
            {
                if (!this.SetActive(value))
                {
                    return;
                }
                isActive = value;
            }
        }

        #endregion

        #region Members

        void Update()
        {
            if (o != null)
            {
                update?.Invoke(o);
            }
        }

        float ap = -60f;


        void UpdatePivot(object[] o)
        {
            int k = Math.Sign((double)o[5]);
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


        #endregion

    }
}
