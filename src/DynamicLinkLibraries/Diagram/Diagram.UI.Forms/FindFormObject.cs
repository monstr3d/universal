using System;
using System.Windows.Forms;

using CategoryTheory;
using NamedTree;

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
                if (obj is Control c)
                {
                    object o = Find(type, c);
                    if (o != null)
                    {
                        return o;
                    }
                }
                if (obj is IAssociatedObject ao)
                {
                    object o = ao.Object;
                    if (o is Control co)
                    {
                        object ob = Find(type, co);
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
