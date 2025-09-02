using System;
using System.Threading;
using System.Threading.Tasks;

using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;

using ErrorHandler;

using NamedTree;

namespace DataWarehouse.Classes.Abstract.Async
{
    public abstract class Leaf : Abstract.Leaf, ILeafAsync, IDataAsync
    {
        protected virtual event Action<object> OnUpdateData;

        ILeafAsync Async => this;

        event Action<object> ILeafAsync.OnUpdateData
        {
            add
            {
                OnUpdateData += value;
            }

            remove
            {
               OnUpdateData -= value;
            }
        }

        protected virtual void OnUpdateDataAct(object o)
        {
            OnUpdateData?.Invoke(o);
        }

        protected abstract Task<bool> RemoveItselfAsync(CancellationToken cancellationToken);

        protected abstract Task<byte[]> GetDataAsync(CancellationToken cancellationToken);

        async Task<byte[]> IDataAsync.GetDataAsync(CancellationToken cancellationToken)
        {
            if (data == null)
            {
                var t = GetDataAsync(cancellationToken);
                await t;
                data = t.Result;
            }
            return data;
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



        async void CallAsync(CancellationToken cancellationToken)
        {
            ILeafAsync async = this;
            var t = async.RemoveItselfAsync(cancellationToken);
            await t;
        }

        async Task<bool> ILeafAsync.RemoveItselfAsync(CancellationToken cancellationToken)
        {
            var t = RemoveItselfAsync(cancellationToken);
            ILeaf  l = this;
            await t;
            if (t.Result)
            {
                ChildrenName.Remove(this);
                Parent = null;
                var i = new Issue(this, ErrorType.None, OperationType.DeleteLeaf);
                OnDeleteItselfAct(i);
                return t.Result;
            }
            var ii = new Issue(this, ErrorType.Database, OperationType.DeleteLeaf);
            OnDeleteItselfAct(ii);


            return t.Result;
        }


        protected async void CallNameAsync(string name, CancellationToken cancellationToken)
        {
            var t = Async.UpdateNameAsync(name, cancellationToken);
            await t;
        }

        protected abstract Task<byte[]> UpdateDataAcync(byte[] data, CancellationToken cancellationToken);
       
        protected virtual bool UpdateName(string name, CancellationToken cancellationToken)
        {
            try
            {
                if (name != this.name)
                {
                    CallNameAsync(name, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
            return false;

        }

  
        protected abstract Task<string> UpdateNameAsync(string name, CancellationToken cancellationToken);

        protected abstract Task<string> UpdateDescriptionAsync(string description, CancellationToken cancellationToken);

        async Task<string> ILeafAsync.UpdateNameAsync(string name, CancellationToken cancellationToken)
        {
            var s = new UpdateData<string, ILeaf>(this.name, name, this);
            if ((name == this.name) || (!ChildrenName.Check(name)))
            {
                var i = new Issue(s, ErrorType.IllegalName, OperationType.UpdateLeafName);
                OnChangeItselfAct(i);
            }
            var t = UpdateNameAsync(name, cancellationToken);
            await t;
            var r = t.Result;
            if (r == null)
            {
                var ii = new Issue(s, ErrorType.Database, OperationType.UpdateLeafName);
                OnChangeItselfAct(ii);
            }
            this.name = r;
            var iii = new Issue(s, ErrorType.None, OperationType.UpdateLeafName);
            OnChangeItselfAct(iii);
            return r;

        }

        Task<string> ILeafAsync.UpdateDescriptionAsync(string description, CancellationToken cancellationToken)
        {
            return UpdateDescriptionAsync(description, cancellationToken);
        }

      //  protected override byte[] Data {  set => CallAsync(value); }

        protected async void CallAsync(byte[] data, CancellationToken cancellationToken)
        {
            ILeafAsync async = this;
            var t = async.UpdateDataAcync(data, cancellationToken);
            await t;
        }

        async Task<byte[]> ILeafAsync.UpdateDataAcync(byte[] data, CancellationToken cancellationToken)
        {
            var t = UpdateDataAcync(data, cancellationToken);
              await t;
            var r = t.Result;
            var s = new UpdateData<byte[], ILeaf>(data, r, this);
            if (r == null)
            {
                var i = new Issue(s, ErrorType.Database, OperationType.UpdateLeafData);
                OnUpdateDataAct(i);
                return t.Result;
            }
            var ii = new Issue(s, ErrorType.None, OperationType.UpdateLeafData);
            this.data = r;
            OnUpdateDataAct(ii);
            return t.Result;

        }
    }
}