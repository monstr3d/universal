using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters.Interfaces
{
    public interface ISaveToStream
    {
        void Save(object obj, Stream stream);
    }
}
