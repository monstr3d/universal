using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using Bytes.Exchange;

[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
public class Publishing : IEvent
{
    #region Fields

    string url;

    Action<byte[]> ev = (byte[] b) => { };

    #endregion

    #region Ctor

    /// <summary>
    /// Default constructor
    /// </summary>
    public Publishing()
    {

    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="url">URL</param>
    public Publishing(string url)
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
        ev(e.Data);
    }

    #endregion

    #region Event
    /// <summary>
    /// Event
    /// </summary>
    public event Action<byte[]> Event
    {
        add { ev += value; }
        remove { ev -= value; }
    }

    #endregion

}

 
 