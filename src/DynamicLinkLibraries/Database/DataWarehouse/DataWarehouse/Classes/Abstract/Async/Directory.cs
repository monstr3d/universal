using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using ErrorHandler;
using NamedTree;

namespace DataWarehouse.Classes.Abstract.Async
{
    public abstract class Directory : Abstract.Directory, IDirectoryAsync
    {

        protected abstract SyncMode SyncMode { get; }


        SyncMode IDirectoryAsync.SyncMode => SyncMode;

        #region Ctor

        protected Directory(bool children) : base(children) 
        {
            AddLeaf = AddAsyncLeaf;
        }

        #endregion

        #region Abstract
        protected abstract Task<List<IDirectoryAsync>> LoadChildren(CancellationToken cancellationToken);

        protected abstract Task<List<ILeafAsync>> LoadLeaves(CancellationToken cancellationToken);

        protected abstract Task<bool> RemoveItselfAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Adds a leaf
        /// </summary>
        /// <param name="leaf">Prototype</param>
        /// <returns>THe added leaf</returns>
        protected abstract Task<IDirectoryAsync> AddAsync(IDirectory directory, CancellationToken cancellationToken);
 
        protected abstract Task<ILeafAsync> AddAsync(ILeaf leaf, CancellationToken cancellationToken);

        /// <summary>
        /// Updates Name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The name</returns>
        protected abstract Task<string> UpdateNameAsync(string name, CancellationToken cancellationToken);

        /// <summary>
        /// Updates Description
        /// </summary>
        /// <param name="name">The description</param>
        /// <returns>The description</returns>
        protected abstract Task<string> UpdateDescriptionAsync(string description, CancellationToken cancellationToken);

        #endregion

        #region 

        protected  virtual List<ILeaf> GetLeavesFormDatabase(CancellationToken cancellationToken)
        {
            var t = LoadLeaves(cancellationToken); ;
            var r = t.Result;
              var lold = leaves;
            if (r == null)
            {
                var s = new UpdateData<List<ILeaf>, IDirectory>(leaves, null, this);
                var iss = new Issue(s, ErrorType.Database, OperationType.LoadLeaves);
                OnGetLeavesAct(iss);
                return null;
            }
            leaves = new List<ILeaf>();
            GetLeaves = () => leaves;
            var c = from d in r select d as ILeaf;
            var cc = c.ToList();
            var ct = from cit in cc select ChildrenName.Add(cit);
            ct.ToArray();
            var ss = new UpdateData<List<ILeaf>, IDirectory>(leaves, cc, this);
            var issue = new Issue(ss, ErrorType.None, OperationType.LoadLeaves);
            OnGetLeavesAct(issue);

            if (leaves == null)
            {
                throw new OwnException();
            }
            return leaves;

        }


        protected virtual List<ILeaf> GetFuncLeafInitial(CancellationToken cancellationToken)
        {
            var leaves = GetLeavesFormDatabase(cancellationToken);
            GetLeaves = () => leaves;
            return leaves;
        }



        protected  List<IDirectory> GetDirectoriesFormDatabase(CancellationToken cancellationToken)
        {
            var t = LoadChildren(cancellationToken);
            var r = t.Result;
            var dd = directories;
            if (r == null)
            {
                var s = new UpdateData<List<IDirectory>, IDirectory>(directories, null, this);
                var iss = new Issue(s, ErrorType.Database, OperationType.LoadDirectories);
                OnGetDirectoriesAct(iss);
                return null;
            }
            directories = new List<IDirectory>();
            GetChildern = () => directories;
            var cp = from d in r select  (d as IDirectory).Post();
            cp.ToArray();
            var c = from d in r select d as IDirectory;
            var cc = c.ToList();
            if (directories.Count > 0)
            {
                throw new OwnException();
            }
            var ct = from cit in cc select ChildrenName.Add(cit);
            ct.ToArray();
            var ss = new UpdateData<List<IDirectory>, IDirectory>(directories, cc, this);
            var issue = new Issue(ss, ErrorType.None, OperationType.LoadDirectories);
            OnGetDirectoriesAct(issue);
            return directories;
        }

        protected async Task LoadDirectoriesFormDatabase(CancellationToken cancellationToken)
        {
            var t = LoadChildren(cancellationToken);
            await t;
        }

    

        protected async Task LoadLeavesFormDatabaseAsync(CancellationToken cancellationToken)
        {
            IDirectoryAsync async = this;
            var t = async.LoadLeaves(cancellationToken);
            await t;
        }

        protected async Task LoadLeavesFormDatabaseAsync(AutoResetEvent e, CancellationToken cancellationToken)
        {
            IDirectoryAsync async = this;
            var t = async.LoadLeaves(cancellationToken);
            await t;
            e.Set();
        }


        protected async Task LoadDirectoriesFormDatabaseAsync(AutoResetEvent e, CancellationToken cancellationToken)
        {
            IDirectoryAsync async = this;
            var t = async.LoadChildren(cancellationToken);
            await t;
            e.Set();
        }

        async Task LoadLeavesFormDataAsync(AutoResetEvent ev, CancellationToken cancellationToken)
        {
            var t = LoadLeavesFormDatabaseAsync(cancellationToken);
            await t;
            ev.Set();
        }

        Func<ILeaf, CancellationToken, ILeaf> AddLeaf;

        protected ILeaf AddAsyncLeaf(ILeaf leaf, CancellationToken cancellationToken)
        {
            try
            {
                CallAsync(leaf, cancellationToken);
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;

        }

        protected virtual async Task<ILeaf> AddSyncLeaf(ILeaf leaf, CancellationToken cancellationToken)
        {
            try
            {

                var async = this as IDirectoryAsync;
                var t = async.AddAsync(leaf, cancellationToken);
                if (SyncMode == SyncMode.Asynchronous)
                {
                    await t;
                }
                return t.Result as ILeaf;
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;

        }

        protected IDirectoryAsync DirectoryAsync => this;

        protected override bool Post()
        {
            return true;
        }

        protected ILeaf Add(ILeaf leaf, CancellationToken cancellationToken)
        {
            Exception ex = null;
            try
            {
                return AddLeaf(leaf, cancellationToken);
            }
            catch (Exception e)
            {
                ex = IncludedException.Get(e);
            }
            throw ex;
        }

        protected  IDirectory Add(IDirectory directory, CancellationToken cancellationToken)
        {
            if (!ParentChildrenName.Check(directory))
            {
                var i = Get(directory, ErrorType.IllegalName, OperationType.AddDirectory);
                OnAddDirectoryAct(i);
                return directory;
            }
            try
            {
                CallAsync(directory, cancellationToken);
            }
            catch (Exception exception)
            {
                exception.HandleException();
            }
            return null;
        }

        protected virtual void RemoveItself(CancellationToken cancellationToken)
        {
            try
            {
                CallAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Remove database binary item");
            }

        }

        protected bool UpdateName(string name, CancellationToken cancellationToken)
        {
            CallAsyncName(name, cancellationToken);
            return true;
        }



        #endregion


        #region Calls

        protected async void CallAsyncName(string name, CancellationToken cancellationToken)
        {
            var async = this as IDirectoryAsync;
            var t = async.UpdateNameAsync(name, cancellationToken);
            await t;
        }


        protected async void CallAsync(ILeaf leaf, CancellationToken cancellationToken)
        {
            var async = this as IDirectoryAsync;
            var t = async.AddAsync(leaf, cancellationToken);
            await t;
        }


        async void CallAsync(IDirectory dir, CancellationToken cancellationToken)
        {
            IDirectoryAsync async = this;
            var t = async.AddAsync(dir, cancellationToken);
            await t;
        }

        async void CallAsync(CancellationToken cancellationToken)
        {
            var async = this as IDirectoryAsync;
            var t = async.RemoveItselfAsync(cancellationToken);
   
            await t;
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

        }

        #endregion


        async Task<ILeafAsync> IDirectoryAsync.AddAsync(ILeaf leaf, CancellationToken cancellationToken)
        {
            if (!ChildrenName.Check(leaf))
            {
                var iss = Get(leaf, ErrorType.IllegalName, OperationType.AddLeaf);
                OnAddLeafAct(iss);
                return null;
            }
            var t = AddAsync(leaf, cancellationToken);
            await t;
            if (t == null || t.Result == null)
            {
                var ii = Get(leaf, ErrorType.Database, OperationType.AddLeaf);
                return null;
            }
            var l = t.Result as ILeaf;
            if (l == null)
            {
                throw new OwnException();
            }
            ChildrenName.Add(l);
            var i = Get(leaf, ErrorType.None, OperationType.AddLeaf);
            OnAddLeafAct(i);
            return t.Result;
        }


        async Task<IDirectoryAsync> IDirectoryAsync.AddAsync(IDirectory directory, CancellationToken cancellationToken)
        {
            if (!ChildrenName.Check(directory))
            {
                var ii = Get(directory, ErrorType.IllegalName, OperationType.AddDirectory);
                OnAddDirectoryAct(ii);
                return this;
            }
            var t = AddAsync(directory, cancellationToken);
            await t;
            var r = t.Result;
            if (r == null)
            {
                OnAddDirectoryAct(Get(directory, ErrorType.Database, OperationType.AddDirectory));
                return r;
            }
            var dir = r as IDirectory;
            dir.Post();
            ChildrenName.Add(dir);
            var i = Get(dir, ErrorType.None, OperationType.AddDirectory);
            OnAddDirectoryAct(i);
            return r;
        }

        async Task IDirectoryAsync.LoadChildren(CancellationToken cancellationToken)
        {
            if (directories != null)
            {
                var s = new UpdateData<List<IDirectory>, IDirectory>(directories, null, this);
                var iss = new Issue(s, ErrorType.AlreadyExecuted, OperationType.LoadDirectories);
                OnGetDirectoriesAct(iss);
                return;
            }
            var t = LoadChildren(cancellationToken);
            await t;
            var dd = directories;
            var r = t.Result;
            if (r == null)
            {
                var s = new UpdateData<List<IDirectory>, IDirectory>(directories, null, this);
                var iss = new Issue(s, ErrorType.Database, OperationType.LoadDirectories);
                OnGetDirectoriesAct(iss);
                return;
            }
            directories = new List<IDirectory>();
            GetChildern = () => directories;
            var c = from d in r select d as IDirectory;
            var cc = c.ToList();
            var cb = from cd in r select (cd as IDirectory).Post();
            cb.ToList();
            if (directories.Count > 0)
            {
                throw new OwnException();
            }
            var ct = from cit in cc select ChildrenName.Add(cit);
            ct.ToArray();
            var ss = new UpdateData<List<IDirectory>, IDirectory>(directories, cc, this);
            var issue = new Issue(ss, ErrorType.None, OperationType.LoadDirectories);
            OnGetDirectoriesAct(issue);


        }

        async Task IDirectoryAsync.LoadLeaves(CancellationToken cancellationToken)
        {
            var ll = leaves;
            if (leaves != null)
            {
                var s = new UpdateData<List<ILeaf>, IDirectory>(null, null, this);
                var iss = new Issue(s, ErrorType.AlreadyExecuted, OperationType.LoadLeaves);
                OnGetLeavesAct(iss);
                return;
            }
            var t = LoadLeaves(cancellationToken);
            await t;
            leaves = new List<ILeaf>();
            var r = t.Result;
            GetLeaves = () => leaves;
            var c = from d in r select d as ILeaf;
            var cc = c.ToList();
            var ct = from cit in cc select ChildrenName.Add(cit);
            ct.ToArray();
            var ss = new UpdateData<List<ILeaf>, IDirectory>(leaves, cc, this);
            var issue = new Issue(ss, ErrorType.None, OperationType.LoadLeaves);
            OnGetLeavesAct(issue);
        }

        Task<bool> IDirectoryAsync.RemoveItselfAsync(CancellationToken cancellationToken)
        {
            return RemoveItselfAsync(cancellationToken);
        }

        async Task<string> IDirectoryAsync.UpdateNameAsync(string name, CancellationToken cancellationToken)
        {
            var s = new UpdateData<string, IDirectory>(this.name, name, this);
            if ((name == this.name) || (!ParentChildrenName.Check(name)))
            {
                var i = new Issue(s, ErrorType.IllegalName, OperationType.UpdateDirectoryName);
                OnChangeItselfAct(i);
            }
            var n = Name;
            if (n == name)
            {
                return name;
            }
            var t = UpdateNameAsync(name, cancellationToken);
            await t;
            var r = t.Result;
            if (r == null)
            {
                var ii = new Issue(s, ErrorType.Database, OperationType.UpdateDirectoryName);
                OnChangeItselfAct(ii);
            }
            this.name = r;
            var iii = new Issue(s, ErrorType.None, OperationType.UpdateDirectoryName);
            OnChangeItselfAct(iii);

            return t.Result;
        }

        
 
        Task<string> IDirectoryAsync.UpdateDescriptionAsync(string description, CancellationToken cancellationToken)
        {
            return UpdateDescriptionAsync(description, cancellationToken);
        }
    }
}