using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class ReadOnlyList<T> : List<T> , IReadOnlyCollection<T>
    {
        public ReadOnlyList() { }
    }
}
