using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI.Interfaces;
using Diagram.UI.Attributes;

namespace DynamicAtmosphere.MSISE.Wrapper.UI
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

        System.Windows.Forms.UserControl uc;

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
                uc = Create(atmosphere);
            }
            if (uc.IsDisposed)
            {
                uc = Create(atmosphere);
            }
            ob[2] = uc;
            return ob;
        }

 
        #endregion

        #region Private Members

        System.Windows.Forms.UserControl Create(Atmosphere atmosphere)
        {
            if (atmosphere.Alias == null)
            {
                UserControls.UserControlAtmosphereFull ucc =
                    new UserControls.UserControlAtmosphereFull();
                ucc.Atmosphere = atmosphere;
                return ucc;
             }
            UserControls.UserControlAtrmosphereShort uc =
               new UserControls.UserControlAtrmosphereShort();
            uc.Atmosphere = atmosphere;
            return uc;
        }

        #endregion
    }
}
