using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Http.Meteo.Services;

namespace Http.Meteo.UI
{
    /// <summary>
    /// Wrapper of properties
    /// </summary>
    public class PropretiesWrapper : ISeparatedPropertyEditor
    {
        #region Fields

        Forms.FormMeteo f = null;

        object[] ob = new object[] { null, Http.Meteo.UI.ResourceImage.Atmosphere };
  
        #endregion

        #region Ctor

        public PropretiesWrapper()
        {
        }

        #endregion

        #region ISeparatedPropertyEditor Members

        object ISeparatedPropertyEditor.GetEditor(object o)
        {
            if (f != null)
            {
                if (!f.IsDisposed)
                {
                    return ob;
                }
            }
            f = new Forms.FormMeteo(o);
            ob[0] = f;
            return ob;
        }

    
        #endregion
    }
}
