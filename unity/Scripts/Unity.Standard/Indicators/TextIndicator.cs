using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard.Abstract;
using UnityEngine.UI;

namespace Unity.Standard.Indicators
{
    /// <summary>
    /// Indicator of text control
    /// </summary>
    public class TextIndicator : AbstractIndicator
    {
        #region Fields

        Text text;

        string pref;

        string format;

        Func<string> f;

        #endregion

        #region Ctor

        public TextIndicator(string parameter, Text text, object type, string format = null)
        {
            f = () => { return obj + ""; };
            this.type = type;
            this.parameter = parameter;
            this.text = text;
            pref = text.text;
            SetActive(false);
            if (format != null)
            {
                this.format = format;
                if (type.GetType() == typeof(double))
                {
                    f = () =>
                    {
                        double x = (double)obj;
                        return x.ToString(format);
                    };

                }
            }
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Sets visible sign
        /// </summary>
        /// <param name="visible">The sign value</param>
        protected void SetVisible(bool visible)
        {
            if (visible == isVisible)
            {
                return;
            }
            isVisible = visible;
            text.gameObject.SetActive(visible);
            if (!visible)
            {
                // text.enabled []
                return;
            }
         //   updateText?.Invoke();
         //  setFloatValue(currentValue);
        }


        protected override void PostSet()
        {
            if (!isActive)
            {
                return;
            }
            if (obj == null)
            {
                return;
            }
            text.text = pref + f();
        }

        protected override void PostSetActive()
        {
            text.gameObject.SetActive(isActive);
            if (!isActive)
            {
                setValue = (object o) => { };
            }
        }

        protected override void PostSetGlobal(string str)
        {

        }

        #endregion

        #region Public Members

        public override string ToString()
        {
            return parameter;
        }


        #endregion

        #region Private

       

        #endregion


    }
}
