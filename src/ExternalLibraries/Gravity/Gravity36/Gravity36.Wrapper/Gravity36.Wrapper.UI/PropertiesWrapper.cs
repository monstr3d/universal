using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI.Attributes;
using Diagram.UI.Interfaces;


namespace Gravity36.Wrapper.UI
{
    /// <summary>
    /// Wrapper of properties
    /// </summary>
    [LinkedType(typeof(Gravity))]
    public class PropertiesWrapper : ISeparatedPropertyEditor
    {
        #region Fields

        object o;

        object[] ob = new object[] { null, Properties.Resources.EARTH };

        Forms.FormEditor f;

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
            f = new Forms.FormEditor(o as Gravity);
            ob[0] = f;
            return ob;
        }

        #endregion
    }
}
