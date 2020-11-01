using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsExtensions.Internal
{
    class EnabledLock : IDisposable
    {

        IEnumerable<object> ob;

 
        internal EnabledLock(IEnumerable<object> ob)
        {
            this.ob = ob;
            SetEnabled(false);
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            SetEnabled(true);
        }

        #endregion

        private void SetEnabled(bool enabled)
        {
             foreach (object o in ob)
            {
                System.Reflection.PropertyInfo pi = o.GetType().GetProperty("Enabled");
                pi.SetValue(o, enabled, null);
              
            }
       }
    }
}
