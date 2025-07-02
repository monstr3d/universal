using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using ErrorHandler;
using NamedTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DataWarehouse.Classes.Abstract.Async
{
    public abstract class Leaf : Abstract.Leaf, ILeafAsync, IDataAsync
    {


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
                    IChildren<ILeaf?> p = Parent as IChildren<ILeaf>;
                    p.RemoveChild(this);
                    Parent = null;
                }
                OnDeleteItselfAct(this);

            });

            await t;

            return t.Result;
        }

        protected async void CallNameAsync(string name)
        {
            var d = Parent as Directory;

            ILeafAsync async = this;
            INamed named = this;
            named.NewName = name;
            var t = async.UpdateNameAsync(name);
            t.GetAwaiter().OnCompleted(() =>
            {
                this.name = t.Result;
                d.Change(this.name, name);
                OnChangeItselfAct(this);
            });
            await t;
        }


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
    }
}