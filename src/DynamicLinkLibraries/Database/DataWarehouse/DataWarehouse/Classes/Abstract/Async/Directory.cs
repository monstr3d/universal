using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Classes.Abstract.Async
{
    public abstract class Directory : Abstract.Directory, IDirectoryAsync
    {

        protected abstract Task<List<IDirectoryAsync>> LoadChildren();

        protected abstract Task<List<ILeafAsync>> LoadLeaves();

        protected abstract Task<bool> RemoveItselfAsync();

        protected abstract Task<IDirectoryAsync> Add(IDirectory directory);
   
        async Task<IDirectoryAsync> IDirectoryAsync.Add(IDirectory directory)
        {
            var t = Add(directory);
            t.GetAwaiter().OnCompleted(() =>
            {
                
                if (t.Result == null)
                {
                    return;
                }
                var dir = t.Result as Directory;
                dir.Parent = this;
                directories.Add(dir);
                Names.Add(dir.Name);
                OnAddDirectoryAct(t.Result as IDirectory);
            });
            await t;
            return t.Result;
        }

        async Task IDirectoryAsync.LoadChildren()
        {
            if (directories != null)
            {
                return;
            }
            directories = new List<IDirectory>();
            GetChildern = () => directories;
            var t = LoadChildren();
            await t;
            var r = t.Result;
            var c = from dir in r select AddExternalDirectory(dir as IDirectory);
            c.ToArray();
        }

        async Task IDirectoryAsync.LoadLeaves()
        {
            if (leaves != null)
            {
                return;
            }

            leaves = new List<ILeaf>();
            GetLeaves = () => leaves;
            var t = LoadLeaves();
            await t;
            var r = t.Result;
            var c = from leaf in r select AddExternalLeaf(leaf as ILeaf, true);
            c.ToArray();
        }

        Task<bool> IDirectoryAsync.RemoveItselfAsync()
        {
            return RemoveItselfAsync();
        }
    }
}