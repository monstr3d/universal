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
    /// <param name="registerInfo">Registration info</param>
    /// <returns>Values of output names and types</returns>
    [OperationContract]
    string[] Register(string registerInfo);

    /// <summary>
    /// Unregisters itself
    /// </summary>
    [OperationContract]
    void UnRegister();

    /// <summary>
    /// Sets bytes
    /// </summary>
    /// <param name="bytes"></param>
    [OperationContract]
    void SetBytes(byte[] bytes);
}