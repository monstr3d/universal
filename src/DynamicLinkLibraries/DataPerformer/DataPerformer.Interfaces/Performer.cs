using BaseTypes;
using BaseTypes.Attributes;
using CategoryTheory;
using Diagram.UI.Interfaces;
using NamedTree.Interfaces;
using System;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Performer of basic operations
    /// </summary>
    public class Performer : Diagram.UI.Performer
    {
        /// <summary>
        /// Gets factory of object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The factory</returns>
        public IFactory GetFactory(object obj)
        {
            if (obj is IAssociatedObject ao)
            {
                var desktop = GetDesktop(ao);
                if (desktop is IFactoryConsumer fc)
                {
                    return fc.Factory;
                }
            }
            return null;
        }
 
  
        public Func<double> Create(ITimeMeasurementConsumer consumer, TimeType timeType = TimeType.Second)
        {
            var m = consumer.Time;
            var f = () => (double)m.Parameter();
            if (timeType == TimeType.Second)
            {
                return f;
            }
            var k = TimeType.Second.Coefficient(timeType);
            return () => k * f();
        }


    }
}
