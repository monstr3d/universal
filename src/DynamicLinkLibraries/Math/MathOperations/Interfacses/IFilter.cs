using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations.Interfacses
{
    public interface IFilter<T> where T : struct
    {
        T? this[T? key] { get; }
    }
}
