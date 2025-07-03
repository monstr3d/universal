using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PostgreSQLWarehouse.Async
{
    public partial class PostgreSQLWarehouseInterface : PostgreSQLWarehouse.PostgreSQLWarehouseInterface,
        IDatabaseInterfaceAsync
    {
        IDirectoryAsync[] roots;
        public PostgreSQLWarehouseInterface(string connection) : base(connection)
        {

        }

        internal async Task<byte[]> GetDataAsync(ILeaf leaf)
        {
            var t = Execute(GetDataAsync, leaf);
            await t;
            return t.Result;
        }

        async Task<IDirectoryAsync[]> IDatabaseInterfaceAsync.GetRoots(string[] extensions)
        {
            if (roots == null)
            {
                var t = Execute(GetCommandRootsAsync);
                await t;
                roots = t.Result.ToArray();
            }
            return roots;
        }

       internal async  Task<string> UpdateDirNameAsync(string name, IDirectory dir)
        {
            var t = Execute(UpdateDirNameAsync, name, dir);
            await t;
            return t.Result;
        }

        async Task<string> UpdateDirDecriptionAsync(string descrption, IDirectory dir)
        {
            var t = Execute(UpdateDirDecriptionAsync, descrption, dir);
            await t;
            return t.Result;
        }

        async Task<string> UpdateLeafNameAsync(string name, ILeaf leaf)
        {
            var t = Execute(UpdateLeafNameAsync, name, leaf);
            await t;
            return t.Result;
        }

        async Task<string> UpdateLeafrDecriptionAsync(string descrption, ILeaf leaf)
        {
            var t = Execute(UpdateLeafrDecriptionAsync, descrption, leaf);
            await t;
            return t.Result;
        }



        internal async Task<IDirectoryAsync> Add(IDirectory parent, IDirectory directory)
        {
            var t = Execute(Add, parent, directory);
            await t;
            return t.Result;
        }

        internal async Task<ILeafAsync> Add(IDirectory parent, ILeafData leaf)
        {
            var t = Execute(Add, parent, leaf);
            await t;
            return t.Result;

        }


        internal async Task<List<IDirectoryAsync>> LoadChildren(IDirectory dir)
        {
            var t = Execute(GetChildrenAsync, dir);
            await t;
            return t.Result;
        }

        internal async Task<object> RemoveAsync(IDirectory directory)
        {
            var t = Execute(RemoveAsync, directory);
            await t;
            return t.Result;
        }

        internal async Task<bool> RemoveAsync(ILeaf leaf)
        {
            var t = Execute(RemoveAsync, leaf);
            await t;
            return t.Result != null;
        }


        internal async Task<byte[]> UpdateDataAcync(byte[] data, ILeafData leaf)
        {
            var t = Execute(UpdateDataAcync, data, leaf);
            await t;
            return t.Result;
        }

        internal async Task<List<ILeafAsync>> GetLeavesAsync(IDirectory d)
        {
            var t = Execute(GetLeavesAsync, d);
            await t;
            return t.Result;
        }

    }
}
