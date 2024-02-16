using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Diagram.UI.WCF
{
    /// <summary>
    /// Service
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        /// <summary>
        /// Executes task
        /// </summary>
        /// <param name="taskName">Task name</param>
        /// <param name="parametres">Parameters</param>
        /// <returns>Operation return</returns>
        [OperationContract]
        string Execute(string taskName, string parametres);
     }

 }