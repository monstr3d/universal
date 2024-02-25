using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Interfaces
{
    /// <summary>
    /// Collection of scada consumer factories
    /// </summary>
    public class ScadaConsumerFactoryCollection : IScadaConsumerFactory
    {
        #region Fields

        List<IScadaConsumerFactory> factories = new List<IScadaConsumerFactory>();

        #endregion

        #region IScadaConsumerFactory Members

        IScadaConsumer IScadaConsumerFactory.this[object prototype]
        {
            get
            {
                foreach (IScadaConsumerFactory factory in factories)
                {
                    IScadaConsumer consumer = factory[prototype];
                    if (consumer != null)
                    {
                        return consumer;
                    }
                }
                return null;
            }
        }

        IScadaConsumer IScadaConsumerFactory.this[IScadaInterface scada, object prototype]
        {
            get
            {
                foreach (IScadaConsumerFactory factory in factories)
                {
                    IScadaConsumer consumer = factory[scada, prototype];
                    if (consumer != null)
                    {
                        return consumer;
                    }
                }
                return null;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Adds a factory
        /// </summary>
        /// <param name="factory">The factory</param>
        public void Add(IScadaConsumerFactory factory)
        {
            factories.Add(factory);
        }

        #endregion
    }
}
