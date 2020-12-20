using System;
using System.Runtime.ExceptionServices;
using CategoryTheory;
using Scada.Desktop;

namespace Unity.Standard
{
    /// <summary>
    /// Abstract indicator
    /// </summary>
    public abstract class AbstractIndicator : IIndicator
    {

        #region Fields

        protected string parameter;

        protected bool isActive = true;

        protected Func<object> func;

        protected object obj;

        protected Action update;

        protected object type;

        protected Action<object> setValue;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        protected AbstractIndicator()
        {
            setValue = Set;
        }

        #endregion

        #region IIndicator Members

        Action IIndicator.Update { get => update; }
        string IIndicator.Parameter { get => parameter; }
        object IIndicator.Value { get => obj;  set => setValue(value); }
        object IIndicator.Type { get => type; }
        bool IIndicator.IsActive 
        { 
            get => isActive; 
            set => SetActive(value); 
        }

        Action<string> IIndicator.Global { get => SetGlobal; }

        #endregion

        #region Abstract Members

        /// <summary>
        /// Global post set
        /// </summary>
        /// <param name="str"></param>
        protected abstract void PostSetGlobal(string str);

        /// <summary>
        /// Active post set
        /// </summary>
        protected abstract void PostSetActive();


        /// <summary>
        /// Active post set
        /// </summary>
        protected abstract void PostSet();

        #endregion

        #region Virtual Members

        /// <summary>
        /// Sets active state
        /// </summary>
        /// <param name="str"></param>
        protected virtual void SetGlobal(string str)
        {
            if (this.EnableDisable(str))
            {
                return;
            }
            PostSetGlobal(str);
        }

        /// <summary>
        /// Sets value
        /// </summary>
        /// <param name="o">Value</param>
        protected virtual void  Set(object o)
        {
            if (!SetValue(o))
            {
                return;
            }
            PostSet();
        }

        /// <summary>
        /// Sets value
        /// </summary>
        /// <param name="o">Value</param>
        /// <returns>True in success</returns>
        protected virtual bool  SetValue(object o)
        {
            if (o.Equals(obj))
            {
                return false;
            }
            obj = o;
            return true;
        }

        /// <summary>
        /// Internal update
        /// </summary>
        protected virtual void UpdateInrternal()
        {
            update?.Invoke();
        }

        /// <summary>
        /// Sets active state
        /// </summary>
        /// <param name="active">The acrive</param>
        protected virtual void  SetActive(bool active)
        {
            if (active == isActive)
            {
                return;
            }
            isActive = active;
            PostSetActive();
        }

        #endregion

        #region Own 

  /*      /// <summary>
        /// Exceeds
        /// </summary>
        protected Func<float[], bool> Exceeds
        {
            get
            { 
                double a = 0;
                if (a.Equals(type))
                {
                    return (float[] l) =>
                    {
                        double x = (double)obj;
                        float y = (float)x;
                        return (y < l[0]) | (y > l[1]);
                    };
                }
                return (float[] l) =>
                {
                    float x = (float)obj;
                    return (x < l[0]) | (x > l[1]);
                };

            }
        }
  !!! */
   
        /// <summary>
        /// Finds the function
        /// </summary>
        protected void Find()
        {
            func = parameter.DetectFunc();
            if (func != null)
            {
                Action act = () => Set(func());
                update = act.Add(update);
            }
        }

        #endregion


    }
}
