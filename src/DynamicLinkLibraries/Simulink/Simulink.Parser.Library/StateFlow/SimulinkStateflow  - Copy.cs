using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Simulink.Parser.Library.StateFlow
{
    /// <summary>
    /// Stateflow for Simulink
    /// </summary>
    public class SimulinkStateflow
    {
        #region Fields

        private XElement element;

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor from Xml element
        /// </summary>
        /// <param name="element">The Xml element</param>
        public SimulinkStateflow(XElement element)
        {
            this.element = element;
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Associated element
        /// </summary>
        public XElement Element
        {
            get
            {
                return element;
            }
        }

        #endregion
    }
}
