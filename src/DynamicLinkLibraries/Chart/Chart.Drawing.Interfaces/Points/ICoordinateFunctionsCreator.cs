using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Drawing.Interfaces.Points
{
    public interface ICoordinateFunctionsCreator
    {
        /// <summary>
        /// Creates coordinate Functions
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Func<object, object>[] this[object obj] { get; }

    }
}
