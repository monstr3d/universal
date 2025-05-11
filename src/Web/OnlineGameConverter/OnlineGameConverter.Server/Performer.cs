using Abstract3DConverters;
using DataPerformer.Interfaces;
using Diagram.UI.Interfaces;
using OnlineGameConverter.Server.BusinessLogic.Orbital;
using OnlineGameConverter.Server.Classes;

namespace OnlineGameConverter.Server
{
    internal class Performer
    {
        private Diagram.UI.Performer performer = new();
    
        internal IEnumerable<OrbitaForecastItem> Calculate(ForecastCondition condition,
            CancellationToken token)
        {
            try
            {
  

                if (condition == null)
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
