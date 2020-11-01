using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI;



[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
class Publishing : IEvent
{
    #region Fields

    string url;

    #endregion

    #region Ctor

    internal Publishing(string url)
    {
        this.url = url;
    }

    #endregion

    #region IEvent Members
    /// <summary>
    /// This method is called from the publisher client to send the event.
    /// </summary>
    /// <param name="e"></param>
    public void OnEvent(AlertData e)
    {

        List<IEvent> subscribers = Subscription.GetClients(url);
        if (subscribers == null)
        {
            return;
        }
        MethodInfo methodInfo = typeof(IEvent).GetMethod("OnEvent");
        foreach (IEvent subscriber in subscribers)
        {
            try
            {
                methodInfo.Invoke(subscriber, new object[] { e });
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }
    }

    #endregion

}

 
 