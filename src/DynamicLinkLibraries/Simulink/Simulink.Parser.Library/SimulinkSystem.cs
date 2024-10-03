using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using Simulink.Parser.Library.CodeCreators;
using Simulink.Parser.Library.StateFlow;

namespace Simulink.Parser.Library
{
    /// <summary>
    /// Proxy of Simulink system
    /// </summary>
    public class SimulinkSystem
    {
        #region Fields

        SimulinkSubsystem system;

        SimulinkStateflow stateflow;
        #endregion


        #region Ctor

       /* public SimulinkSystem(SimulinkSubsystem system, SimulinkStateflow stateflow)
        {
            this.system = system;
            this.stateflow = stateflow;
        }*/

        /// <summary>
        /// Constructor from Xml document
        /// </summary>
        /// <param name="doc">The document</param>
        public SimulinkSystem(XElement doc)
        {
            XElement e = null;
            foreach (XElement p in doc.GetElementsByTagName("Model"))
            {
                e = p;
                break;
            }
            system = new SimulinkSubsystem(
                e,
                null, new BlockCodeCreator());
           IEnumerable<XElement> nl = doc.GetElementsByTagName("Stateflow");
           foreach (XElement p in nl)
           {
               stateflow = new SimulinkStateflow(p);
                break;
           }
        }

        #endregion 

        /// <summary>
        /// Subsystem
        /// </summary>
        public SimulinkSubsystem Subsystem
        {
            get
            {
                return system;
            }
        }
        
        /// <summary>
        /// Stateflow
        /// </summary>
        public SimulinkStateflow Stateflow
        {
            get
            {
                return stateflow;
            }
        }
    }
}
