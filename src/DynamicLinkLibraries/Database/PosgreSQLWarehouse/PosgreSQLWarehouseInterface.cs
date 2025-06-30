using DataWarehouse;
using DataWarehouse.Interfaces;
using ErrorHandler;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using System;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PosgreSQLWarehouse
{

    public partial class PosgreSQLWarehouseInterface : IDatabaseInterface
    {
        public string Connection { get; init; }

        IDirectory[] roots;

        public PosgreSQLWarehouseInterface(string connection)
        {
            this.Connection = connection;
        }

        #region Interface Implementstion

        IDirectory[] IDatabaseInterface.GetRoots(params string[] extensions)
        {
            if (roots == null)
            {
                roots = Execute(GetCommandRoots);
                if (roots.Length > 1)
                {
                    Execute(DropTree);
                    CreateRoots();
                }
                if (roots.Length == 0)
                {
                    CreateRoots();
                }
            }
            return roots;
        }

        #endregion

    }

}

