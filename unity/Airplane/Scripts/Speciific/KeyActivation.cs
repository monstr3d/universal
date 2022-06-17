using System;
using System.Collections.Generic;

using UnityEngine;


using Scada.Interfaces;
using Scada.Desktop;

using Unity.Standard;
using Unity.Standard.Interfaces;
using Unity.Standard.Abstract;

namespace Scripts.Specific
{
    public class KeyActivation : IActivation
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

        static float earthScale = 1;

    
        IStringUpdate su;



        #region Ctor

        public KeyActivation()
        {
            IActivation activation = this;

        }

        #endregion

        #endregion

 
        #region IActivation Members

        int IActivation.Level { get => 0; set { } }

        Action IActivation.Update => su.UpdateItself;

        void IActivation.Activate(MonoBehaviour[] monoBehaviours)
        {
            var mb = monoBehaviours[0];
            var tr = mb.gameObject.transform.worldToLocalMatrix;
            double[] q = new double[]
 /*           {

                -0.15922, -0.38438, -0.38438, 0.82410
            };
            double[] q = new double[]*/
                {

              0.50000, 0.50000, 0.50000, -0.50000
                };
            double[,] m = new double[3, 3];
            double[,] qq = new double[4, 4];

            Vector3D.StaticExtensionVector3D.QuaternionToMatrix(q, m, qq);
        }


        int IActivation.SetConstants(float[] constants)
        {
            return 0;
        }

        int IActivation.SetConstants(string[] constants)
        {

            return 0;
        }


        /// <summary>
        /// Gets activation type from the level
        /// </summary>
        /// <param name="level">The level</param>
        /// <returns>The activation type</returns>
        Type IActivation.GetActivationType(int level)
        {
            return null;
        }


        #endregion

    }
}