using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceService.Attributes
{
    /// <summary>
    /// Localized Category Attribute
    /// </summary>
    public class LocalizedCategoryAttribute : CategoryAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="category">Category</param>
        public LocalizedCategoryAttribute(string category)
            : base(category.ToLocalizedAttribute())
        {
        }
    }
}
