using System;
using UnityEngine;

using Unity.Standard;


using Scada.Interfaces;

namespace Assets
{
    public class UpdateAlarm : AbstractUpdateGameObject
    {

        #region Fields

        string alarm;

        float[] xy;

        float[] delta;


        Transform red;

        Transform green;

        MonoBehaviour mb;

        string al = null;

        Component[] sliders;

        #endregion


        #region Constructor
        public UpdateAlarm()
        {
            ForcesMomentumsUpdate.Alarm += UpdateAlarmF;
        }

        #endregion

        #region Overriden

       
        /// <summary>
        /// Update action
        /// </summary>
        public override Action Update => null;

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="obj">Measurement object</param>
        /// <param name="indicator">Indicator</param>
        /// <param name="scada">SCADA</param>
        public override void Set(object[] obj, Component indicator, IScadaInterface scada)
        {
            base.Set(obj, indicator, scada);
            mb = obj[2] as MonoBehaviour;
            //    var comp = indicator.gameObject.GetGameObjectComponents<Transform>();
            var comp = indicator.gameObject.GetGameObjectComponents<Transform>();
            red = comp["Red"][0];
            green = comp["Green"][0];
        }

        #endregion

        #region Update

   

        #endregion

        #region Private

        void UpdateAlarmF(string s, float[] xxy, float[] ddelta)
        {
            al = s;
            if (al == null)
            {
                xy = null;
                delta = null;
                return;
            }
            if (xy == null & xxy != null)
            {
                xy = xxy;
                mb.StartCoroutine(enumerator);
            }
            xy = xxy;

        }


        System.Collections.IEnumerator enumerator
        {
            get
            {
                while (true)
                {
                    float[] xxy = xy;
                    if (xxy == null)
                    {
                        green.gameObject.SetActive(false);
                        red.gameObject.SetActive(false);
                        break;
                    }
                    green.position = red.position + new Vector3(xxy[0], xxy[1], 0);
                    green.rotation = red.rotation *  Quaternion.Euler(0, 0, xxy[2]);
                    green.gameObject.SetActive(true);
                    red.gameObject.SetActive(true);
                    yield return new WaitForSeconds(0.2f);
                    green.gameObject.SetActive(false);
                    red.gameObject.SetActive(false);
                    yield return new WaitForSeconds(0.2f);

                }
            }
        }

        #endregion
    }
}
