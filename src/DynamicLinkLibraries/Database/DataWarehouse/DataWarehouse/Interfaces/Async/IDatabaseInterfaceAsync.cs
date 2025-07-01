using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Interfaces.Async
{
    public interface IDatabaseInterfaceAsync
    {
        Task<IDirectoryAsync[]> GetRoots(string[] extensions);
    }
}
