using BaseTypes.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTypes.Interfaces
{
    /// <summary>
    /// Holder of attribute of physical parameters
    /// </summary>
    public interface IPhysicalUnitTypeAttribute
    {
        /// <summary>
        /// Attribute of physical parameters
        /// </summary>
        PhysicalUnitTypeAttribute PhysicalUnitTypeAttribute
        {
            get;
            set;
        }
    }
}
