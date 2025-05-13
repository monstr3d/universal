using System;
using System.Linq.Expressions;
using Abstract3DConverters;

using DataPerformer.Interfaces;
using DataPerformer.Portable.DifferentialEquationProcessors;
using DataPerformer.Portable.Helpers;
using DataPerformer.Portable.Wrappers;
using Diagram.UI.Interfaces;

using OnlineGameConverter.Server.BusinessLogic.Orbital;
using OnlineGameConverter.Server.Classes;

namespace OnlineGameConverter.Server
{
    internal class Performer
    {
        internal Performer()
        {
            var p = new BaseTypes.Performer();
            dateToDouble = p.Convert(BaseTypes.Attributes.TimeType.Second, DateTime.Now);

        }

        private Diagram.UI.Performer performer = new();

        Func<DateTime, double> dateToDouble;
    
        internal IEnumerable<OrbitaForecastItem> Calculate(ForecastCondition condition,
            CancellationToken token)
        {
            try
            {
                if (condition == null)
                {
                    return null;
                }
                if (condition.Begin <= condition.End)
                {
                    return null;
                }
                var d = new Dictionary<string, object>()
                {
                    {"Motion equations.x", condition.X },                    
                    {"Motion equations.y", condition.Y },
                    {"Motion equations.z", condition.Z },
                    {"Motion equations.u", condition.Vx },
                    {"Motion equations.v", condition.Vy },
                           {"Motion equations.w", condition.Vz },
         };
                var orb = new OrbitalForecast();
                //var ali = performer.GetAllAliases(orb);
                performer.SetAliases(orb, d);
                var chart = performer.GetObject<IDataConsumer>(orb, "Chart");

                var wrapper = new DataConsumerWrapper(chart);

                ITimeMeasurementProvider timeprovider = new TimeMeasurementProvider();

                var processor = new RungeProcessor();

                var start = dateToDouble(condition.Begin);

                var finish = dateToDouble(condition.End);

                var steps = (int)(start - finish) + 1;

                var cond = "Recursive.y";

                var mea = wrapper.Measurements;

                var l = new LinkedList<OrbitaForecastItem>();

                var act = () =>
                 {
                    var t = timeprovider.Time;
                    // var dt = DateTime.F

                };

                wrapper.PerformFixed(start, 1, steps,
                 timeprovider, processor, StaticExtensionDataPerformerInterfaces.Calculation,
                 0, token, act, cond, null, null);
              //  StaticExtensionDataPerformerInterfaces.Calculation

                //wrapper.PerformFixed(start, finish, steps, timeprovider, processor,
                //   "C", token, 0, null, cond, null, null, null); 




                return null;
            }
            catch (Exception e)
            {
                e.HandleExceptionDouble("Calculate");
            }
            return null;
        }

        

        internal IDataConsumer Get(IDesktop desktop)
        {
            return null;
        }
    }
}
