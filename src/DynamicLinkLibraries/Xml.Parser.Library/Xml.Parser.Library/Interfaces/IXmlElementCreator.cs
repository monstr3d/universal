using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Xml.Parser.Library.Interfaces
{
    /// <summary>
    /// Creator of xml element
    /// </summary>
    public interface IXmlElementCreator
    {
        /// <summary>
        /// Creates Xml Element from strings
        /// </summary>
        /// <param name="text">The strings</param>
        /// <param name="bRow">The begin row</param>
        /// <param name="bColumn">The begin column</param>
        /// <param name="eRow">The end row</param>
        /// <param name="eColumn">The end column</param>
        /// <returns>Created Xml Element</returns>
        XElement Create(IList<string> text, int bRow, int bColumn, int eRow, int eColumn);
    }
}
