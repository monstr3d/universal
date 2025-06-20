using OnlineGameConverter.Server.Interfaces;

namespace OnlineGameConverter.Server.Classes
{
    /// <summary>
    /// Condition of forecast
    /// </summary>
    /*
                    var cond = new ForecastCondition(DateTime.Now, DateTime.Now, -5448.34815324,
                    -4463.93698421, 0, -0.985394777432, 1.21681893834, 7.45047785592);

     */
    public record class OrbitalForecastCondition
    {
 
        public double X { get;  init; }

        public double Y { get; init; }
        public double Z { get; init; }

        public double Vx { get; init; }

        public double Vy { get; init; }

        public double Vz { get; init; }


    }

    public record  class OrbitalForecastConditionDateTime : OrbitalForecastCondition
    {
              public DateTime Begin { get; init; }

              public DateTime End { get; init; }

    }

    public record class OrbitalForecastItemNumberPure : OrbitalForecastCondition
    {
        public double Begin { get; init; }

        public double End { get; init; }

        public double Time { get; init; }
        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }
        public double Vx { get; init; }
        public double Vy { get; init; }
        public double Vz { get; init; }
    }


    public record  class OrbitalForecastConditionNumber :  OrbitalForecastCondition
    {
        public double Begin { get; init; }

        public double End { get; init; }

        /*      public OrbitalForecastCondition(DateTime begin, DateTime end, double x, 
                  double y, double z, double Vx, double Vy, double Vz )
              {
                  Begin = begin;
                  End = end;
                  X = x;
                  Y = y;     
                  Z = z;  
                  this.Vx = Vx;
                  this.Vy = Vy;
                  this.Vz = Vz;
              }*/


    }




    public class ForecastConditionSingleton : IForecastConditionSingleton
    {
        OrbitalForecastConditionDateTime condition = null;
        public ForecastConditionSingleton()
        {
        }

        OrbitalForecastConditionDateTime IForecastCondition.ForecastCondition { get; set; }
    }
}
