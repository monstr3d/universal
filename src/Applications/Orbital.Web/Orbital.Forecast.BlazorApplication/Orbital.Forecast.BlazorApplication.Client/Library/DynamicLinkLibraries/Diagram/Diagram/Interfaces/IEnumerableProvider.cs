using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Provider of IEnumerabe
    /// </summary>
    /// <typeparam name="T">Enumerable type</typeparam>
    public interface IEnumerableProvider<T>
    {
        IEnumerable<T> Enumerable
        {
            get;
        }
    }
}
