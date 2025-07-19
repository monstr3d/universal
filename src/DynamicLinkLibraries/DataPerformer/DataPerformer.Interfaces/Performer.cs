using BaseTypes;
using BaseTypes.Attributes;
using System;

namespace DataPerformer.Interfaces
{
    public class Performer
    {
        public Performer() { }

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
