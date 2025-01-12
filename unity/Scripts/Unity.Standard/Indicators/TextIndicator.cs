using System;

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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameter">Parameter</param>
        /// <param name="text">Text</param>
        /// <param name="type">Type</param>
        /// <param name="format">Format</param>
        /// <param name="debug">the "debug" sign</param>
        public TextIndicator(string parameter, Text text, object type, string format = null, bool debug = false)
        {
            f = () => { return obj + ""; };
            this.type = type;
            this.parameter = parameter;
            this.text = text;
            pref = text.text;
            if (debug)
            {
                SetActive(false);
            }
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
                return;
            }
        }

        /// <summary>
        /// Active post set
        /// </summary>
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
            var v = f();
            if (v != null)
            {
                text.text = pref + v;
            }
        }

        /// <summary>
        /// Active post set
        /// </summary>
        protected override void PostSetActive()
        {
            text.gameObject.SetActive(isActive);
            if (!isActive)
            {
                setValue = (object o) => { };
                return;
            }
            setValue = (object o) => 
            { 
                if (o != null)
                {
                    double x = (double)o;
                    text.text = pref + x.ToString(format);  
                }
            };

        }

        /// <summary>
        /// Global post set
        /// </summary>
        /// <param name="str"></param>
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
