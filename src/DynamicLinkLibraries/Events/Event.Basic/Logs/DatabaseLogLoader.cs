using Event.Interfaces;
using Event.Log.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Basic.Logs
{
    class DatabaseLogLoader : ILogLoader
    {
 
        object ILogLoader.Load(string url, uint begin, uint end)
        {
            object loader =  url.LogFromUrl();
            return loader;
        }
    }
}
