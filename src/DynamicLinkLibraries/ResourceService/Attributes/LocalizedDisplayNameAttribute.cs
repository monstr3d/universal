using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceService.Attributes
{
    /// <summary>
    /// Localized Display Name Attribute
    /// </summary>
    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="displayName">Display Name</param>
        public LocalizedDisplayNameAttribute(string displayName)
            : base(displayName)
        {
        }
    }
}
