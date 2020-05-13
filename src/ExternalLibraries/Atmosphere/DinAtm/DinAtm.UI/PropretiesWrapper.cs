using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI.Interfaces;
using Diagram.UI.Attributes;

namespace DinAtm.UI
{
    /// <summary>
    /// Wrapper of properties
    /// </summary>
    [LinkedType(typeof(Atmosphere))]
    public class PropertiesWrapper : ISeparatedPropertyEditor
    {
        #region Fields

        object o;

        object[] ob = new object[] { null, DinAtm.UI.Properties.Resources.Atmosphere };

        Forms.FormAtmosphereEdit f;


        #endregion

        #region Ctor

        /// <summary>
        /// Wrapper of properties
        /// </summary>
        public PropertiesWrapper()
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
            f = new Forms.FormAtmosphereEdit(o as Atmosphere);
            ob[0] = f;
            return ob;
        }

 
        #endregion
    }
}
