using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI.Interfaces;
using Diagram.UI.Attributes;

namespace DynamicAtmosphere.Wrapper.UI
{
    /// <summary>
    /// Wrapper of properties
    /// </summary>
    [LinkedType(typeof(Atmosphere))]
    public class PropertiesWrapper : ISeparatedPropertyEditor
    {

        #region Fields

        object[] ob = new object[] { null, Properties.Resources.atmosphere, null };

        Forms.FormAtmosphere f;

        Atmosphere atmosphere;

        UserControls.UserControlAtmosphere uc;

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
            atmosphere = o as Atmosphere;
            if (f == null)
            {
                f = new Forms.FormAtmosphere(atmosphere);
            }
            if (f.IsDisposed)
            {
                f = new Forms.FormAtmosphere(atmosphere);
            }
            ob[0] = f;
            if (uc == null)
            {
                uc = new UserControls.UserControlAtmosphere();
                uc.Atmosphere = atmosphere;
            }
            if (uc.IsDisposed)
            {
                uc = new UserControls.UserControlAtmosphere();
                uc.Atmosphere = atmosphere;
            }
            uc = new UserControls.UserControlAtmosphere();
            uc.Atmosphere = atmosphere;
            ob[2] = uc;
            return ob;
        }

        #endregion
    }
}
