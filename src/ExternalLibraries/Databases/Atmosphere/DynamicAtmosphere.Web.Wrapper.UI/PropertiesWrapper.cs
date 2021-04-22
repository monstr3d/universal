using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI.Interfaces;

namespace DynamicAtmosphere.Web.Wrapper.UI
{
    /// <summary>
    /// Wrapper of properties
    /// </summary>
    public class PropertiesWrapper : ISeparatedPropertyEditor
    {

        #region Fields

        object[] ob = new object[] { null, Properties.Resources.atmosphere };

        Atmosphere atmosphere;

        #endregion

        #region ISeparatedPropertyEditor Members

        object ISeparatedPropertyEditor.GetEditor(object o)
        {
            atmosphere = o as Atmosphere;
            ob[0] = Form;
            return ob;
        }

        #endregion

        #region Private

        object Child
        {
            get
            {
                IChildrenObject co = atmosphere;
                IAssociatedObject[] ao = co.Children;
                if (ao == null)
                {
                    return null;
                }
                return ao[0];
            }
        }

        System.Windows.Forms.Form Form
        {
            get
            {
                System.Windows.Forms.Form f = null;
                if (ob[0] != null)
                {
                    f = ob[0] as System.Windows.Forms.Form;
                    if (f != null)
                    {
                        if (!f.IsDisposed)
                        {
                            return f;
                        }
                    }
                }
                object child = Child;
                if (child != null)
                {
                    f = new Forms.FormAtmosphereChild(atmosphere);
                }
                else
                {
                    f = new Forms.FormAtmosphere(atmosphere);
                }
                return f;
            }
        }

        #endregion
    }
}
