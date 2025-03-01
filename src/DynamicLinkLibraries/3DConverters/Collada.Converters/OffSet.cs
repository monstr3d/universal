using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collada.Converters
{
    public class OffSet
    {

        int offset;

        object value;

        public OffSet(int offset, object value)
        {
            this.offset = offset;
            this.value = value;
        }

        public object Value => value;

        public int Offset => offset;
    }
}
