using System;
using System.ComponentModel.DataAnnotations;
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

        protected abstract Task<bool> RemoveItselfAsync();

        protected abstract Task<byte[]> GetDataAsync();

        async Task<byte[]> IDataAsync.GetDataAsync()
        {
            if (data == null)
            {
                var t = GetDataAsync();
                await t;
                data = t.Result;
            }
            return data;
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



        async void CallAsync()
        {
            ILeafAsync async = this;
            var t = async.RemoveItselfAsync();
            await t;
        }

        async Task<bool> ILeafAsync.RemoveItselfAsync()
        {
            var t = RemoveItselfAsync();
            ILeaf  l = this;
            t.GetAwaiter().OnCompleted(() =>
            {
                if (t.Result)
                {
                    ChildrenName.Remove(this);
                    Parent = null;
                    var i = new Issue(this, ErrorType.None, OperationType.DeleteLeaf);
                    OnDeleteItselfAct(i);
                    return;
                }
                var ii = new Issue(this, ErrorType.Database, OperationType.DeleteLeaf);
                OnDeleteItselfAct(ii);

            });

            await t;

            return t.Result;
        }


        protected async void CallNameAsync(string name)
        {
            var t = Async.UpdateNameAsync(name);
            await t;
        }

        protected abstract Task<byte[]> UpdateDataAcync(byte[] data);
       
        protected override bool UpdateName(string name)
        {
            try
            {
                if (name != this.name)
                {
                    CallNameAsync(name);
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
            return false;

        }

  
        protected abstract Task<string> UpdateNameAsync(string name);

        protected abstract Task<string> UpdateDescriptionAsync(string description);

        async Task<string> ILeafAsync.UpdateNameAsync(string name)
        {
            var s = new UpdateData<string, ILeaf>(this.name, name, this);
            if ((name == this.name) || (!ChildrenName.Check(name)))
            {
                var i = new Issue(s, ErrorType.IllegalName, OperationType.UpdateLeafName);
                OnChangeItselfAct(i);
            }
            var t = UpdateNameAsync(name);
            t.GetAwaiter().OnCompleted(() =>
            {
                var r = t.Result;
                if (r == null)
                {
                    var ii = new Issue(s, ErrorType.Database, OperationType.UpdateLeafName);
                    OnChangeItselfAct(ii);
                }
                this.name = r;
                var iii = new Issue(s, ErrorType.None, OperationType.UpdateLeafName);
                OnChangeItselfAct(iii);
            });
            await t;
            return t.Result;

        }

        Task<string> ILeafAsync.UpdateDescriptionAsync(string description)
        {
            return UpdateDescriptionAsync(description);
        }

        protected override byte[] Data {  set => CallAsync(value); }

        protected async void CallAsync(byte[] data)
        {
            ILeafAsync async = this;
            var t = async.UpdateDataAcync(data);
            await t;
        }

        async Task<byte[]> ILeafAsync.UpdateDataAcync(byte[] data)
        {
            var t = UpdateDataAcync(data);
            t.GetAwaiter().OnCompleted(() =>
            {
                var r = t.Result;
                var s = new UpdateData<byte[], ILeaf>(data, r, this);
                if (r == null)
                {
                    var i = new Issue(s, ErrorType.Database, OperationType.UpdateLeafData);
                    OnUpdateDataAct(i);
                    return;
                }
                var ii = new Issue(s, ErrorType.None, OperationType.UpdateLeafData);
                this.data = r;
                OnUpdateDataAct(ii);
            });
            await t;
            return t.Result;

        }
    }
}