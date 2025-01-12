using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Interfaces.Attributes
{
    /// <summary>
    /// Attribute of type
    /// </summary>
    public class MeasurementTypeAttribute : Attribute
    {
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="type"></param>
        public MeasurementTypeAttribute(Type type)
        {
            Type = type;
        }
        Type Type { get; }
    }
}
