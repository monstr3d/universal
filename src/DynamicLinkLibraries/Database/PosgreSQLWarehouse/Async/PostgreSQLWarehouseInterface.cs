using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQLWarehouse.Async
{
    public partial class PostgreSQLWarehouseInterface : PostgreSQLWarehouse.PostgreSQLWarehouseInterface,  IDatabaseInterfaceAsync
    {
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
            var t = Execute(GetCommandRootsAsync);
            await t;
            return t.Result.ToArray();
        }

        internal async Task<IDirectoryAsync> Add(IDirectory parent, IDirectory directory)
        {
            var t = Execute(Add, parent, directory);
            await t;
            return t.Result;
        }

        internal async Task<ILeafAsync> Add(IDirectory parent, ILeafData directory)
        {
            var t = Execute(Add, parent, directory);
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

        internal async Task<object> RemoveAsync(ILeaf leaf)
        {
            var t = Execute(RemoveAsync, leaf);
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
