using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace GeneralNode
{
    /// <summary>
    /// Node of property
    /// </summary>
    public class NodeProperyId : ArbitraryNode
    {

        #region Fields

        string idName = null;

  //      string parentIdName = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="o">Associated object</param>
        public NodeProperyId(object o)
            : base(o)
        {
        }

        #endregion

        /// <summary>
        /// Id
        /// </summary>
        public override object Id
        {
            get 
            {
                PropertyInfo pi = obj.GetType().GetProperty(idName);
                return pi.GetValue(obj, null);
            }
        }

        /// <summary>
        /// Parent id
        /// </summary>
        public override object ParentId
        {
            get 
            {
                PropertyInfo pi = obj.GetType().GetProperty(idName);
                return pi.GetValue(obj, null);
            }
        }
    }
}
