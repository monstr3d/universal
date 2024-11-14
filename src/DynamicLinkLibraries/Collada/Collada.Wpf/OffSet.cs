using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collada.Wpf
{
    public class OffSet
    {

        int offset;

        object obj;

        public OffSet(int offset, object obj)
        {
            this.offset = offset;
            this.obj = obj;
        }

        public object Object => obj;

        public int Offset => offset;
    }
}
