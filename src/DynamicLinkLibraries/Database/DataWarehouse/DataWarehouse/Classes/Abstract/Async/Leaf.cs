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

        IChildrenName ChildrenName => Parent as IChildrenName;

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
            var d = Parent as Directory;
            ILeafAsync async = this;
            INamed named = this;
            var t = async.UpdateNameAsync(name);
            t.GetAwaiter().OnCompleted(() =>
            {
                this.name = t.Result;
                d.Change(this.name, name);
                OnChangeItselfAct(this);
            });
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

        Task<string> ILeafAsync.UpdateNameAsync(string name)
        {
            return UpdateNameAsync(name);
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
                var s = new UpdateData(data, r, this);
                if (r == null)
                {
                    var i = new Issue(s, ErrorType.Database, OperationType.UpdateLeafData);
                    OnUpdateDataAct(i);
                    return;
                }
                var ii = new Issue(s, ErrorType.None, OperationType.UpdateLeafData);
                OnUpdateDataAct(ii);
                this.data = r;
            });
            await t;
            return t.Result;

        }
    }
}