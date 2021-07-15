using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard.Abstract;
using UnityEngine;

namespace Unity.Standard.Indicators
{

    /// <summary>
    /// Indicators of input/output
    /// </summary>
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

        /// <summary>
        /// Crestes
        /// </summary>
        /// <param name="output">Otput</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="type">Type</param>
        /// <param name="coefficient">Coefficient</param>
        /// <param name="compare">The compare sign</param>
        /// <returns></returns>
        static public InputOutputIndicator Create(Action<object> output, string parameter, object type, double coefficient = 1, 
            bool compare = true)
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

        #region Overriden Protected


        /// <summary>
        /// Global post set
        /// </summary>
        /// <param name="str"></param>
        protected override void PostSetGlobal(string str)
        {

        }

        /// <summary>
        /// Active post set
        /// </summary>
        protected override void PostSetActive()
        {

            if (isActive)
            {
                setValue = Set;
                return;
            }
            setValue = (object o) => { };
        }

        /// <summary>
        /// Active post set
        /// </summary>
        protected override void PostSet()
        {
            object val = obj;
            if (coefficient != 1)
            {
                val = coefficient * (double)obj;
            }
            output.Add(val);
        }

        #endregion

    }
}