using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Standard
{
    public class InputOutputIndicator : AbstractIndicator
    {
        #region Fields

        static List<InputOutputIndicator> l = new List<InputOutputIndicator>();

        Action<object> output;

        double coefficient;

        volatile static int stopped = 0;


        #endregion

        #region Ctor

        private InputOutputIndicator(Action<object> output, string parameter, object type,
            double coefficient = 1, bool compare = true)
        {
            this.output = output;
            this.parameter = parameter;
            this.type = type;
            this.coefficient = coefficient;
            obj = type;
            SetActive(true);
            SetActive(false);
        }

        #endregion

        #region IIndicator members
        /*
        Action IIndicator.Update => upd;

        string IIndicator.Parameter => parameter;

        object IIndicator.Value { set => update(value); }

        object IIndicator.Type => type;

        bool IIndicator.IsActive { get => isActive; set => SetActive(value); }
        
        */

        #endregion

        #region Overriden

 
        public override bool Equals(object obj)
        {
            if (!(obj is InputOutputIndicator))
            {
                return false;
            }
            InputOutputIndicator ii = obj as InputOutputIndicator;
            return (ii.parameter.Equals(parameter) & ii.func == func);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Public

        static public InputOutputIndicator Create(Action<object> output, string parameter, object type, double coefficient = 1, bool compare = true)
        {
            var i = new InputOutputIndicator(output, parameter, type, coefficient, compare);
            if (l.Contains(i))
            {
                return null;
            }
            l.Add(i);
            return i;
        }
        #endregion

        protected override void PostSetGlobal(string str)
        {

        }

        protected override void PostSetActive()
        {
            if (isActive)
            {
                setValue = Set;
                return;
            }
            setValue = (object o) => { };
        }

        protected override void PostSet()
        {
            stopped += 1;
            enumerator(output, obj, stopped, coefficient).StartCoroutine();
        }

        System.Collections.IEnumerator enumerator(Action<object> output, object obj, int count,
            double coefficient)
        {
            float delay = StaticExtensionUnity.Activation.delay * stopped;
            yield return new WaitForSeconds(delay);
            double s = (double)obj;
            if (isActive)
            {
                output(coefficient * s);
            }
            stopped -= 1;
        }
    }
}