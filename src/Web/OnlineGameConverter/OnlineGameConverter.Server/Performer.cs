using Abstract3DConverters;


using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable.DifferentialEquationProcessors;
using DataPerformer.Portable.Helpers;
using DataPerformer.Portable.Wrappers;

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
            doubleToDate = p.ConvertInvert(BaseTypes.Attributes.TimeType.Second, 0);

        }

        private Diagram.UI.Performer performer = new();

        

        Func<DateTime, double> dateToDouble;

        Func<double, DateTime> doubleToDate;

        public Task<List<OrbitalForecastItem>> CalculateAsync(OrbitalForecastCondition condition,
            CancellationToken token)
        {
            return Task.FromResult(Calculate(condition, token));
        }



        internal List<OrbitalForecastItem> Calculate(OrbitalForecastCondition condition,
            CancellationToken token)
        {
            try
            {
                if (condition == null)
                {
                    return null;
                }
                OrbitalForecastConditionNumber cond;
                if (condition is OrbitalForecastConditionNumber c)
                {
                    cond = c;
                }
                else
                {
                    var cc = condition as OrbitalForecastConditionDateTime;
                    cond = new OrbitalForecastConditionNumber
                    {
                        Begin = dateToDouble(cc.Begin),
                        End = dateToDouble(cc.End),
                        X = cc.X,
                        Y = cc.Y,
                        Z = cc.Z,
                        Vx = cc.Vx,
                        Vy = cc.Vy,
                        Vz = cc.Vz,
                    };
                }
                if (cond.Begin >= cond.End)
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
                var orb = new OrbitalForecastCalculator();
                //var ali = performer.GetAllAliases(orb);
                performer.SetAliases(orb, d);
                var chart = performer.GetObject<IDataConsumer>(orb, "Chart");

                var wrapper = new DataConsumerWrapper(chart);

                ITimeMeasurementProvider timeprovider = new TimeMeasurementProvider();

                var processor = new RungeProcessor();

                var start = cond.Begin;

                var finish = cond.End;

                var steps = (int)(finish - start) + 1;

                var orbCondition = "Recursive.y";

                var mea = wrapper.Measurements;

                Dictionary<string, Func<double>> parameters = new();


                foreach (var m in mea)
                {
                    parameters[m.Key] = () => (double)m.Value.Parameter();
                }
                

                var l = new List<OrbitalForecastItem>();

                var act = () =>
                 {
                    var t = timeprovider.Time;
                     var dt = doubleToDate(t);
                     var it = new OrbitalForecastItem(dt, parameters["Motion equations.x"](),
                      parameters["Motion equations.y"](),
                      parameters["Motion equations.z"](),
                      parameters["Motion equations.u"](),
                      parameters["Motion equations.v"](),
                      parameters["Motion equations.w"]()
                        );
                     l.Add(it);
                    // var dt = DateTime.F

                };

                wrapper.PerformFixed(start, 1, steps,
                 timeprovider, processor, StaticExtensionDataPerformerInterfaces.Calculation,
                 0, token, act, orbCondition, null, null);
              //  StaticExtensionDataPerformerInterfaces.Calculation

                //wrapper.PerformFixed(start, finish, steps, timeprovider, processor,
                //   "C", token, 0, null, cond, null, null, null); 




                return l;
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
