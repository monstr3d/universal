using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using Bytes.Exchange;



    /// <summary>
    /// This is the class for Subscription Service that is deployed to listen.
    /// </summary>
[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
public class Subscription : IRegistration
{

    static Dictionary<string,
        List<IEvent>> events = new Dictionary<string, List<IEvent>>();

    static List<IEvent> clients = new List<IEvent>();

    event Action<string, IEvent> onAdd = (string url, IEvent ev) => { };
    
    event Action<string,IEvent> onRemove = (string url, IEvent ev) => { };

    event Action<string, byte[]> receive = (string info, byte[] buffer) => { };


    /// <summary>
    /// This is constructor of the class.It is used here to create the instance of the pub/sub data structure

    /// </summary>
    static Subscription()
    {
        //dictionary = Event.Data.Remote.ServerNet.Dictionary;
    }

    /// <summary>
    /// This method return the complete subscriber list to publisher service.
    /// </summary>
    /// <param name="eventOperation"></param>
    /// <returns></returns>
    internal static List<IEvent> GetClients(string url)
    {
        lock (typeof(Subscription))
        {
            if (events.ContainsKey(url))
            {
                return events[url];
            }
            return null;
        }
    }

    /// <summary>
    /// Clients
    /// </summary>
    public static List<IEvent> Clients
    {
        get
        {
            return clients;
        }
    }

    #region IRegistration Membres

    /// <summary>
    /// This method is called by subscriber to register itself with Server.
    /// It register the client with pub/sub service.
    /// </summary>
    /// <param name="registerInfo"></param>
    string[] IRegistration.Register(string registerInfo)
    {
        lock (typeof(Subscription))
        {
            OperationContext ctx = OperationContext.Current;
            IEvent subscriber = ctx.GetCallbackChannel<IEvent>();
            string url = ctx.EndpointDispatcher.EndpointAddress + "";
            List<IEvent> events;
            if (Subscription.events.ContainsKey(url))
            {
                events = Subscription.events[url];
            }
            else
            {
                events = new List<IEvent>();
                Subscription.events[url] = events;
            }
            if (events.Contains(subscriber))
            {
                return null;
            }
            events.Add(subscriber);
            clients.Add(subscriber);
            onAdd(url, subscriber);
            return new string[0];
        }
    }

    /// <summary>
    /// This method is called by subscriber to Unsubscribe itself from  Server.
    /// It   Unsubscribe the client with pub/sub service.
    /// </summary>
    void IRegistration.UnRegister()
    {
        lock (typeof(Subscription))
        {
            OperationContext ctx = OperationContext.Current;
            string url = ctx.EndpointDispatcher.EndpointAddress + "";
            IEvent subscriber = ctx.GetCallbackChannel<IEvent>();
            List<IEvent> l = events[url];
            if (l.Contains(subscriber))
            {
                l.Remove(subscriber);
            }
            if (l.Count == 0)
            {
                events.Remove(url);
            }
            onRemove(url, subscriber);
            clients.Remove(subscriber);
        }
    }

    void IRegistration.SetBytes(byte[] bytes)
    {
        lock (typeof(Subscription))
        {
            OperationContext ctx = OperationContext.Current;
            string url = ctx.EndpointDispatcher.EndpointAddress + "";
            receive(url, bytes);
        }
    }

    #endregion

    #region Public Members

    /// <summary>
    /// Add client event
    /// </summary>
    public event Action<string, IEvent> Add
    {
        add { onAdd += value; }
        remove { onAdd -= value; }
    }

    /// <summary>
    /// Remove client event
    /// </summary>
    public event Action<string, IEvent> Remove
    {
        add { onRemove += value; }
        remove { onRemove -= value; }
    }

    /// <summary>
    /// Receive bytes event
    /// </summary>
    public event Action<string, byte[]> Receive
    {
        add { receive += value; }
        remove { receive -= value; }
    }

    #endregion
}