using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Data.Remote.Interfaces
{
    interface IClient
    {
        string[] Register();

        void Unregister();

        event Action<object[]> Read;

        string Url
        {
            get;
        }

        Event.Remote.RemoteType Type
        {
            get;
        }
    }
}
