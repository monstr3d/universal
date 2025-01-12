using System;

using BaseTypes;

using Scada.Desktop;

using Unity.Standard;

using Unity.Standard.Interfaces;

namespace Unity.Standard.Abstract
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
 
        protected bool isVisible = true;

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

        /// <summary>
        /// Update action
        /// </summary>
        Action IIndicator.Update { get => update; }

        /// <summary>
        /// The name of parameter
        /// </summary>
        string IIndicator.Parameter { get => parameter; }

        /// <summary>
        /// The value
        /// </summary>
        object IIndicator.Value { get => obj;  set => setValue(value); }


        /// <summary>
        /// Type
        /// </summary>
        object IIndicator.Type { get => type; }


        /// <summary>
        /// Type
        /// </summary>
        bool IIndicator.IsActive 
        { 
            get => isActive; 
            set => SetActive(value); 
        }


        /// <summary>
        /// Global action
        /// </summary>
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
        protected virtual bool SetValue(object o)
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
        /// <param name="active">The active</param>
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

        #region Overriden Members

        public override string ToString()
        {
            return parameter;
        }


        #endregion

        #region Own 

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
