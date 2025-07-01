using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// Updates Name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The name</returns>
        protected abstract Task<string> UpdateNameAsync(string name);

        /// <summary>
        /// Updates Description
        /// </summary>
        /// <param name="name">The description</param>
        /// <returns>The description</returns>
        protected abstract Task<string> UpdateDescriptionAsync(string descriptuin);




        /// <summary>
        /// Adds a leaf
        /// </summary>
        /// <param name="leaf">Prototype</param>
        /// <returns>THe added leaf</returns>
        protected abstract Task<ILeafAsync> Add(ILeaf leaf);

        async Task<ILeafAsync> IDirectoryAsync.Add(ILeaf leaf)
        {
            var t = Add(leaf);
            t.GetAwaiter().OnCompleted(() =>
            {

                if (t.Result == null)
                {
                    return;
                }
                var l = t.Result as ILeaf;
                l.Parent = this;
                leaves.Add(l);
                Names.Add(l.Name);
                OnAddLeafAct(l);
            });
            await t;
            return t.Result;
        }


        async Task<IDirectoryAsync> IDirectoryAsync.Add(IDirectory directory)
        {
            var t = Add(directory);
            t.GetAwaiter().OnCompleted(() =>
            {
                
                if (t.Result == null)
                {
                    return;
                }
                var dir = t.Result as IDirectory;
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

        async  Task<string> IDirectoryAsync.UpdateNameAsync(string name)
        {
            var n = Name;
            if (n == name)
            {
                return name;
            }
            var t = UpdateNameAsync(name);
            t.GetAwaiter().OnCompleted(() =>
            {

            });
            await t;
        }

        Task<string> IDirectoryAsync.UpdateDescriptionAsync(string descriptuin)
        {
            return UpdateDescriptionAsync(descriptuin);
        }
    }
}