using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Standard
{
    interface ILimitIndicatorFactory
    {
        event Action<string, Func<object>, float[]> OnAdd;
    }
}
