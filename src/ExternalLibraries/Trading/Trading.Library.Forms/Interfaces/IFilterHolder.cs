using DataPerformer.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.Library.Forms.Interfaces
{
    internal interface IFilterHolder
    {
        FilterWrapper Filter { get; set; }
    }
}

