using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CategoryTheory;

namespace Diagram.UI
{
    /// <summary>
    /// Finds  form
    /// </summary>
    public class FindFormObject : IFindObject
    {

        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly FindFormObject Singleton = new FindFormObject();

        #endregion

        #region Ctor

        private FindFormObject()
        {
        }

        #endregion

        #region IFindObject Members

        object IFindObject.this[Type type, object obj]
        {
            get 
            { 
                if (obj is Control)
                {
                    object o = Find(type, (obj as Control));
                    if (o != null)
                    {
                        return o;
                    }
                }
                if (obj is IAssociatedObject)
                {
                    object o = (obj as IAssociatedObject).Object;
                    if (o is Control)
                    {
                        object ob = Find(type, (o as Control));
                        if (ob != null)
                        {
                            return ob;
                        }
                    }
                }
                return null;
            }
        }

        #endregion

        #region Private Members

        object Find(Type type, Control control)
        {
            Type t = control.GetType();
            if (t.GetInterface(type.FullName, false) != null)
            {
                return control;
            }
            foreach (Control c in control.Controls)
            {
                object o = Find(type, c);
                if (o != null)
                {
                    return o;
                }

            }
            return null;
       }

        #endregion

    }
}
