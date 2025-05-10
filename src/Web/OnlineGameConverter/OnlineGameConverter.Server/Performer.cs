using System;
using System.Linq.Expressions;
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
                           {"Motion equations.vw", condition.Vz },
         };
                  
        /*            +       [9] {[Motion equations.z, 0]}   System.Collections.Generic.KeyValuePair<string, object>
+       [10]    {[Motion equations.o, 0.000145842317]}  System.Collections.Generic.KeyValuePair<string, object>
+       [11]    {[Motion equations.q, 5.3174953569821228E-09]}  System.Collections.Generic.KeyValuePair<string, object>
+       [12]    {[Motion equations.s, 1.6189340462770081E-13]}  System.Collections.Generic.KeyValuePair<string, object>
+       [13]    {[Motion equations.v, 1.21681893834]}   System.Collections.Generic.KeyValuePair<string, object>
+       [14]    {[Motion equations.w, 7.45047785592]}   System.Collections.Generic.KeyValuePair<string, object>
+       [15]    {[Motion equations.y, -4463.93698421]}  System.Collections.Generic.KeyValuePair<string, object>
+       [16]    {[Motion equations.u, -0.985394777432]} System.Collections.Generic.KeyValuePair<string, object>
+       [17]    {[Motion equations.x, -5448.34815324]}  System.Collections.Generic.KeyValuePair<string, object>
        */
                var orb = new OrbitalForecast();
                //var ali = performer.GetAllAliases(orb);
                performer.SetAliases(orb, d);
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
