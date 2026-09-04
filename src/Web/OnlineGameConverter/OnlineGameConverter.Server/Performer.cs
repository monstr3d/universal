using Abstract3DConverters;
using DataPerformer.Interfaces;
using DataPerformer.Portable.DifferentialEquationProcessors;
using DataPerformer.Portable.Helpers;
using DataPerformer.Portable.Wrappers;
using Diagram.UI;
using Diagram.UI.Interfaces;
using OnlineGameConverter.Server.BusinessLogic.Orbital;
using OnlineGameConverter.Server.Classes.Orbital;
using System.Diagnostics;

namespace OnlineGameConverter.Server
{
    internal class Performer
    {
        private Diagram.UI.Performer performer = new();
        OrbitalForecastCondition condition;


        internal Performer()
        {
            var p = new BaseTypes.Performer();
            dateToDouble = p.Convert(BaseTypes.Attributes.TimeType.Second, DateTime.Now);
            doubleToDate = p.ConvertInvert(BaseTypes.Attributes.TimeType.Second, 0);
            var orb = new OrbitalForecastCalculator();
            var aliases = orb.GetAllAliases();
            condition = new OrbitalForecastCondition
            {
                X = (double)aliases["Motion equations.x"],
                Y = (double)aliases["Motion equations.y"],
                Z = (double)aliases["Motion equations.z"],
                Vx = (double)aliases["Motion equations.u"],
                Vy = (double)aliases["Motion equations.v"],
                Vz = (double)aliases["Motion equations.w"],
            };

        }

        

        public Task<OrbitalForecastItemNumberPure> GetInitialAsync()
        {
            return Task.FromResult(GetInitial());
        }

        public OrbitalForecastItemNumberPure GetInitial()
        {
            var dt = DateTime.Now;
            var b = dt.ToOADate() * 86400;
            var e = b + 20000;

            return new OrbitalForecastItemNumberPure
            {
                Begin = b,
                End = e,
                X = condition.X,
                Y = condition.Y,
                Z = condition.Z,
                Vx= condition.Vx,
               Vy = condition.Vy,
               Vz = condition.Vz,

            };


        }

        public OrbitalForecastConditionNumber GetInitialNumber()
        {
            var dt = DateTime.Now;
            return new OrbitalForecastConditionNumber
            {
                Begin = dateToDouble(dt),
                End = dateToDouble(dt) + 20000,
                X = condition.X,
                Y = condition.Y,
                Z = condition.Z,
                Vx = condition.Vx,
                Vy = condition.Vy,
                Vz = condition.Vz,

            };


        }


        Func<DateTime, double> dateToDouble;

        Func<double, DateTime> doubleToDate;

        public Task<List<OrbitalForecastItemNumber>> CalculateOrbitalForecastFromNubmerAsync(OrbitalForecastConditionNumber condition,
            CancellationToken token)
        {
            return Task.FromResult(CalculateOrbitalForecastItemNumber(condition, token));
        }

        public Task<List<OrbitaForecastItem>> CalculateOrbitalForecastFromDatetimeAsync(OrbitalForecastConditionDateTime condition,
         CancellationToken token)
        {
            return Task.FromResult(CalculateOrbitalForecastItemDateTime(condition, token));
        }


        Tuple<DataConsumerWrapper, ITimeMeasurementProvider,
           IDifferentialEquationProcessor, string, Dictionary<string, Func<double>>, double, int> PrepareCalculation(OrbitalForecastCondition condition)
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

            return new Tuple<DataConsumerWrapper, ITimeMeasurementProvider, IDifferentialEquationProcessor, string,
                Dictionary<string, Func<double>>, double, int>
           (wrapper, timeprovider, processor, orbCondition, parameters, start, steps);

        }



        internal List<OrbitaForecastItem> CalculateOrbitalForecastItemDateTime(OrbitalForecastConditionDateTime condition,
    CancellationToken token)
        {
            try
            {
                var prp = PrepareCalculation(condition);
                if (prp == null)
                {
                    return Enumerable.Empty<OrbitaForecastItem>().ToList();
                }
                var parameters = prp.Item5;

                var l = new List<OrbitaForecastItem>();

                var act = () =>
                {
                    var t = prp.Item2.Time;

                    var it = new OrbitaForecastItem
                    {
                        DateTime =  doubleToDate(t),
                        X = parameters["Motion equations.x"](),
                        Y = parameters["Motion equations.y"](),
                        Z = parameters["Motion equations.z"](),
                        Vx = parameters["Motion equations.u"](),
                        Vy = parameters["Motion equations.v"](),
                        Vz = parameters["Motion equations.w"]()

                    };

                    l.Add(it);
                    // var dt = DateTime.F

                };

                prp.Item1.PerformFixed(prp.Item6, 1, prp.Item7, prp.Item2, prp.Item3,
                 StaticExtensionDataPerformerInterfaces.Calculation, 0, token,  act, "Recursive.y", null, null);
                return l;
 
            }
            catch (Exception e)
            {
                e.HandleExceptionDouble("Calculate");
            }
            return null;
        }



        public List<OrbitalForecastItemNumber> CalculateOrbitalForecastItemNumber(OrbitalForecastConditionNumber condition)
        {
            var ct = new CancellationToken();
            return CalculateOrbitalForecastItemNumber(condition, ct);
        }



        public List<OrbitalForecastItemNumber> CalculateOrbitalForecastItemNumber(OrbitalForecastConditionNumber condition,
            CancellationToken token)  
        {
            try
            {
                var sw = new Stopwatch();
                sw.Start();
                var prp = PrepareCalculation(condition);
                if (prp == null)
                {
                    return Enumerable.Empty<OrbitalForecastItemNumber>().ToList();
                }
                var parameters = prp.Item5;

                var l = new List<OrbitalForecastItemNumber>();

                var act = () =>
                 {
                     var t = prp.Item2.Time;
                     sw.Stop();
                     var it = new OrbitalForecastItemNumber
                     {
                         OrbitalTime = t,
                         X = parameters["Motion equations.x"](),
                         Y = parameters["Motion equations.y"](),
                         Z = parameters["Motion equations.z"](),
                         Vx = parameters["Motion equations.u"](),
                         Vy = parameters["Motion equations.v"](),
                         Vz = parameters["Motion equations.w"](),
                         Duration = sw.ElapsedMilliseconds
                     };
                     sw.Start();
                     l.Add(it);
                    // var dt = DateTime.F

                };
                prp.Item1.PerformFixed(prp.Item6, 1, prp.Item7, prp.Item2, prp.Item3,
                        StaticExtensionDataPerformerInterfaces.Calculation, 0, token, act, "Recursive.y", null, null);

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
