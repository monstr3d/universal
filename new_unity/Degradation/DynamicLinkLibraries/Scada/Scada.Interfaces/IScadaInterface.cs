using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Scada.Interfaces
{
    /// <summary>
    /// Scada interface
    /// </summary>
    public interface IScadaInterface
    {
        /// <summary>
        /// Inputs
        /// </summary>
        Dictionary<string, object> Inputs
        {
            get;
        }

        /// <summary>
        /// Outputs
        /// </summary>
        Dictionary<string, object> Outputs
        {
            get;
        }


        /// <summary>
        /// Sets a constant
        /// </summary>
        /// <param name="name">Constant name</param>
        /// <param name="constant">Constant value</param>
        void SetConstant(string name, object constant);

        /// <summary>
        /// Gets constant value
        /// </summary>
        /// <param name="name">The name of constant</param>
        /// <returns>The value of constant</returns>
        object GetConstantValue(string name);


        /// <summary>
        /// Constants
        /// </summary>
        Dictionary<string, object> Constants
        {
            get;
        }

        /// <summary>
        /// Events
        /// </summary>
        List<string> Events
        {
            get;
        }

        /*  !!! FOR LATER EVENTS WITH ARGUMENTS 
         *  /// <summary>
          /// Events with outputs
          /// </summary>
          List<string> EventOutputs
          {
              get;
          }
        */

          /// <summary>
          /// All objects with types
          /// </summary>
          Dictionary<string, List<string>> Objects
          {
              get;
          }

          /// <summary>
          /// Gets input
          /// </summary>
          /// <param name="name">Input name</param>
          /// <returns>Input</returns>
          Action<object> GetInput(string name);

          /// <summary>
          /// Gets inputs
          /// </summary>
          /// <param name="names">Input names</param>
          /// <returns>Input names</returns>
          Action<object[]> GetInput(string[] names);

          /// <summary>
          /// Gets constant
          /// </summary>
          /// <param name="name">Constant</param>
          /// <returns>Constant</returns>
          Action<object> GetConstant(string name);


          /// <summary>
          /// Gets output
          /// </summary>
          /// <param name="name">Name</param>
          /// <returns>Output</returns>
          Func<object> GetOutput(string name);

          /// <summary>
          /// Gets outputs
          /// </summary>
          /// <param name="names">Names</param>
          /// <returns>Outputs</returns>
          Func<object[]> GetOutput(string[] names);

          /// <summary>
          /// Gets event
          /// </summary>
          /// <param name="name">Event name</param>
          /// <returns>The event</returns>
          IEvent this[string name]
          {
              get;
          }
       /* !!! FOR LATER EVENTS WITH ARGUMENTS 
          /// <summary>
          /// Gets event output
          /// </summary>
          /// <param name="name"></param>
          /// <returns></returns>
          IEventOutput GetEvent(string name);
       */
        /// <summary>
        /// Gets object of type 
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="name">Object name</param>
        /// <returns>The object</returns>
        T GetObject<T>(string name) where T : class;

        /// <summary>
        /// The "is enabled" sign
        /// </summary>
        bool IsEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// On start event
        /// </summary>
        event Action OnStart;

        /// <summary>
        /// On Stop event
        /// </summary>
        event Action OnStop;

        /// <summary>
        /// Create XML event
        /// </summary>
        event Action<XElement> OnCreateXml;

        /// <summary>
        /// Xml document
        /// </summary>
        XElement XmlDocument
        {
            get;
        }

        /// <summary>
        /// Error Handler
        /// </summary>
        IErrorHandler ErrorHandler
        {
            get;
            set;
        }

        /// <summary>
        /// Refresh
        /// </summary>
        void Refresh();

        /// <summary>
        /// On refresh event
        /// </summary>
        event Action OnRefresh;

    }
}