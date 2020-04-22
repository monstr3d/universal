using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI.Interfaces;
using Diagram.UI.Attributes;

using CelestialMechanics.Wrapper;

namespace CelestialMechanics.Wrapper.UI
{
    /// <summary>
    /// Wrapper of properties
    /// </summary>
    [LinkedType(typeof(CelestialMechanics.Wrapper.Classes.Orbit))]
    public class PropertiesWrapper : ISeparatedPropertyEditor
    {
        #region Fields

        CelestialMechanics.Wrapper.Classes.Orbit orbit;

        object[] ob = new object[] { null, Properties.Resources.Space, null };

        Forms.FormOrbital f;

        UserControls.UserControlOrbitReadOnly uc;


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
            orbit = o as CelestialMechanics.Wrapper.Classes.Orbit;
            if (orbit.Alias == null)
            {
                if (f != null)
                {
                    if (!f.IsDisposed)
                    {
                        return ob;
                    }
                }
                f = new Forms.FormOrbital(orbit);
                ob[0] = f;
                return ob;
            }
            if (uc == null)
            {
                uc = new UserControls.UserControlOrbitReadOnly();
                uc.Orbit = orbit;
                ob[2] = uc;
                return ob;
            }
            if (!uc.IsDisposed)
            {
                return ob;
            }
            uc = new UserControls.UserControlOrbitReadOnly();
            uc.Orbit = orbit;
            ob[2] = uc;
            return ob;
        }

        #endregion

    }
}
