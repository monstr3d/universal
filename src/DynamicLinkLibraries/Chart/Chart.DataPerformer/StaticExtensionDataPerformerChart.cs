﻿using Chart.DataPerformer.Interfaces;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using Chart.Drawing.Interfaces;
using Diagram.UI;
using Diagram.Interfaces;


namespace Chart.DataPerformer
{
    public static class StaticExtensionDataPerformerChart
    {
        /// <summary>
        /// Attached to point factory
        /// </summary>
        static public IAttachedToPointFactory AttachedToPointFactory
        { get; set; } = null;

   
        public static object AttachedToPoint(this object value)
        {
            if (AttachedToPointFactory == null)
            {
                return value;
            }
            return AttachedToPointFactory[value];
        }

        public static Dictionary<string, object> CreateMeasurements(this IDataConsumer consumer, string argument, string[] values, out MeasurementSeries[] series)
        {
            series = [];
            if (argument == null | values == null)
            {
                return null;
            }
            IMeasurement arg = null;
            if (argument.Equals("Time"))
            {
                arg = StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement;
            }
            else
            {
                arg = consumer.FindMeasurement(argument, false);
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            List<MeasurementSeries> m = new List<MeasurementSeries>();
            foreach (string key in values)
            {
                object o = null;
                IMeasurement val = consumer.FindMeasurement(key, false);
                if (val == null)
                {
                    continue;
                }
                object t = val.Type;
                if (t.IsDoubleType())
                {

                    var ps =
                        new MeasurementSeries(arg.ToValueHolder(), val);

                    d[key] = ps;
                    m.Add(ps);
                    o = ps;
                }
                series = m.ToArray();
                consumer.Prepare();
            }
            return d;
        }

        public static Dictionary<string, object> PerformIterator(this IDataConsumer consumer,
            IIterator iterator, string argument, string[] values,
        out MeasurementSeries[] series,
            Func<bool> stop)
        {
            iterator.Reset();
            consumer.ResetAll();
            var rt = consumer.CreateRuntime(null);
            Dictionary<string, object> dic = consumer.CreateMeasurements(argument, values, out series);
            var coll = consumer.GetDependentCollection();
             coll.ForEach((IRunning s) => s.IsRunning = true);
            do
            {
                if (stop())
                {
                    break;
                }
                rt.UpdateAll();
                foreach (var s in series)
                {
                    s.Step();
                }
            }
            while (iterator.Next());
            return dic;
        }

   }

}