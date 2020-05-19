using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.Attributes;



namespace Celestrak.NORAD.Satellites.UI
{
    /// <summary>
    /// Wrapper of properties
    /// </summary>

    [LinkedType(typeof(SatelliteData))]
    public class PropertiesWrapper : ISeparatedPropertyEditor
    {
        #region Fields

        object o;

        object[] ob = new object[] { null, Properties.Resources.celestrak };

        System.Windows.Forms.Form f;


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
            IChildrenObject c = o as IChildrenObject;
            if (c.Children != null)
            {
                if (c.Children[0] != null)
                {
                    f = new Forms.FormNORADChild(o as SatelliteData);
                    ob[0] = f;
                    return ob;
                }
            }
            f = new Forms.FormNORAD(o as SatelliteData);
            ob[0] = f;
            return ob;
        }

        #endregion
 
    }
}
