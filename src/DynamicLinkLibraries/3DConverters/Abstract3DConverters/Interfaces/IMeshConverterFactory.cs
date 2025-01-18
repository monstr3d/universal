using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMeshConverterFactory
    {
        IMeshConverter this[string extension, string comment] { get; }
    }
}
