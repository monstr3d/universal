using Motion6D.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Specific
{
    public class KeyActivationFiction : IActivation
    {
        public KeyActivationFiction() 
        { 
        
        }

        int IActivation.Level { get => 1; set {} }

        Action IActivation.Update => null;

        void IActivation.Activate(MonoBehaviour[] monoBehaviours)
        {

        }

        Type IActivation.GetActivationType(int level)
        {
            return null;
        }

        void IActivation.PostActivate(MonoBehaviour[] monoBehaviours)
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
    }
}
