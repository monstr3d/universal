using DataPerformer.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataPerformer.Portable.Wrappers
{
    /// <summary>
    /// Wrapper of component collection
    /// </summary>
    public  class ComponentCollectionWrapper
    {
        /// <summary>
        /// The Component collection
        /// </summary>
        public IComponentCollection ComponentCollection { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="componentCollection">The component collection</param>
        public ComponentCollectionWrapper(IComponentCollection componentCollection)
        {
            ComponentCollection = componentCollection;
        }


        /// <summary>
        /// Creates Xml document
        /// </summary>
        /// <param name="consumer">Consumer name</param>
        /// <param name="input">Input</param>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <returns>Document</returns>
    /*!!!    public XmlDocument CreateXmlDocument(string consumer,
            XmlDocument input, double start, double step, int count)
        {
            var desktop = ComponentCollection as IDesktop;
            var c = desktop.GetObject(consumer) as IDataConsumer;
            var wrapper = new DataConsumerWrapper(c);
            return wrapper.CreateXmlDocument(input, start, step, count);
        }*/

        /// <summary>
        /// Creates Xml document
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <returns>Document</returns>
      /* !!!  public XmlDocument CreateXmlDocument(XmlDocument input, double start, double step, int count)
        {
            string consumer = (input.GetElementsByTagName("ChartName")[0] as XmlElement).InnerText;
            return CreateXmlDocument(consumer, input, start, step, count);
        }*/

        /// <summary>
        /// Creates Xml document
        /// </summary>
        /// <param name="input">Input</param>
        /// <returns>Document</returns>
      /* !!! public XmlDocument CreateXmlDocument(XmlDocument input)
        {
            string consumer = (input.GetElementsByTagName("ChartName")[0] as XmlElement).InnerText;
            XmlElement p = input.GetElementsByTagName("Interval")[0] as XmlElement;
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (XmlElement e in p.ChildNodes)
            {
                d[e.Name] = e.InnerText;
            }
            double a = 0;
            double start = (double)d["Start"].FromString(a);
            double step = (double)d["Step"].FromString(a);
            double finish = (double)d["Finish"].FromString(a);
            int count = (int)((finish - start) / step);
            return CreateXmlDocument(consumer, input, start, step, count);
        }*/


        /// <summary>
        /// Performs action with fixed step
        /// </summary>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <param name="provider">Provider of time measure</param>
        /// <param name="processor">Differential equation processor</param>
        /// <param name="priority">Priority</param>
        /// <param name="action">Additional action</param>
        /// <param name="reason">Reason</param>
        public void PerformFixed(double start, double step, int count, ITimeMeasurementProvider provider,
        IDifferentialEquationProcessor processor, int priority, Action action, string reason)
        {
            using (var backup = new
                TimeProviderBackup(ComponentCollection, provider, processor, priority, reason))
            {
                List<IMeasurements> measurements = backup.Measurements;
                IDataRuntime runtime = backup.Runtime;
                ITimeMeasurementProvider old = processor.TimeProvider;
                processor.TimeProvider = provider;
                Action<double, double, long> act = runtime.Step(processor,
                    (double time) => { provider.Time = time; }, reason);
                double last = start;
                double t = start;
                for (int i = 0; i < count; i++)
                {
                    t = start + i * step;
                    act(last, t, (long)i);
                    last = t;
                    action();
                }
                processor.TimeProvider = old;
            }
        }

    }
}
