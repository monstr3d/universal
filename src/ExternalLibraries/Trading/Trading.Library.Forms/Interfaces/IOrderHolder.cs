using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Library.Objects;

namespace Trading.Library.Forms.Interfaces
{
    internal interface IOrderHolder
    {
        Order Order { get; set; }
    }
}
