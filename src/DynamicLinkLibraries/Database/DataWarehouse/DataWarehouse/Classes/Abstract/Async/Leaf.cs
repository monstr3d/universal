using DataWarehouse.Interfaces.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Classes.Abstract.Async
{
    public abstract class Leaf : Abstract.Leaf, ILeafAsync
    {

        protected abstract Task<bool> RemoveItselfAsync();
        async Task<bool> ILeafAsync.RemoveItselfAsync()
        {
            var t = RemoveItselfAsync();
            t.GetAwaiter().OnCompleted(() =>
            {
                if (t.Result)
                {
                    OnDeleteItselfAct();
                }
            });
                
            await t;
      
            return t.Result;
        }
    }
}
