using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Log.Database.Interfaces
{
    interface IParentSet
    {
        ILogItem Parent
        {
            set;
        }
    }
}
