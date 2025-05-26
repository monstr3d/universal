using DataWarehouse.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataWarehouse.React.Server.Interfaces
{
    interface IDataController
    {
        IDirectory CreateDirectory(object id, IDirectory dir)
        {
            return null;
        }

        void UpdateDirectory(IDirectory dir)
        {

        }

        IDirectory Create(object id, IDirectory dir)
        {
            return null;
        }


        IEnumerable<IDirectory> GetDirectories(object id)
        {
            return null;
        }

        IEnumerable<IDirectory> GetRoots()
        {
            return null;
        }

        IDirectory Delete(object id)
        {
            return null;
        }


    }
}
