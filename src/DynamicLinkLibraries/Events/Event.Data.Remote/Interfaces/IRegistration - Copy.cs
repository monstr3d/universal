using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This is the Service contract for Subscription Service
/// </summary>
[ServiceContract(CallbackContract = typeof(IEvent))]
public interface IRegistration
{
    /// <summary>
    /// Registers itself
    /// </summary>
    /// <returns>Values of output names and types</returns>
    [OperationContract]
    string[] Register();

    /// <summary>
    /// Unregisters itself
    /// </summary>
    [OperationContract]
    void UnRegister();
}