using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.UI.Attributes
{
    /// <summary>
    /// Url
    /// </summary>
    public class UrlAttribute : Attribute
    {
        #region Fields

        string url;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">Url</param>
        public UrlAttribute(string url)
        {
            this.url = url;
        }

        #endregion

        #region Members

        /// <summary>
        /// Url
        /// </summary>
        public string Url
        {
            get
            {
                return url;
            }
        }

        #endregion
    }
}
