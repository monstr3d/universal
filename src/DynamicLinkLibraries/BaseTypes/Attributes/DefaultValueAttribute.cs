using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes.Attributes
{
    /// <summary>
    /// Attribute of default value
    /// </summary>
    public class DefaultValueAttribute : Attribute
    {
        #region Fields

        /// <summary>
        /// Default value
        /// </summary>
        string defaulValue;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="defaulValue">Default value</param>
        public DefaultValueAttribute(string defaulValue)
        {
            this.defaulValue = defaulValue;
        }

        #endregion

        #region Members

        /// <summary>
        /// Default value
        /// </summary>
        public string DefaultValue
        {
            get
            {
                return defaulValue;
            }
        }

        #endregion

    }
}
