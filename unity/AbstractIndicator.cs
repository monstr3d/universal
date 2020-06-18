using System;

using CategoryTheory;
using Scada.Desktop;

namespace Unity.Standard
{
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

        protected AbstractIndicator()
        {
            setValue = Set;
        }

        #endregion

        #region IIndicator Members

        Action IIndicator.Update { get => update; }
        string IIndicator.Parameter { get => parameter; }
        object IIndicator.Value { set => setValue(value); }
        object IIndicator.Type { get => type; }
        bool IIndicator.IsActive { get => isActive; set => SetActive(value); }
        Action<string> IIndicator.Global { get => SetGlobal; }

        #endregion

        #region Abstract Members

        protected abstract void PostSetGlobal(string str);


        protected abstract void PostSetActive();


        protected abstract void PostSet();

        #endregion

        #region Virtual Members

        protected virtual void SetGlobal(string str)
        {
            if (this.EnableDisable(str))
            {
                return;
            }
            PostSetGlobal(str);
        }

        protected virtual void  Set(object o)
        {
            if (!SetValue(o))
            {
                return;
            }
            PostSet();
        }

        protected virtual bool  SetValue(object o)
        {
            if (o.Equals(obj))
            {
                return false;
            }
            obj = o;
            return true;
        }

  
        protected virtual void UpdateInrternal()
        {
            update?.Invoke();
        }

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

        #region Own Members

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
