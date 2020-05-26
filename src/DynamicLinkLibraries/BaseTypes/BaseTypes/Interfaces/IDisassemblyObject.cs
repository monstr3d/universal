using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTypes.Interfaces
{
    /// <summary>
    /// Disassemlies object
    /// </summary>
    public interface IDisassemblyObject
    {
        /// <summary>
        /// Returns of the object or required type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IDisassemblyObject this[object type]
        { get; }

        /// <summary>
        /// Names of subobjects
        /// </summary>
        List<Tuple<string, object>>  Types
        { get; }

        /// <summary>
        /// Dissaseblies objects
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        object[] Disassembly(object obj);

    }
}
