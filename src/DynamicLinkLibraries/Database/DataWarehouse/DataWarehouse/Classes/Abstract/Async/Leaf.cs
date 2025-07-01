using DataWarehouse.Interfaces.Async;
using NamedTree;
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
