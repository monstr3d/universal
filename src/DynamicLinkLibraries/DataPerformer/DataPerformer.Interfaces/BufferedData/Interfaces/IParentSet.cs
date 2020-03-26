using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Interfaces.BufferedData.Interfaces
{
    interface IParentSet
    {
        IBufferItem Parent
        {
            set;
        }
    }
}
