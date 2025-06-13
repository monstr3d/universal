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
        }
        public DateTime Begin { get; private set; }

        public DateTime End { get; private set; }*/

        public double X { get;  set; }

        public double Y { get;  set; }
        public double Z { get;  set; }

        public double Vx { get;  set; }

        public double Vy { get;  set; }

        public double Vz { get;  set; }


    }

    public record class OrbitalForecastConditionDateTime : OrbitalForecastCondition
    {
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
              public DateTime Begin { get;  set; }

              public DateTime End { get;  set; }

    }


    public record class OrbitalForecastConditionNumber : OrbitalForecastCondition
    {
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
        public double Begin { get; set; }

        public double End { get; set; }

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
