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
    /// Scada Interface
    /// </summary>
    public abstract class ScadaInterface : IScadaInterface
    {
        #region Fields

        protected Dictionary<string, object> inputs = new Dictionary<string, object>();

        protected Dictionary<string, object> outputs = new Dictionary<string, object>();

        protected Dictionary<string, object> constants = new Dictionary<string, object>();

        protected List<string> events = new List<string>();

        //  FOR LATER EVENTS WITH ARGUMENTS   protected List<string> eventOutputs = new List<string>();

        protected Dictionary<string, Action<object>> dInput = new Dictionary<string, Action<object>>();

        protected Dictionary<string, Action<object>> dConstant = new Dictionary<string, Action<object>>();

        protected Dictionary<string, Func<object>> fConstant = new Dictionary<string, Func<object>>();

        protected Dictionary<string, Func<object>> dOutput = new Dictionary<string, Func<object>>();

        protected Dictionary<string, IEvent> dEvents = new Dictionary<string, IEvent>();

        protected Dictionary<string, IEventOutput> dEventOutputs = new Dictionary<string, IEventOutput>();

        protected Dictionary<string, List<string>> objects = new Dictionary<string, List<string>>();

        /// <summary>
        /// Create XML event
        /// </summary>
        protected Action<XElement> onCreateXml = (XElement document) => { };


        /// <summary>
        /// On start event
        /// </summary>
        protected Action onStart = () => { };

        /// <summary>
        /// On Stop event
        /// </summary>
        protected Action onStop = () => { };


        #endregion

        #region IScadaInterface Members

        Dictionary<string, object> IScadaInterface.Inputs
        {
            get { return inputs; }
        }

        Dictionary<string, object> IScadaInterface.Outputs
        {
            get { return outputs; }
        }

        Dictionary<string, object> IScadaInterface.Constants
        {
            get
            {
                return constants;
            }
        }

        List<string> IScadaInterface.Events
        {
            get { return events; }
        }

        /*  FOR LATER EVENTS WITH ARGUMENTS 
           List<string> IScadaInterface.EventOutputs
           {
               get { return eventOutputs; }
           }
   */

        Action<object> IScadaInterface.GetInput(string name)
        {
            return dInput[name];
        }

        /// <summary>
        /// All objects with types
        /// </summary>
        Dictionary<string, List<string>> IScadaInterface.Objects
        {
            get
            {
                return objects;
            }
        }

        /// <summary>
        /// Gets object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="">Name</param>
        /// <returns>The object</returns>
        public abstract T GetObject<T>(string name) where T : class;

        /// <summary>
        /// Sets a constant
        /// </summary>
        /// <param name="name">Constant name</param>
        /// <param name="constant">Constant value</param>
        void IScadaInterface.SetConstant(string name, object constant)
        {
            Action<object> act = dConstant[name];
            act(constant);
        }

        /// <summary>
        /// Gets inputs
        /// </summary>
        /// <param name="names">Input names</param>
        /// <returns>Input names</returns>
        public abstract Action<object[]> GetInput(string[] name);


        Func<object> IScadaInterface.GetOutput(string name)
        {
            return dOutput[name];
        }

        /// <summary>
        /// Gets outputs
        /// </summary>
        /// <param name="names">Names</param>
        /// <returns>Outputs</returns>
        public abstract Func<object[]> GetOutput(string[] names);

        Action<object> IScadaInterface.GetConstant(string name)
        {
            return dConstant[name];
        }

        IEvent IScadaInterface.this[string name]
        {
            get { return dEvents[name]; }
        }

        /*  FOR LATER EVENTS WITH ARGUMENTS 
           IEventOutput IScadaInterface.GetEvent(string name)
           {
             return dEventOutputs[name]; 
           }
        */

        /// <summary>
        /// The "is enabled" sign
        /// </summary>
        public abstract bool IsEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// On start event
        /// </summary>
        event Action IScadaInterface.OnStart
        {
            add { onStart += value; }
            remove { onStart -= value; }
        }

        /// <summary>
        /// On Stop event
        /// </summary>
        event Action IScadaInterface.OnStop
        {
            add { onStop += value; }
            remove { onStop -= value; }
        }

        /// <summary>
        /// Create XML event
        /// </summary>
        event Action<XElement> IScadaInterface.OnCreateXml
        {
            add { onCreateXml += value; }
            remove { onCreateXml -= value; }

        }

        /// <summary>
        /// Xml document
        /// </summary>
        public abstract XElement XmlDocument
        {
            get;
        }

        /// <summary>
        /// Error Handler
        /// </summary>
        public abstract IErrorHandler ErrorHandler
        {
            get;
            set;
        }

        /// <summary>
        /// Refresh
        /// </summary>
        public abstract void Refresh();

        /// <summary>
        /// Gets constant value
        /// </summary>
        /// <param name="name">The name of constant</param>
        /// <returns>The value of constant</returns>
        public abstract object GetConstantValue(string name);

        /// <summary>
        /// On refresh event
        /// </summary>
        public abstract event Action OnRefresh;

        #endregion

    }
}