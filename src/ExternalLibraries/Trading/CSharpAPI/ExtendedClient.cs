using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IBApi
{
    public class ExtendedClient : EWrapperComposition
    {
        IBClient client = null;

        EReaderSignal signal = null;

        public static event Action OnAdd;
  
        public ExtendedClient(EReaderSignal signal) : base(null)
        {
            this.signal = signal;
            client = new IBClient(signal, this);
            var l = new List<EWrapper>();
            l.Add(client);
            l.Add(new BasicWrapper());
            wrappers = l;
            IClientHolder holder = this;
            holder.Client = (client as ISoketHolder).ClientSocket;
        }




        public IBClient Client
        { get => client; }

        public void Clear()
        {
            Add(new EWrapper[] { new BasicWrapper() });
            OnAdd();
        }


        public void Add(IEnumerable<EWrapper> wrappers)
        {
            var l = new List<EWrapper>();
            if (client != null)
            {
                l.Add(client);
            }
            if (wrappers == null)
            {
                return;
            }
            l.AddRange(wrappers);
            this.wrappers = l;
            SetWrappers();
            IClientHolder holder = this;
            holder.Client = (client as ISoketHolder).ClientSocket;
        }
    }
}