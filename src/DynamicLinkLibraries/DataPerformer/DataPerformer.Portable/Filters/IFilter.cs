using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Portable.Filters
{
    public interface IFilter
    {
        int Count
        { get; set; }

        double? this[double? a] { get; }

        void Reset();
    }
}
