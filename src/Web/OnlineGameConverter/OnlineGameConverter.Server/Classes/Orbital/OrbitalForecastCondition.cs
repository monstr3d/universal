using OnlineGameConverter.Server.Interfaces;

namespace OnlineGameConverter.Server.Classes.Orbital
{
    /// <summary>
    /// Condition of forecast
    /// </summary>
    /*
                    var cond = new ForecastCondition(DateTime.Now, DateTime.Now, -5448.34815324,
                    -4463.93698421, 0, -0.985394777432, 1.21681893834, 7.45047785592);

     */
    public  class OrbitalForecastCondition
    {
        public OrbitalForecastCondition() { }
 
        public double X { get;  set; }

        public double Y { get; set; }
        public double Z { get; set; }

        public double Vx { get; set; }

        public double Vy { get; set; }

        public double Vz { get; set; }

        public OrbitalForecastCondition(OrbitalForecastCondition other)
        {
            X = other.X;
            Y = other.Y;
            Z = other.Z;
            Vx = other.Vx;
            Vy = other.Vy;
            Vz = other.Vz;
        }


    }

    public class OrbitalForecastConditionDateTime : OrbitalForecastCondition
    {

        public OrbitalForecastConditionDateTime()
        {

        }

        public OrbitalForecastConditionDateTime(OrbitalForecastCondition condition) : base(condition) 
        {

        }



        public DateTime Begin { get; set; }

        public DateTime End { get; set; }

        public List<OrbitaForecastItem> Items { get; set; } = new List<OrbitaForecastItem>();


    }

   

    public  class OrbitalForecastItemNumberPure : OrbitalForecastCondition
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


    public  class OrbitalForecastConditionNumber :  OrbitalForecastCondition
    {

        public OrbitalForecastConditionNumber()
        {

        }

        public OrbitalForecastConditionNumber(OrbitalForecastCondition condition)
        {
            this.X = condition.X;
            this.Y = condition.Y;
            this.Z = condition.Z;
            this.Vx = condition.Vx;
            this.Vy = condition.Vy;
            this.Vz = condition.Vz;
        }



        public double Begin { get; set; }

        public double End { get; set; }

        

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
