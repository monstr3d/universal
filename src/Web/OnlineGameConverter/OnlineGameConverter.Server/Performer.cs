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
            doubleToDate = p.ConvertInvert(BaseTypes.Attributes.TimeType.Second, 0);

        }

        private Diagram.UI.Performer performer = new();

        

        Func<DateTime, double> dateToDouble;

        Func<double, DateTime> doubleToDate;

        public Task<List<OrbitalForecastItemNumber>> CalculateOrbitalForecastFromNubmerAsync(OrbitalForecastConditionNumber condition,
            CancellationToken token)
        {
            return Task.FromResult(CalculateOrbitalForecastItemNumber(condition, token));
        }

        public Task<List<OrbitalForecastItemString>> CalculateOrbitalForecastFromStringAsync(OrbitalForecastConditionString condition,
       CancellationToken token)
        {
            return Task.FromResult(CalculateOrbitalForecastItemString(condition, token));
        }


        public Task<List<OrbitalForecastItem>> CalculateOrbitalForecastFromDatetimeAsync(OrbitalForecastConditionDateTime condition,
         CancellationToken token)
        {
            return Task.FromResult(CalculateOrbitalForecastItemDateTime(condition, token));
        }


        Tuple<DataConsumerWrapper, ITimeMeasurementProvider, 
            IDifferentialEquationProcessor, string, Dictionary<string, Func<double>>, double, int> PrepareCalculation(OrbitalForecastConditionNumber condition)
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
   /*             var cc = condition as OrbitalForecastConditionDateTime;
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
                };*/
            }
            cond = condition;
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

            return new Tuple<DataConsumerWrapper, ITimeMeasurementProvider, IDifferentialEquationProcessor, string,
                Dictionary<string, Func<double>>, double, int>
           (wrapper, timeprovider, processor, orbCondition, parameters, start, steps);

        }


        Tuple<DataConsumerWrapper, ITimeMeasurementProvider,
            IDifferentialEquationProcessor, string, Dictionary<string, Func<double>>, double, int> PrepareCalculation(OrbitalForecastConditionString condition)
        {
            if (condition == null)
            {
                return null;
            }
            OrbitalForecastConditionString cond;
                 /*             var cc = condition as OrbitalForecastConditionDateTime;
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
                             };*/
              var d = new Dictionary<string, object>()
                {
                    {"Motion equations.x", double.Parse( condition.X) },
                    {"Motion equations.y",  double.Parse(condition.Y) },
                    {"Motion equations.z", double.Parse(condition.Z) },
                    {"Motion equations.u", double.Parse(condition.Vx) },
                    {"Motion equations.v", double.Parse(condition.Vy) },
                           {"Motion equations.w", double.Parse(condition.Vz) },
         };
            var orb = new OrbitalForecastCalculator();
            //var ali = performer.GetAllAliases(orb);
            performer.SetAliases(orb, d);

            var chart = performer.GetObject<IDataConsumer>(orb, "Chart");

            var wrapper = new DataConsumerWrapper(chart);

            ITimeMeasurementProvider timeprovider = new TimeMeasurementProvider();

            var processor = new RungeProcessor();

            var start = double.Parse(condition.Begin);

            var finish = double.Parse(condition.End);

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


        Tuple<DataConsumerWrapper, ITimeMeasurementProvider,
            IDifferentialEquationProcessor, string, Dictionary<string, Func<double>>, double, int> PrepareCalculation(OrbitalForecastConditionDateTime condition)
        {
            if (condition == null)
            {
                return null;
            }
           var cc = condition;
           var   cond = new OrbitalForecastConditionNumber
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

            return new Tuple<DataConsumerWrapper, ITimeMeasurementProvider, IDifferentialEquationProcessor, string,
                Dictionary<string, Func<double>>, double, int>
           (wrapper, timeprovider, processor, orbCondition, parameters, start, steps);

        }



        internal List<OrbitalForecastItem> CalculateOrbitalForecastItemDateTime(OrbitalForecastConditionDateTime condition,
    CancellationToken token)
        {
            try
            {
                var prp = PrepareCalculation(condition);
                if (prp == null)
                {
                    return Enumerable.Empty<OrbitalForecastItem>().ToList();
                }
                var parameters = prp.Item5;

                var l = new List<OrbitalForecastItem>();

                var act = () =>
                {
                    var t = prp.Item2.Time;

                    var it = new OrbitalForecastItem 
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



        internal List<OrbitalForecastItemNumber> CalculateOrbitalForecastItemNumber(OrbitalForecastConditionNumber condition,
            CancellationToken token)  
        {
            try
            {
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

                     var it = new OrbitalForecastItemNumber
                     {
                         EquatorTime = t,
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
                        StaticExtensionDataPerformerInterfaces.Calculation, 0, token, act, "Recursive.y", null, null);

                return l;
            }
            catch (Exception e)
            {
                e.HandleExceptionDouble("Calculate");
            }
            return null;
        }



        internal List<OrbitalForecastItemString> CalculateOrbitalForecastItemString(OrbitalForecastConditionString condition,
            CancellationToken token)
        {
            try
            {
                var prp = PrepareCalculation(condition);
                if (prp == null)
                {
                    return Enumerable.Empty<OrbitalForecastItemString>().ToList();
                }
                var parameters = prp.Item5;

                var l = new List<OrbitalForecastItemString>();

                var act = () =>
                {
                    var t = prp.Item2.Time;

                    var it = new OrbitalForecastItemString
                    {
                        EquatorTime = t + "",
                        X = parameters["Motion equations.x"]() + "",
                        Y = parameters["Motion equations.y"]() + "",
                        Z = parameters["Motion equations.z"]() + "",
                        Vx = parameters["Motion equations.u"]() + "",
                        Vy = parameters["Motion equations.v"]() + "",
                        Vz = parameters["Motion equations.w"]() + ""

                    };

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
