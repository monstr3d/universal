using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceService.Attributes
{
    /// <summary>
    /// Localized Description Attribute
    /// </summary>
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="description">Description</param>
        public LocalizedDescriptionAttribute(string description)
            : base(description.ToLocalizedAttribute())
        {

        }
    }
}
