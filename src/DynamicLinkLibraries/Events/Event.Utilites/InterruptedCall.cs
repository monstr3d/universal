using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Event.Utilites
{
    public class InterruptedCall
    {
        IAsyncResult r;

        bool success = false;

        AutoResetEvent ev;

        void Call(Action action,  AutoResetEvent ev)
        {
            this.ev = ev;
            r = action.BeginInvoke(null, null);
            Thread t = new Thread(Run);
            t.Start();
            ev.WaitOne();
            if (success)
            {
                action.EndInvoke(r);
                return;
            }
            r.AsyncWaitHandle.Close();
            throw new Exception();
        }

        void Run()
        {
            r.AsyncWaitHandle.WaitOne();
            success = true;

        }
    }
}
