using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using ErrorHandler;
using NamedTree;

namespace DataWarehouse.Classes.Abstract.Async
{
    public abstract class Directory : Abstract.Directory, IDirectoryAsync
    {

        #region Ctor

        protected Directory(bool children) : base(children) { }

        #endregion

        #region Abstract
        protected abstract Task<List<IDirectoryAsync>> LoadChildren();

        protected abstract Task<List<ILeafAsync>> LoadLeaves();

        protected abstract Task<bool> RemoveItselfAsync();

        /// <summary>
        /// Adds a leaf
        /// </summary>
        /// <param name="leaf">Prototype</param>
        /// <returns>THe added leaf</returns>
        protected abstract Task<IDirectoryAsync> AddAsync(IDirectory directory);
 
        protected abstract Task<ILeafAsync> AddAsync(ILeaf leaf);

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
        protected abstract Task<string> UpdateDescriptionAsync(string description);

        #endregion

        #region Overriden

        protected override ILeaf Add(ILeaf leaf)
        {
            try
            {
                 CallAsync(leaf);
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }



        protected override IDirectory Add(IDirectory directory)
        {
            if (!ParentChildrenName.Check(directory))
            {
                var i = Get(directory, ErrorType.IllegalName, OperationType.AddDirectory);
                OnAddDirectoryAct(i);
                return directory;
            }
            try
            {
                CallAsync(directory);
            }
            catch (Exception exception)
            {
                exception.HandleException();
            }
            return null;
        }

        protected override void RemoveItself()
        {
            try
            {
                CallAsync();
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Remove database binary item");
            }

        }

        protected override bool UpdateName(string name)
        {
            var p = Parent as Directory;
            INamed n = this;
            if (!p.Check(name))
            {
                OnChangeItselfAct(this);
                return false;
            }
            CallAsyncName(name);
            return true;
        }



        #endregion

        #region Children name


        IChildrenName ChildrenName => this;

        IChildrenName ParentChildrenName => Parent as IChildrenName;

        #endregion

        #region Calls

        protected async void CallAsyncName(string name)
        {
            var async = this as IDirectoryAsync;
            var t = async.UpdateNameAsync(name);
            await t;
        }


        protected async void CallAsync(ILeaf leaf)
        {
            var async = this as IDirectoryAsync;
            var t = async.AddAsync(leaf);
            await t;
        }


        async void CallAsync(IDirectory dir)
        {
            IDirectoryAsync async = this;
            var t = async.AddAsync(dir);
            await t;
        }

        async void CallAsync()
        {
            var async = this as IDirectoryAsync;
            var t = async.RemoveItselfAsync();
            t.GetAwaiter().OnCompleted(() =>
            {
                if (!t.Result)
                {
                    OnDeleteItselfAct(this);
                    return;
                }
                IDirectory dr = this;
                var p = dr.Parent as Directory;
                IChildren<IDirectory> cd = p;
                cd.RemoveChild(this);
                Parent = null;
                var i = Get(this, ErrorType.None, OperationType.DeleteDirectory);
                OnDeleteItselfAct(i);
            });

            await t;
        }

        #endregion


        async Task<ILeafAsync> IDirectoryAsync.AddAsync(ILeaf leaf)
        {
            if (!ChildrenName.Check(leaf))
            {
                var i = Get(leaf, ErrorType.IllegalName, OperationType.AddLeaf);
                OnAddLeafAct(i);
                return null;
            }
            var t = AddAsync(leaf);
            t.GetAwaiter().OnCompleted(() =>
            {

                var l = t.Result as ILeaf;
                if (l == null)
                {
                    var ii = Get(leaf, ErrorType.Database, OperationType.AddLeaf);
                    return;
                }
                ChildrenName.Add(l);
                var i = Get(leaf, ErrorType.None, OperationType.AddLeaf);
                OnAddLeafAct(i);
            });
            await t;
            return t.Result;
        }


        async Task<IDirectoryAsync> IDirectoryAsync.AddAsync(IDirectory directory)
        {
            if (!ChildrenName.Check(directory))
            {
                var i = Get(directory, ErrorType.IllegalName, OperationType.AddDirectory);
                OnAddDirectoryAct(i);
                return this;
            }
            var t = AddAsync(directory);
            t.GetAwaiter().OnCompleted(() =>
            {
                if (t.Result == null)
                {
                    OnAddDirectoryAct(Get(directory, ErrorType.Database, OperationType.AddDirectory));
                    return;
                }
                var dir = t.Result as IDirectory;
                ChildrenName.Add(dir);
                var i = Get(dir, ErrorType.None, OperationType.AddDirectory);
                OnAddDirectoryAct(i);
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

        async Task<string> IDirectoryAsync.UpdateNameAsync(string name)
        {
            var n = Name;
            if (n == name)
            {
                return name;
            }
            INamed mn = this;
            var d = Parent as Directory;
            if (!d.Check(name))
            {
                OnChangeItselfAct(this);
            }
              var t = UpdateNameAsync(name);
            t.GetAwaiter().OnCompleted(() =>
            {
                OnChangeItselfAct(this);
            });
            await t;
            return t.Result;
        }

        
 
        Task<string> IDirectoryAsync.UpdateDescriptionAsync(string description)
        {
            return UpdateDescriptionAsync(description);
        }
    }
}