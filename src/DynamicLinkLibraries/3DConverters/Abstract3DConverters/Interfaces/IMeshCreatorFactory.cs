using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters.Interfaces
{
    public interface IMeshCreatorFactory
    {
        IMeshCreator this[string filename] { get;  }
    }
}
