using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blender.Wrapper
{
    internal class FileReader
    {

        internal Func<FileReader, byte[], Int64, Int64> Read { get; set; } = null;

        internal Func<FileReader, Int64, Int64> Seek { get; set; } = null;

        internal Action<FileReader> Close { get; set; } = null;

    }
}


